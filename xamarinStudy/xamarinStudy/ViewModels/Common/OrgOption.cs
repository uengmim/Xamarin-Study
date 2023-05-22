using System;
using System.Collections.Generic;
using System.Text;

namespace NMAP.ViewModels.Common
{
    /// <summary>
    /// 조직 옵션
    /// </summary>
    public class OrganizationOption
    {
        /// <summary>
        /// 조직 유형
        /// </summary>
        public string OrgType { get; set; }

        /// <summary>
        /// 밴더 조직ID
        /// </summary>
        public string VOrgId { get; set; }

        /// <summary>
        /// 주문자 조직ID
        /// </summary>
        public string COrgId { get; set; }

        /// <summary>
        /// 운송자 조직ID
        /// </summary>
        public string TOrgId { get; set; }

        /// <summary>
        /// 내부직원 조직ID
        /// </summary>
        public string YOrgId { get; set; }

        /// <summary>
        /// 기타 조직 1
        /// </summary>
        public string EtcOrgId1 { get; set; }

        /// <summary>
        /// 기타 조직 2
        /// </summary>
        public string EtcOrgId2 { get; set; }
    }
}
