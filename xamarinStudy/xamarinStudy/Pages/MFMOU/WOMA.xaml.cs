using Acr.UserDialogs;
using DevExpress.XamarinForms.Editors;
using NMAP.Models.MFMOU;
using NMAP.ViewModels.Common;
using NMAP.ViewModels.MFMOU;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XNSC;
using XNSC.DD;

namespace NMAP.Pages.MFMOU
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WOMA : ContentPage, INMapAppInit
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public WOMA()
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
            BindingContext = new WOMAViewModel(this);
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        /// <summary>
        /// 자재요청 팝업 온/오프 이벤트
        /// </summary>
        public void OnMatRequestOpen()
        {
            popWOMatRequestView.IsOpen = !popWOMatRequestView.IsOpen;
        }

        /// <summary>
        /// DetailView 팝업 온/오프 이벤트
        /// </summary>
        public void OnDetailViewOpen()
        {
            popDetailView.IsOpen = !popDetailView.IsOpen;
        }

        /// <summary>
        /// 저장 다이얼로그 이벤트
        /// </summary>
        /// <returns></returns>
        public async Task<bool> OnMatRequestDialogOpen()
        {
            return await DisplayAlert(Properties.Resources.Dialog_Save_Title, 
                Properties.Resources.Dialog_Save_Message, 
                Properties.Resources.Dialog_OK, 
                Properties.Resources.Dialog_Cancel);
        }

        private void OnPopupClose_Clicked(object sender, EventArgs e)
        {
            OnMatRequestOpen();
        }


        private void OnDetailPopupClose_Clicked(object sender, EventArgs e)
        {
            OnDetailViewOpen();
        }

        /// <summary>
        /// 로딩 다이얼로그 온/오프
        /// </summary>
        /// <param name="yn"></param>
        public void OnLoadingDialog(bool yn)
        {
            if(yn)
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