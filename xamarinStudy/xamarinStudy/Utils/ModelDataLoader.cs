using NMAP.ViewModels.Common;
using NMAP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XNSC.DD.EX;
using NAMHE.Model;
using XNSC;
using XNSC.Net;
using System.Linq;
using Acr.UserDialogs;
using Xamarin.Forms;
using Plugin.DeviceInfo.Abstractions;
using Xamarin.Forms.PlatformConfiguration;
using System.Data;
using System.Net.NetworkInformation;

namespace NMAP.Utils
{
    /// <summary>
    /// 모델 데이토 로드
    /// </summary>
    internal static class ModelDataLoader
    {
        /// <summary>
        /// 메뉴 로딩 여부
        /// </summary>
        public static bool IsMenuLoading{get; private set;}

        /// <summary>
        /// Navigator 메뉴 리스트
        /// </summary>
        public static ObservableCollection<MenuDataModel> NaviMenuList { get; private set; } = InitNaviMenuList();


        /// <summary>
        /// 메뉴 리스트
        /// </summary>
        public static ObservableCollection<MenuDataModel> MenuList { get; private set; }  

        /// <summary>
        /// 메뉴 리스트 초기화
        /// </summary>
        /// <returns></returns>
        private static ObservableCollection<MenuDataModel> InitNaviMenuList()
        {
            //공통 화면
            var menuList = new ObservableCollection<MenuDataModel>
            {
                new MenuDataModel() { Name = "LOGIN", Title = "로그인", Description = "로그인", PageName = "NMAP.Pages.Common.LoginPage", IsMenuDisplay = false, Seq=int.MaxValue },
                new MenuDataModel() { Name = "AENV", Title = "시스템사용요청", Description = "시스템사용요청", PageName = "NMAP.Pages.Common.AENV", IsMenuDisplay = false, Seq=int.MaxValue },
                new MenuDataModel() { Name = "CHGPWD", Title = "암호변경", Description = "암호변경", PageName = "NMAP.Pages.Common.CHGPWD", IsMenuDisplay = false },
                new MenuDataModel() { Name = "SYSREQ", Title = "시스템사용요청", Description = "시스템사용요청", PageName = "NMAP.Pages.Common.SYSREQ", IsMenuDisplay = false, Seq=int.MaxValue }
            };

            MenuList = new ObservableCollection<MenuDataModel>();

            return menuList;
        }

        /// <summary>
        /// 메뉴 리스트를 Clea한다.
        /// </summary>
        public static void ClearMenuList()
        {
            NaviMenuList?.Clear();
            MenuList?.Clear();
        }

