namespace backendAPI.Models
{
    public class Wafer
    {
        public int Id { get; set; }
        public string WaferId { get; set; }
        public string WaferType { get; set; }
        public string WaferSize { get; set; }
        public string WaferStatus { get; set; }
        public string WaferLocation { get; set; }
        public string WaferOwner { get; set; }
        public string WaferComment { get; set; }
        public string WaferImage { get; set; }
    }
}