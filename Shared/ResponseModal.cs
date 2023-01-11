namespace CDPModule1.Shared
{
    public class ResponseModal
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }

    }

    public class DataResponseModal
    {
        public int StatusCode { get; set; }
        public List<List<string>> Data { get; set; }
        public string Message { get; set; }

    }
}
