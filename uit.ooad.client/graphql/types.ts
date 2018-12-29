export type Maybe<T> = T | null;

export interface BookingCreateInput {
    /** Thời điểm nhận phòng dự kiến của khách hàng */
    bookCheckInTime: Maybe<DateTimeOffset>;
    /** Thời điểm trả phòng dự kiến của khách hàng */
    bookCheckOutTime: Maybe<DateTimeOffset>;
    /** Phòng khách hàng chọn đặt trước */
    room: RoomId;
    /** Danh sách khách hàng */
    listOfPatrons: PatronId[];
}
/** Input cho thông tin một phòng */
export interface RoomId {
    /** Id của phòng */
    id: number;
}
/** Input cho thông tin một khách hàng */
export interface PatronId {
    /** Id của khách hàng */
    id: number;
}

export interface BillCreateInput {
    /** Khách hàng */
    patron: Maybe<PatronId>;
}

export interface ServicesDetailCreateInput {
    /** Số lượng */
    number: number;
    /** Thuộc dịch vụ nào */
    service: ServiceId;
}
/** Input cho một thông tin dịch vụ */
export interface ServiceId {
    /** Id của dịch vụ */
    id: number;
}

export interface EmployeeCreateInput {
    /** Id của nhân viên */
    id: string;
    /** Mật khẩu của tài khoản nhân viên */
    password: string;
    /** Tên nhân viên */
    name: string;
    /** Chứng minh nhân dân */
    identityCard: string;
    /** Số điện thoại của nhân viên */
    phoneNumber: string;
    /** Địa chỉ của nhân viên */
    address: string;
    /** Ngày sinh của nhân viên */
    birthdate: DateTimeOffset;
    /** Ngày vào làm */
    startingDate: DateTimeOffset;
    /** Tài khoản còn hiệu lực hay không */
    isActive: boolean;
    /** Loại chức vụ */
    position: Maybe<PositionId>;
}
/** Input cho thông tin một chức vụ */
export interface PositionId {
    /** Id của chức vụ */
    id: number;
}

export interface FloorCreateInput {
    /** Tên tầng */
    name: string;
    /** Trạng thái hoạt động */
    isActive: boolean;
}

export interface PatronCreateInput {
    /** Số an sinh xã hội / Số chứng minh nhân dân / Số passport của khách hàng */
    identification: string;
    /** Tên của khách hàng */
    name: string;
    /** Địa chỉ e-mail của khách hàng */
    email: string;
    /** Giới tính của khách hàng */
    gender: boolean;
    /** Ngày sinh của khách hàng */
    birthdate: DateTimeOffset;
    /** Quốc tịch của khách hàng */
    nationality: string;
    /** Nguyên quán của khách hàng */
    domicile: string;
    /** Địa chỉ thường trú của khách hàng */
    residence: string;
    /** Công ty mà khách hàng đang làm việc */
    company: string;
    /** Một số chú thích về khách hàng nếu cần thiết */
    note: string;
    /** Danh sách số điện thoại của khách hàng */
    listOfPhoneNumbers: Maybe<(Maybe<string>)[]>;
    /** Loại khách hàng */
    patronKind: Maybe<PatronKindId>;
}
/** Input cho thông tin  một loại khách hàng */
export interface PatronKindId {
    /** Id của loại khách hàng */
    id: number;
}

export interface PatronKindCreateInput {
    /** Tên loại khách hàng */
    name: string;
    /** Thông tin mô tả loại khách hàng */
    description: string;
}

export interface PositionCreateInput {
    /** Tên chức vụ */
    name: string;
    /** Quyền chỉnh sửa sơ đồ */
    permissionUpdateGroundPlan: boolean;
    /** Quyền lấy thông tin tầng, phòng */
    permissionGetGroundPlan: boolean;
    /** Quyền quản lý loại phòng */
    permissionManageRoomKind: boolean;
    /** Quyền lấy thông tin loại phòng */
    permissionGetRoomKind: boolean;
    /** Quyền quản lý giá cơ bản và giá biến động */
    permissionManageRate: boolean;
    /** Quyền lấy thông tin giá cơ bản và giá biến động */
    permissionGetRate: boolean;
    /** Quyền thao tác dọn phòng */
    permissionCleaning: boolean;
    /** Quyền tra cứu lịch sử dọn phòng */
    permissionGetHouseKeeping: boolean;
    /** Quyền quản lý thuê phòng */
    permissionManageHiringRoom: boolean;
    /** Quyền quản lý khách hàng */
    permissionManagePatron: boolean;
    /** Quyền lấy thông tin khách hàng */
    permissionGetPatron: boolean;
    /** Quyền quản lý loại khách hàng */
    permissionManagePatronKind: boolean;
    /** Quyền lấy thông tin loại khách hàng */
    permissionGetPatronKind: boolean;
    /** Quyền quản lý chức vụ */
    permissionManagePosition: boolean;
    /** Quyền lấy thông tin chức vụ */
    permissionGetPosition: boolean;
    /** Quyền quản lý thông tin nhân viên */
    permissionManageEmployee: boolean;
    /** Quyền quản lý tài khoản cá nhân */
    permissionManageAccount: boolean;
    /** Quyền quản lý dịch vụ */
    permissionManageService: boolean;
    /** Quyền lấy thông tin dịch vụ */
    permissionGetService: boolean;
    /** Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu) */
    permissionGetVoucher: boolean;
}

