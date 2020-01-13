<template>
    <div>
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.book.open({ rooms: selected })"
            >
                <icon- class="mr-1" i="edit-3" />
                <span>Đặt phòng</span>
            </b-button>
        </block-flex->
        <query-
            v-slot="{ data: { floors } }"
            :query="getFloorsMap"
            :variables="{
                from,
                to,
            }"
            class="hotel-map row flex-1 overflow-hidden"
            child-class="m-2 bg-white rounded shadow-sm w-100 overflow-auto"
        >
            <div class="hotel-map-table-container p-3">
                <table>
                    <tr v-for="floor in floorsFilter(floors)" :key="floor.id">
                        <td>
                            <b-button
                                :variant="floor.isActive ? 'main' : 'gray'"
                            >
                                Tầng {{ floor.name }}
                            </b-button>
                        </td>
                        <td
                            v-for="room in roomsFilter(floor.rooms)"
                            :key="room.id"
                        >
                            <b-button
                                class="position-relative"
                                :variant="
                                    selected.indexOf(room) === -1
                                        ? room.currentBooking
                                            ? 'light-red'
                                            : 'light-blue'
                                        : 'dark-blue'
                                "
                                @contextmenu.prevent="
                                    $refs.context_receptionist_room.open(
                                        $event,
                                        {
                                            room,
                                            floor,
                                            floors,
                                        },
                                    )
                                "
                                @click="toggle(room)"
                            >
                                Phòng {{ room.name }}
                                <br />
                                {{ room.roomKind.name }}
                                <icon-
                                    v-if="!room.isClean"
                                    i="broom"
                                    class="position-absolute b-0 r-0 m-1"
                                />
                            </b-button>
                        </td>
                    </tr>
                </table>
            </div>
        </query->
        <div>
            <context-receptionist-room- ref="context_receptionist_room" />
            <popup-book- ref="book" />
            <popup-patron-select-or-add- ref="patron_select_or_add" />
            <popup-room-select- ref="room_select" />
        </div>
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import moment from 'moment';
import { GetFloors } from '~/graphql/types';
import { getFloorsMap } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';

@Component({
    name: 'index-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getFloorsMap }),
) {
    selected: GetFloors.Rooms[] = [];

    from = moment().format();
    to = moment()
        .add(1, 'hours')
        .format();

    head() {
        return {
            title: 'Sơ đồ khách sạn',
        };
    }

    floorsFilter(floors: GetFloors.Floors[]): GetFloors.Floors[] {
        return floors
            .filter(f => f.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    roomsFilter(rooms: GetFloors.Rooms[]): GetFloors.Rooms[] {
        return rooms
            .filter(r => r.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    toggle(room: GetFloors.Rooms): void {
        const index = this.selected.indexOf(room);

        if (index === -1) this.selected.push(room);
        else this.selected.splice(index, 1);
    }
}
</script>
