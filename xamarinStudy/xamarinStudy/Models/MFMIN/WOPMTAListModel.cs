using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace NMAP.Models.MFMIN
{
    public class WOPMTAListModel : ObservableObject
    {
        private string point;
        private string point_desc;
        private decimal target;
        private decimal minval;
        private decimal maxval;
        private decimal input_val;
        private string meins;
        private string stat;
        private DateTime? input_date;

        /// <summary>
        /// 측정위치
        /// </summary>
        public string Point { get => point; set => point = value; }

        /// <summary>
        /// 측정위치내역
        /// </summary>
        public string Point_desc { get => point_desc; set => point_desc = value; }

        /// <summary>
        /// 목표값
        /// </summary>
        public decimal Target { get => target; set => target = value; }

        /// <summary>
        /// 하한값
        /// </summary>
        public decimal Minval { get => minval; set => minval = value; }

        /// <summary>
        /// 상한값
        /// </summary>
        public decimal Maxval { get => maxval; set => maxval = value; }

        /// <summary>
        /// 측정값
        /// </summary>
        public decimal Input_val { get => input_val; set => input_val = value; }

        /// <summary>
        /// 특성단위
        /// </summary>
        public string Meins { get => meins; set => meins = value; }

        /// <summary>
        /// 평가
        /// </summary>
        public string Stat { get => stat; set => stat = value; }

        /// <summary>
        /// 측정일
        /// </summary>
        public DateTime? Input_date { get => input_date; set => input_date = value; }

        public WOPMTAListModel()
        {

        }

        public WOPMTAListModel(string point, string point_desc, 
            decimal target, decimal minval, decimal maxval, decimal input_val, string meins, string stat, DateTime? input_date) : this()
        {
            Point = point;
            Point_desc = point_desc;
            Target = target;
            Minval = minval;
            Maxval = maxval;
            Input_val = input_val;
            Meins = meins;
            Stat = stat;
            if(input_date != null)
                Input_date = input_date;
        }

        public ObservableCollection<WOPMTAListModel> getData(ObservableCollection<WOPMTAListModel> model, string AnalType)
        {
            model.Clear();
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("12"), "", "합격", new DateTime(2022, 8, 26)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("27"), "", "합격", new DateTime(2022, 8, 27)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("18"), "", "합격", new DateTime(2022, 8, 28)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("9"), "", "합격", new DateTime(2022, 8, 29)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("32"), "", "합격", new DateTime(2022, 8, 30)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("29"), "", "합격", new DateTime(2022, 8, 31)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("20"), "", "합격", new DateTime(2022, 9, 1)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("30"), "", "합격", new DateTime(2022, 9, 2)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("23"), "", "합격", new DateTime(2022, 9, 3)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("28"), "", "합격", new DateTime(2022, 9, 4)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("11"), "", "합격", new DateTime(2022, 9, 5)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("18"), "", "합격", new DateTime(2022, 9, 6)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("26"), "", "합격", new DateTime(2022, 9, 7)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("15"), "", "합격", new DateTime(2022, 9, 8)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("17"), "", "합격", new DateTime(2022, 9, 9)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("18"), "", "합격", new DateTime(2022, 9, 10)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("11"), "", "합격", new DateTime(2022, 9, 11)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("11"), "", "합격", new DateTime(2022, 9, 12)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("25"), "", "합격", new DateTime(2022, 9, 13)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("28"), "", "합격", new DateTime(2022, 9, 14)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("11"), "", "합격", new DateTime(2022, 9, 15)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("24"), "", "합격", new DateTime(2022, 9, 16)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("29"), "", "합격", new DateTime(2022, 9, 17)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("29"), "", "합격", new DateTime(2022, 9, 18)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("10"), "", "합격", new DateTime(2022, 9, 19)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("9"), "", "합격", new DateTime(2022, 9, 20)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("25"), "", "합격", new DateTime(2022, 9, 21)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("28"), "", "합격", new DateTime(2022, 9, 22)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("25"), "", "합격", new DateTime(2022, 9, 23)));
            model.Add(new WOPMTAListModel("WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10"), decimal.Parse("30"), decimal.Parse("16"), "", "합격", new DateTime(2022, 9, 24)));

            return model;
        }
    }
}
