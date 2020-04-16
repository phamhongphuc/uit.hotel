<template>
    <popup- ref="popup" v-slot="{ close }" title="Thêm giá biến động">
        <form-mutate-
            v-if="input"
            :mutation="createPriceVolatility"
            :variables="{ input }"
            success="Thêm giá biến động mới thành công"
            @success="close"
        >
            <div class="d-flex">
                <div>
                    <div class="input-label">Loại phòng</div>
                    <query-
                        v-slot="{ data: { roomKinds } }"
                        :query="getRoomKinds"
                        :poll-interval="0"
                        class="m-3"
                        @result="onResult"
                    >
                        <b-form-select
                            ref="roomKind"
                            v-model="input.roomKind.id"
                            :state="!$v.input.roomKind.$invalid"
                            :options="roomKinds"
                            value-field="id"
                            text-field="name"
                            class="rounded"
                        />
                    </query->
                    <div class="input-label">Tên giá biến động</div>
                    <b-input-
                        v-model="input.name"
                        :state="!$v.input.name.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Ngày bắt đầu có hiệu lực</div>
                    <b-input-
                        v-model="input.effectiveStartDate"
                        :state="!$v.input.effectiveStartDate.$invalid"
                        class="m-3 rounded"
                        type="date"
                        icon="type"
                    />
                    <div class="input-label">Ngày hết hiệu lực</div>
                    <b-input-
                        v-model="input.effectiveEndDate"
                        :state="!$v.input.effectiveEndDate.$invalid"
                        class="m-3 rounded"
                        type="date"
                        icon="type"
                    />
                </div>
                <div>
                    <div class="input-label">Giá theo giờ</div>
                    <b-input-money-
                        v-model="input.hourPrice"
                        :state="!$v.input.hourPrice.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Giá theo ngày</div>
                    <b-input-money-
                        v-model="input.dayPrice"
                        :state="!$v.input.dayPrice.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Giá theo đêm</div>
                    <b-input-money-
                        v-model="input.nightPrice"
                        :state="!$v.input.nightPrice.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Hiệu lực</div>
                    <b-checkbox-group
                        v-model="daysOfWeek"
                        class="m-3 rounded box-shadow-inner color-green"
                        :options="daysOfWeekOptions"
                        button-variant=""
                        name="buttons-1"
                        buttons
                    />
                </div>
            </div>
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
import { Component, mixins, Vue, Watch } from 'nuxt-property-decorator';
import moment from 'moment';
import { required, minLength } from 'vuelidate/lib/validators';
import { DaysOfWeekPropertyType, daysOfWeekOptions } from '~/modules/model';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { PriceVolatilityCreateInput, GetRoomKinds } from '~/graphql/types';
import { createPriceVolatility, getRoomKinds } from '~/graphql/documents';
import { price, validDate, included } from '~/modules/validator';

type PopupMixinType = PopupMixin<
    { roomKind: GetRoomKinds.RoomKinds },
    PriceVolatilityCreateInput
>;

@Component({
    name: 'popup-price-volatility-add-',
    validations: {
        input: {
            name: { required, minLength: minLength(1) },
            hourPrice: price,
            dayPrice: price,
            nightPrice: price,
            effectiveStartDate: { required, validDate },
            effectiveEndDate: { required, validDate },
            roomKind: included('roomKind'),
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ createPriceVolatility, getRoomKinds, daysOfWeekOptions }),
) {
    input!: PriceVolatilityCreateInput;

    onOpen() {
        this.input = {
            name: '',
            hourPrice: 0,
            dayPrice: 0,
            nightPrice: 0,
            effectiveStartDate: moment()
                .set({ hour: 0, minute: 0, second: 0 })
                .format('YYYY-MM-DD'),
            effectiveEndDate: moment()
                .set({ hour: 0, minute: 0, second: 0 })
                .format('YYYY-MM-DD'),
            effectiveOnMonday: true,
            effectiveOnTuesday: true,
            effectiveOnWednesday: true,
            effectiveOnThursday: true,
            effectiveOnFriday: true,
            effectiveOnSaturday: true,
            effectiveOnSunday: true,
            roomKind: { id: -1 },
        };
    }

    daysOfWeek = [];

    @Watch('daysOfWeek')
    onDaysOfWeekChange(value: DaysOfWeekPropertyType[]) {
        const daysOfWeekObject = value.reduce<
            { [key in DaysOfWeekPropertyType]: boolean }
        >(
            (output, key) => {
                output[key] = true;
                return output;
            },
            {
                effectiveOnMonday: false,
                effectiveOnTuesday: false,
                effectiveOnWednesday: false,
                effectiveOnThursday: false,
                effectiveOnFriday: false,
                effectiveOnSaturday: false,
                effectiveOnSunday: false,
            },
        );
        this.input = {
            ...this.input,
            ...daysOfWeekObject,
        };
    }

    async onResult() {
        if (this.input === null) return;

        await Vue.nextTick();
        this.input.roomKind.id = this.data.roomKind.id;
        this.$v.$touch();
    }
}
</script>
