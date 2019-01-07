<template>
    <div @contextmenu.prevent="tableContext">
        <div class="row">
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.room_kind_add.open()"
            >
                <span class="icon mr-1"></span>
                <span>Thêm loại phòng mới</span>
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
                        } loại phòng đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </div>
        <query-
            :query="getRoomKinds"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { roomKinds } }"
                class="table-style"
                :items="roomKindsFilter(roomKinds)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'name',
                        label: 'Tên loại phòng',
                        tdClass: (value, key, row) => {
                            if (!row.isActive)
                                return 'table-cell-disable w-100';
                            return 'w-100';
                        },
                        sortable: true,
                    },
                    {
                        key: 'rooms',
                        label: 'Số phòng',
                        tdClass: 'text-center',
                        sortable: true,
                    },
                    {
                        key: 'numberOfBeds',
                        label: 'Số giường',
                        tdClass: 'text-right',
                    },
                    {
                        key: 'amountOfPeople',
                        label: 'Số người tối đa',
                        tdClass: 'text-right',
                    },
                ]"
                @row-clicked="
                    (roomKind, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_room_kind.open(currentEvent || $event, {
                            roomKind,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <template slot="rooms" slot-scope="{ value }">
                    {{ value.length }} phòng
                </template>
            </b-table>
        </query->
        <context-manage-room-kind- ref="context_room_kind" :refs="$refs" />
        <popup-room-kind-add- ref="room_kind_add" />
        <popup-room-kind-update- ref="room_kind_update" />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getRoomKinds } from '~/graphql/documents/room-kind';
import { mixinData } from '~/components/mixins/mutable';
import { GetRoomKinds } from '~/graphql/types';

@Component({
    name: 'floor-room-',
    mixins: [mixinData({ getRoomKinds })],
})
export default class extends Vue {
    head() {
        return {
            title: 'Sơ đồ khách sạn',
        };
    }

    roomKindsFilter(
        roomKinds: GetRoomKinds.RoomKinds[],
    ): GetRoomKinds.RoomKinds[] {
        if (this.showInactive) return roomKinds;
        return roomKinds.filter(rk => rk.isActive);
    }

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');
        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }

    currentEvent: MouseEvent | null = null;

    showInactive: boolean = false;

    console = console;
}
</script>
