import gql from 'graphql-tag';

export enum BookingStatus {
    Booked,
    CheckedIn,
    CheckedOut,
}

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

export const getBookingDetails = gql`
    query getBookingDetails($id: ID!) {
        booking(id: $id) {
            id
            bookCheckInTime
            bookCheckOutTime
            realCheckInTime
            realCheckOutTime
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
                phoneNumbers
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
                    unitRate
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
