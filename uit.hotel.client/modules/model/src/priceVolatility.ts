import { GetPriceVolatilities, GetPriceVolatility } from '~/graphql/types';

export type DaysOfWeekType = {
    daysOfWeek: [boolean, boolean, boolean, boolean, boolean, boolean, boolean];
};

export const toDaysOfWeek = (
    priceVolatility:
        | GetPriceVolatilities.PriceVolatilities
        | GetPriceVolatility.PriceVolatility,
): DaysOfWeekType => ({
    daysOfWeek: [
        priceVolatility.effectiveOnMonday,
        priceVolatility.effectiveOnTuesday,
        priceVolatility.effectiveOnWednesday,
        priceVolatility.effectiveOnThursday,
        priceVolatility.effectiveOnFriday,
        priceVolatility.effectiveOnSaturday,
        priceVolatility.effectiveOnSunday,
    ],
});

export const daysOfWeekTitles = ['T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'CN'];

export const daysOfWeekProperties = [
    'effectiveOnMonday',
    'effectiveOnTuesday',
    'effectiveOnWednesday',
    'effectiveOnThursday',
    'effectiveOnFriday',
    'effectiveOnSaturday',
    'effectiveOnSunday',
];

export const daysOfWeekOptions = daysOfWeekTitles.map((text, index) => ({
    text,
    value: daysOfWeekProperties[index],
}));

export type DaysOfWeekPropertyType = typeof daysOfWeekProperties[number];
