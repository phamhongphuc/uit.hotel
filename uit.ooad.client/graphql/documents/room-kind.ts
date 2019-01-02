import gql from 'graphql-tag';

export const getRoomKinds = gql`
    query getRoomKinds {
        roomKinds {
            id
            name
            isActive
            amountOfPeople
            numberOfBeds
            rooms {
                id
            }
        }
    }
`;

export const createRoomKind = gql`
    mutation createRoomKind($input: RoomKindCreateInput!) {
        createRoomKind(input: $input) {
            id
            name
            numberOfBeds
            amountOfPeople
            isActive
        }
    }
`;

export const updateRoomKind = gql`
    mutation updateRoomKind($input: RoomKindUpdateInput!) {
        updateRoomKind(input: $input) {
            id
        }
    }
`;

export const deleteRoomKind = gql`
    mutation deleteRoomKind($id: ID!) {
        deleteRoomKind(id: $id)
    }
`;

export const setIsActiveRoomKind = gql`
    mutation setIsActiveRoomKind($id: ID!, $isActive: Boolean!) {
        setIsActiveRoomKind(id: $id, isActive: $isActive)
    }
`;
