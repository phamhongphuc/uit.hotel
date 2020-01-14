import { CheckboxOption } from '~/utils';

export const positionColorMap = (isActive: boolean) =>
    isActive ? 'green' : 'light';

export const positionTitleMap = (isActive: boolean) =>
    isActive ? 'Đang kích hoạt' : 'Đã vô hiệu hóa';

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
        value: 'permissionManagePrice',
    },
];

export const positionOptionsReceptionist: CheckboxOption[] = [
    {
        text: 'Lấy thông tin các chứng từ (hóa đơn, phiếu thu)',
        value: 'permissionGetAccountingVoucher',
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
        value: 'permissionGetPrice',
    },
    {
        text: 'Lấy thông tin dịch vụ',
        value: 'permissionGetService',
    },
    {
        text: 'Quản lý thuê phòng',
        value: 'permissionManageRentingRoom',
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

export const permission = [
    ...positionOptionsAdministrative,
    ...positionOptionsBusiness,
    ...positionOptionsReceptionist,
    ...positionOptionsHouseKeeping,
].map(p => p.value);
