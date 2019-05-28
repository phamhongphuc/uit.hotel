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

export const getFloorsMap = gql`
    query getFloorsMap($from: DateTimeOffset!, $to: DateTimeOffset!) {
        floors {
            id
            name
            isActive
            rooms {
                id
                name
                isActive
                currentBooking(from: $from, to: $to) {
                    id
                }
                roomKind {
                    id
                    name
                }
            }
        }
    }
`;

export const getTimeline = gql`
    query getTimeline {
        floors {
            id
            name
            isActive
            rooms {
                id
                name
                isActive
                bookings {
                    id
                    status
                    createTime
                    bookCheckInTime
                    bookCheckOutTime
                    patrons {
                        id
                    }
                }
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
