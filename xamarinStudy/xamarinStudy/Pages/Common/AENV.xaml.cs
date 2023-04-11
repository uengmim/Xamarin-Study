using Acr.UserDialogs;
using DevExpress.XamarinForms.Editors;
using NMAP.Pages.Common;
using NMAP.Utils;
using NMAP.ViewModels.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XNSC.DD.EX;

namespace NMAP.Pages.Common
{
   
    public partial class AENV : ContentPage {

            public AENV()
        {
            InitializeComponent();
            this.BindingContext = new List<Server>() {
                new Server {Name = "DS4", Code = "DS4", Mandt = "500", Werks = "1000", Spras = "3", IfUserId="IF_MATE"},
                new Server {Name = "DS4_600", Code = "DS4_600", Mandt = "600", Werks = "1000", Spras = "3", IfUserId="IF_MATE"},
                new Server {Name = "QS4", Code = "QS4", Mandt = "200", Werks = "1000", Spras = "3", IfUserId="IF_MATE"},
                new Server {Name = "QS4_210", Code = "QS4", Mandt = "210", Werks = "1000", Spras = "3", IfUserId="IF_MATE"}
            };

            var myValue = Preferences.Get("serverName", "DS4");
            serverCombo.SelectedValue = myValue;
        }

        public class Server
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public string Mandt { get; set; }
            public string Werks { get; set; }
            public string Spras { get; set; }
            public string IfUserId { get; set; }
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            App.Navigate("LOGIN");
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            try
            {
                var selServer = serverCombo.SelectedItem as Server;

                Preferences.Set("serverKey", selServer.Code);
                Preferences.Set("serverName", selServer.Name);
                Preferences.Set("serverMandt", selServer.Mandt);
                Preferences.Set("serverWerks", selServer.Werks);
                Preferences.Set("serverSpras", selServer.Spras);
                Preferences.Set("serverIfUserId", selServer.IfUserId);

                App.InitApp();
                App.Navigate("LOGIN");

                UserDialogs.Instance.Toast("설정을 저장 했습니다.");

            }
            catch(Exception ex)
            {
                UserDialogs.Instance.AlertAsync(ex.Message, "설정 저장 오류");
            }
        }
    }

   
}