using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using uit.hotel.Models;
using uit.hotel.PaymentHelper;
using uit.hotel.Queries.Authentication;
using uit.hotel.Queries.Helper;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace uit.hotel.Businesses
{
    public static class ReceiptBusinessHelper
    {
        public static string PartnerCode => Constant.MomoPartnerCode;
        public static string AccessKey => Constant.MomoAccessKey;
        public static string SecretKey => Constant.MomoSecretKey;
        public static string NotifyUrl => Constant.MomoNotifyUrl;
        public static string ReturnUrl = "https://momo.vn";

        public static string Endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";

        public static string GetMomoPayUrl(this Receipt receipt)
        {
            var requestType = "captureMoMoWallet";
            var signature = string.Join(
                "&",
                $"partnerCode={PartnerCode}",
                $"accessKey={AccessKey}",
                $"requestId={receipt.RequestId}",
                $"amount={receipt.Money}",
                $"orderId={receipt.OrderId}",
                $"orderInfo={receipt.OrderInfo}",
                $"returnUrl={ReturnUrl}",
                $"notifyUrl={NotifyUrl}",
                $"extraData={receipt.ExtraData}"
            ).EncryptSHA256(SecretKey);

            var json = new JObject
            {
                { "partnerCode", PartnerCode },
                { "accessKey", AccessKey },
                { "returnUrl", ReturnUrl },
                { "notifyUrl", NotifyUrl },
                { "amount", receipt.Money.ToString() },
                { "requestId", receipt.RequestId },
                { "orderId", receipt.OrderId },
                { "orderInfo", receipt.OrderInfo },
                { "extraData", receipt.ExtraData },
                { "requestType", requestType },
                { "signature", signature }
            }.ToString();

            var response = Request<MomoGetPayUrlResponse>(json, Endpoint);
            if (response.errorCode != 0)
                throw new Exception(json + "\n\n" + response.localMessage);

            return response.payUrl;
        }

        public static MomoIPNResponse GetMomoIPNResponse(this Receipt receipt)
        {
            var responseTime = DateTimeOffset.Now.ToOffset(Constant.TimeZone).ToString("YYYY-MM-DD HH:mm:ss");
            var message = "Cập nhật thanh toán thành công";
            var signature = string.Join(
                "&",
                $"partnerCode={PartnerCode}",
                $"accessKey={AccessKey}",
                $"requestId={receipt.RequestId}",
                $"orderId={receipt.OrderId}",
                $"errorCode={0}",
                $"message={message}",
                $"responseTime={responseTime}",
                $"extraData={receipt.ExtraData}"
            ).EncryptSHA256(SecretKey);

            return new MomoIPNResponse()
            {
                partnerCode = PartnerCode,
                accessKey = AccessKey,
                requestId = receipt.RequestId,
                orderId = receipt.OrderId,
                errorCode = 0,
                message = message,
                responseTime = responseTime,
                extraData = receipt.ExtraData,
                signature = signature,
            };
        }

        public static MomoGetTransactionStatusResponse GetTransactionStatus(this Receipt receipt)
        {
            var requestType = "transactionStatus";
            var signature = string.Join(
                "&",
                $"partnerCode={PartnerCode}",
                $"accessKey={AccessKey}",
                $"requestId={receipt.RequestId}",
                $"orderId={receipt.OrderId}",
                $"requestType={requestType}"
            ).EncryptSHA256(SecretKey);

            var json = new JObject
            {
                { "partnerCode", PartnerCode },
                { "accessKey", AccessKey },
                { "requestId", receipt.RequestId },
                { "orderId", receipt.OrderId },
                { "requestType", requestType },
                { "signature", signature }
            }.ToString();

            return Request<MomoGetTransactionStatusResponse>(json, Endpoint);
        }

        private static T Request<T>(string json, string endpoint)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(endpoint);
                request.ProtocolVersion = HttpVersion.Version11;
                request.Method = Http.Post;
                request.ContentType = Application.Json;
                request.ContentLength = json.ToBytes().Length;
                request.ReadWriteTimeout = 30000;
                request.Timeout = 15000;

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    streamWriter.Write(json);

                var response = (HttpWebResponse)request.GetResponse();

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch (WebException error) { throw error; }
        }
    }
}
