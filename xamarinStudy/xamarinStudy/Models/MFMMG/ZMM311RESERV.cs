// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZMM_311RESERV_GI" -output "ZMM311RESERV.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

using XNSC;
using XNSC.DD;
using XNSC.DD.EX;

namespace NAMHE.Model
{
/// <summary>
    /// ZMM311RESERVGiModel(ZMM_311RESERV_GI) Proxy class
    /// </summary>
    public class ZMM311RESERVGiModel
    {
        /// <summary>
        /// ES_RETURN(eSReturn) Field
        /// </summary>
        public ZMMS9000Model ES_RETURN { get; set; }

        /// <summary>
        /// CT_LIST(cTList) Field
        /// </summary>
        public IList<ZMMS3080Model> CT_LIST
        {
            get;
            set;
        }

   
    }

    /// <summary>
    /// ZMMS3080Model(ZMMS3080) Proxy class
    /// </summary>
    public class ZMMS3080Model : INotifyPropertyChanged
    {
        private string rsnum;
        private string rspos;
        private string werks;
        private string lgort;
        private string umlgo;
        private string matnr;
        private string menge;
        private string meins;
        private string budat;
        private bool haserror;
        private string errortext;
        private string mblnr;
        private string zeile;
        private string type;
        private string message;

        /// <summary>
        /// 요청번호
        /// </summary>
        public String RSNUM { get { return rsnum; } set { rsnum = value; OnPropertyChanged(nameof(RSNUM)); } }

        /// <summary>
        /// 항번
        /// </summary>
        public String RSPOS { get { return rspos; } set { rspos = value; OnPropertyChanged(nameof(RSPOS)); } }

        /// <summary>
        /// 플랜트
        /// </summary>
        public String WERKS { get { return werks; } set { werks = value; OnPropertyChanged(nameof(WERKS)); } }

        /// <summary>
        /// 출고창고
        /// </summary>
        public String LGORT { get { return lgort; } set { lgort = value; OnPropertyChanged(nameof(LGORT)); } }

        /// <summary>
        /// 입고창고
        /// </summary>
        public String UMLGO { get { return umlgo; } set { umlgo = value; OnPropertyChanged(nameof(UMLGO)); } }

        /// <summary>
        /// 자재코드
        /// </summary>
        public String MATNR { get { return matnr; } set { matnr = value; OnPropertyChanged(nameof(MATNR)); } }

        /// <summary>
        /// 출고수량
        /// </summary>
        public String MENGE { get { return menge; } set { menge = value; OnPropertyChanged(nameof(MENGE)); } }

        /// <summary>
        /// 단위
        /// </summary>
        public System.String MEINS { get { return meins; } set { meins = value; OnPropertyChanged(nameof(MEINS)); } }

        /// <summary>
        /// 처리일자
        /// </summary>
        public System.String BUDAT { get { return budat; } set { budat = value; OnPropertyChanged(nameof(BUDAT)); } }

        public System.String MBLNR { get { return mblnr; } set { mblnr = value; OnPropertyChanged(nameof(MBLNR)); } }
        public System.String ZEILE { get { return zeile; } set { zeile = value; OnPropertyChanged(nameof(ZEILE)); } }
        public System.String TYPE { get { return type; } set { type = value; OnPropertyChanged(nameof(TYPE)); } }
        public System.String MESSAGE { get { return message; } set { message = value; OnPropertyChanged(nameof(MESSAGE)); } }


        public ZMMS3080Model(string rsnum, string rspos, string werks, string lgort, string umlgo, string matnr, string menge
                            , string meins, string budat, string mblnr, string zeile, string type, string message) : this()
        {
            RSNUM = rsnum;
            RSPOS = rspos;
            WERKS = werks;
            LGORT = lgort;
            UMLGO = umlgo;
            MATNR = matnr;
            MENGE = menge;
            MEINS = meins;
            BUDAT = budat;
            MBLNR = mblnr; 
            ZEILE = zeile;  
            TYPE = type;
            MESSAGE = message;

        }

        public ZMMS3080Model()
        {
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

    /// <summary>
    /// ZMM311RESERVGiModel(ZMM_311RESERV_GI) Proxy List Class
    /// </summary>    
    public class ZMM311RESERVGiModelList  : List<ZMM311RESERVGiModel>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZMM311RESERVGiModelList()
        {
            return;
        }


    }

}