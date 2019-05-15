<template>
    <popup- ref="popup" title="Sửa dịch vụ">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { service }, close }"
            :mutation="updateService"
            :variables="{ input }"
            success="Cập nhật thông tin dịch vụ thành công"
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
                v-model="input.unitRate"
                :state="!$v.input.unitRate.$invalid"
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
                    @click="close"
                >
                    <icon- class="mr-1" i="edit-2" />
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { ServiceUpdateInput, GetServices } from 'graphql/types';
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { updateService } from '~/graphql/documents';
import { required, minLength, minValue } from 'vuelidate/lib/validators';

type PopupMixinType = PopupMixin<
    { service: GetServices.Services },
    ServiceUpdateInput
>;

@Component({
    name: 'popup-service-update-',
    validations: {
        input: {
            name: {
                required,
                minLength: minLength(1),
            },
            unitRate: {
                required,
                minLength: minValue(1000),
            },
            unit: { required },
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ updateService }),
) {
    onOpen() {
        const { id, name, unitRate, unit } = this.data.service;
        this.input = { id, name, unitRate, unit };
    }
}
</script>
