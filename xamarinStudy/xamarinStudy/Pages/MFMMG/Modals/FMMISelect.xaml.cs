using Acr.UserDialogs;
using DevExpress.XamarinForms.DataGrid;
using NAMHE.Model;
using NMAP.Models.Common;
using NMAP.ViewModels.Common;
using NMAP.ViewModels.MFMIN;
using NMAP.ViewModels.MFMMG;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XNSC.DD.EX;

namespace NMAP.Pages.MFMMG.Modals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FMMISelect : ContentPage, INMapAppInit
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public FMMISelect(ObservableCollection<T001L> model)
        {
            InitializeComponent();
            InitBindingContext(model);
        }

        #region INMapAppInfo의 구현

        /// <summary>
        /// 로그인 정보
        /// </summary>
        public LoginDataModel LogInInfo { get; set; }

        /// <summary>
        /// 메뉴 정보
        /// </summary>
        public MenuDataModel MenuInfo { get; set; }

        /// <summary>
        /// 바인딩 컨텍스를 초기화 한다.
        /// </summary>
        public void InitBindingContext(ObservableCollection<T001L> model)
        {
            BindingContext = new FMMIViewModel(this, model);
        }
        public void InitBindingContext()
        {
            BindingContext = new FMMIViewModel(this);
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
        private void Select_T001L(object sender, DataGridGestureEventArgs e)
        {
            var selItem = e.Item as T001L;
            MessagingCenter.Instance.Send<object, string>(this, "SendItem", selItem.LGORT);
            Navigation.PopModalAsync();
        }
    }
}