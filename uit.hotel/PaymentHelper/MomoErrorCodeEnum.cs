using System.ComponentModel;

namespace uit.hotel.PaymentHelper
{
    public enum MomoErrorCodeEnum
    {
        // Success
        [Description("Giao dịch khởi tạo")] TransactionInit = -1,
        [Description("Thành công")] Success = 0,
        [Description("Giao dịch đã được thanh toán")] TransactionWasPurchased = 32,

        // Pending
        [Description("Giao dịch đang chờ xử lý")] PendingTransaction = 7,
        [Description("Giao dịch hoàn tiền đã được xử lý")] TransactionRefunded = 34,

        // Transaction wrong
        [Description("Giao dịch không thể refund")] TransactionCannotBeRefunded = 33,
        [Description("Giao dịch đã hết hạn")] ExpiredTransaction = 36,
        [Description("Khách hàng huỷ giao dịch")] OrderCancelledByUser = 49,
        [Description("Giao dịch không tồn tại")] TransactionDoesNotExist = 58,

        // Wrong or missing information
        [Description("Thiếu thông tin đối tác")] EmptyAccessKeyOrPartnerCode = 1,
        [Description("OrderId sai định dạng")] OrderIdIsInWrongFormat = 2,
        [Description("Số tiền thanh toán không hợp lệ")] AmountIsInvalid = 4,
        [Description("Chữ ký không hợp lệ")] SignatureIsWrong = 5,
        [Description("Đơn hàng đã tồn tại")] OrderIdExists = 6,
        [Description("Yêu cầu đã tồn tại")] DuplicatedRequestId = 12,
        [Description("Yêu cầu không đúng định dạng")] RequestedIncorrectFormat = 42,
        [Description("Dịch vụ không hỗ trợ yêu cầu của bạn")] ServiceDoesNotSupportYourRequest = 44,
        [Description("Yêu cầu không hợp lệ")] ErrorParsingBodyToJsonObject = 59,
        [Description("Thiếu field requestType trong HTTP Request Body")] MissingRequestTypeField = 76,

        // Error: Partner
        [Description("Đối tác chưa được kích hoạt")] PartnerIsNotActivated = 14,

        // Error: User
        [Description("Thanh toán bằng nguồn ngân hàng không thành công")] PayByBankSourceFailed = 63,
        [Description("Tài khoản khách hàng không đủ tiền")] InsufficientFunds = 38,
        [Description("Tài khoản hết hạn mức giao dịch trong ngày")] CapsetExceeded = 37,
        [Description("Xác thực khách hàng không thành công")] UserFailedAuthentication = 80,
        [Description("Khách hàng chưa liên kết tài khoản ngân hàng")] UserDoesNotLinkBankAccount = 9043,

        // Error: System
        [Description("Hệ thống đang bảo trì")] SystemMaintenance = 29,
        [Description("Lỗi không xác định (Lỗi hệ thống)")] ErrorUndefined = 99,
    }
}
