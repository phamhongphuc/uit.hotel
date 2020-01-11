import gql from 'graphql-tag';

export const getPatronsAndRooms = gql`
    query getPatronsAndRooms {
        patrons {
            id
            identification
            name
            birthdate
            email
            gender
            residence
            domicile
            phoneNumber
            nationality
            company
            note
            patronKind {
                id
            }
        }
        rooms {
            id
            name
            isActive
            isClean
        }
    }
`;
