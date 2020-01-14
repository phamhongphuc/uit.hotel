<template>
    <context- ref="context" v-slot="{ data: { patron } }">
        <b-nav-item-icon-
            icon="info"
            text="Chi tiết khách hàng"
            @click="refs.patron_detail.open({ id: patron.id })"
        />
        <b-nav-item-icon-
            icon="edit-2"
            text="Sửa thông tin khách hàng"
            @click="refs.patron_update.open({ id: patron.id })"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins';

@Component({
    name: 'context-manage-patron-',
})
export default class extends mixins<ContextMixin>(ContextMixin) {}
</script>
