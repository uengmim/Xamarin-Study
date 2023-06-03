using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMAP
{
    /// <summary>
    /// 메뉴 정보
    /// </summary>
    public interface INMapAppInit
    {
        /// <summary>
        /// 현재 메뉴 정보
        /// </summary>
        public MenuDataModel MenuInfo { get; set; }

        /// <summary>
        /// 로그인 정보
        /// </summary>
        public LoginDataModel LogInInfo { get; set; }

        /// <summary>
        /// 바인딩컨텍스트를 초기화 한다.
        /// </summary>
        public void InitBindingContext();
    }
}
