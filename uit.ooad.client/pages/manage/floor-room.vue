<template>
    <div>
        <div class="row">
            <b-button
                class="m-2 shadow"
                size="md"
                variant="white"
                @click="showDisable = !showDisable"
            >
                <span class="icon mr-1">{{ showDisable ? '' : '' }}</span>
                <span>
                    {{
                        showDisable
                            ? 'Đang hiện phòng và tầng đã bị vô hiệu hóa'
                            : 'Đang ẩn phòng và tầng đã bị vô hiệu hóa'
                    }}
                </span>
            </b-button>
        </div>
        <div class="row flex-1 p-2">
            <div class="col bg-white shadow rounded overflow-auto">
                <gql-query- :query="getFloors" class="row hotel-map">
                    <div slot-scope="{ data }" class="m-3">
                        <div
                            v-for="floor in floorsFilter(data.floors)"
                            :key="floor.id"
                            class="d-flex hotel-map-floor flex-nowrap"
                        >
                            <b-button
                                class="hotel-map-floor-name border-0"
                                variant="main"
                                @contextmenu.prevent="
                                    $refs.floor_context.open($event, floor)
                                "
                            >
                                {{ floor.name }} {{ floor.isActive }}
                            </b-button>
                            <b-button
                                v-for="room in roomsFilter(floor.rooms)"
                                :key="room.id"
                                class="hotel-map-floor-room"
                                variant="white"
                                @contextmenu.prevent="
                                    $refs.room_context.open($event, room)
                                "
                            >
                                {{ room.name }} {{ room.isActive }}
                            </b-button>
                            <b-button-mutate-
                                class="hotel-map-floor-room button-new"
                                variant="white"
                                success="Thêm phòng mới thành công"
                                :mutation="createRoom"
                                :variables="{
                                    input: {
                                        name: 'phòng',
                                        isActive: true,
                                        floor: {
                                            id: floor.id,
                                        },
                                        roomKind: {
                                            id: 1,
                                        },
                                    },
                                }"
                            >
                                <span class="icon"></span>
                                Thêm
                            </b-button-mutate->
                        </div>
                        <div class="d-flex hotel-map-floor">
                            <b-button-mutate-
                                class="hotel-map-floor-name button-new"
                                variant="main"
                                success="Thêm tầng mới thành công"
                                :mutation="createFloor"
                                :variables="{
                                    input: {
                                        name: 'Tầng 2',
                                        isActive: true,
                                    },
                                }"
                            >
                                <span class="icon"></span>
                                Thêm
                            </b-button-mutate->
                        </div>
                    </div>
                </gql-query->
            </div>
        </div>
        <context- ref="room_context">
            <template slot-scope="{ data }">
                <b-nav-item-icon- icon="" text="Xem thông tin chi tiết" />
                <div class="context-hr" />
                <b-nav-item-icon- icon="" text="Sửa thông tin phòng" />
                <b-nav-item-icon-mutate-
                    :mutation="setIsActiveRoom"
                    :variables="{ id: data.id, isActive: !data.isActive }"
                    :icon="data.isActive ? '' : ''"
                    :text="
                        data.isActive
                            ? 'Vô hiệu hóa phòng'
                            : 'Kích hoạt lại phòng'
                    "
                    @click="action(mutate)"
                />
                <b-nav-item-icon-mutate-
                    :mutation="deleteRoom"
                    :variables="{ id: data.id }"
                    icon=""
                    text="Xóa phòng"
                    @click="action(mutate)"
                />
            </template>
        </context->
        <context- ref="floor_context">
            <template slot-scope="{ data }">
                <b-nav-item-icon- icon="" text="Sửa thông tin tầng" />
                <b-nav-item-icon-mutate-
                    :mutation="setIsActiveFloor"
                    :variables="{ id: data.id, isActive: !data.isActive }"
                    :icon="data.isActive ? '' : ''"
                    :text="
                        data.isActive
                            ? 'Vô hiệu hóa tầng'
                            : 'Kích hoạt lại tầng'
                    "
                    @click="action(mutate)"
                />
                <b-nav-item-icon-mutate-
                    :mutation="deleteFloor"
                    :variables="{ id: data.id }"
                    icon=""
                    text="Xóa tầng"
                    @click="action(mutate)"
                />
            </template>
        </context->
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import * as mutation from '~/graphql/documents/floor-room';
import { mixinData } from '~/components/mixins/mutable';
import { GetFloors } from '~/graphql/types';

@Component({
    name: 'index-',
    mixins: [mixinData(mutation)],
})
export default class extends Vue {
    head() {
        return {
            title: 'Sơ đồ khách sạn',
        };
    }

    floorsFilter(floors: GetFloors.Floors[]): GetFloors.Floors[] {
        if (this.showDisable) return floors;
        return floors.filter(f => f.isActive);
    }

    roomsFilter(rooms: GetFloors.Rooms[]): GetFloors.Rooms[] {
        if (this.showDisable) return rooms;
        return rooms.filter(r => r.isActive);
    }

    showDisable: boolean = false;
}
</script>
<style lang="scss">
.hotel-map {
    .hotel-map-floor {
        button {
            border-width: 2px;
            border-color: $border-color;
            padding: 0.75rem;
            margin: 0.25rem;
            min-width: 120px;
        }
    }
}

.button-new {
    border: 2px $border-color dashed;
    &:hover {
        background: rgba($black, 0.05);
    }
}
</style>
