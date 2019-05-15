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
import { ContextMixin, DataMixin } from '~/components/mixins';

@Component({
    name: 'context-manage-rate-',
    mixins: [ContextMixin, DataMixin({})],
})
export default class extends ContextMixin {}
</script>
