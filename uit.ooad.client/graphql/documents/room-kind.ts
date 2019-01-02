import gql from 'graphql-tag';

export const getRoomKinds = gql`
    query getRoomKinds {
        roomKinds {
            id
            name
            isActive
        }
    }
`;
