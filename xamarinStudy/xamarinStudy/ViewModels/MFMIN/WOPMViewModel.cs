using Acr.UserDialogs;
using NAMHE.Model;
using NMAP.Models.MFMIN;
using NMAP.Models.MFMOU;
using NMAP.Pages.MFMIN;
using NMAP.Pages.MFMIN.Modals;
using NMAP.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using XNSC.DD.EX;
using static Xamarin.Forms.Internals.GIFBitmap;

namespace NMAP.ViewModels.MFMIN
{
    public class WOPMViewModel : ObservableObject
    {
        private DateTime startDate;
        private DateTime endDate;
        private DateTime tastartDate;
        private DateTime taendDate;
        private ObservableCollection<ZPMS0002Model> cardviewDataModel = new ObservableCollection<ZPMS0002Model>();
        private ObservableCollection<ZPMS0011Model> wopmViewDataModel = new ObservableCollection<ZPMS0011Model>();
        private ObservableCollection<ZPMF0012Model> wopmSaveDataModel = new ObservableCollection<ZPMF0012Model>();

        private ZPMS0011Model selectedWOPMData = new ZPMS0011Model();
        private ZPMS0002Model selected0002 = new ZPMS0002Model();
        private List<string> analType = new List<string>();
        private ObservableCollection<WOPMTAListModel> wopmtaViewDataModel = new ObservableCollection<WOPMTAListModel>();
        private ObservableCollection<WOPMTAChartModel> wopmtaChartViewDataModel = new ObservableCollection<WOPMTAChartModel>();


        private string ServerWerks { get { return Preferences.Get("serverWerks", ""); } }
        private string ServerKey { get { return Preferences.Get("serverKey", ""); } }

        /// <summary>
        /// 요청사항 입력오류 여부
        /// </summary>
        public bool bRequestTextError { get; set; }

        /// <summary>
        /// 조회버튼 이벤트
        /// </summary>
        public ICommand OnSearchData { get; set; }

        /// <summary>
        /// 점검입력 이벤트
        /// </summary>
        public ICommand OnPMWrite { get; set; }

        /// <summary>
        /// 점검저장 이벤트
        /// </summary>
        public ICommand OnPMWriteSave { get; set; }

        /// <summary>
        /// 추이분석 이벤트
        /// </summary>
        public ICommand OnPMTrendAnalysis { get; set; }

        /// <summary>
        /// 추이분석 조회버튼 이벤트
        /// </summary>
        public ICommand OnSearchTAData { get; set; }

        /// <summary>
        /// 추이분석 유형 변경 이벤트
        /// </summary>
        public ICommand OnChangeAnalType { get; set; }

        /// <summary>
        /// 팝업화면 서브 타이틀 텍스트
        /// </summary>
        public string SubTitleText { get; set; }

        /// <summary>
        /// 점검입력 페이지 타이틀 텍스트
        /// </summary>
        public string ModalTitleText { get; set; }

        /// <summary>
        /// 추이분석 페이지 타이틀 텍스트
        /// </summary>
        public string TAModalTitleText { get; set; }

        /// <summary>
        /// 시작일
        /// </summary>
        public DateTime StartDate { get => startDate; set => startDate = value; }

        /// <summary>
        /// 종료일
        /// </summary>
        public DateTime EndDate { get => endDate; set => endDate = value; }

        /// <summary>
        /// 추이분석 시작일
        /// </summary>
        public DateTime TAStartDate { get => tastartDate; set => tastartDate = value; }

        /// <summary>
        /// 추이분석 종료일
        /// </summary>
        public DateTime TAEndDate { get => taendDate; set => taendDate = value; }

        /// <summary>
        /// 오더리스트 모델
        /// </summary>
        public ObservableCollection<ZPMS0002Model> CardviewDataModel { get => cardviewDataModel; set => cardviewDataModel = value; }

