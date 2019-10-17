using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WebEDI.Common.Core
{
    public abstract class ErrorMappingBase<T> : DictionaryBase
    {
        public string this[T code]
        {
            get
            {
                return InnerHashtable.ContainsKey(code)
                           ? InnerHashtable[code].ToString()
                           : "Không tìm thấy thông tin ứng với mã lỗi";
            }
        }
        protected abstract void InitErrorMapping();

        protected ErrorMappingBase()
        {
            #region General error

            InnerHashtable[ErrorCodeBase.Success] = "Xử lý thành công";
            InnerHashtable[ErrorCodeBase.UnknowError] = "Lỗi không xác định";
            InnerHashtable[ErrorCodeBase.Exception] = "Lỗi trong quá trình xử lý";
            InnerHashtable[ErrorCodeBase.BusinessError] = "Lỗi nghiệp vụ";
            InnerHashtable[ErrorCodeBase.InvalidRequest] = "Yêu cầu không hợp lệ";
            InnerHashtable[ErrorCodeBase.TimeOutSession] = "Phiên làm việc của bạn đã hết.";

            #endregion

            InitErrorMapping();
        }
        public enum ErrorCodeBase
        {
            #region General error

            Success = 0,
            UnknowError = 9999,
            Exception = 9998,
            BusinessError = 9997,
            InvalidRequest = 9996,
            TimeOutSession = -100,

            #endregion
        }
    }
}
