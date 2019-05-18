<template>
    <popup- ref="popup" title="Cập nhật phòng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { room }, close }"
            :mutation="updateRoom"
            :variables="{ input }"
            success="Cập nhật phòng mới thành công"
            @success="close"
        >
            <div class="input-label">Tầng</div>
            <query- :query="getFloors" :poll-interval="0" class="m-3">
                <b-form-select
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
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetFloors, RoomUpdateInput } from '~/graphql/types';
import { getFloors, updateRoom, getRoomKinds } from '~/graphql/documents';
import { required } from 'vuelidate/lib/validators';

type PopupMixinType = PopupMixin<
    {
        room: GetFloors.Rooms;
        floor: GetFloors.Floors;
    },
    RoomUpdateInput
>;

@Component({
    name: 'popup-room-add-',
    validations: {
        input: {
            name: { required },
            floor: {
                id: { required },
            },
            roomKind: {
                id: { required },
            },
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ updateRoom, getRoomKinds, getFloors }),
) {
    onOpen() {
        const {
            room: { id, name, roomKind },
            floor,
        } = this.data;

        this.input = {
            id,
            name,
            floor: {
                id: floor.id,
            },
            roomKind: {
                id: roomKind.id,
            },
        };
    }
}
</script>
