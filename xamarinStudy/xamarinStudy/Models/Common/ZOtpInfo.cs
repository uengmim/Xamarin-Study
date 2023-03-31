// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZOTPINFO" -output "ZOtpInfo.cs" -mtype "proxy" -nspace NMAP.Models.Common

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
    /// ZotpinfoModel(ZOTPINFO) Proxy class
    /// </summary>
    public class ZotpinfoModel
    {
        /// <summary>
        /// ID Field
        /// </summary>
        public System.String id { get; set; }

        /// <summary>
        /// TYPE Field
        /// </summary>
        public System.String type { get; set; }

        /// <summary>
        /// SCODE Field
        /// </summary>
        public System.String scode { get; set; }

        /// <summary>
        /// STATUS Field
        /// </summary>
        public System.String status { get; set; }

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
        /// REFDATS Field
        /// </summary>
        public System.DateTime refdats { get; set; }

        /// <summary>
        /// REFTIMS Field
        /// </summary>
        public System.TimeSpan reftims { get; set; }

        /// <summary>
        /// UPDATS Field
        /// </summary>
        public System.DateTime updats { get; set; }

        /// <summary>
        /// UPTIMS Field
        /// </summary>
        public System.TimeSpan uptims { get; set; }


        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

    /// <summary>
    /// ZotpinfoModel(ZOTPINFO) Proxy List Class
    /// </summary>    
    public class ZotpinfoModelList : List<ZotpinfoModel>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZotpinfoModelList()
        {
            return;
        }
    }
}