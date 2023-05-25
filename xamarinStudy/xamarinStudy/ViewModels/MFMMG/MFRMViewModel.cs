using NAMHE.Model;
using NMAP.Models.Common;
using NMAP.Pages.MFMMG;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XNSC.DD.EX;
using Xamarin.CommunityToolkit.ObjectModel;
using Acr.UserDialogs;
using XNSC.Net;
using ZXing;
using NMAP.Models.MFMOU;
using Xamarin.Essentials;
using NMAP.Pages.MFMMG.Modals;
using NMAP.Utils;
using NMAP.Models.MFMIN;
using System.Runtime.InteropServices.ComTypes;
using static Xamarin.Essentials.Permissions;
using NMAP.Pages.MFMIN.Modals;
using System.Security.Cryptography;
using DevExpress.XamarinForms.DataGrid;

namespace NMAP.ViewModels.MFMMG
{
    public class MFRMViewModel : ObservableObject
    {

        private DateTime startDate;
        private DateTime endDate;
        private String mtart;
        private String matkl;
        private String zdept;
        private String matnr;
        private DateTime nowDate;

        // 콜렉션뷰에서 선택된 데이터
        ZMMS0080Model selectedContact;

        private ObservableCollection<ZMMS0080Model> zmms0080Model = new ObservableCollection<ZMMS0080Model>();
        private ObservableCollection<ZMMS0080Model> zmms0080ModelDetail = new ObservableCollection<ZMMS0080Model>();
        public ObservableCollection<ZMMS3080Model> saveDataModel = new ObservableCollection<ZMMS3080Model>();
        private List<DEPT> DeptData = new List<DEPT>();
        private List<T023T> MatklData = new List<T023T>();
        private List<MARA> MatnrData = new List<MARA>();
        public ZMMS0080Model SelectedContact { get { return selectedContact; } set { if (selectedContact != value) { selectedContact = value; } } }

        private string ServerKey { get { return Preferences.Get("serverKey", ""); } }
        private string ServerMandt { get { return Preferences.Get("serverMandt", ""); } }
        private string ServerWerks { get { return Preferences.Get("serverWerks", ""); } }
        private string ServerSpras { get { return Preferences.Get("serverSpras", ""); } }

        /// <summary>
        /// 시작일
        /// </summary>
        public DateTime StartDate { get => startDate; set => startDate = value; }
        /// <summary>
        /// 시작일
        /// </summary>
        public DateTime NowDate { get => nowDate; set => nowDate = value; }

        /// <summary>
        /// 종료일
        /// </summary>
        public DateTime EndDate { get => endDate; set => endDate = value; }

        /// <summary>
        /// 자재유형
        /// </summary>
        public String Mtart { get => mtart; set => mtart = value; }
        
        /// <summary>
        /// 자재그룹
        /// </summary>
        public String Matkl { get => matkl; set => matkl = value; }
        public string SelecteMatkl { get; set; }

        /// <summary>
        /// 운영부서
        /// </summary>
        public string SelecteDept { get; set; }
        public String Zdept { get => zdept; set => zdept = value; }

        /// <summary>
        /// 운영부서  모델 리스트
        /// </summary>
        public List<DEPT> DEPT { get => DeptData; set => DeptData = value; }

        /// <summary>
        /// 자재그룹  모델 리스트
        /// </summary>
        public List<T023T> T023T { get => MatklData; set => MatklData = value; }

        /// <summary>
        /// 자재코드 모델 리스트
        /// </summary>
        public List<MARA> MARA { get => MatnrData; set => MatnrData = value; }

        /// <summary>
        /// 자재코드
        /// </summary>
        public String Matnr { get => matnr; set => matnr = value; }
        public string SelecteMatnr { get; set; }
        /// <summary>
        /// 구매요청확인 모델
        /// </summary>
        public ObservableCollection<ZMMS0080Model> ZMMS0080Model { get => zmms0080Model; set => zmms0080Model = value; }
        /// <summary>
        /// 구매요청확인 상세정보 모델
        /// </summary>
        public ObservableCollection<ZMMS0080Model> Zmms0080ModelDetail { get => zmms0080ModelDetail; set => zmms0080ModelDetail = value; }

        /// <summary>
        /// 조회버튼 이벤트
        /// </summary>
        public ICommand OnSearchData { get; set; }

        /// <summary>
        /// 상세내용 버튼 이벤트
        /// </summary>
        public ICommand OnDetail { get; set; }

