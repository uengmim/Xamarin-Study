// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZMM_CURR_STOCK" -output "ZmmCurrStock.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZMMCURRStockModel(ZMM_CURR_STOCK) Proxy class
    /// </summary>
    public class ZMMCURRStockModel
    {
        /// <summary>
        /// I_KZNUL(iKznul) Field
        /// </summary>
        public System.String I_KZNUL { get; set; }

        /// <summary>
        /// I_WERKS(iWerks) Field
        /// </summary>
        public System.String I_WERKS { get; set; }

        /// <summary>
        /// ET_LIST(eTList) Field
        /// </summary>
        public IList<ZMMS3120Model> ET_LIST
        {
            get;
            set;
        }

        /// <summary>
        /// IT_INPUT(iTInput) Field
        /// </summary>
        public IList<ZMMS3140Model> IT_INPUT
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
    /// ZMMS3120Model(ZMMS3120) Proxy class
    /// </summary>
    public class ZMMS3120Model
    {
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
        /// MTART(mtart) Field
        /// </summary>
        public System.String MTART { get; set; }

        /// <summary>
        /// MATNR(matnr) Field
        /// </summary>
        public System.String MATNR { get; set; }

        /// <summary>
        /// MAKTX(maktx) Field
        /// </summary>
        public System.String MAKTX { get; set; }

        /// <summary>
        /// SPART(spart) Field
        /// </summary>
        public System.String SPART { get; set; }

        /// <summary>
        /// VTEXT(vtext) Field
        /// </summary>
        public System.String VTEXT { get; set; }

        /// <summary>
        /// MATKL(matkl) Field
        /// </summary>
        public System.String MATKL { get; set; }

        /// <summary>
        /// WGBEZ(wgbez) Field
        /// </summary>
        public System.String WGBEZ { get; set; }

        /// <summary>
        /// ZZDEPT_CD(zZDEPTCd) Field
        /// </summary>
        public System.String ZZDEPT_CD { get; set; }

        /// <summary>
        /// ZZDEPT_NM(zZDEPTNm) Field
        /// </summary>
        public System.String ZZDEPT_NM { get; set; }

        /// <summary>
        /// ZZBIN(zzbin) Field
        /// </summary>
        public System.String ZZBIN { get; set; }

        /// <summary>
        /// MEINS(meins) Field
        /// </summary>
        public System.String MEINS { get; set; }

        /// <summary>
        /// SOBKZ(sobkz) Field
        /// </summary>
        public System.String SOBKZ { get; set; }

        /// <summary>
        /// SOTXT(sotxt) Field
        /// </summary>
        public System.String SOTXT { get; set; }

        /// <summary>
        /// PARTNER(partner) Field
        /// </summary>
        public System.String PARTNER { get; set; }

        /// <summary>
        /// NAME1(nAME1) Field
        /// </summary>
        public System.String NAME1 { get; set; }

        /// <summary>
        /// LABST(labst) Field
        /// </summary>
        public System.Decimal LABST { get; set; }

        /// <summary>
        /// INSME(insme) Field
        /// </summary>
        public System.Decimal INSME { get; set; }

        /// <summary>
        /// SPEME(speme) Field
        /// </summary>
        public System.Decimal SPEME { get; set; }

        /// <summary>
        /// UMLME(umlme) Field
        /// </summary>
        public System.Decimal UMLME { get; set; }

        /// <summary>
        /// LABST_MT(lABSTMt) Field
        /// </summary>
        public System.Decimal LABST_MT { get; set; }

        /// <summary>
        /// INSME_MT(iNSMEMt) Field
        /// </summary>
        public System.Decimal INSME_MT { get; set; }

        /// <summary>
        /// SPEME_MT(sPEMEMt) Field
        /// </summary>
        public System.Decimal SPEME_MT { get; set; }

        /// <summary>
        /// UMLME_MT(uMLMEMt) Field
        /// </summary>
        public System.Decimal UMLME_MT { get; set; }

        /// <summary>
        /// VPRSV(vprsv) Field
        /// </summary>
        public System.String VPRSV { get; set; }

        /// <summary>
        /// PEINH(peinh) Field
        /// </summary>
        public System.Decimal PEINH { get; set; }

        /// <summary>
        /// VERPR(verpr) Field
        /// </summary>
        public System.Decimal VERPR { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }
/// <summary>
    /// ZMMS3140Model(ZMMS3140) Proxy class
    /// </summary>
    public class ZMMS3140Model
    {
        /// <summary>
        /// LGORT(lgort) Field
        /// </summary>
        public System.String LGORT { get; set; }

        /// <summary>
        /// MAKTX(maktx) Field
        /// </summary>
        public System.String MAKTX { get; set; }

        /// <summary>
        /// SOBKZ(sobkz) Field
        /// </summary>
        public System.String SOBKZ { get; set; }

        /// <summary>
        /// PARTNER(partner) Field
        /// </summary>
        public System.String PARTNER { get; set; }

        /// <summary>
        /// MTART(mtart) Field
        /// </summary>
        public System.String MTART { get; set; }

        /// <summary>
        /// MATNR(matnr) Field
        /// </summary>
        public System.String MATNR { get; set; }

        /// <summary>
        /// MATKL(matkl) Field
        /// </summary>
        public System.String MATKL { get; set; }

        /// <summary>
        /// SPART(spart) Field
        /// </summary>
        public System.String SPART { get; set; }

        /// <summary>
        /// ZZDEPT_CD(zZDEPTCd) Field
        /// </summary>
        public System.String ZZDEPT_CD { get; set; }

        /// <summary>
        /// ZZBIN(zzbin) Field
        /// </summary>
        public System.String ZZBIN { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZMMCURRStockModel(ZMM_CURR_STOCK) Proxy List Class
    /// </summary>    
    public class ZMMCURRStockModelList  : List<ZMMCURRStockModel>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZMMCURRStockModelList()
        {
            return;
        }
    }

}