using Acr.UserDialogs;
using Acr.UserDialogs.Infrastructure;
using DevExpress.XamarinForms.Core.Utils.Internal;
using NAMHE.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Xml.Linq;
using XNSC;
using XNSC.DD;
using XNSC.DD.EX;

namespace NMAP.Utils
{
    /// <summary>
    /// 사용자 ID 중복 체크
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class NMapUserIdValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="resourceManagerProvider"></param>
        /// <param name="errMsgResKey"></param>
        public NMapUserIdValidationAttribute() 
            : base()
        {
         }

        /// <summary>
        /// 요청 
        /// </summary>
        public override bool RequiresValidationContext => true;

        /// <summary>
        /// 이중 체크
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected bool IsDupicate(object value, ValidationContext validationContext)
        {
            try
            {
                var userId = value as string;
                if (string.IsNullOrEmpty(userId))
                    return true;

                var dataService = ImateHelper.GetSingleTone();

                var whereCond = $"MANDT = '{App.Mandt}' AND APPID = '{App.APPID}' AND UPPER(LOGID) = UPPER('{userId}')";

                //ID가 등록 되어 있는지 확인
                var sysReqModel = dataService.Adapter.SelectModelData<ZNBPSysrqModelList>(App.DbTitle, "NBPDataModels", "NAMHE.Model.ZNBPSysrqModelList", new string[0], whereCond, "", QueryCacheType.None);

                if (sysReqModel.Count > 0)
                    return true;

                return false;
            }
            catch(Exception ex)
            {
                UserDialogs.Instance.AlertAsync(ex.Message, "시스템오류");
                throw;
            }
        }

        /// <summary>
        /// 유효성 검사
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (IsDupicate(value, validationContext))
                    return new ValidationResult(ErrorMessage);

                return null;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.AlertAsync(ex.Message, "시스템오류");
                return null;
            }
        }
    }
}
