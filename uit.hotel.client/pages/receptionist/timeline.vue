<template>
    <div>
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.book.open({ rooms: [] })"
            >
                <icon- class="mr-1" i="plus" />
                <span>Đặt phòng</span>
            </b-button>
        </block-flex->
        <query-
            v-slot="{ data: { floors } }"
            :query="getTimeline"
            :poll-interval="1000"
            class="query-fill"
        >
            <div>
                <booking-timeline- :floors="floors" :refs="$refs" />
            </div>
        </query->
        <context-receptionist-room- ref="context_receptionist_room" />
        <context-receptionist-booking-
            ref="context_receptionist_booking"
            :refs="$refs"
        />
        <popup-booking-detail- ref="booking_detail" />
        <popup-service-detail-add- ref="service_detail_add" />
        <popup-book- ref="book" :refs="$refs" />
        <popup-patron-select-or-add- ref="patron_select_or_add" />
        <popup-room-select- ref="room_select" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin } from '~/components/mixins';
import { getTimeline } from '~/graphql/documents';
import { toMoney } from '~/utils';

@Component({
    name: 'timeline-',
})
export default class extends mixins<{
    getTimeline: typeof getTimeline;
}>(DataMixin({ getTimeline, toMoney })) {
    head() {
        return { title: 'Quản lý thời gian đặt phòng' };
    }
}
</script>
