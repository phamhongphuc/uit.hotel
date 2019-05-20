<template>
    <popup- ref="popup" title="Thêm booking vào danh sách" no-data>
        <template slot-scope="{ close }">
            <div v-if="input">
                <div class="input-label">Phòng</div>
                <query- :query="getRooms" :poll-interval="0" class="m-3">
                    <b-form-select
                        v-model="input.room.id"
                        slot-scope="{ data: { rooms } }"
                        :state="!$v.input.room.$invalid"
                        :options="rooms"
                        value-field="id"
                        text-field="name"
                        class="rounded"
                    />
                </query->
                <div class="input-label">Khách hàng</div>
                <div class="m-3 table-inner rounded overflow-hidden">
                    <b-table
                        :items="input.listOfPatrons"
                        :fields="[
                            {
                                key: 'index',
                                label: '#',
                                class: 'table-cell-id text-center',
                                sortable: true,
                            },
                            {
                                key: 'name',
                                label: 'Họ và tên',
                                class: 'text-center',
                            },
                            {
                                key: 'identification',
                                label: 'CMND',
                                class: 'text-center',
                            },
                            {
                                key: 'phoneNumbers',
                                label: 'Số điện thoại',
                                class: 'text-center',
                            },
                        ]"
                        class="table-style"
                    >
                        <template slot="index" slot-scope="data">
                            {{ data.index + 1 }}
                        </template>
                    </b-table>
                    <div
                        v-if="input.listOfPatrons.length === 0"
                        class="p-3 text-center"
                    >
                        Chưa có phòng nào trong danh sách. Ấn
                        <icon- class="mx-1" i="users" />
                        để thêm phòng
                    </div>
                </div>
            </div>
            <div class="d-flex m-3">
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    @click="
                        refs.patron_select_or_add.open({
                            callback(id, patron) {
                                input.listOfPatrons.push(patron);
                            },
                        })
                    "
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm khách hàng</span>
                </b-button>
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-3"
                    variant="main"
                    @click="addBookingToList(close)"
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm</span>
                </b-button>
            </div>
        </template>
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { required } from 'vuelidate/lib/validators';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { BookAndCheckInCreateInput, GetRooms } from '~/graphql/types';
import { getPatronKinds, getRooms, createPatron } from '~/graphql/documents';

type PopupMixinType = PopupMixin<
    {
        booking: BookAndCheckInCreateInput;
        callback(result: BookAndCheckInCreateInput): void;
    },
    BookAndCheckInCreateInput
>;

@Component({
    name: 'popup-booking-book-and-check-in-',
    validations: {
        input: {
            room: { required },
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ createPatron, getPatronKinds, getRooms }),
) {
    onOpen() {
        this.input = this.data.booking || {
            bookCheckOutTime: new Date(),
            room: {
                id: 1,
            },
            listOfPatrons: [],
        };
    }

    roomsFilter(rooms: GetRooms.Rooms[]): GetRooms.Rooms[] {
        return rooms
            .filter(r => r.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    addBookingToList(close: Function) {
        this.data.callback(this.input);
        close();
    }
}
</script>
