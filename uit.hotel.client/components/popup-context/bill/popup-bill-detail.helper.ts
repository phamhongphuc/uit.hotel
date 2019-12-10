import { GetBill } from '~/graphql/types';
import { getDate, toDate } from '~/utils';

export const checkIn = (booking: GetBill.Bookings) =>
    toDate(getDate(booking.realCheckInTime, booking.bookCheckInTime));

export const checkOut = (booking: GetBill.Bookings) =>
    toDate(getDate(booking.realCheckOutTime, booking.bookCheckOutTime));
