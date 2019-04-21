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
    patron: PatronId;
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
    listOfPhoneNumbers: string[];
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
    listOfPhoneNumbers: string[];
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
    export interface Variables {
        id: string;
        password: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        login: Login;
    }

    export interface Login {
        __typename?: 'AuthenticationObject';

        token: string;

        employee: Employee;
    }

    export interface Employee {
        __typename?: 'Employee';

        id: string;

        name: string;

        position: Position;
    }

    export interface Position {
        __typename?: 'Position';

        id: number;

        name: string;
    }
}

export namespace UserCheckLogin {
    export interface Variables {}

    export interface Mutation {
        __typename?: 'Mutation';

        checkLogin: CheckLogin;
    }

    export interface CheckLogin {
        __typename?: 'Employee';

        id: string;

        name: string;

        position: Position;
    }

    export interface Position {
        __typename?: 'Position';

        id: number;

        name: string;
    }
}

export namespace GetBills {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        bills: Bills[];
    }

    export interface Bills {
        __typename?: 'Bill';

        id: number;

        time: DateTimeOffset;

        total: number;

        patron: Patron;

        receipts: Maybe<(Maybe<Receipts>)[]>;

        bookings: Maybe<(Maybe<Bookings>)[]>;
    }

    export interface Patron {
        __typename?: 'Patron';

        id: number;

        name: string;
    }

    export interface Receipts {
        __typename?: 'Receipt';

        id: number;

        money: number;
    }

    export interface Bookings {
        __typename?: 'Booking';

        id: number;
    }
}

export namespace AddBookingToBill {
    export interface Variables {
        bill: BillId;
        booking: BookingCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        addBookingToBill: AddBookingToBill;
    }

    export interface AddBookingToBill {
        __typename?: 'Booking';

        id: number;
    }
}

export namespace BookAndCheckIn {
    export interface Variables {
        bookings: BookAndCheckInCreateInput[];
        bill: BillCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        bookAndCheckIn: BookAndCheckIn;
    }

    export interface BookAndCheckIn {
        __typename?: 'Bill';

        id: number;
    }
}

export namespace CreateBill {
    export interface Variables {
        bookings: BookingCreateInput[];
        bill: BillCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createBill: CreateBill;
    }

    export interface CreateBill {
        __typename?: 'Bill';

        id: number;
    }
}

export namespace PayTheBill {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        payTheBill: PayTheBill;
    }

    export interface PayTheBill {
        __typename?: 'Bill';

        id: number;
    }
}

export namespace GetBookings {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        bookings: Bookings[];
    }

    export interface Bookings {
        __typename?: 'Booking';

        id: number;

        bookCheckInTime: Maybe<DateTimeOffset>;

        bookCheckOutTime: Maybe<DateTimeOffset>;

        realCheckInTime: Maybe<DateTimeOffset>;

        realCheckOutTime: Maybe<DateTimeOffset>;

        status: number;

        patrons: (Maybe<Patrons>)[];

        bill: Bill;

        room: Room;
    }

    export interface Patrons {
        __typename?: 'Patron';

        id: number;

        name: string;
    }

    export interface Bill {
        __typename?: 'Bill';

        id: number;
    }

    export interface Room {
        __typename?: 'Room';

        id: number;

        name: string;
    }
}

export namespace GetSimpleBookings {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        bookings: Bookings[];
    }

    export interface Bookings {
        __typename?: 'Booking';

        id: number;

        status: number;

        room: Room;
    }

    export interface Room {
        __typename?: 'Room';

        id: number;

        name: string;
    }
}

export namespace CheckIn {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        checkIn: CheckIn;
    }

    export interface CheckIn {
        __typename?: 'Booking';

        id: number;
    }
}

export namespace RequestCheckOut {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        requestCheckOut: RequestCheckOut;
    }

    export interface RequestCheckOut {
        __typename?: 'Booking';

        id: number;
    }
}

export namespace CheckOut {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        checkOut: CheckOut;
    }

    export interface CheckOut {
        __typename?: 'Booking';

        id: number;
    }
}

