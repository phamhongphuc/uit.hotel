<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { floor, floors }, refs }">
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
                :icon="floor.isActive ? '' : ''"
                :text="
                    floor.isActive ? 'Vô hiệu hóa tầng' : 'Kích hoạt lại tầng'
                "
            />
            <b-nav-item-icon-mutate-
                v-if="floor.isActive"
                :mutation="deleteFloor"
                :variables="{ id: floor.id }"
                icon="trash-2"
                text="Xóa tầng"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import { setIsActiveFloor, deleteFloor } from '~/graphql/documents/floor';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    name: 'context-manage-floor-',
    mixins: [ContextMixin, mixinData({ setIsActiveFloor, deleteFloor })],
})
export default class extends ContextMixin {}
</script>
