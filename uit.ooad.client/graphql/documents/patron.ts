import gql from 'graphql-tag';

export const getPatrons = gql`
    query getPatrons {
        patrons {
            id
            identification
            name
            birthdate
            email
            gender
            residence
            domicile
            phoneNumbers
            nationality
            company
            note
            patronKind {
                id
            }
        }
    }
`;

export const getPatron = gql`
    query getPatron($id: ID!) {
        patron(id: $id) {
            id
            identification
            name
            birthdate
            email
            gender
            residence
            domicile
            phoneNumbers
            nationality
            company
            note
            patronKind {
                id
            }
        }
    }
`;

export const createPatron = gql`
    mutation createPatron($input: PatronCreateInput!) {
        createPatron(input: $input) {
            id
            identification
            name
            birthdate
            email
            gender
            residence
            domicile
            phoneNumbers
            nationality
            company
            note
            patronKind {
                id
            }
        }
    }
`;

export const updatePatron = gql`
    mutation updatePatron($input: PatronUpdateInput!) {
        updatePatron(input: $input) {
            id
        }
    }
`;
