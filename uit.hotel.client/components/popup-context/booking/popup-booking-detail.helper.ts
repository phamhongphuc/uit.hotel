import moment, { duration } from 'moment';
import _ from 'lodash';
import { getDate } from '~/utils';
import { GetBooking, PriceVolatilityItemKindEnum } from '~/graphql/types';
import {
    priceItemKindMap,
    priceItemGetAmount,
    priceItemGetUnitPrice,
} from '~/modules/model';

const getPrice = (groups: GetBooking.PriceVolatilityItems[]): number => {
    const { priceVolatility, kind } = groups[0];
    return {
        [PriceVolatilityItemKindEnum.Hour]: priceVolatility.hourPrice,
        [PriceVolatilityItemKindEnum.Night]: priceVolatility.nightPrice,
        [PriceVolatilityItemKindEnum.Day]: priceVolatility.dayPrice,
    }[kind];
};

export interface PriceItemRender {
    name: string;
    number: string;
    unitPrice: number;
    total: number;
}

export const getPriceItems = (
    booking: GetBooking.Booking,
): PriceItemRender[] => {
    const left = getDate(booking.realCheckInTime, booking.bookCheckInTime);
    const right = getDate(booking.realCheckOutTime, booking.bookCheckOutTime);
    const lateCheckOutHour = parseFloat(
        duration(moment(right).diff(booking.baseDayCheckOutTime))
            .asHours()
            .toFixed(2),
    );
    const earlyCheckInHour = parseFloat(
        duration(moment(booking.baseNightCheckInTime).diff(left))
            .asHours()
            .toFixed(2),
    );

    const priceItems = booking.priceItems.map(p => ({
        name: `Thuê theo ${priceItemKindMap[p.kind]}`,
        number: `${priceItemGetAmount(p)} ${priceItemKindMap[p.kind]}`,
        unitPrice: priceItemGetUnitPrice(booking, p),
        total: p.value,
    }));
    const priceVolatilityItems = _.map(
        _.groupBy(
            booking.priceVolatilityItems,
            item => `${item.priceVolatility.id}-${item.kind}`,
        ),
        group => ({
            name: group[0].priceVolatility.name,
            number: `${group.length} ${priceItemKindMap[group[0].kind]} `,
            unitPrice: getPrice(group),
            total: group.reduce((sum, item) => sum + item.value, 0),
        }),
    );
    const earlyCheckInFeeItem = {
        name: 'Phí nhận phòng sớm',
        number: `${earlyCheckInHour} giờ`,
        unitPrice: booking.price.earlyCheckInFee,
        total: booking.earlyCheckInFee,
    };
    const lateCheckOutFeeItem = {
        name: 'Phí trả phòng trễ',
        number: `${lateCheckOutHour} giờ`,
        unitPrice: booking.price.lateCheckOutFee,
        total: booking.lateCheckOutFee,
    };

    return [
        ...priceItems,
        ...priceVolatilityItems,
        earlyCheckInFeeItem,
        lateCheckOutFeeItem,
    ].filter(item => item.total !== 0);
};
