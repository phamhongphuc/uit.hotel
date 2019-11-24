import gql from 'graphql-tag';

export const getBills = gql`
    query getBills {
        bills {
            id
            time
            totalPrice
            patron {
                id
                name
            }
            receipts {
                id
                money
            }
            bookings {
                id
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

export const createBill = gql`
    mutation createBill(
        $bookings: [BookingCreateInput!]!
        $bill: BillCreateInput!
    ) {
        createBill(bookings: $bookings, bill: $bill) {
            id
        }
    }
`;

export const payTheBill = gql`
    mutation payTheBill($id: ID!) {
        payTheBill(id: $id) {
            id
        }
    }
`;
