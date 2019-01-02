<template>
    <context- ref="context">
        <template slot-scope="{ data: { roomKind } }">
            <b-nav-item-icon- icon="" text="Xem thông tin chi tiết" />
            <div class="context-hr" />
            <!-- {{ roomKind }} -->
            <b-nav-item-icon-
                icon=""
                text="Sửa thông tin phòng"
                @click="refs.room_kind_update.open({ roomKind })"
            />
            <b-nav-item-icon-mutate-
                :mutation="setIsActiveRoomKind"
                :variables="{ id: roomKind.id, isActive: !roomKind.isActive }"
                :icon="roomKind.isActive ? '' : ''"
                :text="
                    roomKind.isActive
                        ? 'Vô hiệu hóa loại phòng'
                        : 'Kích hoạt lại loại phòng'
                "
            />
            <b-nav-item-icon-mutate-
                :mutation="deleteRoomKind"
                :variables="{ id: roomKind.id }"
                icon=""
                text="Xóa loại phòng"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import {
    setIsActiveRoomKind,
    deleteRoomKind,
} from '~/graphql/documents/room-kind';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    name: 'context-manage-room-kind-',
    mixins: [ContextMixin, mixinData({ setIsActiveRoomKind, deleteRoomKind })],
})
export default class extends ContextMixin {}
</script>
