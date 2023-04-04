using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace NMAP.Models.MFMOU
{
    /// <summary>
    /// W/O리스트 모델
    /// </summary>
    public class WOListModel
    {
        public string AUFNR { get; set; }
        public string AUART { get; set; }
        public string KTEXT { get; set; }
        public string BUKRS { get; set; }
        public string WERKS { get; set; }
        public string WERKS_DESC { get; set; }
        public string GSBER { get; set; }
        public string GSBER_DESC { get; set; }
        public string KOKRS { get; set; }
        public string STAT { get; set; }
        public string LOEKZ { get; set; }
        public string INGPR { get; set; }
        public string INGPR_DESC { get; set; }
        public string VAPLZ { get; set; }
        public string VAPLZ_DESC { get; set; }
        public DateTime? IDAT1 { get; set; }
        public DateTime? GSTRP { get; set; }
        public DateTime? GLTRP { get; set; }
        public string QMNUM { get; set; }
        public string EQUNR { get; set; }
        public string EQUNR_DESC { get; set; }
        public string TPLNR { get; set; }
        public string TPLNR_DESC { get; set; }
        public string PARNR { get; set; }
        public string PARNR_DESC { get; set; }
        public string ERNAM { get; set; }
        public string ERNAM_DESC { get; set; }
        public DateTime? ERDAT { get; set; }
        public string AENAM { get; set; }
        public string AENAM_DESC { get; set; }
        public DateTime? AEDAT { get; set; }

        public string MATREQUEST { get; set; }


        public WOListModel()
        {

        }

        public WOListModel(string aufnr, string auart, string ktext, string bukrs, string werks, string werks_desc,
            string gsber, string gsber_desc, string kokrs, string stat, string loekz, string ingpr, string ingpr_desc,
            string vaplz, string vaplz_desc, DateTime idat1, DateTime gstrp, DateTime gltrp, string qmnum, string equnr,
            string equnr_desc, string tplnr, string tplnr_desc, string parnr, string parnr_desc,
            string ernam, string ernam_desc, DateTime erdat, string aenam, string aenam_desc, DateTime aedat) : this()
        {
            AUFNR = aufnr;
            AUART = auart;
            KTEXT = ktext;
            BUKRS = bukrs;
            WERKS = werks;
            WERKS_DESC = werks_desc;
            GSBER = gsber;
            GSBER_DESC = gsber_desc;
            KOKRS = kokrs;
            STAT = stat;
            LOEKZ = loekz;
            INGPR = ingpr;
            INGPR_DESC = ingpr_desc;
            VAPLZ = vaplz;
            VAPLZ_DESC = vaplz_desc;
            IDAT1 = idat1;
            GSTRP = gstrp;
            GLTRP = gltrp;
            QMNUM = qmnum;
            EQUNR = equnr;
            EQUNR_DESC = equnr_desc;
            TPLNR = tplnr;
            TPLNR_DESC = tplnr_desc;
            PARNR = parnr;
            PARNR_DESC = parnr_desc;
            ERNAM = ernam;
            ERNAM_DESC = ernam_desc;
            ERDAT = erdat;
            AENAM = aenam;
            AENAM_DESC = aenam_desc;
            AEDAT = aedat;
        }

        public Task<ObservableCollection<WOListModel>> getData(ObservableCollection<WOListModel> CardviewDataModel)
        {
            CardviewDataModel.Add(new WOListModel("4000044", "PM10", "TEST2", "1000", "1000", "남해화학 여수공장", "1100", "비료 화학", "1000", "REL", "", "421", "NPK#1공장", "PM200", "공무팀", new DateTime(2022, 8, 9), new DateTime(2022, 8, 9), new DateTime(2022, 8, 9), "10000041", "421-R-608", "ROTARY GRANULATOR", "1000-31-1", "SA#1공장", "300007", "외주공사", "CON08", "전종기", new DateTime(2022, 8, 9), "CON08", "", new DateTime(2022, 8, 9)));
            CardviewDataModel.Add(new WOListModel("4000047", "PM10", "", "1000", "1000", "남해화학 여수공장", "1100", "비료 화학", "1000", "CRTD", "", "421", "NPK#1공장", "PM200", "공무팀", new DateTime(), new DateTime(), new DateTime(2022, 8, 9), "10000043", "421-R-608", "ROTARY GRANULATOR", "1000-31-1", "SA#1공장", "300007", "외주공사", "CON08", "전종기", new DateTime(2022, 8, 9), "CON08", "", new DateTime(2022, 8, 9)));
            CardviewDataModel.Add(new WOListModel("4000102", "PM10", "TEST", "1000", "1000", "남해화학 여수공장", "1100", "비료 화학", "1000", "REL", "", "311", "SA#1공장", "PM400", "계전팀", new DateTime(2022, 8, 25), new DateTime(2022, 8, 27), new DateTime(2022, 8, 29), "10000066", "116-GD-1921", "AMMONIA GAS DETECTOR", "1000-31-1", "SA#1공장", "300007", "외주공사", "CON08", "전종기", new DateTime(2022, 8, 25), "CON08", "", new DateTime(2022, 8, 25)));
            CardviewDataModel.Add(new WOListModel("4000126", "PM01", "작업을 요청합니다-", "1000", "1000", "남해화학 여수공장", "1100", "비료 화학", "1000", "REL", "", "116", "고순도암모니아공장", "PM300", "기계정비팀", new DateTime(2022, 8, 30), new DateTime(2022, 8, 30), new DateTime(2022, 8, 30), "10000078", "116-P-101A", "STRIPPING TANK PUMP A", "1000-31-1", "SA#1공장", "300007", "외주공사", "PM001", "장종민", new DateTime(2022, 8, 30), "PM001", "", new DateTime(2022, 8, 30)));
            return Task.FromResult(CardviewDataModel);
            //return Task.Factory.StartNew(() =>
            //{
            //    try
            //    {
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //});
            CardviewDataModel.Add(new WOListModel("4000044", "PM10", "TEST2", "1000", "1000", "남해화학 여수공장", "1100", "비료 화학", "1000", "REL", "", "421", "NPK#1공장", "PM200", "공무팀", new DateTime(2022, 8, 9), new DateTime(2022, 8, 9), new DateTime(2022, 8, 9), "10000041", "421-R-608", "ROTARY GRANULATOR", "1000-31-1", "SA#1공장", "300007", "외주공사", "CON08", "전종기", new DateTime(2022, 8, 9), "CON08", "", new DateTime(2022, 8, 9)));
            CardviewDataModel.Add(new WOListModel("4000047", "PM10", "", "1000", "1000", "남해화학 여수공장", "1100", "비료 화학", "1000", "CRTD", "", "421", "NPK#1공장", "PM200", "공무팀", new DateTime(), new DateTime(), new DateTime(2022, 8, 9), "10000043", "421-R-608", "ROTARY GRANULATOR", "1000-31-1", "SA#1공장", "300007", "외주공사", "CON08", "전종기", new DateTime(2022, 8, 9), "CON08", "", new DateTime(2022, 8, 9)));
            CardviewDataModel.Add(new WOListModel("4000102", "PM10", "TEST", "1000", "1000", "남해화학 여수공장", "1100", "비료 화학", "1000", "REL", "", "311", "SA#1공장", "PM400", "계전팀", new DateTime(2022, 8, 25), new DateTime(2022, 8, 27), new DateTime(2022, 8, 29), "10000066", "116-GD-1921", "AMMONIA GAS DETECTOR", "1000-31-1", "SA#1공장", "300007", "외주공사", "CON08", "전종기", new DateTime(2022, 8, 25), "CON08", "", new DateTime(2022, 8, 25)));
            CardviewDataModel.Add(new WOListModel("4000126", "PM01", "작업을 요청합니다-", "1000", "1000", "남해화학 여수공장", "1100", "비료 화학", "1000", "REL", "", "116", "고순도암모니아공장", "PM300", "기계정비팀", new DateTime(2022, 8, 30), new DateTime(2022, 8, 30), new DateTime(2022, 8, 30), "10000078", "116-P-101A", "STRIPPING TANK PUMP A", "1000-31-1", "SA#1공장", "300007", "외주공사", "PM001", "장종민", new DateTime(2022, 8, 30), "PM001", "", new DateTime(2022, 8, 30)));
            return Task.FromResult(CardviewDataModel);
        } 
    }
}
