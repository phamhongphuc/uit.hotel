<template>
    <popup- ref="popup" title="Cập nhật loại khách hàng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { patron }, close }"
            success="Cập nhật loại khách hàng thành công"
            :mutation="updatePatronKind"
            :variables="{ input }"
        >
            <div class="input-label">Tên loại khách hàng</div>
            <b-input-
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                autocomplete="new-password"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Mô tả</div>
            <b-input-
                v-model="input.description"
                :state="!$v.input.description.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="m-3">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
                    @click="close"
                >
                    <span class="icon mr-1"></span>
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { PopupMixin } from '~/components/mixins/popup';
import { updatePatronKind } from '~/graphql/documents/patronKind';
import { mixinData } from '~/components/mixins/mutable';
import { required } from 'vuelidate/lib/validators';
import { PatronKindUpdateInput, GetPatronKinds } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ updatePatronKind })],
    name: 'popup-patron-update-',
    validations: {
        input: {
            name: { required },
            description: { required },
        },
    },
})
export default class extends PopupMixin<
    { patronKind: GetPatronKinds.PatronKinds },
    PatronKindUpdateInput
> {
    phoneNumbers: string = '';
    onOpen() {
        const patronKind: GetPatronKinds.PatronKinds = this.data.patronKind;
        this.input = {
            id: patronKind.id,
            description: patronKind.description,
            name: patronKind.name,
        };
    }
}
</script>