        /// <summary>
        /// 구매요청 저장 이벤트
        /// </summary>
        public ICommand OnSave { get; set; }
        
        /// <summary>
        /// 날짜변경 커맨드
        /// </summary>
        public ICommand OnSelect { get; set; }
        
        /// <summary>
        /// 자재그룹 별 자재코드 커맨드
        /// </summary>
        public ICommand OnChangeMatnr { get; set; }

        /// <summary>
        /// 자재코드 클리어 커맨드
        /// </summary>
        public ICommand ClearMatnr { get; set; }

        /// <summary>
        /// 상세내용 페이지 타이틀 텍스트
        /// </summary>
        public string ModalTitleText { get; set; }


        /// <summary>
        /// 구매요청확인 조회RFC
        /// </summary>
        /// <returns></returns>

        public MFRMViewModel()
        {
            //조회기간 초기화
            //시작일자 : 현재, 종료일자 : 현재 + 4주(28일)
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddDays(28);
            nowDate = DateTime.Now;
            Mtart = "ERSA";


        }

        // 운영부서 조회 
        private async Task<List<DEPT>> GetDeptData()
        {
            var model = new List<DEPT>();
            {
                try
                {
                    var queryParams = new QueryParameter[]
                   {
                        new QueryParameter(){name = "mandt", dataType = QueryDataType.String, value= ServerMandt },
                   };

                    var queryMsg = new QueryMessage()
                    {
                        queryMethod = QueryRunMethod.Alone,
                        queryName = "DEPT_INFO",
                        dataSource = ServerKey, //<--- 프리페어런스의 값으로 변경하여야 함
                        queryTemplate = "#commonSql.DEPT_INFO",
                        parameters = queryParams,
                        cacheType = QueryCacheType.Cached
                    };

                    var result = await ImateHelper.GetSingleTone().Adapter.DbSelectToDataSetAsync(new List<QueryMessage>(new QueryMessage[] { queryMsg }));
                    var trrResult = result.GetDataObject<DEPT>("DEPT_INFO");
                    model = new List<DEPT>(trrResult);
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(ex.StackTrace);
                    sb.AppendLine("=======================================");
                    sb.AppendLine(ex.Message);
                    UserDialogs.Instance.Alert(sb.ToString(), "INFO");
                }
            };
            return model;

        }

        // 자재그룹 조회 
        private async Task<List<T023T>> GetMatklData()
        {
            var model = new List<T023T>();
            {
                try
                {
                    var queryParams = new QueryParameter[]
                   {
                        new QueryParameter(){name = "mandt", dataType = QueryDataType.String, value= ServerMandt },
                        new QueryParameter(){name = "spras", dataType = QueryDataType.String, value= ServerSpras },
                        new QueryParameter(){name = "like", dataType = QueryDataType.String, value= "%" },
                   };

                    var queryMsg = new QueryMessage()
                    {
                        queryMethod = QueryRunMethod.Alone,
                        queryName = "T023T_A",
                        dataSource = ServerKey, //<--- 프리페어런스의 값으로 변경하여야 함
                        queryTemplate = "#commonSql.T023T_A",
                        parameters = queryParams,
                        cacheType = QueryCacheType.Cached
                    };

                    var result = await ImateHelper.GetSingleTone().Adapter.DbSelectToDataSetAsync(new List<QueryMessage>(new QueryMessage[] { queryMsg }));
                    var trrResult = result.GetDataObject<T023T>("T023T_A");
                    model = new List<T023T>(trrResult);
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(ex.StackTrace);
                    sb.AppendLine("=======================================");
                    sb.AppendLine(ex.Message);
                    UserDialogs.Instance.Alert(sb.ToString(), "INFO");
                }
            };
            return model;

        }
        
