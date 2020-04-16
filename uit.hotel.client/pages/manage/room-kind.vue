<template>
    <div @contextmenu.prevent="tableContext" @dblclick="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.room_kind_add.open()"
            >
                <icon- class="mr-1" i="plus" />
                <span>Thêm loại phòng mới</span>
            </b-button>
            <b-button
                class="m-2 ml-auto"
                variant="white"
                @click="showInactive = !showInactive"
            >
                <icon- :i="showInactive ? 'eye' : 'eye-off'" class="mx-1" />
                <span>
                    {{
                        `Đang ${
                            showInactive ? 'hiện' : 'ẩn'
                        } loại phòng đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </block-flex->
        <query-
            v-slot="{ data: { roomKinds } }"
            :query="getRoomKinds"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                show-empty
                :items="roomKindsFilter(roomKinds)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                    },
                    {
                        key: 'name',
                        label: 'Tên loại phòng',
                        sortable: true,
                    },
                    {
                        key: 'isActive',
                        label: 'Trạng thái',
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
                class="table-style table-header-line"
                @row-clicked="
                    (roomKind, $index, $event) => {
                        $event.stopPropagation();
                        if (
                            currentEvent !== null &&
                            currentEvent.type === 'dblclick'
                        ) {
                            $refs.room_kind_detail.open({ id: roomKind.id });
                            $refs.context_room_kind.close();
                        } else {
                            $refs.context_room_kind.open(
                                currentEvent || $event,
                                {
                                    roomKind,
                                },
                            );
                        }
                        currentEvent = null;
                    }
                "
            >
                <template v-slot:empty>
                    Không tìm thấy loại phòng nào Không tìm thấy dịch vụ nào
                </template>
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(isActive)="{ value }">
                    <icon-
                        i="circle-fill"
                        class="mr-1"
                        :class="`text-${roomKindColorMap(value)}`"
                    />
                    {{ roomKindTitleMap(value) }}
                </template>
                <template v-slot:cell(rooms)="{ value }">
                    {{ value.length }} phòng
                </template>
            </b-table>
        </query->
        <context-manage-room- ref="context_room" />
        <context-manage-room-kind- ref="context_room_kind" />
        <popup-room-kind-add- ref="room_kind_add" />
        <popup-room-kind-detail- ref="room_kind_detail" />
        <popup-room-kind-update- ref="room_kind_update" />
        <popup-room-detail- ref="room_detail" />
        <popup-room-update- ref="room_update" />
        <popup-price-add- ref="price_add" />
        <popup-price-volatility-add- ref="price_volatility_add" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { roomKindColorMap, roomKindTitleMap } from '~/modules/model';
import { getRoomKinds } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { GetRoomKinds } from '~/graphql/types';

@Component({
    name: 'floor-room-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getRoomKinds, roomKindColorMap, roomKindTitleMap }),
) {
    head() {
        return {
            title: 'Quản lý loại phòng',
        };
    }

    roomKindsFilter(
        roomKinds: GetRoomKinds.RoomKinds[],
    ): GetRoomKinds.RoomKinds[] {
        if (this.showInactive) return roomKinds;

        return roomKinds.filter(rk => rk.isActive);
    }

    showInactive = false;
}
</script>
