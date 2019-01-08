<template>
    <popup- ref="popup" title="Thêm phiếu thu" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            success="Thêm phiếu thu mới thành công"
            :mutation="createReceipt"
            :variables="{ input }"
        >
            <div class="input-label">Số tiền</div>
            <b-input-
                ref="autoFocus"
                v-model="input.money"
                type="number"
                :state="!$v.input.money.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Số tài khoản</div>
            <b-input-
                v-model="input.bankAccountNumber"
                type="number"
                :state="!$v.input.bankAccountNumber.$invalid"
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
                    <span class="icon mr-1"></span>
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { ReceiptCreateInput, GetBills } from '~/graphql/types';
import { PopupMixin } from '~/components/mixins/popup';
import { createReceipt } from '~/graphql/documents/receipt';
import { required } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, mixinData({ createReceipt })],
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
export default class extends PopupMixin<
    { bill: GetBills.Bills },
    ReceiptCreateInput
> {
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
