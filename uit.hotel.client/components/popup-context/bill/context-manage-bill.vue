<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { bill, bills }, refs }">
            <b-nav-item-icon-
                v-if="moment(bill.time).year() === 1"
                icon="dollar-sign"
                text="Tạo phiếu thu"
                @click="refs.receipt_add.open({ bill })"
            />
            <b-nav-item-icon-mutate-
                v-if="moment(bill.time).year() === 1"
                :mutation="payTheBill"
                :variables="{ id: bill.id }"
                icon="dollar-sign"
                text="Chốt hóa đơn"
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
import moment from 'moment';

@Component({
    name: 'context-manage-bill-',
    mixins: [ContextMixin, mixinData({ payTheBill, moment })],
})
export default class extends ContextMixin {}
</script>
