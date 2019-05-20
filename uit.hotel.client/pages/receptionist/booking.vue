<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.booking_add.open()"
            >
                <icon- class="mr-1" i="plus" />
                <span>Đặt phòng</span>
            </b-button>
            <b-form-checkbox-group
                v-model="show"
                :options="showOptions"
                class="m-2 ml-auto"
                buttons
                button-variant="white"
            />
        </block-flex->
        <query-
            :query="getBookings"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { bookings } }"
                :items="bookingsFilter(bookings)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'room',
                        label: 'Phòng',
                        tdClass: 'w-100',
                    },
                    {
                        key: 'patrons',
                        label: 'Khách hàng',
                        class: 'text-right',
                    },
                    {
                        key: 'status',
                        label: 'Trạng thái',
                        tdClass: 'w-100 text-nowrap',
                    },
                    {
                        key: 'checkin',
                        label: 'Nhận phòng',
                        tdClass: 'w-100 text-nowrap',
                    },
                    {
                        key: 'checkout',
                        label: 'Trả phòng',
                        tdClass: 'w-100 text-nowrap',
                    },
                ]"
                class="table-style"
                @row-clicked="
                    (booking, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_booking.open(currentEvent || $event, {
                            booking,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <template slot="status" slot-scope="{ value }">
                    {{ bookingStatusEnum[value] }}
                </template>
                <template slot="checkin" slot-scope="{ item }">
                    {{ toDate(getCheckInTime(item)) }}
                </template>
                <template slot="checkout" slot-scope="{ item }">
                    {{ toDate(getCheckOutTime(item)) }}
                </template>
                <template slot="room" slot-scope="{ value }">
                    {{ value.name }}
                </template>
                <template slot="patrons" slot-scope="{ value }">
                    {{ value.length }} khách
                </template>
            </b-table>
        </query->
        <context-manage-booking- ref="context_booking" :refs="$refs" />
        <popup-service-detail-add- ref="service_detail_add" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getBookings } from '~/graphql/documents';
import { DataMixin } from '~/components/mixins';
import { GetBookings } from '~/graphql/types';
import { toMoney, toDate } from '~/utils';

@Component({
    name: 'booking-',
})
export default class extends mixins(
    DataMixin({ getBookings, toMoney, toDate }),
) {
    head() {
        return {
            title: 'Quản lý đơn đặt phòng',
        };
    }

    show = [0, 1, 2, 3];

    bookingStatusEnum = [
        'Đã đặt',
        'Đã nhận phòng',
        'Đã yêu cầu trả phòng',
        'Đã trả phòng',
    ];

    showOptions = this.bookingStatusEnum.map((booking, index) => ({
        text: booking,
        value: index,
    }));

    bookingsFilter(bookings: GetBookings.Bookings[]): GetBookings.Bookings[] {
        return bookings.filter(
            booking => this.show.indexOf(booking.status) !== -1,
        );
    }

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');
        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }

    currentEvent: MouseEvent | null = null;

    getCheckInTime(item: GetBookings.Bookings): string {
        if (item.status === 0) return item.bookCheckInTime;
        else return item.realCheckInTime;
    }

    getCheckOutTime(item: GetBookings.Bookings): string {
        if (item.status === 3) return item.realCheckOutTime;
        else return item.bookCheckOutTime;
    }
}
</script>
