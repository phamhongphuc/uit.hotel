<template>
    <popup- ref="popup" v-slot="{ close }" title="Cập nhật phòng">
        <form-mutate-
            v-if="input"
            :mutation="updateRoom"
            :variables="{ input }"
            success="Cập nhật phòng mới thành công"
            @success="close"
        >
            <div class="input-label">Tầng</div>
            <query-
                v-slot="{ data: { floors } }"
                :query="getFloors"
                :poll-interval="0"
                class="m-3"
                @result="onResult"
            >
                <b-form-select
                    ref="floor"
                    v-model="input.floor.id"
                    :state="!$v.input.floor.$invalid"
                    :options="floors"
                    value-field="id"
                    text-field="name"
                    class="rounded"
                />
            </query->
            <div class="input-label">Loại phòng</div>
            <query-
                v-slot="{ data: { roomKinds } }"
                :query="getRoomKinds"
                :poll-interval="0"
                class="m-3"
                @result="onResult"
            >
                <b-form-select
                    ref="roomKind"
                    v-model="input.roomKind.id"
                    :state="!$v.input.roomKind.id.$invalid"
                    :options="roomKinds"
                    value-field="id"
                    text-field="name"
                    class="rounded"
                />
            </query->
            <div class="input-label">Tên phòng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon="type"
            />
            <div class="m-3">
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    type="submit"
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins, Vue } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { PopupMixin, DataMixin } from '~/components/mixins';
import {
    GetFloors,
    RoomUpdateInput,
    GetRoomKindsQuery,
    GetFloorsQuery,
} from '~/graphql/types';
import { getFloors, updateRoom, getRoomKinds } from '~/graphql/documents';
import { floorRoomName, included } from '~/modules/validator';

type PopupMixinType = PopupMixin<
    {
        room: GetFloors.Rooms;
        floor: GetFloors.Floors;
    },
    RoomUpdateInput
>;

@Component({
    name: 'popup-room-add-',
    validations: {
        input: {
            name: floorRoomName,
            floor: included('floor'),
            roomKind: included('roomKind'),
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ updateRoom, getRoomKinds, getFloors }),
) {
    onOpen() {
        const {
            room: { id, name },
        } = this.data;

        this.input = {
            id,
            name,
            floor: { id: -1 },
            roomKind: { id: -1 },
        };
    }

    async onResult({
        data,
    }: ApolloQueryResult<GetRoomKindsQuery | GetFloorsQuery>) {
        if (this.input === null) return;
        await Vue.nextTick();
        if ('roomKinds' in data) {
            this.input.roomKind.id = this.data.room.roomKind.id;
        } else if ('floors' in data) {
            this.input.floor.id = this.data.floor.id;
        }
        this.$v.$touch();
    }
}
</script>
