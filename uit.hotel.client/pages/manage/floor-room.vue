<template>
    <div>
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.floor_add.open()"
            >
                <span class="icon mr-1"></span>
                <span>Thêm tầng mới</span>
            </b-button>
            <b-button
                class="m-2 ml-auto"
                variant="white"
                @click="showInactive = !showInactive"
            >
                <span class="icon mr-1">{{ showInactive ? '' : '' }}</span>
                <span>
                    {{
                        `Đang ${
                            showInactive ? 'hiện' : 'ẩn'
                        } phòng và tầng đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </block-flex->
        <query-
            :query="getFloors"
            class="hotel-map row flex-1"
            child-class="col m-2 p-3 bg-white rounded shadow-sm overflow-auto"
        >
            <div slot-scope="{ data: { floors } }">
                <table>
                    <tr v-for="floor in floorsFilter(floors)" :key="floor.id">
                        <td>
                            <b-button
                                :variant="floor.isActive ? 'main' : 'gray'"
                                @contextmenu.prevent="
                                    $refs.context_floor.open($event, {
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
                                :variant="room.isActive ? 'light-blue' : 'gray'"
                                @contextmenu.prevent="
                                    $refs.context_room.open($event, {
                                        room,
                                        floor,
                                    })
                                "
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
        <context-manage-room- ref="context_room" :refs="$refs" />
        <context-manage-floor- ref="context_floor" :refs="$refs" />
        <popup-room-add- ref="room_add" />
        <popup-room-update- ref="room_update" />
        <popup-floor-add- ref="floor_add" />
        <popup-floor-update- ref="floor_update" />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getFloors } from '~/graphql/documents/floor';
import { mixinData } from '~/components/mixins/mutable';
import { GetFloors } from '~/graphql/types';

@Component({
    name: 'floor-room-',
    mixins: [mixinData({ getFloors })],
})
export default class extends Vue {
    head() {
        return {
            title: 'Sơ đồ khách sạn',
        };
    }

    floorsFilter(floors: GetFloors.Floors[]): GetFloors.Floors[] {
        if (this.showInactive) return floors;
        return floors
            .filter(f => f.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    roomsFilter(rooms: GetFloors.Rooms[]): GetFloors.Rooms[] {
        if (this.showInactive) return rooms;
        return rooms
            .filter(r => r.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    showInactive: boolean = false;
}
</script>