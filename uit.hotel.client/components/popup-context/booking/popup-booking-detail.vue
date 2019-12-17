<template>
    <popup-
        ref="popup"
        v-slot="{ close }"
        title="Chi tiết đặt phòng"
        class="popup-booking-detail"
        child-class="w-100"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getBooking"
            :variables="variables"
            :poll-interval="500"
            @result="onResult"
        >
            <div class="row p-3">
                <div class="col-6">
                    <div
                        v-if="booking.status !== BookingStatusEnum.CheckedOut"
                        class="d-flex m-child-1 mb-1 flex-wrap"
                    >
                        <div class="font-weight-medium py-1 pr-1">
                            <icon-
                                i="circle-fill"
                                class="mx-1"
                                :class="
                                    booking.room.isClean
                                        ? 'text-blue'
                                        : 'text-yellow'
                                "
                            />
                            {{
                                booking.room.isClean
                                    ? 'Phòng đã dọn'
                                    : 'Phòng chưa dọn'
                            }}
                        </div>
                        <b-button-mutate-
                            class="px-2 py-1 ml-auto"
                            variant="lighten"
                            :mutation="setIsCleanRoom"
                            :variables="{
                                id: booking.room.id,
                                isClean: !booking.room.isClean,
                            }"
                        >
                            <icon- i="broom" class="ml-n1 mr-1" />
                            {{
                                booking.room.isClean
                                    ? 'Đánh dấu là chưa dọn'
                                    : 'Đánh dấu là đã dọn'
                            }}
                        </b-button-mutate->
                    </div>
                    <horizontal-timeline- :booking="booking" />
                    <div class="font-weight-medium my-1 pl-1">
                        Danh sách khách hàng:
                    </div>
                    <div class="mb-1 overflow-auto">
                        <b-table
                            class="table-style table-sm bg-lighten rounded overflow-hidden"
                            :items="booking.patrons"
                            :fields="[
                                {
                                    key: 'index',
                                    label: '#',
                                    class: 'table-cell-id text-center',
                                },
                                {
                                    key: 'name',
                                    label: 'Tên',
                                },
                                {
                                    key: 'identification',
                                    label: 'CMND',
                                },
                                {
                                    key: 'phoneNumbers',
                                    label: 'Số điện thoại',
                                    tdClass: 'text-right',
                                },
                                {
                                    key: 'birthdate',
                                    label: 'Năm sinh',
                                    tdClass: 'text-right',
                                    formatter: toYear,
                                },
                            ]"
                            @row-clicked="
                                (patron, $index, $event) => {
                                    $event.stopPropagation();
                                    refs.context_patron.open(
                                        currentEvent || $event,
                                        {
                                            patron,
                                        },
                                    );
                                    currentEvent = null;
                                }
                            "
                        >
                            <template v-slot:cell(index)="data">
                                {{ data.index + 1 }}
                            </template>
                            <template v-slot:cell(phoneNumbers)="{ value }">
                                <a
                                    :href="`tel:${value}`"
                                    class="d-block"
                                    @click.stop
                                >
                                    {{ value }}
                                </a>
                            </template>
                        </b-table>
                    </div>
                </div>
                <!-- Right -->
                <div class="col-6 pl-0 d-flex flex-column">
                    <div
                        class="d-flex m-child-1 mb-1 flex-wrap justify-content-end"
                    >
                        <b-button
                            class="px-2 py-1 mr-auto"
                            variant="lighten"
                            confirm
                            @click="refs.service_detail_add.open({ booking })"
                        >
                            <icon- i="shopping-bag" class="ml-n1 mr-1" />
                            Thêm dịch vụ
                        </b-button>
                        <b-button-mutate-
                            v-if="booking.status == BookingStatusEnum.Booked"
                            class="px-2 py-1"
                            variant="red"
                            confirm
                            clicked-class="text-white"
                            :mutation="cancel"
                            :variables="{ id: booking.id }"
                            @click="close"
                        >
                            <icon- i="x" class="ml-n1 mr-1" />
                            Hủy
                        </b-button-mutate->
                        <b-button-mutate-
                            v-if="booking.status == BookingStatusEnum.Booked"
                            class="px-2 py-1"
                            variant="green"
                            confirm
                            clicked-class="text-white"
                            :mutation="checkIn"
                            :variables="{ id: booking.id }"
                        >
                            <icon- i="corner-down-right" class="ml-n1 mr-1" />
                            Nhận phòng
                        </b-button-mutate->
                        <b-button-mutate-
                            v-if="booking.status == BookingStatusEnum.CheckedIn"
                            class="px-2 py-1"
                            variant="blue"
                            confirm
                            clicked-class="text-white"
                            :mutation="checkOut"
                            :variables="{ id: booking.id }"
                        >
                            <icon- i="corner-right-up" class="ml-n1 mr-1" />
                            Trả phòng
                        </b-button-mutate->
                    </div>
                    <div class="font-weight-medium my-1 pl-1">
                        Bảng tính giá:
                    </div>
                    <div class="mb-1 overflow-auto">
                        <b-table
                            class="table-style table-sm bg-lighten rounded overflow-hidden"
                            show-empty
                            :items="priceItems"
                            :fields="[
                                {
                                    key: 'index',
                                    label: '#',
                                    class: 'table-cell-id text-center',
                                },
                                {
                                    key: 'name',
                                    label: 'Loại giá',
                                },
                                {
                                    key: 'number',
                                    label: 'Thời gian',
                                    class: 'text-right',
                                },
                                {
                                    key: 'unitPrice',
                                    label: 'Đơn giá',
                                    class: 'text-right',
                                    formatter: toMoney,
                                },
                                {
                                    key: 'total',
                                    label: 'Thành tiền',
                                    class: 'text-right',
                                    formatter: toMoney,
                                },
                            ]"
                        >
                            <template v-slot:cell(index)="data">
                                {{ data.index + 1 }}
                            </template>
                            <template v-slot:cell(name)="{ value, item }">
                                <div v-b-tooltip.window.left="item.tooltip">
                                    <icon-
                                        i="circle-fill"
                                        class="mr-1"
                                        :class="`text-${item.kind}`"
                                    />
                                    {{ value }}
                                </div>
                            </template>
                        </b-table>
                    </div>
                    <div class="my-1 font-weight-medium text-right">
                        Tổng số tiền thuê phòng:
                        {{ toMoney(booking.totalPrice) }}
                    </div>
                    <div class="font-weight-medium my-1 pl-1">
                        Dịch vụ sử dụng:
                    </div>
                    <div class="my-1 overflow-auto">
                        <b-table
                            class="table-style table-sm bg-lighten rounded overflow-hidden"
                            show-empty
                            :items="booking.servicesDetails"
                            :fields="[
                                {
                                    key: 'index',
                                    label: '#',
                                    class: 'table-cell-id text-center',
                                },
                                {
                                    key: 'service',
                                    label: 'Tên dịch vụ',
                                    tdClass: 'text-nowrap text-center',
                                    formatter: toNameFormatter,
                                },
                                {
                                    key: 'number',
                                    label: 'Số lượng',
                                    thClass: 'text-right',
                                    tdClass: 'text-nowrap text-right',
                                },
                                {
                                    key: 'unitPrice',
                                    label: 'Đơn giá',
                                    thClass: 'text-right',
                                    tdClass: 'text-nowrap text-right',
                                    formatter: (
                                        value,
                                        key,
                                        { service: { unitPrice, unit } },
                                    ) => `${toMoney(unitPrice)} / ${unit}`,
                                },
                                {
                                    key: 'total',
                                    label: 'Thành tiền',
                                    thClass: 'text-right',
                                    tdClass: 'text-nowrap text-right',
                                    formatter: (
                                        value,
                                        key,
                                        { service: { unitPrice }, number },
                                    ) => toMoney(unitPrice * number),
                                },
                            ]"
                            @row-clicked="
                                (servicesDetail, $index, $event) => {
                                    $event.stopPropagation();
                                    refs.context_service_detail.open(
                                        currentEvent || $event,
                                        {
                                            servicesDetail,
                                        },
                                    );
                                    currentEvent = null;
                                }
                            "
                        >
                            <template v-slot:empty>
                                Phòng chưa sử dụng dịch vụ nào
                            </template>
                            <template v-slot:cell(index)="data">
                                {{ data.index + 1 }}
                            </template>
                        </b-table>
                    </div>
                    <div class="my-1 font-weight-medium text-right">
                        Tổng số tiền dịch vụ:
                        {{ toMoney(booking.totalServicesDetails) }}
                    </div>
                    <div class="mt-1 font-weight-medium text-right">
                        Tổng cộng:
                        <span class="text-main">
                            {{ toMoney(booking.total) }}
                        </span>
                    </div>
                </div>
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import {
    getPriceItems,
    PriceItemTableRender,
} from './popup-booking-detail.helper';
import {
    BookingStatusEnum,
    GetBooking,
    GetBookingQuery,
} from '~/graphql/types';
import { PopupMixin, DataMixin } from '~/components/mixins';
import {
    cancel,
    checkIn,
    checkOut,
    getBooking,
    setIsCleanRoom,
} from '~/graphql/documents';
import { toDateTime, toMoney, toYear, toNameFormatter } from '~/utils';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-booking-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType, {}>(
    PopupMixin,
    DataMixin({
        BookingStatusEnum,
        cancel,
        checkIn,
        checkOut,
        getBooking,
        setIsCleanRoom,
        toDateTime,
        toMoney,
        toNameFormatter,
        toYear,
    }),
) {
    variables!: GetBooking.Variables;
    booking!: GetBooking.Booking;

    priceItems: PriceItemTableRender[] = [];

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    async onResult({ data: { booking } }: ApolloQueryResult<GetBookingQuery>) {
        this.booking = booking;
        this.priceItems = getPriceItems(booking);
    }
}
</script>
<style lang="scss">
.popup-booking-detail {
    .child-float-right {
        font-weight: 600;
        > div > span {
            float: right;
            margin-left: 1rem;
        }
    }
}
</style>
