<template>
    <popup- ref="popup" title="Thêm phòng">
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="createRoom"
            :variables="{ input }"
            success="Thêm phòng mới thành công"
            @success="close"
        >
            <div class="input-label">Tầng</div>
            <query- :query="getFloors" :poll-interval="0" class="m-3">
                <b-form-select
                    ref="floor"
                    v-model="input.floor.id"
                    slot-scope="{ data: { floors } }"
                    :state="!$v.input.floor.$invalid"
                    :options="floors"
                    value-field="id"
                    text-field="name"
                    class="rounded"
                />
            </query->
            <div class="input-label">Loại phòng</div>
            <query- :query="getRoomKinds" :poll-interval="0" class="m-3">
                <b-form-select
                    ref="roomKind"
                    v-model="input.roomKind.id"
                    slot-scope="{ data: { roomKinds } }"
                    :state="!$v.input.roomKind.id.$invalid"
                    :options="roomKinds"
                    value-field="id"
                    text-field="name"
                    class="rounded"
                />
            </query->
            <div class="input-label">Tên phòng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon="type"
            />
            <div class="m-3">
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    type="submit"
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins, Vue } from 'nuxt-property-decorator';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { createRoom, getFloors, getRoomKinds } from '~/graphql/documents';
import { GetFloors, RoomCreateInput } from '~/graphql/types';
import { floorRoomName, included } from '~/modules/validator';

type PopupMixinType = PopupMixin<{ floor: GetFloors.Floors }, RoomCreateInput>;

@Component({
    name: 'popup-room-add-',
    validations: {
        input: {
            name: floorRoomName,
            floor: included('floor'),
            roomKind: included('roomKind'),
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ createRoom, getRoomKinds, getFloors }),
) {
    onOpen() {
        this.input = {
            name: '',
            floor: { id: -1 },
            roomKind: { id: -1 },
        };
    }

    async onResult() {
        if (this.input === null) return;
        await Vue.nextTick();
        this.input.floor.id = this.data.floor.id;
        this.$v.$touch();
    }
}
</script>
