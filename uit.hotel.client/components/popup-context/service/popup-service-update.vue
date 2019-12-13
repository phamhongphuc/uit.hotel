<template>
    <popup- ref="popup" v-slot="{ close }" title="Sửa dịch vụ">
        <form-mutate-
            v-if="input"
            :mutation="updateService"
            :variables="{ input }"
            success="Cập nhật thông tin dịch vụ thành công"
            @success="close"
        >
            <div class="input-label">Tên dịch vụ</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon="type"
            />
            <div class="input-label">Đơn giá</div>
            <b-input-
                ref="autoFocus"
                v-model="input.unitPrice"
                :state="!$v.input.unitPrice.$invalid"
                class="m-3 rounded"
                icon="type"
            />
            <div class="input-label">Đơn vị</div>
            <b-input-
                ref="autoFocus"
                v-model="input.unit"
                :state="!$v.input.unit.$invalid"
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
                    <icon- class="mr-1" i="edit-2" />
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { ServiceUpdateInput, GetServices } from '~/graphql/types';
import { updateService } from '~/graphql/documents';
import { serviceName, unit, currency } from '~/modules/validator';

type PopupMixinType = PopupMixin<
    { service: GetServices.Services },
    ServiceUpdateInput
>;

@Component({
    name: 'popup-service-update-',
    validations: {
        input: {
            name: serviceName,
            unitPrice: currency,
            unit,
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ updateService }),
) {
    onOpen() {
        const { id, name, unitPrice, unit } = this.data.service;

        this.input = { id, name, unitPrice, unit };
    }
}
</script>
