<template>
    <context- ref="context" v-slot="{ data: { floor } }">
        <b-nav-item-icon-
            v-if="floor.isActive"
            icon="edit-2"
            text="Sửa thông tin tầng"
            @click="refs.floor_update.open({ floor })"
        />
        <b-nav-item-icon-
            v-if="floor.isActive"
            text="Thêm phòng"
            icon="plus"
            @click="refs.room_add.open({ floor })"
        />
        <b-nav-item-icon-mutate-
            :mutation="setIsActiveFloor"
            :variables="{ id: floor.id, isActive: !floor.isActive }"
            :icon="floor.isActive ? 'x' : 'chevrons-up'"
            :text="floor.isActive ? 'Vô hiệu hóa tầng' : 'Kích hoạt lại tầng'"
        />
        <b-nav-item-icon-mutate-
            v-if="floor.isActive"
            :mutation="deleteFloor"
            :variables="{ id: floor.id }"
            icon="trash-2"
            text="Xóa tầng"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { setIsActiveFloor, deleteFloor } from '~/graphql/documents';

@Component({
    name: 'context-manage-floor-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ setIsActiveFloor, deleteFloor }),
) {}
</script>
