import gql from 'graphql-tag';

export const getBookings = gql`
    query getBookings {
        bookings {
            id
            bookCheckInTime
            bookCheckOutTime
            realCheckInTime
            realCheckOutTime
            status
            patrons {
                id
                name
            }
            bill {
                id
            }
            room {
                id
                name
                isClean
            }
        }
    }
`;

export const getBooking = gql`
    query getBooking($id: ID!) {
        booking(id: $id) {
            id
            bookCheckInTime
            bookCheckOutTime
            realCheckInTime
            realCheckOutTime

            baseNightCheckInTime
            baseDayCheckInTime
            baseDayCheckOutTime

            price {
                id
                hourPrice
                nightPrice
                dayPrice
                weekPrice
                monthPrice
                earlyCheckInFee
                lateCheckOutFee
            }
            priceItems {
                kind
                timeSpan
                value
            }
            priceVolatilityItems {
                kind
                date
                timeSpan
                value
                priceVolatility {
                    id
                    name
                    dayPrice
                    hourPrice
                    nightPrice
                }
            }
            earlyCheckInFee
            lateCheckOutFee
            total
            totalPrice
            totalServicesDetails

            status
            patrons {
                id
                identification
                name
                birthdate
                email
                gender
                residence
                domicile
                phoneNumber
                nationality
                company
                note
                patronKind {
                    id
                }
            }
            bill {
                id
            }
            servicesDetails {
                id
                number
                service {
                    id
                    name
                    unit
                    unitPrice
                }
                time
            }
            room {
                id
                name
                isClean
                roomKind {
                    id
                    name
                    numberOfBeds
                    amountOfPeople
                }
                floor {
                    id
                    name
                }
            }
        }
    }
`;

export const getSimpleBookings = gql`
    query getSimpleBookings {
        bookings {
            id
            status
            room {
                id
                name
            }
        }
    }
`;

export const checkIn = gql`
    mutation checkIn($id: ID!) {
        checkIn(id: $id) {
            id
        }
    }
`;

export const checkOut = gql`
    mutation checkOut($id: ID!) {
        checkOut(id: $id) {
            id
        }
    }
`;

export const cancel = gql`
    mutation cancel($id: ID!) {
        cancel(id: $id)
    }
`;
