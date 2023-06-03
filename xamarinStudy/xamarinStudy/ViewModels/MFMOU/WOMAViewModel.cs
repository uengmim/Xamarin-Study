using NAMHE.Model;
using NMAP.Models.MFMOU;
using NMAP.Pages.MFMOU;
using NMAP.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XNSC.DD.EX;
using NMAP.Models.Common;
using Xamarin.CommunityToolkit.ObjectModel;

namespace NMAP.ViewModels.MFMOU
{
    public class WOMAViewModel : ObservableObject
    {
        /// <summary>
        /// 시작일
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 종료일
        /// </summary>
        public DateTime EndDate { get; set; } 

        /// <summary>
        /// 메인 카드뷰 모델
        /// </summary>
        public ObservableCollection<ZPMS0002Model> CardviewDataModel { get; set; }

        /// <summary>
        /// 자재요청 팝업 카드뷰 모델
        /// </summary>
        public ObservableCollection<ZPMS0002Model> PopupCardviewDataModel { get; set; }

        /// <summary>
        /// 자재요청 팝업 카드뷰 모델
        /// </summary>
        public ObservableCollection<ZPMS0003Model> ZPMS0003Model { get; set; }

        /// <summary>
        /// 자재사용 팝업 카드뷰 모델
        /// </summary>
        public ObservableCollection<ZPMS0004Model> ZPMS0004Model { get; set; }

        /// <summary>
        /// 자재사용 팝업 카드뷰 모델
        /// </summary>
        public ObservableCollection<WOMatMedel> PopupMaterialUseDataModel { get { return popupMaterialUseDataModel; } set { popupMaterialUseDataModel = value; OnPropertyChanged(nameof(PopupMaterialUseDataModel)); } }

        public ObservableCollection<WOMatMedel> popupMaterialUseDataModel = new ObservableCollection<WOMatMedel>();

        /// <summary>
        /// 요청사항 입력오류 여부
        /// </summary>
        public bool bRequestTextError { get; set; }

        /// <summary>
        /// 조회버튼 이벤트
        /// </summary>
        public ICommand OnSearchData { get; set; }

        /// <summary>
        /// 자재요청 이벤트
        /// </summary>
        public ICommand OnMatRequest { get; set; }

        /// <summary>
        /// 자재요청 텍스트 변경 이벤트
        /// </summary>
        public ICommand OnMatRequestTextChange { get; set; }  

        /// <summary>
        /// 자재요청 저장 이벤트
        /// </summary>
        public ICommand OnMatRequestSave { get; set; }

        /// <summary>
        /// 자재사용 이벤트
        /// </summary>
        public ICommand OnMatUse { get; set; }

        /// <summary>
        /// 자재사용 수량 변경 이벤트
        /// </summary>
        public ICommand OnMatUseChange { get; set; }

        /// <summary>
        /// 자재사용 저장 이벤트
        /// </summary>
        public ICommand OnMatUseSave { get; set; }

        /// <summary>
        /// 자재사용 이벤트
        /// </summary>
        public ICommand OnMatReturn { get; set; }

        /// <summary>
        /// 자재반납 수량 변경 이벤트
        /// </summary>
        public ICommand OnMatReturnChange { get; set; }

        /// <summary>
        /// 자재사용 저장 이벤트
        /// </summary>
        public ICommand OnMatReturnSave { get; set; }
        /// <summary>
        ///상세 자료 이벤트
        /// </summary>
        public ICommand OnDetailViewOpen { get; set; }
        /// <summary>
        /// 팝업화면 서브 타이틀 텍스트
        /// </summary>
        public string SubTitleText { get; set; }

        public WOMAViewModel()
        {
            //카드뷰 모델 초기화
            CardviewDataModel = new ObservableCollection<ZPMS0002Model>();

            //조회기간 초기화
            StartDate = DateTime.Now.AddDays(-7);
            EndDate = DateTime.Now;
            //bMatRequestPopupOpen = false;

        }

