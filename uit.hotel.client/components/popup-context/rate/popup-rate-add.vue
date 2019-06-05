<template>
    <popup- ref="popup" v-slot="{ close }" title="Thêm giá cơ bản" no-data>
        <form-mutate-
            v-if="input"
            :mutation="createRate"
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
                    <b-input-
                        v-model="input.lateCheckOutFee"
                        :state="!$v.input.lateCheckOutFee.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Phí nhận phòng sớm</div>
                    <b-input-
                        v-model="input.earlyCheckInFee"
                        :state="!$v.input.earlyCheckInFee.$invalid"
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
                </div>
                <div>
                    <div class="input-label">Giá theo ngày</div>
                    <b-input-
                        v-model="input.dayRate"
                        :state="!$v.input.dayRate.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Giá theo đêm</div>
                    <b-input-
                        v-model="input.nightRate"
                        :state="!$v.input.nightRate.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Giá theo tuần</div>
                    <b-input-
                        v-model="input.weekRate"
                        :state="!$v.input.weekRate.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Giá theo tháng</div>
                    <b-input-
                        v-model="input.monthRate"
                        :state="!$v.input.monthRate.$invalid"
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
import { required } from 'vuelidate/lib/validators';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { RateCreateInput, GetRoomKinds } from '~/graphql/types';
import { createRate, getRoomKinds } from '~/graphql/documents';
import { rate, validDate, included } from '~/modules/validator';

type PopupMixinType = PopupMixin<
    { roomKind: GetRoomKinds.RoomKinds },
    RateCreateInput
>;

@Component({
    name: 'popup-rate-add-',
    validations: {
        input: {
            dayRate: rate,
            nightRate: rate,
            weekRate: rate,
            monthRate: rate,
            lateCheckOutFee: rate,
            earlyCheckInFee: rate,
            effectiveStartDate: { required, validDate },
            roomKind: included('roomKind'),
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ createRate, getRoomKinds }),
) {
    onOpen() {
        this.input = {
            dayRate: 0,
            nightRate: 0,
            weekRate: 0,
            monthRate: 0,
            lateCheckOutFee: 0,
            earlyCheckInFee: 0,
            effectiveStartDate: '',
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
