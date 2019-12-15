import { GetBill } from '~/graphql/types';
import { getDate, toDateTime } from '~/utils';

export const checkInFormatter = (
    value: null,
    key: 'checkIn',
    booking: GetBill.Bookings,
) => toDateTime(getDate(booking.realCheckInTime, booking.bookCheckInTime));

export const checkOutFormatter = (
    value: null,
    key: 'checkOut',
    booking: GetBill.Bookings,
) => toDateTime(getDate(booking.realCheckOutTime, booking.bookCheckOutTime));
