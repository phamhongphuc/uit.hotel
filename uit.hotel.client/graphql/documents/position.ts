import gql from 'graphql-tag';
import { CheckboxOption } from '~/utils';

export const getPositions = gql`
    query getPositions {
        positions {
            id
            name
            permissionCleaning
            permissionGetAccountingVoucher
            permissionGetHouseKeeping
            permissionGetMap
            permissionGetPatron
            permissionGetRate
            permissionGetService
            permissionManageEmployee
            permissionManageHiringRoom
            permissionManageMap
            permissionManagePatron
            permissionManagePatronKind
            permissionManagePosition
            permissionManageRate
            permissionManageService
            isActive
            employees {
                id
                isActive
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

export const positionOptionsAdministrative: CheckboxOption[] = [
    {
        text: 'Quản lý chức vụ',
        value: 'permissionManagePosition',
    },
    {
        text: 'Quản lý thông tin nhân viên',
        value: 'permissionManageEmployee',
    },
];

export const positionOptionsBusiness: CheckboxOption[] = [
    {
        text: 'Chỉnh sửa sơ đồ',
        value: 'permissionManageMap',
    },
    {
        text: 'Quản lý loại khách hàng',
        value: 'permissionManagePatronKind',
    },
    {
        text: 'Quản lý dịch vụ',
        value: 'permissionManageService',
    },
    {
        text: 'Quản lý giá cơ bản và giá biến động',
        value: 'permissionManageRate',
    },
];

export const positionOptionsReceptionist: CheckboxOption[] = [
    {
        text: 'Lấy thông tin các chứng từ (hóa đơn, phiếu thu)',
        value: 'permissionGetAccountingVoucher',
    },
    {
        text: 'Tra cứu lịch sử dọn phòng',
        value: 'permissionGetHouseKeeping',
    },
    {
        text: 'Lấy thông tin tầng, phòng',
        value: 'permissionGetMap',
    },
    {
        text: 'Lấy thông tin khách hàng',
        value: 'permissionGetPatron',
    },
    {
        text: 'Lấy thông tin giá cơ bản và giá biến động',
        value: 'permissionGetRate',
    },
    {
        text: 'Lấy thông tin dịch vụ',
        value: 'permissionGetService',
    },
    {
        text: 'Quản lý thuê phòng',
        value: 'permissionManageHiringRoom',
    },
    {
        text: 'Quản lý khách hàng',
        value: 'permissionManagePatron',
    },
];

export const positionOptionsHouseKeeping: CheckboxOption[] = [
    {
        text: 'Thao tác dọn phòng',
        value: 'permissionCleaning',
    },
];
