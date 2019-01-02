import gql from 'graphql-tag';

export const getServices = gql`
    query getServices {
        services {
            id
            name
            unitRate
            unit
            isActive
        }
    }
`;

export const createService = gql`
    mutation createService($input: ServiceCreateInput!) {
        createService(input: $input) {
            id
        }
    }
`;

export const updateService = gql`
    mutation updateService($input: ServiceUpdateInput!) {
        updateService(input: $input) {
            id
        }
    }
`;

export const deleteService = gql`
    mutation deleteService($id: ID!) {
        deleteService(id: $id)
    }
`;
