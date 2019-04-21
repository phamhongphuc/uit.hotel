<template>
    <popup- ref="popup" title="Thêm khách hàng" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="createPatronKind"
            :variables="{ input }"
            success="Thêm khách hàng mới thành công"
        >
            <div class="input-label">Tên loại khách hàng</div>
            <b-input-
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                autocomplete="new-password"
                class="m-3 rounded"
                icon="type"
            />
            <div class="input-label">Mô tả</div>
            <b-input-
                v-model="input.description"
                :state="!$v.input.description.$invalid"
                class="m-3 rounded"
                icon="package"
            />
            <div class="m-3">
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
import { PopupMixin } from '~/components/mixins/popup';
import { createPatronKind } from '~/graphql/documents/patronKind';
import { mixinData } from '~/components/mixins/mutable';
import { required } from 'vuelidate/lib/validators';
import { PatronKindCreateInput } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ createPatronKind })],
    name: 'popup-patron-kind-add-',
    validations: {
        input: {
            name: { required },
            description: { required },
        },
    },
})
export default class extends PopupMixin<void, PatronKindCreateInput> {
    onOpen() {
        this.input = {
            name: '',
            description: '',
        };
    }
}
</script>
