<template>
    <context- ref="context" v-slot="{ data: { room } }">
        <b-nav-item-icon-
            v-if="room"
            icon="info"
            text="Xem thông tin chi tiết"
        />
        <b-nav-item-icon-mutate-
            :mutation="setIsCleanRoom"
            :variables="{
                id: room.id,
                isClean: !room.isClean,
            }"
            icon="broom"
            :text="room.isClean ? 'Đánh dấu là chưa dọn' : 'Đánh dấu là đã dọn'"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { setIsCleanRoom } from '~/graphql/documents';

@Component({
    name: 'context-receptionist-room-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ setIsCleanRoom }),
) {}
</script>
