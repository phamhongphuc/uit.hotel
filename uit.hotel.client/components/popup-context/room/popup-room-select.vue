<template>
    <popup- ref="popup" v-slot="{ close }" title="Thêm phòng">
        <query-
            v-slot="{ data: { floors } }"
            :query="getRoomsMap"
            class="px-3 pb-0 pt-3"
        >
            <b-radio-group
                v-model="roomId"
                class="select-room-map"
                buttons
                button-variant="light-blue"
            >
                <div v-for="floor in floorsFilter(floors)" :key="floor.id">
                    <b-button variant="main">Tầng {{ floor.name }}</b-button>
                    <b-radio
                        v-for="room in roomsFilter(floor.rooms)"
                        :key="room.id"
                        v-b-tooltip.hover
                        :title="tooltip(room)"
                        :value="room.id"
                        :disabled="isDisabled(room)"
                    >
                        Phòng {{ room.name }}
                    </b-radio>
                </div>
            </b-radio-group>
        </query->
        <div class="d-flex m-3">
            <b-button
                :disabled="$v.$invalid"
                class="ml-auto"
                variant="main"
                @click="addRoom(close)"
            >
                <icon- class="mr-1" i="check" />
                <span>Xong</span>
            </b-button>
        </div>
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { RoomCreateInput, GetRoomsMap } from '~/graphql/types';
import { getRoomsMap } from '~/graphql/documents';

type PopupMixinType = PopupMixin<
    {
        currentRoomIds: number[];
        callback: (roomId: number) => void;
    },
    RoomCreateInput
>;

@Component({
    name: 'popup-room-select-',
    validations: {},
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ getRoomsMap }),
) {
    roomId = -1;

    floorsFilter(floors: GetRoomsMap.Floors[]): GetRoomsMap.Floors[] {
        return floors
            .filter(f => f.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    roomsFilter(rooms: GetRoomsMap.Rooms[]): GetRoomsMap.Rooms[] {
        return rooms
            .filter(r => r.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    isDisabled(room: GetRoomsMap.Rooms) {
        return this.data.currentRoomIds.includes(room.id);
    }

    tooltip(room: GetRoomsMap.Rooms) {
        return `Loại: Phòng ${room.roomKind.name}`;
    }

    addRoom(close: Function) {
        this.data.callback(this.roomId);
        this.roomId = -1;
        close();
    }
}
</script>
<style lang="scss">
.select-room-map {
    $margin-size: 0.25rem;

    display: block;
    margin: -$margin-size;
    > div {
        display: flex;
        > button,
        > label {
            width: 7rem;
            margin: $margin-size;
        }
        > button {
            cursor: default !important;
        }
        > label {
            cursor: pointer;
            &.active {
                box-shadow: 0 0 0 #{$margin-size} rgba($main, 1) !important;
            }
            > input {
                display: none;
            }
        }
    }
}
</style>
