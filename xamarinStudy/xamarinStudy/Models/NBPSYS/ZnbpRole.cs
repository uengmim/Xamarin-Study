// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZNBP_ROLE" -output "ZnbpRole.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZNBPRoleModel(ZNBP_ROLE) Proxy class
    /// </summary>
    public class ZNBPRoleModel
    {
        /// <summary>
        /// APPID(appid) Field
        /// </summary>
        public System.String APPID { get; set; }

        /// <summary>
        /// ROLEID(roleid) Field
        /// </summary>
        public System.String ROLEID { get; set; }

        /// <summary>
        /// ROLEDES(roledes) Field
        /// </summary>
        public System.String ROLEDES { get; set; }

        /// <summary>
        /// ROLEOPT(roleopt) Field
        /// </summary>
        public System.String ROLEOPT { get; set; }

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
        /// REFDT1(rEFDT1) Field
        /// </summary>
        public System.DateTime REFDT1 { get; set; }

        /// <summary>
        /// REFDT2(rEFDT2) Field
        /// </summary>
        public System.DateTime REFDT2 { get; set; }

        /// <summary>
        /// REFDT3(rEFDT3) Field
        /// </summary>
        public System.DateTime REFDT3 { get; set; }

        /// <summary>
        /// CRTUSR(crtusr) Field
        /// </summary>
        public System.String CRTUSR { get; set; }

        /// <summary>
        /// CRTDT(crtdt) Field
        /// </summary>
        public System.DateTime CRTDT { get; set; }

        /// <summary>
        /// CRTTM(crttm) Field
        /// </summary>
        public System.TimeSpan CRTTM { get; set; }

        /// <summary>
        /// UPDUSR(updusr) Field
        /// </summary>
        public System.String UPDUSR { get; set; }

        /// <summary>
        /// UPDTM(updtm) Field
        /// </summary>
        public System.TimeSpan UPDTM { get; set; }

        /// <summary>
        /// UPDDT(upddt) Field
        /// </summary>
        public System.DateTime UPDDT { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZNBPRoleModel(ZNBP_ROLE) Proxy List Class
    /// </summary>    
    public class ZNBPRoleModelList  : List<ZNBPRoleModel>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZNBPRoleModelList()
        {
            return;
        }
    }

}