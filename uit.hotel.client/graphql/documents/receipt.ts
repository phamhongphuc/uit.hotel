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

export const getReceipt = gql`
    query getReceipt($id: ID!) {
        receipt(id: $id) {
            id
            time
            kind
            status
            statusText
            payUrl
            money
        }
    }
`;

export const checkReceipt = gql`
    mutation checkReceipt($id: ID!) {
        checkReceipt(id: $id) {
            id
            status
            statusText
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
