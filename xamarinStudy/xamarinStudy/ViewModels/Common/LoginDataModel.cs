using DevExpress.XamarinForms.Charts;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NMAP.ViewModels.Common
{
    /// <summary>
    /// 로그인 모델
    /// </summary>
    public class LoginDataModel
    {
        /// <summary>
        /// 사용자ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 암호
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 사용자 이름
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Emp Id
        /// </summary>
        public string empId { get; set; }

        /// <summary>
        /// 개인 식별 번호
        /// </summary>
        public string Pin { get; set; }

        /// <summary>
        /// Device 정보
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// 부서ID
        /// </summary>
        public string DeptmentId { get; set; }

        /// <summary>
        /// 부서 이름
        /// </summary>
        public string DeptmentName { get; set; }

        /// <summary>
        /// 롤 리스트
        /// </summary>
        public IEnumerable<string> Roles { get; set; }

        /// <summary>
        /// 권한 리스트
        /// </summary>
        public IEnumerable<string> Permitions { get; set; } 

        /// <summary>
        /// 조직 옵션
        /// </summary>
        public OrganizationOption OrgOption { get; set; }
    }
}
