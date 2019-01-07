export type Maybe<T> = T | null;

/** Input cho thông tin một hóa đơn */
export interface BillId {
    /** Id của hóa đơn */
    id: number;
}

export interface BookingCreateInput {
    /** Thời điểm nhận phòng dự kiến của khách hàng */
    bookCheckInTime: DateTimeOffset;
    /** Thời điểm trả phòng dự kiến của khách hàng */
    bookCheckOutTime: DateTimeOffset;
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

export interface BookAndCheckInCreateInput {
    /** Thời điểm trả phòng dự kiến của khách hàng */
    bookCheckOutTime: DateTimeOffset;
    /** Phòng khách hàng chọn đặt trước */
    room: RoomId;
    /** Danh sách khách hàng */
    listOfPatrons: PatronId[];
}

export interface BillCreateInput {
    /** Khách hàng */
    patron: Maybe<PatronId>;
}

export interface ServicesDetailHouseKeepingInput {
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
    /** Email của nhân viên */
    email: string;
    /** Ngày sinh của nhân viên */
    birthdate: DateTimeOffset;
    /** Giới tính của nhân viên */
    gender: boolean;
    /** Ngày vào làm */
    startingDate: DateTimeOffset;
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
    /** Quyền thao tác dọn phòng */
    permissionCleaning: boolean;
    /** Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu) */
    permissionGetAccountingVoucher: boolean;
    /** Quyền tra cứu lịch sử dọn phòng */
    permissionGetHouseKeeping: boolean;
    /** Quyền lấy thông tin tầng, phòng */
    permissionGetMap: boolean;
    /** Quyền lấy thông tin khách hàng */
    permissionGetPatron: boolean;
    /** Quyền lấy thông tin giá cơ bản và giá biến động */
    permissionGetRate: boolean;
    /** Quyền lấy thông tin dịch vụ */
    permissionGetService: boolean;
    /** Quyền quản lý thông tin nhân viên */
    permissionManageEmployee: boolean;
    /** Quyền quản lý thuê phòng */
    permissionManageHiringRoom: boolean;
    /** Quyền quản lý khách hàng */
    permissionManagePatron: boolean;
    /** Quyền quản lý loại khách hàng */
    permissionManagePatronKind: boolean;
    /** Quyền quản lý chức vụ */
    permissionManagePosition: boolean;
    /** Quyền quản lý giá cơ bản và giá biến động */
    permissionManageRate: boolean;
    /** Quyền quản lý dịch vụ */
    permissionManageService: boolean;
    /** Quyền chỉnh sửa sơ đồ */
    permissionManageMap: boolean;
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
    /** Loại phòng */
    roomKind: RoomKindId;
}
/** Input cho một thông tin một loại phòng */
export interface RoomKindId {
    /** Id của một loại phòng */
    id: number;
}

export interface ReceiptCreateInput {
    /** Số tiền đã thu */
    money: number;
    /** Số tài khoản ngân hàng của khách */
    bankAccountNumber: Maybe<string>;
    /** Thuộc hóa đơn */
    bill: Maybe<BillId>;
}

export interface RoomCreateInput {
    /** Tên phòng */
    name: string;
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
}
/** Input cho một thông tin dịch vụ cần tạo mới */
export interface ServiceCreateInput {
    /** Tên dịch vụ */
    name: string;
    /** Đơn giá */
    unitRate: number;
    /** Đơn vị */
    unit: string;
}

export interface ServicesDetailCreateInput {
    /** Số lượng */
    number: number;
    /** Thuộc dịch vụ nào */
    service: ServiceId;
    /** Thuộc booking nào */
    booking: BookingId;
}
/** Input cho một thông tin một đơn đặt phòng */
export interface BookingId {
    /** Id của một đơn đặt phòng */
    id: number;
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
    /** Địa chỉ của nhân viên */
    address: string;
    /** Ngày sinh của nhân viên */
    birthdate: DateTimeOffset;
    /** Email của nhân viên */
    email: string;
    /** Giới tính của nhân viên */
    gender: boolean;
    /** Số điện thoại của nhân viên */
    phoneNumber: string;
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

export interface PatronKindUpdateInput {
    /** Id của loại khách hàng */
    id: number;
    /** Tên loại khách hàng */
    name: string;
    /** Thông tin mô tả loại khách hàng */
    description: string;
}

export interface PositionUpdateInput {
    /** Id của chức vụ */
    id: number;
    /** Tên chức vụ */
    name: string;
    /** Quyền thao tác dọn phòng */
    permissionCleaning: boolean;
    /** Quyền lấy thông tin tầng, phòng */
    permissionGetMap: boolean;
    /** Quyền tra cứu lịch sử dọn phòng */
    permissionGetHouseKeeping: boolean;
    /** Quyền lấy thông tin khách hàng */
    permissionGetPatron: boolean;
    /** Quyền lấy thông tin giá cơ bản và giá biến động */
    permissionGetRate: boolean;
    /** Quyền lấy thông tin dịch vụ */
    permissionGetService: boolean;
    /** Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu) */
    permissionGetAccountingVoucher: boolean;
    /** Quyền quản lý thông tin nhân viên */
    permissionManageEmployee: boolean;
    /** Quyền quản lý thuê phòng */
    permissionManageHiringRoom: boolean;
    /** Quyền chỉnh sửa sơ đồ */
    permissionManageMap: boolean;
    /** Quyền quản lý khách hàng */
    permissionManagePatron: boolean;
    /** Quyền quản lý loại khách hàng */
    permissionManagePatronKind: boolean;
    /** Quyền quản lý chức vụ */
    permissionManagePosition: boolean;
    /** Quyền quản lý giá cơ bản và giá biến động */
    permissionManageRate: boolean;
    /** Quyền quản lý dịch vụ */
    permissionManageService: boolean;
}

export interface RateUpdateInput {
    /** Id của giá cần cập nhật */
    id: number;
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
    /** Loại phòng */
    roomKind: Maybe<RoomKindId>;
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

export interface ServicesDetailUpdateInput {
    /** Id của chi tiết dịch vụ cần cập nhật */
    id: number;
    /** Số lượng */
    number: number;
    /** Thuộc dịch vụ nào */
    service: ServiceId;
}

export interface VolatilityRateUpdateInput {
    /** Id của giá cần cập nhật */
    id: number;
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
    /** Loại phòng */
    roomKind: RoomKindId;
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

