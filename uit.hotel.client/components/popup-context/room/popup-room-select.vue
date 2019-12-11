<template>
    <popup- ref="popup" v-slot="{ close }" title="Thêm phòng">
        <query-
            v-slot="{ data: { floors } }"
            :query="getFloorsMap"
            :variables="{ from, to }"
            class="px-3 pb-0 pt-3"
        >
            <b-checkbox-group v-model="roomIds" class="select-room-map" buttons>
                <div v-for="floor in floorsFilter(floors)" :key="floor.id">
                    <b-button variant="main">Tầng {{ floor.name }}</b-button>
                    <div
                        v-for="room in roomsFilter(floor.rooms)"
                        :key="room.id"
                        v-b-tooltip.hover
                        :title="tooltip(room)"
                    >
                        <b-checkbox
                            :value="room.id"
                            :disabled="isDisabled(room)"
                            :button-variant="buttonVariant(room)"
                        >
                            Phòng {{ room.name }}
                        </b-checkbox>
                    </div>
                </div>
            </b-checkbox-group>
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
import moment from 'moment';
import { RoomSelectMixinType } from './popup-room-select.helper';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetFloorsMap } from '~/graphql/types';
import { getFloorsMap } from '~/graphql/documents';

@Component({
    name: 'popup-room-select-',
    validations: {},
})
export default class extends mixins<RoomSelectMixinType>(
    PopupMixin,
    DataMixin({ getFloorsMap }),
) {
    roomIds = [];

    from = moment().format();
    to = moment()
        .add(1, 'hours')
        .format();

    floorsFilter(floors: GetFloorsMap.Floors[]): GetFloorsMap.Floors[] {
        return floors
            .filter(f => f.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    roomsFilter(rooms: GetFloorsMap.Rooms[]): GetFloorsMap.Rooms[] {
        return rooms
            .filter(r => r.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    isDisabled(room: GetFloorsMap.Rooms) {
        return (
            this.data.currentRoomIds.includes(room.id) ||
            room.currentBooking !== null
        );
    }

    tooltip(room: GetFloorsMap.Rooms) {
        if (this.data.currentRoomIds.includes(room.id)) {
            return 'Phòng đã được chọn';
        }

        if (room.currentBooking !== null) {
            return 'Phòng đã được thuê';
        }

        return `Loại: Phòng ${room.roomKind.name}`;
    }

    buttonVariant(room: GetFloorsMap.Rooms) {
        if (this.data.currentRoomIds.includes(room.id)) {
            return 'orange';
        }

        if (room.currentBooking !== null) {
            return 'light-red';
        }

        return 'light-blue';
    }

    addRoom(close: Function) {
        this.data.callback(this.roomIds);
        this.roomIds = [];
        close();
    }

    onOpen() {
        this.roomIds = [];
        this.from = this.data.from;
        this.to = this.data.to;
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
        > div {
            min-width: 7rem;
            margin: $margin-size;
        }
        > button {
            cursor: default !important;
        }
        > div > label {
            margin: 0;
            cursor: pointer;
            &.active {
                box-shadow: 0 0 0 #{$margin-size * 0.75} rgba($main, 1) !important;
            }
            > input {
                display: none;
            }
        }
    }
}
</style>
