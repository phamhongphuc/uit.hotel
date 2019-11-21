<template>
    <popup-
        ref="popup"
        v-slot="{ close }"
        :no-data="true"
        title="Thêm loại phòng"
    >
        <form-mutate-
            v-if="input"
            :mutation="createRoomKind"
            :variables="{ input }"
            success="Thêm loại phòng mới thành công"
            @success="close"
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
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { RoomKindCreateInput } from '~/graphql/types';
import { createRoomKind } from '~/graphql/documents';
import {
    amountOfPeople,
    numberOfBeds,
    roomKindName,
} from '~/modules/validator';

@Component({
    name: 'popup-room-kind-add-',
    validations: {
        input: {
            name: roomKindName,
            numberOfBeds,
            amountOfPeople,
        },
    },
})
export default class extends mixins<PopupMixin<void, RoomKindCreateInput>>(
    PopupMixin,
    DataMixin({ createRoomKind }),
) {
    onOpen() {
        this.input = {
            name: '',
            numberOfBeds: 1,
            amountOfPeople: 1,
        };
    }
}
</script>
