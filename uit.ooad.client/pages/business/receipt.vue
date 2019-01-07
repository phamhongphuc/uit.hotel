<template>
    <div @contextmenu.prevent="tableContext">
        <div class="row">
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.receipt_add.open()"
            >
                <span class="icon mr-1"></span>
                <span>Tạo phiếu thu</span>
            </b-button>
            <b-button
                class="m-2 ml-auto"
                variant="white"
                @click="showInactive = !showInactive"
            >
                <span class="icon mr-1">{{ showInactive ? '' : '' }}</span>
                <span>
                    {{ `Đang ${showInactive ? 'hiện' : 'ẩn'} phiếu thu cũ` }}
                </span>
            </b-button>
        </div>
        <query-
            :query="getReceipts"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { receipts } }"
                class="table-style"
                :items="receiptsFilter(receipts)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                ]"
                @row-clicked="
                    (receipt, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_receipt.open(currentEvent || $event, {
                            receipt,
                            receipts,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <!-- <template slot="receipts" slot-scope="{ value }">
                    {{ toMoney(sumReceipts(value)) }}
                </template>
                <template slot="total" slot-scope="{ value }">
                    {{ toMoney(value) }}
                </template> -->
            </b-table>
        </query->
        <!-- <context-manage-receipt- ref="context_receipt" :refs="$refs" />
        <popup-receipt-add- ref="receipt_add" />
        <popup-receipt-update- ref="receipt_update" /> -->
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getReceipts } from '~/graphql/documents/receipt';
import { mixinData } from '~/components/mixins/mutable';
import { GetReceipts } from '~/graphql/types';
import { toMoney } from '~/utils/dataFormater';

@Component({
    name: 'receipt-',
    mixins: [mixinData({ getReceipts, toMoney })],
})
export default class extends Vue {
    head() {
        return {
            title: 'Danh sách phiếu thu',
        };
    }

    receiptsFilter(receipts: GetReceipts.Receipts[]): GetReceipts.Receipts[] {
        return receipts;
        // if (this.showInactive) return receipts;
        // return receipts.filter(rk => rk.isActive);
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
