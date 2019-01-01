<template>
    <context- ref="context">
        <template slot-scope="{ data }">
            <b-nav-item-icon- icon="" text="Xem thông tin chi tiết" />
            <div class="context-hr" />
            <b-nav-item-icon- icon="" text="Sửa thông tin phòng" />
            <b-nav-item-icon-mutate-
                :mutation="setIsActiveRoom"
                :variables="{ id: data.id, isActive: !data.isActive }"
                :icon="data.isActive ? '' : ''"
                :text="
                    data.isActive ? 'Vô hiệu hóa phòng' : 'Kích hoạt lại phòng'
                "
                @click="action(mutate)"
            />
            <b-nav-item-icon-mutate-
                :mutation="deleteRoom"
                :variables="{ id: data.id }"
                icon=""
                text="Xóa phòng"
                @click="action(mutate)"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import { setIsActiveRoom, deleteRoom } from '~/graphql/documents/floor-room';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    name: 'context-manage-room-',
    mixins: [ContextMixin, mixinData({ setIsActiveRoom, deleteRoom })],
})
export default class extends ContextMixin {}
</script>