export interface RateCreateInput {
    /** Giá ngày */
    dayRate: number;
    /** Giá đêm */
    nightRate: number;
    /** Giá tuần */
    weekRate: number;
    /** Giá tháng */
    monthRate: number;
    /** Phí check-out muộn */
    lateCheckOutFee: number;
    /** Phí check-out sớm */
    earlyCheckInFee: number;
    /** Ngày giá bắt đầu có hiệu lực */
    effectiveStartDate: DateTimeOffset;
    /** Ngày tạo giá */
    createDate: DateTimeOffset;
    /** Loại phòng */
    roomKind: Maybe<RoomKindId>;
}
/** Input cho một thông tin một loại phòng */
export interface RoomKindId {
    /** Id của một loại phòng */
    id: number;
}

export interface ReceiptCreateInput {
    /** Số tiền đã thu */
    money: number;
    /** Thời gian tạo phiếu thu */
    time: DateTimeOffset;
    /** Kiểu thanh toán (tiền mặt hoặc chuyển khoản) */
    typeOfPayment: number;
    /** Số tài khoản ngân hàng của khách */
    bankAccountNumber: Maybe<string>;
    /** Thuộc hóa đơn */
    bill: Maybe<BillId>;
    /** Nhân viên tạo phiếu thu */
    employee: Maybe<EmployeeId>;
}
/** Input cho thông tin một hóa đơn */
export interface BillId {
    /** Id của hóa đơn */
    id: number;
}
/** Input cho thông tin một nhân viên */
export interface EmployeeId {
    /** Id của một nhân viên */
    id: string;
}

export interface RoomCreateInput {
    /** Tên phòng */
    name: string;
    /** Trạng thái phòng */
    isActive: boolean;
    /** Phòng thuộc tầng nào */
    floor: FloorId;
    /** Loại phòng của phòng */
    roomKind: RoomKindId;
}
/** Input cho một thông tin tầng */
export interface FloorId {
    /** Id của tầng */
    id: number;
}
/** Input cho việc tạo một loại phòng */
export interface RoomKindCreateInput {
    /** Tên loại phòng */
    name: string;
    /** Số giường */
    numberOfBeds: number;
    /** Số người trong một phòng */
    amountOfPeople: number;
    /** Giá theo ngày */
    priceByDate: number;
    /** Trạng thái phòng */
    isActive: boolean;
}
/** Input cho một thông tin dịch vụ cần tạo mới */
export interface ServiceCreateInput {
    /** Tên dịch vụ */
    name: string;
    /** Đơn giá */
    unitRate: number;
    /** Đơn vị */
    unit: string;
    /** Trạng thái hoạt động */
    isActive: boolean;
}

export interface VolatilityRateCreateInput {
    /** Giá ngày */
    dayRate: number;
    /** Giá đêm */
    nightRate: number;
    /** Giá tuần */
    weekRate: number;
    /** Giá tháng */
    monthRate: number;
    /** Phí check-out muộn */
    lateCheckOutFee: number;
    /** Phí check-out sớm */
    earlyCheckInFee: number;
    /** Ngày giá bắt đầu có hiệu lực */
    effectiveStartDate: DateTimeOffset;
    /** Ngày giá hết hiệu lực */
    effectiveEndDate: DateTimeOffset;
    /** Giá có hiệu lực vào ngày Thứ 2 */
    effectiveOnMonday: boolean;
    /** Giá có hiệu lực vào ngày Thứ 3 */
    effectiveOnTuesday: boolean;
    /** Giá có hiệu lực vào ngày Thứ 4 */
    effectiveOnWednesday: boolean;
    /** Giá có hiệu lực vào ngày Thứ 5 */
    effectiveOnThursday: boolean;
    /** Giá có hiệu lực vào ngày Thứ 6 */
    effectiveOnFriday: boolean;
    /** Giá có hiệu lực vào ngày Thứ 7 */
    effectiveOnSaturday: boolean;
    /** Giá có hiệu lực vào ngày Chủ Nhật */
    effectiveOnSunday: boolean;
    /** Ngày tạo giá */
    createDate: DateTimeOffset;
    /** Loại phòng */
    roomKind: RoomKindId;
}

export interface EmployeeUpdateInput {
    /** Id của nhân viên */
    id: string;
    /** Tên nhân viên */
    name: string;
    /** Chứng minh nhân dân */
    identityCard: string;
    /** Số điện thoại của nhân viên */
    phoneNumber: string;
    /** Địa chỉ của nhân viên */
    address: string;
    /** Ngày sinh của nhân viên */
    birthdate: DateTimeOffset;
    /** Ngày vào làm */
    startingDate: DateTimeOffset;
    /** Loại chức vụ */
    position: Maybe<PositionId>;
}

