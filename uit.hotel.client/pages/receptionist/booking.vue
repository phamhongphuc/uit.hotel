<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.book.open({ rooms: [] })"
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
            v-slot="{ data: { bookings } }"
            :query="getBookings"
            class="query-fill"
        >
            <b-table
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
                class="table-style table-header-line"
                @row-clicked="
                    (booking, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_receptionist_booking.open(
                            currentEvent || $event,
                            {
                                booking,
                            },
                        );
                        currentEvent = null;
                    }
                "
            >
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(status)="{ value }">
                    {{ bookingStatusEnum[value] }}
                </template>
                <template v-slot:cell(checkin)="{ item }">
                    {{ toDate(getCheckInTime(item)) }}
                </template>
                <template v-slot:cell(checkout)="{ item }">
                    {{ toDate(getCheckOutTime(item)) }}
                </template>
                <template v-slot:cell(room)="{ value }">
                    {{ value.name }}
                </template>
                <template v-slot:cell(patrons)="{ value }">
                    {{ value.length }} khách
                </template>
            </b-table>
            <div
                v-if="bookingsFilter(bookings).length === 0"
                class="table-after"
            >
                Không tìm thấy bản ghi đặt phòng nào
            </div>
        </query->
        <context-receptionist-booking-
            ref="context_receptionist_booking"
            :refs="$refs"
        />
        <popup-service-detail-add- ref="service_detail_add" />
        <popup-book- ref="book" :refs="$refs" />
        <popup-patron-select-or-add- ref="patron_select_or_add" />
        <popup-room-select- ref="room_select" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getBookings } from '~/graphql/documents';
import { DataMixin } from '~/components/mixins';
import { GetBookings, BookingStatusEnum } from '~/graphql/types';
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

    show = [
        BookingStatusEnum.Booked,
        BookingStatusEnum.CheckedIn,
        BookingStatusEnum.CheckedOut,
    ];

    bookingStatusEnum = ['Đã đặt', 'Đã nhận phòng', 'Đã trả phòng'];

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

    getCheckInTime(item: GetBookings.Bookings) {
        if (item.status === BookingStatusEnum.Booked)
            return item.bookCheckInTime;
        return item.realCheckInTime;
    }

    getCheckOutTime(item: GetBookings.Bookings) {
        if (item.status === BookingStatusEnum.CheckedOut)
            return item.realCheckOutTime;
        return item.bookCheckOutTime;
    }
}
</script>
