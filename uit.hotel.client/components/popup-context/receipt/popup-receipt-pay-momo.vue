<template>
    <popup-
        ref="popup"
        v-slot
        title="Thanh toán Momo"
        class="popup-receipt-pay-momo"
        child-class="w-100 h-100"
    >
        <query-
            v-if="isPending"
            v-slot
            :query="getReceipt"
            :variables="variables"
            :poll-interval="500"
            class="w-100 h-100"
            child-class="w-100 h-100"
            @result="onResult"
        >
            <iframe
                :src="receipt.payUrl"
                sandbox="allow-scripts allow-same-origin"
                frameborder="0"
                class="d-block w-100 h-100"
            />
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { getReceipt, checkReceipt } from '~/graphql/documents';
import {
    CheckReceipt,
    GetBill,
    GetReceipt,
    GetReceiptQuery,
    ReceiptStatusEnum,
} from '~/graphql/types';
import { apolloClientNotify } from '~/modules/apollo';
import { notify } from '~/plugins/notify';

type PopupMixinType = PopupMixin<{ receipt: GetBill.Receipts }, null>;

@Component({
    name: 'popup-receipt-pay-momo-',
    validations: {},
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({
        getReceipt,
    }),
) {
    receipt!: GetReceipt.Receipt;
    variables!: GetReceipt.Variables;
    isPending = false;

    async onOpen() {
        const id = this.data.receipt.id.toString();
        this.variables = { id };

        const { data } = await apolloClientNotify({ app: this }).mutate<
            CheckReceipt.Mutation,
            CheckReceipt.Variables
        >({ mutation: checkReceipt, variables: { id } });

        if (!data) {
            notify.error({
                title: 'Lỗi không xác định',
                type: 'error',
            });
            this.close();
            return;
        }
        this.checkStatus(data.checkReceipt);
    }

    async onResult({ data: { receipt } }: ApolloQueryResult<GetReceiptQuery>) {
        this.receipt = receipt;
        this.checkStatus(receipt);
    }

    checkStatus({
        status,
        statusText,
    }: GetReceipt.Receipt | CheckReceipt.CheckReceipt) {
        switch (status) {
            case ReceiptStatusEnum.Error:
            case ReceiptStatusEnum.SystemError:
                notify.error({ title: statusText });
                this.isPending = false;
                setTimeout(this.close, 1000);
                break;
            case ReceiptStatusEnum.Success:
                notify.success({ title: statusText });
                this.isPending = false;
                setTimeout(this.close, 1000);
                break;
            case ReceiptStatusEnum.Pending:
            default:
                this.isPending = true;
                break;
        }
    }
}
</script>
<style lang="scss">
.popup-receipt-pay-momo {
    .popup-modal {
        max-width: 800px;
        &-content {
            display: flex;
            flex-direction: column;
            width: 100%;
            height: 100%;
            overflow: hidden;
            > .query {
                height: 100%;
            }
        }
    }

    .toolbar {
        border-bottom: 1.5px solid $border-color;
    }
}
</style>
