<template>
    <context- ref="context" v-slot="{ data: { rate, rates } }">
        <b-nav-item-icon-
            v-if="rate.isActive"
            icon="edit-2"
            text="Sửa thông tin giá cơ bản"
            @click="refs.rate_update.open({ rate })"
        />
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
