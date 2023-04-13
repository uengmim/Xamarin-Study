// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZNBP_SYSRQ" -output "Znbpsysrq.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZNBPSysrqModel(ZNBP_SYSRQ) Proxy class
    /// </summary>
    public class ZNBPSysrqModel
    {
        /// <summary>
        /// MANDT(mandt) Field
        /// </summary>
        public System.String MANDT { get; set; }

        /// <summary>
        /// RQNUM(rqnum) Field
        /// </summary>
        public System.String RQNUM { get; set; }

        /// <summary>
        /// APPID(appid) Field
        /// </summary>
        public System.String APPID { get; set; }

        /// <summary>
        /// RQTYP(rqtyp) Field
        /// </summary>
        public System.String RQTYP { get; set; }

        /// <summary>
        /// ORGID(orgid) Field
        /// </summary>
        public System.String ORGID { get; set; }

        /// <summary>
        /// ORGDES1(oRGDES1) Field
        /// </summary>
        public System.String ORGDES1 { get; set; }

        /// <summary>
        /// ORGDES2(oRGDES2) Field
        /// </summary>
        public System.String ORGDES2 { get; set; }

        /// <summary>
        /// ORGDES3(oRGDES3) Field
        /// </summary>
        public System.String ORGDES3 { get; set; }

        /// <summary>
        /// ORGDES4(oRGDES4) Field
        /// </summary>
        public System.String ORGDES4 { get; set; }

        /// <summary>
        /// ORGDES5(oRGDES5) Field
        /// </summary>
        public System.String ORGDES5 { get; set; }

        /// <summary>
        /// NAME(name) Field
        /// </summary>
        public System.String NAME { get; set; }

        /// <summary>
        /// APPST(appst) Field
        /// </summary>
        public System.String APPST { get; set; }

        /// <summary>
        /// LOGID(logid) Field
        /// </summary>
        public System.String LOGID { get; set; }

        /// <summary>
        /// LOGPW(logpw) Field
        /// </summary>
        public System.String LOGPW { get; set; }

        /// <summary>
        /// INITPW(initpw) Field
        /// </summary>
        public System.String INITPW { get; set; }

        /// <summary>
        /// MACID(macid) Field
        /// </summary>
        public System.String MACID { get; set; }

        /// <summary>
        /// INTIP(intip) Field
        /// </summary>
        public System.String INTIP { get; set; }

        /// <summary>
        /// ROLE(role) Field
        /// </summary>
        public System.String ROLE { get; set; }

        /// <summary>
        /// PERM(perm) Field
        /// </summary>
        public System.String PERM { get; set; }

        /// <summary>
        /// VORGID(vorgid) Field
        /// </summary>
        public System.String VORGID { get; set; }

        /// <summary>
        /// CORGID(corgid) Field
        /// </summary>
        public System.String CORGID { get; set; }

        /// <summary>
        /// TORGID(torgid) Field
        /// </summary>
        public System.String TORGID { get; set; }

        /// <summary>
        /// YORGID(yorgid) Field
        /// </summary>
        public System.String YORGID { get; set; }

        /// <summary>
        /// ETCORG1(eTCORG1) Field
        /// </summary>
        public System.String ETCORG1 { get; set; }

        /// <summary>
        /// ETCIRG2(eTCIRG2) Field
        /// </summary>
        public System.String ETCIRG2 { get; set; }

        /// <summary>
        /// REFDA1(rEFDA1) Field
        /// </summary>
        public System.String REFDA1 { get; set; }

        /// <summary>
        /// REFDA2(rEFDA2) Field
        /// </summary>
        public System.String REFDA2 { get; set; }

        /// <summary>
        /// REFDA3(rEFDA3) Field
        /// </summary>
        public System.String REFDA3 { get; set; }

        /// <summary>
        /// REFDA4(rEFDA4) Field
        /// </summary>
        public System.String REFDA4 { get; set; }

        /// <summary>
        /// REFDA5(rEFDA5) Field
        /// </summary>
        public System.String REFDA5 { get; set; }

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
    /// ZNBPSysrqModel(ZNBP_SYSRQ) Proxy List Class
    /// </summary>    
    public class ZNBPSysrqModelList  : List<ZNBPSysrqModel>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZNBPSysrqModelList()
        {
            return;
        }
    }

}