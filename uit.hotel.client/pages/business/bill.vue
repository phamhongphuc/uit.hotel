<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.book.open({ rooms: [] })"
            >
                <icon- class="mr-1" i="plus" />
                <span>Đặt phòng</span>
            </b-button>
            <b-button
                class="m-2 ml-auto"
                variant="white"
                @click="showInactive = !showInactive"
            >
                <icon- :i="showInactive ? 'eye' : 'eye-off'" class="mx-1" />
                <span>
                    {{
                        `Đang ${
                            showInactive ? 'hiện' : 'ẩn'
                        } dịch vụ đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </block-flex->
        <query-
            v-slot="{ data: { bills } }"
            :query="getBills"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                :items="billsFilter(bills)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'time',
                        label: 'Thời gian chốt hóa đơn',
                        tdClass: 'w-100',
                    },
                    {
                        key: 'bookings',
                        label: 'Phòng',
                        class: 'text-right text-nowrap',
                    },
                    {
                        key: 'receipts',
                        label: 'Số lần',
                        class: 'text-right',
                    },
                    {
                        key: 'totalReceipts',
                        label: 'Đã thanh toán',
                        class: 'text-right',
                    },
                    {
                        key: 'totalPrice',
                        label: 'Tổng cộng',
                        class: 'text-right',
                    },
                ]"
                class="table-style table-header-line"
                @row-clicked="
                    (bill, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_bill.open(currentEvent || $event, {
                            bill,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(time)="{ value }">
                    {{
                        moment(value).year() === 1
                            ? 'Chưa chốt hóa đơn'
                            : toDate(value)
                    }}
                </template>
                <template v-slot:cell(bookings)="{ value }">
                    {{ value.length }} phòng
                </template>
                <template v-slot:cell(receipts)="{ value }">
                    {{ value.length }} lần
                </template>
                <template v-slot:cell(totalReceipts)="{ item }">
                    {{ toMoney(sumReceipts(item.receipts)) }}
                </template>
                <template v-slot:cell(totalPrice)="{ value }">
                    {{ toMoney(value) }}
                </template>
            </b-table>
            <div v-if="billsFilter(bills).length === 0" class="table-after">
                Không tìm thấy hóa đơn nào
            </div>
        </query->
        <context-manage-bill- ref="context_bill" />
        <context-manage-patron- ref="context_patron" />
        <context-receptionist-booking- ref="context_receptionist_booking" />
        <context-receptionist-service-detail- ref="context_service_detail" />
        <popup-bill-detail- ref="bill_detail" />
        <popup-book- ref="book" />
        <popup-booking-detail- ref="booking_detail" />
        <popup-patron-select-or-add- ref="patron_select_or_add" />
        <popup-patron-update- ref="patron_update" />
        <popup-receipt-add- ref="receipt_add" />
        <popup-room-select- ref="room_select" />
        <popup-service-detail-add- ref="service_detail_add" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import moment from 'moment';
import { getBills } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { GetBills } from '~/graphql/types';
import { toMoney, toDate } from '~/utils';

@Component({
    name: 'bill-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getBills, toMoney, toDate, moment }),
) {
    head() {
        return {
            title: 'Quản lý hóa đơn',
        };
    }

    billsFilter(bills: GetBills.Bills[]): GetBills.Bills[] {
        return bills;
    }

    sumReceipts(receipt: GetBills.Receipts[]) {
        return receipt.map(r => r.money).reduce((a, b) => a + b, 0);
    }

    showInactive = false;
}
</script>
