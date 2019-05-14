<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { patronKind }, refs }">
            <b-nav-item-icon-
                icon="edit-2"
                text="Sửa thông tin loại khách hàng"
                @click="refs.patron_kind_update.open({ patronKind })"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins';

@Component({
    name: 'context-manage-patron-kind-',
    mixins: [ContextMixin],
})
export default class extends ContextMixin {}
</script>
