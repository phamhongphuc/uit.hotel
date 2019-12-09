<template>
    <popup-
        ref="popup"
        v-slot="{ close }"
        title="Chi tiết đặt phòng"
        class="popup-booking-detail"
        child-class="w-100"
    >
        <query-
            v-slot
            :query="getBookingDetails"
            :variables="variables"
            :poll-interval="500"
            @result="onResult"
        >
            <div class="row p-3">
                <div class="col-7">
                    <horizontal-timeline- :booking="booking" class="mb-3" />
                    <div
                        class="my-2 overflow-auto"
                        @contextmenu.prevent="tableContext"
                    >
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
                                    label: 'Số lượng',
                                    tdClass: 'text-right',
                                },
                                {
                                    key: 'unitPrice',
                                    label: 'Đơn giá',
                                    tdClass: 'text-right',
                                },
                                {
                                    key: 'total',
                                    label: 'Thành tiền',
                                    tdClass: 'text-right',
                                },
                            ]"
                        >
                            <template v-slot:cell(index)="data">
                                {{ data.index + 1 }}
                            </template>
                            <template v-slot:cell(unitPrice)="{ value }">
                                {{ toMoney(value) }}
                            </template>
                            <template v-slot:cell(total)="{ value }">
                                {{ toMoney(value) }}
                            </template>
                        </b-table>
                    </div>
                    <div class="my-2 font-weight-medium text-right">
                        Tổng số tiền thuê phòng:
                        {{ toMoney(booking.totalPrice) }}
                    </div>
                    <div
                        class="my-2 overflow-auto"
                        @contextmenu.prevent="tableContext"
                    >
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
                                    key: 'name',
                                    label: 'Tên dịch vụ',
                                    tdClass: 'text-nowrap text-center',
                                },
                                {
                                    key: 'number',
                                    label: 'Số lượng',
                                    tdClass: 'text-nowrap text-right',
                                },
                                {
                                    key: 'unitPrice',
                                    label: 'Đơn giá',
                                    tdClass: 'text-nowrap text-right',
                                },
                                {
                                    key: 'total',
                                    label: 'Thành tiền',
                                    tdClass: 'text-nowrap text-right',
                                },
                            ]"
                            @row-clicked="
                                (service, $index, $event) => {
                                    $event.stopPropagation();
                                    $refs.context_service.open(
                                        currentEvent || $event,
                                        {
                                            service,
                                            services,
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
                            <template v-slot:cell(name)="{ item }">
                                {{ item.service.name }}
                            </template>
                            <template
                                v-slot:cell(unitPrice)="{
                                    item: { service: { unitPrice, unit } },
                                }"
                            >
                                {{ toMoney(unitPrice) }} / {{ unit }}
                            </template>
                            <template
                                v-slot:cell(total)="{
                                    item: { service: { unitPrice }, number },
                                }"
                            >
                                {{ toMoney(unitPrice * number) }}
                            </template>
                        </b-table>
                    </div>
                    <div class="my-2 font-weight-medium text-right">
                        Tổng số tiền dịch vụ:
                        {{ toMoney(booking.totalServicesDetails) }}
                    </div>
                    <div class="mt-2 font-weight-medium text-right">
                        Tổng cộng:
                        {{ toMoney(booking.total) }}
                    </div>
                </div>
                <!-- Right -->
                <div class="col-5 pl-0 d-flex flex-column">
                    <div
                        class="d-flex m-child-1 flex-wrap justify-content-start"
                    >
                        <b-button-mutate-
                            v-if="booking.status == BookingStatusEnum.Booked"
                            class="px-2 py-1"
                            variant="lighten"
                            confirm
                            :mutation="checkIn"
                            :variables="{ id: booking.id }"
                        >
                            <icon- i="corner-down-right" class="ml-n1 mr-1" />
                            Nhận phòng
                        </b-button-mutate->
                        <b-button-mutate-
                            v-if="booking.status == BookingStatusEnum.Booked"
                            class="px-2 py-1"
                            variant="lighten"
                            confirm
                            :mutation="cancel"
                            :variables="{ id: booking.id }"
                            @click="close"
                        >
                            <icon- i="x" class="ml-n1 mr-1" />
                            Hủy
                        </b-button-mutate->
                        <b-button-mutate-
                            v-if="booking.status == BookingStatusEnum.CheckedIn"
                            class="px-2 py-1"
                            variant="lighten"
                            confirm
                            :mutation="checkOut"
                            :variables="{ id: booking.id }"
                        >
                            <icon- i="corner-right-up" class="ml-n1 mr-1" />
                            Trả phòng
                        </b-button-mutate->
                    </div>
                    <div class="mt-2 flex-1 overflow-auto">
                        <div class="font-weight-medium mb-1">
                            Danh sách khách hàng:
                        </div>
                        <b-table
                            class="table-style table-sm bg-lighten rounded overflow-hidden"
                            :items="booking.patrons"
                            :fields="[
                                {
                                    key: 'index',
                                    label: '#',
                                    class: 'table-cell-id text-center',
                                    sortable: true,
                                },
                                {
                                    key: 'name',
                                    label: 'Tên',
                                    tdClass: 'w-100',
                                },
                                {
                                    key: 'identification',
                                    label: 'CMND',
                                    tdClass: 'w-100',
                                },
                                {
                                    key: 'phoneNumbers',
                                    label: 'Số điện thoại',
                                    tdClass: 'text-nowrap text-right',
                                },
                                {
                                    key: 'birthdate',
                                    label: 'Năm sinh',
                                    tdClass: 'text-nowrap text-right',
                                },
                            ]"
                            @row-clicked="
                                (patron, $index, $event) => {
                                    $event.stopPropagation();
                                    $refs.context_patron.open(
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
                            <template v-slot:cell(birthdate)="{ value }">
                                {{ toYear(value) }}
                            </template>
                        </b-table>
                    </div>
                </div>
            </div>
        </query->
        <context-manage-patron- ref="context_patron" :refs="$refs" />
        <popup-patron-update- ref="patron_update" />
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import moment, { duration } from 'moment';
import {
    priceItemGetAmount,
    priceItemKindMap,
    priceItemGetUnitPrice,
} from '~/modules/model';
import {
    GetBookingDetails,
    BookingStatusEnum,
    GetBookingDetailsQuery,
} from '~/graphql/types';
import { PopupMixin, DataMixin } from '~/components/mixins';
import {
    getBookingDetails,
    checkIn,
    checkOut,
    cancel,
} from '~/graphql/documents';
import { toDate, toMoney, toYear, getDate } from '~/utils';

type PopupMixinType = PopupMixin<{ id: number }, null>;

interface PriceItemRender {
    name: string;
    number: string;
    unitPrice: number;
    total: number;
}

@Component({
    name: 'popup-booking-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({
        BookingStatusEnum,
        getBookingDetails,
        checkIn,
        checkOut,
        cancel,
        toDate,
        toMoney,
        toYear,
    }),
) {
    variables!: GetBookingDetails.Variables;
    booking!: GetBookingDetails.Booking;

    currentEvent: MouseEvent | null = null;
    priceItems: PriceItemRender[] = [];

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    async onResult({ data }: ApolloQueryResult<GetBookingDetailsQuery>) {
        this.booking = data.booking;

        this.priceItems = [
            ...this.booking.priceItems.map(p => ({
                name: `Thuê theo ${priceItemKindMap[p.kind]}`,
                number: `${priceItemGetAmount(p)} ${priceItemKindMap[p.kind]}`,
                unitPrice: priceItemGetUnitPrice(this.booking, p),
                total: p.value,
            })),
            ...(this.booking.earlyCheckInFee === 0
                ? []
                : [
                      {
                          name: 'Phí nhận phòng sớm',
                          number: `${this.earlyCheckInHour} giờ`,
                          unitPrice: this.booking.price.earlyCheckInFee,
                          total: this.booking.earlyCheckInFee,
                      },
                  ]),
            ...(this.booking.lateCheckOutFee === 0
                ? []
                : [
                      {
                          name: 'Phí trả phòng trễ',
                          number: `${this.lateCheckOutHour} giờ`,
                          unitPrice: this.booking.price.lateCheckOutFee,
                          total: this.booking.lateCheckOutFee,
                      },
                  ]),
        ];
    }

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');
        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }

    get earlyCheckInHour() {
        const { booking, left } = this;
        return parseFloat(
            duration(moment(booking.baseNightCheckInTime).diff(left))
                .asHours()
                .toFixed(2),
        );
    }

    get lateCheckOutHour() {
        const { booking, right } = this;
        return parseFloat(
            duration(moment(right).diff(booking.baseDayCheckOutTime))
                .asHours()
                .toFixed(2),
        );
    }

    get left() {
        return getDate(
            this.booking.realCheckInTime,
            this.booking.bookCheckInTime,
        );
    }

    get right() {
        return getDate(
            this.booking.realCheckOutTime,
            this.booking.bookCheckOutTime,
        );
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
