import { duration, Duration } from 'moment';
import { GetBookingDetails, PriceItemKindEnum } from '~/graphql/types';
import { toMoney } from '~/utils';

const kindMap: {
    [key in PriceItemKindEnum]: string;
} = {
    [PriceItemKindEnum.Hour]: 'giờ',
    [PriceItemKindEnum.Night]: 'đêm',
    [PriceItemKindEnum.Day]: 'ngày',
    [PriceItemKindEnum.Week]: 'tuần',
    [PriceItemKindEnum.Month]: 'tháng',
};

const getAmountMap = (
    time: Duration,
): { [key in PriceItemKindEnum]: () => number } => ({
    [PriceItemKindEnum.Hour]: () => time.asHours(),
    [PriceItemKindEnum.Night]: () => 1,
    [PriceItemKindEnum.Day]: () => time.add(2, 'hour').asDays(),
    [PriceItemKindEnum.Week]: () => time.add(2, 'hour').asWeeks(),
    [PriceItemKindEnum.Month]: () => time.add(2, 'hour').asMonths(),
});

const getUnitPriceMap = (
    price: GetBookingDetails.Price,
): { [key in PriceItemKindEnum]: () => number } => ({
    [PriceItemKindEnum.Hour]: () => price.hourPrice,
    [PriceItemKindEnum.Night]: () => price.nightPrice,
    [PriceItemKindEnum.Day]: () => price.dayPrice,
    [PriceItemKindEnum.Week]: () => price.weekPrice,
    [PriceItemKindEnum.Month]: () => price.monthPrice,
});

export function getPriceItemText(
    booking: GetBookingDetails.Booking,
    priceItem: GetBookingDetails.PriceItems,
) {
    const unit = kindMap[priceItem.kind];
    const unitPrice = getUnitPriceMap(booking.price)[priceItem.kind]();
    const number = parseFloat(
        getAmountMap(duration(priceItem.timeSpan, 'second'))
            [priceItem.kind]()
            .toFixed(2),
    );

    return `${number} ${unit} ✕ ${toMoney(unitPrice)}`;
}
