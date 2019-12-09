import { Moment } from 'moment';
import { BookingStatusEnum } from '~/graphql/types';

export const bookingStatusMap: {
    [key in BookingStatusEnum]: string;
} = {
    [BookingStatusEnum.Booked]: 'Đã đặt phòng',
    [BookingStatusEnum.CheckedIn]: 'Đã nhận phòng',
    [BookingStatusEnum.CheckedOut]: 'Đã trả phòng',
};

export const bookingStatusIconMap: {
    [key in BookingStatusEnum]: [string, string];
} = {
    [BookingStatusEnum.Booked]: ['circle', 'orange'],
    [BookingStatusEnum.CheckedIn]: ['check-circle', 'green'],
    [BookingStatusEnum.CheckedOut]: ['disc', 'light'],
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
