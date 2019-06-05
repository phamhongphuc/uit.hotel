<template>
    <popup-
        ref="popup"
        v-slot="{ close }"
        title="Thêm booking vào danh sách"
        no-data
    >
        <div v-if="input">
            <div class="input-label">Phòng</div>
            <query-
                :query="getRooms"
                :poll-interval="0"
                class="m-3"
                @result="onResult"
            >
                <b-form-select
                    ref="room"
                    v-model="input.room.id"
                    v-slot="{ data: { rooms } }"
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
                    <template v-slot:index="data">
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
    </popup->
</template>
<script lang="ts">
import { Component, mixins, Vue } from 'nuxt-property-decorator';
import { minLength, required } from 'vuelidate/lib/validators';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { BookAndCheckInCreateInput, GetRooms } from '~/graphql/types';
import { getPatronKinds, getRooms, createPatron } from '~/graphql/documents';
import { included } from '~/modules/validator';

type PopupMixinType = PopupMixin<
    {
        booking: BookAndCheckInCreateInput;
        callback(result: BookAndCheckInCreateInput): void;
    },
    BookAndCheckInCreateInput
>;

@Component({
    name: 'popup-booking-add-or-update-',
    validations: {
        input: {
            room: included('room'),
            listOfPatrons: {
                minLength: minLength(1),
                required,
            },
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
            room: { id: -1 },
            listOfPatrons: [],
        };
    }

    roomsFilter(rooms: GetRooms.Rooms[]): GetRooms.Rooms[] {
        return rooms
            .filter(r => r.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    addBookingToList(close: Function) {
        if (this.input === null) throw new Error("Popup input mustn't be null");
        this.data.callback(this.input);
        close();
    }

    async onResult() {
        if (!this.data.booking) return;
        if (this.input === null) return;
        await Vue.nextTick();
        this.input.room.id = this.data.booking.room.id;
        this.$v.$touch();
    }
}
</script>
