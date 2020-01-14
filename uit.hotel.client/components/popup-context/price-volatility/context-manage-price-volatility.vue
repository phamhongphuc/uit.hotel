<template>
    <context- ref="context" v-slot="{ data: { priceVolatility } }">
        <b-nav-item-icon-
            icon="info"
            text="Thông tin giá"
            @click="
                refs.price_volatility_detail.open({ id: priceVolatility.id })
            "
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins';

@Component({
    name: 'context-manage-price-volatility-',
})
export default class extends mixins<ContextMixin>(ContextMixin) {}
</script>
