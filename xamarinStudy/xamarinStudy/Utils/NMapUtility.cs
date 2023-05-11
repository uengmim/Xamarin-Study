using NMAP.ViewModels;
using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NMAP.Utils
{
    /// <summary>
    /// NMAP 유틸리티
    /// </summary>
    internal static class NMapUtility
    {
        /// <summary>
        /// 패이지 초기화
        /// </summary>
        public static Page NMapPageInit(string pageName, object[] uiParams = null)
        {
            try
            {
                var modelMagr = ViewModelManager.InitInstance() as ViewModelManager;
                modelMagr.ReloadMenuList();

                var naviMenuList = modelMagr.NaviMenuList;
                var naviMenuItem = naviMenuList?.FirstOrDefault(m => m.Name == pageName);
                if (naviMenuItem == null)
                    throw new Exception("UI를 찾을수 없습니다.");

                return NMapPageActivation(naviMenuItem, uiParams);
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 메뉴 아이템으로 Page를 Activate한다.
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public static Page NMapPageActivation(MenuDataModel menuItem, object[] uiParams = null)
        {
            if (menuItem == null)
                return null;

            var page = menuItem.PageActivation(uiParams);

            //페이지를 초기화 한다.
            var appInfo = page as INMapAppInit;
            if (appInfo != null)
            {
                appInfo.LogInInfo = App.LoginInfo;
                appInfo.MenuInfo = menuItem;

                appInfo.InitBindingContext();
            }

            return page;
        }
    }
}
