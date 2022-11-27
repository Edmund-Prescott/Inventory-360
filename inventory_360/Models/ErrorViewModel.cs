namespace inventory_360.Models
{
    public class ErrorViewModel
    {
        public int id { get; set; }
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}