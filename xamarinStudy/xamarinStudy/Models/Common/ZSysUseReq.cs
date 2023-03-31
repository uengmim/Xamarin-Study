// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZSYSUSERREQ" -output "ZSysUseReq.cs" -mtype "proxy" -nspace NMAP.Models.Ccmmon

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

using XNSC;
using XNSC.DD;
using XNSC.DD.EX;

namespace NMAP.Models.Common
{
    /// <summary>
    /// ZsysuserreqModel(ZSYSUSERREQ) Proxy class
    /// </summary>
    public class ZsysuserreqModel
    {
        /// <summary>
        /// ID Field
        /// </summary>
        public System.String id { get; set; }

        /// <summary>
        /// NAME Field
        /// </summary>
        public System.String name { get; set; }

        /// <summary>
        /// ROLE Field
        /// </summary>
        public System.String role { get; set; }

        /// <summary>
        /// EMAIL Field
        /// </summary>
        public System.String email { get; set; }

        /// <summary>
        /// APPNAME Field
        /// </summary>
        public System.String appname { get; set; }

        /// <summary>
        /// DEPTCODE Field
        /// </summary>
        public System.String deptcode { get; set; }

        /// <summary>
        /// DEPTNAME Field
        /// </summary>
        public System.String deptname { get; set; }

        /// <summary>
        /// USERID Field
        /// </summary>
        public System.String userid { get; set; }

        /// <summary>
        /// EMPID Field
        /// </summary>
        public System.String empid { get; set; }

        /// <summary>
        /// REFDATA1 Field
        /// </summary>
        public System.String rEFDATA1 { get; set; }

        /// <summary>
        /// REFDATA2 Field
        /// </summary>
        public System.String rEFDATA2 { get; set; }

        /// <summary>
        /// REFDATA3 Field
        /// </summary>
        public System.String rEFDATA3 { get; set; }

        /// <summary>
        /// REFDATA4 Field
        /// </summary>
        public System.String rEFDATA4 { get; set; }

        /// <summary>
        /// REFDATA5 Field
        /// </summary>
        public System.String rEFDATA5 { get; set; }

        /// <summary>
        /// REGDATS Field
        /// </summary>
        public System.DateTime regdats { get; set; }

        /// <summary>
        /// REGTIMS Field
        /// </summary>
        public System.TimeSpan regtims { get; set; }

        /// <summary>
        /// STATUS Field
        /// </summary>
        public System.String status { get; set; }

        /// <summary>
        /// UPDATS Field
        /// </summary>
        public System.DateTime updats { get; set; }

        /// <summary>
        /// UPTIMS Field
        /// </summary>
        public System.TimeSpan uptims { get; set; }

        /// <summary>
        /// ACCCODE Field
        /// </summary>
        public System.String acccode { get; set; }

        /// <summary>
        /// REJCODE Field
        /// </summary>
        public System.String rejcode { get; set; }


        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

    /// <summary>
    /// ZsysuserreqModel(ZSYSUSERREQ) Proxy List Class
    /// </summary>    
    public class ZsysuserreqModelList : List<ZsysuserreqModel>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZsysuserreqModelList()
        {
            return;
        }
    }
}