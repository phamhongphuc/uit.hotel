<template>
    <popup- ref="popup" title="Đặt phòng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { bill }, close }"
            :mutation="createBill"
            :variables="getInput"
            success="Thêm phòng cho hóa đơn có sẵn"
            @success="close"
        >
            <div class="input-label">Khách hàng đứng tên hóa đơn</div>
            <div class="m-3 d-flex">
                <query- :query="getPatrons" :poll-interval="500">
                    <b-form-select
                        v-model="input.bill.patron.id"
                        slot-scope="{ data: { patrons } }"
                        :state="!$v.input.$invalid"
                        :options="patrons"
                        value-field="id"
                        text-field="name"
                        class="rounded"
                    />
                </query->
                <b-button
                    variant="main"
                    class="ml-3 text-nowrap"
                    @click="
                        refs.patron_select_or_add.open({
                            callback(id) {
                                input.bill.patron.id = id;
                            },
                        })
                    "
                >
                    <icon- class="mr-1" i="edit-2" />
                    <span>Chọn hoặc thêm khách hàng</span>
                </b-button>
            </div>
            <div class="input-label">Thời gian nhận phòng dự kiến</div>
            <b-input-date-time- v-model="bookCheckInTime" class="rounded m-3" />
            <div class="input-label">Thời gian trả phòng dự kiến</div>
            <b-input-date-time-
                v-model="bookCheckOutTime"
                class="rounded m-3"
            />
            <div class="input-label">Danh sách phòng</div>
            <div class="m-3 table-inner rounded overflow-hidden">
                <b-table
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
                    class="table-style table-cell-middle"
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
                    <icon- class="mx-1" i="plus-square" />
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
                    <icon- class="mr-1" i="plus-square" />
                    <span>Thêm phòng</span>
                </b-button>
                <b-button
                    :disabled="$v.$invalid"
                    variant="main"
                    class="ml-3"
                    type="submit"
                >
                    <icon- class="mr-1" i="edit-2" />
                    <span>Đặt phòng</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import moment from 'moment';
import { Component, mixins } from 'nuxt-property-decorator';
import { GetFloors, CreateBill, BookingCreateInput } from '~/graphql/types';
import { createBill, getPatrons, getRoom } from '~/graphql/documents';
import { PopupMixin, DataMixin } from '~/components/mixins';

type PopupMixinType = PopupMixin<
    { rooms: GetFloors.Rooms[] },
    CreateBill.Variables
>;

@Component({
    name: 'popup-booking-and-check-in-',
    validations: {
        input: {},
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ createBill, getPatrons, getRoom }),
) {
    bookCheckOutTime: string = moment().format();
    bookCheckInTime: string = moment().format();

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
                bookCheckInTime: new Date(),
                room: {
                    id: r.id,
                },
                listOfPatrons: [],
            })),
        };
    }

    get getInput(): CreateBill.Variables {
        const { input, bookCheckOutTime, bookCheckInTime } = this;
        const { bill, bookings } = input;
        return {
            bill: {
                patron: {
                    id: bill.patron.id,
                },
            },
            bookings: bookings.map(b => {
                return {
                    bookCheckOutTime,
                    bookCheckInTime,
                    room: {
                        id: b.room.id,
                    },
                    listOfPatrons: b.listOfPatrons.map(p => ({ id: p.id })),
                };
            }),
        };
    }

    removeBooking(booking: BookingCreateInput) {
        const index = this.input.bookings.indexOf(booking);
        this.input.bookings.splice(index, 1);
    }
}
</script>
