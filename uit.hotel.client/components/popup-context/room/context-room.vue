<template>
    <context- ref="context" v-slot="{ data: { room } }">
        <b-nav-item-icon-
            v-if="room"
            icon="alert-circle"
            text="Xem thông tin chi tiết"
        />
        <div class="context-hr" />
        <!-- <b-nav-item-icon-
                icon="edit-2"
                text="Sửa thông tin phòng"
                @click="refs.room_update.open({ room, floor, floors })"
            /> -->
        <!-- <b-nav-item-icon-mutate-
                :mutation="setIsActiveRoom"
                :variables="{ id: room.id, isActive: !room.isActive }"
                :icon="room.isActive ? 'x' : 'chevrons-up'"
                text="Cho"
            /> -->
        <!-- <b-nav-item-icon-mutate-
                :mutation="deleteRoom"
                :variables="{ id: room.id }"
                icon="trash-2"
                text="Xóa phòng"
            /> -->
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { setIsActiveRoom, deleteRoom } from '~/graphql/documents';

@Component({
    name: 'context-manage-room-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ setIsActiveRoom, deleteRoom }),
) {}
</script>
