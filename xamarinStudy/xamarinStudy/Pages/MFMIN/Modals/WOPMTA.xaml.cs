using Acr.UserDialogs;
using DevExpress.XamarinForms.Editors;
using NMAP.Models.MFMOU;
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

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NMAP.Pages.MFMIN.Modals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WOPMTA : ContentPage, INMapAppInit
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public WOPMTA(WOPMViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
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
        /// 뒤로가기 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
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
            //popWOMatRequestView.IsOpen = !popWOMatRequestView.IsOpen;
        }

        /// <summary>
        /// 저장 다이얼로그 이벤트
        /// </summary>
        /// <returns></returns>
        public async Task<bool> OnMatRequestDialogOpen()
        {
            return await DisplayAlert("저장", "해당 내용으로 요청하시겠습니까?", "예", "아니오");
        }

    }
}