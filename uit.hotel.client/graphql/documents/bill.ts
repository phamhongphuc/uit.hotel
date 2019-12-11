import gql from 'graphql-tag';

export const getBills = gql`
    query getBills {
        bills {
            id
            time
            totalPrice
            totalReceipts
            discount
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
                status
                room {
                    id
                    name
                }
            }
        }
    }
`;

export const getBill = gql`
    query getBill($id: ID!) {
        bill(id: $id) {
            id
            patron {
                id
                name
            }
            time
            discount
            totalPrice
            totalReceipts
            bookings {
                id
                total
                status
                patrons {
                    id
                }
                room {
                    id
                    name
                }
                realCheckInTime
                realCheckOutTime
                bookCheckInTime
                bookCheckOutTime
            }
            receipts {
                id
                money
                employee {
                    id
                    name
                }
                time
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
