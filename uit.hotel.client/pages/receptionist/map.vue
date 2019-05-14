<template>
    <div>
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.book_and_check_in.open({ rooms: selected })"
            >
                <icon- class="mr-1" i="plus" />
                <span>Đặt phòng nhận ngay</span>
            </b-button>
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.book.open({ rooms: selected })"
            >
                <icon- class="mr-1" i="plus" />
                <span>Đặt phòng</span>
            </b-button>
        </block-flex->
        <query-
            :query="getFloorsMap"
            :variables="{
                from,
                to,
            }"
            class="hotel-map row flex-1 p-2"
            child-class="bg-white rounded shadow-sm w-100 overflow-auto"
        >
            <div
                slot-scope="{ data: { floors } }"
                class="hotel-map-table-container p-3"
            >
                <table>
                    <tr v-for="floor in floorsFilter(floors)" :key="floor.id">
                        <td>
                            <b-button
                                :variant="floor.isActive ? 'main' : 'gray'"
                                @contextmenu.prevent="
                                    $refs.context_floor.open($event, {
                                        floors: floors,
                                        floor,
                                    })
                                "
                            >
                                Tầng {{ floor.name }}
                            </b-button>
                        </td>
                        <td
                            v-for="room in roomsFilter(floor.rooms)"
                            :key="room.id"
                        >
                            <b-button
                                :variant="
                                    selected.indexOf(room) === -1
                                        ? room.currentBooking
                                            ? 'light-red'
                                            : 'light-blue'
                                        : 'dark-blue'
                                "
                                @contextmenu.prevent="
                                    $refs.context_room.open($event, {
                                        room,
                                        floor,
                                        floors,
                                    })
                                "
                                @click="toggle(room)"
                            >
                                {{ room.name }}
                                <br />
                                {{ room.roomKind.name }}
                            </b-button>
                        </td>
                    </tr>
                </table>
            </div>
        </query->
        <div>
            <context-room- ref="context_room" :refs="$refs" />
            <popup-book-and-check-in- ref="book_and_check_in" :refs="$refs" />
            <popup-book- ref="book" :refs="$refs" />
            <popup-booking-book-and-check-in-
                ref="booking_book_and_check_in"
                :refs="$refs"
            />
            <popup-patron-select-or-add- ref="patron_select_or_add" />
        </div>
    </div>
</template>
<script lang="ts">
import { GetFloors } from 'graphql/types';
import { Vue, Component } from 'nuxt-property-decorator';
import { getFloorsMap } from '~/graphql/documents/floor';
import { mixinData } from '~/components/mixins/mutable';
import moment from 'moment';

@Component({
    name: 'index-',
    mixins: [mixinData({ getFloorsMap })],
})
export default class extends Vue {
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
