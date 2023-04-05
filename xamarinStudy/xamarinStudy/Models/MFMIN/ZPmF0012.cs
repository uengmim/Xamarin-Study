// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZPM_F0012" -output "ZPmF0012.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZPMF0012Model(ZPM_F0012) Proxy class
    /// </summary>
    public class ZPMF0012Model
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
        /// IT_DATA(iTData) Field
        /// </summary>
        public IList<ZPMS0010Model> IT_DATA
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
    /// ZPMS0010Model(ZPMS0010) Proxy class
    /// </summary>
    public class ZPMS0010Model
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
        /// EQUNR(equnr) Field
        /// </summary>
        public System.String EQUNR { get; set; }

        /// <summary>
        /// POINT(point) Field
        /// </summary>
        public System.String POINT { get; set; }

        /// <summary>
        /// MDOCM(mdocm) Field
        /// </summary>
        public System.String MDOCM { get; set; }

        /// <summary>
        /// RDCNT(rdcnt) Field
        /// </summary>
        public System.String RDCNT { get; set; }

        /// <summary>
        /// CODCT(codct) Field
        /// </summary>
        public System.String CODCT { get; set; }

        /// <summary>
        /// CODGR(codgr) Field
        /// </summary>
        public System.String CODGR { get; set; }

        /// <summary>
        /// VLCOD(vlcod) Field
        /// </summary>
        public System.String VLCOD { get; set; }

        /// <summary>
        /// UNITR(unitr) Field
        /// </summary>
        public System.String UNITR { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZPMF0012Model(ZPM_F0012) Proxy List Class
    /// </summary>    
    public class ZPMF0012ModelList  : List<ZPMF0012Model>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZPMF0012ModelList()
        {
            return;
        }
    }

}