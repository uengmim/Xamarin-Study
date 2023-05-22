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
using DevExpress.Utils;

namespace NMAP.ViewModels.MFMMG
{
    public class MFMVViewModel : ObservableObject
    {
        private ObservableCollection<ZMMS3120Model> zmmS3120Model = new ObservableCollection<ZMMS3120Model>();
        private List<T001L> LgortData = new List<T001L>();
        /// <summary>
        /// 자재명
        /// </summary>
        /// 
        private string ServerKey { get { return Preferences.Get("serverKey", ""); } }
        private string ServerMandt { get { return Preferences.Get("serverMandt", ""); } }
        private string ServerWerks { get { return Preferences.Get("serverWerks", ""); } }

        public string MatnrName { get; set; }
        public string SelecteLgort { get; set; }

        /// <summary>
        /// 자재재고확인 콜렉션뷰 모델
        /// </summary>
        public ObservableCollection<ZMMS3120Model> ZMMS3120Model { get => zmmS3120Model; set => zmmS3120Model = value; }

        /// <summary>
        /// 입고창고  모델 리스트
        /// </summary>
        public List<T001L> T001L { get => LgortData; set => LgortData = value; }

        /// <summary>
        /// 조회버튼 이벤트
        /// </summary>
        public ICommand OnSearchData { get; set; }


        public MFMVViewModel()
        {
            //카드뷰 모델 초기화
            ZMMS3120Model = new ObservableCollection<ZMMS3120Model>();

        }

        // 자재재고확인 조회 RFC Function
        private async Task<ObservableCollection<ZMMS3120Model>> GetData(string matnr, string lgort)
        {
            var model = new ObservableCollection<ZMMS3120Model>();
            {
                try
                {
                    var inputModel = new ObservableCollection<ZMMS3140Model>();
                    inputModel.Add(new ZMMS3140Model() { LGORT = lgort, MAKTX = matnr, MATKL = "", MATNR = "", MTART = "", PARTNER = "", SOBKZ = "", SPART = "", ZZBIN = "", ZZDEPT_CD = "" });

                    var modelList = new ZMMCURRStockModelList();

                    modelList.Add(new ZMMCURRStockModel()
                    {
                        I_WERKS = ServerWerks,
                        I_KZNUL = "",
                        IT_INPUT = inputModel,
                        ET_LIST = new ObservableCollection<ZMMS3120Model>()

                    }); ;
                    var result = await ImateHelper.GetSingleTone().Adapter.RefcCallUsingModelAsync<ZMMCURRStockModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZMMCURRStockModelList", modelList, QueryCacheType.None);
                    model = new ObservableCollection<ZMMS3120Model>(result[0].ET_LIST);

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

        // 자재재고확인 입고창고 리스트 조회 RFC Function
        private async Task<List<T001L>> GetLgortData()
        {
            var model = new List<T001L>();
            {
                try
                {
                    var queryParams = new QueryParameter[]
                   {
                        new QueryParameter(){name = "mandt", dataType = QueryDataType.String, value= ServerMandt },
                        new QueryParameter(){name = "werks", dataType = QueryDataType.String, value= ServerWerks },
                   };

                    var queryMsg = new QueryMessage()
                    {
                        queryMethod = QueryRunMethod.Alone,
                        queryName = "T001L",
                        dataSource = ServerKey, //<--- 프리페어런스의 값으로 변경하여야 함
                        queryTemplate = "#commonSql.T001L",
                        parameters = queryParams,
                        cacheType = QueryCacheType.Cached
                    };

                    var result = await ImateHelper.GetSingleTone().Adapter.DbSelectToDataSetAsync(new List<QueryMessage>(new QueryMessage[] { queryMsg }));
                    var trrResult = result.GetDataObject<T001L>("T001L");
                    model = new List<T001L>(trrResult);
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

        public async void initData()
        {
            T001L.Clear();
            T001L = await GetLgortData();
            OnPropertyChanged(nameof(T001L));
        }

        public MFMVViewModel(MFMV page) : this()
        {
            ZMMS3120Model = new ObservableCollection<ZMMS3120Model>();
            T001L = new List<T001L>();

            initData();

            //조회 이벤트 설정
            OnSearchData = new Command(async () =>
            {
                if (!string.IsNullOrEmpty(MatnrName))
                {
                    if (MatnrName.Length < 3)
                        {
                        UserDialogs.Instance.Alert("자재명을 3자 이상 입력하세요.");
                        return;
                    }
                }else if(string.IsNullOrEmpty(MatnrName) && string.IsNullOrEmpty(SelecteLgort))
                {
                    UserDialogs.Instance.Alert("자재명 또는 저장위치를 입력하세요.");
                    return;
                }
                ZMMS3120Model.Clear();
                page.OnLoadingDialog(true);
                ZMMS3120Model = await GetData(MatnrName, string.IsNullOrEmpty(SelecteLgort) ? "": SelecteLgort);
                if (ZMMS3120Model.Count == 0)
                {
                    UserDialogs.Instance.Alert("조회된 데이터가 없습니다.");
                    page.OnLoadingDialog(false);
                    return;
                }
                page.OnLoadingDialog(false);
                OnPropertyChanged(nameof(ZMMS3120Model));
            });


        }


    }
}