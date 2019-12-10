import gql from 'graphql-tag';

export const createServicesDetail = gql`
    mutation createServicesDetail($input: ServicesDetailCreateInput!) {
        createServicesDetail(input: $input) {
            id
        }
    }
`;

export const deleteServicesDetail = gql`
    mutation deleteServicesDetail($id: ID!) {
        deleteServicesDetail(id: $id)
    }
`;
