import gql from 'graphql-tag';

export const getPatronKinds = gql`
    query getPatronKinds {
        patronKinds {
            id
            name
            description
            patrons {
                id
                name
            }
        }
    }
`;

export const createPatronKind = gql`
    mutation createPatronKind($input: PatronKindCreateInput!) {
        createPatronKind(input: $input) {
            id
        }
    }
`;

export const updatePatronKind = gql`
    mutation updatePatronKind($input: PatronKindUpdateInput!) {
        updatePatronKind(input: $input) {
            id
        }
    }
`;
