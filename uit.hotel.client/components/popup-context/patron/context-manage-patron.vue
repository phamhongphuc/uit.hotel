<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { patron }, refs }">
            <b-nav-item-icon-
                icon="edit-2"
                text="Sửa thông tin khách hàng"
                @click="refs.patron_update.open({ patron })"
            />
        </template>
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
