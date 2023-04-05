using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace NMAP.Models.MFMOU
{
    /// <summary>
    /// W/O 자재목록 모델
    /// </summary>
    public class WOMatMedel : INotifyPropertyChanged
    {
        private string aufnr;
        private string rsnum;
        private string werks;
        private string lgort;
        private string lgobe;
        private string matnr;
        private string matnr_desc;
        private string vaplz;
        private string vaplz_desc;
        private string meins;
        private DateTime bdter;
        private decimal qty_rev;
        private decimal qty_req;
        private decimal qty_out;
        private decimal qty_con;
        private decimal qty_rec;
        private decimal qty_iev;
        private decimal qty_input;
        private bool haserror;
        private string errortext;

        /// <summary>
        /// 오더번호
        /// </summary>
        public string AUFNR { get { return aufnr; } set { aufnr = value; OnPropertyChanged(nameof(AUFNR)); } }

        /// <summary>
        /// 예약번호
        /// </summary>
        public string RSNUM { get { return rsnum; } set { rsnum = value; OnPropertyChanged(nameof(RSNUM)); } }

        /// <summary>
        /// 플랜트
        /// </summary>
        public string WERKS { get { return werks; } set { werks = value; OnPropertyChanged(nameof(WERKS)); } }

        /// <summary>
        /// 저장위치
        /// </summary>
        public string LGORT { get { return lgort; } set { lgort = value; OnPropertyChanged(nameof(LGORT)); } }

        /// <summary>
        /// 저장위치명
        /// </summary>
        public string LGOBE { get { return lgobe; } set { lgobe = value; OnPropertyChanged(nameof(LGOBE)); } }

        /// <summary>
        /// 자재번호
        /// </summary>
        public string MATNR { get { return matnr; } set { matnr = value; OnPropertyChanged(nameof(MATNR)); } }

        /// <summary>
        /// 자재명
        /// </summary>
        public string MATNR_DESC { get { return matnr_desc; } set { matnr_desc = value; OnPropertyChanged(nameof(MATNR_DESC)); } }

        /// <summary>
        /// 작업장
        /// </summary>
        public string VAPLZ { get { return vaplz; } set { vaplz = value; OnPropertyChanged(nameof(VAPLZ)); } }

        /// <summary>
        /// 작업장명
        /// </summary>
        public string VAPLZ_DESC { get { return vaplz_desc; } set { vaplz_desc = value; OnPropertyChanged(nameof(VAPLZ_DESC)); } }

        /// <summary>
        /// 단위
        /// </summary>
        public string MEINS { get { return meins; } set { meins = value; OnPropertyChanged(nameof(MEINS)); } }

        /// <summary>
        /// 요청일
        /// </summary>
        public DateTime BDTER { get { return bdter; } set { bdter = value; OnPropertyChanged(nameof(BDTER)); } }

        /// <summary>
        /// 예약수량
        /// </summary>
        public decimal QTY_REV { get { return qty_rev; } set { qty_rev = value; OnPropertyChanged(nameof(QTY_REV)); } }

        /// <summary>
        /// 청구수량
        /// </summary>
        public decimal QTY_REQ { get { return qty_req; } set { qty_req = value; OnPropertyChanged(nameof(QTY_REQ)); } }

        /// <summary>
        /// 출고수량
        /// </summary>
        public decimal QTY_OUT { get { return qty_out; } set { qty_out = value; OnPropertyChanged(nameof(QTY_OUT)); } }

        /// <summary>
        /// 사용수량
        /// </summary>
        public decimal QTY_CON { get { return qty_con; } set { qty_con = value; OnPropertyChanged(nameof(QTY_CON)); } }

        /// <summary>
        /// 반납수량
        /// </summary>
        public decimal QTY_REC { get { return qty_rec; } set { qty_rec = value; OnPropertyChanged(nameof(QTY_REC)); } }

        /// <summary>
        /// 재고수량
        /// </summary>
        public decimal QTY_IEV { get { return qty_iev; } set { qty_iev = value; OnPropertyChanged(nameof(QTY_IEV)); } }


        /// <summary>
        /// 화면입력수량
        /// </summary>
        public decimal QTY_INPUT { get { return qty_input; } set { qty_input = value; OnPropertyChanged(nameof(QTY_INPUT)); } }

        /// <summary>
        /// 수량입력 오류 여부
        /// </summary>
        public bool HasError { get { return haserror; } set { haserror = value; OnPropertyChanged(nameof(HasError)); } }

        /// <summary>
        /// 수량입력 오류 텍스트
        /// </summary>
        public string ErrorText { get { return errortext; } set { errortext = value; OnPropertyChanged(nameof(ErrorText)); } }


        public WOMatMedel()
        {

        }

        public WOMatMedel(string aufnr, string rsnum, string werks, string lgort, string lgobe, string matnr, string mat_desc, string vaplz, string vaplz_desc,
            string meins, DateTime bdter, decimal qty_rev, decimal qty_req, decimal qty_out, decimal qty_con, decimal qty_rec, decimal qty_iev, decimal qty_input) : this()
        {
            AUFNR = aufnr;
            RSNUM = rsnum;
            WERKS = werks;
            LGORT = lgort;
            LGOBE = lgobe;
            MATNR = matnr;
            MATNR_DESC = mat_desc;
            VAPLZ = vaplz;
            VAPLZ_DESC = vaplz_desc;
            MEINS = meins;
            BDTER = bdter;
            QTY_REV = qty_rev;
            QTY_REQ = qty_req;
            QTY_OUT = qty_out;
            QTY_CON = qty_con;
            QTY_REC = qty_rec;
            QTY_IEV = qty_iev;
            QTY_INPUT = qty_input;
        }

        public ObservableCollection<WOMatMedel> getData(ObservableCollection<WOMatMedel> CardviewDataModel)
        {
            CardviewDataModel.Add(new WOMatMedel("4000102", "216", "1000", "4201", "저장품공정(Shop)창고", "ERSA-001", "ERSA-001", "PM400", "계전팀", "EA", new DateTime(2022, 8, 29), 5, 5, 5, 0, 5, 0, 0));
            CardviewDataModel.Add(new WOMatMedel("4000102", "216", "1000", "4000", "저장품 창고(공통)", "M1300CH-014", "ELEVATOR BUCKET CHAIN", "PM400", "계전팀", "LK", new DateTime(2022, 8, 29), 10, 10, 10, 5, 5, 5, 0));
            return CardviewDataModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, args);
        }
    }
}
