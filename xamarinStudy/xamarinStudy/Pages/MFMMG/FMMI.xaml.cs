using System;
using Acr.UserDialogs;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

using NMAP.ViewModels.MFMMG;
using NMAP.ViewModels.Common;
using NMAP.ViewModels.MFMIN;
using NMAP.Pages.MFMMG.Modals;
using NMAP.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using NAMHE.Model;
using XNSC.DD.EX;
using XNSC.Net;
using NMAP.Models.Common;
using System.Collections.ObjectModel;
using DevExpress.XamarinForms.Editors;
using NMAP.Models.MFMOU;
using ZXing;

namespace NMAP.Pages.MFMMG
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FMMI : ContentPage, INMapAppInit
    {
        public FMMIViewModel viewModel { get; set; }
        /// <summary>
        /// 생성자
        /// </summary>
        public FMMI()
        {
            InitializeComponent();
            InitBindingContext();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            /*
            MessagingCenter.Instance.Subscribe<object, string>(this, "SendItem", (sender, arg) =>
            {
                kukEdit.Text = arg;
            });
            */
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
            BindingContext = viewModel = new FMMIViewModel(this);
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
        
        /// <summary>
        /// 값 변경 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onValueChange(object sender, EventArgs e)
        {
            if (rsnumTxt.Text != "")
            {
                rsnumTxt.Text = rsnumTxt.Text.Substring(0, rsnumTxt.Text.Length > 10 ? 10 : rsnumTxt.Text.Length);
            }
        }

        /// <summary>
        /// QR스캐너 버튼 클릭(자재요청번호 스캔)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void qrScan_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage()
            {
                Title = "Scan QR Code"
            };

            scan.OnScanResult += (result) =>
            {
                scan.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    rsnumTxt.Text = result.Text;

                    if(result.Text != ""){
                        viewModel.OnSearchData.Execute(null);
                    }
                });
            };

            var toolbarItem = new ToolbarItem { Text = "취소" };
            toolbarItem.Clicked += (s, e) =>
            {
                scan.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                });
            };
            var qrPage = new NavigationPage(scan);
            qrPage.ToolbarItems.Add(toolbarItem);

            await Navigation.PushModalAsync(qrPage);

        }

        /// <summary>
        /// 입고창고 화면이동 이벤트
        /// </summary>
        /// <param name="viewModel"></param>
        public async void onPopup_Clicked(ObservableCollection<T001L> model)
        {
            await Navigation.PushModalAsync(new NavigationPage(new FMMISelect(model)));
        }

        /// <summary>
        /// 자재출고 저장 다이얼로그 이벤트
        /// </summary>
        /// <returns></returns>
        public async Task<bool> OnSaveDialogOpen()
        {
            return await DisplayAlert("저장", "해당 내용으로 요청하시겠습니까?", "예", "아니오");
        }
        public async void OnResultMessage(string sCode, string sMsg)
        {
            if (sCode != "S")
                await DisplayAlert("결과메세지", "오류메세지"+sMsg, Properties.Resources.Dialog_Confirm);
            else
                await DisplayAlert("결과메세지", "출고요청이 완료되었습니다.", Properties.Resources.Dialog_Confirm);
        }

        public async void OnErrorMessage(string sMsg)
        {
                await DisplayAlert("알림", sMsg, Properties.Resources.Dialog_Confirm);
        }



    }
}