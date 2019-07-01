<template>
    <context- ref="context" v-slot="{ data: { rate, rates } }">
        <b-nav-item-icon- icon="info" text="Thông tin giá" />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins';

@Component({
    name: 'context-manage-rate-',
})
export default class extends mixins<ContextMixin>(ContextMixin) {}
</script>
