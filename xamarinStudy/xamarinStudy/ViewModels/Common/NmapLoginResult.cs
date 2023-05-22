using NAMHE.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMAP.ViewModels.Common
{
    /// <summary>
    /// 로그인 정보
    /// </summary>
    public class NmapLoginResult
    {
        /// <summary>
        /// 로그인 정보
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 메시지
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 기본 Path
        /// </summary>
        public string DefaultPath { get; set; }

        /// <summary>
        /// 사용자 Data
        /// </summary>
        public LoginDataModel UserData { get; set; }

        /// <summary>
        /// 시스템 요청 모델
        /// </summary>
        public object[] DefaultPathParams { get; set; }
    }
}
