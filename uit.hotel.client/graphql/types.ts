export type Maybe<T> = T | null;
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
    ID: string;
    String: string;
    Boolean: boolean;
    Int: number;
    Float: number;
    /** The `DateTimeOffset` scalar type represents a date, time and offset from UTC.
     * `DateTimeOffset` expects timestamps to be formatted in accordance with the
     * [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard.
     */
    DateTimeOffset: string | Date;
    /** The `Date` scalar type represents a year, month and day in accordance with the
     * [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard.
     */
    Date: string | Date;
    /** The `DateTime` scalar type represents a date and time. `DateTime` expects
     * timestamps to be formatted in accordance with the
     * [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard.
     */
    DateTime: string | Date;
    Decimal: number;
    /** The `Milliseconds` scalar type represents a period of time represented as the total number of milliseconds. */
    Milliseconds: number;
    /** The `Seconds` scalar type represents a period of time represented as the total number of seconds. */
    Seconds: number;
};

export type AppMutation = {
    /** Thêm phòng khách đoàn */
    addBookingToBill: Booking;
    /** Đặt và nhận phòng ngay tại khách sạn */
    bookAndCheckIn: Bill;
    /** Hủy đặt phòng */
    cancel: Scalars['String'];
    /** Tạo và trả về một đơn đặt phòng */
    createBill: Bill;
    /** Tạo và trả về một nhân viên mới */
    createEmployee: Employee;
    /** Tạo và trả về một tầng mới */
    createFloor: Floor;
    /** Tạo và trả về một khách hàng mới */
    createPatron: Patron;
    /** Tạo và trả về một loại khách hàng mới */
    createPatronKind: PatronKind;
    /** Tạo và trả về một chức vụ mới */
    createPosition: Position;
    /** Tạo và trả về một loại giá cơ bản mới */
    createRate: Rate;
    /** Tạo và trả về một phiếu thu mới */
    createReceipt: Receipt;
    /** Tạo và trả về một phòng mới */
    createRoom: Room;
    /** Tạo và trả về một loại phòng */
    createRoomKind: RoomKind;
    /** Tạo và trả về một dịch vụ mới */
    createService: Service;
    /** Tạo và trả về một chi tiết dịch vụ mới */
    createServicesDetail: ServicesDetail;
    /** Tạo và trả về một giá biến động mới */
    createVolatilityRate: VolatilityRate;
    /** Nhân viên tự đổi mật khẩu cho tài khoản của mình */
    changePassword: Scalars['String'];
    /** Cập nhật thời gian checkin của phòng */
    checkIn: Booking;
    /** Kiểm tra đăng nhập */
    checkLogin: Employee;
    /** Thực hiện xác nhận trả phòng */
    checkOut: Booking;
    /** Xóa một tầng */
    deleteFloor: Scalars['String'];
    /** Xóa một loại khách hàng */
    deletePatronKind: Scalars['String'];
    /** Xóa một chức vụ */
    deletePosition: Scalars['String'];
    /** Xóa một giá cơ bản */
    deleteRate: Scalars['String'];
    /** Xóa một phòng */
    deleteRoom: Scalars['String'];
    /** Xóa một loại phòng */
    deleteRoomKind: Scalars['String'];
    /** Xóa một dịch vụ */
    deleteService: Scalars['String'];
    /** Xóa một dịch vụ */
    deleteServicesDetail: Scalars['String'];
    /** Xóa một giá biến động */
    deleteVolatilityRate: Scalars['String'];
    /** Khởi tạo tài khoản admin */
    initializeAdminAccount: Scalars['String'];
    /** Khởi tạo dữ liệu */
    initializeDatabase: Scalars['String'];
    /** Đăng nhập mới */
    login: AuthenticationObject;
    /** Thanh toán hóa đơn (thanh toán tiền phòng) */
    payTheBill: Bill;
    /** Reset lại mật khẩu cho nhân viên khi quên mật khẩu */
    resetPassword: Scalars['String'];
    /** Vô hiệu hóa/ kích hoạt tài khoản */
    setIsActiveAccount: Scalars['String'];
    /** Cập nhật trạng thái hoạt động của tầng */
    setIsActiveFloor: Scalars['String'];
    /** Cập nhật trạng thái hoạt động của chức vụ */
    setIsActivePosition: Scalars['String'];
    /** Vô hiệu hóa chức vụ và chuyển nhân viên sang chức vụ mới */
    setIsActivePositionAndMoveEmployee: Scalars['String'];
    /** Cập nhật trạng thái hoạt động của một phòng */
    setIsActiveRoom: Scalars['String'];
    /** Cập nhật trạng thái hoạt động của loại phòng */
    setIsActiveRoomKind: Scalars['String'];
    /** Cập nhật trạng thái của dịch vụ */
    setIsActiveService: Scalars['String'];
    /** Cập nhật trạng thái dọn phòng của một phòng */
    setIsCleanRoom: Scalars['String'];
    /** Chỉnh sửa thông tin nhân viên */
    updateEmployee: Employee;
    /** Cập nhật và trả về một tầng vừa cập nhật */
    updateFloor: Floor;
    /** Cập nhật và trả về một khách hàng vừa cập nhật */
    updatePatron: Patron;
    /** Cập nhật và trả về một loại khách hàng vừa cập nhật */
    updatePatronKind: PatronKind;
    /** Cập nhật và trả về một chức vụ vừa cập nhật */
    updatePosition: Position;
    /** Cập nhật và trả về một giá cơ bản vừa cập nhật */
    updateRate: Rate;
    /** Cập nhật và trả về một phòng vừa cập nhật */
    updateRoom: Room;
    /** Cập nhật và trả về loại phòng vừa cập nhật */
    updateRoomKind: RoomKind;
    /** Cập nhật và trả về một dịch vụ mới cập nhật */
    updateService: Service;
    /** Cập nhật và trả về một chi tiết dịch vụ mới cập nhật */
    updateServicesDetail: ServicesDetail;
    /** Cập nhật và trả về một giá biến động vừa cập nhật */
    updateVolatilityRate: VolatilityRate;
};

export type AppMutationAddBookingToBillArgs = {
    bill: BillId;
    booking: BookingCreateInput;
};

export type AppMutationBookAndCheckInArgs = {
    bookings: Array<BookAndCheckInCreateInput>;
    bill: BillCreateInput;
};

export type AppMutationCancelArgs = {
    id: Scalars['ID'];
};

export type AppMutationCreateBillArgs = {
    bookings: Array<BookingCreateInput>;
    bill: BillCreateInput;
};

export type AppMutationCreateEmployeeArgs = {
    input: EmployeeCreateInput;
};

export type AppMutationCreateFloorArgs = {
    input: FloorCreateInput;
};

export type AppMutationCreatePatronArgs = {
    input: PatronCreateInput;
};

export type AppMutationCreatePatronKindArgs = {
    input: PatronKindCreateInput;
};

export type AppMutationCreatePositionArgs = {
    input: PositionCreateInput;
};

export type AppMutationCreateRateArgs = {
    input: RateCreateInput;
};

export type AppMutationCreateReceiptArgs = {
    input: ReceiptCreateInput;
};

export type AppMutationCreateRoomArgs = {
    input: RoomCreateInput;
};

export type AppMutationCreateRoomKindArgs = {
    input: RoomKindCreateInput;
};

export type AppMutationCreateServiceArgs = {
    input: ServiceCreateInput;
};

export type AppMutationCreateServicesDetailArgs = {
    input: ServicesDetailCreateInput;
};

export type AppMutationCreateVolatilityRateArgs = {
    input: VolatilityRateCreateInput;
};

export type AppMutationChangePasswordArgs = {
    password: Scalars['String'];
    newPassword: Scalars['String'];
};

export type AppMutationCheckInArgs = {
    id: Scalars['ID'];
};

export type AppMutationCheckOutArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeleteFloorArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeletePatronKindArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeletePositionArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeleteRateArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeleteRoomArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeleteRoomKindArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeleteServiceArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeleteServicesDetailArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeleteVolatilityRateArgs = {
    id: Scalars['ID'];
};

export type AppMutationInitializeAdminAccountArgs = {
    email: Scalars['String'];
    password: Scalars['String'];
};

export type AppMutationLoginArgs = {
    id: Scalars['String'];
    password: Scalars['String'];
};

export type AppMutationPayTheBillArgs = {
    id: Scalars['ID'];
};

export type AppMutationResetPasswordArgs = {
    id: Scalars['ID'];
};

