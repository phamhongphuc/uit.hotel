<template>
    <popup- ref="popup" title="Thêm phiếu thu" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="createReceipt"
            :variables="{ input }"
            success="Thêm phiếu thu mới thành công"
        >
            <div class="input-label">Số tiền</div>
            <b-input-
                ref="autoFocus"
                v-model="input.money"
                :state="!$v.input.money.$invalid"
                type="number"
                class="m-3 rounded"
                icon="type"
            />
            <div class="input-label">Số tài khoản</div>
            <b-input-
                v-model="input.bankAccountNumber"
                :state="!$v.input.bankAccountNumber.$invalid"
                type="number"
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
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { ReceiptCreateInput, GetBills } from '~/graphql/types';
import { createReceipt } from '~/graphql/documents';
import { required } from 'vuelidate/lib/validators';

type PopupMixinType = PopupMixin<{ bill: GetBills.Bills }, ReceiptCreateInput>;

@Component({
    name: 'popup-receipt-add-',
    validations: {
        input: {
            money: {
                required,
            },
            bankAccountNumber: {},
            bill: {
                required,
            },
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ createReceipt }),
) {
    onOpen() {
        this.input = {
            money: 0,
            bankAccountNumber: '',
            bill: {
                id: this.data.bill.id,
            },
        };
    }
}
</script>
