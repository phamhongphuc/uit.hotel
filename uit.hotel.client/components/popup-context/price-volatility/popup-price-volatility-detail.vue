<template>
    <popup-
        ref="popup"
        v-slot
        title="Chi tiết giá biến động"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getPriceVolatility"
            :variables="variables"
            @result="onResult"
        >
            <div class="p-3">
                <div class="font-weight-medium mt-n1 mb-1 px-1">
                    Loại phòng:
                    <b-link
                        class="text-main"
                        href="#"
                        @click="
                            refs.room_kind_detail.open({
                                id: priceVolatility.roomKind.id,
                            })
                        "
                    >
                        {{ priceVolatility.roomKind.name }}
                    </b-link>
                </div>
                <div class="font-weight-medium px-1 my-1">
                    Ngày tạo: {{ toDateTime(priceVolatility.createDate) }}
                </div>
                <div class="font-weight-medium px-1 my-1">
                    Bát đầu từ:
                    {{ toDateTime(priceVolatility.effectiveStartDate) }}
                </div>
                <div class="font-weight-medium px-1 my-1">
                    Kết thúc lúc:
                    {{ toDateTime(priceVolatility.effectiveEndDate) }}
                </div>
                <div class="font-weight-medium px-1 my-1">
                    Ngày có hiệu lực:
                    <b-button-group class="ml-1">
                        <b-button
                            v-for="(day, index) in daysOfWeek.daysOfWeek"
                            :key="`day-${index}`"
                            class="shadow-none text-nowrap"
                            size="sm"
                            :variant="day ? 'green' : 'light'"
                        >
                            {{ daysOfWeekTitles[index] }}
                        </b-button>
                    </b-button-group>
                </div>
                <hr class="my-2" />
                <div class="font-weight-medium my-1 pl-1">
                    Giá tăng thêm:
                </div>
                <div class="overflow-auto">
                    <key-value-
                        class="table-style bg-lighten rounded text-nowrap"
                        :key-field="{
                            label: 'Loại giá/phí',
                        }"
                        :value-field="{
                            label: 'Số tiền',
                            formatter: toMoney,
                            tdClass: 'text-right',
                        }"
                        :data="priceVolatilityKeyValue"
                    />
                </div>
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import {
    daysOfWeekTitles,
    toDaysOfWeek,
    DaysOfWeekType,
} from '~/modules/model';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetPriceVolatility, GetPriceVolatilityQuery } from '~/graphql/types';
import { getPriceVolatility } from '~/graphql/documents';
import { toMoney, toDateTime, toNameFormatter } from '~/utils';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-room-kind-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType, {}>(
    PopupMixin,
    DataMixin({
        getPriceVolatility,
        toDateTime,
        toMoney,
        toNameFormatter,
        toDaysOfWeek,
        daysOfWeekTitles,
    }),
) {
    variables!: GetPriceVolatility.Variables;
    priceVolatility!: GetPriceVolatility.PriceVolatility;
    daysOfWeek!: DaysOfWeekType;
    priceVolatilityKeyValue: { [key: string]: string | number } = {};

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    onResult({
        data: { priceVolatility },
    }: ApolloQueryResult<GetPriceVolatilityQuery>) {
        this.priceVolatility = priceVolatility;
        this.priceVolatilityKeyValue = {
            'Giá theo giờ': priceVolatility.hourPrice,
            'Giá theo đêm': priceVolatility.nightPrice,
            'Giá theo ngày': priceVolatility.dayPrice,
        };
        this.daysOfWeek = toDaysOfWeek(priceVolatility);
    }
}
</script>
