using System;
using System.Collections.Generic;
using System.Text;

namespace WebEDI.Common.Core
{
    public class ErrorMapping : ErrorMappingBase<ErrorMapping.ErrorCodes>
    {
        private static ErrorMapping _current;
        public static ErrorMapping Current
        {
            get { return _current ?? (_current = new ErrorMapping()); }
        }
        protected override void InitErrorMapping()
        {
            InnerHashtable[ErrorCodes.UpdateAccountInvalidUsername] = "Tên đăng nhập không hợp lệ";
            InnerHashtable[ErrorCodes.UpdateAccountInvalidPassword] = "Mật khẩu không hợp lệ";
            InnerHashtable[ErrorCodes.UpdateAccountInvalidRetypePassword] = "Mật khẩu nhập lại không chính xác";
            InnerHashtable[ErrorCodes.UpdateAccountInvalidSuccess] = "Đăng nhập thành công";
        }
        public enum ErrorCodes
        {
            UpdateAccountUserNotFound = 01000,
            UpdateAccountInvalidUsername = 01001,
            UpdateAccountInvalidPassword = 01002,
            UpdateAccountInvalidRetypePassword = 01003,
            UpdateAccountUsernameExists = 01004,
            UpdateAccountInvalidSuccess=01005,

        }
    }
}
