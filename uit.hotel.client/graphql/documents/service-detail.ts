import gql from 'graphql-tag';

export const createServicesDetail = gql`
    mutation createServicesDetail($input: ServicesDetailCreateInput!) {
        createServicesDetail(input: $input) {
            id
        }
    }
`;
