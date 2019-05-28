<template>
    <div>
        <block-flex->
            <b-button class="m-2" variant="white">
                <icon- class="mr-1" i="plus" />
                <span>Đặt phòng nhận ngay</span>
            </b-button>
            <b-button class="m-2" variant="white">
                <icon- class="mr-1" i="plus" />
                <span>Đặt phòng</span>
            </b-button>
        </block-flex->
        <query- :query="getTimeline" :poll-interval="500" class="query-fill">
            <div slot-scope="{ data: { floors } }">
                <booking-timeline- :floors="floors" />
            </div>
        </query->
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
