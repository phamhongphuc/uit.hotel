<template>
    <popup- ref="popup" title="Cập nhật loại phòng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { roomKind }, close }"
            success="Cập nhật loại phòng mới thành công"
            :mutation="updateRoomKind"
            :variables="{ input }"
        >
            <div class="input-label">Tên loại phòng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Số giường</div>
            <b-input-
                v-model="input.numberOfBeds"
                type="number"
                :min="1"
                :max="5"
                :state="!$v.input.numberOfBeds.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Số người</div>
            <b-input-
                v-model="input.amountOfPeople"
                type="number"
                :min="1"
                :max="10"
                :state="!$v.input.amountOfPeople.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="d-flex m-3">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
                    @click="close"
                >
                    <span class="icon"></span>
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { GetRoomKinds, RoomKindUpdateInput } from '~/graphql/types';
import { PopupMixin } from '~/components/mixins/popup';
import { updateRoomKind } from '~/graphql/documents/room-kind';
import { required, minLength, between } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, mixinData({ updateRoomKind })],
    name: 'popup-room-kind-add-',
    validations: {
        input: {
            name: {
                required,
                minLength: minLength(1),
            },
            numberOfBeds: {
                required,
                between: between(1, 5),
            },
            amountOfPeople: {
                required,
                between: between(1, 10),
            },
        },
    },
})
export default class extends PopupMixin<
    { roomKind: GetRoomKinds.RoomKinds },
    RoomKindUpdateInput
> {
    onOpen() {
        const { id, name, numberOfBeds, amountOfPeople } = this.data.roomKind;
        this.input = { id, name, numberOfBeds, amountOfPeople };
    }
}
</script>
