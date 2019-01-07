<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { bill, bills }, refs }">
            <b-nav-item-icon-
                v-if="bill.isActive"
                icon=""
                text="Sửa thông tin hóa đơn"
                @click="refs.bill_update.open({ bill })"
            />
            <b-nav-item-icon-mutate-
                :mutation="setIsActiveBill"
                :variables="{ id: bill.id, isActive: !bill.isActive }"
                :icon="bill.isActive ? '' : ''"
                :text="
                    bill.isActive
                        ? 'Vô hiệu hóa hóa đơn'
                        : 'Kích hoạt lại hóa đơn'
                "
            />
            <b-nav-item-icon-mutate-
                v-if="bill.isActive"
                :mutation="deleteBill"
                :variables="{ id: bill.id }"
                icon=""
                text="Xóa hóa đơn"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import {} from '~/graphql/documents/bill';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    name: 'context-manage-bill-',
    mixins: [ContextMixin, mixinData({})],
})
export default class extends ContextMixin {}
</script>
