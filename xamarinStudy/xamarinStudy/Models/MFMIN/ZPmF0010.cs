// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZPM_F0010" -output "ZPmF0010.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

using XNSC;
using XNSC.DD;
using XNSC.DD.EX;

namespace NAMHE.Model
{
/// <summary>
    /// ZPMF0010Model(ZPM_F0010) Proxy class
    /// </summary>
    public class ZPMF0010Model
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
        /// I_AUART(iAuart) Field
        /// </summary>
        public System.String I_AUART { get; set; }

        /// <summary>
        /// I_AUFNR(iAufnr) Field
        /// </summary>
        public System.String I_AUFNR { get; set; }

        /// <summary>
        /// I_EQUNR(iEqunr) Field
        /// </summary>
        public System.String I_EQUNR { get; set; }

        /// <summary>
        /// I_IDAT1_E(iIDAT1E) Field
        /// </summary>
        public System.DateTime I_IDAT1_E { get; set; }

        /// <summary>
        /// I_IDAT1_S(iIDAT1S) Field
        /// </summary>
        public System.DateTime I_IDAT1_S { get; set; }

        /// <summary>
        /// I_INGPR(iIngpr) Field
        /// </summary>
        public System.String I_INGPR { get; set; }

        /// <summary>
        /// I_STAT(iStat) Field
        /// </summary>
        public System.String I_STAT { get; set; }

        /// <summary>
        /// I_VAPLZ(iVaplz) Field
        /// </summary>
        public System.String I_VAPLZ { get; set; }

        /// <summary>
        /// I_WERKS(iWerks) Field
        /// </summary>
        public System.String I_WERKS { get; set; }

        /// <summary>
        /// ITAB_DATA(iTABData) Field
        /// </summary>
        public IList<ZPMS0002Model> ITAB_DATA
        {
            get;
            set;
        }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }
    /*
/// <summary>
    /// ZPMS0002Model(ZPMS0002) Proxy class
    /// </summary>
    public class ZPMS0002Model
    {
        /// <summary>
        /// AUFNR(aufnr) Field
        /// </summary>
        public System.String AUFNR { get; set; }

        /// <summary>
        /// AUART(auart) Field
        /// </summary>
        public System.String AUART { get; set; }

        /// <summary>
        /// KTEXT(ktext) Field
        /// </summary>
        public System.String KTEXT { get; set; }

        /// <summary>
        /// BUKRS(bukrs) Field
        /// </summary>
        public System.String BUKRS { get; set; }

        /// <summary>
        /// WERKS(werks) Field
        /// </summary>
        public System.String WERKS { get; set; }

        /// <summary>
        /// WERKS_DESC(wERKSDesc) Field
        /// </summary>
        public System.String WERKS_DESC { get; set; }

        /// <summary>
        /// GSBER(gsber) Field
        /// </summary>
        public System.String GSBER { get; set; }

        /// <summary>
        /// GSBER_DESC(gSBERDesc) Field
        /// </summary>
        public System.String GSBER_DESC { get; set; }

        /// <summary>
        /// KOKRS(kokrs) Field
        /// </summary>
        public System.String KOKRS { get; set; }

        /// <summary>
        /// STAT(stat) Field
        /// </summary>
        public System.String STAT { get; set; }

        /// <summary>
        /// STAT1(sTAT1) Field
        /// </summary>
        public System.String STAT1 { get; set; }

        /// <summary>
        /// LOEKZ(loekz) Field
        /// </summary>
        public System.String LOEKZ { get; set; }

        /// <summary>
        /// INGPR(ingpr) Field
        /// </summary>
        public System.String INGPR { get; set; }

        /// <summary>
        /// INGPR_DESC(iNGPRDesc) Field
        /// </summary>
        public System.String INGPR_DESC { get; set; }

        /// <summary>
        /// VAPLZ(vaplz) Field
        /// </summary>
        public System.String VAPLZ { get; set; }

        /// <summary>
        /// VAPLZ_DESC(vAPLZDesc) Field
        /// </summary>
        public System.String VAPLZ_DESC { get; set; }

        /// <summary>
        /// IDAT1(iDAT1) Field
        /// </summary>
        public System.DateTime IDAT1 { get; set; }

        /// <summary>
        /// GSTRP(gstrp) Field
        /// </summary>
        public System.DateTime GSTRP { get; set; }

        /// <summary>
        /// GLTRP(gltrp) Field
        /// </summary>
        public System.DateTime GLTRP { get; set; }

        /// <summary>
        /// QMNUM(qmnum) Field
        /// </summary>
        public System.String QMNUM { get; set; }

        /// <summary>
        /// EQUNR(equnr) Field
        /// </summary>
        public System.String EQUNR { get; set; }

        /// <summary>
        /// EQUNR_DESC(eQUNRDesc) Field
        /// </summary>
        public System.String EQUNR_DESC { get; set; }

        /// <summary>
        /// TPLNR(tplnr) Field
        /// </summary>
        public System.String TPLNR { get; set; }

        /// <summary>
        /// TPLNR_DESC(tPLNRDesc) Field
        /// </summary>
        public System.String TPLNR_DESC { get; set; }

        /// <summary>
        /// PARNR(parnr) Field
        /// </summary>
        public System.String PARNR { get; set; }

        /// <summary>
        /// PARNR_DESC(pARNRDesc) Field
        /// </summary>
        public System.String PARNR_DESC { get; set; }

        /// <summary>
        /// ERNAM(ernam) Field
        /// </summary>
        public System.String ERNAM { get; set; }

        /// <summary>
        /// ERNAM_DESC(eRNAMDesc) Field
        /// </summary>
        public System.String ERNAM_DESC { get; set; }

        /// <summary>
        /// ERDAT(erdat) Field
        /// </summary>
        public System.DateTime ERDAT { get; set; }

        /// <summary>
        /// AENAM(aenam) Field
        /// </summary>
        public System.String AENAM { get; set; }

        /// <summary>
        /// AENAM_DESC(aENAMDesc) Field
        /// </summary>
        public System.String AENAM_DESC { get; set; }

        /// <summary>
        /// AEDAT(aedat) Field
        /// </summary>
        public System.DateTime AEDAT { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }
    */
/// <summary>
    /// ZPMF0010Model(ZPM_F0010) Proxy List Class
    /// </summary>    
    public class ZPMF0010ModelList  : List<ZPMF0010Model>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZPMF0010ModelList()
        {
            return;
        }
    }

}