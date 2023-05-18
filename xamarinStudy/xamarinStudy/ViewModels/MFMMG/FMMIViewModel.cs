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

namespace NMAP.ViewModels.MFMMG
{
    public class FMMIViewModel : ObservableObject
    {

        private ObservableCollection<T001L> fmmiSelectModel = new ObservableCollection<T001L>();
        private ObservableCollection<ZMMS3070Model> zmmS3070Model = new ObservableCollection<ZMMS3070Model>();
        public ObservableCollection<ZMMS3080Model> saveDataModel = new ObservableCollection<ZMMS3080Model>();


        private string ServerKey { get { return Preferences.Get("serverKey", ""); } }
        private string ServerMandt { get { return Preferences.Get("serverMandt", ""); } }
        private string ServerWerks { get { return Preferences.Get("serverWerks", ""); } }

        /// <summary>
        /// 요청번호
        /// </summary>
        public string Rsnum { get; set; }

        /// <summary>
        /// 자재출고 카드뷰 모델
        /// </summary>
        public ObservableCollection<ZMMS3070Model> ZMMS3070Model { get => zmmS3070Model; set => zmmS3070Model = value; }

        /// <summary>
        /// 입고창고 카드뷰 모델
        /// </summary>
        public ObservableCollection<T001L> T001L { get; set; }

        /// <summary>
        /// 조회버튼 이벤트
        /// </summary>
        public ICommand OnSearchData { get; set; }

        /// <summary>
        /// 입고창고 버튼 이벤트
        /// </summary>
        public ICommand OnPopup { get; set; }

        /// <summary>
        /// 자재출고 저장 이벤트
        /// </summary>
        public ICommand OnSave { get; set; }

        /// <summary>
        /// 자재출고 저장 이벤트
        /// </summary>
        public ICommand OnChange { get; set; }

        /// <summary>
        /// 입고창고 페이지 타이틀 텍스트
        /// </summary>
        public string ModalTitleText { get; set; }

        public ObservableCollection<T001L> FmmiViewDataModel { get => fmmiSelectModel; set => fmmiSelectModel = value; }

        /// <summary>
        /// 자재출고 조회RFC
        /// </summary>
        /// <returns></returns>

        public FMMIViewModel()
        {
            //카드뷰 모델 초기화
            ZMMS3070Model = new ObservableCollection<ZMMS3070Model>();

        }
        public FMMIViewModel(FMMISelect page) : this()
        {
        }
        public FMMIViewModel(FMMISelect page, ObservableCollection<T001L> model) : this()
        {
            T001L = new ObservableCollection<T001L>();
            T001L = model;
            OnPropertyChanged(nameof(T001L));
        }