        id: number;

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

        id: number;

        name: string;
    };
}

export namespace GetBills {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        bills: Bills[];
    };

    export type Bills = {
        __typename?: 'Bill';

        id: number;

        time: DateTimeOffset;

        total: number;

        patron: Patron;

        employee: Maybe<Employee>;

        receipts: Maybe<(Maybe<Receipts>)[]>;

        bookings: Maybe<(Maybe<Bookings>)[]>;
    };

    export type Patron = {
        __typename?: 'Patron';

        id: number;

        name: string;
    };

    export type Employee = {
        __typename?: 'Employee';

        id: string;

        name: string;
    };

    export type Receipts = {
        __typename?: 'Receipt';

        id: number;

        money: number;
    };

    export type Bookings = {
        __typename?: 'Booking';

        id: number;

        total: number;
    };
}

export namespace AddBookingToBill {
    export type Variables = {
        bill: BillId;
        booking: BookingCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        addBookingToBill: AddBookingToBill;
    };

    export type AddBookingToBill = {
        __typename?: 'Booking';

        id: number;
    };
}

export namespace BookAndCheckIn {
    export type Variables = {
        bookings: BookAndCheckInCreateInput[];
        bill: BillCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        bookAndCheckIn: BookAndCheckIn;
    };

    export type BookAndCheckIn = {
        __typename?: 'Bill';

        id: number;
    };
}

export namespace GetEmployees {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        employees: Employees[];
    };

    export type Employees = {
        __typename?: 'Employee';

        id: string;

        name: string;

        identityCard: string;

        phoneNumber: string;

        address: string;

        email: string;

        birthdate: DateTimeOffset;

        gender: boolean;

        startingDate: DateTimeOffset;

        isActive: boolean;

        position: Position;
    };

    export type Position = {
        __typename?: 'Position';

        id: number;

        name: string;
    };
}

