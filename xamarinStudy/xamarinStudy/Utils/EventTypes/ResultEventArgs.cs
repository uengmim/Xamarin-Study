using System;
using System.Collections.Generic;
using System.Text;

namespace NMAP.Utils
{
    /// <summary>
    /// 결과 이벤트 대리자
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    internal delegate void ResultEventHandler(object sender, ResultEventArgs e);

    /// <summary>
    /// 결과 이벤트 인수
    /// </summary>
    internal class ResultEventArgs : EventArgs
    {
        /// <summary>
        /// 성공여부
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 메시지
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="success">성공여부</param>
        /// <param name="message">메시지</param>
        public ResultEventArgs(bool success, string message)
        {
            IsSuccess= success;
            Message= message;
        }
    }
}