export namespace Cancel {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        cancel: string;
    }
}

export namespace GetEmployees {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        employees: Employees[];
    }

    export interface Employees {
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
    }

    export interface Position {
        __typename?: 'Position';

        id: number;

        name: string;
    }
}

export namespace CreateEmployee {
    export interface Variables {
        input: EmployeeCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createEmployee: CreateEmployee;
    }

    export interface CreateEmployee {
        __typename?: 'Employee';

        id: string;
    }
}

export namespace UpdateEmployee {
    export interface Variables {
        input: EmployeeUpdateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        updateEmployee: UpdateEmployee;
    }

    export interface UpdateEmployee {
        __typename?: 'Employee';

        id: string;
    }
}

export namespace ResetPassword {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        resetPassword: string;
    }
}

export namespace SetIsActiveAccount {
    export interface Variables {
        id: string;
        isActive: boolean;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        setIsActiveAccount: string;
    }
}

export namespace ChangePassword {
    export interface Variables {
        password: string;
        newPassword: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        changePassword: string;
    }
}

export namespace GetFloors {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        floors: Floors[];
    }

    export interface Floors {
        __typename?: 'Floor';

        id: number;

        name: string;

        isActive: boolean;

        rooms: Maybe<(Maybe<Rooms>)[]>;
    }

    export interface Rooms {
        __typename?: 'Room';

        id: number;

        name: string;

        isActive: boolean;

        roomKind: RoomKind;
    }

    export interface RoomKind {
        __typename?: 'RoomKind';

        id: number;

        name: string;
    }
}

export namespace GetFloorsMap {
    export interface Variables {
        from: DateTimeOffset;
        to: DateTimeOffset;
    }

    export interface Query {
        __typename?: 'Query';

        floors: Floors[];
    }

    export interface Floors {
        __typename?: 'Floor';

        id: number;

        name: string;

        isActive: boolean;

        rooms: Maybe<(Maybe<Rooms>)[]>;
    }

    export interface Rooms {
        __typename?: 'Room';

        id: number;

        name: string;

        isActive: boolean;

        currentBooking: Maybe<CurrentBooking>;

        roomKind: RoomKind;
    }

    export interface CurrentBooking {
        __typename?: 'Booking';

        id: number;
    }

    export interface RoomKind {
        __typename?: 'RoomKind';

        id: number;

        name: string;
    }
}

export namespace CreateFloor {
    export interface Variables {
        input: FloorCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createFloor: CreateFloor;
    }

    export interface CreateFloor {
        __typename?: 'Floor';

        id: number;
    }
}

export namespace UpdateFloor {
    export interface Variables {
        input: FloorUpdateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        updateFloor: UpdateFloor;
    }

    export interface UpdateFloor {
        __typename?: 'Floor';

        id: number;
    }
}

export namespace DeleteFloor {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        deleteFloor: string;
    }
}

export namespace SetIsActiveFloor {
    export interface Variables {
        id: string;
        isActive: boolean;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        setIsActiveFloor: string;
    }
}

export namespace GetPatrons {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        patrons: Patrons[];
    }

    export interface Patrons {
        __typename?: 'Patron';

        id: number;

        identification: string;

        name: string;

        birthdate: DateTimeOffset;

        email: string;

        gender: boolean;

        residence: string;

        domicile: string;

        phoneNumbers: string[];

        nationality: string;

        company: string;

        note: string;

        patronKind: PatronKind;
    }

    export interface PatronKind {
        __typename?: 'PatronKind';

        id: number;
    }
}

export namespace GetPatron {
    export interface Variables {
        id: string;
    }

    export interface Query {
        __typename?: 'Query';

        patron: Patron;
    }

    export interface Patron {
        __typename?: 'Patron';

        id: number;

        identification: string;

        name: string;

        birthdate: DateTimeOffset;

        email: string;

        gender: boolean;

        residence: string;

        domicile: string;

        phoneNumbers: string[];

        nationality: string;

        company: string;

        note: string;

        patronKind: PatronKind;
    }

    export interface PatronKind {
        __typename?: 'PatronKind';

