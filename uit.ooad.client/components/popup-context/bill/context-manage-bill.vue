<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { bill, bills }, refs }">
            <b-nav-item-icon-
                icon=""
                text="Tạo phiếu thu"
                @click="refs.receipt_add.open({ bill })"
            />
            <b-nav-item-icon-mutate-
                icon=""
                text="Chốt hóa đơn"
                :mutation="payTheBill"
                :variables="{ id: bill.id }"
                @click="refs.receipt_add.open({ bill })"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import { mixinData } from '~/components/mixins/mutable';
import { payTheBill } from '~/graphql/documents/bill';

@Component({
    name: 'context-manage-bill-',
    mixins: [ContextMixin, mixinData({ payTheBill })],
})
export default class extends ContextMixin {}
</script>
