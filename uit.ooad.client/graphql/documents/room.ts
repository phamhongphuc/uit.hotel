import gql from 'graphql-tag';

export const createRoom = gql`
    mutation createRoom($input: RoomCreateInput!) {
        createRoom(input: $input) {
            id
        }
    }
`;

export const updateRoom = gql`
    mutation updateRoom($input: RoomUpdateInput!) {
        updateRoom(input: $input) {
            id
        }
    }
`;

export const deleteRoom = gql`
    mutation deleteRoom($id: ID!) {
        deleteRoom(id: $id)
    }
`;

export const setIsActiveRoom = gql`
    mutation setIsActiveRoom($id: ID!, $isActive: Boolean!) {
        setIsActiveRoom(id: $id, isActive: $isActive)
    }
`;
