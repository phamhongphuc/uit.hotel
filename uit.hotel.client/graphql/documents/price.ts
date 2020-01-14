import gql from 'graphql-tag';

export const getPrices = gql`
    query getPrices {
        prices {
            id
            hourPrice
            nightPrice
            dayPrice
            effectiveStartDate
            createDate
            roomKind {
                id
                name
            }
        }
    }
`;

export const getPrice = gql`
    query getPrice($id: ID!) {
        price(id: $id) {
            id
            createDate
            effectiveStartDate
            earlyCheckInFee
            lateCheckOutFee
            hourPrice
            nightPrice
            dayPrice
            weekPrice
            monthPrice
            roomKind {
                id
                name
            }
        }
    }
`;

export const createPrice = gql`
    mutation createPrice($input: PriceCreateInput!) {
        createPrice(input: $input) {
            id
        }
    }
`;
