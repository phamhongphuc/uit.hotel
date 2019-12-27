<template>
    <popup-
        ref="popup"
        v-slot
        :title="`Chi tiết hóa đơn #${id}`"
        class="popup-bill-detail"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getBill"
            :variables="variables"
            :poll-interval="500"
            @result="onResult"
        >
            <div class="p-3">
                <div class="d-flex m-child-1 mb-2 flex-wrap">
                    <div class="py-1 px-1 font-weight-medium mr-auto">
                        <span>
                            <icon-
                                i="circle-fill"
                                class="mr-1"
                                :class="`text-${bookingStatusColorMap[status]}`"
                            />
                            {{ billStatusMap[status] }}
                        </span>
                        <span
                            v-if="status === BookingStatusEnum.CheckedOut"
                            class="ml-1"
                        >
                            <span v-if="isMinDate(bill.time)">
                                <icon- i="circle" class="mr-1 text-yellow" />
                                Chưa thanh toán
                            </span>
                            <span v-else>
                                <icon-
                                    i="check-circle"
                                    class="mr-1 text-green"
                                />
                                Đã thanh toán {{ fromNow(bill.time) }}
                            </span>
                        </span>
                    </div>
                    <b-button
                        v-if="isMinDate(bill.time)"
                        size="sm"
                        variant="lighten"
                        @click="refs.bill_update_discount.open({ bill })"
                    >
                        <icon- class="mr-1" i="discount" />
                        <span>Giảm giá</span>
                    </b-button>
                    <b-button-mutate-
                        v-if="
                            isMinDate(bill.time) &&
                                status === BookingStatusEnum.CheckedOut &&
                                rest === 0
                        "
                        size="sm"
                        variant="lighten"
                        :mutation="payTheBill"
                        :variables="{ id }"
                    >
                        <icon- class="mr-1" i="card" />
                        Chốt hóa đơn
                    </b-button-mutate->
                    <b-button
                        v-if="isMinDate(bill.time)"
                        size="sm"
                        variant="green"
                        @click="refs.receipt_add.open({ bill })"
                    >
                        <icon- class="mr-1" i="card-down" />
                        <span>Thanh toán</span>
                    </b-button>
                </div>
                <div class="my-1 overflow-auto">
                    <b-table
                        class="table-style table-sm bg-lighten rounded overflow-hidden"
                        :items="bill.bookings"
                        :fields="[
                            {
                                key: 'index',
                                label: '#',
                                class: 'table-cell-id text-center',
                                sortable: true,
                            },
                            {
                                key: 'room',
                                label: 'Phòng',
                                formatter: room => `Phòng ${room.name}`,
                            },
                            {
                                key: 'patrons',
                                label: 'Khách',
                                formatter: patrons => `${patrons.length} khách`,
                            },
                            {
                                key: 'checkIn',
                                label: 'Nhận phòng',
                                formatter: checkInFormatter,
                            },
                            {
                                key: 'checkOut',
                                label: 'Trả phòng',
                                formatter: checkOutFormatter,
                            },
                            {
                                key: 'status',
                                label: 'Trạng thái',
                            },
                            {
                                key: 'total',
                                label: 'Chi phí',
                                formatter: toMoney,
                            },
                        ]"
                        @row-clicked="
                            (booking, $index, $event) => {
                                $event.stopPropagation();
                                refs.context_booking.open(
                                    currentEvent || $event,
                                    { booking },
                                );
                                currentEvent = null;
                            }
                        "
                    >
                        <template v-slot:cell(index)="data">
                            {{ data.index + 1 }}
                        </template>
                        <template v-slot:cell(status)="{ value }">
                            <icon-
                                class="mr-1"
                                i="circle-fill"
                                :class="`text-${bookingStatusColorMap[value]}`"
                            />
                            {{ bookingStatusMap[value] }}
                        </template>
                    </b-table>
                </div>
                <div class="mt-1 mb-2 font-weight-medium text-right">
                    Tổng cộng:
                    <span class="text-blue">
                        {{ toMoney(bill.totalPrice) }}
                    </span>
                </div>
                <b-table
                    class="table-style table-sm bg-lighten rounded overflow-hidden"
                    show-empty
                    :items="bill.receipts"
                    :fields="[
                        {
                            key: 'index',
                            label: '#',
                            class: 'table-cell-id text-center',
                            sortable: true,
                        },
                        {
                            key: 'time',
                            label: 'Thời gian',
                            class: 'text-center',
                            formatter: toDateTime,
                        },
                        {
                            key: 'money',
                            label: 'Số tiền',
                            class: 'text-center',
                        },
                        {
                            key: 'bankAccountNumber',
                            label: 'Tài khoản   ',
                            class: 'text-center',
                        },
                    ]"
                >
                    <template v-slot:empty>
                        Chưa có phiếu thu nào được tạo
                    </template>
                    <template v-slot:cell(index)="data">
                        {{ data.index + 1 }}
                    </template>
                </b-table>
                <div class="my-1 font-weight-medium text-right">
                    Đã thanh toán:
                    <span class="text-blue">
                        {{ toMoney(bill.totalReceipts) }}
                    </span>
                </div>
                <div class="my-1 font-weight-medium text-right">
                    Giảm giá:
                    <span class="text-yellow">
                        {{ toMoney(bill.discount) }}
                    </span>
                </div>
                <div class="mt-1 font-weight-medium text-right font-size-6">
                    Chưa thanh toán:
                    <span class="text-red">
                        {{ toMoney(rest) }}
                    </span>
                </div>
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import {
    checkInFormatter,
    checkOutFormatter,
} from './popup-bill-detail.helper';
import { GetBillQuery, GetBill, BookingStatusEnum } from '~/graphql/types';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { getBill, payTheBill } from '~/graphql/documents';
import { toDateTime, toMoney, isMinDate, fromNow } from '~/utils';
import {
    billStatusMap,
    bookingStatusMap,
    bookingStatusColorMap,
} from '~/modules/model';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-booking-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType, {}>(
    PopupMixin,
    DataMixin({
        billStatusMap,
        bookingStatusColorMap,
        BookingStatusEnum,
        bookingStatusMap,
        checkInFormatter,
        checkOutFormatter,
        fromNow,
        getBill,
        isMinDate,
        payTheBill,
        toDateTime,
        toMoney,
    }),
) {
    variables!: GetBill.Variables;

    bill!: GetBill.Bill;
    id = -1;
    rest = 0;
    status: BookingStatusEnum = BookingStatusEnum.Booked;

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    async onResult({ data: { bill } }: ApolloQueryResult<GetBillQuery>) {
        this.bill = bill;
        this.id = bill.id;
        this.rest = bill.totalPrice - bill.totalReceipts - bill.discount;
        this.status = bill.bookings.reduce<BookingStatusEnum>(
            (result, booking, index) => {
                if (index === 0) return booking.status;
                if (booking.status !== result)
                    return BookingStatusEnum.CheckedIn;
                return result;
            },
            BookingStatusEnum.CheckedIn,
        );
    }
}
</script>
