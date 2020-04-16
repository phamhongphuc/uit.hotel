<template>
    <div
        class="bill-page"
        @contextmenu.prevent="tableContext"
        @dblclick="tableContext"
    >
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.book.open({ rooms: [] })"
            >
                <icon- class="mr-1" i="edit-3" />
                <span>Đặt phòng</span>
            </b-button>
            <b-checkbox-group
                v-model="billStatus"
                class="m-2 ml-auto rounded box-shadow-inner color-green"
                :options="billStatusOptions"
                button-variant="white"
                name="buttons-1"
                buttons
            />
        </block-flex->
        <query-
            v-slot
            :query="getBills"
            class="row overflow-auto"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
            @result="onResult"
        >
            <div>
                <b-table
                    class="table-style table-header-line table-cell-middle"
                    show-empty
                    :items="billsFiltered"
                    :fields="[
                        {
                            key: 'index',
                            label: '#',
                            class: 'table-cell-id text-center',
                        },
                        {
                            key: 'bookings',
                            label: 'Phòng',
                        },
                        {
                            key: 'status',
                            label: 'Trạng thái thanh toán',
                        },
                        {
                            key: 'patron',
                            label: 'Khách hàng',
                            class: 'text-right',
                            formatter: patron => patron.name,
                        },
                        {
                            key: 'totalPrice',
                            label: 'Tổng cộng',
                            class: 'text-right text-nowrap',
                            formatter: billToMoney,
                        },
                        {
                            key: 'discount',
                            label: 'Giảm giá',
                            tdClass: 'text-right text-nowrap',
                            formatter: discountToMoney,
                        },
                        {
                            key: 'totalReceipts',
                            label: 'Đã thanh toán',
                            tdClass: 'text-right text-nowrap',
                            formatter: billToMoney,
                        },
                        {
                            key: 'rest',
                            label: 'Chưa thanh toán',
                            tdClass: 'text-right text-nowrap',
                            formatter: billToMoney,
                        },
                    ]"
                    @row-clicked="
                        (bill, $index, $event) => {
                            $event.stopPropagation();
                            if (
                                currentEvent !== null &&
                                currentEvent.type === 'dblclick'
                            ) {
                                $refs.bill_detail.open({ id: bill.id });
                                $refs.context_bill.close();
                            } else {
                                $refs.context_bill.open(
                                    currentEvent || $event,
                                    {
                                        bill,
                                    },
                                );
                            }
                            currentEvent = null;
                        }
                    "
                >
                    <template v-slot:empty>
                        Không tìm thấy hóa đơn nào
                    </template>
                    <template v-slot:cell(index)="data">
                        {{ data.index + 1 }}
                    </template>
                    <template v-slot:cell(bookings)="{ value }">
                        <div class="d-flex m-child-1 flex-wrap">
                            <div
                                v-for="booking in value"
                                :key="`booking-${booking.id}`"
                                @dblclick.stop="
                                    refs.booking_detail.open({
                                        id: booking.id,
                                    });
                                    $refs.bill_detail.close();
                                "
                                @contextmenu.prevent.stop="
                                    $refs.context_booking.open($event, {
                                        booking,
                                    })
                                "
                            >
                                <b-button
                                    size="sm"
                                    class="shadow-none text-nowrap"
                                    :variant="
                                        bookingStatusColorMap[booking.status]
                                    "
                                >
                                    Phòng {{ booking.room.name }}
                                </b-button>
                            </div>
                        </div>
                    </template>
                    <template v-slot:cell(status)="{ value, item: { time } }">
                        <icon-
                            i="circle-fill"
                            class="mr-1"
                            :class="`text-${billStatusColorMap[value]}`"
                        />
                        {{ billStatusMap(value, time) }}
                    </template>
                </b-table>
            </div>
        </query->
        <context-manage-bill- ref="context_bill" />
        <context-manage-patron- ref="context_patron" />
        <context-receptionist-booking- ref="context_booking" />
        <context-receptionist-service-detail- ref="context_service_detail" />
        <popup-bill-detail- ref="bill_detail" />
        <popup-bill-update-discount- ref="bill_update_discount" />
        <popup-book- ref="book" />
        <popup-booking-detail- ref="booking_detail" />
        <popup-patron-detail- ref="patron_detail" />
        <popup-patron-select-or-add- ref="patron_select_or_add" />
        <popup-patron-update- ref="patron_update" />
        <popup-receipt-add- ref="receipt_add" />
        <popup-room-select- ref="room_select" />
        <popup-service-detail-add- ref="service_detail_add" />
        <popup-receipt-pay-momo- ref="receipt_pay_momo" />
    </div>
</template>
<script lang="ts">
import { Component, mixins, Watch } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { getBills } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { GetBills, GetBillsQuery, BillStatusEnum } from '~/graphql/types';
import { fromNow, toMoney, isMinDate } from '~/utils';
import {
    billStatusColorMap,
    billStatusMap,
    billStatusOptions,
    bookingStatusColorMap,
} from '~/modules/model';

@Component({
    name: 'bill-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({
        billStatusColorMap,
        billStatusMap,
        billStatusOptions,
        bookingStatusColorMap,
        fromNow,
        getBills,
        isMinDate,
        toMoney,
    }),
) {
    head() {
        return { title: 'Quản lý hóa đơn' };
    }

    billStatus: BillStatusEnum[] = [BillStatusEnum.Pending];

    bills: GetBills.Bills[] = [];
    billsFiltered: (GetBills.Bills & {
        rest: number;
    })[] = [];

    async onResult({ data: { bills } }: ApolloQueryResult<GetBillsQuery>) {
        this.bills = bills;
        this.setBillsFiltered();
    }

    @Watch('billStatus')
    setBillsFiltered() {
        this.billsFiltered = this.bills
            .filter(bill => this.billStatus.includes(bill.status))
            .map(bill => ({
                ...bill,
                rest:
                    bill.status === BillStatusEnum.Cancel
                        ? 0
                        : bill.totalPrice - bill.totalReceipts - bill.discount,
            }));
    }

    billToMoney(value: number, key: string, item: GetBills.Bills) {
        if (item.status === BillStatusEnum.Cancel && value === 0) return '-';
        return toMoney(value);
    }

    discountToMoney(value: number) {
        return value === 0 ? '-' : toMoney(value);
    }

    showInactive = false;
}
</script>
<style lang="scss">
.bill-page {
    &-booking-item {
        font-size: $font-size-sm;
    }
}
</style>
