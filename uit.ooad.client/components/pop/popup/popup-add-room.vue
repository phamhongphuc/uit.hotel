<template>
    <popup- ref="popup" title="Thêm phòng">
        <form-mutate-
            slot-scope="{ data: { floor, floors }, close }"
            success="Thêm phòng mới thành công"
            :mutation="createRoom"
            :variables="{
                input: {
                    name: roomName,
                    isActive: true,
                    floor: {
                        id: floorId,
                    },
                    roomKind: {
                        id: 1,
                    },
                },
            }"
        >
            <div class="input-label">Tầng</div>
            <div class="m-3">
                <b-form-select
                    v-model="floorId"
                    value-field="id"
                    text-field="name"
                    :value="1"
                    :options="floors"
                    class="rounded"
                />
            </div>
            <div class="input-label">Loại phòng</div>
            <query- :query="getRoomKinds" class="m-3" :poll-interval="0">
                <div slot-scope="{ data }">
                    <b-form-select
                        v-model="roomKindId"
                        value-field="id"
                        text-field="name"
                        :value="1"
                        :options="data.roomKinds"
                        class="rounded"
                    />
                </div>
            </query->
            <div class="input-label">Tên phòng</div>
            <b-input-
                ref="autoFocus"
                v-model="roomName"
                class="m-3 rounded"
                icon=""
            />
            <div class="m-3 d-flex">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    @click="close"
                >
                    <span class="icon"></span>
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { PopupMixin } from '~/components/mixins/popup';
import { createRoom, getRoomKinds } from '~/graphql/documents/floor-room';
import { GetFloors } from '~/graphql/types';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    mixins: [PopupMixin, mixinData({ createRoom, getRoomKinds })],
    name: 'popup-add-room-',
})
export default class extends PopupMixin {
    roomName: string = '';
    floorId: number | null = null;
    roomKindId: number | null = null;

    onOpen() {
        const data = this.data as {
            floor: GetFloors.Floors;
            floors: GetFloors.Floors[];
        };
        this.floorId = data.floor.id;
        this.roomName = '';
    }
}
</script>
<style lang="scss">
.input-label {
    padding: 0.25rem;
    margin: -0.5rem 1rem -1rem;

    &:first-child {
        margin-top: 0.5rem;
    }
}
</style>
