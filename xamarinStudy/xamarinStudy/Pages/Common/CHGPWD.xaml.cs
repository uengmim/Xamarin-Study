using Acr.UserDialogs;
using DevExpress.XamarinForms.DataForm;
using DevExpress.XamarinForms.Editors;
using NAMHE.Model;
using NMAP.Utils;
using NMAP.Utils.PickerSourceProvider;
using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XNSC.DD.EX;
using XNSC.Net;

namespace NMAP.Pages.Common
{
    /// <summary>
    /// 시스템 사용요청
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CHGPWD : ContentPage
    {
        /// <summary>
        /// 암호 변경
        /// </summary>
        private readonly ChgPwdDataModel chgPwdDataModel;

        /// <summary>
        /// 수정할 시스템 요청
        /// </summary>
        private readonly ZNBPSysrqModel updateSysReq;

        /// <summary>
        /// 생성자
        /// </summary>
        public CHGPWD(ZNBPSysrqModel sysReq)
        {
            InitializeComponent();

            updateSysReq = sysReq;
            chgPwdDataModel = new ChgPwdDataModel()
            {
                LoginId = updateSysReq.LOGID,
            };

            dataForm.DataObject = chgPwdDataModel;
        }

        /// <summary>
        /// Back 버턴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Clicked(object sender, EventArgs e)
        {
            App.Navigate("LOGIN");
        }

        /// <summary>
        /// 암호 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ChgPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataForm.Validate())
                    return;

                var dataService = ImateHelper.GetSingleTone();

                updateSysReq.LOGPW = CRYPT.SHA256Hash(chgPwdDataModel.NewPassword).ToUpper();
                updateSysReq.INITPW = "N";
                updateSysReq.MACID = App.DeviceId;
                updateSysReq.ERNAM = "IF_IMATE";
                updateSysReq.ERDAT = DateTime.Now;
                updateSysReq.ERZET = DateTime.Now.TimeOfDay;
                updateSysReq.ModelStatus = DIMModelStatus.Modify;

                var sysReqModelList = new ZNBPSysrqModelList
                {
                    updateSysReq
                };

                dataService.Adapter.ModifyModelData<ZNBPSysrqModelList>(App.DbTitle, "NBPDataModels", "NAMHE.Model.ZNBPSysrqModelList", sysReqModelList);
                UserDialogs.Instance.Toast("암호 변경을 을 하였습니다");
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync(ex.Message, "오류");
            }
        }

        /// <summary>
        /// 폼 유효성 검사
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataForm_ValidateProperty(object sender, DataFormPropertyValidationEventArgs e)
        {
            if (e.PropertyName == "Password")
            {
                var oldPsswd = CRYPT.SHA256Hash(e.NewValue as string ?? "").ToUpper();
                if (!updateSysReq.LOGPW.Equals(oldPsswd, StringComparison.OrdinalIgnoreCase))
                {
                    e.HasError = true;
                    e.ErrorText = "이전 암호가 일치 하지 않습니다.";
                }
            }
            else if (e.PropertyName == "NewPasswordConfirm")
            {
                if (!chgPwdDataModel.NewPassword.Equals(e.NewValue as string))
                {
                    e.HasError = true;
                    e.ErrorText = "변경할 암호가 일치 하지 않습니다.";
                }
            }
        }
    }
}