        // 자재코드 조회 
        private async Task<List<MARA>> GetMatnrData()
        {
            var model = new List<MARA>();
            {
                try
                {
                    var queryParams = new QueryParameter[]
                   {
                        new QueryParameter(){name = "mandt", dataType = QueryDataType.String, value= ServerMandt },
                        new QueryParameter(){name = "spras", dataType = QueryDataType.String, value= ServerSpras },
                        new QueryParameter(){name = "mtart1", dataType = QueryDataType.String, value= Mtart },
                        new QueryParameter(){name = "matkl", dataType = QueryDataType.String, value= String.IsNullOrEmpty(SelecteMatkl)?"%" : SelecteMatkl },
                   };

                    var queryMsg = new QueryMessage()
                    {
                        queryMethod = QueryRunMethod.Alone,
                        queryName = "MARA_C",
                        dataSource = ServerKey, //<--- 프리페어런스의 값으로 변경하여야 함
                        queryTemplate = "#commonSql.MARA_C",
                        parameters = queryParams,
                        cacheType = QueryCacheType.Cached
                    };

                    var result = await ImateHelper.GetSingleTone().Adapter.DbSelectToDataSetAsync(new List<QueryMessage>(new QueryMessage[] { queryMsg }));
                    var trrResult = result.GetDataObject<MARA>("MARA_C");
                    model = new List<MARA>(trrResult);
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(ex.StackTrace);
                    sb.AppendLine("=======================================");
                    sb.AppendLine(ex.Message);
                    UserDialogs.Instance.Alert(sb.ToString(), "INFO");
                }
            };
            return model;

        }

        // 구매요청 조회 RFC Function
        private async Task<ObservableCollection<ZMMS0080Model>> GetData()
        {
            var model = new ObservableCollection<ZMMS0080Model>();
            {
                try
                {

                    var modelList = new ZMMMATPLANNINGMD04ModelList();

                    modelList.Add(new ZMMMATPLANNINGMD04Model()
                    {
                        I_WERKS = ServerWerks,   //필수
                        I_MTART = Mtart,   //필수
                        I_MATKL = SelecteMatkl,
                        I_ZDEPT = string.IsNullOrEmpty(SelecteDept)? "" : SelecteDept,      //필수
                        I_MATNR = string.IsNullOrEmpty(SelecteMatnr)? "" : SelecteMatnr,
                        I_BDTER_FR = StartDate,
                        I_BDTER_TO = EndDate,
                        ET_DATA = new ObservableCollection<ZMMS0080Model>()

                    });
                    var result = await ImateHelper.GetSingleTone().Adapter.RefcCallUsingModelAsync<ZMMMATPLANNINGMD04ModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZMMMATPLANNINGMD04ModelList", modelList, QueryCacheType.None);
                    model = new ObservableCollection<ZMMS0080Model>(result[0].ET_DATA);

                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(ex.StackTrace);
                    sb.AppendLine("=======================================");
                    sb.AppendLine(ex.Message);
                    UserDialogs.Instance.Alert(sb.ToString(), "INFO");
                }
            };
            return model;
        }

