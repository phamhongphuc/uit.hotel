<template>
    <div>
        <div class="row">
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.book_and_check_in.open({ rooms: selected })"
            >
                <span class="icon mr-1"></span>
                <span>Đặt phòng nhận ngay</span>
            </b-button>
        </div>
        <query-
            :query="getFloorsMap"
            :variables="{
                from,
                to,
            }"
            class="hotel-map row flex-1"
            child-class="col m-2 p-3 bg-white rounded shadow-sm overflow-auto"
        >
            <div slot-scope="{ data: { floors } }">
                <div
                    v-for="floor in floorsFilter(floors)"
                    :key="floor.id"
                    class="d-flex flex-nowrap"
                >
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
                    <b-button
                        v-for="room in roomsFilter(floor.rooms)"
                        :key="room.id"
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
                </div>
            </div>
        </query->
        <context-room- ref="context_room" :refs="$refs" />
        <popup-book-and-check-in- ref="book_and_check_in" :refs="$refs" />
        <popup-booking-book-and-check-in-
            ref="booking_book_and_check_in"
            :refs="$refs"
        />
        <popup-patron-select-or-add- ref="patron_select" />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getFloorsMap } from '~/graphql/documents/floor';
import { mixinData } from '~/components/mixins/mutable';
import { GetFloors } from 'graphql/types';
import moment from 'moment';

@Component({
    name: 'index-',
    mixins: [mixinData({ getFloorsMap })],
})
export default class extends Vue {
    selected: GetFloors.Rooms[] = [];

    from = moment().format();
    to = moment()
        .add(1, 'days')
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
