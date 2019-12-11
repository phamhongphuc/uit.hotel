import { BookingStatusEnum } from '~/graphql/types';

export const billStatusMap: {
    [key in BookingStatusEnum]: string;
} = {
    [BookingStatusEnum.Booked]: 'Tất phòng đang chờ nhận',
    [BookingStatusEnum.CheckedIn]: 'Có phòng đang được sử dụng',
    [BookingStatusEnum.CheckedOut]: 'Tất cả phòng đã trả',
};
