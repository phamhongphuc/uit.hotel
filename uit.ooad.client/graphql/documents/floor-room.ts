import gql from 'graphql-tag';

export const getFloors = gql`
    query getFloors {
        floors {
            id
            name
            isActive
            rooms {
                id
                name
                roomKind {
                    id
                    name
                }
            }
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

export const deleteRoom = gql`
    mutation deleteRoom($id: ID!) {
        deleteRoom(id: $id)
    }
`;

export const createFloor = gql`
    mutation createFloor($input: FloorCreateInput!) {
        createFloor(input: $input) {
            id
            name
            isActive
        }
    }
`;

export const deleteFloor = gql`
    mutation deleteFloor($id: ID!) {
        deleteFloor(id: $id)
    }
`;
