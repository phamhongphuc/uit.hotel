import { Vue, Component, namespace, Prop } from 'nuxt-property-decorator';
import { UserLogin } from '~/graphql/types';

export enum PermissionEnum {
    /** Quyền thao tác dọn phòng */
    Cleaning,
    /** Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu) */
    GetAccountingVoucher,
    /** Quyền tra cứu lịch sử dọn phòng */
    GetHouseKeeping,
    /** Quyền lấy thông tin tầng, phòng */
    GetMap,
    /** Quyền lấy thông tin khách hàng */
    GetPatron,
    /** Quyền lấy thông tin giá cơ bản và giá biến động */
    GetRate,
    /** Quyền lấy thông tin dịch vụ */
    GetService,
    /** Quyền quản lý thông tin nhân viên */
    ManageEmployee,
    /** Quyền quản lý thuê phòng */
    ManageHiringRoom,
    /** Quyền quản lý khách hàng */
    ManagePatron,
    /** Quyền quản lý loại khách hàng */
    ManagePatronKind,
    /** Quyền quản lý chức vụ */
    ManagePosition,
    /** Quyền quản lý giá cơ bản và giá biến động */
    ManageRate,
    /** Quyền quản lý dịch vụ */
    ManageService,
    /** Quyền chỉnh sửa sơ đồ */
    ManageMap,
}

@Component
export class PermissionMixin extends Vue {
    @(namespace('user').State)
    employee!: UserLogin.Employee;

    @Prop({
        default: true,
        validator(permission: boolean | string[] | PermissionEnum[]) {
            if (typeof permission === 'boolean') return true;
            else if (
                typeof permission === 'object' &&
                Array.isArray(permission)
            ) {
                return permission.every((p: string | PermissionEnum) => {
                    const condition = p in PermissionEnum;
                    if (!condition) {
                        const permissionMessage =
                            typeof p === 'string'
                                ? `String: ${p}`
                                : `Number: ${p} (${PermissionEnum[p]})`;
                        // eslint-disable-next-line no-console
                        console.warn(
                            `${permissionMessage} is not a is not a valid prop for permission.\n`,
                            `Valid value is`,
                            { enum: PermissionEnum },
                        );
                    }
                    return condition;
                });
            }
            return false;
        },
    })
    permission!: boolean | PermissionEnum[] | string[];

    get isShow() {
        const { permission, employee } = this;

        if (!employee) return true;
        else if (typeof permission === 'boolean') return permission;
        else if (permission === undefined) return false;
        return permission.every((each: string | PermissionEnum) => {
            let pString = each; // if p is string
            if (typeof each === 'number') pString = PermissionEnum[each];
            return employee.position['permission' + pString];
        });
    }
}
