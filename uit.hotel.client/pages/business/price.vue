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
            @result="onResult"
        >
            <b-table
                :items="pricesFiltered"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'effectiveStartDate',
                        label: 'Có hiệu lực từ',
                        tdClass: 'text-center',
                        formatter: toDate,
                    },
                    {
                        key: 'createDate',
                        label: 'Ngày tạo',
                        tdClass: 'text-left',
                        formatter: toDate,
                    },
                    {
                        key: 'hourPrice',
                        label: 'Giá theo giờ',
                        class: 'text-right',
                        formatter: toMoney,
                    },
                    {
                        key: 'nightPrice',
                        label: 'Giá theo đêm',
                        class: 'text-right',
                        formatter: toMoney,
                    },
                    {
                        key: 'dayPrice',
                        label: 'Giá theo ngày',
                        class: 'text-right',
                        formatter: toMoney,
                    },
                    {
                        key: 'roomKind',
                        label: 'Loại phòng',
                        formatter: toNameFormatter,
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
            </b-table>
        </query->
        <context-manage-price- ref="context_price" />
        <popup-price-add- ref="price_add" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { getPrices } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { GetPrices, GetPricesQuery } from '~/graphql/types';
import { toMoney, toDate, toNameFormatter } from '~/utils';

@Component({
    name: 'price-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getPrices, toMoney, toDate, toNameFormatter }),
) {
    head() {
        return {
            title: 'Quản lý giá',
        };
    }

    prices: GetPrices.Prices[] = [];
    pricesFiltered: GetPrices.Prices[] = [];

    async onResult({ data: { prices } }: ApolloQueryResult<GetPricesQuery>) {
        this.prices = prices;
        this.pricesFiltered = prices;
    }
}
</script>
