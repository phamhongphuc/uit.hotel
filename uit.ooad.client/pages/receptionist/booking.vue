<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.booking_add.open()"
            >
                <span class="icon mr-1"></span>
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
        </block-flex->
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
            title: 'Quản lý đơn đặt phòng',
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
