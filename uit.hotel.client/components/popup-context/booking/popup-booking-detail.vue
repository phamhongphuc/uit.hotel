<template>
    <popup-
        ref="popup"
        v-slot="{ close }"
        title="Chi tiết đặt phòng"
        class="popup-booking-detail"
        child-class="w-100"
    >
        <query-
            v-slot="{ data: { booking, booking: { id } } }"
            :query="getBookingDetails"
            :variables="variables"
            :poll-interval="500"
        >
            <div class="row p-3">
                <div class="col-8">
                    <horizontal-timeline- :booking="booking" />
                </div>
                <div class="col-4 pl-0">
                    <div class="d-flex m-child-1 flex-wrap justify-content-end">
                        <b-button-mutate-
                            v-if="booking.status == BookingStatusEnum.Booked"
                            class="px-2"
                            variant="lighten"
                            :mutation="checkIn"
                            :variables="{ id }"
                        >
                            <icon- i="corner-down-right" class="ml-n1 mr-1" />
                            Nhận phòng
                        </b-button-mutate->
                        <b-button-mutate-
                            v-if="booking.status == BookingStatusEnum.Booked"
                            class="px-2"
                            variant="lighten"
                            :mutation="cancel"
                            :variables="{ id }"
                            @click="close"
                        >
                            <icon- i="x" class="ml-n1 mr-1" />
                            Hủy
                        </b-button-mutate->
                        <b-button-mutate-
                            v-if="booking.status == BookingStatusEnum.CheckedIn"
                            class="px-2"
                            variant="lighten"
                            :mutation="checkOut"
                            :variables="{ id }"
                        >
                            <icon- i="corner-right-up" class="ml-n1 mr-1" />
                            Trả phòng
                        </b-button-mutate->
                    </div>
                    <div class="font-weight-medium mt-2">
                        Trạng thái:
                    </div>
                </div>
            </div>
            <div class="row px-3 pb-3 pt-0">
                <div class="col-7" @contextmenu.prevent="tableContext">
                    <b-table
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
                                label: 'Tên khách hàng',
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
                        class="table-style table-sm border shadow-sm"
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
                <div class="col-5 pl-0">
                    <div class="flex-1">
                        <b-table
                            class="table-style table-sm border shadow-sm"
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
                        <!-- <div class="text-right mt-2">
                            Tổng cộng:
                            {{ totalServiceDetails(booking.servicesDetails) }}
                        </div> -->
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
import { GetBookingDetails, BookingStatusEnum } from '~/graphql/types';
import { PopupMixin, DataMixin } from '~/components/mixins';
import {
    getBookingDetails,
    checkIn,
    checkOut,
    cancel,
} from '~/graphql/documents';
import { toDate, toMoney, toYear } from '~/utils';

type PopupMixinType = PopupMixin<{ id: number }, null>;

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

    currentEvent: MouseEvent | null = null;

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    totalServiceDetails(servicesDetails: GetBookingDetails.ServicesDetails[]) {
        return toMoney(
            servicesDetails.reduce(
                (sum, { service: { unitPrice }, number }) =>
                    sum + number * unitPrice,
                0,
            ),
        );
    }

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');
        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
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