        // 자재출고 조회 RFC Function
        private async Task<ObservableCollection<ZMMS3070Model>> GetData(string rsnum)
        {
            var model = new ObservableCollection<ZMMS3070Model>();
            {
                try
                {

                    var Param = new ZMM311RESERVInquiryModel()
                    {
                        I_RSNUM = rsnum
                    };

                    var QueryMsg = new QueryMessage()
                    {
                        queryMethod = QueryRunMethod.Alone,
                        queryName = "GetData",
                        dataSource = ServerKey,
                        queryTemplate = $"EXECRFC ZMM_311RESERV_INQUIRY {ParamterUtility.GetRFCParameter(Param)} RETURN ES_RETURN,ET_LIST",
                        cacheType = QueryCacheType.Cached
                    };

                    var result = await ImateHelper.GetSingleTone().Adapter.DbSelectToDataSetAsync(new List<QueryMessage>(new QueryMessage[] { QueryMsg }));
                    var obj = result.GetDataObject<ZMMS3070Model>("GetData!ET_LIST");
                    model = new ObservableCollection<ZMMS3070Model>(obj);

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

        // 자재출고 입고창고 리스트 조회 RFC Function
        private async Task<ObservableCollection<T001L>> GetDataPop()
        {
            var model = new ObservableCollection<T001L>();
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
                    model = new ObservableCollection<T001L>(trrResult);
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

        // 자재출고 RFC 저장 Function
        public async Task<ZMM311RESERVGiModelList> SaveOrderData(ObservableCollection<ZMMS3080Model> saveData)
        {
            var model = new ZMM311RESERVGiModelList();
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    var zmm311List = new ZMM311RESERVGiModelList();
                    zmm311List.Add(new ZMM311RESERVGiModel()
                    {
                        ES_RETURN = new ZMMS9000Model(),
                        CT_LIST = saveData,
                    });


                    model = ImateHelper.GetSingleTone().Adapter.RefcCallUsingModel<ZMM311RESERVGiModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZMM311RESERVGiModelList", zmm311List, QueryCacheType.None);
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

        public FMMIViewModel(FMMI page) : this()
        {
            ZMMS3070Model = new ObservableCollection<ZMMS3070Model>();

            //조회 이벤트 설정
            OnSearchData = new Command(async () =>
            {
                if (Rsnum == "" || Rsnum == null)
                {
                    UserDialogs.Instance.Alert("입력된 요청번호가 없습니다.");
                    return;
                }
                ZMMS3070Model.Clear();
                page.OnLoadingDialog(true);
                ZMMS3070Model = await GetData(Rsnum);
                if (ZMMS3070Model.Count != 0)
                {
                    // 출고수량 자동 세팅 ( 조회시 요청수량 - 기출고 = 출고수량 )
                    foreach (var row in ZMMS3070Model)
                    {
                        row.MENGE = (decimal.Parse(string.IsNullOrEmpty(row.BDMNG) ? "0" : row.BDMNG) - decimal.Parse(string.IsNullOrEmpty(row.ENMNG) ? "0" : row.ENMNG)).ToString();
                        row.IsChecked = row.KZEAR == "X" ? true : false;
                    }
                }
                page.OnLoadingDialog(false);
                OnPropertyChanged(nameof(ZMMS3070Model));
            });

            /*
            //입고창고 선택 팝업 이벤트
            OnPopup = new Command( async () =>
            {
                page.OnLoadingDialog(true);
                T001L = await GetDataPop();
                page.OnLoadingDialog(false);
                ModalTitleText = "입고창고 목록";
                OnPropertyChanged(nameof(T001L));
                page.onPopup_Clicked(T001L);
            });
            */

            // 출고수량 변경시 이벤트 
            OnChange = new Command<ZMMS3070Model>((ZMMS3070Model selectedRow) =>
            {
                if (selectedRow != null)
                {
                    if (decimal.Parse(string.IsNullOrEmpty(selectedRow.LABST) ? "0" : selectedRow.LABST) < decimal.Parse(string.IsNullOrEmpty(selectedRow.MENGE) ? "0" : selectedRow.MENGE))
                    {
                        selectedRow.ErrorText = "재고초과";
                        selectedRow.HasError = true;
                    }
                    else if ((decimal.Parse(string.IsNullOrEmpty(selectedRow.BDMNG) ? "0" : selectedRow.BDMNG) - decimal.Parse(string.IsNullOrEmpty(selectedRow.ENMNG) ? "0" : selectedRow.ENMNG)) < decimal.Parse(string.IsNullOrEmpty(selectedRow.MENGE) ? "0" : selectedRow.MENGE))
                    {
                        selectedRow.ErrorText = "수량초과";
                        selectedRow.HasError = true;
                    }
                    else
                    {
                        selectedRow.ErrorText = "";
                        selectedRow.HasError = false;
                    }
                    OnPropertyChanged(nameof(ZMMS3070Model));
                }
            });

            //자재출고 저장 이벤트 설정
            OnSave = new Command(async () =>
            {
                saveDataModel.Clear();

                foreach (var row in ZMMS3070Model)
                {
                    if (row.HasError)
                    {
                        page.OnErrorMessage(row.ErrorText);
                        return;
                    }

                    saveDataModel.Add(new ZMMS3080Model(row.RSNUM, row.RSPOS, ServerWerks, row.LGORT, row.UMLGO, row.MATNR, row.MENGE, row.MEINS, DateTime.Now.ToString("yyyyMMdd"), "", "", "", ""));
                }



                var result = await page.OnSaveDialogOpen();
                if (!result)
                    return;

                // 결과 값이 존재하는지 
                page.OnLoadingDialog(true);
                var model = await SaveOrderData(saveDataModel);
                if (model.Count == 0)
                {
                    page.OnLoadingDialog(false);
                    return;
                }
                // 임시로 1번 (RFC확인 후 수정- 현재 2가지 테이블로 나오고있어서..)
                page.OnResultMessage(model[0].CT_LIST[0].TYPE, model[0].CT_LIST[0].MESSAGE);

                //성공적인 저장 후 재조회
                if (model[0].CT_LIST[0].TYPE == "S")
                    ZMMS3070Model = await GetData(Rsnum);
                page.OnLoadingDialog(false);

            });

        }


    }
}