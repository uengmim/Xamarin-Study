using DevExpress.XamarinForms.DataForm;
using NMAP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NMAP.ViewModels.Common
{
    /// <summary>
    /// 시스템 사용요청 데이터 모델
    /// </summary>
    internal class SysReqDataModel
    {
        /// <summary>
        /// 아이디(ID)
        /// </summary>
        [DataFormDisplayOptions(GroupName = "로그인 정보", LabelText = "아이디(ID)", IsLabelVisible =false)]
        [DataFormTextEditor(Placeholder = "아이디(ID)", InplaceLabelText = "아이디(ID)", IsInplaceLabelFloating = true)]
        [Required(ErrorMessage ="사용자ID를 입력 하여 주십시오.")]
        [NMapUserIdValidation(ErrorMessage = "이미 등록된 사용자ID 입니다.")]
        public string LoginId{get; set;}

        /// <summary>
        /// 암호
        /// </summary>
        [DataFormDisplayOptions(GroupName = "로그인 정보", LabelText = "암호", IsLabelVisible = false)]
        [DataFormPasswordEditor(Placeholder = "암호", InplaceLabelText = "암호", IsInplaceLabelFloating = true)]
        [Required(ErrorMessage = "암호를 입력 하여 주십시오.")]
        public string Password { get; set; }

        /// <summary>
        /// 암호확인
        /// </summary>
        [DataFormDisplayOptions(GroupName = "로그인 정보", LabelText = "암호확인", IsLabelVisible = false)]
        [DataFormPasswordEditor(Placeholder = "암호확인", InplaceLabelText = "암호확인", IsInplaceLabelFloating = true)]
        [Compare(nameof(Password), ErrorMessage ="암호가 일치 하지 않습니다.")]
        public string PasswordConfirm { get; set; }

        /// <summary>
        /// 사용자유형
        /// </summary>
        [DataFormDisplayOptions(GroupName = "업체(부서) 정보", LabelText = "사용자 유형", IsLabelVisible = false)]
        [DataFormComboBoxEditor(Placeholder = "사용자 유형", InplaceLabelText = "사용자 유형", IsInplaceLabelFloating = true, DisplayMember ="Name", ValueMember ="Code")]
        [Required(ErrorMessage = "사용자 유형을 입력 하여 주십시오.")]
        public string RequireType { get; set; }

        /// <summary>
        /// 오청 대상
        /// </summary>
        [DataFormDisplayOptions(GroupName = "업체(부서) 정보", LabelText = "요청 대상", IsLabelVisible = false)]
        [DataFormComboBoxEditor(Placeholder = "요청 대상", InplaceLabelText = "요청 대상", IsInplaceLabelFloating = true,
                                DisplayMember = "Name", ValueMember = "Code", ClearIconVisibility = DevExpress.XamarinForms.Editors.IconVisibility.Auto,
                                IsFilterEnabled = true, FilterMode = DevExpress.XamarinForms.Editors.FilterMode.Contains)]
        [Required(ErrorMessage = "요청 대상을 입력 하여 주십시오.")]
        public string OrgId { get; set; }

        /// <summary>
        /// 담당자
        /// </summary>
        [DataFormDisplayOptions(GroupName = "업체(부서) 정보", LabelText = "담당자", IsLabelVisible = false)]
        [DataFormTextEditor(Placeholder = "담당자", InplaceLabelText = "담당자", IsInplaceLabelFloating = true)]
        [Required(ErrorMessage = "담당자를 입력 하여 주십시오.")]
        public string Name { get; set; }

        /// <summary>
        /// 사용자 역활
        /// </summary>
        [DataFormDisplayOptions(GroupName = "역활/권한", LabelText = "역활", IsLabelVisible = false)]
        [DataFormComboBoxEditor(Placeholder = "역활", InplaceLabelText = "역활", IsInplaceLabelFloating = true, DisplayMember = "Name", ValueMember = "Code")]
        [Required(ErrorMessage = "사용자 역활을 입력 하여 주십시오.")]
        public string Role { get; set; }

        /// <summary>
        /// 사용자 권한
        /// </summary>
        [DataFormDisplayOptions(GroupName = "역활/권한", LabelText = "권한", IsLabelVisible = false)]
        [DataFormComboBoxEditor(Placeholder = "권한", InplaceLabelText = "권한", IsInplaceLabelFloating = true, DisplayMember = "Name", ValueMember = "Code")]
        [Required(ErrorMessage = "사용자 권한을 입력 하여 주십시오.")]
        public string Perm { get; set; }
    }
}
