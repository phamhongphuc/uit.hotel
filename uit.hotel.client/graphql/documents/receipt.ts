import gql from 'graphql-tag';

export const getReceipts = gql`
    query getReceipts {
        receipts {
            id
            money
            time
            bill {
                id
            }
        }
    }
`;

export const createReceipt = gql`
    mutation createReceipt($input: ReceiptCreateInput!) {
        createReceipt(input: $input) {
            id
        }
    }
`;
