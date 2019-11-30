<template>
    <context- ref="context" v-slot="{ data: { position } }">
        <b-nav-item-icon-
            v-if="position.isActive"
            icon="edit-2"
            text="Sửa thông tin vị trí"
            @click="refs.position_update.open({ position })"
        />
        <b-nav-item-icon-mutate-
            :mutation="setIsActivePosition"
            :variables="{ id: position.id, isActive: !position.isActive }"
            :icon="position.isActive ? 'x' : 'chevrons-up'"
            :text="
                position.isActive
                    ? 'Vô hiệu hóa vị trí'
                    : 'Kích hoạt lại vị trí'
            "
        />
        <b-nav-item-icon-mutate-
            v-if="position.isActive"
            :mutation="deletePosition"
            :variables="{ id: position.id }"
            confirm
            icon="trash-2"
            text="Xóa vị trí"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { setIsActivePosition, deletePosition } from '~/graphql/documents';

@Component({
    name: 'context-manage-position-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ setIsActivePosition, deletePosition }),
) {}
</script>
