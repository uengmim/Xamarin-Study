// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZPM_F0002" -output "ZPmF0002Proxy.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

using XNSC;
using XNSC.DD;
using XNSC.DD.EX;

namespace NAMHE.Model
{
/// <summary>
    /// ZPMF0002Model(ZPM_F0002) Proxy class
    /// </summary>
    public class ZPMF0002Model
    {
        /// <summary>
        /// E_MSG(eMsg) Field
        /// </summary>
        public System.String E_MSG { get; set; }

        /// <summary>
        /// E_TYPE(eType) Field
        /// </summary>
        public System.String E_TYPE { get; set; }

        /// <summary>
        /// I_AUFNR(iAufnr) Field
        /// </summary>
        public System.String I_AUFNR { get; set; }

        /// <summary>
        /// ITAB_DATA1(iTABDATA1) Field
        /// </summary>
        public ObservableCollection<ZPMS0002Model> ITAB_DATA1
        {
            get;
            set;
        }

        /// <summary>
        /// ITAB_DATA2(iTABDATA2) Field
        /// </summary>
        public ObservableCollection<ZPMS0003Model> ITAB_DATA2
        {
            get;
            set;
        }

        /// <summary>
        /// ITAB_DATA3(iTABDATA3) Field
        /// </summary>
        public ObservableCollection<ZPMS0004Model> ITAB_DATA3
        {
            get;
            set;
        }

        /// <summary>
        /// ITAB_DATA4(iTABDATA4) Field
        /// </summary>
        public ObservableCollection<ZPMS0009Model> ITAB_DATA4
        {
            get;
            set;
        }

        /// <summary>
        /// ITAB_DATA5(iTABDATA5) Field
        /// </summary>
        public ObservableCollection<ZPMT10010Model> ITAB_DATA5
        {
            get;
            set;
        }

        /// <summary>
        /// ITAB_DATA6(iTABDATA6) Field
        /// </summary>
        public ObservableCollection<ZPMT10011Model> ITAB_DATA6
        {
            get;
            set;
        }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZPMS0003Model(ZPMS0003) Proxy class
    /// </summary>
    public class ZPMS0003Model
    {
        /// <summary>
        /// AUFNR(aufnr) Field
        /// </summary>
        public System.String AUFNR { get; set; }

        /// <summary>
        /// KURZTEXT(kurztext) Field
        /// </summary>
        public System.String KURZTEXT { get; set; }

        /// <summary>
        /// ARBEI(arbei) Field
        /// </summary>
        public System.Decimal ARBEI { get; set; }

        /// <summary>
        /// MEINH(meinh) Field
        /// </summary>
        public System.String MEINH { get; set; }

        /// <summary>
        /// ANZZL(anzzl) Field
        /// </summary>
        public System.SByte ANZZL { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }
/// <summary>
    /// ZPMS0004Model(ZPMS0004) Proxy class
    /// </summary>
    public class ZPMS0004Model
    {
        /// <summary>
        /// AUFNR(aufnr) Field
        /// </summary>
        public System.String AUFNR { get; set; }

        /// <summary>
        /// RSNUM(rsnum) Field
        /// </summary>
        public System.String RSNUM { get; set; }

        /// <summary>
        /// WERKS(werks) Field
        /// </summary>
        public System.String WERKS { get; set; }

        /// <summary>
        /// LGORT(lgort) Field
        /// </summary>
        public System.String LGORT { get; set; }

        /// <summary>
        /// LGOBE(lgobe) Field
        /// </summary>
        public System.String LGOBE { get; set; }

        /// <summary>
        /// MATNR(matnr) Field
        /// </summary>
        public System.String MATNR { get; set; }

        /// <summary>
        /// MATNR_DESC(mATNRDesc) Field
        /// </summary>
        public System.String MATNR_DESC { get; set; }

        /// <summary>
        /// VAPLZ(vaplz) Field
        /// </summary>
        public System.String VAPLZ { get; set; }

        /// <summary>
        /// VAPLZ_DESC(vAPLZDesc) Field
        /// </summary>
        public System.String VAPLZ_DESC { get; set; }

        /// <summary>
        /// MEINS(meins) Field
        /// </summary>
        public System.String MEINS { get; set; }

        /// <summary>
        /// BDTER(bdter) Field
        /// </summary>
        public System.DateTime BDTER { get; set; }

        /// <summary>
        /// QTY_REV(qTYRev) Field
        /// </summary>
        public System.Decimal QTY_REV { get; set; }

        /// <summary>
        /// QTY_REQ(qTYReq) Field
        /// </summary>
        public System.Decimal QTY_REQ { get; set; }

        /// <summary>
        /// QTY_OUT(qTYOut) Field
        /// </summary>
        public System.Decimal QTY_OUT { get; set; }

        /// <summary>
        /// QTY_CON(qTYCon) Field
        /// </summary>
        public System.Decimal QTY_CON { get; set; }

        /// <summary>
        /// QTY_REC(qTYRec) Field
        /// </summary>
        public System.Decimal QTY_REC { get; set; }

        /// <summary>
        /// QTY_IEV(qTYIev) Field
        /// </summary>
        public System.Decimal QTY_IEV { get; set; }

        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }
/// <summary>
    /// ZPMS0009Model(ZPMS0009) Proxy class
    /// </summary>
    public class ZPMS0009Model
    {
        /// <summary>
        /// NOTIF_NO(nOTIFNo) Field
        /// </summary>
        public System.String NOTIF_NO { get; set; }

