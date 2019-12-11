<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="
                    $refs.price_add.open({
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
            v-slot="{ data: { prices } }"
            :query="getPrices"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                :items="pricesFilter(prices)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'dayPrice',
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
                class="table-style table-header-line"
                @row-clicked="
                    (price, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_price.open(currentEvent || $event, {
                            price,
                            prices,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(createDate)="{ value }">
                    {{ toDate(value) }}
                </template>
                <template v-slot:cell(effectiveStartDate)="{ value }">
                    {{ toDate(value) }}
                </template>
                <template v-slot:cell(dayPrice)="{ value }">
                    {{ toMoney(value) }}
                </template>
                <template v-slot:cell(roomKind)="{ value }">
                    {{ value.name }}
                </template>
            </b-table>
            <div v-if="pricesFilter(prices).length === 0" class="table-after">
                Không tìm thấy giá nào
            </div>
        </query->
        <context-manage-price- ref="context_price" />
        <popup-price-add- ref="price_add" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getPrices } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { GetPrices } from '~/graphql/types';
import { toMoney, toDate } from '~/utils';

@Component({
    name: 'price-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getPrices, toMoney, toDate }),
) {
    head() {
        return {
            title: 'Quản lý giá',
        };
    }

    pricesFilter(prices: GetPrices.Prices[]): GetPrices.Prices[] {
        return prices;
    }
}
</script>
