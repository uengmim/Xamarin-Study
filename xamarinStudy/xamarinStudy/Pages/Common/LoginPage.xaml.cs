using Acr.UserDialogs;
using NAMHE.Model;
using NMAP.Models.Common;
using NMAP.Utils;
using NMAP.ViewModels;
using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XNSC;
using XNSC.DD.EX;
using XNSC.Net;
using ZXing;

namespace NMAP.Pages.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {


        private ViewModelManager viewModelManager;

        public LoginPage()
        {
            ViewModelManager.InitInstance(true);
            viewModelManager = ViewModelManager.Instance as ViewModelManager;
           
            InitializeComponent();

            teLoginId.Text = Preferences.Get("saveId", "");
            switRemember.OnColor = Color.FromHex("003851");
            switRemember.IsToggled = Preferences.Get("saveRemember", true);

        }
        ///<summary>
        /// 뒤로가기버튼
        /// </summary>
        protected override bool OnBackButtonPressed()
        {
            try
            {
                //Device.BeginInvokeOnMainThread(async () => await Navigation.PopAsync());
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 로그인 버턴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Login_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Preferences.Get("serverName", null)))
                {
                    UserDialogs.Instance.Toast("상단 설정버튼을 통해 사용정보를 등록하세요.", TimeSpan.FromSeconds(2.5));
                    return;
                }
                else if (string.IsNullOrEmpty(teLoginId.Text))
                {
                    UserDialogs.Instance.Toast("로그인 ID를 넣어주십시오.", TimeSpan.FromSeconds(2.5));
                    return;
                }
                else if (string.IsNullOrEmpty(tePasswd.Text))
                {
                    UserDialogs.Instance.Toast("암호를 넣어주십시오.", TimeSpan.FromSeconds(2.5));
                    return;
                }

                //로딩 
                UserDialogs.Instance.ShowLoading();
                //메뉴 리스트를 초기화 한다.
                ModelDataLoader.ClearMenuList();

                //결과 
                var result = await ModelDataLoader.GetLoginInfo(teLoginId.Text, tePasswd.Text??"");
                if(result.Result)
                {
                    //ID 기억
                    if (switRemember.IsToggled)
                    {
                        Preferences.Set("saveId", teLoginId.Text);
                        Preferences.Set("saveRemember", switRemember.IsToggled);
                    }
                    else
                    {
                        Preferences.Remove("saveId");
                        Preferences.Remove("saveRemember");
                    }

                    //메인페이지 이동
                    App.LoginInfo = result.UserData;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage = new LoadingMainPage();
                    });
                }
                else
                {
                    UserDialogs.Instance.Toast(result.Message);

                    if (!string.IsNullOrEmpty(result.DefaultPath) && result.DefaultPath != "#")
                    {
                        if (result.DefaultPathParams != null)
                            App.Navigate(result.DefaultPath, result.DefaultPathParams);
                        else
                            App.Navigate(result.DefaultPath);
                    }
                }
            }
            catch(Exception ex) {
                UserDialogs.Instance.Alert(ex.Message);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            switRemember.IsToggled = !switRemember.IsToggled;
        }

        private void switRemember_Toggled(object sender, ToggledEventArgs e)
        {

            Device.BeginInvokeOnMainThread(() =>
            {
                if (e.Value)
                {
                    switRemember.OnColor = Color.FromHex("45c9b0");
                }
                else
                {

                    switRemember.OnColor = Color.FromHex("003851");
                }
            });
    
        }

        /// <summary>
        /// 셋팅 버턴 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServer_Clicked(object sender, EventArgs e)
        {
            App.Navigate("AENV");
        }

        /// <summary>
        /// 시스템 사용요청 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //Setting 버튼 클릭 시 이벤트
        private void btnSysReq_Clicked(object sender, EventArgs e)
        {
            App.Navigate("SYSREQ");
        }

        /// <summary>
        /// 암호 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnPasswdChg_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Preferences.Get("serverName", null)))
            {
                UserDialogs.Instance.Toast("상단 설정버튼을 통해 사용정보를 등록하세요.", TimeSpan.FromSeconds(2.5));
                return;
            }
            else if (string.IsNullOrEmpty(teLoginId.Text))
            {
                UserDialogs.Instance.Toast("로그인 ID를 넣어주십시오.", TimeSpan.FromSeconds(2.5));
                return;
            }
            var dataService = ImateHelper.GetSingleTone();

            var resultSysReqModel = await dataService.Adapter.SelectModelDataAsync<ZNBPSysrqModelList>(App.DbTitle, "NBPDataModels", "NAMHE.Model.ZNBPSysrqModelList", new string[0],
              $"MANDT = '{App.Mandt}' AND APPID = '{App.APPID}' AND UPPER(LOGID) = UPPER('{teLoginId.Text}') ", "", QueryCacheType.None);

            if (resultSysReqModel.Count == 0)
            {
                UserDialogs.Instance.Toast("사용자ID가 잘못되었습니다.", TimeSpan.FromSeconds(2.5));
                return;
            }

            App.Navigate("CHGPWD", resultSysReqModel.First());
        }
    }
}