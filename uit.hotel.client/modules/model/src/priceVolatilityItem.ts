import moment, { duration } from 'moment';
import { GetBooking, PriceVolatilityItemKindEnum } from '~/graphql/types';
import { toMoney } from '~/utils';

export class PriceVolatilityItemObject {
    item: GetBooking.PriceVolatilityItems;
    total = -1;
    length = -1;
    index: number;

    constructor(
        items:
            | GetBooking.PriceVolatilityItems[]
            | GetBooking.PriceVolatilityItems,
        index = -1,
    ) {
        if (Array.isArray(items)) {
            const [item] = items;
            this.item = item;
            this.total = items.reduce((sum, i) => sum + i.value, 0);
            this.length = items.length;
        } else {
            this.item = items;
        }
        this.index = index;
    }

    get name() {
        return this.item.priceVolatility.name;
    }

    get unitPrice() {
        const { priceVolatility, kind } = this.item;
        return {
            [PriceVolatilityItemKindEnum.Hour]: priceVolatility.hourPrice,
            [PriceVolatilityItemKindEnum.Night]: priceVolatility.nightPrice,
            [PriceVolatilityItemKindEnum.Day]: priceVolatility.dayPrice,
        }[kind];
    }

    get unit() {
        const { kind } = this.item;
        return {
            [PriceVolatilityItemKindEnum.Hour]: 'giờ',
            [PriceVolatilityItemKindEnum.Night]: 'đêm',
            [PriceVolatilityItemKindEnum.Day]: 'ngày',
        }[kind];
    }

    get amount() {
        const { timeSpan } = this.item;
        const time = duration(timeSpan, 'second');
        if (this.item.kind === PriceVolatilityItemKindEnum.Hour)
            return time.asHours();
        return this.length !== -1 ? this.length : 1;
    }

    get number() {
        return `${this.amount} ${this.unit}`;
    }

    get left() {
        return moment(this.item.date);
    }

    get right() {
        return this.left.clone().add(this.item.timeSpan, 'seconds');
    }

    get line() {
        return this.index + 2;
    }

    get text() {
        const { unit, unitPrice, amount } = this;
        return `${amount} ${unit} ✕ ${toMoney(unitPrice)}`;
    }
}
