<template>
    <popup- ref="popup" title="Cập nhật loại khách hàng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { patron }, close }"
            :mutation="updatePatronKind"
            :variables="{ input }"
            success="Cập nhật loại khách hàng thành công"
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
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { PatronKindUpdateInput, GetPatronKinds } from 'graphql/types';
import { Component } from 'nuxt-property-decorator';
import { PopupMixin, mixinData } from '~/components/mixins';
import { updatePatronKind } from '~/graphql/documents';
import { required } from 'vuelidate/lib/validators';

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