        /// <summary>
        /// POSNR(posnr) Field
        /// </summary>
        public System.String POSNR { get; set; }

        /// <summary>
        /// CAUSE_KEY(cAUSEKey) Field
        /// </summary>
        public System.String CAUSE_KEY { get; set; }

        /// <summary>
        /// KATALOGART(katalogart) Field
        /// </summary>
        public System.String KATALOGART { get; set; }

        /// <summary>
        /// CODEGRUPPE(codegruppe) Field
        /// </summary>
        public System.String CODEGRUPPE { get; set; }

        /// <summary>
        /// KURZTEXT_GR(kURZTEXTGr) Field
        /// </summary>
        public System.String KURZTEXT_GR { get; set; }

        /// <summary>
        /// CODE(code) Field
        /// </summary>
        public System.String CODE { get; set; }

        /// <summary>
        /// KURZTEXT_CODE(kURZTEXTCode) Field
        /// </summary>
        public System.String KURZTEXT_CODE { get; set; }

        /// <summary>
        /// FETXT(fetxt) Field
        /// </summary>
        public System.String FETXT { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }
/// <summary>
    /// ZPMT10010Model(ZPMT10010) Proxy class
    /// </summary>
    public class ZPMT10010Model
    {
        /// <summary>
        /// MANDT(mandt) Field
        /// </summary>
        public System.String MANDT { get; set; }

        /// <summary>
        /// AUFNR(aufnr) Field
        /// </summary>
        public System.String AUFNR { get; set; }

        /// <summary>
        /// PAY_CNT(pAYCnt) Field
        /// </summary>
        public System.String PAY_CNT { get; set; }

        /// <summary>
        /// REDAT(redat) Field
        /// </summary>
        public System.DateTime REDAT { get; set; }

        /// <summary>
        /// CODAT(codat) Field
        /// </summary>
        public System.DateTime CODAT { get; set; }

        /// <summary>
        /// BUDAT(budat) Field
        /// </summary>
        public System.DateTime BUDAT { get; set; }

        /// <summary>
        /// EBELN(ebeln) Field
        /// </summary>
        public System.String EBELN { get; set; }

        /// <summary>
        /// BELNR(belnr) Field
        /// </summary>
        public System.String BELNR { get; set; }

        /// <summary>
        /// LIFNR(lifnr) Field
        /// </summary>
        public System.String LIFNR { get; set; }

        /// <summary>
        /// GJAHR(gjahr) Field
        /// </summary>
        public System.String GJAHR { get; set; }

        /// <summary>
        /// STAT(stat) Field
        /// </summary>
        public System.String STAT { get; set; }

        /// <summary>
        /// ERNAM(ernam) Field
        /// </summary>
        public System.String ERNAM { get; set; }

        /// <summary>
        /// ERDAT(erdat) Field
        /// </summary>
        public System.DateTime ERDAT { get; set; }

        /// <summary>
        /// ERZET(erzet) Field
        /// </summary>
        public System.TimeSpan ERZET { get; set; }

        /// <summary>
        /// AENAM(aenam) Field
        /// </summary>
        public System.String AENAM { get; set; }

        /// <summary>
        /// AEDAT(aedat) Field
        /// </summary>
        public System.DateTime AEDAT { get; set; }

        /// <summary>
        /// AEZET(aezet) Field
        /// </summary>
        public System.TimeSpan AEZET { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }
/// <summary>
    /// ZPMT10011Model(ZPMT10011) Proxy class
    /// </summary>
    public class ZPMT10011Model
    {
        /// <summary>
        /// MANDT(mandt) Field
        /// </summary>
        public System.String MANDT { get; set; }

        /// <summary>
        /// AUFNR(aufnr) Field
        /// </summary>
        public System.String AUFNR { get; set; }

        /// <summary>
        /// PAY_CNT(pAYCnt) Field
        /// </summary>
        public System.String PAY_CNT { get; set; }

        /// <summary>
        /// PAYITEM(payitem) Field
        /// </summary>
        public System.String PAYITEM { get; set; }

        /// <summary>
        /// QTY_REQ(qTYReq) Field
        /// </summary>
        public System.String QTY_REQ { get; set; }

        /// <summary>
        /// QTY_CON(qTYCon) Field
        /// </summary>
        public System.String QTY_CON { get; set; }

        /// <summary>
        /// ERNAM(ernam) Field
        /// </summary>
        public System.String ERNAM { get; set; }

        /// <summary>
        /// ERDAT(erdat) Field
        /// </summary>
        public System.DateTime ERDAT { get; set; }

        /// <summary>
        /// ERZET(erzet) Field
        /// </summary>
        public System.TimeSpan ERZET { get; set; }

        /// <summary>
        /// AENAM(aenam) Field
        /// </summary>
        public System.String AENAM { get; set; }

        /// <summary>
        /// AEDAT(aedat) Field
        /// </summary>
        public System.DateTime AEDAT { get; set; }

        /// <summary>
        /// AEZET(aezet) Field
        /// </summary>
        public System.TimeSpan AEZET { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZPMF0002Model(ZPM_F0002) Proxy List Class
    /// </summary>    
    public class ZPMF0002ModelList  : ObservableCollection<ZPMF0002Model>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZPMF0002ModelList()
        {
            return;
        }
    }

}