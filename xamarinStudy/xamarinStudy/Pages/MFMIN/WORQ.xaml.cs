using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NMAP.Pages.MFMIN
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WORQ : ContentPage, INMapAppInit
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public WORQ()
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
            BindingContext = MenuInfo;
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
    }
}