export interface FloorUpdateInput {
    /** Id tầng cần cập nhật */
    id: number;
    /** Tên tầng */
    name: string;
}

export interface PatronUpdateInput {
    /** Id của khách hàng */
    id: number;
    /** Số an sinh xã hội / Số chứng minh nhân dân / Số passport của khách hàng */
    identification: string;
    /** Tên của khách hàng */
    name: string;
    /** Địa chỉ e-mail của khách hàng */
    email: string;
    /** Giới tính của khách hàng */
    gender: boolean;
    /** Ngày sinh của khách hàng */
    birthdate: DateTimeOffset;
    /** Quốc tịch của khách hàng */
    nationality: string;
    /** Nguyên quán của khách hàng */
    domicile: string;
    /** Địa chỉ thường trú của khách hàng */
    residence: string;
    /** Công ty mà khách hàng đang làm việc */
    company: string;
    /** Một số chú thích về khách hàng nếu cần thiết */
    note: string;
    /** Danh sách số điện thoại của khách hàng */
    listOfPhoneNumbers: Maybe<(Maybe<string>)[]>;
    /** Loại khách hàng */
    patronKind: Maybe<PatronKindId>;
}

export interface RoomUpdateInput {
    /** Id phòng cần cập nhật */
    id: number;
    /** Tên phòng */
    name: string;
    /** Phòng thuộc tầng nào */
    floor: Maybe<FloorId>;
    /** Loại phòng của phòng */
    roomKind: Maybe<RoomKindId>;
}
/** Input cho việc chỉnh sửa một loại phòng */
export interface RoomKindUpdateInput {
    /** Id loại phòng */
    id: number;
    /** Tên loại phòng */
    name: string;
    /** Số giường */
    numberOfBeds: number;
    /** Số người trong một phòng */
    amountOfPeople: number;
    /** Giá theo ngày */
    priceByDate: number;
}
/** Input cho một thông tin dịch vụ cần cập nhật */
export interface ServiceUpdateInput {
    /** Id của dịch vụ */
    id: number;
    /** Tên dịch vụ */
    name: string;
    /** Đơn giá */
    unitRate: number;
    /** Đơn vị */
    unit: string;
}

/** The `DateTimeOffset` scalar type represents a date, time and offset from UTC. `DateTimeOffset` expects timestamps to be formatted in accordance with the [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard. */
export type DateTimeOffset = any;

/** The `Date` scalar type represents a year, month and day in accordance with the [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard. */
export type Date = any;

/** The `DateTime` scalar type represents a date and time. `DateTime` expects timestamps to be formatted in accordance with the [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard. */
export type DateTime = any;

export type Decimal = any;

/** The `Milliseconds` scalar type represents a period of time represented as the total number of milliseconds. */
export type Milliseconds = any;

/** The `Seconds` scalar type represents a period of time represented as the total number of seconds. */
export type Seconds = any;

// ====================================================
// Documents
// ====================================================

export namespace UserLogin {
    export type Variables = {
        id: string;
        password: string;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        login: Login;
    };

    export type Login = {
        __typename?: 'AuthenticationObject';

        token: string;

        employee: Employee;
    };

    export type Employee = {
        __typename?: 'Employee';

        id: string;

        name: string;

        position: Position;
    };

    export type Position = {
        __typename?: 'Position';

        name: string;
    };
}

export namespace UserCheckLogin {
    export type Variables = {};

    export type Mutation = {
        __typename?: 'Mutation';

        checkLogin: CheckLogin;
    };

    export type CheckLogin = {
        __typename?: 'Employee';

        id: string;

        name: string;

        position: Position;
    };

    export type Position = {
        __typename?: 'Position';

        name: string;
    };
}

export namespace GetFloors {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        floors: Floors[];
    };

    export type Floors = {
        __typename?: 'Floor';

        id: number;

        name: string;

        isActive: boolean;

        rooms: Maybe<(Maybe<Rooms>)[]>;
    };

    export type Rooms = {
        __typename?: 'Room';

        id: number;

        name: string;

        isActive: boolean;

        roomKind: RoomKind;
    };

    export type RoomKind = {
        __typename?: 'RoomKind';

        id: number;

        name: string;
    };
}

export namespace CreateRoom {
    export type Variables = {
        input: RoomCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        createRoom: CreateRoom;
    };

    export type CreateRoom = {
        __typename?: 'Room';

        id: number;
    };
}

export namespace DeleteRoom {
    export type Variables = {
        id: string;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        deleteRoom: string;
    };
}

export namespace CreateFloor {
    export type Variables = {
        input: FloorCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        createFloor: CreateFloor;
    };

    export type CreateFloor = {
        __typename?: 'Floor';

        id: number;

        name: string;

        isActive: boolean;
    };
}

export namespace DeleteFloor {
    export type Variables = {
        id: string;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        deleteFloor: string;
    };
}

export namespace SetIsActiveFloor {
    export type Variables = {
        id: string;
        isActive: boolean;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        setIsActiveFloor: string;
    };
}

export namespace SetIsActiveRoom {
    export type Variables = {
        id: string;
        isActive: boolean;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        setIsActiveRoom: string;
    };
}
