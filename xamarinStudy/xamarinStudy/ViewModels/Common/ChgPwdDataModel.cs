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
    internal class ChgPwdDataModel
    {
        /// <summary>
        /// 아이디(ID)
        /// </summary>
        [DataFormDisplayOptions(LabelText = "아이디(ID)", IsLabelVisible =false)]
        [DataFormTextEditor(Placeholder = "아이디(ID)", InplaceLabelText = "아이디(ID)", IsInplaceLabelFloating = true, IsReadOnly =true)]
        [Required(ErrorMessage ="사용자ID를 입력 하여 주십시오.")]
        public string LoginId{get; set;}

        /// <summary>
        /// 이전 암호
        /// </summary>
        [DataFormDisplayOptions(LabelText = "이전암호", IsLabelVisible = false)]
        [DataFormPasswordEditor(Placeholder = "이전암호", InplaceLabelText = "암호", IsInplaceLabelFloating = true)]
        [Required(ErrorMessage = "암호를 입력 하여 주십시오.")]
        public string Password { get; set; }

        /// <summary>
        /// 새로운 암호
        /// </summary>
        [DataFormDisplayOptions(LabelText = "변경할 암호", IsLabelVisible = false)]
        [DataFormPasswordEditor(Placeholder = "변경할 암호", InplaceLabelText = "암호", IsInplaceLabelFloating = true)]
        [Required(ErrorMessage = "변경할 암호를 입력 하여 주십시오.")]
        public string NewPassword { get; set; }

        /// <summary>
        /// 새로운 암호확인
        /// </summary>
        [DataFormDisplayOptions(LabelText = "변경할 암호확인", IsLabelVisible = false)]
        [DataFormPasswordEditor(Placeholder = "변경할 암호확인", InplaceLabelText = "암호확인", IsInplaceLabelFloating = true)]
        [Compare(nameof(Password), ErrorMessage ="변경할 암호가 일치 하지 않습니다.")]
        public string NewPasswordConfirm { get; set; }

    }
}