        public WOMAViewModel(WOMA page) : this()
        {
            ZPMS0003Model = new ObservableCollection<ZPMS0003Model>();

            //조회 이벤트 설정
            OnSearchData = new Command(async () =>
            {
                CardviewDataModel.Clear();
                page.OnLoadingDialog(true);
                var iMATE = new IMATE();
                CardviewDataModel = await iMATE.GetOrderList(StartDate, EndDate);
                page.OnLoadingDialog(false);
                OnPropertyChanged(nameof(CardviewDataModel));
            });

            //자재요청 팝업오픈 이벤트 설정
            OnMatRequest = new Command<ZPMS0002Model>(async (ZPMS0002Model selectedRow) =>
            {
                ZPMS0003Model.Clear();
                page.OnLoadingDialog(true);
                var iMATE = new IMATE();
                var model = await iMATE.GetOrderDetailList(selectedRow.AUFNR);
                page.OnLoadingDialog(false);

                if (model.Count == 0)
                    return;

                if (model[0].ITAB_DATA2 != null)
                    ZPMS0003Model = model[0].ITAB_DATA2;
                else
                    ZPMS0003Model.Add(new ZPMS0003Model() { AUFNR = selectedRow.AUFNR });

                OnPropertyChanged(nameof(ZPMS0003Model));
                SubTitleText = string.Format("{0} : 자재요청", selectedRow.AUFNR);
                page.OnMatRequestOpen();
            });

            //상세자료 OPen 이벤트 설정
            OnDetailViewOpen = new Command<ZPMS0002Model>( (ZPMS0002Model selectedRow) =>
            {
                PopupCardviewDataModel = new ObservableCollection<ZPMS0002Model>();
                PopupCardviewDataModel.Add(selectedRow);

                OnPropertyChanged(nameof(PopupCardviewDataModel));
                page.OnDetailViewOpen();
            });

            //자재요청 저장 이벤트 설정
            OnMatRequestSave = new Command(async () =>
            {
                if (bRequestTextError)
                    return;

                var result = await page.OnMatRequestDialogOpen();
                if (!result)
                    return;

                page.OnLoadingDialog(true);
                var iMATE = new IMATE();
                var model = await iMATE.SaveOrderData(ZPMS0003Model[0]);
                if(model.Count == 0)
                {
                    page.OnLoadingDialog(false);
                    return;
                }
                
                page.OnResultMessage(model[0].E_TYPE, model[0].E_MSG);

                page.OnMatRequestOpen();

                //if (model[0].E_TYPE == "S")
                CardviewDataModel = await iMATE.GetOrderList(StartDate, EndDate);
                page.OnLoadingDialog(false);
   
            });

            //자재요청 텍스트 이벤트 설정
            OnMatRequestTextChange = new Command<ZPMS0003Model>((ZPMS0003Model selectedRow) =>
            {
                if (selectedRow == null)
                    return;

                if (selectedRow.KURZTEXT.Length > 40)
                    bRequestTextError = true;
                else
                    bRequestTextError = false;
            });
        }

        public WOMAViewModel(WOMU page) : this()
        {
            ZPMS0004Model = new ObservableCollection<ZPMS0004Model>();
            PopupMaterialUseDataModel = new ObservableCollection<WOMatMedel>();

            //조회 이벤트 설정
            OnSearchData = new Command( async () =>
            {
                CardviewDataModel.Clear();
                page.OnLoadingDialog(true);
                var iMATE = new IMATE();
                CardviewDataModel = await iMATE.GetOrderList(StartDate, EndDate);
                page.OnLoadingDialog(false);
                OnPropertyChanged(nameof(CardviewDataModel));
            });

            //자재사용 팝업오픈 이벤트 설정
            OnMatUse = new Command<ZPMS0002Model>( async (ZPMS0002Model selectedRow) =>
            {
                ZPMS0004Model.Clear();
                PopupMaterialUseDataModel.Clear();
                page.OnLoadingDialog(true);
                var iMATE = new IMATE();
                var model = await iMATE.GetOrderDetailList(selectedRow.AUFNR);
                page.OnLoadingDialog(false);
                if (model.Count == 0)
                    return;

                if (model[0].ITAB_DATA3.Count > 0)
                {
                    ZPMS0004Model = model[0].ITAB_DATA3;
                    SubTitleText = string.Format("{0} : 자재목록", selectedRow.AUFNR);
                    foreach (var item in ZPMS0004Model)
                    {
                        PopupMaterialUseDataModel.Add(new WOMatMedel(item.AUFNR, item.RSNUM, item.WERKS, item.LGORT, item.LGOBE, item.MATNR, item.MATNR_DESC,
                            item.VAPLZ, item.VAPLZ_DESC, item.MEINS, item.BDTER, item.QTY_REV, item.QTY_REQ, item.QTY_OUT, item.QTY_CON, item.QTY_REC, item.QTY_IEV, 0));
                    }
                    page.OnMatUseOpen();
                }
                else
                {
                    if (model[0].E_TYPE == "S")
                        page.OnResultMessage("E", Properties.Resources.Dialog_No_data);
                    else
                        page.OnResultMessage(model[0].E_TYPE, model[0].E_MSG);
                }

                OnPropertyChanged(nameof(ZPMS0003Model));
                
            });

            OnMatUseChange = new Command<WOMatMedel>((WOMatMedel selectedRow) =>
            {
                if (selectedRow.QTY_OUT < selectedRow.QTY_INPUT + selectedRow.QTY_CON)
                {
                    selectedRow.ErrorText = "수량초과";
                    selectedRow.HasError = true;
                }
                else
                {
                    selectedRow.ErrorText = "";
                    selectedRow.HasError = false;
                    selectedRow.QTY_REC = selectedRow.QTY_OUT - selectedRow.QTY_INPUT - selectedRow.QTY_CON;
                }

                OnPropertyChanged(nameof(PopupMaterialUseDataModel));
            });

            //자재사용 저장 이벤트 설정
            OnMatUseSave = new Command(async () =>
            {
                bool error = false;

                foreach(var row in popupMaterialUseDataModel)
                {
                    if (row.HasError)
                    {
                        error = true;
                        return;
                    }
                }

                if (error)
                    return;

                var result = await page.OnMatUseDialogOpen();
                if (!result)
                    return;

                page.OnLoadingDialog(true);
                var iMATE = new IMATE();
                var model = await iMATE.SaveOrderData(popupMaterialUseDataModel);
                if (model.Count == 0)
                {
                    page.OnLoadingDialog(false);
                    return;
                }

                page.OnResultMessage(model[0].E_TYPE, model[0].E_MSG);

                page.OnMatUseOpen();

                //if (model[0].E_TYPE == "S")
                CardviewDataModel = await iMATE.GetOrderList(StartDate, EndDate);
                page.OnLoadingDialog(false);

            });
        }

