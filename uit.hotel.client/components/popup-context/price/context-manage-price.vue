<template>
    <context- ref="context" v-slot="{ data: { price } }">
        <b-nav-item-icon-
            icon="info"
            text="Thông tin giá"
            @click="refs.price_detail.open({ id: price.id })"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins';

@Component({
    name: 'context-manage-price-',
})
export default class extends mixins<ContextMixin>(ContextMixin) {}
</script>