        id: number;
    }
}

export namespace CreatePatron {
    export interface Variables {
        input: PatronCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createPatron: CreatePatron;
    }

    export interface CreatePatron {
        __typename?: 'Patron';

        id: number;

        identification: string;

        name: string;

        birthdate: DateTimeOffset;

        email: string;

        gender: boolean;

        residence: string;

        domicile: string;

        phoneNumbers: string[];

        nationality: string;

        company: string;

        note: string;

        patronKind: PatronKind;
    }

    export interface PatronKind {
        __typename?: 'PatronKind';

        id: number;
    }
}

export namespace UpdatePatron {
    export interface Variables {
        input: PatronUpdateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        updatePatron: UpdatePatron;
    }

    export interface UpdatePatron {
        __typename?: 'Patron';

        id: number;
    }
}

export namespace GetPatronKinds {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        patronKinds: PatronKinds[];
    }

    export interface PatronKinds {
        __typename?: 'PatronKind';

        id: number;

        name: string;

        description: string;

        patrons: Maybe<(Maybe<Patrons>)[]>;
    }

    export interface Patrons {
        __typename?: 'Patron';

        id: number;

        name: string;
    }
}

export namespace CreatePatronKind {
    export interface Variables {
        input: PatronKindCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createPatronKind: CreatePatronKind;
    }

    export interface CreatePatronKind {
        __typename?: 'PatronKind';

        id: number;
    }
}

export namespace UpdatePatronKind {
    export interface Variables {
        input: PatronKindUpdateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        updatePatronKind: UpdatePatronKind;
    }

    export interface UpdatePatronKind {
        __typename?: 'PatronKind';

        id: number;
    }
}

export namespace GetPositions {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        positions: Positions[];
    }

    export interface Positions {
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
    }

    export interface Employees {
        __typename?: 'Employee';

        id: string;

        isActive: boolean;
    }
}

export namespace CreatePosition {
    export interface Variables {
        input: PositionCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createPosition: CreatePosition;
    }

    export interface CreatePosition {
        __typename?: 'Position';

        id: number;
    }
}

export namespace UpdatePosition {
    export interface Variables {
        input: PositionUpdateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        updatePosition: UpdatePosition;
    }

    export interface UpdatePosition {
        __typename?: 'Position';

        id: number;
    }
}

export namespace DeletePosition {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        deletePosition: string;
    }
}

export namespace SetIsActivePosition {
    export interface Variables {
        id: string;
        isActive: boolean;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        setIsActivePosition: string;
    }
}

export namespace SetIsActivePositionAndMoveEmployee {
    export interface Variables {
        id: string;
        newId: string;
        isActive: boolean;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        setIsActivePositionAndMoveEmployee: string;
    }
}

export namespace GetRates {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        rates: Rates[];
    }

    export interface Rates {
        __typename?: 'Rate';

        id: number;

        dayRate: number;

        effectiveStartDate: DateTimeOffset;

        createDate: DateTimeOffset;

        roomKind: RoomKind;
    }

    export interface RoomKind {
        __typename?: 'RoomKind';

        id: number;

        name: string;
    }
}

export namespace CreateRate {
    export interface Variables {
        input: RateCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createRate: CreateRate;
    }

    export interface CreateRate {
        __typename?: 'Rate';

        id: number;
    }
}

export namespace GetReceipts {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        receipts: Receipts[];
    }

    export interface Receipts {
        __typename?: 'Receipt';

        id: number;

        money: number;

        time: DateTimeOffset;

        bankAccountNumber: Maybe<string>;

        bill: Bill;
    }

    export interface Bill {
        __typename?: 'Bill';

        id: number;
    }
}

export namespace CreateReceipt {
    export interface Variables {
        input: ReceiptCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createReceipt: CreateReceipt;
    }

    export interface CreateReceipt {
        __typename?: 'Receipt';

        id: number;
    }
}

