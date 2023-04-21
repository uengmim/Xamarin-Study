using Acr.UserDialogs;
using DevExpress.XamarinForms.Editors;
using NMAP.Models.MFMOU;
using NMAP.Pages.MFMIN.Modals;
using NMAP.ViewModels.Common;
using NMAP.ViewModels.MFMIN;
using NMAP.ViewModels.MFMOU;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;using DevExpress.XamarinForms.Editors;
using Xamarin.Forms.Xaml;

namespace NMAP.Pages.MFMIN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WOPM : ContentPage, INMapAppInit
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public WOPM()
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
            BindingContext = new WOPMViewModel(this);
        }

        #endregion

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
        /// 저장 다이얼로그 이벤트
        /// </summary>
        /// <returns></returns>
        public async Task<bool> OnMatRequestDialogOpen()
        {
            return await DisplayAlert("저장", "해당 내용으로 요청하시겠습니까?", "예", "아니오");
        }

        /// <summary>
        /// 점검입력 화면이동 이벤트
        /// </summary>
        /// <param name="viewModel"></param>
        public async void OnWOPMWritePage(WOPMViewModel viewModel)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WOPMWrite(viewModel)));
        }

        /// <summary>
        /// 추이분석 화면이동 이벤트
        /// </summary>
        /// <param name="viewModel"></param>
        public async void OnWOPMTAPage(WOPMViewModel viewModel)
        {
            await Navigation.PushModalAsync(new NavigationPage(new WOPMTA(viewModel)));
        }

        /// <summary>
        /// 저장 다이얼로그 이벤트
        /// </summary>
        /// <returns></returns>
        public async Task<bool> OnWOWriteDialogOpen()
        {
            return await DisplayAlert("저장", "해당 내용으로 요청하시겠습니까?", "예", "아니오");
        }

        void CustomDayCellStyle(object sender, CustomSelectableCellStyleEventArgs e)
        {
            if (e.Date.DayOfWeek == DayOfWeek.Saturday || e.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.TextColor = Color.FromHex("F44848");
                if (e.IsTrailing)
                    e.TextColor = Color.FromRgba(e.TextColor.R, e.TextColor.G, e.TextColor.B, 0.5);
            }
        }

        private void CustomDayOfWeekCellStyle(object sender, CustomDayOfWeekCellStyleEventArgs e)
        {
            if (e.DayOfWeek == DayOfWeek.Saturday || e.DayOfWeek == DayOfWeek.Sunday)
                e.TextColor = Color.FromHex("F44848");
        }
    }
}