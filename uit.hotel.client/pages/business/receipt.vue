<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2 ml-auto"
                variant="white"
                @click="showInactive = !showInactive"
            >
                <icon- :i="showInactive ? 'eye' : 'eye-off'" class="mx-1" />
                <span>
                    {{ `Đang ${showInactive ? 'hiện' : 'ẩn'} phiếu thu cũ` }}
                </span>
            </b-button>
        </block-flex->
        <query-
            :query="getReceipts"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { receipts } }"
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
                class="table-style"
            >
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <template slot="time" slot-scope="{ value }">
                    {{ toDate(value) }}
                </template>
                <template slot="money" slot-scope="{ value }">
                    {{ toMoney(value) }}
                </template>
            </b-table>
        </query->
        <!-- <context-manage-receipt- ref="context_receipt" :refs="$refs" /> -->
        <!-- <popup-receipt-add- ref="receipt_add" />
        <popup-receipt-update- ref="receipt_update" /> -->
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getReceipts } from '~/graphql/documents/receipt';
import { mixinData } from '~/components/mixins/mutable';
import { GetReceipts } from '~/graphql/types';
import { toMoney, toDate } from '~/utils/dataFormater';

@Component({
    name: 'receipt-',
    mixins: [mixinData({ getReceipts, toMoney, toDate })],
})
export default class extends Vue {
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

    showInactive: boolean = false;

    console = console;
}
</script>
