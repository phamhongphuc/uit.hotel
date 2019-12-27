using uit.hotel.Models;

namespace uit.hotel.PaymentHelper
{
    public class MomoGetTransactionStatusResponse
    {
        public string partnerCode { get; set; }
        public string accessKey { get; set; }
        public string requestId { get; set; }
        public string orderId { get; set; }
        public string requestType { get; set; }
        public string amount { get; set; }
        public string transId { get; set; }
        public string payType { get; set; }
        public int errorCode { get; set; }
        public string message { get; set; }
        public string localMessage { get; set; }
        public string extraData { get; set; }
        public string signature { get; set; }

        public MomoErrorCodeEnum errorCodeEnum => (MomoErrorCodeEnum)errorCode;

        public ReceiptStatusEnum statusEnum
        {
            get
            {
                switch (errorCodeEnum)
                {
                    // Success
                    case MomoErrorCodeEnum.Success:
                    case MomoErrorCodeEnum.TransactionWasPurchased:
                        return ReceiptStatusEnum.Success;

                    // Pending
                    case MomoErrorCodeEnum.TransactionInit:
                    case MomoErrorCodeEnum.PendingTransaction:
                    case MomoErrorCodeEnum.TransactionRefunded:
                        return ReceiptStatusEnum.Pending;

                    // Transaction wrong
                    case MomoErrorCodeEnum.TransactionCannotBeRefunded:
                    case MomoErrorCodeEnum.ExpiredTransaction:
                    case MomoErrorCodeEnum.OrderCancelledByUser:
                    case MomoErrorCodeEnum.TransactionDoesNotExist:
                    // Wrong or missing information
                    case MomoErrorCodeEnum.EmptyAccessKeyOrPartnerCode:
                    case MomoErrorCodeEnum.OrderIdIsInWrongFormat:
                    case MomoErrorCodeEnum.AmountIsInvalid:
                    case MomoErrorCodeEnum.SignatureIsWrong:
                    case MomoErrorCodeEnum.OrderIdExists:
                    case MomoErrorCodeEnum.DuplicatedRequestId:
                    case MomoErrorCodeEnum.RequestedIncorrectFormat:
                    case MomoErrorCodeEnum.ServiceDoesNotSupportYourRequest:
                    case MomoErrorCodeEnum.ErrorParsingBodyToJsonObject:
                    case MomoErrorCodeEnum.MissingRequestTypeField:
                        return ReceiptStatusEnum.Error;

                    // Error: Partner
                    case MomoErrorCodeEnum.PartnerIsNotActivated:
                    // Error: User
                    case MomoErrorCodeEnum.PayByBankSourceFailed:
                    case MomoErrorCodeEnum.InsufficientFunds:
                    case MomoErrorCodeEnum.CapsetExceeded:
                    case MomoErrorCodeEnum.UserFailedAuthentication:
                    case MomoErrorCodeEnum.UserDoesNotLinkBankAccount:
                    // Error: System
                    case MomoErrorCodeEnum.SystemMaintenance:
                    case MomoErrorCodeEnum.ErrorUndefined:
                    default:
                        return ReceiptStatusEnum.SystemError;
                }
            }
        }
    }
}
