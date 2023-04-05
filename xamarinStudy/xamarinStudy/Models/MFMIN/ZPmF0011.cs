// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZPM_F0011" -output "ZPmF0011.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZPMF0011Model(ZPM_F0011) Proxy class
    /// </summary>
    public class ZPMF0011Model
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
        /// ITAB_DATA(iTABData) Field
        /// </summary>
        public IList<ZPMS0011Model> ITAB_DATA
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
    /// ZPMS0011Model(ZPMS0011) Proxy class
    /// </summary>
    public class ZPMS0011Model
    {
        /// <summary>
        /// SEQ2(sEQ2) Field
        /// </summary>
        public System.String SEQ2 { get; set; }

        /// <summary>
        /// WERKS(werks) Field
        /// </summary>
        public System.String WERKS { get; set; }

        /// <summary>
        /// AUFNR(aufnr) Field
        /// </summary>
        public System.String AUFNR { get; set; }

        /// <summary>
        /// POINT(point) Field
        /// </summary>
        public System.String POINT { get; set; }

        /// <summary>
        /// KTEXT(ktext) Field
        /// </summary>
        public System.String KTEXT { get; set; }

        /// <summary>
        /// VAPLZ(vaplz) Field
        /// </summary>
        public System.String VAPLZ { get; set; }

        /// <summary>
        /// GSTRS(gstrs) Field
        /// </summary>
        public System.DateTime GSTRS { get; set; }

        /// <summary>
        /// GLTRS(gltrs) Field
        /// </summary>
        public System.DateTime GLTRS { get; set; }

        /// <summary>
        /// GSUZP(gsuzp) Field
        /// </summary>
        public System.TimeSpan GSUZP { get; set; }

        /// <summary>
        /// GLUZP(gluzp) Field
        /// </summary>
        public System.TimeSpan GLUZP { get; set; }

        /// <summary>
        /// RUECK(rueck) Field
        /// </summary>
        public System.String RUECK { get; set; }

        /// <summary>
        /// TPLNR(tplnr) Field
        /// </summary>
        public System.String TPLNR { get; set; }

        /// <summary>
        /// PLTXT(pltxt) Field
        /// </summary>
        public System.String PLTXT { get; set; }

        /// <summary>
        /// EQUNR(equnr) Field
        /// </summary>
        public System.String EQUNR { get; set; }

        /// <summary>
        /// EQKTX(eqktx) Field
        /// </summary>
        public System.String EQKTX { get; set; }

        /// <summary>
        /// VORNR(vornr) Field
        /// </summary>
        public System.String VORNR { get; set; }

        /// <summary>
        /// LTXA1(lTXA1) Field
        /// </summary>
        public System.String LTXA1 { get; set; }

        /// <summary>
        /// PSORT(psort) Field
        /// </summary>
        public System.String PSORT { get; set; }

        /// <summary>
        /// PTTXT(pttxt) Field
        /// </summary>
        public System.String PTTXT { get; set; }

        /// <summary>
        /// MSEHI(msehi) Field
        /// </summary>
        public System.String MSEHI { get; set; }

        /// <summary>
        /// ILART(ilart) Field
        /// </summary>
        public System.String ILART { get; set; }

        /// <summary>
        /// DESIR(desir) Field
        /// </summary>
        public System.String DESIR { get; set; }

        /// <summary>
        /// MRMAX(mrmax) Field
        /// </summary>
        public System.String MRMAX { get; set; }

        /// <summary>
        /// MRMIN(mrmin) Field
        /// </summary>
        public System.String MRMIN { get; set; }

        /// <summary>
        /// MSGRP(msgrp) Field
        /// </summary>
        public System.String MSGRP { get; set; }

        /// <summary>
        /// WARPL(warpl) Field
        /// </summary>
        public System.String WARPL { get; set; }

        /// <summary>
        /// TXT04(tXT04) Field
        /// </summary>
        public System.String TXT04 { get; set; }

        /// <summary>
        /// MRNGU(mrngu) Field
        /// </summary>
        public System.String MRNGU { get; set; }

        /// <summary>
        /// DECIM(decim) Field
        /// </summary>
        public System.Int16 DECIM { get; set; }

        /// <summary>
        /// EXPON(expon) Field
        /// </summary>
        public System.Int16 EXPON { get; set; }

        /// <summary>
        /// MRMAXI(mrmaxi) Field
        /// </summary>
        public System.String MRMAXI { get; set; }

        /// <summary>
        /// MRMINI(mrmini) Field
        /// </summary>
        public System.String MRMINI { get; set; }

        /// <summary>
        /// DESIRI(desiri) Field
        /// </summary>
        public System.String DESIRI { get; set; }

        /// <summary>
        /// MDOCM(mdocm) Field
        /// </summary>
        public System.String MDOCM { get; set; }

        /// <summary>
        /// RECDC(recdc) Field
        /// </summary>
        public System.String RECDC { get; set; }

        /// <summary>
        /// UNITC(unitc) Field
        /// </summary>
        public System.String UNITC { get; set; }

        /// <summary>
        /// VLCOD(vlcod) Field
        /// </summary>
        public System.String VLCOD { get; set; }

        /// <summary>
        /// IDATE(idate) Field
        /// </summary>
        public System.DateTime IDATE { get; set; }

        /// <summary>
        /// MDTXT(mdtxt) Field
        /// </summary>
        public System.String MDTXT { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZPMF0011Model(ZPM_F0011) Proxy List Class
    /// </summary>    
    public class ZPMF0011ModelList  : List<ZPMF0011Model>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZPMF0011ModelList()
        {
            return;
        }
    }

}