namespace VillaApplication.Model.Data
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }

        public ErrorResponse(int errorCode, string message)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }
    }
}
