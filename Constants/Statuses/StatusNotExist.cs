namespace NHNT.Constants.Statuses
{
    public class StatusNotExist : IStatusError
    {
        public static readonly StatusNotExist PROVINCE_ID = new StatusNotExist(420_001, "Id tỉnh này không tồn tại");
        public static readonly StatusNotExist USER_ID = new StatusNotExist(420_001, "Người dùng này không tồn tại (id)");
        public static readonly StatusNotExist REFRESH_TOKEN = new StatusNotExist(420_002, "Không tìm thấy refresh token trong cơ sở dữ liệu");


        //

        private int Code;
        private string Message;

        private StatusNotExist(int code, string message)
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