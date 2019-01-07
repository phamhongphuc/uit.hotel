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
            total
            totalRates
            totalVolatilityRate
            totalServicesDetails
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

export const requestCheckOut = gql`
    mutation requestCheckOut($id: ID!) {
        requestCheckOut(id: $id) {
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
