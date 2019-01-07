<template>
    <popup- ref="popup" title="Thêm phòng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { floor }, close }"
            success="Thêm phòng mới thành công"
            :mutation="createRoom"
            :variables="{ input }"
        >
            <div class="input-label">Tầng</div>
            <query- :query="getFloors" class="m-3" :poll-interval="0">
                <b-form-select
                    v-model="input.floor.id"
                    slot-scope="{ data: { floors } }"
                    value-field="id"
                    text-field="name"
                    :state="!$v.input.floor.$invalid"
                    :options="floors"
                    class="rounded"
                />
            </query->
            <div class="input-label">Loại phòng</div>
            <query- :query="getRoomKinds" class="m-3" :poll-interval="0">
                <b-form-select
                    v-model="input.roomKind.id"
                    slot-scope="{ data: { roomKinds } }"
                    value-field="id"
                    text-field="name"
                    :state="!$v.input.roomKind.id.$invalid"
                    :options="roomKinds"
                    class="rounded"
                />
            </query->
            <div class="input-label">Tên phòng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="m-3">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
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
import { createRoom } from '~/graphql/documents/room';
import { getFloors } from '~/graphql/documents/floor';
import { getRoomKinds } from '~/graphql/documents/room-kind';
import { GetFloors, RoomCreateInput } from '~/graphql/types';
import { mixinData } from '~/components/mixins/mutable';
import { required } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, mixinData({ createRoom, getRoomKinds, getFloors })],
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
export default class extends PopupMixin<
    { floor: GetFloors.Floors },
    RoomCreateInput
> {
    onOpen() {
        this.input = {
            name: '',
            floor: {
                id: this.data.floor.id,
            },
            roomKind: {
                id: 1,
            },
        };
    }
}
</script>
