using System;
using System.Collections.Generic;
using System.Text;
using static WebEDI.Common.EnumExtensions;

namespace WebEDI.Common
{
    public enum ErrorCodes
    {
        None,

        /// <summary>
        /// Error when 2 user modifies the same data at the same time
        /// </summary>
        [ResourceKey(Key = "E.SS_WE000010.001")]
        DBConnectionFailed,
        /// <summary>
        /// Fail to saving data to database
        /// </summary>
        [ResourceKey(Key = "E.SS_WE000010.002")]
        AccountInvalidUsername,
        [ResourceKey(Key = "E.SS_WE000010.003")]
        AccountInvalidPassWord,
        [ResourceKey(Key = "I.SS_WE000010.004")]
        AccountInvalidSuccess,
        [ResourceKey(Key = "E.SS_WE000004.002")]
        SendMailFail,
        [ResourceKey(Key = "E.SS_WE000004.001")]
        SearchOrderFail,

    }
}
