<template>
    <context- ref="context">
        <template slot-scope="{ data: { room, floor } }">
            <b-nav-item-icon-
                icon="alert-circle"
                text="Xem thông tin chi tiết"
            />
            <div class="context-hr" />
            <b-nav-item-icon-
                v-if="room.isActive"
                icon="edit-2"
                text="Sửa thông tin phòng"
                @click="refs.room_update.open({ room, floor })"
            />
            <b-nav-item-icon-mutate-
                :mutation="setIsActiveRoom"
                :variables="{ id: room.id, isActive: !room.isActive }"
                :icon="room.isActive ? '' : ''"
                :text="
                    room.isActive ? 'Vô hiệu hóa phòng' : 'Kích hoạt lại phòng'
                "
            />
            <b-nav-item-icon-mutate-
                v-if="room.isActive"
                :mutation="deleteRoom"
                :variables="{ id: room.id }"
                icon="trash-2"
                text="Xóa phòng"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { setIsActiveRoom, deleteRoom } from '~/graphql/documents';

@Component({
    name: 'context-manage-room-',
    mixins: [ContextMixin, DataMixin({ setIsActiveRoom, deleteRoom })],
})
export default class extends ContextMixin {}
</script>