export type AppMutationSetIsActiveAccountArgs = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type AppMutationSetIsActiveFloorArgs = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type AppMutationSetIsActivePositionArgs = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type AppMutationSetIsActivePositionAndMoveEmployeeArgs = {
    id: Scalars['ID'];
    newId: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type AppMutationSetIsActiveRoomArgs = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type AppMutationSetIsActiveRoomKindArgs = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type AppMutationSetIsActiveServiceArgs = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type AppMutationSetIsCleanRoomArgs = {
    id: Scalars['ID'];
    isClean: Scalars['Boolean'];
};

export type AppMutationUpdateEmployeeArgs = {
    input: EmployeeUpdateInput;
};

export type AppMutationUpdateFloorArgs = {
    input: FloorUpdateInput;
};

export type AppMutationUpdatePatronArgs = {
    input: PatronUpdateInput;
};

export type AppMutationUpdatePatronKindArgs = {
    input: PatronKindUpdateInput;
};

export type AppMutationUpdatePositionArgs = {
    input: PositionUpdateInput;
};

export type AppMutationUpdateRateArgs = {
    input: RateUpdateInput;
};

export type AppMutationUpdateRoomArgs = {
    input: RoomUpdateInput;
};

export type AppMutationUpdateRoomKindArgs = {
    input: RoomKindUpdateInput;
};

export type AppMutationUpdateServiceArgs = {
    input: ServiceUpdateInput;
};

export type AppMutationUpdateServicesDetailArgs = {
    input: ServicesDetailUpdateInput;
};

export type AppMutationUpdateVolatilityRateArgs = {
    input: VolatilityRateUpdateInput;
};

export type AppQuery = {
    /** Trả về thông tin một hóa đơn */
    bill: Bill;
    /** Trả về một danh sách các hóa đơn */
    bills: Array<Bill>;
    /** Trả về thông tin một đơn đặt phòng */
    booking: Booking;
    /** Trả về một danh sách các đơn đặt phòng */
    bookings: Array<Booking>;
    /** Trả về thông tin một nhân viên */
    employee: Employee;
    /** Trả về một danh sách các nhân viên */
    employees: Array<Employee>;
    /** Trả về danh sách khách hàng theo từ khóa tìm kiếm */
    findingPatron: Array<Patron>;
    /** Trả về thông tin một tầng */
    floor: Floor;
    /** Trả về một danh sách các tầng */
    floors: Array<Floor>;
    /** Kiểm tra */
    isInitialized: Scalars['Boolean'];
    /** Trả về thông tin một khách hàng */
    patron: Patron;
    /** Trả về thông tin của một loại khách hàng */
    patronKind: PatronKind;
    /** Trả về một danh sách các loại khách hàng có trong hệ thống */
    patronKinds: Array<PatronKind>;
    /** Trả về một danh sách các khách hàng */
    patrons: Array<Patron>;
    /** Trả về thông tin một chức vụ */
    position: Position;
    /** Trả về một danh sách các chức vụ */
    positions: Array<Position>;
    /** Trả về thông tin một loại giá cơ bản */
    rate: Rate;
    /** Trả về một danh sách các loại giá cơ bản */
    rates: Array<Rate>;
    /** Trả về thông tin một phiếu thu */
    receipt: Receipt;
    /** Trả về một danh sách các phiếu thu */
    receipts: Array<Receipt>;
    /** Trả về thông tin của một phòng */
    room: Room;
    /** Trả về thông tin của một loại phòng */
    roomKind: RoomKind;
    /** Trả về một danh sách các loại phòng */
    roomKinds: Array<RoomKind>;
    /** Trả về một danh sách các phòng */
    rooms: Array<Room>;
    /** Trả về thông tin một dịch vụ */
    service: Service;
    /** Trả về một danh sách các dịch vụ */
    services: Array<Service>;
    /** Trả về thông tin một chi tiết dịch vụ */
    servicesDetail: ServicesDetail;
    /** Trả về một danh sách các chi tiết dịch vụ */
    servicesDetails: Array<ServicesDetail>;
    /** Trả về thông tin một giá biến động */
    volatilityRate: VolatilityRate;
    /** Trả về một danh sách các giá biến động */
    volatilityRates: Array<VolatilityRate>;
};

export type AppQueryBillArgs = {
    id: Scalars['ID'];
};

export type AppQueryBookingArgs = {
    id: Scalars['ID'];
};

export type AppQueryEmployeeArgs = {
    id: Scalars['ID'];
};

export type AppQueryFindingPatronArgs = {
    id: Scalars['ID'];
};

export type AppQueryFloorArgs = {
    id: Scalars['ID'];
};

export type AppQueryPatronArgs = {
    id: Scalars['ID'];
};

export type AppQueryPatronKindArgs = {
    id: Scalars['ID'];
};

export type AppQueryPositionArgs = {
    id: Scalars['ID'];
};

export type AppQueryRateArgs = {
    id: Scalars['ID'];
};

export type AppQueryReceiptArgs = {
    id: Scalars['ID'];
};

export type AppQueryRoomArgs = {
    id: Scalars['ID'];
};

export type AppQueryRoomKindArgs = {
    id: Scalars['ID'];
};

export type AppQueryServiceArgs = {
    id: Scalars['ID'];
};

export type AppQueryServicesDetailArgs = {
    id: Scalars['ID'];
};

export type AppQueryVolatilityRateArgs = {
    id: Scalars['ID'];
};

/** Một đối tượng đăng nhập */
export type AuthenticationObject = {
    /** Thông tin nhân viên đăng nhập */
    employee: Employee;
    /** Token đăng nhập */
    token: Scalars['String'];
};

/** Một phiếu hóa đơn của khách hàng */
export type Bill = {
    /** Danh sách các thông tin đặt trước của hóa đơn */
    bookings: Maybe<Array<Maybe<Booking>>>;
    /** Thông tin nhân viên nhận thanh toán hóa đơn */
    employee: Maybe<Employee>;
    /** Id của hóa đơn */
    id: Scalars['Int'];
    /** Thông tin khách hàng thanh toán hóa đơn */
    patron: Patron;
    /** Danh sách các biên nhận cho hóa đơn */
    receipts: Maybe<Array<Maybe<Receipt>>>;
    /** Thời điểm in hóa đơn */
    time: Scalars['DateTimeOffset'];
    /** Tổng giá trị hóa đơn */
    total: Scalars['Int'];
    /** Tổng giá trị các phiếu thu */
    totalReceipts: Scalars['Int'];
};

export type BillCreateInput = {
    /** Khách hàng */
    patron: PatronId;
};

/** Input cho thông tin một hóa đơn */
export type BillId = {
    /** Id của hóa đơn */
    id: Scalars['Int'];
};

export type BookAndCheckInCreateInput = {
    /** Thời điểm trả phòng dự kiến của khách hàng */
    bookCheckOutTime: Scalars['DateTimeOffset'];
    /** Phòng khách hàng chọn đặt trước */
    room: RoomId;
    /** Danh sách khách hàng */
    listOfPatrons: Array<PatronId>;
};

/** Một thông tin thuê phòng của khách hàng */
export type Booking = {
    /** Thông tin hóa đơn của thông tin thuê phòng */
    bill: Bill;
    /** Thời điểm nhận phòng dự kiến của khách hàng */
    bookCheckInTime: Scalars['DateTimeOffset'];
    /** Thời điểm trả phòng dự kiến của khách hàng */
    bookCheckOutTime: Scalars['DateTimeOffset'];
    /** Thời điểm tạo thông tin thuê phòng */
    createTime: Scalars['DateTimeOffset'];
    /** Nhân viên thực hiện giao dịch nhận đặt phòng từ khách hàng */
    employeeBooking: Maybe<Employee>;
    /** Nhân viên thực hiện check-in cho khách hàng */
    employeeCheckIn: Maybe<Employee>;
    /** Nhân viên thực hiện check-out cho khách hàng */
    employeeCheckOut: Maybe<Employee>;
    /** Id của thông tin thuê phòng */
    id: Scalars['Int'];
    /** Danh sách khách hàng yêu cầu đặt phòng */
    patrons: Array<Maybe<Patron>>;
    /** Thời điểm nhận phòng của khách hàng */
    realCheckInTime: Maybe<Scalars['DateTimeOffset']>;
    /** Thời điểm trả phòng của khách hàng */
    realCheckOutTime: Maybe<Scalars['DateTimeOffset']>;
    /** Phòng khách hàng chọn đặt trước */
    room: Room;
    /** Danh sách chi tiết sử dụng dịch vụ của khách hàng */
    servicesDetails: Maybe<Array<Maybe<ServicesDetail>>>;
    /** Trạng thái của thông tin thuê phòng */
    status: Scalars['Int'];
    /** Tổng tiền của booking */
    total: Scalars['Int'];
    /** Tổng tiền của booking */
    totalRates: Scalars['Int'];
    /** Tổng tiền của booking */
    totalServicesDetails: Scalars['Int'];
    /** Tổng tiền của booking */
    totalVolatilityRate: Scalars['Int'];
};

export type BookingCreateInput = {
    /** Thời điểm nhận phòng dự kiến của khách hàng */
    bookCheckInTime: Scalars['DateTimeOffset'];
    /** Thời điểm trả phòng dự kiến của khách hàng */
    bookCheckOutTime: Scalars['DateTimeOffset'];
    /** Phòng khách hàng chọn đặt trước */
    room: RoomId;
    /** Danh sách khách hàng */
    listOfPatrons: Array<PatronId>;
};

/** Input cho một thông tin một đơn đặt phòng */
export type BookingId = {
    /** Id của một đơn đặt phòng */
    id: Scalars['Int'];
};

/** Một nhân viên trong khách sạn */
export type Employee = {
    /** Địa chỉ của nhân viên */
    address: Scalars['String'];
    /** Danh sách các Hóa đơn mà nhân viên tạo */
    bills: Array<Bill>;
    /** Ngày sinh của nhân viên */
    birthdate: Scalars['DateTimeOffset'];
    /** Danh sách các Thông tin thuê phòng mà nhân viên tạo */
    bookings: Array<Booking>;
    /** Email của nhân viên */
    email: Scalars['String'];
    /** Giới tính của nhân viên */
    gender: Scalars['Boolean'];
    /** Id của nhân viên */
    id: Scalars['String'];
    /** Chứng minh nhân dân */
    identityCard: Scalars['String'];
    /** Tài khoản còn hiệu lực hay không */
    isActive: Scalars['Boolean'];
    /** Tên nhân viên */
    name: Scalars['String'];
    /** Chức vụ */
    position: Position;
    /** Số điện thoại của nhân viên */
    phoneNumber: Scalars['String'];
    /** Danh sách các Giá cơ bản mà nhân viên tạo */
    rates: Array<Rate>;
    /** Danh sách các Phiếu thu mà nhân viên tạo */
    receipts: Array<Receipt>;
    /** Ngày vào làm */
    startingDate: Scalars['DateTimeOffset'];
    /** Danh sách các Giá biến động mà nhân viên tạo */
    volatilityRates: Array<VolatilityRate>;
};

export type EmployeeCreateInput = {
    /** Id của nhân viên */
    id: Scalars['String'];
    /** Mật khẩu của tài khoản nhân viên */
    password: Scalars['String'];
    /** Tên nhân viên */
    name: Scalars['String'];
    /** Chứng minh nhân dân */
    identityCard: Scalars['String'];
    /** Số điện thoại của nhân viên */
    phoneNumber: Scalars['String'];
    /** Địa chỉ của nhân viên */
    address: Scalars['String'];
    /** Email của nhân viên */
    email: Scalars['String'];
    /** Ngày sinh của nhân viên */
    birthdate: Scalars['DateTimeOffset'];
    /** Giới tính của nhân viên */
    gender: Scalars['Boolean'];
    /** Ngày vào làm */
    startingDate: Scalars['DateTimeOffset'];
    /** Loại chức vụ */
    position: PositionId;
};

export type EmployeeUpdateInput = {
    /** Id của nhân viên */
    id: Scalars['String'];
    /** Tên nhân viên */
    name: Scalars['String'];
    /** Chứng minh nhân dân */
    identityCard: Scalars['String'];
    /** Địa chỉ của nhân viên */
    address: Scalars['String'];
    /** Ngày sinh của nhân viên */
    birthdate: Scalars['DateTimeOffset'];
    /** Email của nhân viên */
    email: Scalars['String'];
    /** Giới tính của nhân viên */
    gender: Scalars['Boolean'];
    /** Số điện thoại của nhân viên */
    phoneNumber: Scalars['String'];
    /** Ngày vào làm */
    startingDate: Scalars['DateTimeOffset'];
    /** Loại chức vụ */
    position: PositionId;
};

/** Một tầng trong khách sạn */
export type Floor = {
    /** Id của tầng */
    id: Scalars['Int'];
    /** Trạng thái hoạt động */
    isActive: Scalars['Boolean'];
    /** Tên tầng */
    name: Scalars['String'];
    /** Danh sách các phòng có trong tầng */
    rooms: Array<Room>;
};

export type FloorCreateInput = {
    /** Tên tầng */
    name: Scalars['String'];
};

/** Input cho một thông tin tầng */
export type FloorId = {
    /** Id của tầng */
    id: Scalars['Int'];
};

export type FloorUpdateInput = {
    /** Id tầng cần cập nhật */
    id: Scalars['Int'];
    /** Tên tầng */
    name: Scalars['String'];
};

/** Thông tin  một khách hàng của khách sạn */
export type Patron = {
    /** Danh sách các số hóa đơn của khách hàng */
    bills: Array<Bill>;
    /** Ngày sinh của khách hàng */
    birthdate: Scalars['DateTimeOffset'];
    /** Danh sách các đơn đặt trước của khách hàng */
    bookings: Array<Booking>;
    /** Công ty mà khách hàng đang làm việc */
    company: Scalars['String'];
    /** Nguyên quán của khách hàng */
    domicile: Scalars['String'];
    /** Địa chỉ e-mail của khách hàng */
    email: Scalars['String'];
    /** Giới tính của khách hàng */
    gender: Scalars['Boolean'];
    /** Id của khách hàng */
    id: Scalars['Int'];
    /** Số an sinh xã hội / Số chứng minh nhân dân / Số passport của khách hàng */
    identification: Scalars['String'];
    /** Tên của khách hàng */
    name: Scalars['String'];
    /** Quốc tịch của khách hàng */
    nationality: Scalars['String'];
    /** Một số chú thích về khách hàng nếu cần thiết */
    note: Scalars['String'];
    /** Loại khách hàng */
    patronKind: PatronKind;
    /** Danh sách số điện thoại của khách hàng */
    phoneNumbers: Array<Scalars['String']>;
    /** Địa chỉ thường trú của khách hàng */
    residence: Scalars['String'];
};

export type PatronCreateInput = {
    /** Số an sinh xã hội / Số chứng minh nhân dân / Số passport của khách hàng */
    identification: Scalars['String'];
    /** Tên của khách hàng */
    name: Scalars['String'];
    /** Địa chỉ e-mail của khách hàng */
    email: Scalars['String'];
    /** Giới tính của khách hàng */
    gender: Scalars['Boolean'];
    /** Ngày sinh của khách hàng */
    birthdate: Maybe<Scalars['DateTimeOffset']>;
    /** Quốc tịch của khách hàng */
    nationality: Scalars['String'];
    /** Nguyên quán của khách hàng */
    domicile: Scalars['String'];
    /** Địa chỉ thường trú của khách hàng */
    residence: Scalars['String'];
    /** Công ty mà khách hàng đang làm việc */
    company: Scalars['String'];
    /** Một số chú thích về khách hàng nếu cần thiết */
    note: Scalars['String'];
    /** Danh sách số điện thoại của khách hàng */
    listOfPhoneNumbers: Array<Scalars['String']>;
    /** Loại khách hàng */
    patronKind: PatronKindId;
};

/** Input cho thông tin một khách hàng */
export type PatronId = {
    /** Id của khách hàng */
    id: Scalars['Int'];
};

/** Thông tin  một loại khách hàng */
export type PatronKind = {
    /** Thông tin mô tả loại khách hàng */
    description: Scalars['String'];
    /** Id của loại khách hàng */
    id: Scalars['Int'];
    /** Tên loại khách hàng */
    name: Scalars['String'];
    /** Danh sách các khách hàng thuộc loại khách hàng */
    patrons: Maybe<Array<Maybe<Patron>>>;
};

export type PatronKindCreateInput = {
    /** Tên loại khách hàng */
    name: Scalars['String'];
    /** Thông tin mô tả loại khách hàng */
    description: Scalars['String'];
};

/** Input cho thông tin  một loại khách hàng */
export type PatronKindId = {
    /** Id của loại khách hàng */
    id: Scalars['Int'];
};

export type PatronKindUpdateInput = {
    /** Id của loại khách hàng */
    id: Scalars['Int'];
    /** Tên loại khách hàng */
    name: Scalars['String'];
    /** Thông tin mô tả loại khách hàng */
    description: Scalars['String'];
};

export type PatronUpdateInput = {
    /** Id của khách hàng */
    id: Scalars['Int'];
    /** Số an sinh xã hội / Số chứng minh nhân dân / Số passport của khách hàng */
    identification: Scalars['String'];
    /** Tên của khách hàng */
    name: Scalars['String'];
    /** Địa chỉ e-mail của khách hàng */
    email: Scalars['String'];
    /** Giới tính của khách hàng */
    gender: Scalars['Boolean'];
    /** Ngày sinh của khách hàng */
    birthdate: Scalars['DateTimeOffset'];
    /** Quốc tịch của khách hàng */
    nationality: Scalars['String'];
    /** Nguyên quán của khách hàng */
    domicile: Scalars['String'];
    /** Địa chỉ thường trú của khách hàng */
    residence: Scalars['String'];
    /** Công ty mà khách hàng đang làm việc */
    company: Scalars['String'];
    /** Một số chú thích về khách hàng nếu cần thiết */
    note: Scalars['String'];
    /** Danh sách số điện thoại của khách hàng */
    listOfPhoneNumbers: Array<Scalars['String']>;
    /** Loại khách hàng */
    patronKind: PatronKindId;
};

/** Một chức vụ trong khách sạn */
export type Position = {
    /** Số nhân viên còn hoạt động */
    countActiveEmployees: Scalars['Int'];
    /** Số nhân viên */
    countEmployees: Scalars['Int'];
    /** Số nhân viên ngưng hoạt động */
    countInActiveEmployees: Scalars['Int'];
    /** Danh sách các nhân viên thuộc quyền này */
    employees: Maybe<Array<Maybe<Employee>>>;
    /** Id của chức vụ */
    id: Scalars['Int'];
    /** Trạng thái kích hoạt/vô hiệu hóa chức vụ */
    isActive: Scalars['Boolean'];
    /** Tên chức vụ */
    name: Scalars['String'];
    /** Quyền thao tác dọn phòng */
    permissionCleaning: Scalars['Boolean'];
    /** Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu) */
    permissionGetAccountingVoucher: Scalars['Boolean'];
    /** Quyền lấy thông tin tầng, phòng */
    permissionGetMap: Scalars['Boolean'];
    /** Quyền lấy thông tin khách hàng */
    permissionGetPatron: Scalars['Boolean'];
    /** Quyền lấy thông tin giá cơ bản và giá biến động */
    permissionGetRate: Scalars['Boolean'];
    /** Quyền lấy thông tin dịch vụ */
    permissionGetService: Scalars['Boolean'];
    /** Quyền quản lý thông tin nhân viên */
    permissionManageEmployee: Scalars['Boolean'];
    /** Quyền chỉnh sửa sơ đồ */
    permissionManageMap: Scalars['Boolean'];
    /** Quyền quản lý khách hàng */
    permissionManagePatron: Scalars['Boolean'];
    /** Quyền quản lý loại khách hàng */
    permissionManagePatronKind: Scalars['Boolean'];
    /** Quyền quản lý chức vụ */
    permissionManagePosition: Scalars['Boolean'];
    /** Quyền quản lý giá cơ bản và giá biến động */
    permissionManageRate: Scalars['Boolean'];
    /** Quyền quản lý thuê phòng */
    permissionManageRentingRoom: Scalars['Boolean'];
    /** Quyền quản lý dịch vụ */
    permissionManageService: Scalars['Boolean'];
};

export type PositionCreateInput = {
    /** Tên chức vụ */
    name: Scalars['String'];
    /** Quyền thao tác dọn phòng */
    permissionCleaning: Scalars['Boolean'];
    /** Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu) */
    permissionGetAccountingVoucher: Scalars['Boolean'];
    /** Quyền lấy thông tin tầng, phòng */
    permissionGetMap: Scalars['Boolean'];
    /** Quyền lấy thông tin khách hàng */
    permissionGetPatron: Scalars['Boolean'];
    /** Quyền lấy thông tin giá cơ bản và giá biến động */
    permissionGetRate: Scalars['Boolean'];
    /** Quyền lấy thông tin dịch vụ */
    permissionGetService: Scalars['Boolean'];
    /** Quyền quản lý thông tin nhân viên */
    permissionManageEmployee: Scalars['Boolean'];
    /** Quyền quản lý thuê phòng */
    permissionManageRentingRoom: Scalars['Boolean'];
    /** Quyền quản lý khách hàng */
    permissionManagePatron: Scalars['Boolean'];
    /** Quyền quản lý loại khách hàng */
    permissionManagePatronKind: Scalars['Boolean'];
    /** Quyền quản lý chức vụ */
    permissionManagePosition: Scalars['Boolean'];
    /** Quyền quản lý giá cơ bản và giá biến động */
    permissionManageRate: Scalars['Boolean'];
    /** Quyền quản lý dịch vụ */
    permissionManageService: Scalars['Boolean'];
    /** Quyền chỉnh sửa sơ đồ */
    permissionManageMap: Scalars['Boolean'];
};

/** Input cho thông tin một chức vụ */
export type PositionId = {
    /** Id của chức vụ */
    id: Scalars['Int'];
};

export type PositionUpdateInput = {
    /** Id của chức vụ */
    id: Scalars['Int'];
    /** Tên chức vụ */
    name: Scalars['String'];
    /** Quyền thao tác dọn phòng */
    permissionCleaning: Scalars['Boolean'];
    /** Quyền lấy thông tin tầng, phòng */
    permissionGetMap: Scalars['Boolean'];
    /** Quyền lấy thông tin khách hàng */
    permissionGetPatron: Scalars['Boolean'];
    /** Quyền lấy thông tin giá cơ bản và giá biến động */
    permissionGetRate: Scalars['Boolean'];
    /** Quyền lấy thông tin dịch vụ */
    permissionGetService: Scalars['Boolean'];
    /** Quyền lấy thông tin các chứng từ (hóa đơn, phiếu thu) */
    permissionGetAccountingVoucher: Scalars['Boolean'];
    /** Quyền quản lý thông tin nhân viên */
    permissionManageEmployee: Scalars['Boolean'];
    /** Quyền quản lý thuê phòng */
    permissionManageRentingRoom: Scalars['Boolean'];
    /** Quyền chỉnh sửa sơ đồ */
    permissionManageMap: Scalars['Boolean'];
    /** Quyền quản lý khách hàng */
    permissionManagePatron: Scalars['Boolean'];
    /** Quyền quản lý loại khách hàng */
    permissionManagePatronKind: Scalars['Boolean'];
    /** Quyền quản lý chức vụ */
    permissionManagePosition: Scalars['Boolean'];
    /** Quyền quản lý giá cơ bản và giá biến động */
    permissionManageRate: Scalars['Boolean'];
    /** Quyền quản lý dịch vụ */
    permissionManageService: Scalars['Boolean'];
};

/** Giá cố định của một loại phòng */
export type Rate = {
    /** Ngày tạo giá */
    createDate: Scalars['DateTimeOffset'];
    /** Giá ngày */
    dayRate: Scalars['Int'];
    /** Phí check-out sớm */
    earlyCheckInFee: Scalars['Int'];
    /** Ngày giá bắt đầu có hiệu lực */
    effectiveStartDate: Scalars['DateTimeOffset'];
    /** Nhân viên tạo giá */
    employee: Maybe<Employee>;
    /** Id của giá */
    id: Scalars['Int'];
    /** Phí check-out muộn */
    lateCheckOutFee: Scalars['Int'];
    /** Giá tháng */
    monthRate: Scalars['Int'];
    /** Giá đêm */
    nightRate: Scalars['Int'];
    /** Thuộc loại phòng */
    roomKind: RoomKind;
    /** Giá tuần */
    weekRate: Scalars['Int'];
};

export type RateCreateInput = {
    /** Giá ngày */
    dayRate: Scalars['Int'];
    /** Giá đêm */
    nightRate: Scalars['Int'];
    /** Giá tuần */
    weekRate: Scalars['Int'];
    /** Giá tháng */
    monthRate: Scalars['Int'];
    /** Phí check-out muộn */
    lateCheckOutFee: Scalars['Int'];
    /** Phí check-out sớm */
    earlyCheckInFee: Scalars['Int'];
    /** Ngày giá bắt đầu có hiệu lực */
    effectiveStartDate: Scalars['DateTimeOffset'];
    /** Loại phòng */
    roomKind: RoomKindId;
};

export type RateUpdateInput = {
    /** Id của giá cần cập nhật */
    id: Scalars['Int'];
    /** Giá ngày */
    dayRate: Scalars['Int'];
    /** Giá đêm */
    nightRate: Scalars['Int'];
    /** Giá tuần */
    weekRate: Scalars['Int'];
    /** Giá tháng */
    monthRate: Scalars['Int'];
    /** Phí check-out muộn */
    lateCheckOutFee: Scalars['Int'];
    /** Phí check-out sớm */
    earlyCheckInFee: Scalars['Int'];
    /** Ngày giá bắt đầu có hiệu lực */
    effectiveStartDate: Scalars['DateTimeOffset'];
    /** Loại phòng */
    roomKind: RoomKindId;
};

/** Phiếu thu */
export type Receipt = {
    /** Số tài khoản ngân hàng của khách */
    bankAccountNumber: Maybe<Scalars['String']>;
    /** Phiếu thu thuộc hóa đơn nào */
    bill: Bill;
    /** Nhân viên tạo phiếu thu */
    employee: Employee;
    /** Id của phiếu thu */
    id: Scalars['Int'];
    /** Số tiền đã thu */
    money: Scalars['Int'];
    /** Thời gian tạo phiếu thu */
    time: Scalars['DateTimeOffset'];
};

export type ReceiptCreateInput = {
    /** Số tiền đã thu */
    money: Scalars['Int'];
    /** Số tài khoản ngân hàng của khách */
    bankAccountNumber: Maybe<Scalars['String']>;
    /** Thuộc hóa đơn */
    bill: BillId;
};

/** Một phòng trong khách sạn */
export type Room = {
    /** Danh sách thông tin thuê phòng */
    bookings: Array<Booking>;
    /** Đơn đặt phòng hiện tại */
    currentBooking: Maybe<Booking>;
    /** Phòng thuộc tầng nào */
    floor: Floor;
    /** Id của phòng */
    id: Scalars['Int'];
    /** Trạng thái phòng */
    isActive: Scalars['Boolean'];
    /** Trạng thái dọn phòng */
    isClean: Scalars['Boolean'];
    /** Phòng trống */
    isEmpty: Scalars['Boolean'];
    /** Tên phòng */
    name: Scalars['String'];
    /** Loại phòng của phòng */
    roomKind: RoomKind;
};

/** Một phòng trong khách sạn */
export type RoomCurrentBookingArgs = {
    from: Scalars['DateTimeOffset'];
    to: Scalars['DateTimeOffset'];
};

/** Một phòng trong khách sạn */
export type RoomIsEmptyArgs = {
    from: Scalars['DateTimeOffset'];
    to: Scalars['DateTimeOffset'];
};

export type RoomCreateInput = {
    /** Tên phòng */
    name: Scalars['String'];
    /** Phòng thuộc tầng nào */
    floor: FloorId;
    /** Loại phòng của phòng */
    roomKind: RoomKindId;
};

/** Input cho thông tin một phòng */
export type RoomId = {
    /** Id của phòng */
    id: Scalars['Int'];
};

/** Một loại phòng hiện có trong khách sạn */
export type RoomKind = {
    /** Số người trong một phòng */
    amountOfPeople: Scalars['Int'];
    /** Id của loại phòng */
    id: Scalars['Int'];
    /** Trạng thái phòng */
    isActive: Scalars['Boolean'];
    /** Tên loại phòng */
    name: Scalars['String'];
    /** Số giường */
    numberOfBeds: Scalars['Int'];
    /** Danh sách giá cố định của loại phòng */
    rates: Maybe<Array<Maybe<Rate>>>;
    /** Danh sách các phòng thuộc loại phòng này */
    rooms: Maybe<Array<Maybe<Room>>>;
    /** Danh sách giá biến động của loại phòng */
    volatilityRates: Maybe<Array<Maybe<VolatilityRate>>>;
};

/** Input cho việc tạo một loại phòng */
export type RoomKindCreateInput = {
    /** Tên loại phòng */
    name: Scalars['String'];
    /** Số giường */
    numberOfBeds: Scalars['Int'];
    /** Số người trong một phòng */
    amountOfPeople: Scalars['Int'];
};

/** Input cho một thông tin một loại phòng */
export type RoomKindId = {
    /** Id của một loại phòng */
    id: Scalars['Int'];
};

/** Input cho việc chỉnh sửa một loại phòng */
export type RoomKindUpdateInput = {
    /** Id loại phòng */
    id: Scalars['Int'];
    /** Tên loại phòng */
    name: Scalars['String'];
    /** Số giường */
    numberOfBeds: Scalars['Int'];
    /** Số người trong một phòng */
    amountOfPeople: Scalars['Int'];
};

export type RoomUpdateInput = {
    /** Id phòng cần cập nhật */
    id: Scalars['Int'];
    /** Tên phòng */
    name: Scalars['String'];
    /** Phòng thuộc tầng nào */
    floor: FloorId;
    /** Loại phòng của phòng */
    roomKind: RoomKindId;
};

/** Một dịch vụ trong khách sạn */
export type Service = {
    /** Id của dịch vụ */
    id: Scalars['Int'];
    /** Trạng thái hoạt động */
    isActive: Scalars['Boolean'];
    /** Tên dịch vụ */
    name: Scalars['String'];
    /** Danh sách chi tiết dịch vụ */
    servicesDetails: Maybe<Array<Maybe<ServicesDetail>>>;
    /** Đơn vị */
    unit: Scalars['String'];
    /** Đơn giá */
    unitRate: Scalars['Int'];
};

/** Input cho một thông tin dịch vụ cần tạo mới */
export type ServiceCreateInput = {
    /** Tên dịch vụ */
    name: Scalars['String'];
    /** Đơn giá */
    unitRate: Scalars['Int'];
    /** Đơn vị */
    unit: Scalars['String'];
};

/** Input cho một thông tin dịch vụ */
export type ServiceId = {
    /** Id của dịch vụ */
    id: Scalars['Int'];
};

/** Một chi tiết dịch vụ của Thông tin thuê phòng */
export type ServicesDetail = {
    /** Thuộc thông tin thuê phòng nào */
    booking: Booking;
    /** Id của chi tiết dịch vụ */
    id: Scalars['Int'];
    /** Số lượng */
    number: Scalars['Int'];
    /** Thuộc dịch vụ nào */
    service: Service;
    /** Thời gian tạo */
    time: Scalars['DateTimeOffset'];
    /** Thành tiền */
    total: Scalars['Int'];
};

export type ServicesDetailCreateInput = {
    /** Số lượng */
    number: Scalars['Int'];
    /** Thuộc dịch vụ nào */
    service: ServiceId;
    /** Thuộc booking nào */
    booking: BookingId;
};

export type ServicesDetailUpdateInput = {
    /** Id của chi tiết dịch vụ cần cập nhật */
    id: Scalars['Int'];
    /** Số lượng */
    number: Scalars['Int'];
    /** Thuộc dịch vụ nào */
    service: ServiceId;
};

/** Input cho một thông tin dịch vụ cần cập nhật */
export type ServiceUpdateInput = {
    /** Id của dịch vụ */
    id: Scalars['Int'];
    /** Tên dịch vụ */
    name: Scalars['String'];
    /** Đơn giá */
    unitRate: Scalars['Int'];
    /** Đơn vị */
    unit: Scalars['String'];
};

/** Giá biến động của một loại phòng */
export type VolatilityRate = {
    /** Ngày tạo giá */
    createDate: Scalars['DateTimeOffset'];
    /** Giá ngày */
    dayRate: Scalars['Int'];
    /** Phí check-out sớm */
    earlyCheckInFee: Scalars['Int'];
    /** Ngày giá hết hiệu lực */
    effectiveEndDate: Scalars['DateTimeOffset'];
    /** Giá có hiệu lực vào ngày Thứ 6 */
    effectiveOnFriday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 2 */
    effectiveOnMonday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 7 */
    effectiveOnSaturday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Chủ Nhật */
    effectiveOnSunday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 3 */
    effectiveOnTuesday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 5 */
    effectiveOnThursday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 4 */
    effectiveOnWednesday: Scalars['Boolean'];
    /** Ngày giá bắt đầu có hiệu lực */
    effectiveStartDate: Scalars['DateTimeOffset'];
    /** Nhân viên tạo giá */
    employee: Maybe<Employee>;
    /** Id của giá */
    id: Scalars['Int'];
    /** Phí check-out muộn */
    lateCheckOutFee: Scalars['Int'];
    /** Giá tháng */
    monthRate: Scalars['Int'];
    /** Giá đêm */
    nightRate: Scalars['Int'];
    /** Thuộc loại phòng */
    roomKind: RoomKind;
    /** Giá tuần */
    weekRate: Scalars['Int'];
};

export type VolatilityRateCreateInput = {
    /** Giá ngày */
    dayRate: Scalars['Int'];
    /** Giá đêm */
    nightRate: Scalars['Int'];
    /** Giá tuần */
    weekRate: Scalars['Int'];
    /** Giá tháng */
    monthRate: Scalars['Int'];
    /** Phí check-out muộn */
    lateCheckOutFee: Scalars['Int'];
    /** Phí check-out sớm */
    earlyCheckInFee: Scalars['Int'];
    /** Ngày giá bắt đầu có hiệu lực */
    effectiveStartDate: Scalars['DateTimeOffset'];
    /** Ngày giá hết hiệu lực */
    effectiveEndDate: Scalars['DateTimeOffset'];
    /** Giá có hiệu lực vào ngày Thứ 2 */
    effectiveOnMonday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 3 */
    effectiveOnTuesday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 4 */
    effectiveOnWednesday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 5 */
    effectiveOnThursday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 6 */
    effectiveOnFriday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 7 */
    effectiveOnSaturday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Chủ Nhật */
    effectiveOnSunday: Scalars['Boolean'];
    /** Loại phòng */
    roomKind: RoomKindId;
};

export type VolatilityRateUpdateInput = {
    /** Id của giá cần cập nhật */
    id: Scalars['Int'];
    /** Giá ngày */
    dayRate: Scalars['Int'];
    /** Giá đêm */
    nightRate: Scalars['Int'];
    /** Giá tuần */
    weekRate: Scalars['Int'];
    /** Giá tháng */
    monthRate: Scalars['Int'];
    /** Phí check-out muộn */
    lateCheckOutFee: Scalars['Int'];
    /** Phí check-out sớm */
    earlyCheckInFee: Scalars['Int'];
    /** Ngày giá bắt đầu có hiệu lực */
    effectiveStartDate: Scalars['DateTimeOffset'];
    /** Ngày giá hết hiệu lực */
    effectiveEndDate: Scalars['DateTimeOffset'];
    /** Giá có hiệu lực vào ngày Thứ 2 */
    effectiveOnMonday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 3 */
    effectiveOnTuesday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 4 */
    effectiveOnWednesday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 5 */
    effectiveOnThursday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 6 */
    effectiveOnFriday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Thứ 7 */
    effectiveOnSaturday: Scalars['Boolean'];
    /** Giá có hiệu lực vào ngày Chủ Nhật */
    effectiveOnSunday: Scalars['Boolean'];
    /** Loại phòng */
    roomKind: RoomKindId;
};
export type IsInitializedQueryVariables = {};

export type IsInitializedQuery = Pick<AppQuery, 'isInitialized'>;

export type GetBillsQueryVariables = {};

export type GetBillsQuery = {
    bills: Array<
        Pick<Bill, 'id' | 'time' | 'total'> & {
            patron: Pick<Patron, 'id' | 'name'>;
            receipts: Maybe<Array<Maybe<Pick<Receipt, 'id' | 'money'>>>>;
            bookings: Maybe<Array<Maybe<Pick<Booking, 'id'>>>>;
        }
    >;
};

export type AddBookingToBillMutationVariables = {
    bill: BillId;
    booking: BookingCreateInput;
};

export type AddBookingToBillMutation = {
    addBookingToBill: Pick<Booking, 'id'>;
};

export type BookAndCheckInMutationVariables = {
    bookings: Array<BookAndCheckInCreateInput>;
    bill: BillCreateInput;
};

export type BookAndCheckInMutation = { bookAndCheckIn: Pick<Bill, 'id'> };

export type CreateBillMutationVariables = {
    bookings: Array<BookingCreateInput>;
    bill: BillCreateInput;
};

export type CreateBillMutation = { createBill: Pick<Bill, 'id'> };

export type PayTheBillMutationVariables = {
    id: Scalars['ID'];
};

export type PayTheBillMutation = { payTheBill: Pick<Bill, 'id'> };

export type GetBookingsQueryVariables = {};

export type GetBookingsQuery = {
    bookings: Array<
        Pick<
            Booking,
            | 'id'
            | 'bookCheckInTime'
            | 'bookCheckOutTime'
            | 'realCheckInTime'
            | 'realCheckOutTime'
            | 'status'
        > & {
            patrons: Array<Maybe<Pick<Patron, 'id' | 'name'>>>;
            bill: Pick<Bill, 'id'>;
            room: Pick<Room, 'id' | 'name' | 'isClean'>;
        }
    >;
};

export type GetSimpleBookingsQueryVariables = {};

export type GetSimpleBookingsQuery = {
    bookings: Array<
        Pick<Booking, 'id' | 'status'> & { room: Pick<Room, 'id' | 'name'> }
    >;
};

export type CheckInMutationVariables = {
    id: Scalars['ID'];
};

export type CheckInMutation = { checkIn: Pick<Booking, 'id'> };

export type CheckOutMutationVariables = {
    id: Scalars['ID'];
};

export type CheckOutMutation = { checkOut: Pick<Booking, 'id'> };

export type CancelMutationVariables = {
    id: Scalars['ID'];
};

export type CancelMutation = Pick<AppMutation, 'cancel'>;

export type GetEmployeesQueryVariables = {};

export type GetEmployeesQuery = {
    employees: Array<
        Pick<
            Employee,
            | 'id'
            | 'name'
            | 'identityCard'
            | 'phoneNumber'
            | 'address'
            | 'email'
            | 'birthdate'
            | 'gender'
            | 'startingDate'
            | 'isActive'
        > & { position: Pick<Position, 'id' | 'name'> }
    >;
};

export type CreateEmployeeMutationVariables = {
    input: EmployeeCreateInput;
};

export type CreateEmployeeMutation = { createEmployee: Pick<Employee, 'id'> };

export type UpdateEmployeeMutationVariables = {
    input: EmployeeUpdateInput;
};

export type UpdateEmployeeMutation = { updateEmployee: Pick<Employee, 'id'> };

export type ResetPasswordMutationVariables = {
    id: Scalars['ID'];
};

export type ResetPasswordMutation = Pick<AppMutation, 'resetPassword'>;

export type SetIsActiveAccountMutationVariables = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type SetIsActiveAccountMutation = Pick<
    AppMutation,
    'setIsActiveAccount'
>;

export type ChangePasswordMutationVariables = {
    password: Scalars['String'];
    newPassword: Scalars['String'];
};

export type ChangePasswordMutation = Pick<AppMutation, 'changePassword'>;

export type UserLoginMutationVariables = {
    id: Scalars['String'];
    password: Scalars['String'];
};

export type UserLoginMutation = {
    login: Pick<AuthenticationObject, 'token'> & {
        employee: Pick<Employee, 'id' | 'name'> & {
            position: Pick<
                Position,
                | 'id'
                | 'name'
                | 'permissionCleaning'
                | 'permissionGetAccountingVoucher'
                | 'permissionGetMap'
                | 'permissionGetPatron'
                | 'permissionGetRate'
                | 'permissionGetService'
                | 'permissionManageEmployee'
                | 'permissionManageRentingRoom'
                | 'permissionManageMap'
                | 'permissionManagePatron'
                | 'permissionManagePatronKind'
                | 'permissionManagePosition'
                | 'permissionManageRate'
                | 'permissionManageService'
            >;
        };
    };
};

export type UserCheckLoginMutationVariables = {};

export type UserCheckLoginMutation = {
    checkLogin: Pick<Employee, 'id' | 'name'> & {
        position: Pick<
            Position,
            | 'id'
            | 'name'
            | 'permissionCleaning'
            | 'permissionGetAccountingVoucher'
            | 'permissionGetMap'
            | 'permissionGetPatron'
            | 'permissionGetRate'
            | 'permissionGetService'
            | 'permissionManageEmployee'
            | 'permissionManageRentingRoom'
            | 'permissionManageMap'
            | 'permissionManagePatron'
            | 'permissionManagePatronKind'
            | 'permissionManagePosition'
            | 'permissionManageRate'
            | 'permissionManageService'
        >;
    };
};

export type GetFloorsQueryVariables = {};

export type GetFloorsQuery = {
    floors: Array<
        Pick<Floor, 'id' | 'name' | 'isActive'> & {
            rooms: Array<
                Pick<Room, 'id' | 'name' | 'isActive'> & {
                    roomKind: Pick<RoomKind, 'id' | 'name'>;
                }
            >;
        }
    >;
};

export type GetFloorsMapQueryVariables = {
    from: Scalars['DateTimeOffset'];
    to: Scalars['DateTimeOffset'];
};

export type GetFloorsMapQuery = {
    floors: Array<
        Pick<Floor, 'id' | 'name' | 'isActive'> & {
            rooms: Array<
                Pick<Room, 'id' | 'name' | 'isActive'> & {
                    currentBooking: Maybe<Pick<Booking, 'id'>>;
                    roomKind: Pick<RoomKind, 'id' | 'name'>;
                }
            >;
        }
    >;
};

export type GetTimelineQueryVariables = {};

export type GetTimelineQuery = {
    floors: Array<
        Pick<Floor, 'id' | 'name' | 'isActive'> & {
            rooms: Array<
                Pick<Room, 'id' | 'name' | 'isActive' | 'isClean'> & {
                    bookings: Array<
                        Pick<
                            Booking,
                            | 'id'
                            | 'status'
                            | 'createTime'
                            | 'bookCheckInTime'
                            | 'bookCheckOutTime'
                        > & { patrons: Array<Maybe<Pick<Patron, 'id'>>> }
                    >;
                    roomKind: Pick<RoomKind, 'id' | 'name'>;
                }
            >;
        }
    >;
};

export type CreateFloorMutationVariables = {
    input: FloorCreateInput;
};

export type CreateFloorMutation = { createFloor: Pick<Floor, 'id'> };

export type UpdateFloorMutationVariables = {
    input: FloorUpdateInput;
};

export type UpdateFloorMutation = { updateFloor: Pick<Floor, 'id'> };

export type DeleteFloorMutationVariables = {
    id: Scalars['ID'];
};

export type DeleteFloorMutation = Pick<AppMutation, 'deleteFloor'>;

export type SetIsActiveFloorMutationVariables = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type SetIsActiveFloorMutation = Pick<AppMutation, 'setIsActiveFloor'>;

export type InitializeAdminAccountMutationVariables = {
    email: Scalars['String'];
    password: Scalars['String'];
};

export type InitializeAdminAccountMutation = Pick<
    AppMutation,
    'initializeAdminAccount'
>;

export type GetPatronsQueryVariables = {};

export type GetPatronsQuery = {
    patrons: Array<
        Pick<
            Patron,
            | 'id'
            | 'identification'
            | 'name'
            | 'birthdate'
            | 'email'
            | 'gender'
            | 'residence'
            | 'domicile'
            | 'phoneNumbers'
            | 'nationality'
            | 'company'
            | 'note'
        > & { patronKind: Pick<PatronKind, 'id'> }
    >;
};

export type GetPatronQueryVariables = {
    id: Scalars['ID'];
};

export type GetPatronQuery = {
    patron: Pick<
        Patron,
        | 'id'
        | 'identification'
        | 'name'
        | 'birthdate'
        | 'email'
        | 'gender'
        | 'residence'
        | 'domicile'
        | 'phoneNumbers'
        | 'nationality'
        | 'company'
        | 'note'
    > & { patronKind: Pick<PatronKind, 'id'> };
};

export type CreatePatronMutationVariables = {
    input: PatronCreateInput;
};

export type CreatePatronMutation = {
    createPatron: Pick<
        Patron,
        | 'id'
        | 'identification'
        | 'name'
        | 'birthdate'
        | 'email'
        | 'gender'
        | 'residence'
        | 'domicile'
        | 'phoneNumbers'
        | 'nationality'
        | 'company'
        | 'note'
    > & { patronKind: Pick<PatronKind, 'id'> };
};

export type UpdatePatronMutationVariables = {
    input: PatronUpdateInput;
};

export type UpdatePatronMutation = { updatePatron: Pick<Patron, 'id'> };

export type GetPatronKindsQueryVariables = {};

export type GetPatronKindsQuery = {
    patronKinds: Array<
        Pick<PatronKind, 'id' | 'name' | 'description'> & {
            patrons: Maybe<Array<Maybe<Pick<Patron, 'id' | 'name'>>>>;
        }
    >;
};

export type CreatePatronKindMutationVariables = {
    input: PatronKindCreateInput;
};

export type CreatePatronKindMutation = {
    createPatronKind: Pick<PatronKind, 'id'>;
};

export type UpdatePatronKindMutationVariables = {
    input: PatronKindUpdateInput;
};

export type UpdatePatronKindMutation = {
    updatePatronKind: Pick<PatronKind, 'id'>;
};

export type GetPositionsQueryVariables = {};

export type GetPositionsQuery = {
    positions: Array<
        Pick<
            Position,
            | 'id'
            | 'name'
            | 'permissionCleaning'
            | 'permissionGetAccountingVoucher'
            | 'permissionGetMap'
            | 'permissionGetPatron'
            | 'permissionGetRate'
            | 'permissionGetService'
            | 'permissionManageEmployee'
            | 'permissionManageRentingRoom'
            | 'permissionManageMap'
            | 'permissionManagePatron'
            | 'permissionManagePatronKind'
            | 'permissionManagePosition'
            | 'permissionManageRate'
            | 'permissionManageService'
            | 'isActive'
        > & {
            employees: Maybe<Array<Maybe<Pick<Employee, 'id' | 'isActive'>>>>;
        }
    >;
};

export type CreatePositionMutationVariables = {
    input: PositionCreateInput;
};

export type CreatePositionMutation = { createPosition: Pick<Position, 'id'> };

export type UpdatePositionMutationVariables = {
    input: PositionUpdateInput;
};

export type UpdatePositionMutation = { updatePosition: Pick<Position, 'id'> };

export type DeletePositionMutationVariables = {
    id: Scalars['ID'];
};

export type DeletePositionMutation = Pick<AppMutation, 'deletePosition'>;

export type SetIsActivePositionMutationVariables = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type SetIsActivePositionMutation = Pick<
    AppMutation,
    'setIsActivePosition'
>;

export type SetIsActivePositionAndMoveEmployeeMutationVariables = {
    id: Scalars['ID'];
    newId: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type SetIsActivePositionAndMoveEmployeeMutation = Pick<
    AppMutation,
    'setIsActivePositionAndMoveEmployee'
>;

export type GetRatesQueryVariables = {};

export type GetRatesQuery = {
    rates: Array<
        Pick<Rate, 'id' | 'dayRate' | 'effectiveStartDate' | 'createDate'> & {
            roomKind: Pick<RoomKind, 'id' | 'name'>;
        }
    >;
};

export type CreateRateMutationVariables = {
    input: RateCreateInput;
};

export type CreateRateMutation = { createRate: Pick<Rate, 'id'> };

export type GetReceiptsQueryVariables = {};

export type GetReceiptsQuery = {
    receipts: Array<
        Pick<Receipt, 'id' | 'money' | 'time' | 'bankAccountNumber'> & {
            bill: Pick<Bill, 'id'>;
        }
    >;
};

export type CreateReceiptMutationVariables = {
    input: ReceiptCreateInput;
};

export type CreateReceiptMutation = { createReceipt: Pick<Receipt, 'id'> };

export type GetRoomKindsQueryVariables = {};

export type GetRoomKindsQuery = {
    roomKinds: Array<
        Pick<
            RoomKind,
            'id' | 'name' | 'isActive' | 'amountOfPeople' | 'numberOfBeds'
        > & { rooms: Maybe<Array<Maybe<Pick<Room, 'id'>>>> }
    >;
};

export type CreateRoomKindMutationVariables = {
    input: RoomKindCreateInput;
};

export type CreateRoomKindMutation = {
    createRoomKind: Pick<
        RoomKind,
        'id' | 'name' | 'numberOfBeds' | 'amountOfPeople' | 'isActive'
    >;
};

export type UpdateRoomKindMutationVariables = {
    input: RoomKindUpdateInput;
};

export type UpdateRoomKindMutation = { updateRoomKind: Pick<RoomKind, 'id'> };

export type DeleteRoomKindMutationVariables = {
    id: Scalars['ID'];
};

export type DeleteRoomKindMutation = Pick<AppMutation, 'deleteRoomKind'>;

export type SetIsActiveRoomKindMutationVariables = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type SetIsActiveRoomKindMutation = Pick<
    AppMutation,
    'setIsActiveRoomKind'
>;

export type GetRoomsQueryVariables = {};

export type GetRoomsQuery = {
    rooms: Array<Pick<Room, 'id' | 'name' | 'isActive'>>;
};

export type GetRoomsWithIsEmptyQueryVariables = {
    from: Scalars['DateTimeOffset'];
    to: Scalars['DateTimeOffset'];
};

export type GetRoomsWithIsEmptyQuery = {
    rooms: Array<Pick<Room, 'id' | 'name' | 'isActive' | 'isEmpty'>>;
};

export type GetRoomQueryVariables = {
    id: Scalars['ID'];
};

export type GetRoomQuery = { room: Pick<Room, 'id' | 'name' | 'isActive'> };

export type CreateRoomMutationVariables = {
    input: RoomCreateInput;
};

export type CreateRoomMutation = { createRoom: Pick<Room, 'id'> };

export type UpdateRoomMutationVariables = {
    input: RoomUpdateInput;
};

export type UpdateRoomMutation = { updateRoom: Pick<Room, 'id'> };

export type DeleteRoomMutationVariables = {
    id: Scalars['ID'];
};

export type DeleteRoomMutation = Pick<AppMutation, 'deleteRoom'>;

export type SetIsActiveRoomMutationVariables = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type SetIsActiveRoomMutation = Pick<AppMutation, 'setIsActiveRoom'>;

export type SetIsCleanRoomMutationVariables = {
    id: Scalars['ID'];
    isClean: Scalars['Boolean'];
};

export type SetIsCleanRoomMutation = Pick<AppMutation, 'setIsCleanRoom'>;

export type CreateServicesDetailMutationVariables = {
    input: ServicesDetailCreateInput;
};

export type CreateServicesDetailMutation = {
    createServicesDetail: Pick<ServicesDetail, 'id'>;
};

export type GetServicesQueryVariables = {};

export type GetServicesQuery = {
    services: Array<
        Pick<Service, 'id' | 'name' | 'unitRate' | 'unit' | 'isActive'> & {
            servicesDetails: Maybe<
                Array<Maybe<Pick<ServicesDetail, 'id' | 'number'>>>
            >;
        }
    >;
};

export type CreateServiceMutationVariables = {
    input: ServiceCreateInput;
};

export type CreateServiceMutation = { createService: Pick<Service, 'id'> };

export type UpdateServiceMutationVariables = {
    input: ServiceUpdateInput;
};

export type UpdateServiceMutation = { updateService: Pick<Service, 'id'> };

export type DeleteServiceMutationVariables = {
    id: Scalars['ID'];
};

export type DeleteServiceMutation = Pick<AppMutation, 'deleteService'>;

export type SetIsActiveServiceMutationVariables = {
    id: Scalars['ID'];
    isActive: Scalars['Boolean'];
};

export type SetIsActiveServiceMutation = Pick<
    AppMutation,
    'setIsActiveService'
>;

export type GetPatronsAndRoomsQueryVariables = {};

export type GetPatronsAndRoomsQuery = {
    patrons: Array<
        Pick<
            Patron,
            | 'id'
            | 'identification'
            | 'name'
            | 'birthdate'
            | 'email'
            | 'gender'
            | 'residence'
            | 'domicile'
            | 'phoneNumbers'
            | 'nationality'
            | 'company'
            | 'note'
        > & { patronKind: Pick<PatronKind, 'id'> }
    >;
    rooms: Array<Pick<Room, 'id' | 'name' | 'isActive' | 'isClean'>>;
};
export namespace IsInitialized {
    export type Variables = IsInitializedQueryVariables;
    export type Query = IsInitializedQuery;
}

export namespace GetBills {
    export type Variables = GetBillsQueryVariables;
    export type Query = GetBillsQuery;
    export type Bills = NonNullable<GetBillsQuery['bills'][0]>;
    export type Patron = (NonNullable<GetBillsQuery['bills'][0]>)['patron'];
    export type Receipts = NonNullable<
        (NonNullable<(NonNullable<GetBillsQuery['bills'][0]>)['receipts']>)[0]
    >;
    export type Bookings = NonNullable<
        (NonNullable<(NonNullable<GetBillsQuery['bills'][0]>)['bookings']>)[0]
    >;
}

export namespace AddBookingToBill {
    export type Variables = AddBookingToBillMutationVariables;
    export type Mutation = AddBookingToBillMutation;
    export type AddBookingToBill = AddBookingToBillMutation['addBookingToBill'];
}

export namespace BookAndCheckIn {
    export type Variables = BookAndCheckInMutationVariables;
    export type Mutation = BookAndCheckInMutation;
    export type BookAndCheckIn = BookAndCheckInMutation['bookAndCheckIn'];
}

export namespace CreateBill {
    export type Variables = CreateBillMutationVariables;
    export type Mutation = CreateBillMutation;
    export type CreateBill = CreateBillMutation['createBill'];
}

export namespace PayTheBill {
    export type Variables = PayTheBillMutationVariables;
    export type Mutation = PayTheBillMutation;
    export type PayTheBill = PayTheBillMutation['payTheBill'];
}

export namespace GetBookings {
    export type Variables = GetBookingsQueryVariables;
    export type Query = GetBookingsQuery;
    export type Bookings = NonNullable<GetBookingsQuery['bookings'][0]>;
    export type Patrons = NonNullable<
        (NonNullable<GetBookingsQuery['bookings'][0]>)['patrons'][0]
    >;
    export type Bill = (NonNullable<GetBookingsQuery['bookings'][0]>)['bill'];
    export type Room = (NonNullable<GetBookingsQuery['bookings'][0]>)['room'];
}

export namespace GetSimpleBookings {
    export type Variables = GetSimpleBookingsQueryVariables;
    export type Query = GetSimpleBookingsQuery;
    export type Bookings = NonNullable<GetSimpleBookingsQuery['bookings'][0]>;
    export type Room = (NonNullable<
        GetSimpleBookingsQuery['bookings'][0]
    >)['room'];
}

export namespace CheckIn {
    export type Variables = CheckInMutationVariables;
    export type Mutation = CheckInMutation;
    export type CheckIn = CheckInMutation['checkIn'];
}

export namespace CheckOut {
    export type Variables = CheckOutMutationVariables;
    export type Mutation = CheckOutMutation;
    export type CheckOut = CheckOutMutation['checkOut'];
}

export namespace Cancel {
    export type Variables = CancelMutationVariables;
    export type Mutation = CancelMutation;
}

export namespace GetEmployees {
    export type Variables = GetEmployeesQueryVariables;
    export type Query = GetEmployeesQuery;
    export type Employees = NonNullable<GetEmployeesQuery['employees'][0]>;
    export type Position = (NonNullable<
        GetEmployeesQuery['employees'][0]
    >)['position'];
}

export namespace CreateEmployee {
    export type Variables = CreateEmployeeMutationVariables;
    export type Mutation = CreateEmployeeMutation;
    export type CreateEmployee = CreateEmployeeMutation['createEmployee'];
}

export namespace UpdateEmployee {
    export type Variables = UpdateEmployeeMutationVariables;
    export type Mutation = UpdateEmployeeMutation;
    export type UpdateEmployee = UpdateEmployeeMutation['updateEmployee'];
}

export namespace ResetPassword {
    export type Variables = ResetPasswordMutationVariables;
    export type Mutation = ResetPasswordMutation;
}

export namespace SetIsActiveAccount {
    export type Variables = SetIsActiveAccountMutationVariables;
    export type Mutation = SetIsActiveAccountMutation;
}

export namespace ChangePassword {
    export type Variables = ChangePasswordMutationVariables;
    export type Mutation = ChangePasswordMutation;
}

export namespace UserLogin {
    export type Variables = UserLoginMutationVariables;
    export type Mutation = UserLoginMutation;
    export type Login = UserLoginMutation['login'];
    export type Employee = UserLoginMutation['login']['employee'];
    export type Position = UserLoginMutation['login']['employee']['position'];
}

export namespace UserCheckLogin {
    export type Variables = UserCheckLoginMutationVariables;
    export type Mutation = UserCheckLoginMutation;
    export type CheckLogin = UserCheckLoginMutation['checkLogin'];
    export type Position = UserCheckLoginMutation['checkLogin']['position'];
}

export namespace GetFloors {
    export type Variables = GetFloorsQueryVariables;
    export type Query = GetFloorsQuery;
    export type Floors = NonNullable<GetFloorsQuery['floors'][0]>;
    export type Rooms = NonNullable<
        (NonNullable<GetFloorsQuery['floors'][0]>)['rooms'][0]
    >;
    export type RoomKind = (NonNullable<
        (NonNullable<GetFloorsQuery['floors'][0]>)['rooms'][0]
    >)['roomKind'];
}

export namespace GetFloorsMap {
    export type Variables = GetFloorsMapQueryVariables;
    export type Query = GetFloorsMapQuery;
    export type Floors = NonNullable<GetFloorsMapQuery['floors'][0]>;
    export type Rooms = NonNullable<
        (NonNullable<GetFloorsMapQuery['floors'][0]>)['rooms'][0]
    >;
    export type CurrentBooking = NonNullable<
        (NonNullable<
            (NonNullable<GetFloorsMapQuery['floors'][0]>)['rooms'][0]
        >)['currentBooking']
    >;
    export type RoomKind = (NonNullable<
        (NonNullable<GetFloorsMapQuery['floors'][0]>)['rooms'][0]
    >)['roomKind'];
}

export namespace GetTimeline {
    export type Variables = GetTimelineQueryVariables;
    export type Query = GetTimelineQuery;
    export type Floors = NonNullable<GetTimelineQuery['floors'][0]>;
    export type Rooms = NonNullable<
        (NonNullable<GetTimelineQuery['floors'][0]>)['rooms'][0]
    >;
    export type Bookings = NonNullable<
        (NonNullable<
            (NonNullable<GetTimelineQuery['floors'][0]>)['rooms'][0]
        >)['bookings'][0]
    >;
    export type Patrons = NonNullable<
        (NonNullable<
            (NonNullable<
                (NonNullable<GetTimelineQuery['floors'][0]>)['rooms'][0]
            >)['bookings'][0]
        >)['patrons'][0]
    >;
    export type RoomKind = (NonNullable<
        (NonNullable<GetTimelineQuery['floors'][0]>)['rooms'][0]
    >)['roomKind'];
}

export namespace CreateFloor {
    export type Variables = CreateFloorMutationVariables;
    export type Mutation = CreateFloorMutation;
    export type CreateFloor = CreateFloorMutation['createFloor'];
}

export namespace UpdateFloor {
    export type Variables = UpdateFloorMutationVariables;
    export type Mutation = UpdateFloorMutation;
    export type UpdateFloor = UpdateFloorMutation['updateFloor'];
}

export namespace DeleteFloor {
    export type Variables = DeleteFloorMutationVariables;
    export type Mutation = DeleteFloorMutation;
}

export namespace SetIsActiveFloor {
    export type Variables = SetIsActiveFloorMutationVariables;
    export type Mutation = SetIsActiveFloorMutation;
}

export namespace InitializeAdminAccount {
    export type Variables = InitializeAdminAccountMutationVariables;
    export type Mutation = InitializeAdminAccountMutation;
}

export namespace GetPatrons {
    export type Variables = GetPatronsQueryVariables;
    export type Query = GetPatronsQuery;
    export type Patrons = NonNullable<GetPatronsQuery['patrons'][0]>;
    export type PatronKind = (NonNullable<
        GetPatronsQuery['patrons'][0]
    >)['patronKind'];
}

export namespace GetPatron {
    export type Variables = GetPatronQueryVariables;
    export type Query = GetPatronQuery;
    export type Patron = GetPatronQuery['patron'];
    export type PatronKind = GetPatronQuery['patron']['patronKind'];
}

export namespace CreatePatron {
    export type Variables = CreatePatronMutationVariables;
    export type Mutation = CreatePatronMutation;
    export type CreatePatron = CreatePatronMutation['createPatron'];
    export type PatronKind = CreatePatronMutation['createPatron']['patronKind'];
}

export namespace UpdatePatron {
    export type Variables = UpdatePatronMutationVariables;
    export type Mutation = UpdatePatronMutation;
    export type UpdatePatron = UpdatePatronMutation['updatePatron'];
}

export namespace GetPatronKinds {
    export type Variables = GetPatronKindsQueryVariables;
    export type Query = GetPatronKindsQuery;
    export type PatronKinds = NonNullable<
        GetPatronKindsQuery['patronKinds'][0]
    >;
    export type Patrons = NonNullable<
        (NonNullable<
            (NonNullable<GetPatronKindsQuery['patronKinds'][0]>)['patrons']
        >)[0]
    >;
}

export namespace CreatePatronKind {
    export type Variables = CreatePatronKindMutationVariables;
    export type Mutation = CreatePatronKindMutation;
    export type CreatePatronKind = CreatePatronKindMutation['createPatronKind'];
}

export namespace UpdatePatronKind {
    export type Variables = UpdatePatronKindMutationVariables;
    export type Mutation = UpdatePatronKindMutation;
    export type UpdatePatronKind = UpdatePatronKindMutation['updatePatronKind'];
}

export namespace GetPositions {
    export type Variables = GetPositionsQueryVariables;
    export type Query = GetPositionsQuery;
    export type Positions = NonNullable<GetPositionsQuery['positions'][0]>;
    export type Employees = NonNullable<
        (NonNullable<
            (NonNullable<GetPositionsQuery['positions'][0]>)['employees']
        >)[0]
    >;
}

export namespace CreatePosition {
    export type Variables = CreatePositionMutationVariables;
    export type Mutation = CreatePositionMutation;
    export type CreatePosition = CreatePositionMutation['createPosition'];
}

export namespace UpdatePosition {
    export type Variables = UpdatePositionMutationVariables;
    export type Mutation = UpdatePositionMutation;
    export type UpdatePosition = UpdatePositionMutation['updatePosition'];
}

export namespace DeletePosition {
    export type Variables = DeletePositionMutationVariables;
    export type Mutation = DeletePositionMutation;
}

export namespace SetIsActivePosition {
    export type Variables = SetIsActivePositionMutationVariables;
    export type Mutation = SetIsActivePositionMutation;
}

export namespace SetIsActivePositionAndMoveEmployee {
    export type Variables = SetIsActivePositionAndMoveEmployeeMutationVariables;
    export type Mutation = SetIsActivePositionAndMoveEmployeeMutation;
}

export namespace GetRates {
    export type Variables = GetRatesQueryVariables;
    export type Query = GetRatesQuery;
    export type Rates = NonNullable<GetRatesQuery['rates'][0]>;
    export type RoomKind = (NonNullable<GetRatesQuery['rates'][0]>)['roomKind'];
}

export namespace CreateRate {
    export type Variables = CreateRateMutationVariables;
    export type Mutation = CreateRateMutation;
    export type CreateRate = CreateRateMutation['createRate'];
}

export namespace GetReceipts {
    export type Variables = GetReceiptsQueryVariables;
    export type Query = GetReceiptsQuery;
    export type Receipts = NonNullable<GetReceiptsQuery['receipts'][0]>;
    export type Bill = (NonNullable<GetReceiptsQuery['receipts'][0]>)['bill'];
}

export namespace CreateReceipt {
    export type Variables = CreateReceiptMutationVariables;
    export type Mutation = CreateReceiptMutation;
    export type CreateReceipt = CreateReceiptMutation['createReceipt'];
}

export namespace GetRoomKinds {
    export type Variables = GetRoomKindsQueryVariables;
    export type Query = GetRoomKindsQuery;
    export type RoomKinds = NonNullable<GetRoomKindsQuery['roomKinds'][0]>;
    export type Rooms = NonNullable<
        (NonNullable<
            (NonNullable<GetRoomKindsQuery['roomKinds'][0]>)['rooms']
        >)[0]
    >;
}

export namespace CreateRoomKind {
    export type Variables = CreateRoomKindMutationVariables;
    export type Mutation = CreateRoomKindMutation;
    export type CreateRoomKind = CreateRoomKindMutation['createRoomKind'];
}

export namespace UpdateRoomKind {
    export type Variables = UpdateRoomKindMutationVariables;
    export type Mutation = UpdateRoomKindMutation;
    export type UpdateRoomKind = UpdateRoomKindMutation['updateRoomKind'];
}

export namespace DeleteRoomKind {
    export type Variables = DeleteRoomKindMutationVariables;
    export type Mutation = DeleteRoomKindMutation;
}

export namespace SetIsActiveRoomKind {
    export type Variables = SetIsActiveRoomKindMutationVariables;
    export type Mutation = SetIsActiveRoomKindMutation;
}

export namespace GetRooms {
    export type Variables = GetRoomsQueryVariables;
    export type Query = GetRoomsQuery;
    export type Rooms = NonNullable<GetRoomsQuery['rooms'][0]>;
}

export namespace GetRoomsWithIsEmpty {
    export type Variables = GetRoomsWithIsEmptyQueryVariables;
    export type Query = GetRoomsWithIsEmptyQuery;
    export type Rooms = NonNullable<GetRoomsWithIsEmptyQuery['rooms'][0]>;
}

export namespace GetRoom {
    export type Variables = GetRoomQueryVariables;
    export type Query = GetRoomQuery;
    export type Room = GetRoomQuery['room'];
}

export namespace CreateRoom {
    export type Variables = CreateRoomMutationVariables;
    export type Mutation = CreateRoomMutation;
    export type CreateRoom = CreateRoomMutation['createRoom'];
}

export namespace UpdateRoom {
    export type Variables = UpdateRoomMutationVariables;
    export type Mutation = UpdateRoomMutation;
    export type UpdateRoom = UpdateRoomMutation['updateRoom'];
}

export namespace DeleteRoom {
    export type Variables = DeleteRoomMutationVariables;
    export type Mutation = DeleteRoomMutation;
}

export namespace SetIsActiveRoom {
    export type Variables = SetIsActiveRoomMutationVariables;
    export type Mutation = SetIsActiveRoomMutation;
}

export namespace SetIsCleanRoom {
    export type Variables = SetIsCleanRoomMutationVariables;
    export type Mutation = SetIsCleanRoomMutation;
}

export namespace CreateServicesDetail {
    export type Variables = CreateServicesDetailMutationVariables;
    export type Mutation = CreateServicesDetailMutation;
    export type CreateServicesDetail = CreateServicesDetailMutation['createServicesDetail'];
}

export namespace GetServices {
    export type Variables = GetServicesQueryVariables;
    export type Query = GetServicesQuery;
    export type Services = NonNullable<GetServicesQuery['services'][0]>;
    export type ServicesDetails = NonNullable<
        (NonNullable<
            (NonNullable<GetServicesQuery['services'][0]>)['servicesDetails']
        >)[0]
    >;
}

export namespace CreateService {
    export type Variables = CreateServiceMutationVariables;
    export type Mutation = CreateServiceMutation;
    export type CreateService = CreateServiceMutation['createService'];
}

export namespace UpdateService {
    export type Variables = UpdateServiceMutationVariables;
    export type Mutation = UpdateServiceMutation;
    export type UpdateService = UpdateServiceMutation['updateService'];
}

export namespace DeleteService {
    export type Variables = DeleteServiceMutationVariables;
    export type Mutation = DeleteServiceMutation;
}

export namespace SetIsActiveService {
    export type Variables = SetIsActiveServiceMutationVariables;
    export type Mutation = SetIsActiveServiceMutation;
}

export namespace GetPatronsAndRooms {
    export type Variables = GetPatronsAndRoomsQueryVariables;
    export type Query = GetPatronsAndRoomsQuery;
    export type Patrons = NonNullable<GetPatronsAndRoomsQuery['patrons'][0]>;
    export type PatronKind = (NonNullable<
        GetPatronsAndRoomsQuery['patrons'][0]
    >)['patronKind'];
    export type Rooms = NonNullable<GetPatronsAndRoomsQuery['rooms'][0]>;
}
