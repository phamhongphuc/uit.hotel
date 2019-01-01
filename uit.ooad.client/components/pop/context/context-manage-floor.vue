<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { floor, floors }, refs }">
            <b-nav-item-icon- icon="" text="Sửa thông tin tầng" />
            <b-nav-item-icon-
                v-if="floor.isActive"
                text="Thêm phòng"
                icon=""
                @click="refs.add_room.open({ floor, floors })"
            />
            <b-nav-item-icon-mutate-
                :mutation="setIsActiveFloor"
                :variables="{ id: floor.id, isActive: !floor.isActive }"
                :icon="floor.isActive ? '' : ''"
                :text="
                    floor.isActive ? 'Vô hiệu hóa tầng' : 'Kích hoạt lại tầng'
                "
                @click="action(mutate)"
            />
            <b-nav-item-icon-mutate-
                :mutation="deleteFloor"
                :variables="{ id: floor.id }"
                icon=""
                text="Xóa tầng"
                @click="action(mutate)"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import { setIsActiveFloor, deleteFloor } from '~/graphql/documents/floor-room';

@Component({
    name: 'context-manage-floor-',
    mixins: [ContextMixin],
})
export default class extends ContextMixin {
    setIsActiveFloor = setIsActiveFloor;
    deleteFloor = deleteFloor;
}
</script>
