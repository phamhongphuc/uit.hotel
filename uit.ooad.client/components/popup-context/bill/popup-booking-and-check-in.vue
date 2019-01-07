<template>
    <popup- ref="popup" title="Đặt phòng và nhận ngay">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { bill }, close }"
            success="Thêm phòng cho hóa đơn có sẵn"
            :mutation="bookAndCheckIn"
            :variables="{ input }"
        >
            <div class="input-label">Khách hàng</div>
            <query-
                :query="getPatrons"
                :poll-interval="500"
                class="m-3"
                child-class="d-flex"
            >
                <template slot-scope="{ data: { patrons } }">
                    <b-form-select
                        v-model="input.bill.patron.id"
                        value-field="id"
                        text-field="name"
                        :state="!$v.input.$invalid"
                        :options="patrons"
                        class="rounded"
                    />
                    <b-button
                        variant="main"
                        class="ml-3 text-nowrap"
                        @click="
                            refs.patron_select.open({
                                patron: input.bill.patron,
                            })
                        "
                    >
                        <span class="icon"></span>
                        <span>Chọn khách hàng</span>
                    </b-button>
                </template>
            </query->
            <div class="input-label">Danh sách phòng</div>
            <div class="d-flex m-3">
                <b-button
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
                    @click="close"
                >
                    <span class="icon"></span>
                    <span>Đặt phòng và nhận ngay</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { bookAndCheckIn } from '~/graphql/documents/bill';
import { getPatrons } from '~/graphql/documents/patron';
import { GetFloors, BookAndCheckIn } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ bookAndCheckIn, getPatrons })],
    name: 'popup-booking-and-check-in-',
    validations: {
        input: {},
    },
})
export default class extends PopupMixin<
    { rooms: GetFloors.Rooms[] },
    BookAndCheckIn.Variables
> {
    onOpen() {
        const self = this;
        this.input = {
            bill: {
                patron: {
                    id: 1,
                },
            },
            bookings: self.data.rooms.map(r => ({
                bookCheckOutTime: new Date(),
                room: {
                    id: r.id,
                },
                listOfPatrons: [],
            })),
        };
    }
}
</script>
