<template>
    <div>
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.book.open({ rooms: [] })"
            >
                <icon- class="mr-1" i="edit-3" />
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
                <booking-timeline- :floors="floors" />
            </div>
        </query->
        <context-manage-patron- ref="context_patron" />
        <context-receptionist-booking- ref="context_booking" />
        <context-receptionist-room- ref="context_receptionist_room" />
        <context-receptionist-service-detail- ref="context_service_detail" />
        <popup-book- ref="book" />
        <popup-booking-detail- ref="booking_detail" />
        <popup-patron-select-or-add- ref="patron_select_or_add" />
        <popup-patron-update- ref="patron_update" />
        <popup-room-select- ref="room_select" />
        <popup-service-detail-add- ref="service_detail_add" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin, Page } from '~/components/mixins';
import { getTimeline } from '~/graphql/documents';
import { toMoney } from '~/utils';

@Component({
    name: 'timeline-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getTimeline, toMoney }),
) {
    head() {
        return { title: 'Quản lý thời gian đặt phòng' };
    }
}
</script>
