// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZPM_F0014" -output "ZPmF0014.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZPMF0014Model(ZPM_F0014) Proxy class
    /// </summary>
    public class ZPMF0014Model
    {
        /// <summary>
        /// E_MSG(eMsg) Field
        /// </summary>
        public System.String E_MSG { get; set; }

        /// <summary>
        /// E_TYPE(eType) Field
        /// </summary>
        public System.String E_TYPE { get; set; }

        /// <summary>
        /// I_ARBPL(iArbpl) Field
        /// </summary>
        public System.String I_ARBPL { get; set; }

        /// <summary>
        /// I_EQART(iEqart) Field
        /// </summary>
        public System.String I_EQART { get; set; }

        /// <summary>
        /// I_EQUNR(iEqunr) Field
        /// </summary>
        public System.String I_EQUNR { get; set; }

        /// <summary>
        /// I_EQUNR_DESC(iEQUNRDesc) Field
        /// </summary>
        public System.String I_EQUNR_DESC { get; set; }

        /// <summary>
        /// I_INGRP(iIngrp) Field
        /// </summary>
        public System.String I_INGRP { get; set; }

        /// <summary>
        /// ET_DATA(eTData) Field
        /// </summary>
        public IList<ZPMS0014Model> ET_DATA
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
    /// ZPMS0014Model(ZPMS0014) Proxy class
    /// </summary>
    public class ZPMS0014Model
    {
        /// <summary>
        /// EQUNR(equnr) Field
        /// </summary>
        public System.String EQUNR { get; set; }

        /// <summary>
        /// EQUNR_DESC(eQUNRDesc) Field
        /// </summary>
        public System.String EQUNR_DESC { get; set; }

        /// <summary>
        /// TPLNR(tplnr) Field
        /// </summary>
        public System.String TPLNR { get; set; }

        /// <summary>
        /// TPLNR_DESC(tPLNRDesc) Field
        /// </summary>
        public System.String TPLNR_DESC { get; set; }

        /// <summary>
        /// EQTYP(eqtyp) Field
        /// </summary>
        public System.String EQTYP { get; set; }

        /// <summary>
        /// EQART(eqart) Field
        /// </summary>
        public System.String EQART { get; set; }

        /// <summary>
        /// BUKRS(bukrs) Field
        /// </summary>
        public System.String BUKRS { get; set; }

        /// <summary>
        /// ANLNR(anlnr) Field
        /// </summary>
        public System.String ANLNR { get; set; }

        /// <summary>
        /// GROES(groes) Field
        /// </summary>
        public System.String GROES { get; set; }

        /// <summary>
        /// BRGEW(brgew) Field
        /// </summary>
        public System.Decimal BRGEW { get; set; }

        /// <summary>
        /// GEWEI(gewei) Field
        /// </summary>
        public System.String GEWEI { get; set; }

        /// <summary>
        /// ANSDT(ansdt) Field
        /// </summary>
        public System.DateTime ANSDT { get; set; }

        /// <summary>
        /// ANSWT(answt) Field
        /// </summary>
        public System.Decimal ANSWT { get; set; }

        /// <summary>
        /// WAERS(waers) Field
        /// </summary>
        public System.String WAERS { get; set; }

        /// <summary>
        /// HERST(herst) Field
        /// </summary>
        public System.String HERST { get; set; }

        /// <summary>
        /// HERLD(herld) Field
        /// </summary>
        public System.String HERLD { get; set; }

        /// <summary>
        /// HZEIN(hzein) Field
        /// </summary>
        public System.String HZEIN { get; set; }

        /// <summary>
        /// SERGE(serge) Field
        /// </summary>
        public System.String SERGE { get; set; }

        /// <summary>
        /// TYPBZ(typbz) Field
        /// </summary>
        public System.String TYPBZ { get; set; }

        /// <summary>
        /// BAUJJ(baujj) Field
        /// </summary>
        public System.String BAUJJ { get; set; }

        /// <summary>
        /// BAUMM(baumm) Field
        /// </summary>
        public System.String BAUMM { get; set; }

        /// <summary>
        /// SWERK(swerk) Field
        /// </summary>
        public System.String SWERK { get; set; }

        /// <summary>
        /// ABCKZ(abckz) Field
        /// </summary>
        public System.String ABCKZ { get; set; }

        /// <summary>
        /// GSBER(gsber) Field
        /// </summary>
        public System.String GSBER { get; set; }

        /// <summary>
        /// KOKRS(kokrs) Field
        /// </summary>
        public System.String KOKRS { get; set; }

        /// <summary>
        /// KOSTL(kostl) Field
        /// </summary>
        public System.String KOSTL { get; set; }

        /// <summary>
        /// ARBPL(arbpl) Field
        /// </summary>
        public System.String ARBPL { get; set; }

        /// <summary>
        /// INGRP(ingrp) Field
        /// </summary>
        public System.String INGRP { get; set; }

        /// <summary>
        /// BEBER(beber) Field
        /// </summary>
        public System.String BEBER { get; set; }

        /// <summary>
        /// INBDT(inbdt) Field
        /// </summary>
        public System.DateTime INBDT { get; set; }

        /// <summary>
        /// GERNR(gernr) Field
        /// </summary>
        public System.String GERNR { get; set; }

        /// <summary>
        /// ERDAT(erdat) Field
        /// </summary>
        public System.DateTime ERDAT { get; set; }

        /// <summary>
        /// ERNAM(ernam) Field
        /// </summary>
        public System.String ERNAM { get; set; }

        /// <summary>
        /// AEDAT(aedat) Field
        /// </summary>
        public System.DateTime AEDAT { get; set; }

        /// <summary>
        /// AENAM(aenam) Field
        /// </summary>
        public System.String AENAM { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZPMF0014Model(ZPM_F0014) Proxy List Class
    /// </summary>    
    public class ZPMF0014ModelList  : List<ZPMF0014Model>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZPMF0014ModelList()
        {
            return;
        }
    }

}