export namespace CreateEmployee {
    export type Variables = {
        input: EmployeeCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        createEmployee: CreateEmployee;
    };

    export type CreateEmployee = {
        __typename?: 'Employee';

        id: string;
    };
}

export namespace UpdateEmployee {
    export type Variables = {
        input: EmployeeUpdateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        updateEmployee: UpdateEmployee;
    };

    export type UpdateEmployee = {
        __typename?: 'Employee';

        id: string;
    };
}

export namespace ResetPassword {
    export type Variables = {
        id: string;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        resetPassword: string;
    };
}

export namespace SetIsActiveAccount {
    export type Variables = {
        id: string;
        isActive: boolean;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        setIsActiveAccount: string;
    };
}

export namespace ChangePassword {
    export type Variables = {
        password: string;
        newPassword: string;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        changePassword: string;
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
    };
}

export namespace UpdateFloor {
    export type Variables = {
        input: FloorUpdateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        updateFloor: UpdateFloor;
    };

    export type UpdateFloor = {
        __typename?: 'Floor';

        id: number;
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

export namespace GetPatrons {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        patrons: Patrons[];
    };

    export type Patrons = {
        __typename?: 'Patron';

        id: number;

        identification: string;

        name: string;

        birthdate: DateTimeOffset;

        email: string;

        gender: boolean;

        residence: string;

        domicile: string;

        phoneNumbers: Maybe<(Maybe<string>)[]>;

        nationality: string;

        company: string;

        note: string;

        patronKind: PatronKind;
    };

    export type PatronKind = {
        __typename?: 'PatronKind';

        id: number;
    };
}

export namespace CreatePatron {
    export type Variables = {
        input: PatronCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        createPatron: CreatePatron;
    };

    export type CreatePatron = {
        __typename?: 'Patron';

        id: number;
    };
}

export namespace UpdatePatron {
    export type Variables = {
        input: PatronUpdateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        updatePatron: UpdatePatron;
    };

    export type UpdatePatron = {
        __typename?: 'Patron';

        id: number;
    };
}

export namespace GetPatronKinds {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        patronKinds: PatronKinds[];
    };

    export type PatronKinds = {
        __typename?: 'PatronKind';

        id: number;

        name: string;

        description: string;

        patrons: Maybe<(Maybe<Patrons>)[]>;
    };

    export type Patrons = {
        __typename?: 'Patron';

        id: number;

        name: string;
    };
}

export namespace CreatePatronKind {
    export type Variables = {
        input: PatronKindCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        createPatronKind: CreatePatronKind;
    };

    export type CreatePatronKind = {
        __typename?: 'PatronKind';

        id: number;
    };
}

export namespace UpdatePatronKind {
    export type Variables = {
        input: PatronKindUpdateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        updatePatronKind: UpdatePatronKind;
    };

    export type UpdatePatronKind = {
        __typename?: 'PatronKind';

        id: number;
    };
}

export namespace GetPositions {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        positions: Positions[];
    };

    export type Positions = {
        __typename?: 'Position';

        id: number;

        name: string;

        permissionCleaning: boolean;

        permissionGetAccountingVoucher: boolean;

        permissionGetHouseKeeping: boolean;

        permissionGetMap: boolean;

        permissionGetPatron: boolean;

        permissionGetRate: boolean;

        permissionGetService: boolean;

        permissionManageEmployee: boolean;

        permissionManageHiringRoom: boolean;

        permissionManageMap: boolean;

        permissionManagePatron: boolean;

        permissionManagePatronKind: boolean;

        permissionManagePosition: boolean;

        permissionManageRate: boolean;

        permissionManageService: boolean;

        isActive: boolean;

        employees: Maybe<(Maybe<Employees>)[]>;
    };

    export type Employees = {
        __typename?: 'Employee';

        id: string;

        isActive: boolean;
    };
}

export namespace CreatePosition {
    export type Variables = {
        input: PositionCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        createPosition: CreatePosition;
    };

    export type CreatePosition = {
        __typename?: 'Position';

        id: number;
    };
}

export namespace UpdatePosition {
    export type Variables = {
        input: PositionUpdateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        updatePosition: UpdatePosition;
    };

    export type UpdatePosition = {
        __typename?: 'Position';

        id: number;
    };
}

