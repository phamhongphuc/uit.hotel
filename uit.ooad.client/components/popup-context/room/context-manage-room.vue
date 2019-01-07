<template>
    <context- ref="context">
        <template slot-scope="{ data: { room, floor } }">
            <b-nav-item-icon- icon="" text="Xem thông tin chi tiết" />
            <div class="context-hr" />
            <b-nav-item-icon-
                icon=""
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
                :mutation="deleteRoom"
                :variables="{ id: room.id }"
                icon=""
                text="Xóa phòng"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import { setIsActiveRoom, deleteRoom } from '~/graphql/documents/room';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    name: 'context-manage-room-',
    mixins: [ContextMixin, mixinData({ setIsActiveRoom, deleteRoom })],
})
export default class extends ContextMixin {}
</script>
