<template>
    <context- ref="context" v-slot="{ data: { patronKind } }">
        <b-nav-item-icon-
            icon="edit-2"
            text="Sửa thông tin loại khách hàng"
            @click="refs.patron_kind_update.open({ patronKind })"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins';

@Component({
    name: 'context-manage-patron-kind-',
})
export default class extends mixins<ContextMixin>(ContextMixin) {}
</script>
