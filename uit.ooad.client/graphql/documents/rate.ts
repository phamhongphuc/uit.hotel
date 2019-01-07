import gql from 'graphql-tag';

export const getRates = gql`
    query getRates {
        rates {
            id
            dayRate
            effectiveStartDate
            createDate
            roomKind {
                id
                name
            }
        }
    }
`;

export const createRate = gql`
    mutation createRate($input: RateCreateInput!) {
        createRate(input: $input) {
            id
        }
    }
`;
