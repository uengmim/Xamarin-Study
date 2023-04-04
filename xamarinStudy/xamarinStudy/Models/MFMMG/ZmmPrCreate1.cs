// iMATE Auto generator Code
// (C)Copyright 2022 ISTN
// RUN : imatecc gen_md -title DS4 -object "ZMM_PR_CREATE_1" -output "ZmmPrCreate1.cs" -nspace "NAMHE.Model" -mtype "proxy" -serial "field"

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
    /// ZMMPRCREATE1Model(ZMM_PR_CREATE_1) Proxy class
    /// </summary>
    public class ZMMPRCREATE1Model
    {
        /// <summary>
        /// ES_RETURN(eSReturn) Field
        /// </summary>
        public ZMMS0090Model ES_RETURN{ get; set; }

        /// <summary>
        /// I_EEIND(iEeind) Field
        /// </summary>
        public System.DateTime I_EEIND { get; set; }

        /// <summary>
        /// I_MATNR(iMatnr) Field
        /// </summary>
        public System.String I_MATNR { get; set; }

        /// <summary>
        /// I_MENGE(iMenge) Field
        /// </summary>
        public System.Decimal I_MENGE { get; set; }

        /// <summary>
        /// I_WERKS(iWerks) Field
        /// </summary>
        public System.String I_WERKS { get; set; }

        /// <summary>
        /// ET_RETURN(eTReturn) Field
        /// </summary>
        public IList<BAPIRET2Model> ET_RETURN
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
    /// ZMMS0090Model(ZMMS0090) Proxy class
    /// </summary>
    public class ZMMS0090Model
    {
        /// <summary>
        /// TYPE(type) Field
        /// </summary>
        public System.String TYPE { get; set; }

        /// <summary>
        /// MESSAGE(message) Field
        /// </summary>
        public System.String MESSAGE { get; set; }

        /// <summary>
        /// BANFN(banfn) Field
        /// </summary>
        public System.String BANFN { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }
/// <summary>
    /// BAPIRET2Model(BAPIRET2) Proxy class
    /// </summary>
    public class BAPIRET2Model
    {
        /// <summary>
        /// TYPE(type) Field
        /// </summary>
        public System.String TYPE { get; set; }

        /// <summary>
        /// ID(id) Field
        /// </summary>
        public System.String ID { get; set; }

        /// <summary>
        /// NUMBER(number) Field
        /// </summary>
        public System.String NUMBER { get; set; }

        /// <summary>
        /// MESSAGE(message) Field
        /// </summary>
        public System.String MESSAGE { get; set; }

        /// <summary>
        /// LOG_NO(lOGNo) Field
        /// </summary>
        public System.String LOG_NO { get; set; }

        /// <summary>
        /// LOG_MSG_NO(lOGMSGNo) Field
        /// </summary>
        public System.String LOG_MSG_NO { get; set; }

        /// <summary>
        /// MESSAGE_V1(mESSAGEV1) Field
        /// </summary>
        public System.String MESSAGE_V1 { get; set; }

        /// <summary>
        /// MESSAGE_V2(mESSAGEV2) Field
        /// </summary>
        public System.String MESSAGE_V2 { get; set; }

        /// <summary>
        /// MESSAGE_V3(mESSAGEV3) Field
        /// </summary>
        public System.String MESSAGE_V3 { get; set; }

        /// <summary>
        /// MESSAGE_V4(mESSAGEV4) Field
        /// </summary>
        public System.String MESSAGE_V4 { get; set; }

        /// <summary>
        /// PARAMETER(parameter) Field
        /// </summary>
        public System.String PARAMETER { get; set; }

        /// <summary>
        /// ROW(row) Field
        /// </summary>
        public System.Int32 ROW { get; set; }

        /// <summary>
        /// FIELD(field) Field
        /// </summary>
        public System.String FIELD { get; set; }

        /// <summary>
        /// SYSTEM(system) Field
        /// </summary>
        public System.String SYSTEM { get; set; }

   
        /// <summary>
        /// 모델의 상태
        /// </summary>
        public DIMModelStatus ModelStatus { get; set; }

    }

/// <summary>
    /// ZMMPRCREATE1Model(ZMM_PR_CREATE_1) Proxy List Class
    /// </summary>    
    public class ZMMPRCREATE1ModelList  : List<ZMMPRCREATE1Model>
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ZMMPRCREATE1ModelList()
        {
            return;
        }
    }

}