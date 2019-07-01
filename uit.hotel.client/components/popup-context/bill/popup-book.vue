<template>
    <popup-
        ref="popup"
        v-slot="{ close }"
        title="Đặt phòng"
        class="align-items-start"
    >
        <form-mutate-
            :mutation="mutation"
            :variables="variables"
            success="Thêm phòng cho hóa đơn có sẵn"
            @success="close"
        >
            <query-
                :query="getPatronsAndRooms"
                class="d-none"
                @result="onResult"
            />
            <div>
                <div class="input-label">
                    Thời gian nhận phòng dự kiến:
                    <b-form-checkbox v-model="isCheckinNow" inline class="ml-1">
                        Nhận ngay
                    </b-form-checkbox>
                </div>
                <b-input-date-time-
                    v-if="!isCheckinNow"
                    v-model="bookCheckInTime"
                    class="rounded m-3"
                    :state="!$v.bookCheckOutTime.$invalid"
                />
                <div v-else class="m-2" />
                <div class="input-label">Thời gian trả phòng dự kiến</div>
                <b-input-date-time-
                    v-model="bookCheckOutTime"
                    class="rounded m-3"
                    :state="!$v.bookCheckOutTime.$invalid"
                />
                <div class="input-label">Danh sách đặt phòng</div>
                <div
                    class="m-3 list-of-patrons box-shadow-inner rounded overflow-hidden"
                >
                    <popup-book-room-detail-
                        v-for="row in tableData"
                        :key="row.room.id"
                        :row="row"
                        @select-patron="selectPatron"
                        @remove-patron="removePatron"
                        @remove-room="removeRoom"
                        @add-patron="
                            refs.patron_select_or_add.open({
                                callback(patronId) {
                                    addPatron(patronId, row);
                                },
                            })
                        "
                    />
                    <text-validator-
                        :state="!$v.tableData.$invalid"
                        class="py-3 pl-4"
                    >
                        <template v-slot:valid>
                            Có tổng cộng {{ numberOfPatrons }} người /
                            {{ tableData.length }} phòng
                        </template>
                        <template v-slot:invalid>
                            Danh sách phòng không hợp lệ
                            <br />
                            Ấn
                            <icon- class="mx-1" i="plus-square" />
                            để thêm phòng
                        </template>
                    </text-validator->
                </div>
                <div class="d-flex m-3">
                    <b-button
                        variant="main"
                        class="ml-auto"
                        @click="
                            refs.room_select.open({
                                currentRoomIds,
                                callback: roomAdded,
                            })
                        "
                    >
                        <icon- class="mr-1" i="plus-square" />
                        <span>Thêm phòng</span>
                    </b-button>
                    <b-button
                        :disabled="$v.$invalid"
                        class="ml-3"
                        variant="main"
                        type="submit"
                    >
                        <icon- class="mr-1" i="check" />
                        <span>Xong</span>
                    </b-button>
                </div>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import moment from 'moment';
import { Component, mixins } from 'nuxt-property-decorator';
import {
    GetFloors,
    GetPatronsAndRoomsQuery,
    GetPatronsAndRooms,
    CreateBill,
    BookAndCheckIn,
} from '~/graphql/types';
import {
    createBill,
    getRoom,
    getPatronsAndRooms,
    bookAndCheckIn,
} from '~/graphql/documents';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { bookCheckOutTime, bookCheckInTime } from '~/modules/validator';
import { ApolloQueryResult } from 'apollo-client';
import { required } from 'vuelidate/lib/validators';
import { TableDataType } from './popup-book.helper';

type PopupMixinType = PopupMixin<{ rooms: GetFloors.Rooms[] }, null>;

@Component({
    name: 'popup-booking-and-check-in-',
    validations: {
        bookCheckInTime,
        bookCheckOutTime,
        tableData: {
            required,
            $each: {
                patrons: {
                    required,
                },
            },
            duplicate: (tableData: TableDataType[]) =>
                tableData
                    .flatMap(row =>
                        row.patrons.map(patron => patron.identification),
                    )
                    .every(
                        (value, index, array) => array.indexOf(value) === index,
                    ),
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ getPatronsAndRooms, getRoom, moment }),
) {
    isCheckinNow: boolean = false;

    bookCheckInTime: string = moment()
        .add(1, 'day')
        .set({
            hour: 13,
            minute: 0,
            second: 0,
        })
        .format();

    bookCheckOutTime: string = moment()
        .add(2, 'day')
        .set({
            hour: 11,
            minute: 0,
            second: 0,
        })
        .format();

    patrons: GetPatronsAndRooms.Patrons[] = [];
    rooms: GetPatronsAndRooms.Rooms[] = [];

    tableData: TableDataType[] = [];

    onOpen() {
        this.tableData = [];
    }

    get mutation() {
        return this.isCheckinNow ? bookAndCheckIn : createBill;
    }

    get variables(): BookAndCheckIn.Variables | CreateBill.Variables {
        let patronId = -1;

        if (this.isCheckinNow) {
            const output: BookAndCheckIn.Variables = {
                bookings: this.tableData.map(tableRow => ({
                    bookCheckOutTime: this.bookCheckOutTime,
                    room: { id: tableRow.room.id },
                    listOfPatrons: tableRow.patrons.map(patron => {
                        if (patron.isOwner) patronId = patron.id;
                        return { id: patron.id };
                    }),
                })),
                bill: { patron: { id: patronId } },
            };
            return output;
        } else {
            const output: CreateBill.Variables = {
                bookings: this.tableData.map(tableRow => ({
                    bookCheckInTime: this.bookCheckInTime,
                    bookCheckOutTime: this.bookCheckOutTime,
                    room: { id: tableRow.room.id },
                    listOfPatrons: tableRow.patrons.map(patron => {
                        if (patron.isOwner) patronId = patron.id;
                        return { id: patron.id };
                    }),
                })),
                bill: { patron: { id: patronId } },
            };
            return output;
        }
    }

    roomAdded(roomIds: number[]) {
        roomIds
            .map(roomId => this.rooms.find(r => r.id === roomId))
            .forEach(room => {
                if (room === undefined) return;
                this.tableData.push({ room, patrons: [] });
            });
    }

    get numberOfPatrons() {
        return this.tableData.reduce(
            (sum, current) => sum + current.patrons.length,
            0,
        );
    }

    get currentRoomIds() {
        return this.tableData.reduce(
            (output, rowData) => {
                output.push(rowData.room.id);
                return output;
            },
            [] as number[],
        );
    }

    addPatron(patronId: number, row: TableDataType) {
        const patron = this.patrons.find(patron => patron.id === patronId);
        if (patron === undefined) return;
        row.patrons.push({ ...patron, isOwner: this.numberOfPatrons === 0 });
    }

    selectPatron(patronId: number) {
        this.tableData.forEach(row => {
            row.patrons.forEach(patron => {
                patron.isOwner = patronId === patron.id;
            });
        });
    }

    removePatron(patronId: number) {
        this.tableData.forEach(row => {
            const index = row.patrons.findIndex(
                patron => patron.id === patronId,
            );
            if (index !== -1) row.patrons.splice(index, 1);
        });
    }

    removeRoom(roomId: number) {
        const index = this.tableData.findIndex(row => row.room.id === roomId);
        this.tableData.splice(index, 1);
    }

    async onResult({ data }: ApolloQueryResult<GetPatronsAndRoomsQuery>) {
        this.patrons = data.patrons;
        this.rooms = data.rooms;
    }
}
</script>
