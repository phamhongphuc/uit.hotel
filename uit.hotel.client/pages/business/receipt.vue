<template>
    <div @contextmenu.prevent="tableContext">
        <query-
            v-slot="{ data: { receipts } }"
            :query="getReceipts"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                :items="receiptsFilter(receipts)"
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
                class="table-style table-header-line"
            >
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(time)="{ value }">
                    {{ toDate(value) }}
                </template>
                <template v-slot:cell(money)="{ value }">
                    {{ toMoney(value) }}
                </template>
            </b-table>
            <div
                v-if="receiptsFilter(receipts).length === 0"
                class="table-after"
            >
                Không tìm thấy phiếu thu nào
            </div>
        </query->
        <!-- <context-manage-receipt- ref="context_receipt" :refs="$refs" /> -->
        <!-- <popup-receipt-add- ref="receipt_add" />
        <popup-receipt-update- ref="receipt_update" /> -->
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getReceipts } from '~/graphql/documents';
import { DataMixin } from '~/components/mixins';
import { GetReceipts } from '~/graphql/types';
import { toMoney, toDate } from '~/utils';

@Component({
    name: 'receipt-',
})
export default class extends mixins(
    DataMixin({ getReceipts, toMoney, toDate }),
) {
    head() {
        return {
            title: 'Danh sách phiếu thu',
        };
    }

    receiptsFilter(receipts: GetReceipts.Receipts[]): GetReceipts.Receipts[] {
        return receipts;
    }

    sumReceipts(bookings: GetReceipts.Receipts[]) {
        return bookings.map(r => r.money).reduce((a, b) => a + b, 0);
    }

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');

        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }

    currentEvent: MouseEvent | null = null;
}
</script>
