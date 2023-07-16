namespace NHNT.Constants.Statuses
{
    public class StatusWrongFormat : IStatusError
    {
        public static readonly StatusWrongFormat USER_IS_NULL = new StatusWrongFormat(430_001, "Không thể tương tác với user bị null");
        public static readonly StatusWrongFormat USERNAME_OR_PASSWORD_WRONG_FROMAT = new StatusWrongFormat(430_002, "Tên tài khoản hoặc mật khẩu không đúng");
        public static readonly StatusWrongFormat ACCESS_TOKEN_EMPTY = new StatusWrongFormat(430_003, "Access token đang bị rỗng");
        public static readonly StatusWrongFormat REFRESH_TOKEN_EMPTY = new StatusWrongFormat(430_004, "Refresh token đang bị rỗng");
        public static readonly StatusWrongFormat REFRESH_TOKEN_IS_REVOKED = new StatusWrongFormat(430_005, "Refresh token này đã bị hủy bỏ");
        public static readonly StatusWrongFormat ACCESS_TOKEN_ID_NOT_MATCH_JTI = new StatusWrongFormat(430_006, "Access token id không khớp với refesh token");
        public static readonly StatusWrongFormat USERNAME_IS_EMPTY = new StatusWrongFormat(430_007, "Thông tin người dùng không thấy (username = null)");
        public static readonly StatusWrongFormat ROLE_IS_NULL = new StatusWrongFormat(430_008, "Không thể tương tác với role bị null");
        public static readonly StatusWrongFormat DEPARTMENT_IS_NULL = new StatusWrongFormat(430_009, "Không thể tương tác với department bị null");
        public static readonly StatusWrongFormat DEPARTMENT_GROUP_IS_NULL = new StatusWrongFormat(430_010, "Không thể tương tác với department group bị null");
        public static readonly StatusWrongFormat IMAGE_IS_NULL = new StatusWrongFormat(430_011, "Không thể tương tác với image bị null");


        //

        private int Code;
        private string Message;

        private StatusWrongFormat(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int GetCode()
        {
            return this.Code;
        }

        public string GetMessage()
        {
            return this.Message;
        }
    }
}