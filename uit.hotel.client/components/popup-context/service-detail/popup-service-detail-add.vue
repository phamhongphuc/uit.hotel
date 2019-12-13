<template>
    <popup-
        ref="popup"
        v-slot="{ close }"
        :title="`Thêm dịch vụ cho phòng ${roomName}`"
    >
        <form-mutate-
            v-if="input"
            :mutation="createServicesDetail"
            :variables="{ input }"
            success="Thêm chi tiết dịch vụ mới thành công"
            @success="close"
        >
            <div class="input-label">Số lượng</div>
            <b-input-
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
import { ExecutionResult } from 'graphql';
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
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ getServices, createServicesDetail, getSimpleBookings }),
) {
    roomName = '';

    onOpen() {
        this.input = {
            number: 1,
            service: { id: -1 },
            booking: { id: this.data.booking.id },
        };
        this.roomName = this.data.booking.room.name;
    }

    async onResult(result: ExecutionResult<GetSimpleBookingsQuery>) {
        if (!result.data) return;

        if (this.input === null) return;

        await Vue.nextTick();
        this.input.booking.id = this.data.booking.id;
        this.$v.$touch();
    }
}
</script>
