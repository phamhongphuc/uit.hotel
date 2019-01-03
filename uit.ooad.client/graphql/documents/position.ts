import gql from 'graphql-tag';

export const getPositions = gql`
    query getPositions {
        positions {
            id
            name
            permissionUpdateGroundPlan
            permissionGetGroundPlan
            permissionManageRoomKind
            permissionGetRoomKind
            permissionManageRate
            permissionGetRate
            permissionGetHouseKeeping
            permissionCleaning
            permissionManageHiringRoom
            permissionManagePatron
            permissionGetPatron
            permissionManagePatronKind
            permissionGetPatronKind
            permissionManagePosition
            permissionGetPosition
            permissionManageEmployee
            permissionManageAccount
            permissionManageService
            permissionGetService
            permissionGetVoucher
            isActive
            employees {
                id
            }
        }
    }
`;

export const createPosition = gql`
    mutation createPosition($input: PositionCreateInput!) {
        createPosition(input: $input) {
            id
        }
    }
`;

export const updatePosition = gql`
    mutation updatePosition($input: PositionUpdateInput!) {
        updatePosition(input: $input) {
            id
        }
    }
`;

export const deletePosition = gql`
    mutation deletePosition($id: ID!) {
        deletePosition(id: $id)
    }
`;

export const setIsActivePosition = gql`
    mutation setIsActivePosition($id: ID!, $isActive: Boolean!) {
        setIsActivePosition(id: $id, isActive: $isActive)
    }
`;

export const setIsActivePositionAndMoveEmployee = gql`
    mutation setIsActivePositionAndMoveEmployee(
        $id: ID!
        $newId: ID!
        $isActive: Boolean!
    ) {
        setIsActivePositionAndMoveEmployee(
            id: $id
            newId: $newId
            isActive: $isActive
        )
    }
`;
