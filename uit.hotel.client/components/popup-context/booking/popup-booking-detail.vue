<template>
    <popup-
        ref="popup"
        v-slot
        title="Chi tiết đặt phòng"
        class="popup-booking-detail"
        child-class="w-100"
    >
        <query-
            v-slot="{ data: { booking } }"
            :query="getBookingDetails"
            :variables="variables"
            :poll-interval="500"
        >
            <div class="m-3">
                <horizontal-timeline- :booking="booking" />
            </div>

            <div class="d-flex m-2">
                <div class="m-2 flex-1" @contextmenu.prevent="tableContext">
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
                        class="table-style border shadow-sm"
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
            <div class="d-flex m-2">
                <div class="m-2 flex-1">
                    <b-table
                        class="table-style border shadow-sm"
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
                    <div class="text-right mt-2">
                        Tổng cộng:
                        {{ totalServiceDetails(booking.servicesDetails) }}
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
import { GetBookingDetails } from '~/graphql/types';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { getBookingDetails } from '~/graphql/documents';
import { toDate, toMoney, toYear } from '~/utils';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-booking-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ getBookingDetails, toDate, toMoney, toYear }),
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