        /// <summary>
        /// 로그인 정보를 가져 온다.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public static async Task<NmapLoginResult> GetLoginInfo(string userId, string passwd)
        {
            try
            {
                var dataService = ImateHelper.GetSingleTone();

                // 사용자 ID 체크
                //
                var result8100Model = await dataService.Adapter.SelectModelDataAsync<ZNBPSysrqModelList>(App.DbTitle, "NBPDataModels", "NAMHE.Model.ZNBPSysrqModelList", new string[0],
                  $"MANDT = '{App.Mandt}' AND APPID = '{App.APPID}' AND UPPER(LOGID) = UPPER('{userId}') ", "", QueryCacheType.None);

                var logData = result8100Model;

                if (logData.Count == 0)
                    return new NmapLoginResult() { Result = false, Message = "사용자ID또는 암호가 잘못되었습니다.", DefaultPathParams = null };

                var loginInfo = logData.First();
                var passwdHash = CRYPT.SHA256Hash(passwd);
                if (passwdHash.ToLower() != loginInfo.LOGPW.ToLower())
                    return new NmapLoginResult() { Result = false, Message = "사용자ID또는 암호가 잘못되었습니다.", DefaultPath = "#", DefaultPathParams = null };

                if (loginInfo.APPST == "R")
                    return new NmapLoginResult() { Result = false, Message = "시스템 사용 요청 중입니다.", DefaultPath = "#", DefaultPathParams = null };

                if (loginInfo.APPST == "E")
                    return new NmapLoginResult() { Result = false, Message = "시스템 사용이 중지 되었습니다,", DefaultPath = "#", DefaultPathParams = null };

                if (loginInfo.INITPW == "Y")
                    return new NmapLoginResult() { Result = false, Message = "초기암호입니다. 암호변경 페이지로 이동 합니다.", DefaultPath = "CHGPWD", DefaultPathParams = new object[] { loginInfo } };

                //-----------------------------------------------------------
                // 역활체크
                //
                var role = loginInfo.ROLE;
                var perm = loginInfo.PERM;

                //-----------------------------------------------------------------------------------
                if (perm == null || perm.Length == 0)
                    return new NmapLoginResult() { Result = false, Message = "권한이 잘못 되었습니다.", DefaultPath = "#" };

                var whereCond = $"APPID = '{App.APPID}' AND ROLEID = '{role}'";
                var roleModels = await dataService.Adapter.SelectModelDataAsync<ZNBPRoleModelList>(App.DbTitle, "NBPDataModels", "NAMHE.Model.ZNBPRoleModelList", null, whereCond, "", QueryCacheType.None);
                if (roleModels.Count == 0)
                    return new NmapLoginResult() { Result = false, Message = "역활정보가  잘못되었습니다.", DefaultPath = "#", DefaultPathParams = null };

                var roleModel = roleModels.First();
                //-------------------------------------------------------------------
                // 디바이스 체크
                //
                if (roleModel.ROLEOPT == "S")
                {
                    if (App.DeviceId.ToLower() != loginInfo.MACID.ToLower())
                        return new NmapLoginResult() { Result = false, Message = "사용신청한 모바일기기와 틀립니다. 시스템 사용요청 페이지로 이동 합니다.", DefaultPath = "SYREQ", DefaultPathParams = null };
                 }
                else if (roleModel.ROLEOPT == "L")
                {
                    var findMac = await dataService.Adapter.SelectModelDataAsync<ZNBPSysrqModelList>(App.DbTitle, "NBPDataModels", "NAMHE.Model.ZNBPSysrqModelList", null,
                      $"APPID = '{App.APPID}' AND UPPER(MACID) = UPPER('{App.DeviceId}')", "", QueryCacheType.None);

                    if (findMac.Count == 0)
                        return new NmapLoginResult() { Result = false, Message = "사용신청이 안된 모바일 기기 입니다. 시스템 사용요청 페이지로 이동 합니다.", DefaultPath = "SYREQ", DefaultPathParams = null };
                }

                var orgOption = new OrganizationOption();
                orgOption.OrgType = loginInfo.RQTYP;
                orgOption.VOrgId = loginInfo.VORGID;
                orgOption.COrgId = loginInfo.CORGID;
                orgOption.TOrgId = loginInfo.TORGID;
                orgOption.YOrgId = loginInfo.YORGID;
                orgOption.EtcOrgId1 = loginInfo.ETCORG1;
                orgOption.EtcOrgId2 = loginInfo.ETCIRG2;

                var loginResult = loginInfo.RQTYP == "Y"
                  ? new LoginDataModel()
                  {
                      UserId = loginInfo.LOGID,
                      UserName = loginInfo.ORGDES1,
                      empId = loginInfo.ORGID,
                      Pin = loginInfo.ORGID,
                      DeptmentId = loginInfo.ORGDES2,
                      DeptmentName = loginInfo.ORGDES3,
                      OrgOption = orgOption,
                      DeviceId = loginInfo.MACID,
                      Roles = new string[] { role },
                      Permitions = new string[] { perm }
                  }
                  : new LoginDataModel()
                  {
                      UserId = loginInfo.LOGID,
                      UserName = loginInfo.NAME,
                      empId = loginInfo.ORGID,
                      Pin = loginInfo.ORGID,
                      DeptmentId = loginInfo.ORGID,
                      DeptmentName = loginInfo.ORGDES1,
                      OrgOption = orgOption,
                      DeviceId = loginInfo.MACID,
                      Roles = new string[] { role },
                      Permitions = new string[] { perm }
                  };

                return new NmapLoginResult() { Result = true, Message = "", DefaultPath = "HOME", UserData = loginResult, DefaultPathParams = null };
            }
            catch(Exception ex)
            {
                return new NmapLoginResult() { Result = false, Message =$"로그인 오류: {ex.Message}", DefaultPath = "#" };
            }
        }

