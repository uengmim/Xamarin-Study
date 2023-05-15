using DevExpress.XamarinForms.DataGrid;
using NMAP.ViewModels;
using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NMAP.Utils
{

    public class MenuListTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HasSubMenu { get; set; }

        public DataTemplate NoneSubMenu { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            MenuDataModel target = item as MenuDataModel;

            return (target?.Items?.Count ?? 0) > 0 ? HasSubMenu : NoneSubMenu;
        }
    }
}
