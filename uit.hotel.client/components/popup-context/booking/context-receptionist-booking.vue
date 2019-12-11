<template>
    <context-
        ref="context"
        v-slot="{
            data: {
                booking,
                booking: { id },
            },
        }"
    >
        <b-nav-item-icon-
            icon="info"
            text="Chi tiết đặt phòng"
            @click="refs.booking_detail.open({ id })"
        />
        <b-nav-item-icon-mutate-
            v-if="booking.status === BookingStatusEnum.Booked"
            :mutation="cancel"
            :variables="{ id }"
            icon="trash-2"
            class="text-red"
            text="Hủy đặt phòng"
        />
        <b-nav-item-icon-mutate-
            v-if="booking.status === BookingStatusEnum.Booked"
            :mutation="checkIn"
            :variables="{ id }"
            class="text-green"
            icon="key"
            text="Nhận phòng"
        />
        <b-nav-item-icon-mutate-
            v-else-if="booking.status === BookingStatusEnum.CheckedIn"
            :mutation="checkOut"
            :variables="{ id }"
            class="text-green"
            icon="check-circle"
            text="Trả phòng"
        />
        <b-nav-item-icon-
            icon="shopping-bag"
            text="Thêm dịch vụ"
            @click="refs.service_detail_add.open({ booking })"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { checkIn, checkOut, cancel } from '~/graphql/documents';
import { BookingStatusEnum } from '~/graphql/types';

@Component({
    name: 'context-receptionist-booking-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ checkIn, checkOut, cancel, BookingStatusEnum }),
) {}
</script>
