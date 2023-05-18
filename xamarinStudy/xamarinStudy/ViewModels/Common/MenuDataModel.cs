using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace NMAP.ViewModels.Common
{
    /// <summary>
    /// 메뉴 데이터 모델
    /// </summary>
    public class MenuDataModel
    {
        /// <summary>
        /// 순서
        /// </summary>
        public int Seq { get; set; }
        /// <summary>
        /// 메뉴 이름(코드)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 메뉴 제목
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 메뉴 설명
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 이미지명
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 사용자 롤
        /// </summary>
        public List<string> Roles { get; set; }

        /// <summary>
        /// 사용 권한 코드
        /// </summary>
        public List<string> Permissions { get; set; }

        /// <summary>
        /// 메뉴 Tag
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 사용자 Data
        /// </summary>
        public object UserData { get; set; }

        /// <summary>
        /// 페이지 이름(네임스페이스 포함)
        /// </summary>
        public string PageName { get; set; }

        /// <summary>
        /// 하위 아이템
        /// </summary>
        public ObservableCollection<MenuDataModel> Items { get; set; }

        /// <summary>
        /// 메뉴 포시 여부
        /// </summary>
        public bool IsMenuDisplay { get; set; } = true;

        /// <summary>
        /// 현재 Page이름의 Type을 반환 한다.
        /// </summary>
        /// <returns></returns>
        public Type GetPageType()
        {
            if (string.IsNullOrEmpty(PageName))
                return null;

            var asm = Assembly.GetExecutingAssembly();
            return asm.GetType(PageName);
        }

        /// <summary>
        /// 페이지 Acivator
        /// </summary>
        /// <returns></returns>
        public Page PageActivation(object[] uiParams = null)
        {

            return uiParams == null
                ? (Page)Activator.CreateInstance(GetPageType())
                : (Page)Activator.CreateInstance(GetPageType(), uiParams);
        }
    }
}