        public WOMAViewModel(WOMR page) : this()
        {
            ZPMS0004Model = new ObservableCollection<ZPMS0004Model>();
            PopupMaterialUseDataModel = new ObservableCollection<WOMatMedel>();

            //조회 이벤트 설정
            OnSearchData = new Command( async () =>
            {
                CardviewDataModel.Clear();
                page.OnLoadingDialog(true);
                var iMATE = new IMATE();
                CardviewDataModel = await iMATE.GetOrderList(StartDate, EndDate);
                page.OnLoadingDialog(false);
                OnPropertyChanged(nameof(CardviewDataModel));
            });

            //자재반납 팝업오픈 이벤트 설정
            OnMatReturn = new Command<ZPMS0002Model>(async (ZPMS0002Model selectedRow) =>
            {
                //PopupMaterialUseDataModel.Clear();
                //var model = new WOMatMedel();
                //model.getData(PopupMaterialUseDataModel);
                //SubTitleText = string.Format("{0} : 자재목록", selectedRow.AUFNR);
                //page.OnMatReturnOpen();

                ZPMS0004Model.Clear();
                PopupMaterialUseDataModel.Clear();
                page.OnLoadingDialog(true);
                var iMATE = new IMATE();
                var model = await iMATE.GetOrderDetailList(selectedRow.AUFNR);
                page.OnLoadingDialog(false);
                if (model.Count == 0)
                    return;

                if (model[0].ITAB_DATA3.Count > 0)
                {
                    ZPMS0004Model = model[0].ITAB_DATA3;
                    SubTitleText = string.Format("{0} : 자재목록", selectedRow.AUFNR);
                    foreach (var item in ZPMS0004Model)
                    {
                        PopupMaterialUseDataModel.Add(new WOMatMedel(item.AUFNR, item.RSNUM, item.WERKS, item.LGORT, item.LGOBE, item.MATNR, item.MATNR_DESC,
                            item.VAPLZ, item.VAPLZ_DESC, item.MEINS, item.BDTER, item.QTY_REV, item.QTY_REQ, item.QTY_OUT, item.QTY_CON, item.QTY_REC, item.QTY_IEV, 0));
                    }
                    page.OnMatReturnOpen();
                }
                else
                {
                    if (model[0].E_TYPE == "S")
                        page.OnResultMessage("E", Properties.Resources.Dialog_No_data);
                    else
                        page.OnResultMessage(model[0].E_TYPE, model[0].E_MSG);
                }

                OnPropertyChanged(nameof(ZPMS0003Model));
            });


            OnMatReturnChange = new Command<WOMatMedel>((WOMatMedel selectedRow) =>
            {
                if (selectedRow.QTY_REC > selectedRow.QTY_OUT - selectedRow.QTY_CON)
                {
                    selectedRow.ErrorText = "수량초과";
                    selectedRow.HasError = true;
                }
                else
                {
                    selectedRow.ErrorText = "";
                    selectedRow.HasError = false;
                }

                OnPropertyChanged(nameof(PopupMaterialUseDataModel));
            });

            //자재반납 저장 이벤트 설정
            OnMatReturnSave = new Command(async () =>
            {
                bool error = false;

                foreach (var row in popupMaterialUseDataModel)
                {
                    if (row.HasError)
                    {
                        error = true;
                        return;
                    }
                }

                if (error)
                    return;

                var result = await page.OnMatReturnDialogOpen();
                if (!result)
                    return;

                page.OnMatReturnOpen();
            });
        }
    }
}
