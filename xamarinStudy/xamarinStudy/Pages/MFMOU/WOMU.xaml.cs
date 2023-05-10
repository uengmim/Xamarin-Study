using Acr.UserDialogs;
using DevExpress.XamarinForms.Editors;
using NMAP.Models.MFMOU;
using NMAP.ViewModels.Common;
using NMAP.ViewModels.MFMOU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NMAP.Pages.MFMOU
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WOMU : ContentPage, INMapAppInit
    {
        public WOMAViewModel viewModel { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public WOMU()
        {
            InitializeComponent();
        }

        #region INMapAppInfo의 구현

        /// <summary>
        /// 로그린 정보
        /// </summary>
        public LoginDataModel LogInInfo { get; set; }

        /// <summary>
        /// 메뉴 정보
        /// </summary>
        public MenuDataModel MenuInfo { get; set; }

        /// <summary>
        /// 바인딩 컨텍스를 초기화 한다.
        /// </summary>
        public void InitBindingContext()
        {
            //여기에 컨텍스트를 바인딩 힌다.
            BindingContext = viewModel = new WOMAViewModel(this);
        }

        #endregion

        /// <summary>
        /// 메뉴 버턴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Instance.Send<object>(this, "menuOpen");
        }

        /// <summary>
        /// 자재사용 팝업 온/오프 이벤트
        /// </summary>
        public void OnMatUseOpen()
        {
            popWOMatUseView.IsOpen = !popWOMatUseView.IsOpen;
        }

        private void OnMatUseChange(object sender, EventArgs e)
        {
            var edit = sender as NumericEdit;
            var model = edit.BindingContext as WOMatMedel;

            if (model.QTY_OUT < model.QTY_INPUT + model.QTY_CON)
            {
                edit.ErrorText = "출고수량이상 입력할 수 없습니다.";
                edit.HasError = true;
            }
            else
            {
                edit.ErrorText = "";
                edit.HasError = false;
                model.QTY_REC = model.QTY_OUT - model.QTY_INPUT - model.QTY_CON;
                viewModel.popupMaterialUseDataModel[viewModel.popupMaterialUseDataModel.IndexOf(model)].QTY_REC = model.QTY_REC;
            }
        }

        /// <summary>
        /// 저장 다이얼로그 이벤트
        /// </summary>
        /// <returns></returns>
        public async Task<bool> OnMatUseDialogOpen()
        {
            return await DisplayAlert(Properties.Resources.Dialog_Save_Title,
                Properties.Resources.Dialog_Save_Message,
                Properties.Resources.Dialog_OK,
                Properties.Resources.Dialog_Cancel);
        }

        private void OnPopupClose_Clicked(object sender, EventArgs e)
        {
            OnMatUseOpen();
        }

        /// <summary>
        /// 로딩 다이얼로그 온/오프
        /// </summary>
        /// <param name="yn"></param>
        public void OnLoadingDialog(bool yn)
        {
            if (yn)
                UserDialogs.Instance.ShowLoading();
            else
                UserDialogs.Instance.HideLoading();

        }

        /// <summary>
        /// 메시지 출력
        /// </summary>
        /// <param name="sCode"></param>
        /// <param name="sMsg"></param>
        public async void OnResultMessage(string sCode, string sMsg)
        {
            if (sCode != "S")
                await DisplayAlert("결과메시지", sMsg, Properties.Resources.Dialog_Confirm);
            else
                await DisplayAlert("결과메시지", Properties.Resources.Dialog_Save_Success, Properties.Resources.Dialog_Confirm);
        }
    }
}