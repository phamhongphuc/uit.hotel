<template>
    <popup- ref="popup" title="Chi tiết đặt phòng" class="popup-booking-detail">
        <query-
            v-slot="{
                data: {
                    booking,
                    booking: {
                        room,
                    },
                },
            }"
            :query="getBookingDetails"
            :variables="variables"
            :poll-interval="0"
        >
            <div class="d-flex m-2">
                <div
                    class="flex-fill border shadow-sm p-3 m-2 child-float-right"
                >
                    <div>
                        Tầng:
                        <span>{{ room.floor.name }}</span>
                    </div>
                    <div>
                        Phòng:
                        <span>{{ room.name }}</span>
                    </div>
                    <hr class="my-3 mx-n3" />
                    <div>
                        Loại phòng:
                        <span>{{ room.roomKind.name }}</span>
                    </div>
                    <div>
                        Số người tối đa:
                        <span>{{ room.roomKind.amountOfPeople }}</span>
                    </div>
                    <div>
                        Số giường:
                        <span>{{ room.roomKind.numberOfBeds }}</span>
                    </div>
                </div>
                <div
                    class="flex-fill border shadow-sm p-3 m-2 child-float-right"
                >
                    <div>
                        Nhận phòng dự kiến:
                        <span>
                            {{ toDate(booking.bookCheckInTime) }}
                        </span>
                    </div>
                    <div>
                        Trả phòng dự kiến:
                        <span>
                            {{ toDate(booking.bookCheckOutTime) }}
                        </span>
                    </div>
                    <div>
                        Nhận phòng thực tế:
                        <span>
                            {{ toDate(booking.realCheckInTime) }}
                        </span>
                    </div>
                    <div>
                        Trả phòng thực tế:
                        <span>
                            {{ toDate(booking.realCheckOutTime) }}
                        </span>
                    </div>
                </div>
            </div>
            <div class="my-n2" />
            <div class="d-flex m-2">
                <div class="m-2 flex-1">
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
                        <template v-slot:index="data">
                            {{ data.index + 1 }}
                        </template>
                        <template v-slot:phoneNumbers="{ value }">
                            <a
                                v-for="phoneNumber in value"
                                :key="phoneNumber"
                                :href="`tel:${phoneNumber}`"
                                class="d-block"
                                @click.stop
                            >
                                {{ phoneNumber }}
                            </a>
                        </template>
                        <template v-slot:birthdate="{ value }">
                            {{ toYear(value) }}
                        </template>
                    </b-table>
                </div>
            </div>
            <div class="my-n2" />
            <div class="d-flex m-2">
                <div class="m-2 flex-1">
                    <b-table
                        class="table-style border shadow-sm"
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
                                key: 'unitRate',
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
                        <template v-slot:index="data">
                            {{ data.index + 1 }}
                        </template>
                        <template v-slot:name="{ item }">
                            {{ item.service.name }}
                        </template>
                        <template
                            v-slot:unitRate="{
                                item: { service: { unitRate, unit } },
                            }"
                        >
                            {{ toMoney(unitRate) }} / {{ unit }}
                        </template>
                        <template
                            v-slot:total="{
                                item: { service: { unitRate }, number },
                            }"
                        >
                            {{ toMoney(unitRate * number) }}
                        </template>
                    </b-table>
                    <div class="text-medium text-right mt-2">
                        Tổng cộng:
                        {{ totalServiceDetails(booking.servicesDetails) }}
                    </div>
                </div>
            </div>
        </query->
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
    onOpen() {}

    get variables(): GetBookingDetails.Variables {
        return { id: this.data.id.toString() };
    }

    totalServiceDetails(servicesDetails: GetBookingDetails.ServicesDetails[]) {
        return toMoney(
            servicesDetails.reduce((sum, { service: { unitRate }, number }) => {
                return sum + number * unitRate;
            }, 0),
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
