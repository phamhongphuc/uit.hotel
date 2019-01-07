import gql from 'graphql-tag';

export const getBills = gql`
    query getBills {
        bills {
            id
            time
            total
            patron {
                id
                name
            }
            employee {
                id
                name
            }
            receipts {
                id
                money
            }
            bookings {
                id
                total
            }
        }
    }
`;

export const addBookingToBill = gql`
    mutation addBookingToBill($bill: BillId!, $booking: BookingCreateInput!) {
        addBookingToBill(bill: $bill, booking: $booking) {
            id
        }
    }
`;

export const bookAndCheckIn = gql`
    mutation bookAndCheckIn(
        $bookings: [BookAndCheckInCreateInput!]!
        $bill: BillCreateInput!
    ) {
        bookAndCheckIn(bookings: $bookings, bill: $bill) {
            id
        }
    }
`;
