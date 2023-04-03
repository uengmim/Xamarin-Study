// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZPM_F0001" -output "ZPmF0001Proxy.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZPMF0001 RFC 파라미터
    /// </summary>
    public class PmOrderParams
    {
        /// <summary>
        /// I_AUART(iAuart) Field
        /// </summary>
        public string I_AUART { get; set; }

        /// <summary>
        /// I_AUFNR(iAufnr) Field
        /// </summary>
        public string I_AUFNR { get; set; }

        /// <summary>
        /// I_IDAT1_E(iIDAT1E) Field
        /// </summary>
        public DateTime I_IDAT1_E { get; set; }

        /// <summary>
        /// I_IDAT1_S(iIDAT1S) Field
        /// </summary>
        public DateTime I_IDAT1_S { get; set; }

        /// <summary>
        /// I_INGPR(iIngpr) Field
        /// </summary>
        public string I_INGPR { get; set; }

        /// <summary>
        /// I_PARNR(iParnr) Field
        /// </summary>
        public string I_PARNR { get; set; }

        /// <summary>
        /// I_STAT(iStat) Field
        /// </summary>
        public string I_STAT { get; set; }

        /// <summary>
        /// I_VAPLZ(iVaplz) Field
        /// </summary>
        public string I_VAPLZ { get; set; }

        /// <summary>
        /// I_WERKS(iWerks) Field
        /// </summary>
        public string I_WERKS { get; set; }
    }

}