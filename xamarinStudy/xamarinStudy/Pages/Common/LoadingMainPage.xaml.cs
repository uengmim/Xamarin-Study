using Acr.UserDialogs;
using NMAP.Utils;
using NMAP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using XNSC.Net;

namespace NMAP.Pages.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingMainPage : ContentPage
    {
        private ViewModelManager viewModelManager;

        public LoadingMainPage()
        {
            viewModelManager = ViewModelManager.InitInstance() as ViewModelManager;
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            RotateIndicator();
            await ModelDataLoader.GetNaviMenuData().ContinueWith(f =>
            {
                try
                {
                    if (!f.IsFaulted)
                    {
                        //결과는 화면에 표시할 메뉴의 리스트를 반환 한다.
                        viewModelManager.MenuList = f.Result;
                        App.Navigate("HOME");
                    }
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.AlertAsync(ex.Message, "시스템 오류");
                }

            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }


        public async void RotateIndicator() { do { await imgRotate.RotateTo(5400, 30000); } while (true); }
    }
}