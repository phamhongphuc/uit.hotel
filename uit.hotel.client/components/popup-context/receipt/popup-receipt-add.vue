<template>
    <popup- ref="popup" v-slot="{ close }" title="Thêm phiếu thu" no-data>
        <form-mutate-
            v-if="input"
            :mutation="createReceipt"
            :variables="{ input }"
            success="Thêm phiếu thu mới thành công"
            @success="close"
        >
            <div class="input-label">Hình thức</div>
            <b-radio-group
                v-model="input.kind"
                class="m-3 receipt-kind-radio-group"
                buttons
            >
                <b-radio name="some-radios" :value="ReceiptKindEnum.Cash">
                    Tiền mặt
                </b-radio>
                <b-radio name="some-radios" :value="ReceiptKindEnum.Momo">
                    Ví momo
                </b-radio>
            </b-radio-group>
            <div class="input-label">Số tiền</div>
            <b-input-money-
                ref="autoFocus"
                v-model="input.money"
                :state="!$v.input.money.$invalid"
                type="number"
                class="m-3 rounded"
                icon="type"
            />
            <div class="my-1 mx-3 font-weight-medium text-right">
                Chưa thanh toán:
                <span class="text-blue">
                    {{
                        toMoney(
                            data.bill.totalPrice -
                                data.bill.totalReceipts -
                                data.bill.discount,
                        )
                    }}
                </span>
            </div>
            <div class="my-1 mx-3 font-weight-medium text-right">
                Thanh toán:
                <span class="text-green">
                    {{ toMoney(input.money) }}
                </span>
            </div>
            <div class="my-1 mx-3 font-weight-medium text-right">
                Còn lại:
                <span class="text-green">
                    {{
                        toMoney(
                            data.bill.totalPrice -
                                data.bill.totalReceipts -
                                data.bill.discount -
                                input.money,
                        )
                    }}
                </span>
            </div>
            <div class="d-flex m-3">
                <b-button
                    v-b-tooltip.bottom.window="
                        'Nhập số tiền bằng phần còn lại của hóa đơn'
                    "
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="lighten"
                    @click="autoMoney"
                >
                    <icon- class="mr-1" i="activity" />
                    <span>Tự động</span>
                </b-button>
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-2"
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
import { ReceiptCreateInput, GetBills, ReceiptKindEnum } from '~/graphql/types';
import { createReceipt } from '~/graphql/documents';
import { optional, currency } from '~/modules/validator';
import { toMoney, toPercent } from '~/utils';

type PopupMixinType = PopupMixin<{ bill: GetBills.Bills }, ReceiptCreateInput>;

@Component({
    name: 'popup-receipt-add-',
    validations: {
        input: {
            money: currency,
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ createReceipt, optional, ReceiptKindEnum, toMoney, toPercent }),
) {
    onOpen() {
        this.input = {
            money: 0,
            kind: ReceiptKindEnum.Cash,
            bill: {
                id: this.data.bill.id,
            },
        };
    }

    autoMoney() {
        const { totalPrice, totalReceipts, discount } = this.data.bill;

        if (this.input !== null)
            this.input.money = totalPrice - totalReceipts - discount;
    }
}
</script>
<style lang="scss">
.receipt-kind-radio-group {
    > * {
        background-color: $input-bg;
        &:active {
            box-shadow: none !important;
        }
        &.active {
            color: $white;
            background-color: $blue;
            box-shadow: none !important;
        }
    }
}
</style>
