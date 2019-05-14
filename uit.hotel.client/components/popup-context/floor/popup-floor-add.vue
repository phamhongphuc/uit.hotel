<template>
    <popup- ref="popup" title="Thêm tầng" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="createFloor"
            :variables="{ input }"
            success="Thêm tầng mới thành công"
        >
            <div class="input-label">Tên tầng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
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
import { FloorCreateInput } from 'graphql/types';
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { createFloor } from '~/graphql/documents/floor';
import { required, minLength } from 'vuelidate/lib/validators';

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
