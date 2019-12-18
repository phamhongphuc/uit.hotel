import _ from 'lodash';
import {
    BookingObject,
    PriceItemObject,
    PriceVolatilityItemObject,
} from '~/modules/model';
import { GetBooking } from '~/graphql/types';

export enum PriceItemTableRenderKindEnum {
    Fee = 'red',
    Price = 'blue',
    PriceVolatility = 'green',
}

export interface PriceItemTableRender {
    name: string;
    number: string;
    unitPrice: number;
    total: number;
    kind: PriceItemTableRenderKindEnum;
    tooltip: string;
}

export const getPriceItems = (
    booking: GetBooking.Booking,
): PriceItemTableRender[] => {
    const object = new BookingObject(booking);

    const priceItems: PriceItemTableRender[] = booking.priceItems
        .map(priceItem => new PriceItemObject(booking.price, priceItem))
        .map(({ unit, number, unitPrice, total }) => ({
            name: `Thuê theo ${unit}`,
            number,
            unitPrice,
            total,
            kind: PriceItemTableRenderKindEnum.Price,
            tooltip: 'Giá cơ bản',
        }));
    const priceVolatilityItems: PriceItemTableRender[] = _.chain(
        booking.priceVolatilityItems,
    )
        .groupBy(item => `${item.priceVolatility.id}-${item.kind}`)
        .map(items => new PriceVolatilityItemObject(items))
        .map(({ name, number, unitPrice, total }) => ({
            name,
            number,
            unitPrice,
            total,
            kind: PriceItemTableRenderKindEnum.PriceVolatility,
            tooltip: 'Giá biến động',
        }))
        .value();
    const earlyCheckInFeeItem: PriceItemTableRender = {
        name: 'Phí nhận phòng sớm',
        number: `${object.earlyCheckInHour} giờ`,
        unitPrice: booking.price.earlyCheckInFee,
        total: booking.earlyCheckInFee,
        kind: PriceItemTableRenderKindEnum.Fee,
        tooltip: 'Phụ phí',
    };
    const lateCheckOutFeeItem: PriceItemTableRender = {
        name: 'Phí trả phòng trễ',
        number: `${object.lateCheckOutHour} giờ`,
        unitPrice: booking.price.lateCheckOutFee,
        total: booking.lateCheckOutFee,
        kind: PriceItemTableRenderKindEnum.Fee,
        tooltip: 'Phụ phí',
    };

    return [
        ...priceItems,
        ...priceVolatilityItems,
        earlyCheckInFeeItem,
        lateCheckOutFeeItem,
    ].filter(item => item.total !== 0);
};
