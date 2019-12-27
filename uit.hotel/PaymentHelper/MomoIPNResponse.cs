namespace uit.hotel.PaymentHelper
{
    public class MomoIPNResponse
    {
        public string partnerCode { get; set; }
        public string accessKey { get; set; }
        public string requestId { get; set; }
        public string orderId { get; set; }
        public int errorCode { get; set; }
        public string message { get; set; }
        public string responseTime { get; set; }
        public string extraData { get; set; }
        public string signature { get; set; }
        public int receiptId { get; set; }
    }
}
