using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.hotel.DataAccesses;
using uit.hotel.Models;
using uit.hotel.PaymentHelper;

namespace uit.hotel.Businesses
{
    public static class ReceiptBusiness
    {
        public static async Task<Receipt> Add(Employee employee, Receipt receipt)
        {
            if (receipt.Money == 0)
                throw new Exception("Số tiền nhập vào phải khác 0");
            receipt.Bill = receipt.Bill.GetManaged();
            receipt.Employee = employee;
            receipt.PayUrl = "";

            switch (receipt.Kind)
            {
                case ReceiptKindEnum.Momo:
                    if (receipt.Money < 0)
                        throw new Exception("Hệ thống hiện chỉ cho phép hoàn tiền mặt");
                    receipt.Status = ReceiptStatusEnum.Pending;
                    receipt.StatusText = "";
                    receipt = await ReceiptDataAccess.Add(receipt);
                    receipt = await ReceiptDataAccess.UpdatePayUrl(receipt, receipt.GetMomoPayUrl());
                    await Check(receipt);
                    break;
                case ReceiptKindEnum.Cash:
                    receipt.Status = ReceiptStatusEnum.Success;
                    receipt.StatusText = "Đã thanh toán";
                    receipt = await ReceiptDataAccess.Add(receipt);
                    break;
            }

            return receipt;
        }

        public static Task<Receipt> MomoNotified(MomoIPNRequest parameter)
        {
            var receipt = Get(parameter.ReceiptId);
            if (receipt == null)
                throw new Exception($"Không tìm thấy phiếu thu có id là: {parameter.ReceiptId}");

            return Check(receipt);
        }

        public static Task<Receipt> Check(int receiptId)
            => Check(Get(receiptId));

        public static async Task<Receipt> Check(Receipt receipt)
        {
            receipt = receipt.GetManaged();

            switch (receipt.Kind)
            {
                case ReceiptKindEnum.Momo:
                    var transactionStatus = receipt.GetTransactionStatus();
                    await ReceiptDataAccess.UpdateStatus(
                        receipt,
                        transactionStatus.statusEnum,
                        transactionStatus.localMessage
                    );
                    break;
                case ReceiptKindEnum.Cash:
                    //? Nothing to check
                    break;
            }

            return receipt;
        }

        public static Receipt Get(int receiptId) => ReceiptDataAccess.Get(receiptId);

        public static IEnumerable<Receipt> Get() => ReceiptDataAccess.Get();
    }
}
