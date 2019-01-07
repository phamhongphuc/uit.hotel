<template>
    <div @contextmenu.prevent="tableContext">
        <div class="row">
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.booking_add.open()"
            >
                <span class="icon"></span>
                <span>Đặt phòng</span>
            </b-button>
            <b-button
                class="m-2 ml-auto"
                variant="white"
                @click="showInactive = !showInactive"
            >
                <span class="icon mr-1">{{ showInactive ? '' : '' }}</span>
                <span>
                    {{
                        `Đang ${
                            showInactive ? 'hiện' : 'ẩn'
                        } dịch vụ đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </div>
        <query-
            :query="getBookings"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { bookings } }"
                class="table-style"
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
                @row-clicked="
                    (booking, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_booking.open(currentEvent || $event, {
                            booking,
                            bookings,
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
                    {{ toDate(item.bookCheckInTime) }}
                </template>
                <template slot="checkout" slot-scope="{ item }">
                    {{ toDate(item.bookCheckOutTime) }}
                </template>
                <template slot="room" slot-scope="{ value }">
                    {{ value.name }}
                </template>
                <template slot="patrons" slot-scope="{ value }">
                    {{ value.length }} khách
                </template>
            </b-table>
        </query->
        <!-- <context-manage-booking- ref="context_booking" :refs="$refs" />
        <popup-booking-add- ref="booking_add" />
        <popup-booking-update- ref="booking_update" /> -->
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getBookings } from '~/graphql/documents/booking';
import { mixinData } from '~/components/mixins/mutable';
import { GetBookings } from '~/graphql/types';
import { toMoney, toDate } from '~/utils/dataFormater';

@Component({
    name: 'booking-',
    mixins: [mixinData({ getBookings, toMoney, toDate })],
})
export default class extends Vue {
    head() {
        return {
            title: 'Sơ đồ khách sạn',
        };
    }

    bookingStatusEnum = [
        'Đã đặt',
        'Đã nhận phòng',
        'Đã yêu cầu trả phòng',
        'Đã trả phòng',
    ];

    bookingsFilter(bookings: GetBookings.Bookings[]): GetBookings.Bookings[] {
        return bookings;
    }

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');
        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }

    currentEvent: MouseEvent | null = null;

    showInactive: boolean = false;

    console = console;
}
</script>
