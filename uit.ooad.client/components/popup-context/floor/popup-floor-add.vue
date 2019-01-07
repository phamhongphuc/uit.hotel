<template>
    <popup- ref="popup" title="Thêm tầng" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            success="Thêm tầng mới thành công"
            :mutation="createFloor"
            :variables="{ input }"
        >
            <div class="input-label">Tên tầng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
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
import { PopupMixin } from '~/components/mixins/popup';
import { createFloor } from '~/graphql/documents/floor';
import { required, minLength } from 'vuelidate/lib/validators';
import { FloorCreateInput } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ createFloor })],
    name: 'popup-floor-add-',
    validations: {
        input: {
            name: {
                required,
                minLength: minLength(1),
            },
        },
    },
})
export default class extends PopupMixin<void, FloorCreateInput> {
    onOpen() {
        this.input = {
            name: '',
        };
    }
}
</script>
