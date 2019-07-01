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
        <b-nav-item-icon-mutate-
            v-if="booking.status === statusEnum.Booked"
            :mutation="cancel"
            :variables="{ id }"
            icon="trash-2"
            class="text-red"
            text="Hủy đặt phòng"
        />
        <b-nav-item-icon-mutate-
            v-if="booking.status === statusEnum.Booked"
            :mutation="checkIn"
            :variables="{ id }"
            class="text-green"
            icon="key"
            text="Nhận phòng"
        />
        <b-nav-item-icon-mutate-
            v-else-if="booking.status === statusEnum.CheckedIn"
            :mutation="checkOut"
            :variables="{ id }"
            class="text-green"
            icon="check-circle"
            text="Trả phòng"
        />
        <b-nav-item-icon-
            icon="shopping-bag"
            text="Thêm chi tiết dịch vụ"
            @click="refs.service_detail_add.open({ booking })"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { checkIn, checkOut, cancel } from '~/graphql/documents';

@Component({
    name: 'context-receptionist-booking-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ checkIn, checkOut, cancel }),
) {
    statusEnum = {
        Booked: 0,
        CheckedIn: 1,
        CheckedOut: 2,
    };
}
</script>
