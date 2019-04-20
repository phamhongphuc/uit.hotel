<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { rate, rates }, refs }">
            <b-nav-item-icon-
                v-if="rate.isActive"
                icon="edit-2"
                text="Sửa thông tin giá cơ bản"
                @click="refs.rate_update.open({ rate })"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    name: 'context-manage-rate-',
    mixins: [ContextMixin, mixinData({})],
})
export default class extends ContextMixin {}
</script>
