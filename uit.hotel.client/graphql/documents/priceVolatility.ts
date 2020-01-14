import gql from 'graphql-tag';

export const getPriceVolatilities = gql`
    query getPriceVolatilities {
        priceVolatilities {
            id
            name
            hourPrice
            dayPrice
            nightPrice
            effectiveStartDate
            effectiveEndDate
            effectiveOnMonday
            effectiveOnTuesday
            effectiveOnWednesday
            effectiveOnThursday
            effectiveOnFriday
            effectiveOnSaturday
            effectiveOnSunday
            createDate
            employee {
                id
            }
            roomKind {
                id
                name
            }
        }
    }
`;

export const getPriceVolatility = gql`
    query getPriceVolatility($id: ID!) {
        priceVolatility(id: $id) {
            id
            name
            hourPrice
            dayPrice
            nightPrice
            effectiveStartDate
            effectiveEndDate
            effectiveOnMonday
            effectiveOnTuesday
            effectiveOnWednesday
            effectiveOnThursday
            effectiveOnFriday
            effectiveOnSaturday
            effectiveOnSunday
            createDate
            employee {
                id
            }
            roomKind {
                id
                name
            }
        }
    }
`;

export const createPriceVolatility = gql`
    mutation createPriceVolatility($input: PriceVolatilityCreateInput!) {
        createPriceVolatility(input: $input) {
            id
        }
    }
`;
