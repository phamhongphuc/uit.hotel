import { BookingStatusEnum, GetBill, GetBills } from '~/graphql/types';

export const billStatusMap: {
    [key in BookingStatusEnum]: string;
} = {
    [BookingStatusEnum.Booked]: 'Tất cả các phòng đang chờ nhận',
    [BookingStatusEnum.CheckedIn]: 'Có phòng đang được sử dụng',
    [BookingStatusEnum.CheckedOut]: 'Tất cả các phòng đã trả',
};

export const getBillStatus = (bill: GetBill.Bill | GetBills.Bills) => {
    return (bill as GetBill.Bill).bookings
        .map(b => b.status)
        .reduce<BookingStatusEnum>((result, status, index) => {
            if (index === 0) return status;
            if (status !== result) return BookingStatusEnum.CheckedIn;
            return result;
        }, BookingStatusEnum.CheckedIn);
};
