using Acr.UserDialogs;
using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace NMAP.Pages.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage, INMapAppInit
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public HomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 뒤로 가기 버턴
        /// </summary>
        /// <returns></returns>
        protected override  bool OnBackButtonPressed()
        {
           DisplayAlert("Title", "Are you sure you want to leave the screen with unsave changes?", "Yes", "No")
                .ContinueWith(answer =>
                {
                    if (answer.Result)
                        return;

                });
            return false;
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
            BindingContext = MenuInfo;
        }

        #endregion

        /// <summary>
        /// 메뉴 버턴 클릭Home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMenu_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Instance.Send<object>(this, "menuOpen");
        }
       
    }
}