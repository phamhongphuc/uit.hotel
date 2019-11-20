import gql from 'graphql-tag';

export const getPrices = gql`
    query getPrices {
        prices {
            id
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

export const createPrice = gql`
    mutation createPrice($input: PriceCreateInput!) {
        createPrice(input: $input) {
            id
        }
    }
`;
