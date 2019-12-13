import { Moment } from 'moment';
import { BookingStatusEnum } from '~/graphql/types';

export const bookingStatusMap: {
    [key in BookingStatusEnum]: string;
} = {
    [BookingStatusEnum.Booked]: 'Phòng đang chờ nhận',
    [BookingStatusEnum.CheckedIn]: 'Phòng đã nhận',
    [BookingStatusEnum.CheckedOut]: 'Phòng đã trả',
};

export const bookingStatusColorMap: {
    [key in BookingStatusEnum]: string;
} = {
    [BookingStatusEnum.Booked]: 'yellow',
    [BookingStatusEnum.CheckedIn]: 'green',
    [BookingStatusEnum.CheckedOut]: 'light',
};

export const bookingStatusRemainMap = (
    left: Moment,
    right: Moment,
): {
    [key in BookingStatusEnum]: () => string;
} => ({
    [BookingStatusEnum.Booked]: () =>
        `Còn ${left.fromNow(true)} trước khi nhận phòng.`,

    [BookingStatusEnum.CheckedIn]: () =>
        `Còn ${right.fromNow(true)} trước khi trả phòng.`,

    [BookingStatusEnum.CheckedOut]: () =>
        `Đã trả phòng ${right.fromNow(true)} trước.`,
});
