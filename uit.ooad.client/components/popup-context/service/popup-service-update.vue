<template>
    <popup- ref="popup" title="Sửa dịch vụ">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { service }, close }"
            success="Cập nhật thông tin dịch vụ thành công"
            :mutation="updateService"
            :variables="{ input }"
        >
            <div class="input-label">Tên dịch vụ</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Đơn giá</div>
            <b-input-
                ref="autoFocus"
                v-model="input.unitRate"
                :state="!$v.input.unitRate.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Đơn vị</div>
            <b-input-
                ref="autoFocus"
                v-model="input.unit"
                :state="!$v.input.unit.$invalid"
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
                    <span class="icon mr-1"></span>
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { updateService } from '~/graphql/documents/service';
import { required, minLength, minValue } from 'vuelidate/lib/validators';
import { ServiceUpdateInput, GetServices } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ updateService })],
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
export default class extends PopupMixin<
    { service: GetServices.Services },
    ServiceUpdateInput
> {
    onOpen() {
        const { id, name, unitRate, unit } = this.data.service;
        this.input = { id, name, unitRate, unit };
    }
}
</script>
