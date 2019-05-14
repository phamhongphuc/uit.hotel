<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="
                    $refs.rate_add.open({
                        roomKind: {
                            id: 1,
                        },
                    })
                "
            >
                <icon- class="mr-1" i="plus" />
                <span>Thêm giá cơ bản mới</span>
            </b-button>
        </block-flex->
        <query-
            :query="getRates"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { rates } }"
                :items="ratesFilter(rates)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'dayRate',
                        label: 'Tên giá cơ bản',
                        tdClass: 'w-100',
                    },
                    {
                        key: 'createDate',
                        label: 'Ngày tạo',
                        tdClass: 'text-nowrap text-left',
                    },
                    {
                        key: 'effectiveStartDate',
                        label: 'Có hiệu lực từ',
                        tdClass: 'text-nowrap text-center',
                    },
                    {
                        key: 'roomKind',
                        label: 'Loại phòng',
                        tdClass: 'text-nowrap text-center',
                    },
                ]"
                class="table-style"
                @row-clicked="
                    (rate, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_rate.open(currentEvent || $event, {
                            rate,
                            rates,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <template slot="createDate" slot-scope="{ value }">
                    {{ toDate(value) }}
                </template>
                <template slot="effectiveStartDate" slot-scope="{ value }">
                    {{ toDate(value) }}
                </template>
                <template slot="dayRate" slot-scope="{ value }">
                    {{ toMoney(value) }}
                </template>
                <template slot="roomKind" slot-scope="{ value }">
                    {{ value.name }}
                </template>
            </b-table>
        </query->
        <context-manage-rate- ref="context_rate" :refs="$refs" />
        <popup-rate-add- ref="rate_add" />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getRates } from '~/graphql/documents';
import { mixinData } from '~/components/mixins';
import { GetRates } from '~/graphql/types';
import { toMoney, toDate } from '~/utils/dataFormater';

@Component({
    name: 'rate-',
    mixins: [mixinData({ getRates, toMoney, toDate })],
})
export default class extends Vue {
    head() {
        return {
            title: 'Quản lý giá',
        };
    }

    ratesFilter(rates: GetRates.Rates[]): GetRates.Rates[] {
        return rates;
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
