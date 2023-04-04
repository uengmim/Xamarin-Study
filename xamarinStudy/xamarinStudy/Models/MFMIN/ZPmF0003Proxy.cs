// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZPM_F0003" -output "ZPmF0003Proxy.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZPMF0003Model(ZPM_F0003) Proxy class
    /// </summary>
    public class ZPMF0003Model
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
        public IList<ZPMS0003Model> ITAB_DATA1
        {
            get;
            set;
        }

        /// <summary>
        /// ITAB_DATA2(iTABDATA2) Field
        /// </summary>
        public IList<ZPMS0009Model> ITAB_DATA2
        {
            get;
            set;
        }

        /// <summary>
        /// ITAB_DATA3(iTABDATA3) Field
        /// </summary>
        public IList<ZPMT10010Model> ITAB_DATA3
        {
            get;
            set;
        }

        /// <summary>
        /// ITAB_DATA4(iTABDATA4) Field
        /// </summary>
        public IList<ZPMT10011Model> ITAB_DATA4
        {
            get;
            set;
        }

        /// <summary>
        /// ITAB_DATA5(iTABDATA5) Field
        /// </summary>
        public IList<ZPMS0012Model> ITAB_DATA5
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
    /// ZPMS0012Model(ZPMS0012) Proxy class
    /// </summary>
    public class ZPMS0012Model
    {
        /// <summary>
        /// SEQ2(sEQ2) Field
        /// </summary>
        public System.String SEQ2 { get; set; }

        /// <summary>
        /// RSNUM(rsnum) Field
        /// </summary>
        public System.String RSNUM { get; set; }

        /// <summary>
        /// RSPOS(rspos) Field
        /// </summary>
        public System.String RSPOS { get; set; }

        /// <summary>
        /// LGORT(lgort) Field
        /// </summary>
        public System.String LGORT { get; set; }

        /// <summary>
        /// MATNR(matnr) Field
        /// </summary>
        public System.String MATNR { get; set; }

        /// <summary>
        /// QTY_CON(qTYCon) Field
        /// </summary>
        public System.Decimal QTY_CON { get; set; }

        /// <summary>
        /// QTY_DEL(qTYDel) Field
        /// </summary>
        public System.Decimal QTY_DEL { get; set; }

        /// <summary>
        /// EINHEIT(einheit) Field
        /// </summary>
        public System.String EINHEIT { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZPMF0003Model(ZPM_F0003) Proxy List Class
    /// </summary>    
    public class ZPMF0003ModelList  : List<ZPMF0003Model>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZPMF0003ModelList()
        {
            return;
        }
    }

}