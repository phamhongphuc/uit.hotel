<template>
    <popup-
        ref="popup"
        v-slot
        title="Chi tiết giá cơ bản"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getPrice"
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
                                id: price.roomKind.id,
                            })
                        "
                    >
                        {{ price.roomKind.name }}
                    </b-link>
                </div>
                <div class="font-weight-medium px-1 my-1">
                    Ngày tạo: {{ toDateTime(price.createDate) }}
                </div>
                <div class="font-weight-medium px-1 my-1">
                    Có hiệu lực từ:
                    {{ toDateTime(price.effectiveStartDate) }}
                </div>
                <hr class="my-2" />
                <div class="font-weight-medium my-1 pl-1">
                    Giá cơ bản:
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
                        :data="priceKeyValue"
                    />
                </div>
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetPrice, GetPriceQuery } from '~/graphql/types';
import { getPrice } from '~/graphql/documents';
import { toMoney, toDateTime, toNameFormatter } from '~/utils';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-room-kind-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType, {}>(
    PopupMixin,
    DataMixin({
        getPrice,
        toDateTime,
        toMoney,
        toNameFormatter,
    }),
) {
    variables!: GetPrice.Variables;
    price!: GetPrice.Price;

    priceKeyValue: { [key: string]: string | number } = {};

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    setPriceKeyValue() {
        const { price } = this;
        this.priceKeyValue = {
            'Phí nhận phòng sớm': price.earlyCheckInFee,
            'Phí trả phòng trễ': price.lateCheckOutFee,
            'Giá theo giờ': price.hourPrice,
            'Giá theo đêm': price.nightPrice,
            'Giá theo ngày': price.dayPrice,
            'Giá theo tuần': price.weekPrice,
            'Giá theo tháng': price.monthPrice,
        };
    }

    onResult({ data }: ApolloQueryResult<GetPriceQuery>) {
        this.price = data.price;
        this.setPriceKeyValue();
    }
}
</script>
