<template>
    <popup- ref="popup" title="Thêm dịch vụ">
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
                class="m-3 rounded"
                icon="type"
                type="number"
                text-field="name"
                value-field="id"
            />
            <div class="input-label">Dịch vụ</div>
            <query-
                v-slot="{ data: { services } }"
                :query="getServices"
                :poll-interval="0"
                class="m-3"
            >
                <b-form-select
                    ref="service"
                    v-model="input.service.id"
                    :state="!$v.input.service.$invalid"
                    :options="services"
                    class="rounded"
                    text-field="name"
                    value-field="id"
                />
            </query->
            <div class="input-label">Đơn đặt tại phòng</div>
            <query-
                v-slot="{ data: { bookings } }"
                :query="getSimpleBookings"
                :poll-interval="0"
                class="m-3"
                @result="onResult"
            >
                <b-form-select
                    ref="booking"
                    v-model="input.booking.id"
                    :state="!$v.input.booking.$invalid"
                    :options="mappedBookings"
                    class="rounded"
                    text-field="name"
                    value-field="id"
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
import { Component, mixins, Vue } from 'nuxt-property-decorator';
import { minValue } from 'vuelidate/lib/validators';
import { DataMixin, PopupMixin } from '~/components/mixins';
import {
    ServicesDetailCreateInput,
    GetBookings,
    GetSimpleBookingsQuery,
} from '~/graphql/types';
import { included } from '~/modules/validator';
import {
    getServices,
    getSimpleBookings,
    createServicesDetail,
} from '~/graphql/documents';
import { ExecutionResult } from 'graphql';

type PopupMixinType = PopupMixin<
    {
        booking: GetBookings.Bookings;
    },
    ServicesDetailCreateInput
>;

@Component({
    name: 'popup-service-detail-add-',
    validations: {
        input: {
            number: {
                minLength: minValue(1),
            },
            service: included('service'),
            booking: included('booking'),
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ getServices, createServicesDetail, getSimpleBookings }),
) {
    bookings: GetSimpleBookingsQuery['bookings'] = [];

    onOpen() {
        this.input = {
            number: 0,
            service: { id: -1 },
            booking: { id: -1 },
        };
    }

    get mappedBookings() {
        return this.bookings.map(booking => ({
            id: booking.id,
            name: booking.room.name,
        }));
    }

    async onResult(result: ExecutionResult<GetSimpleBookingsQuery>) {
        if (result.data === undefined) return;
        this.bookings = result.data.bookings;

        if (this.input === null) return;
        await Vue.nextTick();
        this.input.booking.id = this.data.booking.id;
        this.$v.$touch();
    }
}
</script>
