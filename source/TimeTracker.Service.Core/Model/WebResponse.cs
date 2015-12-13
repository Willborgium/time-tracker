namespace TimeTracker.Service.Core.Model
{
    public class WebResponse
    {
        public bool HasError { get; set; }

        public string ErrorDetails { get; set; }
    }

    public class WebResponse<T> : WebResponse
    {
        public T Data { get; set; }
    }
}