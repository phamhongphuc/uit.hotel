<template>
    <popup- ref="popup" :no-data="true" title="Thêm loại phòng">
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="createRoomKind"
            :variables="{ input }"
            success="Thêm loại phòng mới thành công"
        >
            <div class="input-label">Tên loại phòng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon="type"
            />
            <div class="input-label">Số giường</div>
            <b-input-
                v-model="input.numberOfBeds"
                :min="1"
                :max="5"
                :state="!$v.input.numberOfBeds.$invalid"
                type="number"
                class="m-3 rounded"
                icon="type"
            />
            <div class="input-label">Số người</div>
            <b-input-
                v-model="input.amountOfPeople"
                :min="1"
                :max="10"
                :state="!$v.input.amountOfPeople.$invalid"
                type="number"
                class="m-3 rounded"
                icon="type"
            />
            <div class="d-flex m-3">
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    @click="close"
                >
                    <icon- class="mr-1" i="plus" />
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
