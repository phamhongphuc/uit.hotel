<template>
    <popup-
        ref="popup"
        v-slot
        title="Chi tiết loại phòng"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getRoomKind"
            :variables="variables"
            @result="onResult"
        >
            <div class="p-3">
                <div class="d-flex m-child-1 flex-wrap">
                    <div class="p-1 font-weight-medium mr-auto">
                        Trạng thái:
                        <span>
                            <icon-
                                i="circle-fill"
                                class="m-1"
                                :class="
                                    `text-${roomKindColorMap(
                                        roomKind.isActive,
                                    )}`
                                "
                            />
                            {{ roomKindTitleMap(roomKind.isActive) }}
                        </span>
                    </div>
                    <b-button-mutate-
                        variant="lighten"
                        :mutation="setIsActiveRoomKind"
                        :variables="{
                            id: roomKind.id,
                            isActive: !roomKind.isActive,
                        }"
                    >
                        <icon-
                            :i="roomKind.isActive ? 'x' : 'chevrons-up'"
                            class="ml-n1 mr-1"
                        />
                        {{
                            roomKind.isActive
                                ? 'Vô hiệu hóa loại phòng'
                                : 'Kích hoạt lại loại phòng'
                        }}
                    </b-button-mutate->
                    <b-button
                        size="sm"
                        variant="lighten"
                        @click="refs.price_add.open({ roomKind })"
                    >
                        <icon- class="mr-1" i="receipt" />
                        <span>Thêm giá cơ bản</span>
                    </b-button>
                    <b-button
                        size="sm"
                        variant="lighten"
                        @click="refs.price_volatility_add.open({ roomKind })"
                    >
                        <icon- class="mr-1" i="receipt" />
                        <span>Thêm giá biến động</span>
                    </b-button>
                </div>
                <div class="row mt-2">
                    <div class="col-8 pr-0">
                        <div class="font-weight-medium my-1 pl-1">
                            Tối đa: {{ roomKind.amountOfPeople }} người,
                            {{ roomKind.numberOfBeds }} giường
                        </div>
                        <div class="font-weight-medium my-1 pl-1">
                            Danh sách phòng:
                        </div>
                        <div
                            v-if="roomKind.rooms.length !== 0"
                            class="d-flex m-child-1 flex-wrap"
                        >
                            <b-button
                                v-for="room in roomKind.rooms"
                                :key="`room-${room.id}`"
                                :variant="room.isActive ? 'green' : 'light'"
                                size="sm"
                                class="shadow-none text-nowrap"
                                @contextmenu.prevent="
                                    refs.context_room.open($event, {
                                        room: {
                                            ...room,
                                            roomKind: { id: roomKind.id },
                                        },
                                        floor: { id: room.floor.id },
                                    })
                                "
                            >
                                Phòng {{ room.name }}
                            </b-button>
                        </div>
                        <div v-else class="px-1">
                            <em>
                                Chưa có phòng nào trong danh sách.
                            </em>
                        </div>
                        <div class="font-weight-medium my-1 pl-1">
                            Danh sách giá:
                        </div>
                        <div class="my-1 overflow-auto">
                            <b-table
                                class="table-style table-sm bg-lighten rounded overflow-hidden"
                                :items="prices"
                                :fields="[
                                    {
                                        key: 'name',
                                        label: 'Loại giá',
                                        class: '',
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
                            />
                        </div>
                    </div>
                    <div class="col-4">
                        <div class="font-weight-medium my-1 pl-1">
                            Tổng giá đang áp dụng:
                        </div>
                        <key-value-
                            class="table-style bg-lighten rounded"
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
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { roomKindColorMap, roomKindTitleMap } from '~/modules/model';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetRoomKind, GetRoomKindQuery } from '~/graphql/types';
import { getRoomKind, setIsActiveRoomKind } from '~/graphql/documents';
import { toMoney, toDateTime, toNameFormatter } from '~/utils';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-room-kind-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType, {}>(
    PopupMixin,
    DataMixin({
        getRoomKind,
        roomKindColorMap,
        roomKindTitleMap,
        setIsActiveRoomKind,
        toDateTime,
        toMoney,
        toNameFormatter,
    }),
) {
    variables!: GetRoomKind.Variables;
    roomKind!: GetRoomKind.RoomKind;

    priceKeyValue: { [key: string]: string | number } = {};
    priceSummary = {
        hourPrice: 0,
        nightPrice: 0,
        dayPrice: 0,
    };

    prices: {
        name: string;
        hourPrice: number;
        nightPrice: number;
        dayPrice: number;
        [key: string]: any;
    }[] = [];

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    setPriceSummary() {
        const {
            currentPrice: price,
            currentPriceVolatilities: priceVolatilities,
        } = this.roomKind;
        this.priceSummary = priceVolatilities.reduce(
            (out, p) => ({
                hourPrice: out.hourPrice + p.hourPrice,
                nightPrice: out.nightPrice + p.nightPrice,
                dayPrice: out.dayPrice + p.dayPrice,
            }),
            {
                hourPrice: price.hourPrice,
                nightPrice: price.nightPrice,
                dayPrice: price.dayPrice,
            },
        );
    }

    setPriceKeyValue() {
        const {
            priceSummary,
            roomKind: { currentPrice: price },
        } = this;
        this.priceKeyValue = {
            'Phí nhận phòng sớm': price.earlyCheckInFee,
            'Phí trả phòng trễ': price.lateCheckOutFee,
            'Giá theo giờ': priceSummary.hourPrice,
            'Giá theo đêm': priceSummary.nightPrice,
            'Giá theo ngày': priceSummary.dayPrice,
            'Giá theo tuần': price.weekPrice,
            'Giá theo tháng': price.monthPrice,
        };
    }

    setPrice() {
        const {
            currentPrice: price,
            currentPriceVolatilities: priceVolatilities,
        } = this.roomKind;
        const { priceSummary } = this;
        this.prices = [
            {
                name: 'Giá cơ bản',
                hourPrice: price.hourPrice,
                nightPrice: price.nightPrice,
                dayPrice: price.dayPrice,
            },
            ...priceVolatilities.map(p => ({
                name: p.name,
                hourPrice: p.hourPrice,
                nightPrice: p.nightPrice,
                dayPrice: p.dayPrice,
            })),
            {
                name: 'Tổng cộng',
                hourPrice: priceSummary.hourPrice,
                nightPrice: priceSummary.nightPrice,
                dayPrice: priceSummary.dayPrice,
                _rowVariant: 'light',
            },
        ];
    }

    onResult({ data }: ApolloQueryResult<GetRoomKindQuery>) {
        this.roomKind = data.roomKind;
        this.setPriceSummary();
        this.setPriceKeyValue();
        this.setPrice();
    }
}
</script>
