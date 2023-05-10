using Acr.UserDialogs;
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
    public partial class WOMR : ContentPage, INMapAppInit
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public WOMR()
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

        public void OnMatReturnOpen()
        {
            popWOMatReturnView.IsOpen = !popWOMatReturnView.IsOpen;
        }

        private void OnPopupClose_Clicked(object sender, EventArgs e)
        {
            OnMatReturnOpen();
        }

        /// <summary>
        /// 저장 다이얼로그 이벤트
        /// </summary>
        /// <returns></returns>
        public async Task<bool> OnMatReturnDialogOpen()
        {
            return await DisplayAlert(Properties.Resources.Dialog_Save_Title,
                Properties.Resources.Dialog_Save_Message,
                Properties.Resources.Dialog_OK,
                Properties.Resources.Dialog_Cancel);
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