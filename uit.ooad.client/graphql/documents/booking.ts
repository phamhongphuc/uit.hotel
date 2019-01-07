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
