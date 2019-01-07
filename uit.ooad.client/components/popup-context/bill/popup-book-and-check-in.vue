<template>
    <popup- ref="popup" title="Đặt phòng và nhận ngay">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { bill }, close }"
            success="Thêm phòng cho hóa đơn có sẵn"
            :mutation="bookAndCheckIn"
            :variables="getInput"
        >
            <div class="input-label">Khách hàng đứng tên hóa đơn</div>
            <div class="m-3 d-flex">
                <query- :query="getPatrons" :poll-interval="500">
                    <b-form-select
                        v-model="input.bill.patron.id"
                        slot-scope="{ data: { patrons } }"
                        value-field="id"
                        text-field="name"
                        :state="!$v.input.$invalid"
                        :options="patrons"
                        class="rounded"
                    />
                </query->
                <b-button
                    variant="main"
                    class="ml-3 text-nowrap"
                    @click="
                        refs.patron_select.open({
                            callback(id) {
                                input.bill.patron.id = id;
                            },
                        })
                    "
                >
                    <span class="icon"></span>
                    <span>Chọn hoặc thêm khách hàng</span>
                </b-button>
            </div>
            <div class="input-label">Danh sách phòng</div>
            <div class="m-3 table-inner rounded overflow-hidden">
                <b-table
                    class="table-style"
                    :items="input.bookings"
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
                            class: 'text-center',
                        },
                        {
                            key: 'listOfPatrons',
                            label: 'Danh sách khách hàng',
                            class: 'text-center',
                        },
                        {
                            key: 'actions',
                            label: 'Thao tác',
                            class: 'text-center',
                        },
                    ]"
                >
                    <template slot="index" slot-scope="data">
                        {{ data.index + 1 }}
                    </template>
                    <template slot="room" slot-scope="{ value }">
                        <query-
                            :query="getRoom"
                            :variables="{
                                id: value.id,
                            }"
                            :poll-interval="0"
                        >
                            <span slot-scope="{ data: { room } }">
                                {{ room.name }}
                            </span>
                        </query->
                    </template>
                    <template slot="listOfPatrons" slot-scope="{ value }">
                        <div v-for="patron in value" :key="patron.id">
                            {{ patron.name }}
                        </div>
                    </template>
                    <template slot="actions" slot-scope="{ item }">
                        <div class="d-flex">
                            <b-button
                                variant="main"
                                @click="
                                    refs.booking_book_and_check_in.open({
                                        booking: item,
                                        callback(result) {
                                            removeBooking(item);
                                            input.bookings.push(result);
                                        },
                                    })
                                "
                            >
                                Sửa
                            </b-button>
                            <b-button
                                class="ml-3"
                                variant="main"
                                @click="removeBooking(item)"
                            >
                                Xóa
                            </b-button>
                        </div>
                    </template>
                </b-table>
                <div v-if="input.bookings.length === 0" class="p-3 text-center">
                    Chưa có phòng nào trong danh sách. Ấn
                    <span class="icon mx-1"></span>
                    để thêm phòng
                </div>
            </div>
            <div class="d-flex m-3">
                <b-button
                    variant="main"
                    class="ml-auto"
                    @click="
                        refs.booking_book_and_check_in.open({
                            callback(result) {
                                input.bookings.push(result);
                            },
                        })
                    "
                >
                    <span class="icon"></span>
                    <span>Thêm phòng</span>
                </b-button>
                <b-button
                    variant="main"
                    class="ml-3"
                    type="submit"
                    :disabled="$v.$invalid"
                    @click="close"
                >
                    <span class="icon"></span>
                    <span>Đặt phòng và nhận ngay</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import {
    GetFloors,
    BookAndCheckIn,
    BookAndCheckInCreateInput,
} from '~/graphql/types';
import { bookAndCheckIn } from '~/graphql/documents/bill';
import { getPatrons } from '~/graphql/documents/patron';
import { getRoom } from '~/graphql/documents/room';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';

@Component({
    mixins: [PopupMixin, mixinData({ bookAndCheckIn, getPatrons, getRoom })],
    name: 'popup-booking-and-check-in-',
    validations: {
        input: {},
    },
})
export default class extends PopupMixin<
    { rooms: GetFloors.Rooms[] },
    BookAndCheckIn.Variables
> {
    onOpen() {
        const self = this;
        this.input = {
            bill: {
                patron: {
                    id: 1,
                },
            },
            bookings: self.data.rooms.map(r => ({
                bookCheckOutTime: new Date(),
                room: {
                    id: r.id,
                },
                listOfPatrons: [],
            })),
        };
    }

    get getInput(): BookAndCheckIn.Variables {
        const { input } = this;
        const { bill, bookings } = input;
        return {
            bill: {
                patron: {
                    id: bill.patron.id,
                },
            },
            bookings: bookings.map(b => {
                return {
                    bookCheckOutTime: b.bookCheckOutTime,
                    room: {
                        id: b.room.id,
                    },
                    listOfPatrons: b.listOfPatrons.map(p => ({ id: p.id })),
                };
            }),
        };
    }

    removeBooking(booking: BookAndCheckInCreateInput) {
        const index = this.input.bookings.indexOf(booking);
        this.input.bookings.splice(index, 1);
    }
}
</script>
