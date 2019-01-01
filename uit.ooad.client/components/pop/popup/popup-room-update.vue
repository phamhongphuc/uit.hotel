<template>
    <popup- ref="popup" title="Cập nhật phòng">
        <form-mutate-
            slot-scope="{ data: { room, floors }, close }"
            success="Cập nhật phòng mới thành công"
            :mutation="updateRoom"
            :variables="{
                input: {
                    id: room.id,
                    name: roomName,
                    floor: {
                        id: floorId,
                    },
                    roomKind: {
                        id: roomKindId,
                    },
                },
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
            <div class="m-3 d-flex">
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
import { updateRoom, getRoomKinds } from '~/graphql/documents/floor-room';
import { GetFloors } from '~/graphql/types';
import { mixinData } from '~/components/mixins/mutable';
import { required } from 'vuelidate/lib/validators';

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
export default class extends PopupMixin {
    roomName: string = '';
    floorId: number | null = null;
    roomKindId: number | null = null;

    onOpen() {
        const data = this.data as {
            room: GetFloors.Rooms;
            floor: GetFloors.Floors;
        };
        this.floorId = data.floor.id;
        this.roomKindId = data.room.roomKind.id;
        this.roomName = data.room.name;
    }
}
</script>
<style lang="scss">
.input-label {
    padding: 0.25rem;
    margin: -0.5rem 1rem -1rem;

    &:first-child {
        margin-top: 0.5rem;
    }
}
</style>
