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

export const positionOptions = [
    {
        text: 'Quyền thao tác dọn phòng',
        value: 'permissionCleaning',
    },
    {
        text: 'Quyền lấy thông tin tầng, phòng',
        value: 'permissionGetGroundPlan',
    },
    {
        text: 'Quyền tra cứu lịch sử dọn phòng',
        value: 'permissionGetHouseKeeping',
    },
    {
        text: 'Quyền lấy thông tin khách hàng',
        value: 'permissionGetPatron',
    },
    {
        text: 'Quyền lấy thông tin loại khách hàng',
        value: 'permissionGetPatronKind',
    },
    {
        text: 'Quyền lấy thông tin chức vụ',
        value: 'permissionGetPosition',
    },
    {
        text: 'Quyền lấy thông tin giá cơ bản và giá biến động',
        value: 'permissionGetRate',
    },
    {
        text: 'Quyền lấy thông tin loại phòng',
        value: 'permissionGetRoomKind',
    },
    {
        text: 'Quyền lấy thông tin dịch vụ',
        value: 'permissionGetService',
    },
    {
        text: 'Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu)',
        value: 'permissionGetVoucher',
    },
    {
        text: 'Quyền quản lý tài khoản cá nhân',
        value: 'permissionManageAccount',
    },

    {
        text: 'Quyền quản lý thông tin nhân viên',
        value: 'permissionManageEmployee',
    },
    {
        text: 'Quyền quản lý thuê phòng',
        value: 'permissionManageHiringRoom',
    },
    {
        text: 'Quyền quản lý khách hàng',
        value: 'permissionManagePatron',
    },
    {
        text: 'Quyền quản lý loại khách hàng',
        value: 'permissionManagePatronKind',
    },

    {
        text: 'Quyền quản lý chức vụ',
        value: 'permissionManagePosition',
    },

    {
        text: 'Quyền quản lý giá cơ bản và giá biến động',
        value: 'permissionManageRate',
    },
    {
        text: 'Quyền quản lý loại phòng',
        value: 'permissionManageRoomKind',
    },
    {
        text: 'Quyền quản lý dịch vụ',
        value: 'permissionManageService',
    },
    {
        text: 'Quyền chỉnh sửa sơ đồ',
        value: 'permissionUpdateGroundPlan',
    },
];

export const positionOptionsA = [
    {
        text: 'Quyền thao tác dọn phòng',
        value: 'permissionCleaning',
    },
    {
        text: 'Quyền lấy thông tin tầng, phòng',
        value: 'permissionGetGroundPlan',
    },
    {
        text: 'Quyền tra cứu lịch sử dọn phòng',
        value: 'permissionGetHouseKeeping',
    },
    {
        text: 'Quyền lấy thông tin khách hàng',
        value: 'permissionGetPatron',
    },
    {
        text: 'Quyền lấy thông tin loại khách hàng',
        value: 'permissionGetPatronKind',
    },
    {
        text: 'Quyền lấy thông tin chức vụ',
        value: 'permissionGetPosition',
    },
    {
        text: 'Quyền lấy thông tin giá cơ bản và giá biến động',
        value: 'permissionGetRate',
    },
    {
        text: 'Quyền lấy thông tin loại phòng',
        value: 'permissionGetRoomKind',
    },
    {
        text: 'Quyền lấy thông tin dịch vụ',
        value: 'permissionGetService',
    },
    {
        text: 'Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu)',
        value: 'permissionGetVoucher',
    },
    {
        text: 'Quyền quản lý tài khoản cá nhân',
        value: 'permissionManageAccount',
    },

    {
        text: 'Quyền quản lý thông tin nhân viên',
        value: 'permissionManageEmployee',
    },
    {
        text: 'Quyền quản lý thuê phòng',
        value: 'permissionManageHiringRoom',
    },
    {
        text: 'Quyền quản lý khách hàng',
        value: 'permissionManagePatron',
    },
    {
        text: 'Quyền quản lý loại khách hàng',
        value: 'permissionManagePatronKind',
    },

    {
        text: 'Quyền quản lý chức vụ',
        value: 'permissionManagePosition',
    },

    {
        text: 'Quyền quản lý giá cơ bản và giá biến động',
        value: 'permissionManageRate',
    },
    {
        text: 'Quyền quản lý loại phòng',
        value: 'permissionManageRoomKind',
    },
    {
        text: 'Quyền quản lý dịch vụ',
        value: 'permissionManageService',
    },
    {
        text: 'Quyền chỉnh sửa sơ đồ',
        value: 'permissionUpdateGroundPlan',
    },
];
