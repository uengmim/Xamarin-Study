// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZPM_F0016" -output "ZPmF0016.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZPMF0016Model(ZPM_F0016) Proxy class
    /// </summary>
    public class ZPMF0016Model
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
        /// I_ARBPL(iArbpl) Field
        /// </summary>
        public System.String I_ARBPL { get; set; }

        /// <summary>
        /// ET_DATA(eTData) Field
        /// </summary>
        public IList<ZPMS0016Model> ET_DATA
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
    /// ZPMS0016Model(ZPMS0016) Proxy class
    /// </summary>
    public class ZPMS0016Model
    {
        /// <summary>
        /// ARBPL(arbpl) Field
        /// </summary>
        public System.String ARBPL { get; set; }

        /// <summary>
        /// KTEXT(ktext) Field
        /// </summary>
        public System.String KTEXT { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZPMF0016Model(ZPM_F0016) Proxy List Class
    /// </summary>    
    public class ZPMF0016ModelList  : List<ZPMF0016Model>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZPMF0016ModelList()
        {
            return;
        }
    }

}