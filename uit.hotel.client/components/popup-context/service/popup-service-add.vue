<template>
    <popup- ref="popup" v-slot="{ close }" title="Thêm dịch vụ" no-data>
        <form-mutate-
            v-if="input"
            :mutation="createService"
            :variables="{ input }"
            success="Thêm dịch vụ mới thành công"
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
            <b-input-money-
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
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { ServiceCreateInput } from '~/graphql/types';
import { createService } from '~/graphql/documents';
import { currency, serviceName, unit } from '~/modules/validator';

@Component({
    name: 'popup-service-add-',
    validations: {
        input: {
            name: serviceName,
            unitPrice: currency,
            unit,
        },
    },
})
export default class extends mixins<PopupMixin<void, ServiceCreateInput>>(
    PopupMixin,
    DataMixin({ createService }),
) {
    onOpen() {
        this.input = {
            name: '',
            unitPrice: 10000,
            unit: 'đơn vị',
        };
    }
}
</script>