        /// <summary>
        /// Navigater MenuList(업무 리스트) Load
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<MenuDataModel>> GetNaviMenuData(bool refresh = false)
        {
            try
            {
                var dataService = ImateHelper.GetSingleTone();

                if (!refresh && NaviMenuList.Any(m=>m.IsMenuDisplay))
                    return NaviMenuList;

                IsMenuLoading = true;

                //메뉴 초기화
                var menuList = InitNaviMenuList();
                var dispMenuList= new ObservableCollection<MenuDataModel>();

                var home = new MenuDataModel() { Name = "HOME", Title = "HOME", Description = "홈", PageName = "NMAP.Pages.Common.HomePage", Seq = int.MinValue };
                //공통 화면
                menuList.Add(home);
                dispMenuList.Add(home);

                var role = App.LoginInfo.Roles.FirstOrDefault();
                var permit = App.LoginInfo.Permitions.FirstOrDefault();

                if (role == null || permit == null)
                    throw new Exception("역활 및 권한이 잘못 되었습니다.");

                var whereCond = $"APPID = '{App.APPID}' AND ROLEID = '{role}'";

                //롤 메뉴 리스트
                var roleMenuRoleModels = await dataService.Adapter.SelectModelDataAsync<ZNBPRomnModelList>(App.DbTitle, "NBPDataModels", "NAMHE.Model.ZNBPRomnModelList", null, whereCond, "", QueryCacheType.None);
                var rolePermitMenus = new ZNBPRomnModelList();
                if (permit == "*")
                {
                    rolePermitMenus = roleMenuRoleModels;
                }
                else
                {
                    var wherePemitCond = $"APPID = '{App.APPID}' AND ROLEID = '{role}' AND PERMID = '{permit}'";

                    //롤 권한용 기본 메뉴 권한 리스트
                    var roleMenuPermitModels = await dataService.Adapter.SelectModelDataAsync<ZNBPRpmnModelList>(App.DbTitle, "NBPDataModels", "NAMHE.Model.ZNBPRpmnModelList", null, wherePemitCond, "", QueryCacheType.None);

                    var permitRoles = roleMenuRoleModels.Join(roleMenuPermitModels, r => r.MNUID, p => p.MNUID, (r, p) => r);
                    var permtPMenu = permitRoles.Select(p => p.PMNUID).Distinct();

                    //메뉴 아이템
                    rolePermitMenus.AddRange(permitRoles.ToList());
                    //폴더
                    roleMenuRoleModels.Where(r => permtPMenu.Contains(r.MNUID)).ToList().ForEach((r) =>
                    {
                        rolePermitMenus.Add(r);
                    });
                }

                var pmnuidGroup = rolePermitMenus.GroupBy(r => r.PMNUID);
                var menuOrder = 1;
                foreach (var items in pmnuidGroup)
                {

                    if (items.Count() == 0 || items.Key == "_root_")
                        continue;

                    var subMenuInfo = new ObservableCollection<MenuDataModel>();
                    var subMenuOrder = 1;
                    foreach (var itm in items)
                    {
                        var uiInfo = itm.UIID.Split('.');
                        var pageName = $"NMAP.Pages.{itm.UIID}";
                        var uiId = uiInfo.Last();

                        subMenuInfo.Add(new MenuDataModel() { Name = uiId, Title = itm.MNUNM, Description = itm.MNUNM, PageName = pageName, Seq = subMenuOrder });
                    }

                    var roleMenu = roleMenuRoleModels.Where(r => r.MNUID == items.Key).First();

                    var menuItem = new MenuDataModel()
                    {
                        Name = roleMenu.UIID,
                        Title = roleMenu.MNUNM,
                        Description = "folder",
                        PageName = "",
                        Items = subMenuInfo,
                        Seq = menuOrder
                    };

                    menuList.Add(menuItem);
                    dispMenuList.Add(menuItem);
                }

                NaviMenuList = menuList;
                MenuList = dispMenuList;

                //----------------------------------------------------------------------------------
                return dispMenuList;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                IsMenuLoading = false;
            }
        }

