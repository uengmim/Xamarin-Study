// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZMM_311RESERV_INQUIRY" -output "ZMM311RESERVInquiry.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

using XNSC;
using XNSC.DD;
using XNSC.DD.EX;

namespace NAMHE.Model
{
    /// <summary>
    /// ZMM311RESERVInquiryModel(ZMM_311RESERV_INQUIRY) Proxy class
    /// </summary>
    public class ZMM311RESERVInquiryModel
    {
       
        /// <summary>
        /// I_RSNUM(iRsnum) Field
        /// </summary>
        public String I_RSNUM { get; set; }

       

    }

    /// <summary>
    /// ZMMS9000Model(ZMMS9000) Proxy class
    /// </summary>
    public class ZMMS9000Model
    {
        /// <summary>
        /// TYPE(type) Field
        /// </summary>
        public System.String TYPE { get; set; }

        /// <summary>
        /// MESSAGE(message) Field
        /// </summary>
        public System.String MESSAGE { get; set; }


    }
    /// <summary>
    /// ZMMS3070Model(ZMMS3070) Proxy class
    /// </summary>
    public class ZMMS3070Model
    {

        /// <summary>
        /// RSNUM(rsnum) Field
        /// </summary>
        public String RSNUM { get; set; }

        /// <summary>
        /// RSPOS(rspos) Field
        /// </summary>
        public String RSPOS { get; set; }

        /// <summary>
        /// MATNR(matnr) Field
        /// </summary>
        public String MATNR { get; set; }

        /// <summary>
        /// MAKTX(maktx) Field
        /// </summary>
        public String MAKTX { get; set; }

        /// <summary>
        /// BDMNG(bdmng) Field
        /// </summary>
        public String BDMNG { get; set; }

        /// <summary>
        /// MEINS(meins) Field
        /// </summary>
        public String MEINS { get; set; }

        /// <summary>
        /// LGORT(lgort) Field
        /// </summary>
        public String LGORT { get; set; }

        /// <summary>
        /// UMLGO(umlgo) Field
        /// </summary>
        public String UMLGO { get; set; }

        /// <summary>
        /// ZZBIN(zzbin) Field
        /// </summary>
        public String ZZBIN { get; set; }

        /// <summary>
        /// ENMNG(enmng) Field
        /// </summary>
        public String ENMNG { get; set; }

        /// <summary>
        /// KZEAR(kzear) Field
        /// </summary>
        public String KZEAR { get; set; }

        /// <summary>
        /// LABST(labst) Field
        /// </summary>
        public String LABST { get; set; }


        /// <summary>
        /// 출고수량 입력
        /// </summary>
        public String MENGE { get; set; }

        /// <summary>
        /// 수량입력 오류 여부
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// 수량입력 오류 텍스트
        /// </summary>
        public string ErrorText { get; set; }


        public bool IsChecked { get; set; }



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
    /// ZMM311RESERVInquiryModel(ZMM_311RESERV_INQUIRY) Proxy List Class
    /// </summary>    
    public class ZMM311RESERVInquiryModelList : List<ZMM311RESERVInquiryModel>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZMM311RESERVInquiryModelList()
        {
            return;
        }
    }

}