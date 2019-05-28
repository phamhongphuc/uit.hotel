<template>
    <popup- ref="popup" title="Thêm dịch vụ" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="createServicesDetail"
            :variables="{ input }"
            success="Thêm chi tiết dịch vụ mới thành công"
            @success="close"
        >
            <div class="input-label">Số lượng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.number"
                :state="!$v.input.number.$invalid"
                type="number"
                class="m-3 rounded"
                icon="type"
            />
            <div class="input-label">Dịch vụ</div>
            <query- :query="getServices" :poll-interval="0" class="m-3">
                <b-form-select
                    v-model="input.service.id"
                    slot-scope="{ data: { services } }"
                    :state="!$v.input.service.$invalid"
                    :options="services"
                    value-field="id"
                    text-field="name"
                    class="rounded"
                />
            </query->
            <div class="input-label">Đơn đặt tại phòng</div>
            <query- :query="getSimpleBookings" :poll-interval="0" class="m-3">
                <b-form-select
                    v-model="input.booking.id"
                    slot-scope="{ data: { bookings } }"
                    :state="!$v.input.booking.$invalid"
                    :options="
                        bookings.map(book => ({
                            id: book.id,
                            name: book.room.name,
                        }))
                    "
                    value-field="id"
                    text-field="name"
                    class="rounded"
                />
            </query->
            <div class="d-flex m-3">
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    type="submit"
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { required, minValue } from 'vuelidate/lib/validators';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { ServicesDetailCreateInput, GetBookings } from '~/graphql/types';
import {
    getServices,
    getSimpleBookings,
    createServicesDetail,
} from '~/graphql/documents';

type PopupMixinType = PopupMixin<
    {
        booking: GetBookings.Bookings;
    },
    ServicesDetailCreateInput
>;

@Component({
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
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ getServices, createServicesDetail, getSimpleBookings }),
) {
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
