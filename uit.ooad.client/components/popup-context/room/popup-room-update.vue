<template>
    <popup- ref="popup" title="Cập nhật phòng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { room, floors }, close }"
            success="Cập nhật phòng mới thành công"
            :mutation="updateRoom"
            :variables="{ input }"
        >
            <div class="input-label">Tầng</div>
            <div class="m-3">
                <b-form-select
                    v-model="input.floor.id"
                    value-field="id"
                    text-field="name"
                    :state="!$v.input.floor.$invalid"
                    :options="floors"
                    class="rounded"
                />
            </div>
            <div class="input-label">Loại phòng</div>
            <query- :query="getRoomKinds" class="m-3" :poll-interval="0">
                <div slot-scope="{ data: { roomKinds } }">
                    <b-form-select
                        v-model="input.roomKind.id"
                        value-field="id"
                        text-field="name"
                        :state="!$v.input.roomKind.id.$invalid"
                        :options="roomKinds"
                        class="rounded"
                    />
                </div>
            </query->
            <div class="input-label">Tên phòng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="m-3">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
                    @click="close"
                >
                    <span class="icon"></span>
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { PopupMixin } from '~/components/mixins/popup';
import { GetFloors, RoomUpdateInput } from '~/graphql/types';
import { mixinData } from '~/components/mixins/mutable';
import { required } from 'vuelidate/lib/validators';
import { updateRoom } from '~/graphql/documents/room';
import { getRoomKinds } from '~/graphql/documents/room-kind';

interface PopupRoomUpdateInput {
    room: GetFloors.Rooms;
    floor: GetFloors.Floors;
    floors: GetFloors.Floors[];
}

@Component({
    mixins: [PopupMixin, mixinData({ updateRoom, getRoomKinds })],
    name: 'popup-room-add-',
    validations: {
        input: {
            name: { required },
            floor: {
                id: { required },
            },
            roomKind: {
                id: { required },
            },
        },
    },
})
export default class extends PopupMixin<PopupRoomUpdateInput, RoomUpdateInput> {
    onOpen() {
        const {
            room: { id, name, roomKind },
            floor,
        } = this.data;

        this.input = {
            id,
            name,
            floor: {
                id: floor.id,
            },
            roomKind: {
                id: roomKind.id,
            },
        };
        // const data = this.data as {
        //     room: GetFloors.Rooms;
        //     floor: GetFloors.Floors;
        // };
        // this.floorId = data.floor.id;
        // this.roomKindId = data.room.roomKind.id;
        // this.roomName = data.room.name;
    }
}
</script>
