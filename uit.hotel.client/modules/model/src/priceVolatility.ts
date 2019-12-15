import { GetPriceVolatilities } from '~/graphql/types';

export type DaysOfWeekType = {
    daysOfWeek: [boolean, boolean, boolean, boolean, boolean, boolean, boolean];
};

export const toDaysOfWeek = (
    priceVolatility: GetPriceVolatilities.PriceVolatilities,
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

export const DaysOfWeekTitles = ['T2', 'T3', 'T4', 'T5', 'T6', 'T7', 'CN'];

export const DaysOfWeekProperties = [
    'effectiveOnMonday',
    'effectiveOnTuesday',
    'effectiveOnWednesday',
    'effectiveOnThursday',
    'effectiveOnFriday',
    'effectiveOnSaturday',
    'effectiveOnSunday',
];

export const DaysOfWeekOptions = DaysOfWeekTitles.map((text, index) => ({
    text,
    value: DaysOfWeekProperties[index],
}));

export type DaysOfWeekProperty = typeof DaysOfWeekProperties[number];
