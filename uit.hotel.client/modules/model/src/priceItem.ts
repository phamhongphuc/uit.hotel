import { duration } from 'moment';
import { GetBooking, PriceItemKindEnum } from '~/graphql/types';
import { toMoney } from '~/utils';

export class PriceItemObject {
    price: GetBooking.Price;
    priceItem: GetBooking.PriceItems;

    constructor(price: GetBooking.Price, priceItem: GetBooking.PriceItems) {
        this.price = price;
        this.priceItem = priceItem;
    }

    get amount() {
        const { timeSpan, kind } = this.priceItem;
        const time = duration(timeSpan, 'second');
        return parseFloat(
            {
                [PriceItemKindEnum.Hour]: () => time.asHours(),
                [PriceItemKindEnum.Night]: () => 1,
                [PriceItemKindEnum.Day]: () => time.add(2, 'hour').asDays(),
                [PriceItemKindEnum.Week]: () => time.add(2, 'hour').asWeeks(),
                [PriceItemKindEnum.Month]: () => time.add(2, 'hour').asMonths(),
            }
                [kind]()
                .toFixed(2),
        );
    }

    get unit() {
        const { kind } = this.priceItem;
        return {
            [PriceItemKindEnum.Hour]: 'giờ',
            [PriceItemKindEnum.Night]: 'đêm',
            [PriceItemKindEnum.Day]: 'ngày',
            [PriceItemKindEnum.Week]: 'tuần',
            [PriceItemKindEnum.Month]: 'tháng',
        }[kind];
    }

    get unitPrice() {
        const { price, priceItem } = this;
        return {
            [PriceItemKindEnum.Hour]: () => price.hourPrice,
            [PriceItemKindEnum.Night]: () => price.nightPrice,
            [PriceItemKindEnum.Day]: () => price.dayPrice,
            [PriceItemKindEnum.Week]: () => price.weekPrice,
            [PriceItemKindEnum.Month]: () => price.monthPrice,
        }[priceItem.kind]();
    }

    get total() {
        return this.priceItem.value;
    }

    get number() {
        return `${this.amount} ${this.unit}`;
    }

    get text() {
        const { unit, unitPrice, amount } = this;
        return `${amount} ${unit} ✕ ${toMoney(unitPrice)}`;
    }
}
