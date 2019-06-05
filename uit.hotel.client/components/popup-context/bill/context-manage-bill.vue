<template>
    <context- ref="context" v-slot="{ data: { bill }, refs }" :refs="refs">
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
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { payTheBill } from '~/graphql/documents';
import moment from 'moment';

@Component({
    name: 'context-manage-bill-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ payTheBill, moment }),
) {}
</script>
