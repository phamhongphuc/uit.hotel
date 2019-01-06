<template>
    <popup- ref="popup" title="Thêm loại phòng" no-data="true">
        <form-mutate-
            slot-scope="{ close }"
            success="Thêm loại phòng mới thành công"
            :mutation="createRoomKind"
            :variables="{
                input,
            }"
        >
            <div class="input-label">Tên loại phòng</div>
            <b-input-
                ref="autoFocus"
                v-model="roomKindName"
                :state="!$v.roomKindName.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Số giường</div>
            <b-input-
                v-model="numberOfBeds"
                type="number"
                :min="1"
                :max="5"
                :state="!$v.numberOfBeds.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Số người</div>
            <b-input-
                v-model="amountOfPeople"
                type="number"
                :min="1"
                :max="10"
                :state="!$v.amountOfPeople.$invalid"
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
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { RoomKindCreateInput } from '~/graphql/types';
import { PopupMixin } from '~/components/mixins/popup';
import { createRoomKind } from '~/graphql/documents/room-kind';
import { required, minLength, between } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, mixinData({ createRoomKind })],
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
export default class extends PopupMixin<void, RoomKindCreateInput> {
    onOpen() {
        this.input = {
            name: '',
            numberOfBeds: 1,
            amountOfPeople: 1,
        };
    }
}
</script>
