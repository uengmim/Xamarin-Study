using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace NMAP.Models.MFMIN
{
    public class WOPMListModel : ObservableObject
    {
        private string aufnr;
        private string equnr;
        private string equnr_desc;
        private int seq;
        private string point;
        private string point_desc;
        private decimal target;
        private decimal minval;
        private decimal maxval;
        private decimal input_val;
        private string meins;
        private string stat;
        private DateTime? input_date;
        private List<StatComboBoxModel> statComboBoxData = new List<StatComboBoxModel>();

        /// <summary>
        /// 오더번호
        /// </summary>
        public string Aufnr { get => aufnr; set => aufnr = value; }

        /// <summary>
        /// 설비번호
        /// </summary>
        public string Equnr { get => equnr; set => equnr = value; }

        /// <summary>
        /// 설비명
        /// </summary>
        public string Equnr_desc { get => equnr_desc; set => equnr_desc = value; }
        
        /// <summary>
        /// 측정지점
        /// </summary>
        public int Seq { get => seq; set => seq = value; }

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

        /// <summary>
        /// 평가 콤보박스 데이터
        /// </summary>
        public List<StatComboBoxModel> StatComboBoxData { get => statComboBoxData; set => statComboBoxData = value; }

        public WOPMListModel()
        {

        }

        public WOPMListModel(string aufnr, string equnr, string equnr_desc, int seq, string point, string point_desc, 
            decimal target, decimal minval, decimal maxval, decimal input_val, string meins, string stat, DateTime? input_date) : this()
        {
            Aufnr = aufnr; ;
            Equnr = equnr;
            Equnr_desc = equnr_desc;
            Seq = seq;
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
            StatComboBoxData.Add(new StatComboBoxModel("A", "합격"));
            StatComboBoxData.Add(new StatComboBoxModel("B", "불합격"));

            OnPropertyChanged(nameof(StatComboBoxData));
        }

        public class StatComboBoxModel
        {
            private string code;
            private string name;

            public string Code { get => code; set => code = value; }
            public string Name { get => name; set => name = value; }

            public StatComboBoxModel(string code, string name)
            {
                Code = code;
                Name = name;
            }
        }

        public ObservableCollection<WOPMListModel> getData(ObservableCollection<WOPMListModel> model)
        {
            model.Clear();
            model.Add(new WOPMListModel("4000192", "421-R-608", "ROTARY GRANULATOR", 1, "WEST/LEFT", "WEST/Left-내역", decimal.Parse("29.8"), decimal.Parse("10.0"), decimal.Parse("30.0"), 0, "", "", null));
            model.Add(new WOPMListModel("4000192", "421-R-608", "ROTARY GRANULATOR", 2, "EAST/LEFT", "EAST/Left-내역", decimal.Parse("29.4"), decimal.Parse("10.0"), decimal.Parse("100.0"), 0, "", "", null));
            model.Add(new WOPMListModel("4000192", "421-R-608", "ROTARY GRANULATOR", 3, "WEST/MIDDLE", "WEST/Middle-내역", decimal.Parse("30.0"), decimal.Parse("20.0"), decimal.Parse("40.0"), 0, "", "", null));
            model.Add(new WOPMListModel("4000192", "421-R-608", "ROTARY GRANULATOR", 4, "EAST/MIDDLE", "EAST/Middle-내역", decimal.Parse("30.0"), decimal.Parse("20.0"), decimal.Parse("40.0"), 0, "", "", null));
            return model;
        }
    }
}
