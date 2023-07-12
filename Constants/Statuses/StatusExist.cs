namespace NHNT.Constants.Statuses
{
    public class StatusExist : IStatusError
    {
        public static readonly StatusExist STATUS = new StatusExist(410_001, "");


        //

        private int Code;
        private string Message;

        private StatusExist(int code, string message)
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