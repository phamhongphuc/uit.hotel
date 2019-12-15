import { GetBill } from '~/graphql/types';
import { getDate, toDateTime } from '~/utils';

export const checkIn = (booking: GetBill.Bookings) =>
    toDateTime(getDate(booking.realCheckInTime, booking.bookCheckInTime));

export const checkOut = (booking: GetBill.Bookings) =>
    toDateTime(getDate(booking.realCheckOutTime, booking.bookCheckOutTime));
