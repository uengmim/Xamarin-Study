using Acr.UserDialogs;
using DevExpress.XamarinForms.Core.Utils.Internal;
using DevExpress.XamarinForms.DataForm;
using NMAP.ViewModels.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMAP.Utils.PickerSourceProvider
{

    /// <summary>
    /// Data 
    /// </summary>
    internal class SysReqPickerSourceProvider : IPickerSourceProvider
    {
        /// <summary>
        /// 데이터 소스
        /// </summary>
        public SysReqDataModel DataSource { get; set; }

        /// <summary>
        /// 요청 유형 리스트
        /// </summary>
        private readonly List<CodeInfo> reqTypeList;

        /// <summary>
        /// 코드 정보 사전
        /// </summary>
        public Dictionary<string, List<CodeInfo>> CodeInfosDic { get; set; } = null;
        /// <summary>
        /// 코드 정보 Set
        /// </summary>
        public DataSet CodeInfosSet { get; set; } = null;

        /// <summary>
        /// CodeInofs 로딩완료
        /// </summary>
        public event ResultEventHandler CodeInfosLoaded;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="dataSource"></param>
        public SysReqPickerSourceProvider(SysReqDataModel dataSource)
        {
            DataSource = dataSource;
            reqTypeList = new List<CodeInfo>() {
                    new CodeInfo("V", "공급자"),
                    new CodeInfo("C", "주문자"),
                    new CodeInfo("T", "운송사"),
                    new CodeInfo("Y", "내부직원")
                };

        }

        /// <summary>
        /// 코드 정보 로딩
        /// </summary>
        public async void LoadDataModel()
        {
            try
            {
                var result = await ModelDataLoader.SysReqCodeInfo();

                CodeInfosDic = result.Item1;
                CodeInfosSet = result.Item2;

                //이벤트 발생
                CodeInfosLoaded?.Invoke(this, new ResultEventArgs(true, ""));
            }
            catch (Exception ex)
            {
                CodeInfosDic = null;
                //이벤트 발생
                CodeInfosLoaded?.Invoke(this, new ResultEventArgs(false, ex.Message));
            }
        }

        /// <summary>
        /// 시스템 요청 콤보박스 데ㅣ터 소스
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public IEnumerable GetSource(string propertyName)
        {
            if (CodeInfosDic == null)
                return null;

            if (propertyName == "RequireType")
            {
                return reqTypeList;
            }
            else if(propertyName == "OrgId")
            {
                switch (DataSource.RequireType)
                {
                    case "V":
                        return CodeInfosDic["구매업체"];
                    case "T":
                        return CodeInfosDic["운송업체"];
                    case "C":
                        return CodeInfosDic["고객"];
                    case "Y":
                        return CodeInfosDic["사원"];
                    default:
                        return null;
                }
            }
            else if(propertyName == "Role")
            {
                return CodeInfosDic["역활"];
            }
            else if (propertyName == "Perm")
            {
                if (DataSource.Role == null)
                    return null;

                var permList = CodeInfosDic["권한"].Where(p => p.RefCode == DataSource.Role).ToList();
                permList.Insert(0, new CodeInfo("*", "기본"));

                return permList;
            }

            return null;
        }
    }
}
