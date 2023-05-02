using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NMAP.Utils
{
    /// <summary>
    /// 코드 정보
    /// </summary>
    internal class CodeInfo
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 이름
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string RefCode { get; set; }

        /// <summary>
        /// 표시 이름
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="code">코드</param>
        /// <param name="name">이름</param>
        /// <param name="refCode">참조코드</param>
        /// <param name="displayName">표시이름</param>
        public CodeInfo(string code, string name, string refCode = "", string displayName = "")
        {
            Code = code;
            Name = name;
            RefCode = refCode;
            DisplayName = displayName;
        }
    }
}
