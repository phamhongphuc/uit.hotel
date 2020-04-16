<template>
    <popup- ref="popup" v-slot="{ close }" title="Thêm giá cơ bản">
        <form-mutate-
            v-if="input"
            :mutation="createPrice"
            :variables="{ input }"
            success="Thêm giá cơ bản mới thành công"
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
                    <div class="input-label">Phí trả phòng trễ</div>
                    <b-input-money-
                        v-model="input.lateCheckOutFee"
                        :state="!$v.input.lateCheckOutFee.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Phí nhận phòng sớm</div>
                    <b-input-money-
                        v-model="input.earlyCheckInFee"
                        :state="!$v.input.earlyCheckInFee.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                </div>
                <div>
                    <div class="input-label">Ngày bắt đầu có hiệu lực</div>
                    <b-input-
                        v-model="input.effectiveStartDate"
                        :state="!$v.input.effectiveStartDate.$invalid"
                        class="m-3 rounded"
                        type="date"
                        icon="type"
                    />
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
                </div>
                <div>
                    <div class="input-label">Giá theo đêm</div>
                    <b-input-money-
                        v-model="input.nightPrice"
                        :state="!$v.input.nightPrice.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Giá theo tuần</div>
                    <b-input-money-
                        v-model="input.weekPrice"
                        :state="!$v.input.weekPrice.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Giá theo tháng</div>
                    <b-input-money-
                        v-model="input.monthPrice"
                        :state="!$v.input.monthPrice.$invalid"
                        class="m-3 rounded"
                        icon="type"
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
import { Component, mixins, Vue } from 'nuxt-property-decorator';
import moment from 'moment';
import { required } from 'vuelidate/lib/validators';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { PriceCreateInput, GetRoomKinds } from '~/graphql/types';
import { createPrice, getRoomKinds } from '~/graphql/documents';
import { price, validDate, included } from '~/modules/validator';

type PopupMixinType = PopupMixin<
    { roomKind: GetRoomKinds.RoomKinds },
    PriceCreateInput
>;

@Component({
    name: 'popup-price-add-',
    validations: {
        input: {
            hourPrice: price,
            dayPrice: price,
            nightPrice: price,
            weekPrice: price,
            monthPrice: price,
            lateCheckOutFee: price,
            earlyCheckInFee: price,
            effectiveStartDate: { required, validDate },
            roomKind: included('roomKind'),
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ createPrice, getRoomKinds }),
) {
    onOpen() {
        this.input = {
            hourPrice: 0,
            dayPrice: 0,
            nightPrice: 0,
            weekPrice: 0,
            monthPrice: 0,
            lateCheckOutFee: 0,
            earlyCheckInFee: 0,
            effectiveStartDate: moment()
                .set({ hour: 0, minute: 0, second: 0 })
                .format('YYYY-MM-DD'),
            roomKind: { id: -1 },
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
