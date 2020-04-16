<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="
                    $refs.price_volatility_add.open({ roomKind: { id: -1 } })
                "
            >
                <icon- class="mr-1" i="plus" />
                <span>Thêm giá biến động mới</span>
            </b-button>
        </block-flex->
        <query-
            v-slot
            :query="getPriceVolatilities"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
            @result="onResult"
        >
            <b-table
                class="table-style table-header-line table-cell-middle"
                show-empty
                :items="priceVolatilitiesFiltered"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                    },
                    {
                        key: 'name',
                        label: 'Tên giá biến động',
                    },
                    {
                        key: 'createDate',
                        label: 'Ngày tạo',
                        formatter: toDateTime,
                    },
                    {
                        key: 'effectiveStartDate',
                        label: 'Bắt đầu từ',
                        tdClass: 'text-center',
                        formatter: toDate,
                    },
                    {
                        key: 'effectiveEndDate',
                        label: 'Kết thúc lúc',
                        tdClass: 'text-center',
                        formatter: toDate,
                    },
                    {
                        key: 'roomKind',
                        label: 'Loại phòng',
                        formatter: toNameFormatter,
                    },
                    {
                        key: 'daysOfWeek',
                        label: 'Hiệu lực',
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
                ]"
                @row-clicked="
                    (priceVolatility, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_price_volatility.open(
                            currentEvent || $event,
                            {
                                priceVolatility,
                            },
                        );
                        currentEvent = null;
                    }
                "
            >
                <template v-slot:empty>
                    Chưa có giá biến động nào được tạo
                </template>
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(daysOfWeek)="{ value }">
                    <b-button-group>
                        <b-button
                            v-for="(day, index) in value"
                            :key="`day-${index}`"
                            class="shadow-none text-nowrap"
                            size="sm"
                            :variant="day ? 'green' : 'light'"
                        >
                            {{ daysOfWeekTitles[index] }}
                        </b-button>
                    </b-button-group>
                </template>
            </b-table>
        </query->
        <context-manage-price-volatility- ref="context_price_volatility" />
        <popup-price-volatility-detail- ref="price_volatility_detail" />
        <popup-room-kind-detail- ref="room_kind_detail" />
        <popup-room-kind-update- ref="room_kind_update" />
        <popup-room-detail- ref="room_detail" />
        <popup-room-update- ref="room_update" />
        <popup-price-volatility-add- ref="price_volatility_add" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import {
    DaysOfWeekType,
    toDaysOfWeek,
    daysOfWeekTitles,
} from '~/modules/model';
import { getPriceVolatilities } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import {
    GetPriceVolatilitiesQuery,
    GetPriceVolatilities,
} from '~/graphql/types';
import { toMoney, toDateTime, toDate, toNameFormatter } from '~/utils';

@Component({
    name: 'price-volatility-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({
        daysOfWeekTitles,
        getPriceVolatilities,
        toDateTime,
        toDate,
        toMoney,
        toNameFormatter,
    }),
) {
    head() {
        return {
            title: 'Quản lý giá',
        };
    }

    priceVolatilities: GetPriceVolatilities.PriceVolatilities[] = [];
    priceVolatilitiesFiltered: (GetPriceVolatilities.PriceVolatilities &
        DaysOfWeekType)[] = [];

    async onResult({
        data: { priceVolatilities },
    }: ApolloQueryResult<GetPriceVolatilitiesQuery>) {
        this.priceVolatilities = priceVolatilities;
        this.priceVolatilitiesFiltered = priceVolatilities.map(
            priceVolatility => ({
                ...priceVolatility,
                ...toDaysOfWeek(priceVolatility),
            }),
        );
    }
}
</script>
