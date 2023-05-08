using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using XNSC.DD;
using XNSC.Net;

namespace NMAP.Utils
{
    internal class ImateHelper
    {
        /// <summary>
        /// Single Tone
        /// </summary>
        /// <param name="reCreate"></param>
        /// <returns></returns>
        public static ImateHelper GetSingleTone(bool reCreate = false)
        {
            if (!reCreate && singleToneObj == null)
                singleToneObj = new ImateHelper();

            return singleToneObj;
        }
        private static ImateHelper singleToneObj = null;

        //-------------------------------------------------------------------------------

        /// <summary>
        /// Imate Adapter
        /// </summary>
        public ImateAdapter Adapter { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        public ImateHelper()
        {
            CryptKeyTableManager.LoadKeyTable(Properties.Resources.Profile);
            var keyData = CryptKeyTableManager.GetCryptKey(0);

            var apiProfile = JsonSerializer.Deserialize<ApiProfile>(keyData);

            Adapter = new ImateAdapter(apiProfile.ApiUrl, apiProfile.Secret, apiProfile.ApiUserId, apiProfile.ApiPassword, true, false);
            //Adapter = new ImateAdapter("https://192.168.3.37/iMATEWebAPIB4", apiProfile.Secret, "iacm_system", "a#12!08@", true, false);
        }
    }
}
