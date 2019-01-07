<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { patron }, refs }">
            <b-nav-item-icon-
                icon=""
                text="Sửa thông tin khách hàng"
                @click="refs.patron_update.open({ patron })"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';

@Component({
    name: 'context-manage-patron-',
    mixins: [ContextMixin],
})
export default class extends ContextMixin {}
</script>
