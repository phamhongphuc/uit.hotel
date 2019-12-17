import moment, { duration, Moment } from 'moment';
import _ from 'lodash';
import { PriceItemObject } from './priceItem';
import { PriceVolatilityItemObject } from './priceVolatilityItem';
import { BookingStatusEnum, GetBooking } from '~/graphql/types';
import { getDate } from '~/utils';

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

export interface PriceItemRender {
    name?: string;
    left: Moment;
    right: Moment;
    text: string;
    value: number;
    line: number;
}

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

export class BookingObject {
    booking: GetBooking.Booking;

    constructor(booking: GetBooking.Booking) {
        this.booking = booking;
    }

    get lateCheckOutHour() {
        const { booking, right } = this;
        return parseFloat(
            duration(moment(right).diff(booking.baseDayCheckOutTime))
                .asHours()
                .toFixed(2),
        );
    }

    get earlyCheckInHour() {
        const { booking, left } = this;
        return parseFloat(
            duration(moment(booking.baseNightCheckInTime).diff(left))
                .asHours()
                .toFixed(2),
        );
    }

    get remain() {
        const {
            left,
            right,
            booking: { status },
        } = this;

        return {
            [BookingStatusEnum.Booked]() {
                return `Còn ${left.fromNow(true)} trước khi nhận phòng.`;
            },
            [BookingStatusEnum.CheckedIn]() {
                return `Còn ${right.fromNow(true)} trước khi trả phòng.`;
            },
            [BookingStatusEnum.CheckedOut]() {
                return `Đã trả phòng ${right.fromNow(true)} trước.`;
            },
        }[status]();
    }

    get left() {
        return getDate(
            this.booking.realCheckInTime,
            this.booking.bookCheckInTime,
        );
    }

    get right() {
        return getDate(
            this.booking.realCheckOutTime,
            this.booking.bookCheckOutTime,
        );
    }

    get priceItemsRender(): PriceItemRender[] {
        const { baseNightCheckInTime, priceItems, price } = this.booking;
        let iterate = moment(baseNightCheckInTime);

        return priceItems.map(priceItem => {
            const left = iterate.clone();
            const right = iterate.clone().add(priceItem.timeSpan, 'second');
            const { text } = new PriceItemObject(price, priceItem);
            const { value } = priceItem;

            iterate = right.clone().add(2, 'hour');

            return { left, right, text, value, line: 1 };
        });
    }

    get priceVolatilityItemsRender(): PriceItemRender[] {
        const { priceVolatilityItems } = this.booking;
        return _.chain(priceVolatilityItems)
            .groupBy(item => item.priceVolatility.id)
            .values()
            .map((items, index) =>
                items.map(item => new PriceVolatilityItemObject(item, index)),
            )
            .flatMap()
            .map(
                ({
                    left,
                    right,
                    text,
                    item: {
                        value,
                        priceVolatility: { name },
                    },
                    line,
                }) => ({ left, right, text, value, line, name }),
            )
            .value();
    }
}
