export type Maybe<T> = T | null;
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
    ID: string;
    String: string;
    Boolean: boolean;
    Int: number;
    Float: number;
    DateTimeOffset: string | Date;
    Seconds: number;
    Date: string | Date;
    DateTime: string | Date;
    Decimal: number;
    Milliseconds: number;
};

export type AppMutation = {
    addBookingToBill: Booking;
    bookAndCheckIn: Bill;
    cancel: Scalars['String'];
    createBill: Bill;
    createEmployee: Employee;
    createFloor: Floor;
    createPatron: Patron;
    createPatronKind: PatronKind;
    createPosition: Position;
    createPrice: Price;
    createPriceVolatility: PriceVolatility;
    createReceipt: Receipt;
    createRoom: Room;
    createRoomKind: RoomKind;
    createService: Service;
    createServicesDetail: ServicesDetail;
    changePassword: Scalars['String'];
    checkBookingPrice: Booking;
    checkIn: Booking;
    checkLogin: Employee;
    checkOut: Booking;
    checkReceipt: Receipt;
    deleteFloor: Scalars['String'];
    deletePatronKind: Scalars['String'];
    deletePosition: Scalars['String'];
    deletePrice: Scalars['String'];
    deletePriceVolatility: Scalars['String'];
    deleteRoom: Scalars['String'];
    deleteRoomKind: Scalars['String'];
    deleteService: Scalars['String'];
    deleteServicesDetail: Scalars['String'];
    initializeAdminAccount: Scalars['String'];
    initializeDatabase: Scalars['String'];
    login: AuthenticationObject;
    payTheBill: Bill;
    resetPassword: Scalars['String'];
    setIsActiveAccount: Scalars['String'];
    setIsActiveFloor: Scalars['String'];
    setIsActivePosition: Scalars['String'];
    setIsActivePositionAndMoveEmployee: Scalars['String'];
    setIsActiveRoom: Scalars['String'];
    setIsActiveRoomKind: Scalars['String'];
    setIsActiveService: Scalars['String'];
    setIsCleanRoom: Scalars['String'];
    updateBill: Bill;
    updateBillDiscount: Bill;
    updateEmployee: Employee;
    updateFloor: Floor;
    updatePatron: Patron;
    updatePatronKind: PatronKind;
    updatePosition: Position;
    updatePrice: Price;
    updatePriceVolatility: PriceVolatility;
    updateRoom: Room;
    updateRoomKind: RoomKind;
    updateService: Service;
    updateServicesDetail: ServicesDetail;
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

export type AppMutationCreatePriceArgs = {
    input: PriceCreateInput;
};

export type AppMutationCreatePriceVolatilityArgs = {
    input: PriceVolatilityCreateInput;
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

export type AppMutationChangePasswordArgs = {
    password: Scalars['String'];
    newPassword: Scalars['String'];
};

export type AppMutationCheckBookingPriceArgs = {
    booking: BookingCreateInput;
};

export type AppMutationCheckInArgs = {
    id: Scalars['ID'];
};

export type AppMutationCheckOutArgs = {
    id: Scalars['ID'];
};

export type AppMutationCheckReceiptArgs = {
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

export type AppMutationDeletePriceArgs = {
    id: Scalars['ID'];
};

export type AppMutationDeletePriceVolatilityArgs = {
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

export type AppMutationUpdateBillArgs = {
    input: BillUpdateInput;
};

export type AppMutationUpdateBillDiscountArgs = {
    input: BillUpdateDiscountInput;
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

export type AppMutationUpdatePriceArgs = {
    input: PriceUpdateInput;
};

export type AppMutationUpdatePriceVolatilityArgs = {
    input: PriceVolatilityUpdateInput;
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

export type AppQuery = {
    bill: Bill;
    bills: Array<Bill>;
    booking: Booking;
    bookings: Array<Booking>;
    employee: Employee;
    employees: Array<Employee>;
    findingPatron: Array<Patron>;
    floor: Floor;
    floors: Array<Floor>;
    isInitialized: Scalars['Boolean'];
    patron: Patron;
    patronKind: PatronKind;
    patronKinds: Array<PatronKind>;
    patrons: Array<Patron>;
    position: Position;
    positions: Array<Position>;
    price: Price;
    prices: Array<Price>;
    priceVolatilities: Array<PriceVolatility>;
    priceVolatility: PriceVolatility;
    receipt: Receipt;
    receipts: Array<Receipt>;
    room: Room;
    roomKind: RoomKind;
    roomKinds: Array<RoomKind>;
    rooms: Array<Room>;
    service: Service;
    services: Array<Service>;
    servicesDetail: ServicesDetail;
    servicesDetails: Array<ServicesDetail>;
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

export type AppQueryPriceArgs = {
    id: Scalars['ID'];
};

export type AppQueryPriceVolatilityArgs = {
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

export type AuthenticationObject = {
    employee: Employee;
    token: Scalars['String'];
};

export type Bill = {
    bookings: Array<Booking>;
    discount: Scalars['Int'];
    employee: Maybe<Employee>;
    id: Scalars['Int'];
    patron: Patron;
    receipts: Array<Receipt>;
    status: BillStatusEnum;
    time: Scalars['DateTimeOffset'];
    totalPrice: Scalars['Int'];
    totalReceipts: Scalars['Int'];
};

export type BillCreateInput = {
    patron: PatronId;
};

export type BillId = {
    id: Scalars['Int'];
};

export enum BillStatusEnum {
    Pending = 'PENDING',
    Success = 'SUCCESS',
    Cancel = 'CANCEL',
}

export type BillUpdateDiscountInput = {
    id: Scalars['Int'];
    discount: Scalars['Int'];
};

export type BillUpdateInput = {
    id: Scalars['Int'];
    discount: Scalars['Int'];
    patron: PatronId;
};

export type BookAndCheckInCreateInput = {
    bookCheckOutTime: Scalars['DateTimeOffset'];
    room: RoomId;
    listOfPatrons: Array<PatronId>;
};

export type Booking = {
    baseDayCheckInTime: Scalars['DateTimeOffset'];
    baseDayCheckOutTime: Scalars['DateTimeOffset'];
    baseNightCheckInTime: Scalars['DateTimeOffset'];
    bill: Bill;
    bookCheckInTime: Scalars['DateTimeOffset'];
    bookCheckOutTime: Scalars['DateTimeOffset'];
    createTime: Scalars['DateTimeOffset'];
    earlyCheckInFee: Scalars['Int'];
    employeeBooking: Maybe<Employee>;
    employeeCheckIn: Maybe<Employee>;
    employeeCheckOut: Maybe<Employee>;
    id: Scalars['Int'];
    lateCheckOutFee: Scalars['Int'];
    patrons: Array<Patron>;
    price: Price;
    priceItems: Array<PriceItem>;
    priceVolatilityItems: Array<PriceVolatilityItem>;
    realCheckInTime: Scalars['DateTimeOffset'];
    realCheckOutTime: Scalars['DateTimeOffset'];
    room: Room;
    servicesDetails: Array<ServicesDetail>;
    status: BookingStatusEnum;
    total: Scalars['Int'];
    totalPrice: Scalars['Int'];
    totalServicesDetails: Scalars['Int'];
};

export type BookingCreateInput = {
    bookCheckInTime: Scalars['DateTimeOffset'];
    bookCheckOutTime: Scalars['DateTimeOffset'];
    room: RoomId;
    listOfPatrons: Array<PatronId>;
};

export type BookingId = {
    id: Scalars['Int'];
};

export enum BookingStatusEnum {
    Booked = 'BOOKED',
    CheckedIn = 'CHECKED_IN',
    CheckedOut = 'CHECKED_OUT',
}

export type Employee = {
    address: Scalars['String'];
    bills: Array<Bill>;
    birthdate: Scalars['DateTimeOffset'];
    bookings: Array<Booking>;
    email: Scalars['String'];
    gender: Scalars['Boolean'];
    id: Scalars['String'];
    identityCard: Scalars['String'];
    isActive: Scalars['Boolean'];
    name: Scalars['String'];
    position: Position;
    prices: Array<Price>;
    priceVolatilities: Array<PriceVolatility>;
    phoneNumber: Scalars['String'];
    receipts: Array<Receipt>;
    startingDate: Scalars['DateTimeOffset'];
};

export type EmployeeCreateInput = {
    id: Scalars['String'];
    password: Scalars['String'];
    name: Scalars['String'];
    identityCard: Scalars['String'];
    phoneNumber: Scalars['String'];
    address: Scalars['String'];
    email: Scalars['String'];
    birthdate: Scalars['DateTimeOffset'];
    gender: Scalars['Boolean'];
    startingDate: Scalars['DateTimeOffset'];
    position: PositionId;
};

export type EmployeeUpdateInput = {
    id: Scalars['String'];
    name: Scalars['String'];
    identityCard: Scalars['String'];
    address: Scalars['String'];
    birthdate: Scalars['DateTimeOffset'];
    email: Scalars['String'];
    gender: Scalars['Boolean'];
    phoneNumber: Scalars['String'];
    startingDate: Scalars['DateTimeOffset'];
    position: PositionId;
};

export type Floor = {
    id: Scalars['Int'];
    isActive: Scalars['Boolean'];
    name: Scalars['String'];
    rooms: Array<Room>;
};

export type FloorCreateInput = {
    name: Scalars['String'];
};

export type FloorId = {
    id: Scalars['Int'];
};

export type FloorUpdateInput = {
    id: Scalars['Int'];
    name: Scalars['String'];
};

export type Patron = {
    bills: Array<Bill>;
    birthdate: Scalars['DateTimeOffset'];
    bookings: Array<Booking>;
    company: Scalars['String'];
    domicile: Scalars['String'];
    email: Scalars['String'];
    gender: Scalars['Boolean'];
    id: Scalars['Int'];
    identification: Scalars['String'];
    name: Scalars['String'];
    nationality: Scalars['String'];
    note: Scalars['String'];
    patronKind: PatronKind;
    phoneNumber: Scalars['String'];
    residence: Scalars['String'];
};

export type PatronCreateInput = {
    identification: Scalars['String'];
    name: Scalars['String'];
    email: Scalars['String'];
    gender: Scalars['Boolean'];
    birthdate: Maybe<Scalars['DateTimeOffset']>;
    nationality: Scalars['String'];
    domicile: Scalars['String'];
    residence: Scalars['String'];
    phoneNumber: Scalars['String'];
    company: Scalars['String'];
    note: Scalars['String'];
    patronKind: PatronKindId;
};

export type PatronId = {
    id: Scalars['Int'];
};

export type PatronKind = {
    description: Scalars['String'];
    id: Scalars['Int'];
    name: Scalars['String'];
    patrons: Array<Patron>;
};

export type PatronKindCreateInput = {
    name: Scalars['String'];
    description: Scalars['String'];
};

export type PatronKindId = {
    id: Scalars['Int'];
};

export type PatronKindUpdateInput = {
    id: Scalars['Int'];
    name: Scalars['String'];
    description: Scalars['String'];
};

export type PatronUpdateInput = {
    id: Scalars['Int'];
    identification: Scalars['String'];
    name: Scalars['String'];
    email: Scalars['String'];
    gender: Scalars['Boolean'];
    birthdate: Scalars['DateTimeOffset'];
    nationality: Scalars['String'];
    domicile: Scalars['String'];
    residence: Scalars['String'];
    phoneNumber: Scalars['String'];
    company: Scalars['String'];
    note: Scalars['String'];
    patronKind: PatronKindId;
};

export type Position = {
    countActiveEmployees: Scalars['Int'];
    countEmployees: Scalars['Int'];
    countInActiveEmployees: Scalars['Int'];
    employees: Array<Employee>;
    id: Scalars['Int'];
    isActive: Scalars['Boolean'];
    name: Scalars['String'];
    permissionCleaning: Scalars['Boolean'];
    permissionGetAccountingVoucher: Scalars['Boolean'];
    permissionGetMap: Scalars['Boolean'];
    permissionGetPatron: Scalars['Boolean'];
    permissionGetPrice: Scalars['Boolean'];
    permissionGetService: Scalars['Boolean'];
    permissionManageEmployee: Scalars['Boolean'];
    permissionManageMap: Scalars['Boolean'];
    permissionManagePatron: Scalars['Boolean'];
    permissionManagePatronKind: Scalars['Boolean'];
    permissionManagePosition: Scalars['Boolean'];
    permissionManagePrice: Scalars['Boolean'];
    permissionManageRentingRoom: Scalars['Boolean'];
    permissionManageService: Scalars['Boolean'];
};

export type PositionCreateInput = {
    name: Scalars['String'];
    permissionCleaning: Scalars['Boolean'];
    permissionGetAccountingVoucher: Scalars['Boolean'];
    permissionGetMap: Scalars['Boolean'];
    permissionGetPatron: Scalars['Boolean'];
    permissionGetPrice: Scalars['Boolean'];
    permissionGetService: Scalars['Boolean'];
    permissionManageEmployee: Scalars['Boolean'];
    permissionManageRentingRoom: Scalars['Boolean'];
    permissionManagePatron: Scalars['Boolean'];
    permissionManagePatronKind: Scalars['Boolean'];
    permissionManagePosition: Scalars['Boolean'];
    permissionManagePrice: Scalars['Boolean'];
    permissionManageService: Scalars['Boolean'];
    permissionManageMap: Scalars['Boolean'];
};

export type PositionId = {
    id: Scalars['Int'];
};

export type PositionUpdateInput = {
    id: Scalars['Int'];
    name: Scalars['String'];
    permissionCleaning: Scalars['Boolean'];
    permissionGetMap: Scalars['Boolean'];
    permissionGetPatron: Scalars['Boolean'];
    permissionGetPrice: Scalars['Boolean'];
    permissionGetService: Scalars['Boolean'];
    permissionGetAccountingVoucher: Scalars['Boolean'];
    permissionManageEmployee: Scalars['Boolean'];
    permissionManageRentingRoom: Scalars['Boolean'];
    permissionManageMap: Scalars['Boolean'];
    permissionManagePatron: Scalars['Boolean'];
    permissionManagePatronKind: Scalars['Boolean'];
    permissionManagePosition: Scalars['Boolean'];
    permissionManagePrice: Scalars['Boolean'];
    permissionManageService: Scalars['Boolean'];
};

export type Price = {
    createDate: Scalars['DateTimeOffset'];
    dayPrice: Scalars['Int'];
    earlyCheckInFee: Scalars['Int'];
    effectiveStartDate: Scalars['DateTimeOffset'];
    employee: Maybe<Employee>;
    hourPrice: Scalars['Int'];
    id: Scalars['Int'];
    lateCheckOutFee: Scalars['Int'];
    monthPrice: Scalars['Int'];
    nightPrice: Scalars['Int'];
    roomKind: RoomKind;
    weekPrice: Scalars['Int'];
};

export type PriceCreateInput = {
    hourPrice: Scalars['Int'];
    dayPrice: Scalars['Int'];
    nightPrice: Scalars['Int'];
    weekPrice: Scalars['Int'];
    monthPrice: Scalars['Int'];
    lateCheckOutFee: Scalars['Int'];
    earlyCheckInFee: Scalars['Int'];
    effectiveStartDate: Scalars['DateTimeOffset'];
    roomKind: RoomKindId;
};

export type PriceItem = {
    booking: Booking;
    kind: PriceItemKindEnum;
    timeSpan: Scalars['Seconds'];
    value: Scalars['Int'];
};

export enum PriceItemKindEnum {
    Hour = 'HOUR',
    Night = 'NIGHT',
    Day = 'DAY',
    Week = 'WEEK',
    Month = 'MONTH',
}

export type PriceUpdateInput = {
    id: Scalars['Int'];
    hourPrice: Scalars['Int'];
    dayPrice: Scalars['Int'];
    nightPrice: Scalars['Int'];
    weekPrice: Scalars['Int'];
    monthPrice: Scalars['Int'];
    lateCheckOutFee: Scalars['Int'];
    earlyCheckInFee: Scalars['Int'];
    effectiveStartDate: Scalars['DateTimeOffset'];
    roomKind: RoomKindId;
};

export type PriceVolatility = {
    createDate: Scalars['DateTimeOffset'];
    dayPrice: Scalars['Int'];
    effectiveEndDate: Scalars['DateTimeOffset'];
    effectiveOnFriday: Scalars['Boolean'];
    effectiveOnMonday: Scalars['Boolean'];
    effectiveOnSaturday: Scalars['Boolean'];
    effectiveOnSunday: Scalars['Boolean'];
    effectiveOnTuesday: Scalars['Boolean'];
    effectiveOnThursday: Scalars['Boolean'];
    effectiveOnWednesday: Scalars['Boolean'];
    effectiveStartDate: Scalars['DateTimeOffset'];
    employee: Maybe<Employee>;
    hourPrice: Scalars['Int'];
    id: Scalars['Int'];
    name: Scalars['String'];
    nightPrice: Scalars['Int'];
    roomKind: RoomKind;
};

export type PriceVolatilityCreateInput = {
    name: Scalars['String'];
    hourPrice: Scalars['Int'];
    dayPrice: Scalars['Int'];
    nightPrice: Scalars['Int'];
    effectiveStartDate: Scalars['DateTimeOffset'];
    effectiveEndDate: Scalars['DateTimeOffset'];
    effectiveOnMonday: Scalars['Boolean'];
    effectiveOnTuesday: Scalars['Boolean'];
    effectiveOnWednesday: Scalars['Boolean'];
    effectiveOnThursday: Scalars['Boolean'];
    effectiveOnFriday: Scalars['Boolean'];
    effectiveOnSaturday: Scalars['Boolean'];
    effectiveOnSunday: Scalars['Boolean'];
    roomKind: RoomKindId;
};

export type PriceVolatilityItem = {
    booking: Booking;
    date: Scalars['DateTimeOffset'];
    kind: PriceVolatilityItemKindEnum;
    priceVolatility: PriceVolatility;
    timeSpan: Scalars['Seconds'];
    value: Scalars['Int'];
};

export enum PriceVolatilityItemKindEnum {
    Hour = 'HOUR',
    Night = 'NIGHT',
    Day = 'DAY',
}

export type PriceVolatilityUpdateInput = {
    id: Scalars['Int'];
    hourPrice: Scalars['Int'];
    dayPrice: Scalars['Int'];
    nightPrice: Scalars['Int'];
    effectiveStartDate: Scalars['DateTimeOffset'];
    effectiveEndDate: Scalars['DateTimeOffset'];
    effectiveOnMonday: Scalars['Boolean'];
    effectiveOnTuesday: Scalars['Boolean'];
    effectiveOnWednesday: Scalars['Boolean'];
    effectiveOnThursday: Scalars['Boolean'];
    effectiveOnFriday: Scalars['Boolean'];
    effectiveOnSaturday: Scalars['Boolean'];
    effectiveOnSunday: Scalars['Boolean'];
    roomKind: RoomKindId;
};

export type Receipt = {
    bill: Bill;
    employee: Employee;
    extraData: Scalars['String'];
    id: Scalars['Int'];
    kind: ReceiptKindEnum;
    money: Scalars['Int'];
    orderId: Scalars['String'];
    orderInfo: Scalars['String'];
    payUrl: Scalars['String'];
    status: ReceiptStatusEnum;
    statusText: Scalars['String'];
    time: Scalars['DateTimeOffset'];
};

export type ReceiptCreateInput = {
    money: Scalars['Int'];
    bill: BillId;
    kind: ReceiptKindEnum;
};

export enum ReceiptKindEnum {
    Cash = 'CASH',
    Momo = 'MOMO',
}

export enum ReceiptStatusEnum {
    Pending = 'PENDING',
    Success = 'SUCCESS',
    Error = 'ERROR',
    SystemError = 'SYSTEM_ERROR',
}

export type Room = {
    bookings: Array<Booking>;
    currentBooking: Maybe<Booking>;
    floor: Floor;
    id: Scalars['Int'];
    isActive: Scalars['Boolean'];
    isClean: Scalars['Boolean'];
    isEmpty: Scalars['Boolean'];
    name: Scalars['String'];
    roomKind: RoomKind;
};

export type RoomCurrentBookingArgs = {
    from: Scalars['DateTimeOffset'];
    to: Scalars['DateTimeOffset'];
};

export type RoomIsEmptyArgs = {
    from: Scalars['DateTimeOffset'];
    to: Scalars['DateTimeOffset'];
};

export type RoomCreateInput = {
    name: Scalars['String'];
    floor: FloorId;
    roomKind: RoomKindId;
};

export type RoomId = {
    id: Scalars['Int'];
};

export type RoomKind = {
    amountOfPeople: Scalars['Int'];
    currentPrice: Price;
    currentPriceVolatilities: Array<PriceVolatility>;
    id: Scalars['Int'];
    isActive: Scalars['Boolean'];
    name: Scalars['String'];
    numberOfBeds: Scalars['Int'];
    prices: Array<Price>;
    priceVolatilities: Array<PriceVolatility>;
    rooms: Array<Room>;
};

export type RoomKindCreateInput = {
    name: Scalars['String'];
    numberOfBeds: Scalars['Int'];
    amountOfPeople: Scalars['Int'];
};

export type RoomKindId = {
    id: Scalars['Int'];
};

export type RoomKindUpdateInput = {
    id: Scalars['Int'];
    name: Scalars['String'];
    numberOfBeds: Scalars['Int'];
    amountOfPeople: Scalars['Int'];
};

export type RoomUpdateInput = {
    id: Scalars['Int'];
    name: Scalars['String'];
    floor: FloorId;
    roomKind: RoomKindId;
};

export type Service = {
    id: Scalars['Int'];
    isActive: Scalars['Boolean'];
    name: Scalars['String'];
    servicesDetails: Array<ServicesDetail>;
    unit: Scalars['String'];
    unitPrice: Scalars['Int'];
};

export type ServiceCreateInput = {
    name: Scalars['String'];
    unitPrice: Scalars['Int'];
    unit: Scalars['String'];
};

export type ServiceId = {
    id: Scalars['Int'];
};

export type ServicesDetail = {
    booking: Booking;
    id: Scalars['Int'];
    number: Scalars['Int'];
    service: Service;
    time: Scalars['DateTimeOffset'];
    total: Scalars['Int'];
};

export type ServicesDetailCreateInput = {
    number: Scalars['Int'];
    service: ServiceId;
    booking: BookingId;
};

export type ServicesDetailUpdateInput = {
    id: Scalars['Int'];
    number: Scalars['Int'];
    service: ServiceId;
};

export type ServiceUpdateInput = {
    id: Scalars['Int'];
    name: Scalars['String'];
    unitPrice: Scalars['Int'];
    unit: Scalars['String'];
};

export type GetBillsQueryVariables = {};

export type GetBillsQuery = {
    bills: Array<
        Pick<
            Bill,
            | 'id'
            | 'time'
            | 'totalPrice'
            | 'totalReceipts'
            | 'discount'
            | 'status'
        > & {
            patron: Pick<Patron, 'id' | 'name'>;
            bookings: Array<
                Pick<Booking, 'id' | 'status'> & {
                    room: Pick<Room, 'id' | 'name'>;
                }
            >;
        }
    >;
};

export type GetBillQueryVariables = {
    id: Scalars['ID'];
};

export type GetBillQuery = {
    bill: Pick<
        Bill,
        'id' | 'status' | 'time' | 'discount' | 'totalPrice' | 'totalReceipts'
    > & {
        patron: Pick<Patron, 'id' | 'name'>;
        bookings: Array<
            Pick<
                Booking,
                | 'id'
                | 'total'
                | 'status'
                | 'realCheckInTime'
                | 'realCheckOutTime'
                | 'bookCheckInTime'
                | 'bookCheckOutTime'
            > & {
                patrons: Array<Pick<Patron, 'id'>>;
                room: Pick<Room, 'id' | 'name'>;
            }
        >;
        receipts: Array<
            Pick<
                Receipt,
                | 'id'
                | 'orderId'
                | 'time'
                | 'kind'
                | 'status'
                | 'statusText'
                | 'payUrl'
                | 'money'
            >
        >;
    };
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

export type UpdateBillDiscountMutationVariables = {
    input: BillUpdateDiscountInput;
};

export type UpdateBillDiscountMutation = {
    updateBillDiscount: Pick<Bill, 'id'>;
};

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
            patrons: Array<Pick<Patron, 'id' | 'name'>>;
            bill: Pick<Bill, 'id'>;
            room: Pick<Room, 'id' | 'name' | 'isClean'>;
        }
    >;
};

export type GetBookingQueryVariables = {
    id: Scalars['ID'];
};

export type GetBookingQuery = {
    booking: Pick<
        Booking,
        | 'id'
        | 'bookCheckInTime'
        | 'bookCheckOutTime'
        | 'realCheckInTime'
        | 'realCheckOutTime'
        | 'baseNightCheckInTime'
        | 'baseDayCheckInTime'
        | 'baseDayCheckOutTime'
        | 'earlyCheckInFee'
        | 'lateCheckOutFee'
        | 'total'
        | 'totalPrice'
        | 'totalServicesDetails'
        | 'status'
    > & {
        price: Pick<
            Price,
            | 'id'
            | 'hourPrice'
            | 'nightPrice'
            | 'dayPrice'
            | 'weekPrice'
            | 'monthPrice'
            | 'earlyCheckInFee'
            | 'lateCheckOutFee'
        >;
        priceItems: Array<Pick<PriceItem, 'kind' | 'timeSpan' | 'value'>>;
        priceVolatilityItems: Array<
            Pick<
                PriceVolatilityItem,
                'kind' | 'date' | 'timeSpan' | 'value'
            > & {
                priceVolatility: Pick<
                    PriceVolatility,
                    'id' | 'name' | 'dayPrice' | 'hourPrice' | 'nightPrice'
                >;
            }
        >;
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
                | 'phoneNumber'
                | 'nationality'
                | 'company'
                | 'note'
            > & { patronKind: Pick<PatronKind, 'id'> }
        >;
        bill: Pick<Bill, 'id'>;
        servicesDetails: Array<
            Pick<ServicesDetail, 'id' | 'number' | 'time'> & {
                service: Pick<Service, 'id' | 'name' | 'unit' | 'unitPrice'>;
            }
        >;
        room: Pick<Room, 'id' | 'name' | 'isClean'> & {
            roomKind: Pick<
                RoomKind,
                'id' | 'name' | 'numberOfBeds' | 'amountOfPeople'
            >;
            floor: Pick<Floor, 'id' | 'name'>;
        };
    };
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

export type GetEmployeeQueryVariables = {
    id: Scalars['ID'];
};

export type GetEmployeeQuery = {
    employee: Pick<
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
    > & { position: Pick<Position, 'id' | 'name'> };
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
                | 'permissionGetPrice'
                | 'permissionGetService'
                | 'permissionManageEmployee'
                | 'permissionManageRentingRoom'
                | 'permissionManageMap'
                | 'permissionManagePatron'
                | 'permissionManagePatronKind'
                | 'permissionManagePosition'
                | 'permissionManagePrice'
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
            | 'permissionGetPrice'
            | 'permissionGetService'
            | 'permissionManageEmployee'
            | 'permissionManageRentingRoom'
            | 'permissionManageMap'
            | 'permissionManagePatron'
            | 'permissionManagePatronKind'
            | 'permissionManagePosition'
            | 'permissionManagePrice'
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
                Pick<Room, 'id' | 'name' | 'isClean' | 'isActive'> & {
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
                            | 'realCheckInTime'
                            | 'realCheckOutTime'
                        > & { patrons: Array<Pick<Patron, 'id'>> }
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
            | 'phoneNumber'
            | 'nationality'
            | 'company'
            | 'note'
        > & { patronKind: Pick<PatronKind, 'id' | 'name'> }
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
        | 'phoneNumber'
        | 'nationality'
        | 'company'
        | 'note'
    > & {
        patronKind: Pick<PatronKind, 'id' | 'name'>;
        bookings: Array<
            Pick<
                Booking,
                | 'id'
                | 'bookCheckInTime'
                | 'bookCheckOutTime'
                | 'realCheckInTime'
                | 'realCheckOutTime'
                | 'status'
                | 'total'
            > & { room: Pick<Room, 'id' | 'name'> }
        >;
    };
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
        | 'phoneNumber'
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
            patrons: Array<Pick<Patron, 'id' | 'name'>>;
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
            | 'permissionGetPrice'
            | 'permissionGetService'
            | 'permissionManageEmployee'
            | 'permissionManageRentingRoom'
            | 'permissionManageMap'
            | 'permissionManagePatron'
            | 'permissionManagePatronKind'
            | 'permissionManagePosition'
            | 'permissionManagePrice'
            | 'permissionManageService'
            | 'isActive'
        > & { employees: Array<Pick<Employee, 'id' | 'isActive'>> }
    >;
};

export type GetPositionQueryVariables = {
    id: Scalars['ID'];
};

export type GetPositionQuery = {
    position: Pick<
        Position,
        | 'id'
        | 'name'
        | 'permissionCleaning'
        | 'permissionGetAccountingVoucher'
        | 'permissionGetMap'
        | 'permissionGetPatron'
        | 'permissionGetPrice'
        | 'permissionGetService'
        | 'permissionManageEmployee'
        | 'permissionManageRentingRoom'
        | 'permissionManageMap'
        | 'permissionManagePatron'
        | 'permissionManagePatronKind'
        | 'permissionManagePosition'
        | 'permissionManagePrice'
        | 'permissionManageService'
        | 'isActive'
    > & { employees: Array<Pick<Employee, 'id' | 'name' | 'isActive'>> };
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

export type GetPricesQueryVariables = {};

export type GetPricesQuery = {
    prices: Array<
        Pick<
            Price,
            | 'id'
            | 'hourPrice'
            | 'nightPrice'
            | 'dayPrice'
            | 'effectiveStartDate'
            | 'createDate'
        > & { roomKind: Pick<RoomKind, 'id' | 'name'> }
    >;
};

export type GetPriceQueryVariables = {
    id: Scalars['ID'];
};

export type GetPriceQuery = {
    price: Pick<
        Price,
        | 'id'
        | 'createDate'
        | 'effectiveStartDate'
        | 'earlyCheckInFee'
        | 'lateCheckOutFee'
        | 'hourPrice'
        | 'nightPrice'
        | 'dayPrice'
        | 'weekPrice'
        | 'monthPrice'
    > & { roomKind: Pick<RoomKind, 'id' | 'name'> };
};

export type CreatePriceMutationVariables = {
    input: PriceCreateInput;
};

export type CreatePriceMutation = { createPrice: Pick<Price, 'id'> };

export type GetPriceVolatilitiesQueryVariables = {};

export type GetPriceVolatilitiesQuery = {
    priceVolatilities: Array<
        Pick<
            PriceVolatility,
            | 'id'
            | 'name'
            | 'hourPrice'
            | 'dayPrice'
            | 'nightPrice'
            | 'effectiveStartDate'
            | 'effectiveEndDate'
            | 'effectiveOnMonday'
            | 'effectiveOnTuesday'
            | 'effectiveOnWednesday'
            | 'effectiveOnThursday'
            | 'effectiveOnFriday'
            | 'effectiveOnSaturday'
            | 'effectiveOnSunday'
            | 'createDate'
        > & {
            employee: Maybe<Pick<Employee, 'id'>>;
            roomKind: Pick<RoomKind, 'id' | 'name'>;
        }
    >;
};

export type GetPriceVolatilityQueryVariables = {
    id: Scalars['ID'];
};

export type GetPriceVolatilityQuery = {
    priceVolatility: Pick<
        PriceVolatility,
        | 'id'
        | 'name'
        | 'hourPrice'
        | 'dayPrice'
        | 'nightPrice'
        | 'effectiveStartDate'
        | 'effectiveEndDate'
        | 'effectiveOnMonday'
        | 'effectiveOnTuesday'
        | 'effectiveOnWednesday'
        | 'effectiveOnThursday'
        | 'effectiveOnFriday'
        | 'effectiveOnSaturday'
        | 'effectiveOnSunday'
        | 'createDate'
    > & {
        employee: Maybe<Pick<Employee, 'id'>>;
        roomKind: Pick<RoomKind, 'id' | 'name'>;
    };
};

export type CreatePriceVolatilityMutationVariables = {
    input: PriceVolatilityCreateInput;
};

export type CreatePriceVolatilityMutation = {
    createPriceVolatility: Pick<PriceVolatility, 'id'>;
};

export type GetReceiptsQueryVariables = {};

export type GetReceiptsQuery = {
    receipts: Array<
        Pick<Receipt, 'id' | 'money' | 'time'> & { bill: Pick<Bill, 'id'> }
    >;
};

export type GetReceiptQueryVariables = {
    id: Scalars['ID'];
};

export type GetReceiptQuery = {
    receipt: Pick<
        Receipt,
        'id' | 'time' | 'kind' | 'status' | 'statusText' | 'payUrl' | 'money'
    >;
};

export type CheckReceiptMutationVariables = {
    id: Scalars['ID'];
};

export type CheckReceiptMutation = {
    checkReceipt: Pick<Receipt, 'id' | 'status' | 'statusText'>;
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
        > & { rooms: Array<Pick<Room, 'id'>> }
    >;
};

export type GetRoomKindQueryVariables = {
    id: Scalars['ID'];
};

export type GetRoomKindQuery = {
    roomKind: Pick<
        RoomKind,
        'id' | 'name' | 'isActive' | 'amountOfPeople' | 'numberOfBeds'
    > & {
        rooms: Array<
            Pick<Room, 'id' | 'isActive' | 'name'> & {
                floor: Pick<Floor, 'id'>;
            }
        >;
        currentPrice: Pick<
            Price,
            | 'id'
            | 'earlyCheckInFee'
            | 'lateCheckOutFee'
            | 'hourPrice'
            | 'nightPrice'
            | 'dayPrice'
            | 'weekPrice'
            | 'monthPrice'
        >;
        currentPriceVolatilities: Array<
            Pick<
                PriceVolatility,
                'id' | 'name' | 'hourPrice' | 'nightPrice' | 'dayPrice'
            >
        >;
    };
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

export type GetRoomQuery = {
    room: Pick<Room, 'id' | 'name' | 'isActive' | 'isClean'> & {
        roomKind: Pick<RoomKind, 'id' | 'name'>;
        bookings: Array<
            Pick<
                Booking,
                | 'id'
                | 'total'
                | 'status'
                | 'realCheckInTime'
                | 'realCheckOutTime'
                | 'bookCheckInTime'
                | 'bookCheckOutTime'
            > & {
                patrons: Array<Pick<Patron, 'id'>>;
                room: Pick<Room, 'id' | 'name'>;
            }
        >;
    };
};

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

export type DeleteServicesDetailMutationVariables = {
    id: Scalars['ID'];
};

export type DeleteServicesDetailMutation = Pick<
    AppMutation,
    'deleteServicesDetail'
>;

export type GetServicesQueryVariables = {};

export type GetServicesQuery = {
    services: Array<
        Pick<Service, 'id' | 'name' | 'unitPrice' | 'unit' | 'isActive'> & {
            servicesDetails: Array<Pick<ServicesDetail, 'id' | 'number'>>;
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
            | 'phoneNumber'
            | 'nationality'
            | 'company'
            | 'note'
        > & { patronKind: Pick<PatronKind, 'id'> }
    >;
    rooms: Array<Pick<Room, 'id' | 'name' | 'isActive' | 'isClean'>>;
};

export type IsInitializedQueryVariables = {};

export type IsInitializedQuery = Pick<AppQuery, 'isInitialized'>;

export namespace GetBills {
    export type Variables = GetBillsQueryVariables;
    export type Query = GetBillsQuery;
    export type Bills = NonNullable<GetBillsQuery['bills'][0]>;
    export type Patron = NonNullable<GetBillsQuery['bills'][0]>['patron'];
    export type Bookings = NonNullable<
        NonNullable<GetBillsQuery['bills'][0]>['bookings'][0]
    >;
    export type Room = NonNullable<
        NonNullable<GetBillsQuery['bills'][0]>['bookings'][0]
    >['room'];
}

export namespace GetBill {
    export type Variables = GetBillQueryVariables;
    export type Query = GetBillQuery;
    export type Bill = GetBillQuery['bill'];
    export type Patron = GetBillQuery['bill']['patron'];
    export type Bookings = NonNullable<GetBillQuery['bill']['bookings'][0]>;
    export type Patrons = NonNullable<
        NonNullable<GetBillQuery['bill']['bookings'][0]>['patrons'][0]
    >;
    export type Room = NonNullable<GetBillQuery['bill']['bookings'][0]>['room'];
    export type Receipts = NonNullable<GetBillQuery['bill']['receipts'][0]>;
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

export namespace UpdateBillDiscount {
    export type Variables = UpdateBillDiscountMutationVariables;
    export type Mutation = UpdateBillDiscountMutation;
    export type UpdateBillDiscount = UpdateBillDiscountMutation['updateBillDiscount'];
}

export namespace GetBookings {
    export type Variables = GetBookingsQueryVariables;
    export type Query = GetBookingsQuery;
    export type Bookings = NonNullable<GetBookingsQuery['bookings'][0]>;
    export type Patrons = NonNullable<
        NonNullable<GetBookingsQuery['bookings'][0]>['patrons'][0]
    >;
    export type Bill = NonNullable<GetBookingsQuery['bookings'][0]>['bill'];
    export type Room = NonNullable<GetBookingsQuery['bookings'][0]>['room'];
}

export namespace GetBooking {
    export type Variables = GetBookingQueryVariables;
    export type Query = GetBookingQuery;
    export type Booking = GetBookingQuery['booking'];
    export type Price = GetBookingQuery['booking']['price'];
    export type PriceItems = NonNullable<
        GetBookingQuery['booking']['priceItems'][0]
    >;
    export type PriceVolatilityItems = NonNullable<
        GetBookingQuery['booking']['priceVolatilityItems'][0]
    >;
    export type PriceVolatility = NonNullable<
        GetBookingQuery['booking']['priceVolatilityItems'][0]
    >['priceVolatility'];
    export type Patrons = NonNullable<GetBookingQuery['booking']['patrons'][0]>;
    export type PatronKind = NonNullable<
        GetBookingQuery['booking']['patrons'][0]
    >['patronKind'];
    export type Bill = GetBookingQuery['booking']['bill'];
    export type ServicesDetails = NonNullable<
        GetBookingQuery['booking']['servicesDetails'][0]
    >;
    export type Service = NonNullable<
        GetBookingQuery['booking']['servicesDetails'][0]
    >['service'];
    export type Room = GetBookingQuery['booking']['room'];
    export type RoomKind = GetBookingQuery['booking']['room']['roomKind'];
    export type Floor = GetBookingQuery['booking']['room']['floor'];
}

export namespace GetSimpleBookings {
    export type Variables = GetSimpleBookingsQueryVariables;
    export type Query = GetSimpleBookingsQuery;
    export type Bookings = NonNullable<GetSimpleBookingsQuery['bookings'][0]>;
    export type Room = NonNullable<
        GetSimpleBookingsQuery['bookings'][0]
    >['room'];
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
    export type Position = NonNullable<
        GetEmployeesQuery['employees'][0]
    >['position'];
}

export namespace GetEmployee {
    export type Variables = GetEmployeeQueryVariables;
    export type Query = GetEmployeeQuery;
    export type Employee = GetEmployeeQuery['employee'];
    export type Position = GetEmployeeQuery['employee']['position'];
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
        NonNullable<GetFloorsQuery['floors'][0]>['rooms'][0]
    >;
    export type RoomKind = NonNullable<
        NonNullable<GetFloorsQuery['floors'][0]>['rooms'][0]
    >['roomKind'];
}

export namespace GetFloorsMap {
    export type Variables = GetFloorsMapQueryVariables;
    export type Query = GetFloorsMapQuery;
    export type Floors = NonNullable<GetFloorsMapQuery['floors'][0]>;
    export type Rooms = NonNullable<
        NonNullable<GetFloorsMapQuery['floors'][0]>['rooms'][0]
    >;
    export type CurrentBooking = NonNullable<
        NonNullable<
            NonNullable<GetFloorsMapQuery['floors'][0]>['rooms'][0]
        >['currentBooking']
    >;
    export type RoomKind = NonNullable<
        NonNullable<GetFloorsMapQuery['floors'][0]>['rooms'][0]
    >['roomKind'];
}

export namespace GetTimeline {
    export type Variables = GetTimelineQueryVariables;
    export type Query = GetTimelineQuery;
    export type Floors = NonNullable<GetTimelineQuery['floors'][0]>;
    export type Rooms = NonNullable<
        NonNullable<GetTimelineQuery['floors'][0]>['rooms'][0]
    >;
    export type Bookings = NonNullable<
        NonNullable<
            NonNullable<GetTimelineQuery['floors'][0]>['rooms'][0]
        >['bookings'][0]
    >;
    export type Patrons = NonNullable<
        NonNullable<
            NonNullable<
                NonNullable<GetTimelineQuery['floors'][0]>['rooms'][0]
            >['bookings'][0]
        >['patrons'][0]
    >;
    export type RoomKind = NonNullable<
        NonNullable<GetTimelineQuery['floors'][0]>['rooms'][0]
    >['roomKind'];
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
    export type PatronKind = NonNullable<
        GetPatronsQuery['patrons'][0]
    >['patronKind'];
}

export namespace GetPatron {
    export type Variables = GetPatronQueryVariables;
    export type Query = GetPatronQuery;
    export type Patron = GetPatronQuery['patron'];
    export type PatronKind = GetPatronQuery['patron']['patronKind'];
    export type Bookings = NonNullable<GetPatronQuery['patron']['bookings'][0]>;
    export type Room = NonNullable<
        GetPatronQuery['patron']['bookings'][0]
    >['room'];
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
        NonNullable<GetPatronKindsQuery['patronKinds'][0]>['patrons'][0]
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
        NonNullable<GetPositionsQuery['positions'][0]>['employees'][0]
    >;
}

export namespace GetPosition {
    export type Variables = GetPositionQueryVariables;
    export type Query = GetPositionQuery;
    export type Position = GetPositionQuery['position'];
    export type Employees = NonNullable<
        GetPositionQuery['position']['employees'][0]
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

export namespace GetPrices {
    export type Variables = GetPricesQueryVariables;
    export type Query = GetPricesQuery;
    export type Prices = NonNullable<GetPricesQuery['prices'][0]>;
    export type RoomKind = NonNullable<GetPricesQuery['prices'][0]>['roomKind'];
}

export namespace GetPrice {
    export type Variables = GetPriceQueryVariables;
    export type Query = GetPriceQuery;
    export type Price = GetPriceQuery['price'];
    export type RoomKind = GetPriceQuery['price']['roomKind'];
}

export namespace CreatePrice {
    export type Variables = CreatePriceMutationVariables;
    export type Mutation = CreatePriceMutation;
    export type CreatePrice = CreatePriceMutation['createPrice'];
}

export namespace GetPriceVolatilities {
    export type Variables = GetPriceVolatilitiesQueryVariables;
    export type Query = GetPriceVolatilitiesQuery;
    export type PriceVolatilities = NonNullable<
        GetPriceVolatilitiesQuery['priceVolatilities'][0]
    >;
    export type Employee = NonNullable<
        NonNullable<
            GetPriceVolatilitiesQuery['priceVolatilities'][0]
        >['employee']
    >;
    export type RoomKind = NonNullable<
        GetPriceVolatilitiesQuery['priceVolatilities'][0]
    >['roomKind'];
}

export namespace GetPriceVolatility {
    export type Variables = GetPriceVolatilityQueryVariables;
    export type Query = GetPriceVolatilityQuery;
    export type PriceVolatility = GetPriceVolatilityQuery['priceVolatility'];
    export type Employee = NonNullable<
        GetPriceVolatilityQuery['priceVolatility']['employee']
    >;
    export type RoomKind = GetPriceVolatilityQuery['priceVolatility']['roomKind'];
}

export namespace CreatePriceVolatility {
    export type Variables = CreatePriceVolatilityMutationVariables;
    export type Mutation = CreatePriceVolatilityMutation;
    export type CreatePriceVolatility = CreatePriceVolatilityMutation['createPriceVolatility'];
}

export namespace GetReceipts {
    export type Variables = GetReceiptsQueryVariables;
    export type Query = GetReceiptsQuery;
    export type Receipts = NonNullable<GetReceiptsQuery['receipts'][0]>;
    export type Bill = NonNullable<GetReceiptsQuery['receipts'][0]>['bill'];
}

export namespace GetReceipt {
    export type Variables = GetReceiptQueryVariables;
    export type Query = GetReceiptQuery;
    export type Receipt = GetReceiptQuery['receipt'];
}

export namespace CheckReceipt {
    export type Variables = CheckReceiptMutationVariables;
    export type Mutation = CheckReceiptMutation;
    export type CheckReceipt = CheckReceiptMutation['checkReceipt'];
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
        NonNullable<GetRoomKindsQuery['roomKinds'][0]>['rooms'][0]
    >;
}

export namespace GetRoomKind {
    export type Variables = GetRoomKindQueryVariables;
    export type Query = GetRoomKindQuery;
    export type RoomKind = GetRoomKindQuery['roomKind'];
    export type Rooms = NonNullable<GetRoomKindQuery['roomKind']['rooms'][0]>;
    export type Floor = NonNullable<
        GetRoomKindQuery['roomKind']['rooms'][0]
    >['floor'];
    export type CurrentPrice = GetRoomKindQuery['roomKind']['currentPrice'];
    export type CurrentPriceVolatilities = NonNullable<
        GetRoomKindQuery['roomKind']['currentPriceVolatilities'][0]
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
    export type RoomKind = GetRoomQuery['room']['roomKind'];
    export type Bookings = NonNullable<GetRoomQuery['room']['bookings'][0]>;
    export type Patrons = NonNullable<
        NonNullable<GetRoomQuery['room']['bookings'][0]>['patrons'][0]
    >;
    export type _Room = NonNullable<
        GetRoomQuery['room']['bookings'][0]
    >['room'];
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

export namespace DeleteServicesDetail {
    export type Variables = DeleteServicesDetailMutationVariables;
    export type Mutation = DeleteServicesDetailMutation;
}

export namespace GetServices {
    export type Variables = GetServicesQueryVariables;
    export type Query = GetServicesQuery;
    export type Services = NonNullable<GetServicesQuery['services'][0]>;
    export type ServicesDetails = NonNullable<
        NonNullable<GetServicesQuery['services'][0]>['servicesDetails'][0]
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
    export type PatronKind = NonNullable<
        GetPatronsAndRoomsQuery['patrons'][0]
    >['patronKind'];
    export type Rooms = NonNullable<GetPatronsAndRoomsQuery['rooms'][0]>;
}

export namespace IsInitialized {
    export type Variables = IsInitializedQueryVariables;
    export type Query = IsInitializedQuery;
}