export namespace GetRoomKinds {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        roomKinds: RoomKinds[];
    }

    export interface RoomKinds {
        __typename?: 'RoomKind';

        id: number;

        name: string;

        isActive: boolean;

        amountOfPeople: number;

        numberOfBeds: number;

        rooms: Maybe<(Maybe<Rooms>)[]>;
    }

    export interface Rooms {
        __typename?: 'Room';

        id: number;
    }
}

export namespace CreateRoomKind {
    export interface Variables {
        input: RoomKindCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createRoomKind: CreateRoomKind;
    }

    export interface CreateRoomKind {
        __typename?: 'RoomKind';

        id: number;

        name: string;

        numberOfBeds: number;

        amountOfPeople: number;

        isActive: boolean;
    }
}

export namespace UpdateRoomKind {
    export interface Variables {
        input: RoomKindUpdateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        updateRoomKind: UpdateRoomKind;
    }

    export interface UpdateRoomKind {
        __typename?: 'RoomKind';

        id: number;
    }
}

export namespace DeleteRoomKind {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        deleteRoomKind: string;
    }
}

export namespace SetIsActiveRoomKind {
    export interface Variables {
        id: string;
        isActive: boolean;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        setIsActiveRoomKind: string;
    }
}

export namespace GetRooms {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        rooms: Rooms[];
    }

    export interface Rooms {
        __typename?: 'Room';

        id: number;

        name: string;

        isActive: boolean;
    }
}

export namespace GetRoomsWithIsEmpty {
    export interface Variables {
        from: DateTimeOffset;
        to: DateTimeOffset;
    }

    export interface Query {
        __typename?: 'Query';

        rooms: Rooms[];
    }

    export interface Rooms {
        __typename?: 'Room';

        id: number;

        name: string;

        isActive: boolean;

        isEmpty: boolean;
    }
}

export namespace GetRoom {
    export interface Variables {
        id: string;
    }

    export interface Query {
        __typename?: 'Query';

        room: Room;
    }

    export interface Room {
        __typename?: 'Room';

        id: number;

        name: string;

        isActive: boolean;
    }
}

export namespace CreateRoom {
    export interface Variables {
        input: RoomCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createRoom: CreateRoom;
    }

    export interface CreateRoom {
        __typename?: 'Room';

        id: number;
    }
}

export namespace UpdateRoom {
    export interface Variables {
        input: RoomUpdateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        updateRoom: UpdateRoom;
    }

    export interface UpdateRoom {
        __typename?: 'Room';

        id: number;
    }
}

export namespace DeleteRoom {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        deleteRoom: string;
    }
}

export namespace SetIsActiveRoom {
    export interface Variables {
        id: string;
        isActive: boolean;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        setIsActiveRoom: string;
    }
}

export namespace CreateServicesDetail {
    export interface Variables {
        input: ServicesDetailCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createServicesDetail: CreateServicesDetail;
    }

    export interface CreateServicesDetail {
        __typename?: 'ServicesDetail';

        id: number;
    }
}

export namespace GetServices {
    export interface Variables {}

    export interface Query {
        __typename?: 'Query';

        services: Services[];
    }

    export interface Services {
        __typename?: 'Service';

        id: number;

        name: string;

        unitRate: number;

        unit: string;

        isActive: boolean;

        servicesDetails: Maybe<(Maybe<ServicesDetails>)[]>;
    }

    export interface ServicesDetails {
        __typename?: 'ServicesDetail';

        id: number;

        number: number;
    }
}

export namespace CreateService {
    export interface Variables {
        input: ServiceCreateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        createService: CreateService;
    }

    export interface CreateService {
        __typename?: 'Service';

        id: number;
    }
}

export namespace UpdateService {
    export interface Variables {
        input: ServiceUpdateInput;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        updateService: UpdateService;
    }

    export interface UpdateService {
        __typename?: 'Service';

        id: number;
    }
}

export namespace DeleteService {
    export interface Variables {
        id: string;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        deleteService: string;
    }
}

export namespace SetIsActiveService {
    export interface Variables {
        id: string;
        isActive: boolean;
    }

    export interface Mutation {
        __typename?: 'Mutation';

        setIsActiveService: string;
    }
}
