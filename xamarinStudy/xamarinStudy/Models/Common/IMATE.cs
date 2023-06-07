using Acr.UserDialogs.Infrastructure;
using NAMHE.Model;
using NMAP.Models.MFMOU;
using NMAP.Utils;
using NMAP.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XNSC.DD.EX;
using XNSC.Net;

namespace NMAP.Models.Common
{
    public class IMATE
    {
        private string ServerKey { get { return Preferences.Get("serverKey", ""); } }

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public IMATE()
        {

        }

        /// <summary>
        /// 오더리스트 RFC
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<ZPMS0002Model>> GetOrderList(DateTime StartDate, DateTime EndDate, LoginDataModel loginInfo)
        {
            try
            {
                if (string.IsNullOrEmpty(ServerKey))
                    throw new ArgumentException(Properties.Resources.STR_EMPTY_SERVER_KEY);

                var model = new ObservableCollection<ZPMS0002Model>();
                var zpmf0001List = new ZPMF0001ModelList();

                var isADMIN = false;
                var parnr = loginInfo.empId;

                foreach (var rol in loginInfo.Roles)
                {
                    if (rol == "ADMIN")
                        isADMIN = true;
                }

                if (isADMIN)
                    parnr = "";

                // 객체 TYPE 인식 문제 때문에 NULL 값을 전송 하면안됨, 기본 값을 반드시 넣어 주어야 함.
                zpmf0001List.Add(new ZPMF0001Model()
                {
                    I_WERKS = "1000",
                    I_AUFNR = "",
                    I_PARNR = parnr,
                    I_AUART = "",
                    I_STAT = "",
                    I_IDAT1_S = StartDate,
                    I_IDAT1_E = EndDate,
                    I_VAPLZ = "",
                    I_INGPR = "",
                    E_MSG = "",
                    E_TYPE = "",
                    ITAB_DATA = new ObservableCollection<ZPMS0002Model>()
                });

                var result = await ImateHelper.GetSingleTone().Adapter.RefcCallUsingModelAsync<ZPMF0001ModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZPMF0001ModelList", zpmf0001List, QueryCacheType.None);
                return result[0].ITAB_DATA;
            }
            catch (Exception ex)
            {
                Log.Error("NMAP", $"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// 오더 상세 리스트 RFC
        /// </summary>
        /// <param name="aufnr"></param>
        /// <returns></returns>
        public async Task<ZPMF0002ModelList> GetOrderDetailList(string aufnr)
        {
            try
            {
                if (string.IsNullOrEmpty(ServerKey))
                    throw new ArgumentException(Properties.Resources.STR_EMPTY_SERVER_KEY);

                var zpmf0002List = new ZPMF0002ModelList();
                // 객체 TYPE 인식 문제 때문에 NULL 값을 전송 하면안됨, 기본 값을 반드시 넣어 주어야 함.
                zpmf0002List.Add(new ZPMF0002Model()
                {
                    I_AUFNR = aufnr,
                    E_MSG = "",
                    E_TYPE = "",
                    ITAB_DATA1 = new ObservableCollection<ZPMS0002Model>(),
                    ITAB_DATA2 = new ObservableCollection<ZPMS0003Model>(),
                    ITAB_DATA3 = new ObservableCollection<ZPMS0004Model>(),
                    ITAB_DATA4 = new ObservableCollection<ZPMS0009Model>(),
                    ITAB_DATA5 = new ObservableCollection<ZPMT10010Model>(),
                    ITAB_DATA6 = new ObservableCollection<ZPMT10011Model>()
                });

                return await ImateHelper.GetSingleTone().Adapter.RefcCallUsingModelAsync<ZPMF0002ModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZPMF0002ModelList", zpmf0002List, QueryCacheType.None);
            }
            catch (Exception ex)
            {
                Log.Error("NMAP", $"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// 오더 데이터 저장(자재요청 저장)
        /// </summary>
        /// <param name="aufnr"></param>
        /// <returns></returns>
        public async Task<ZPMF0003ModelList> SaveOrderData(ZPMS0003Model selectedRow)
        {
            try
            {
                if (string.IsNullOrEmpty(ServerKey))
                    throw new ArgumentException(Properties.Resources.STR_EMPTY_SERVER_KEY);

                var itab_data1 = new ObservableCollection<ZPMS0003Model>(new ZPMS0003Model[] { selectedRow });

                var zpmf0003List = new ZPMF0003ModelList();
                zpmf0003List.Add(new ZPMF0003Model()
                {
                    I_AUFNR = selectedRow.AUFNR,
                    E_MSG = "",
                    E_TYPE = "",
                    ITAB_DATA1 = itab_data1,
                    ITAB_DATA2 = new ObservableCollection<ZPMS0009Model>(),
                    ITAB_DATA3 = new ObservableCollection<ZPMT10010Model>(),
                    ITAB_DATA4 = new ObservableCollection<ZPMT10011Model>(),
                    ITAB_DATA5 = new ObservableCollection<ZPMS0012Model>(),
                });

                return await ImateHelper.GetSingleTone().Adapter.RefcCallUsingModelAsync<ZPMF0003ModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZPMF0003ModelList", zpmf0003List, QueryCacheType.None);
            }
            catch (Exception ex)
            {
                Log.Error("NMAP", $"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// 오더 데이터 저장(자재사용 저장)
        /// </summary>
        /// <param name="aufnr"></param>
        /// <returns></returns>
        public async Task<ZPMF0003ModelList> SaveOrderData(ObservableCollection<WOMatMedel> useMatList)
        {
            try
            {
                if (string.IsNullOrEmpty(ServerKey))
                    throw new ArgumentException(Properties.Resources.STR_EMPTY_SERVER_KEY);

                var model = new ZPMF0003ModelList();
                var itab_data5 = new ObservableCollection<ZPMS0012Model>();

                foreach(var row in useMatList)
                {
                    itab_data5.Add(new ZPMS0012Model() { RSNUM = row.RSNUM, LGORT = row.LGORT, MATNR = row.MATNR, QTY_CON = row.QTY_INPUT, EINHEIT = row.MEINS });
                }

                var zpmf0003List = new ZPMF0003ModelList();
                zpmf0003List.Add(new ZPMF0003Model()
                {
                    I_AUFNR = useMatList[0].AUFNR,
                    E_MSG = "",
                    E_TYPE = "",
                    ITAB_DATA1 = new ObservableCollection<ZPMS0003Model>(),
                    ITAB_DATA2 = new ObservableCollection<ZPMS0009Model>(),
                    ITAB_DATA3 = new ObservableCollection<ZPMT10010Model>(),
                    ITAB_DATA4 = new ObservableCollection<ZPMT10011Model>(),
                    ITAB_DATA5 = itab_data5,
                });

                return await ImateHelper.GetSingleTone().Adapter.RefcCallUsingModelAsync<ZPMF0003ModelList>(ServerKey, "NBPDataModels", "NAMHE.Model.ZPMF0003ModelList", zpmf0003List, QueryCacheType.None);
            }
            catch (Exception ex)
            {
                Log.Error("NMAP", $"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
                throw;
            }
        }
    }
}
