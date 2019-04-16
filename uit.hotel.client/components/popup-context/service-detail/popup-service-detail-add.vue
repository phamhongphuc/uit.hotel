<template>
    <popup- ref="popup" title="Thêm dịch vụ" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            success="Thêm chi tiết dịch vụ mới thành công"
            :mutation="createServicesDetail"
            :variables="{ input }"
        >
            <div class="input-label">Số lượng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.number"
                :state="!$v.input.number.$invalid"
                type="number"
                class="m-3 rounded"
                icon=""
            />
            <div class="input-label">Dịch vụ</div>
            <query- :query="getServices" class="m-3" :poll-interval="0">
                <b-form-select
                    v-model="input.service.id"
                    slot-scope="{ data: { services } }"
                    value-field="id"
                    text-field="name"
                    :state="!$v.input.service.$invalid"
                    :options="services"
                    class="rounded"
                />
            </query->
            <div class="input-label">Đơn đặt tại phòng</div>
            <query- :query="getSimpleBookings" class="m-3" :poll-interval="0">
                <b-form-select
                    v-model="input.booking.id"
                    slot-scope="{ data: { bookings } }"
                    value-field="id"
                    text-field="name"
                    :state="!$v.input.booking.$invalid"
                    :options="
                        bookings.map(book => ({
                            id: book.id,
                            name: book.room.name,
                        }))
                    "
                    class="rounded"
                />
            </query->
            <div class="d-flex m-3">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
                    @click="close"
                >
                    <span class="icon mr-1"></span>
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { getServices } from '~/graphql/documents/service';
import { getSimpleBookings } from '~/graphql/documents/booking';
import { createServicesDetail } from '~/graphql/documents/service-detail';
import { required, minValue } from 'vuelidate/lib/validators';
import { ServicesDetailCreateInput, GetBookings } from 'graphql/types';

@Component({
    mixins: [
        PopupMixin,
        mixinData({
            getServices,
            createServicesDetail,
            getSimpleBookings,
        }),
    ],
    name: 'popup-service-add-',
    validations: {
        input: {
            number: {
                minLength: minValue(1),
            },
            service: { required },
            booking: { required },
        },
    },
})
export default class extends PopupMixin<
    {
        booking: GetBookings.Bookings;
    },
    ServicesDetailCreateInput
> {
    onOpen() {
        const self = this;
        if (self === null) return;
        this.input = {
            number: 0,
            service: { id: 1 },
            booking: { id: self.data.booking.id },
        };
    }
}
</script>