        // 구매요청 RFC 저장 Function
        public async Task<ZMMPRCREATE1ModelList> SaveOrderData()
        {
            var model = new ZMMPRCREATE1ModelList();
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    var prList = new ZMMPRCREATE1ModelList();
                    prList.Add(new ZMMPRCREATE1Model()
                    {
                        ES_RETURN = new ZMMS0090Model(),
                        I_WERKS = ServerWerks,
                        I_MATNR = SelectedContact.MATNR,
                        I_MENGE = SelectedContact.MNG03,
                        I_EEIND = DateTime.Parse(SelectedContact.PR_DATE),
                        ET_RETURN = new ObservableCollection<BAPIRET2Model>()
                    });

                    model = ImateHelper.GetSingleTone().Adapter.RefcCallUsingModel<ZMMPRCREATE1ModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZMMPRCREATE1ModelList", prList, QueryCacheType.None);
                }
                catch (Exception ex)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(ex.StackTrace);
                    sb.AppendLine("=======================================");
                    sb.AppendLine(ex.Message);
                    UserDialogs.Instance.Alert(sb.ToString(), "INFO");
                }
            });
            return model;
        }

        public async void initData()
        {
            DEPT.Clear();
            DEPT = await GetDeptData();
            OnPropertyChanged(nameof(DEPT));

            T023T.Clear();
            T023T = await GetMatklData();
            OnPropertyChanged(nameof(T023T));

            MARA.Clear();
            MARA = await GetMatnrData();
            OnPropertyChanged(nameof(MARA));
        }

        public MFRMViewModel(MFRM page) : this()
        {
            ZMMS0080Model = new ObservableCollection<ZMMS0080Model>();
            DEPT = new List<DEPT>();

            initData();

            //조회 이벤트 설정
            OnSearchData = new Command(async () =>
            {
                if(string.IsNullOrEmpty(SelecteMatkl))
                {
                    UserDialogs.Instance.Alert("자재그룹을 입력해주세요.");
                    return;
                }else if (string.IsNullOrEmpty(SelecteDept))
                {
                    UserDialogs.Instance.Alert("운영부서를 입력해주세요.");
                    return;
                }

                ZMMS0080Model.Clear();
                page.OnLoadingDialog(true);

                ZMMS0080Model = await GetData();
                if (ZMMS0080Model.Count == 0)
                {
                    UserDialogs.Instance.Alert("조회된 데이터가 없습니다.");
                    page.OnLoadingDialog(false);
                    return;
                }
                else
                {
                    OnPropertyChanged(nameof(ZMMS0080Model));
                    page.on_subpage(this); 
                }
                page.OnLoadingDialog(false);
            });
            OnChangeMatnr = new Command(async () =>
            {
                SelecteMatnr = null;
                OnPropertyChanged(nameof(SelecteMatnr));

                MARA.Clear();
                MARA = await GetMatnrData(); 
                OnPropertyChanged(nameof(MARA));
            });
            ClearMatnr = new Command(() =>
            {
                SelecteMatnr = null;
                OnPropertyChanged(nameof(SelecteMatnr));
            });


            }
        public MFRMViewModel(MFRMSub page, MFRMViewModel viewModel) : this()
        {
            ZMMS0080Model = viewModel.ZMMS0080Model;
            Mtart = viewModel.Mtart;
            /* Matkl = viewModel.Matkl;
             Zdept = viewModel.Zdept;
             Matnr = viewModel.Matnr;
             */
            SelecteDept = viewModel.SelecteDept;
            SelecteMatkl = viewModel.SelecteMatkl;
            SelecteMatnr = viewModel.SelecteMatnr;

            StartDate = viewModel.StartDate;   
            EndDate = viewModel.EndDate;   

            OnPropertyChanged(nameof(ZMMS0080Model));
            OnPropertyChanged(nameof(Mtart));
            OnPropertyChanged(nameof(SelecteDept));
            OnPropertyChanged(nameof(SelecteMatkl));
            OnPropertyChanged(nameof(SelecteMatnr));
            OnPropertyChanged(nameof(StartDate));
            OnPropertyChanged(nameof(EndDate));

            //상세내용
            OnDetail = new Command<ZMMS0080Model>((ZMMS0080Model selectRow) =>
            {
                Zmms0080ModelDetail.Clear();
                Zmms0080ModelDetail = new ObservableCollection<ZMMS0080Model>(new ZMMS0080Model[] { selectRow });
                ModalTitleText = string.Format("{0}의 상세내역", selectRow.MAKTX);
                OnPropertyChanged(nameof(Zmms0080ModelDetail));
                page.on_datail(this);
            });
            //상세내용
            OnSelect = new Command<ZMMS0080Model>((ZMMS0080Model selectRow) =>
            {
                if(selectRow != null)
                {
                    SelectedContact = selectRow;
                }

                OnPropertyChanged(nameof(SelectedContact));
            });


            //구매요청 저장 이벤트 설정
            OnSave = new Command(async () =>
            {
                saveDataModel.Clear();
                if (SelectedContact == null)
                {
                    
                    UserDialogs.Instance.Alert("저장하려는 데이터를 선택해주세요.");
                    return;
                }else if(SelectedContact.PR_DATE == null)
                {
                    UserDialogs.Instance.Alert("납품요청일자를 입력해주세요.");
                    return;
                }
                else if (SelectedContact.MNG03 == 0)
                {
                    UserDialogs.Instance.Alert("요청량을 입력해주세요.");
                    return;
                }


                var result = await page.OnSaveDialogOpen();
                if (!result)
                    return;

                // 결과 값이 존재하는지 
                page.OnLoadingDialog(true);
                var model = await SaveOrderData();
                if (model.Count == 0)
                {
                    page.OnLoadingDialog(false);
                    return;
                }

                if (model[0].ES_RETURN.TYPE == "S")
                    page.OnResultMessage(model[0].ES_RETURN.TYPE, model[0].ES_RETURN.BANFN);
                else
                    page.OnResultMessage(model[0].ES_RETURN.TYPE, model[0].ES_RETURN.MESSAGE);

                ZMMS0080Model.Clear();
                ZMMS0080Model = await GetData();
                OnPropertyChanged(nameof(ZMMS0080Model));
                page.OnLoadingDialog(false);

            });
        }
        public MFRMViewModel(MFRMDetail page) : this()
        {

        }

    }
}