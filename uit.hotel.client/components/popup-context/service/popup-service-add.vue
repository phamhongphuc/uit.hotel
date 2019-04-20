<template>
    <popup- ref="popup" title="Thêm dịch vụ" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            success="Thêm dịch vụ mới thành công"
            :mutation="createService"
            :variables="{ input }"
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
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
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
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { createService } from '~/graphql/documents/service';
import { required, minLength, minValue } from 'vuelidate/lib/validators';
import { ServiceCreateInput } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ createService })],
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
export default class extends PopupMixin<void, ServiceCreateInput> {
    onOpen() {
        this.input = {
            name: '',
            unitRate: 10000,
            unit: 'đơn vị',
        };
    }
}
</script>
