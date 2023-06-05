using Acr.UserDialogs;
using DevExpress.XamarinForms.Navigation;
using NMAP.Pages.Common;
using NMAP.ViewModels;
using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using NMAP.Utils;

namespace NMAP
{
    public partial class MainPage : DrawerPage
    {
        private ViewModelManager modelManager = ViewModelManager.InitInstance() as ViewModelManager;

        /// <summary>
        /// 
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            DrawerContentMaxHeight = App.ScreenHeight;
            BindingContext = modelManager;
        }


        // <summary>
        /// 페이지 구성시 생성자 바로 다음, Resume 시에 호출되는 Event
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Instance.Subscribe<object>(this, "menuOpen", (send) =>
            {
                IsDrawerOpened = !IsDrawerOpened;
            });

            MessagingCenter.Instance.Subscribe<object, object>(this, "homeMenuTap", (send, item) =>
            {
                TapGestureRecognizer_Tapped(item, null);
            });

            MessagingCenter.Instance.Subscribe<object>(this, "backHome", (send) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    App.Navigate("HOME");
                });
            });


            MessagingCenter.Instance.Subscribe<object>(this, "reloadMenu", (send) =>
            {
                UserDialogs.Instance.ShowLoading();

                ModelDataLoader.GetNaviMenuData().ContinueWith(f =>
                {
                    if (f.IsFaulted)
                    {
                        UserDialogs.Instance.HideLoading();
                    }
                    else
                    {
                        //반환값은 표시할 메뉴임
                        modelManager.MenuList = f.Result;

                        App.Navigate("HOME");

                        UserDialogs.Instance.HideLoading();
                    }
                });
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            MessagingCenter.Instance.Subscribe<object, Page>(this, "turnPage", (send, page) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MainContent = new NavigationPage(page)
                    {
                        BarTextColor = Color.Black,
                        BarBackgroundColor = Color.White,
                    };
                });
            });
        }

        /// <summary>
        /// 페이지 Pause 및 Close 될때 마다 호출되는 Event
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Instance.Unsubscribe<object>(this, "menuOpen");
            MessagingCenter.Instance.Unsubscribe<object, object>(this, "homeMenuTap");
            MessagingCenter.Instance.Unsubscribe<object>(this, "backHome");
            MessagingCenter.Instance.Unsubscribe<object>(this, "reloadMenu");
        }
        ///<summary>
        /// 뒤로가기버튼
        /// </summary>
        protected override bool OnBackButtonPressed()
        {
            try
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    try
                    {
                        await App.GlobalNavigation.PopAsync();
                    }
                    catch(Exception ex)
                    {
                        await UserDialogs.Instance.AlertAsync(ex.Message);
                    }
                });

                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// DrawerPage MainContent 교체 Event
        /// Drawer 내부 및 HomePage 에서 쓰임
        /// </summary>
        /// <param name="target">Event를 요청한 Page 별 Binding Context</param>
        private async void ChangeMainContent(MenuDataModel target)
        {
            try
            {
                if (target.Name == "HOME")
                {

                    App.Navigate(target.Name);
                    //MainContent = NMapUtility.NMapPageActivation(target);
                }
                else
                {
                    await MainContent.Navigation.PushAsync(NMapUtility.NMapPageActivation(target));
                }
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.Alert($"'{target.Title}'을 로딩 할수 없습니다.{Environment.NewLine}{ex.Message}");
            }
        }

        /// <summary>
        /// 페이지 이동 Tap Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            MenuDataModel target;
            if (sender is Grid)
            {
                target = ((Grid)sender).BindingContext as MenuDataModel;
            }
            else if (sender is Frame)
            {
                target = ((Frame)sender).BindingContext as MenuDataModel;
            }
            else if (sender is PancakeView)
            {
                target = ((PancakeView)sender).BindingContext as MenuDataModel;
            }
            else
                target = null;

            ChangeMainContent(target);

            if (sender is Grid)
                IsDrawerOpened = !IsDrawerOpened;
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
        /// 로그아웃 버턴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_Clicked(object sender, EventArgs e)
        {
            App.Navigate("LOGIN");
        }

    }
}