        /// <summary>
        /// 시스템 요청의 코드 정보
        /// </summary>
        /// <returns></returns>
        public static async Task<(Dictionary<string, List<CodeInfo>>, DataSet)> SysReqCodeInfo()
        {
            try
            {
                //-----------------------------
                var queryParams = new QueryParameter[]
                {
                new QueryParameter(){name = "mandt", dataType = QueryDataType.String, value= App.Mandt },
                new QueryParameter(){name = "ktokk", dataType = QueryDataType.String, value= "Z040" }
                };

                var queryMsg1 = new QueryMessage()
                {
                    queryMethod = QueryRunMethod.Alone,
                    queryName = "운송업체",
                    dataSource = App.DbTitle,
                    queryTemplate = "#commonSql.LFA1",
                    parameters = queryParams,
                    cacheType = QueryCacheType.Cached
                };

                var queryMsg2 = new QueryMessage()
                {
                    queryMethod = QueryRunMethod.Alone,
                    queryName = "구매업체",
                    dataSource = App.DbTitle,
                    queryTemplate = "#commonSql.LFA1",
                    parameters = queryParams,
                    cacheType = QueryCacheType.Cached
                };

                //-----------------------------
                var queryParamMandt = new QueryParameter[]
                {
                new QueryParameter(){name = "mandt", dataType = QueryDataType.String, value= App.Mandt }
                };

                var queryMsg3 = new QueryMessage()
                {
                    queryMethod = QueryRunMethod.Alone,
                    queryName = "고객",
                    dataSource = App.DbTitle,
                    queryTemplate = "#systemSql.KNA1_SYSRQ",
                    parameters = queryParamMandt,
                    cacheType = QueryCacheType.Cached
                };
                //-----------------------------


                var queryMsg4 = new QueryMessage()
                {
                    queryMethod = QueryRunMethod.Alone,
                    queryName = "사원",
                    dataSource = App.DbTitle,
                    queryTemplate = "#systemSql.EMPINF",
                    parameters = queryParamMandt,
                    cacheType = QueryCacheType.Cached
                };

                //------------------------------------------
                var queryParamAppId = new QueryParameter[]
                {
                new QueryParameter(){name = "appid", dataType = QueryDataType.String, value= App.APPID }
                };

                var queryMsg5 = new QueryMessage()
                {
                    queryMethod = QueryRunMethod.Alone,
                    queryName = "역활",
                    dataSource = App.DbTitle,
                    queryTemplate = "#systemSql.APP_ROLE",
                    parameters = queryParamAppId,
                    cacheType = QueryCacheType.Cached
                };

                var queryMsg6 = new QueryMessage()
                {
                    queryMethod = QueryRunMethod.Alone,
                    queryName = "권한",
                    dataSource = App.DbTitle,
                    queryTemplate = "#systemSql.APP_PERM_ALL",
                    parameters = queryParamAppId,
                    cacheType = QueryCacheType.Cached
                };

                var result = await ImateHelper.GetSingleTone().Adapter.DbSelectToDataSetAsync(new List<QueryMessage>(new QueryMessage[] { queryMsg1, queryMsg2, queryMsg3, queryMsg4, queryMsg5, queryMsg6 }));

                Dictionary<string, List<CodeInfo>> codeInfosDic = new Dictionary<string, List<CodeInfo>>();

                //-------------------------------
                List<CodeInfo> transList = new List<CodeInfo>();
                foreach (DataRow r in result.Tables["운송업체"].Rows)
                {
                    transList.Add(new CodeInfo(r["LIFNR"].ToString(), $"{r["NAME1"]}({r["ORT01"]})", "", r["NAME1"].ToString()));
                }
                codeInfosDic.Add("운송업체", transList);

                //-------------------------------
                List<CodeInfo> vendList = new List<CodeInfo>();
                foreach (DataRow r in result.Tables["구매업체"].Rows)
                {
                    vendList.Add(new CodeInfo(r["LIFNR"].ToString(), $"{r["NAME1"]}({r["ORT01"]})", "", r["NAME1"].ToString()));
                }
                codeInfosDic.Add("구매업체", vendList);

                //--------------------------------
                List<CodeInfo> custList = new List<CodeInfo>();
                foreach (DataRow r in result.Tables["고객"].Rows)
                {
                    custList.Add(new CodeInfo(r["KUNNR"].ToString(), $"{r["NAME1"]}({r["ORT01"]})", "", r["NAME1"].ToString()));
                }
                codeInfosDic.Add("고객", custList);

                //--------------------------------
                List<CodeInfo> empList = new List<CodeInfo>();
                foreach (DataRow r in result.Tables["사원"].Rows)
                {
                    empList.Add(new CodeInfo(r["EMP_NO"].ToString(), $"{r["EMP_NM"]}({r["DEPT_NM"]})", "", r["EMP_NM"].ToString()));
                }
                codeInfosDic.Add("사원", empList);

                //---------------------------------
                List<CodeInfo> roleList = new List<CodeInfo>();
                foreach (DataRow r in result.Tables["역활"].Rows)
                {
                    roleList.Add(new CodeInfo(r["ROLEID"].ToString(), $"{r["ROLEDES"]}", "", r["ROLEDES"].ToString()));
                }
                codeInfosDic.Add("역활", roleList);

                //---------------------------------
                List<CodeInfo> permList = new List<CodeInfo>();
                foreach (DataRow r in result.Tables["권한"].Rows)
                {
                    permList.Add(new CodeInfo(r["PERMID"].ToString(), $"{r["PERMDES"]}", r["ROLEID"].ToString(), r["PERMDES"].ToString()));
                }
                codeInfosDic.Add("권한", permList);

                return (codeInfosDic, result);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
