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
                isActive
                roomKind {
                    id
                    name
                }
            }
        }
    }
`;

export const createFloor = gql`
    mutation createFloor($input: FloorCreateInput!) {
        createFloor(input: $input) {
            id
        }
    }
`;

export const updateFloor = gql`
    mutation updateFloor($input: FloorUpdateInput!) {
        updateFloor(input: $input) {
            id
        }
    }
`;

export const deleteFloor = gql`
    mutation deleteFloor($id: ID!) {
        deleteFloor(id: $id)
    }
`;

export const setIsActiveFloor = gql`
    mutation setIsActiveFloor($id: ID!, $isActive: Boolean!) {
        setIsActiveFloor(id: $id, isActive: $isActive)
    }
`;
