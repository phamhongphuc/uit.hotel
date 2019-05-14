<template>
    <popup- ref="popup" title="Thêm giá cơ bản" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="createRate"
            :variables="{ input }"
            success="Thêm giá cơ bản mới thành công"
        >
            <div class="d-flex">
                <div>
                    <div class="input-label">Loại phòng</div>
                    <query-
                        :query="getRoomKinds"
                        :poll-interval="0"
                        class="m-3"
                    >
                        <b-form-select
                            v-model="input.roomKind.id"
                            slot-scope="{ data: { roomKinds } }"
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
                    @click="close"
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { RateCreateInput, GetRoomKinds } from 'graphql/types';
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { createRate } from '~/graphql/documents/rate';
import { getRoomKinds } from '~/graphql/documents/room-kind';
import { required } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, mixinData({ createRate, getRoomKinds })],
    name: 'popup-rate-add-',
    validations: {
        input: {
            dayRate: { required },
            nightRate: { required },
            weekRate: { required },
            monthRate: { required },
            lateCheckOutFee: { required },
            earlyCheckInFee: { required },
            effectiveStartDate: { required },
            roomKind: { required },
        },
    },
})
export default class extends PopupMixin<
    { roomKind: GetRoomKinds.RoomKinds },
    RateCreateInput
> {
    onOpen() {
        const self = this;
        this.input = {
            dayRate: 0,
            nightRate: 0,
            weekRate: 0,
            monthRate: 0,
            lateCheckOutFee: 0,
            earlyCheckInFee: 0,
            effectiveStartDate: '',
            roomKind: {
                id: self.data.roomKind.id,
            },
        };
    }
}
</script>
