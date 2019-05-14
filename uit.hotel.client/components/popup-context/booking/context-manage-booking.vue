<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { booking } }">
            <b-nav-item-icon-mutate-
                v-if="booking.status === statusEnum.Booked"
                :mutation="cancel"
                :variables="{ id: booking.id }"
                icon="trash-2"
                text="Hủy đặt phòng"
            />
            <b-nav-item-icon-mutate-
                v-if="booking.status === statusEnum.Booked"
                :mutation="checkIn"
                :variables="{ id: booking.id }"
                icon="trash-2"
                text="Nhận phòng"
            />
            <b-nav-item-icon-mutate-
                v-else-if="booking.status === statusEnum.CheckedIn"
                :mutation="requestCheckOut"
                :variables="{ id: booking.id }"
                icon="trash-2"
                text="Yêu cầu trả phòng"
            />
            <b-nav-item-icon-mutate-
                v-else-if="booking.status === statusEnum.RequestedCheckOut"
                :mutation="checkOut"
                :variables="{ id: booking.id }"
                icon="trash-2"
                text="Trả phòng"
            />
            <b-nav-item-icon-
                icon="edit-2"
                text="Thêm chi tiết dịch vụ"
                @click="refs.service_detail_add.open({ booking })"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin, mixinData } from '~/components/mixins';
import {
    checkIn,
    requestCheckOut,
    checkOut,
    cancel,
} from '~/graphql/documents';

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
