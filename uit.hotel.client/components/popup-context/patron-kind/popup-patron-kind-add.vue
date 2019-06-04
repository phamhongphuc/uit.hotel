<template>
    <popup- ref="popup" title="Thêm khách hàng" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="createPatronKind"
            :variables="{ input }"
            success="Thêm khách hàng mới thành công"
            @success="close"
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
import { PopupMixin, DataMixin } from '~/components/mixins';
import { PatronKindCreateInput } from '~/graphql/types';
import { createPatronKind } from '~/graphql/documents';
import { patronKindDescription, patronKindName } from '~/modules/validator';

@Component({
    name: 'popup-patron-kind-add-',
    validations: {
        input: {
            name: patronKindName,
            description: patronKindDescription,
        },
    },
})
export default class extends mixins<PopupMixin<void, PatronKindCreateInput>>(
    PopupMixin,
    DataMixin({ createPatronKind }),
) {
    onOpen() {
        this.input = {
            name: '',
            description: '',
        };
    }
}
</script>
