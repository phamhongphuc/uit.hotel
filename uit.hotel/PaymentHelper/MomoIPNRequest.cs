using System;
using System.Web;

namespace uit.hotel.PaymentHelper
{
    public class MomoIPNRequest
    {
        public string partnerCode { get; set; }
        public string accessKey { get; set; }
        public string requestId { get; set; }
        public string amount { get; set; }
        public string orderId { get; set; }
        public string orderInfo { get; set; }
        public string orderType { get; set; }
        public string transId { get; set; }
        public int errorCode { get; set; }
        public string message { get; set; }
        public string localMessage { get; set; }
        public string payType { get; set; }
        public string responseTime { get; set; }
        public string extraData { get; set; }
        public string signature { get; set; }

        public int ReceiptId => Int32.Parse(HttpUtility.ParseQueryString(extraData)["id"]);
    }
}
