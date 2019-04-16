<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { booking } }">
            <b-nav-item-icon-mutate-
                v-if="booking.status === statusEnum.Booked"
                :mutation="cancel"
                :variables="{ id: booking.id }"
                icon=""
                text="Hủy đặt phòng"
            />
            <b-nav-item-icon-mutate-
                v-if="booking.status === statusEnum.Booked"
                :mutation="checkIn"
                :variables="{ id: booking.id }"
                icon=""
                text="Nhận phòng"
            />
            <b-nav-item-icon-mutate-
                v-else-if="booking.status === statusEnum.CheckedIn"
                :mutation="requestCheckOut"
                :variables="{ id: booking.id }"
                icon=""
                text="Yêu cầu trả phòng"
            />
            <b-nav-item-icon-mutate-
                v-else-if="booking.status === statusEnum.RequestedCheckOut"
                :mutation="checkOut"
                :variables="{ id: booking.id }"
                icon=""
                text="Trả phòng"
            />
            <b-nav-item-icon-
                icon=""
                text="Thêm chi tiết dịch vụ"
                @click="refs.service_detail_add.open({ booking })"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import { mixinData } from '~/components/mixins/mutable';
import {
    checkIn,
    requestCheckOut,
    checkOut,
    cancel,
} from '~/graphql/documents/booking';

@Component({
    name: 'context-manage-patron-kind-',
    mixins: [
        ContextMixin,
        mixinData({ checkIn, requestCheckOut, checkOut, cancel }),
    ],
})
export default class extends ContextMixin {
    statusEnum = {
        Booked: 0,
        CheckedIn: 1,
        RequestedCheckOut: 2,
        CheckedOut: 3,
    };
}
</script>
