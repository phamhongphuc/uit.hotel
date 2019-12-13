import { duration, Duration } from 'moment';
import { GetBooking, PriceItemKindEnum } from '~/graphql/types';
import { toMoney } from '~/utils';

export const priceItemKindMap: {
    [key in PriceItemKindEnum]: string;
} = {
    [PriceItemKindEnum.Hour]: 'giờ',
    [PriceItemKindEnum.Night]: 'đêm',
    [PriceItemKindEnum.Day]: 'ngày',
    [PriceItemKindEnum.Week]: 'tuần',
    [PriceItemKindEnum.Month]: 'tháng',
};

const priceItemGetAmountMap = (
    time: Duration,
): { [key in PriceItemKindEnum]: () => number } => ({
    [PriceItemKindEnum.Hour]: () => time.asHours(),
    [PriceItemKindEnum.Night]: () => 1,
    [PriceItemKindEnum.Day]: () => time.add(2, 'hour').asDays(),
    [PriceItemKindEnum.Week]: () => time.add(2, 'hour').asWeeks(),
    [PriceItemKindEnum.Month]: () => time.add(2, 'hour').asMonths(),
});

const priceItemGetUnitPriceMap = (
    price: GetBooking.Price,
): { [key in PriceItemKindEnum]: () => number } => ({
    [PriceItemKindEnum.Hour]: () => price.hourPrice,
    [PriceItemKindEnum.Night]: () => price.nightPrice,
    [PriceItemKindEnum.Day]: () => price.dayPrice,
    [PriceItemKindEnum.Week]: () => price.weekPrice,
    [PriceItemKindEnum.Month]: () => price.monthPrice,
});

export const priceItemGetAmount = (priceItem: GetBooking.PriceItems) =>
    parseFloat(
        priceItemGetAmountMap(duration(priceItem.timeSpan, 'second'))
            [priceItem.kind]()
            .toFixed(2),
    );

export const priceItemGetUnitPrice = (
    booking: GetBooking.Booking,
    priceItem: GetBooking.PriceItems,
) => priceItemGetUnitPriceMap(booking.price)[priceItem.kind]();

export function getPriceItemText(
    booking: GetBooking.Booking,
    priceItem: GetBooking.PriceItems,
) {
    const unit = priceItemKindMap[priceItem.kind];
    const unitPrice = priceItemGetUnitPriceMap(booking.price)[priceItem.kind]();
    const number = priceItemGetAmount(priceItem);

    return `${number} ${unit} ✕ ${toMoney(unitPrice)}`;
}
