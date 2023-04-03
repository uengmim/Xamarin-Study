using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace NMAP.Models.MFMIN
{
    public class WOPMTAChartModel : ObservableObject
    {
        private string point_desc;
        private IList<WOPMTAListModel> values;

        /// <summary>
        /// 측정위치내역
        /// </summary>
        public string Point_desc { get => point_desc; set => point_desc = value; }
        public IList<WOPMTAListModel> Values { get => values; set => values = value; }

        public WOPMTAChartModel()
        {

        }

        public WOPMTAChartModel(string point_desc, IList<WOPMTAListModel> values) : this()
        {
            Point_desc = point_desc;
            Values = values;
        }

        public ObservableCollection<WOPMTAChartModel> getData(ObservableCollection<WOPMTAChartModel> model)
        {
            model.Clear();
            var condata = new WOPMTAListModel();
            model.Add(new WOPMTAChartModel("WEST/Left-내역", condata.getData(new ObservableCollection<WOPMTAListModel>(), "일별")));
            return model;
        }
    }
}
