using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NMAP.Pages.Common;
using Acr.UserDialogs;
using NMAP.ViewModels.Common;
using NMAP.Utils;
using Xamarin.Essentials;
using DeviceId;
using XNSC;
using System.Threading.Tasks;

namespace NMAP
{
    public partial class App : Application
    {
        /// <summary>
        /// Screen 높이
        /// </summary>
        public static int ScreenHeight { get; set; }
        /// <summary>
        /// Screen  넓이
        /// </summary>
        public static int ScreenWidth { get; set; }

        /// <summary>
        /// 로그인 정보
        /// </summary>
        public static LoginDataModel LoginInfo { get; set; }

        /// <summary>
        /// 앱의 중지 시간
        /// </summary>
        public DateTime StopTime { get; set; }

        /// <summary>
        /// 앱의 다시시작 시간
        /// </summary>
        public DateTime ResumeTime { get; set; }

        //-----------------------------------------------------------------

        /// <summary>
        /// APP ID
        /// </summary>
        public const string APPID = "NMAP";

        /// <summary>
        /// Device 식별자
        /// </summary>
        public static string DeviceId { get; set; } = InitApp();

        /// <summary>
        /// MANDT
        /// </summary>
        public static string Mandt { get; private set; }
       
        /// <summary>
        /// Plant
        /// </summary>
        public static string Werks { get; private set; }

        /// <summary>
        /// 언어 키
        /// </summary>
        public static string Spras { get; private set; }

        /// <summary>
        /// 서버 설정
        /// </summary>
        public static string DbTitle { get; private set; }

        /// <summary>
        /// 인터페이스 사용자 ID
        /// </summary>
        public static string IFUserId { get; private set; }

        /// <summary>
        /// Navigarion Page
        /// </summary>
        public static INavigation GlobalNavigation { get; private set; }

        /// <summary>
        /// 정적 초기화
        /// </summary>
        /// <returns></returns>
        public static string InitApp()
        {
               
            string ImateDeviceId;

            try
            {
                ImateDeviceId = new DeviceIdBuilder().ToString();
            }
            catch (Exception)
            {
                ImateDeviceId = null;
            }

            Mandt = Preferences.Get("serverMandt", "100");
            Werks = Preferences.Get("serverWerks", "1000");
            Spras = Preferences.Get("serverSpras", "3");
            DbTitle = $"{Preferences.Get("serverKey", "PS4")}?client={Mandt};pool_name=imate_pool_{Mandt}";
            IFUserId = Preferences.Get("serverIfUserId", "IF_MATE");

            DeviceId = ImateDeviceId;

            return ImateDeviceId;
        }

        /// <summary>
        /// 화면을 이동 시킨다.
        /// </summary>
        /// <param name="uiCode"></param>
        /// <param name="uiParams">UI 파라미터</param>
        public static void Navigate(string uiCode, params object[] uiParams)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    Task.Delay(200).Wait();
                    Current.MainPage = new MainPage()
                    {
                        MainContent = new NavigationPage(NMapUtility.NMapPageInit(uiCode, uiParams))
                    };
                }
                catch (Exception e)
                {
                    UserDialogs.Instance.AlertAsync(e.Message, "화면이동 오류");
                }
            });
        }

        /// <summary>
        /// 생성자
        /// </summary>
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            DevExpress.XamarinForms.Navigation.Initializer.Init();
            DevExpress.XamarinForms.Popup.Initializer.Init();
            DevExpress.XamarinForms.Editors.Initializer.Init();
            DevExpress.XamarinForms.DataGrid.Initializer.Init();
            DevExpress.XamarinForms.DataForm.Initializer.Init();
            DevExpress.XamarinForms.CollectionView.Initializer.Init();
            DevExpress.XamarinForms.Charts.Initializer.Init();
            Current.UserAppTheme = OSAppTheme.Light;

            InitializeComponent();

            var rootPage = NMapUtility.NMapPageInit("LOGIN");
            GlobalNavigation = rootPage.Navigation;

            Navigate("LOGIN");
        }

        /// <summary>
        /// 처리되지 않은 예외
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            try
            {
                UserDialogs.Instance.AlertAsync(e.Exception?.Message, "시스템 오류");
                Console.WriteLine($"App - OnUnhandledException - An exception occurred: {e.Exception}");
            }
            catch (Exception)
            {
                //오류는 무시 한다.
            }
        }

        /// <summary>
        /// 처리되지 않은 예외
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                UserDialogs.Instance.AlertAsync((e.ExceptionObject as Exception)?.Message, "시스템 오류");
                Console.WriteLine($"App - OnUnhandledException - An exception occurred: {e.ExceptionObject as Exception}");
            }
            catch (Exception)
            {
                //오류는 무시 한다.
            }
        }

        /// <summary>
        /// 앱 시작
        /// </summary>
        protected override void OnStart()
        {
            return;
        }

        /// <summary>
        /// 앱 슬립
        /// </summary>
        protected override void OnSleep()
        {
            StopTime = DateTime.Now;
        }

        /// <summary>
        /// Sleep후 다시 기동
        /// </summary>
        protected override async void OnResume()
        {
            ResumeTime = DateTime.Now;
            if ((ResumeTime.TimeOfDay - StopTime.TimeOfDay) >= TimeSpan.FromMinutes(1))
            {
                await UserDialogs.Instance.AlertAsync("장시간 미입력으로 앱이 종료 됩니다.\r\n앱을 다시 실행하여 주십시오.", "INFO", "확인");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}
