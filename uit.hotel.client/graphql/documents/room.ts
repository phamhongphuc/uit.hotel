import gql from 'graphql-tag';

export const getRooms = gql`
    query getRooms {
        rooms {
            id
            name
            isActive
        }
    }
`;

export const getRoomsWithIsEmpty = gql`
    query getRoomsWithIsEmpty($from: DateTimeOffset!, $to: DateTimeOffset!) {
        rooms {
            id
            name
            isActive
            isEmpty(from: $from, to: $to)
        }
    }
`;

export const getRoom = gql`
    query getRoom($id: ID!) {
        room(id: $id) {
            id
            name
            isActive
        }
    }
`;

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

export const setIsCleanRoom = gql`
    mutation setIsCleanRoom($id: ID!, $isClean: Boolean!) {
        setIsCleanRoom(id: $id, isClean: $isClean)
    }
`;
