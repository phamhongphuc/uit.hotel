<template>
    <popup- ref="popup" title="Thêm vị trí" no-data="true">
        <form-mutate-
            slot-scope="{ close }"
            success="Thêm vị trí mới thành công"
            :mutation="createPosition"
            :variables="{
                input: {
                    name: positionName,
                },
            }"
        >
            <div class="input-label">Tên vị trí</div>
            <b-input-
                ref="autoFocus"
                v-model="positionName"
                :state="!$v.positionName.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Quyền</div>
            <b-form-checkbox-group
                v-model="selected"
                class="m-3"
                buttons
                stacked
                size="sm"
                button-variant="main"
                :options="positionOptions"
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
import { createPosition, positionOptions } from '~/graphql/documents/position';
import { mixinData } from '~/components/mixins/mutable';
import { required } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, mixinData({ createPosition })],
    name: 'popup-position-add-',
    validations: {
        positionName: {
            required,
        },
    },
})
export default class extends PopupMixin {
    positionName: string = '';
    selected = [];

    positionOptions = positionOptions;

    onOpen() {
        this.positionName = '';
        this.selected = [];
    }
}
</script>
