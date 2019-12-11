<template>
    <context- ref="context" v-slot="{ data: { bill, bill: { id } } }">
        <b-nav-item-icon-
            icon="info"
            text="Chi tiết hóa đơn"
            @click="refs.bill_detail.open({ id })"
        />
        <b-nav-item-icon-
            v-if="moment(bill.time).year() === 1"
            icon="invoice-1"
            text="Tạo phiếu thu"
            @click="refs.receipt_add.open({ bill })"
        />
        <b-nav-item-icon-mutate-
            v-if="moment(bill.time).year() === 1"
            :mutation="payTheBill"
            :variables="{ id }"
            icon="invoice-3"
            text="Chốt hóa đơn"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import moment from 'moment';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { payTheBill } from '~/graphql/documents';

@Component({
    name: 'context-manage-bill-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ payTheBill, moment }),
) {}
</script>