        /// <summary>
        /// 예방보전 리스트 모델
        /// </summary>
        public ObservableCollection<ZPMS0011Model> WopmViewDataModel { get => wopmViewDataModel; set => wopmViewDataModel = value; }
        public ObservableCollection<ZPMF0012Model> WopmSaveDataModel { get => wopmSaveDataModel; set => wopmSaveDataModel = value; }
        /// <summary>
        /// 추이분석 선택 데이터
        /// </summary>
        public ZPMS0002Model Selected0002 { get => selected0002; set => selected0002 = value; }
        public ZPMS0011Model SelectedWOPMData { get => selectedWOPMData; set => selectedWOPMData = value; }

        /// <summary>
        /// 추이분석 유형 콤보박스 데이터
        /// </summary>
        public List<string> AnalType { get => analType; set => analType = value; }

        /// <summary>
        /// 추이분석 콤보박스 선택값
        /// </summary>
        public string SelectedAnalType { get; set; }

        /// <summary>
        /// 추이분석 데이터 프로퍼티
        /// </summary>
        public ObservableCollection<WOPMTAListModel> WopmtaViewDataModel { get => wopmtaViewDataModel; set => wopmtaViewDataModel = value; }

        //  조회 RFC Function
        private async Task<ObservableCollection<ZPMS0002Model>> GetData()
        {
            var model = new ObservableCollection<ZPMS0002Model>();
            {
                try
                {
                    var modelList = new ZPMF0010ModelList();

                    modelList.Add(new ZPMF0010Model()
                    {
                        I_WERKS = ServerWerks,
                        I_AUFNR = "",
                        I_AUART = "PM30",
                        I_STAT = "",
                        I_IDAT1_S = StartDate,
                        I_IDAT1_E = EndDate,
                        I_VAPLZ = "",
                        I_INGPR = "",
                        I_EQUNR = "",
                        E_MSG = "",
                        E_TYPE = "",
                        ITAB_DATA = new ObservableCollection<ZPMS0002Model>()

                    }); ;
                    var result = await ImateHelper.GetSingleTone().Adapter.RefcCallUsingModelAsync<ZPMF0010ModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZPMF0010ModelList", modelList, QueryCacheType.None);
                    model = new ObservableCollection<ZPMS0002Model>(result[0].ITAB_DATA);

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

        //  점검입력 버튼 조회 RFC Function
        private async Task<ObservableCollection<ZPMS0011Model>> GetWopmData(ZPMS0002Model selectrow)
        {
            var model = new ObservableCollection<ZPMS0011Model>();
            {
                try
                {
                    var modelList = new ZPMF0011ModelList();

                    modelList.Add(new ZPMF0011Model()
                    {
                        I_AUFNR = selectrow.AUFNR,
                        E_MSG = "",
                        E_TYPE = "",
                        ITAB_DATA = new ObservableCollection<ZPMS0011Model>()

                    }); ;
                    var result = await ImateHelper.GetSingleTone().Adapter.RefcCallUsingModelAsync<ZPMF0011ModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZPMF0011ModelList", modelList, QueryCacheType.None);
                    model = new ObservableCollection<ZPMS0011Model>(result[0].ITAB_DATA);

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
        //  저장 버튼  RFC Function
        // 리턴 값 ZPMF0012Model 바꿔주기
        private async Task<ObservableCollection<ZPMF0012Model>> SaveWopmData(ZPMS0002Model selectrow)
        {

            var model = new ObservableCollection<ZPMF0012Model>();
            {
                try
                {
                    var modelList = new ZPMF0012ModelList();

                    modelList.Add(new ZPMF0012Model()
                    {
                        E_MSG = "",
                        E_TYPE = "",
                        I_AUFNR = selectrow.AUFNR,
                        IT_DATA = new ObservableCollection<ZPMS0010Model>()
                    }); ;

                    foreach (var row in wopmViewDataModel)
                    {
                        modelList[0].IT_DATA.Add(new ZPMS0010Model()
                        {
                            SEQ2 = row.SEQ2,
                            WERKS = row.WERKS,
                            EQUNR = row.EQUNR,
                            POINT = row.POINT,
                            MDOCM = row.MDOCM,
                            RDCNT = row.RECDC,
                            CODCT = "",
                            CODGR = "",
                            VLCOD = row.VLCOD,
                            UNITR = row.UNITC,

                        });
                    }
                    var result = await ImateHelper.GetSingleTone().Adapter.RefcCallUsingModelAsync<ZPMF0012ModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZPMF0012ModelList", modelList, QueryCacheType.None);
                    model = new ObservableCollection<ZPMF0012Model>(result);
                    if (model[0].E_TYPE != "E")
                    {
                        UserDialogs.Instance.Alert("저장이 완료되었습니다.", Properties.Resources.Dialog_Confirm);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("저장이 정상적으로 되지 않았습니다." + model[0].E_MSG, Properties.Resources.Dialog_Confirm);
                    }
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
        /// <summary>
        /// 생성자
        /// </summary> 
        public WOPMViewModel()
        {
            //조회기간 초기화
            StartDate = DateTime.Now.AddDays(-7);
            EndDate = DateTime.Now;
            TAStartDate = DateTime.Now.AddDays(-7);
            TAEndDate = DateTime.Now;
            //bMatRequestPopupOpen = false;

        }

        public WOPMViewModel(WOPM page) : this()
        {
            //구분 콤보박스 셋팅
            AnalType.Clear();
            AnalType.Add("일별");
            AnalType.Add("월별");
            SelectedAnalType = "일별";
            //AnalType.Add("년별");

            OnPropertyChanged(nameof(SelectedAnalType));
            OnInitAnalType();


            //조회 이벤트 설정
            OnSearchData = new Command(async () =>
            {
                CardviewDataModel.Clear();
                page.OnLoadingDialog(true);
                CardviewDataModel = await GetData();
                if (CardviewDataModel.Count == 0)
                {
                    UserDialogs.Instance.Alert("조회된 데이터가 없습니다.");
                    page.OnLoadingDialog(false);
                    return;
                }
                page.OnLoadingDialog(false);
                OnPropertyChanged(nameof(CardviewDataModel));

            });

            OnPMWrite = new Command<ZPMS0002Model>(async (ZPMS0002Model selectRow) =>
            {
                WopmViewDataModel.Clear();
                page.OnLoadingDialog(true);
                Selected0002 = selectRow;
                WopmViewDataModel = await GetWopmData(selectRow);
                ModalTitleText = string.Format("오더번호 {0}의 점검목록", selectRow.AUFNR);
                OnPropertyChanged(nameof(WopmViewDataModel));
                page.OnLoadingDialog(false);
                page.OnWOPMWritePage(this);
            });

            OnPMWriteSave = new Command(async () =>
            {
                WopmSaveDataModel.Clear();
                page.OnLoadingDialog(true);
                var result = await page.OnWOWriteDialogOpen();
                if (result)
                {
                    WopmSaveDataModel = await SaveWopmData(Selected0002);
                    page.OnLoadingDialog(false);
                    return;
                }
                else
                {
                    page.OnLoadingDialog(false);
                    return;
                }


            });

            OnPMTrendAnalysis = new Command<ZPMS0011Model>((ZPMS0011Model selectRow) =>
            {
                selectedWOPMData = selectRow;
                //TAModalTitleText = String.Format("점검포인트 {0}의 추이분석", selectedWOPMData.Point_desc);

                //데이터 조회부분
                var condata = new WOPMTAListModel();
                condata.getData(WopmtaViewDataModel, "일별");

                //페이지 이동
                page.OnWOPMTAPage(this);
            });

            OnChangeAnalType = new Command(() =>
            {
                OnInitAnalType();
            });
        }


        /// <summary>
        /// 구분별 일자 초기설정
        /// </summary>
        private void OnInitAnalType()
        {
            if (SelectedAnalType == "일별")
                TAStartDate = DateTime.Now.AddMonths(-1);
            else if (SelectedAnalType == "월별")
                TAStartDate = DateTime.Now.AddYears(-1);

            TAEndDate = DateTime.Now;

            OnPropertyChanged(nameof(TAStartDate));
            OnPropertyChanged(nameof(TAEndDate));
        }

        public WOPMViewModel(WOPMWrite page) : this()
        {

        }

        public WOPMViewModel(WOPMTA page) : this()
        {

        }
    }
}
