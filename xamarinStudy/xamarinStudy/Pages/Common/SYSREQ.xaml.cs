using Acr.UserDialogs;
using DevExpress.XamarinForms.DataForm;
using DevExpress.XamarinForms.Editors;
using NAMHE.Model;
using NMAP.Utils;
using NMAP.Utils.PickerSourceProvider;
using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using XNSC.Net;

namespace NMAP.Pages.Common
{
    /// <summary>
    /// 시스템 사용요청
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SYSREQ : ContentPage
    {
        private readonly SysReqDataModel sysReqDataModel;
        private readonly SysReqPickerSourceProvider sysReqPicker;

        /// <summary>
        /// 생성자
        /// </summary>
        public SYSREQ()
        {
            InitializeComponent();

            sysReqDataModel = new SysReqDataModel();
            sysReqPicker = new SysReqPickerSourceProvider(sysReqDataModel);
            sysReqPicker.CodeInfosLoaded += SysReqPicker_CodeInfosLoaded;
            dataForm.DataObject = sysReqDataModel;
            dataForm.PickerSourceProvider = sysReqPicker;

            sysReqPicker.LoadDataModel();
            UserDialogs.Instance.ShowLoading("잠시만 기다려 주십시오.");
        }

        /// <summary>
        /// 코드 로딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void SysReqPicker_CodeInfosLoaded(object sender, ResultEventArgs e)
        {
            UserDialogs.Instance.HideLoading();
            if(!e.IsSuccess)
                UserDialogs.Instance.AlertAsync(e.Message, "시스템 오류");

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

        private void SysReq_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dataForm.Validate())
                    return;

                var sysReqModel = new ZNBPSysrqModel()
                {
                    RQNUM = Path.GetRandomFileName().Replace(".", "").ToLower(),
                    MANDT = App.Mandt,
                    APPID = App.APPID,

                    LOGID = sysReqDataModel.LoginId,
                    LOGPW = CRYPT.SHA256Hash(sysReqDataModel.Password).ToUpper(),

                    RQTYP = sysReqDataModel.RequireType,
                    ORGID = sysReqDataModel.OrgId,
                    NAME = sysReqDataModel.Name,

                    ROLE = sysReqDataModel.Role,
                    PERM = sysReqDataModel.Perm,

                    MACID = App.DeviceId,
                    INTIP = "",
                    
                    ORGDES1 = "",
                    ORGDES2 = "",
                    ORGDES3 = "",
                    ORGDES4 = "",
                    ORGDES5 = "",
                    VORGID = "",
                    TORGID = "",
                    CORGID = "",
                    YORGID = "",
                    ETCORG1 = "",
                    ETCIRG2 = "",
                    
                    INITPW = "N",
                    APPST = "R",

                    REFDA1 = "",
                    REFDA2 = "",
                    REFDA3 = "",
                    REFDA4 = "",
                    REFDA5 = "",
                    
                    AENAM = "IF_IMATE",
                    AEDAT = DateTime.Now,
                    AEZET = DateTime.Now.TimeOfDay,
                    ERNAM = "IF_IMATE",
                    ERDAT = DateTime.Now,
                    ERZET = DateTime.Now.TimeOfDay,

                    ModelStatus = XNSC.DD.EX.DIMModelStatus.Add
                };

                switch (sysReqDataModel.RequireType)
                {
                    case "V":
                        var vendRow = sysReqPicker.CodeInfosSet.Tables["구매업체"].AsEnumerable().First(r => r.Field<string>("LIFNR") == sysReqDataModel.OrgId);
                        sysReqModel.ORGDES1 = vendRow.Field<string>("NAME1");
                        sysReqModel.ORGDES2 = vendRow.Field<string>("ORT01");
                        sysReqModel.ORGDES3 = vendRow.Field<string>("STRAS");
                        sysReqModel.VORGID = sysReqDataModel.OrgId;
                        break;

                    case "T":
                        var transRow = sysReqPicker.CodeInfosSet.Tables["운송업체"].AsEnumerable().First(r => r.Field<string>("LIFNR") == sysReqDataModel.OrgId);
                        sysReqModel.ORGDES1 = transRow.Field<string>("NAME1");
                        sysReqModel.ORGDES2 = transRow.Field<string>("ORT01");
                        sysReqModel.ORGDES3 = transRow.Field<string>("STRAS");
                        sysReqModel.TORGID = sysReqDataModel.OrgId;
                        break;

                    case "C":
                        var custRow = sysReqPicker.CodeInfosSet.Tables["운송업체"].AsEnumerable().First(r => r.Field<string>("KUNNR") == sysReqDataModel.OrgId);
                        sysReqModel.ORGDES1 = custRow.Field<string>("NAME1");
                        sysReqModel.ORGDES2 = custRow.Field<string>("ORT01");
                        sysReqModel.ORGDES3 = custRow.Field<string>("STRAS");
                        sysReqModel.CORGID = sysReqDataModel.OrgId;
                        break;

                    case "Y":
                    default:
                        var empRow = sysReqPicker.CodeInfosSet.Tables["사원"].AsEnumerable().First(r => r.Field<string>("EMP_NO") == sysReqDataModel.OrgId);
                        sysReqModel.ORGDES1 = empRow.Field<string>("EMP_NM");
                        sysReqModel.ORGDES2 = empRow.Field<string>("DEPT_CD");
                        sysReqModel.ORGDES3 = empRow.Field<string>("DEPT_NM");
                        sysReqModel.YORGID = sysReqDataModel.OrgId;
                        break;
                }

                var sysReqModelList = new ZNBPSysrqModelList
                {
                    sysReqModel
                };

                ImateHelper.GetSingleTone().Adapter.ModifyModelData<ZNBPSysrqModelList>(App.DbTitle, "NBPDataModels", "NAMHE.Model.ZNBPSysrqModelList", sysReqModelList);
                UserDialogs.Instance.Toast("시스템 요청을 하였습니다");
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.AlertAsync(ex.Message, "오류");
            }
        }

        /// <summary>
        /// 폼 유효성 검사
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataForm_ValidateProperty(object sender, DataFormPropertyValidationEventArgs e)
        {
            if (e.PropertyName == "OrgId")
            {
                if (sysReqDataModel.RequireType == "Y")
                {
                    sysReqDataModel.Name = sysReqPicker.CodeInfosDic["사원"].FirstOrDefault(c => c.Code == e.NewValue as string)?.DisplayName??"";

                    //내부 Edit에 표시 한다.
                    var item = dataForm.Items.First(i => i.FieldName == "Name");
                    var itemEditor = item.GetType().BaseType.BaseType.BaseType.GetField("innerEditor", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    if (itemEditor != null)
                        ((TextEdit)itemEditor.GetValue(item)).Text = sysReqDataModel.Name;
                }
            }

            if(e.PropertyName == "PasswordConfirm")
            {
                if(!sysReqDataModel.Password.Equals(e.NewValue as string))
                {
                    e.HasError = true;
                    e.ErrorText = "암호가 일치 하지 않습니다.";
                }
            }

            //내부 Editor 
            //var item = dataForm.Items.FirstOrDefault(i => i.FieldName == e.PropertyName) as DataFormItem;
            //var itemType = item.GetType();
            //var itemEditor = itemType.BaseType.BaseType.GetField("innerEditor", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            //if( itemEditor != null )
            //    var editor = itemEditor.GetValue(item) as ComboBoxEdit;
        }
    }
}