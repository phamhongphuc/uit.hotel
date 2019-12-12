<template>
    <popup-
        ref="popup"
        v-slot="{ close }"
        title="Cập nhật giảm giá cho hóa đơn"
    >
        <form-mutate-
            v-if="input"
            :mutation="updateBillDiscount"
            :variables="{ input }"
            success="Cập nhật giảm giá thành công"
            @success="close"
        >
            <div class="input-label">Giảm giá</div>
            <b-input-money-
                v-model="input.discount"
                :state="!$v.input.discount.$invalid"
                class="mx-3 mt-3 mb-2 rounded"
                icon="type"
                type="number"
                text-field="name"
                value-field="id"
            />
            <div class="my-1 mx-3 font-weight-medium text-right">
                Tổng cộng:
                <span class="text-blue">
                    {{ toMoney(data.bill.totalPrice) }}
                </span>
            </div>
            <div class="my-1 mx-3 font-weight-medium text-right">
                Đã giảm:
                <span class="text-green">
                    {{ toPercent(input.discount / data.bill.totalPrice) }}
                </span>
            </div>
            <div class="my-1 mx-3 font-weight-medium text-right">
                Giá sau khi giảm:
                <span class="text-green">
                    {{ toMoney(data.bill.totalPrice - input.discount) }}
                </span>
            </div>
            <div class="d-flex mx-3 mt-2 mb-3">
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    type="submit"
                >
                    <icon- class="mr-1" i="check" />
                    <span>Xong</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { required, integer } from 'vuelidate/lib/validators';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { BillUpdateDiscountInput, GetBill } from '~/graphql/types';
import { updateBillDiscount } from '~/graphql/documents';
import { toMoney, toPercent, toNumber } from '~/utils';

type PopupMixinType = PopupMixin<
    {
        bill: GetBill.Bill;
    },
    BillUpdateDiscountInput
>;

@Component({
    name: 'popup-bill-update-discount-',
    validations: {
        input: {
            discount: {
                required,
                integer,
                lessThanTotalPrice(value: string | number) {
                    return (
                        toNumber(value) <
                        (this as PopupBillUpdateDiscount).data.bill.totalPrice
                    );
                },
            },
        },
    },
})
export default class PopupBillUpdateDiscount extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ updateBillDiscount, toMoney, toPercent }),
) {
    roomName = '';

    onOpen() {
        this.input = {
            id: this.data.bill.id,
            discount: this.data.bill.discount,
        };
    }
}
</script>
