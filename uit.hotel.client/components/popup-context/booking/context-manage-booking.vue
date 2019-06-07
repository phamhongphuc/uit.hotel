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
            text="Hủy đặt phòng"
        />
        <b-nav-item-icon-mutate-
            v-if="booking.status === statusEnum.Booked"
            :mutation="checkIn"
            :variables="{ id }"
            icon="trash-2"
            text="Nhận phòng"
        />
        <b-nav-item-icon-mutate-
            v-else-if="booking.status === statusEnum.RequestedCheckOut"
            :mutation="checkOut"
            :variables="{ id }"
            icon="trash-2"
            text="Trả phòng"
        />
        <b-nav-item-icon-
            icon="edit-2"
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
    name: 'context-manage-patron-kind-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ checkIn, checkOut, cancel }),
) {
    statusEnum = {
        Booked: 0,
        CheckedIn: 1,
        RequestedCheckOut: 2,
        CheckedOut: 3,
    };
}
</script>
