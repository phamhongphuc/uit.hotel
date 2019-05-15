<template>
    <popup- ref="popup" title="Thêm dịch vụ" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="createService"
            :variables="{ input }"
            success="Thêm dịch vụ mới thành công"
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
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { ServiceCreateInput } from 'graphql/types';
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { createService } from '~/graphql/documents';
import { required, minLength, minValue } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, DataMixin({ createService })],
    name: 'popup-service-add-',
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
export default class extends mixins<PopupMixin<void, ServiceCreateInput>>(
    PopupMixin,
) {
    onOpen() {
        this.input = {
            name: '',
            unitRate: 10000,
            unit: 'đơn vị',
        };
    }
}
</script>
