<template>
    <div @contextmenu.prevent="tableContext">
        <div class="row">
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.bill_add.open()"
            >
                <span class="icon"></span>
                <span>Đặt phòng</span>
            </b-button>
            <b-button
                class="m-2 ml-auto"
                variant="white"
                @click="showInactive = !showInactive"
            >
                <span class="icon mr-1">{{ showInactive ? '' : '' }}</span>
                <span>
                    {{
                        `Đang ${
                            showInactive ? 'hiện' : 'ẩn'
                        } dịch vụ đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </div>
        <query-
            :query="getBills"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { bills } }"
                class="table-style"
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
                        label: 'Thời gian',
                        tdClass: (value, key, row) => {
                            if (!row.isActive)
                                return 'table-cell-disable w-100';
                            return 'w-100';
                        },
                    },
                    {
                        key: 'receipts',
                        label: 'Đã thanh toán',
                        class: 'text-right',
                    },
                    {
                        key: 'total',
                        label: 'Tổng cộng',
                        class: 'text-right',
                    },
                ]"
                @row-clicked="
                    (bill, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_bill.open(currentEvent || $event, {
                            bill,
                            bills,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <template slot="receipts" slot-scope="{ value }">
                    {{ toMoney(sumReceipts(value)) }}
                </template>
                <template slot="total" slot-scope="{ value }">
                    {{ toMoney(value) }}
                </template>
            </b-table>
        </query->
        <!-- <context-manage-bill- ref="context_bill" :refs="$refs" />
        <popup-bill-add- ref="bill_add" />
        <popup-bill-update- ref="bill_update" /> -->
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getBills } from '~/graphql/documents/bill';
import { mixinData } from '~/components/mixins/mutable';
import { GetBills } from '~/graphql/types';
import { toMoney } from '~/utils/dataFormater';

@Component({
    name: 'bill-',
    mixins: [mixinData({ getBills, toMoney })],
})
export default class extends Vue {
    head() {
        return {
            title: 'Sơ đồ khách sạn',
        };
    }

    billsFilter(bills: GetBills.Bills[]): GetBills.Bills[] {
        return bills;
        // if (this.showInactive) return bills;
        // return bills.filter(rk => rk.isActive);
    }

    sumReceipts(bookings: GetBills.Receipts[]) {
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
