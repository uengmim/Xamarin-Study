using NMAP.Utils;
using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NMAP.ViewModels
{
    internal class ViewModelManager : ViewModelBase
    {
        /// <summary>
        /// Navigation 메뉴 리스트 데이터 모델
        /// </summary>
        public ObservableCollection<MenuDataModel> NaviMenuList { get; set; }

        /// <summary>
        /// 표시용 메뉴 리스트
        /// </summary>
        public ObservableCollection<MenuDataModel> MenuList { get => menuList; set { menuList = value; OnPropertyChanged(nameof(MenuList)); } }
        private ObservableCollection<MenuDataModel> menuList = new ObservableCollection<MenuDataModel>();

        /// <summary>
        /// 인스턴스를 초기화 한다,
        /// </summary>
        public static ViewModelBase InitInstance(bool isInit = false)
        {
            if (!isInit && _instance != null )
                return _instance;

            return _instance = (new ViewModelManager()).InitObject();
        }

        /// <summary>
        /// 생성자
        /// </summary>
        public ViewModelManager() {
            ReloadMenuList();
        }


        /// <summary>
        /// 메뉴 리스트를 다시로드 한다.
        /// </summary>
        public void ReloadMenuList()
        {
            NaviMenuList = ModelDataLoader.NaviMenuList;
            MenuList = ModelDataLoader.MenuList;
        }

        /// <summary>
        /// 현재 Object를 반환 한다.
        /// </summary>
        /// <returns></returns>
        protected override ViewModelBase InitObject() => this;

        //--------------------------------------------------------------------------------------

        /// <summary>
        /// 로그인 View 모델
        /// </summary>
        public LoginDataModel LoginInfo => App.LoginInfo;
    }
}
