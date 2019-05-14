<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { position, positions }, refs }">
            <b-nav-item-icon-
                v-if="position.isActive"
                icon="edit-2"
                text="Sửa thông tin vị trí"
                @click="refs.position_update.open({ position })"
            />
            <b-nav-item-icon-mutate-
                :mutation="setIsActivePosition"
                :variables="{ id: position.id, isActive: !position.isActive }"
                :icon="position.isActive ? '' : ''"
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
                icon="trash-2"
                text="Xóa vị trí"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin, mixinData } from '~/components/mixins';
import { setIsActivePosition, deletePosition } from '~/graphql/documents';

@Component({
    name: 'context-manage-position-',
    mixins: [ContextMixin, mixinData({ setIsActivePosition, deletePosition })],
})
export default class extends ContextMixin {}
</script>
