<template>
    <popup- ref="popup" title="Thêm phòng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { floors }, close }"
            success="Thêm phòng mới thành công"
            :mutation="createRoom"
            :variables="{ input }"
        >
            <div class="input-label">Tầng</div>
            <div class="m-3">
                <b-form-select
                    v-model="input.floor.id"
                    value-field="id"
                    text-field="name"
                    :state="!$v.input.floor.id.$invalid"
                    :options="floors"
                    class="rounded"
                />
            </div>
            <div class="input-label">Loại phòng</div>
            <query- :query="getRoomKinds" class="m-3" :poll-interval="0">
                <div slot-scope="{ data: { roomKinds } }">
                    <b-form-select
                        v-model="input.roomKind.id"
                        value-field="id"
                        text-field="name"
                        :state="!$v.input.roomKind.id.$invalid"
                        :options="roomKinds"
                        class="rounded"
                    />
                </div>
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
import { getRoomKinds } from '~/graphql/documents/room-kind';
import { GetFloors, RoomCreateInput } from '~/graphql/types';
import { mixinData } from '~/components/mixins/mutable';
import { required } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, mixinData({ createRoom, getRoomKinds })],
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
