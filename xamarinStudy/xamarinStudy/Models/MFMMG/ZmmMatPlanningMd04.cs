// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZMM_MAT_PLANNING_MD04" -output "ZmmMatPlanningMd04.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZMMMATPLANNINGMD04Model(ZMM_MAT_PLANNING_MD04) Proxy class
    /// </summary>
    public class ZMMMATPLANNINGMD04Model
    {
        /// <summary>
        /// I_BDTER_FR(iBDTERFr) Field
        /// </summary>
        public System.DateTime I_BDTER_FR { get; set; }

        /// <summary>
        /// I_BDTER_TO(iBDTERTo) Field
        /// </summary>
        public System.DateTime I_BDTER_TO { get; set; }

        /// <summary>
        /// I_MATKL(iMatkl) Field
        /// </summary>
        public System.String I_MATKL { get; set; }

        /// <summary>
        /// I_MATNR(iMatnr) Field
        /// </summary>
        public System.String I_MATNR { get; set; }

        /// <summary>
        /// I_MTART(iMtart) Field
        /// </summary>
        public System.String I_MTART { get; set; }

        /// <summary>
        /// I_WERKS(iWerks) Field
        /// </summary>
        public System.String I_WERKS { get; set; }

        /// <summary>
        /// I_ZDEPT(iZdept) Field
        /// </summary>
        public System.String I_ZDEPT { get; set; }

        /// <summary>
        /// ET_DATA(eTData) Field
        /// </summary>
        public IList<ZMMS0080Model> ET_DATA
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
    /// ZMMS0080Model(ZMMS0080) Proxy class
    /// </summary>
    public class ZMMS0080Model
    {
        /// <summary>
        /// MATNR(matnr) Field
        /// </summary>
        public System.String MATNR { get; set; }

        /// <summary>
        /// MAKTX(maktx) Field
        /// </summary>
        public System.String MAKTX { get; set; }

        /// <summary>
        /// LGORT(lgort) Field
        /// </summary>
        public System.String LGORT { get; set; }

        /// <summary>
        /// ZZBIN(zzbin) Field
        /// </summary>
        public System.String ZZBIN { get; set; }

        /// <summary>
        /// MEINS(meins) Field
        /// </summary>
        public System.String MEINS { get; set; }

        /// <summary>
        /// INVMNG1(iNVMNG1) Field
        /// </summary>
        public System.Decimal INVMNG1 { get; set; }

        /// <summary>
        /// INVMNG2(iNVMNG2) Field
        /// </summary>
        public System.Decimal INVMNG2 { get; set; }

        /// <summary>
        /// POMNG(pomng) Field
        /// </summary>
        public System.Decimal POMNG { get; set; }

        /// <summary>
        /// PRMNG(prmng) Field
        /// </summary>
        public System.Decimal PRMNG { get; set; }

        /// <summary>
        /// MNG01(mNG01) Field
        /// </summary>
        public System.Decimal MNG01 { get; set; }

        /// <summary>
        /// MNG02(mNG02) Field
        /// </summary>
        public System.Decimal MNG02 { get; set; }

        /// <summary>
        /// MNG03(mNG03) Field
        /// </summary>
        public System.Decimal MNG03 { get; set; }

        /// <summary>
        /// MATKL(matkl) Field
        /// </summary>
        public System.String MATKL { get; set; }

        /// <summary>
        /// ZZDEPT_CD_DESC(zZDEPTCDDesc) Field
        /// </summary>
        public System.String ZZDEPT_CD_DESC { get; set; }

        /// <summary>
        /// MINBE(minbe) Field
        /// </summary>
        public System.Decimal MINBE { get; set; }

        /// <summary>
        /// EISBE(eisbe) Field
        /// </summary>
        public System.Decimal EISBE { get; set; }

        /// <summary>
        /// PLIFZ(plifz) Field
        /// </summary>
        public System.Decimal PLIFZ { get; set; }

        /// <summary>
        /// ZZMAIN_E(zZMAINE) Field
        /// </summary>
        public System.String ZZMAIN_E { get; set; }

        /// <summary>
        /// ZSPEC_LONG(zSPECLong) Field
        /// </summary>
        public System.String ZSPEC_LONG { get; set; }

        /// <summary>
        /// PR_DATE(prDate) Field
        /// </summary>
        public System.String PR_DATE { get; set; }

        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZMMMATPLANNINGMD04Model(ZMM_MAT_PLANNING_MD04) Proxy List Class
    /// </summary>    
    public class ZMMMATPLANNINGMD04ModelList  : List<ZMMMATPLANNINGMD04Model>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZMMMATPLANNINGMD04ModelList()
        {
            return;
        }
    }

}