export namespace DeletePosition {
    export type Variables = {
        id: string;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        deletePosition: string;
    };
}

export namespace SetIsActivePosition {
    export type Variables = {
        id: string;
        isActive: boolean;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        setIsActivePosition: string;
    };
}

export namespace SetIsActivePositionAndMoveEmployee {
    export type Variables = {
        id: string;
        newId: string;
        isActive: boolean;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        setIsActivePositionAndMoveEmployee: string;
    };
}

export namespace GetReceipts {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        receipts: Receipts[];
    };

    export type Receipts = {
        __typename?: 'Receipt';

        id: number;

        money: number;

        time: DateTimeOffset;

        bankAccountNumber: Maybe<string>;

        bill: Bill;
    };

    export type Bill = {
        __typename?: 'Bill';

        id: number;
    };
}

export namespace CreateReceipt {
    export type Variables = {
        input: ReceiptCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        createReceipt: CreateReceipt;
    };

    export type CreateReceipt = {
        __typename?: 'Receipt';

        id: number;
    };
}

export namespace GetRoomKinds {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        roomKinds: RoomKinds[];
    };

    export type RoomKinds = {
        __typename?: 'RoomKind';

        id: number;

        name: string;

        isActive: boolean;

        amountOfPeople: number;

        numberOfBeds: number;

        rooms: Maybe<(Maybe<Rooms>)[]>;
    };

    export type Rooms = {
        __typename?: 'Room';

        id: number;
    };
}

export namespace CreateRoomKind {
    export type Variables = {
        input: RoomKindCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        createRoomKind: CreateRoomKind;
    };

    export type CreateRoomKind = {
        __typename?: 'RoomKind';

        id: number;

        name: string;

        numberOfBeds: number;

        amountOfPeople: number;

        isActive: boolean;
    };
}

export namespace UpdateRoomKind {
    export type Variables = {
        input: RoomKindUpdateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        updateRoomKind: UpdateRoomKind;
    };

    export type UpdateRoomKind = {
        __typename?: 'RoomKind';

        id: number;
    };
}

export namespace DeleteRoomKind {
    export type Variables = {
        id: string;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        deleteRoomKind: string;
    };
}

export namespace SetIsActiveRoomKind {
    export type Variables = {
        id: string;
        isActive: boolean;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        setIsActiveRoomKind: string;
    };
}

export namespace GetRooms {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        rooms: Rooms[];
    };

    export type Rooms = {
        __typename?: 'Room';

        id: number;

        name: string;

        isActive: boolean;
    };
}

export namespace GetRoom {
    export type Variables = {
        id: string;
    };

    export type Query = {
        __typename?: 'Query';

        room: Room;
    };

    export type Room = {
        __typename?: 'Room';

        id: number;

        name: string;

        isActive: boolean;
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

export namespace UpdateRoom {
    export type Variables = {
        input: RoomUpdateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        updateRoom: UpdateRoom;
    };

    export type UpdateRoom = {
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

export namespace GetServices {
    export type Variables = {};

    export type Query = {
        __typename?: 'Query';

        services: Services[];
    };

    export type Services = {
        __typename?: 'Service';

        id: number;

        name: string;

        unitRate: number;

        unit: string;

        isActive: boolean;

        servicesDetails: Maybe<(Maybe<ServicesDetails>)[]>;
    };

    export type ServicesDetails = {
        __typename?: 'ServicesDetail';

        id: number;

        number: number;
    };
}

export namespace CreateService {
    export type Variables = {
        input: ServiceCreateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        createService: CreateService;
    };

    export type CreateService = {
        __typename?: 'Service';

        id: number;
    };
}

export namespace UpdateService {
    export type Variables = {
        input: ServiceUpdateInput;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        updateService: UpdateService;
    };

    export type UpdateService = {
        __typename?: 'Service';

        id: number;
    };
}

export namespace DeleteService {
    export type Variables = {
        id: string;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        deleteService: string;
    };
}

export namespace SetIsActiveService {
    export type Variables = {
        id: string;
        isActive: boolean;
    };

    export type Mutation = {
        __typename?: 'Mutation';

        setIsActiveService: string;
    };
}
