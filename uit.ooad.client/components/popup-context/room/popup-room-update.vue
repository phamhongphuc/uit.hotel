<template>
    <popup- ref="popup" title="Cập nhật phòng">
        <form-mutate-
            slot-scope="{ data: { room, floors }, close }"
            success="Cập nhật phòng mới thành công"
            :mutation="updateRoom"
            :variables="{
                input,
            }"
        >
            <div class="input-label">Tầng</div>
            <div class="m-3">
                <b-form-select
                    v-model="floorId"
                    value-field="id"
                    text-field="name"
                    :state="!$v.floorId.$invalid"
                    :options="floors"
                    class="rounded"
                />
            </div>
            <div class="input-label">Loại phòng</div>
            <query- :query="getRoomKinds" class="m-3" :poll-interval="0">
                <div slot-scope="{ data: { roomKinds } }">
                    <b-form-select
                        v-model="roomKindId"
                        value-field="id"
                        text-field="name"
                        :state="!$v.roomKindId.$invalid"
                        :options="roomKinds"
                        class="rounded"
                    />
                </div>
            </query->
            <div class="input-label">Tên phòng</div>
            <b-input-
                ref="autoFocus"
                v-model="roomName"
                :state="!$v.roomName.$invalid"
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
        roomName: {
            required,
        },
        floorId: {
            required,
        },
        roomKindId: {
            required,
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
