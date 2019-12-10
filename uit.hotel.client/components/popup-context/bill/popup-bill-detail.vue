<template>
    <popup-
        ref="popup"
        v-slot
        title="Chi tiết đặt phòng"
        class="popup-bill-detail"
    >
        <query-
            v-slot
            :query="getBill"
            :variables="variables"
            :poll-interval="500"
            @result="onResult"
        >
            <div class="m-3">
                <div
                    class="d-flex m-child-1 mb-2 flex-wrap justify-content-start"
                >
                    <b-button
                        variant="lighten"
                        @click="$refs.book.open({ rooms: [] })"
                    >
                        <icon- class="mr-1" i="plus" />
                        <span>Đặt phòng</span>
                    </b-button>
                </div>
                <b-table
                    class="table-style table-sm bg-lighten rounded overflow-hidden"
                    :items="bill.bookings"
                    :fields="[
                        {
                            key: 'index',
                            label: '#',
                            class: 'table-cell-id text-center',
                            sortable: true,
                        },
                        {
                            key: 'room',
                            label: 'Phòng',
                        },
                        {
                            key: 'patrons',
                            label: 'Khách',
                        },
                        {
                            key: 'checkIn',
                            label: 'Nhận phòng',
                        },
                        {
                            key: 'checkOut',
                            label: 'Trả phòng',
                        },
                        {
                            key: 'total',
                            label: 'Chi phí',
                        },
                    ]"
                    @row-clicked="
                        (booking, $index, $event) => {
                            $event.stopPropagation();
                            $refs.context_receptionist_booking.open(
                                currentEvent || $event,
                                {
                                    booking,
                                },
                            );
                            currentEvent = null;
                        }
                    "
                >
                    <template v-slot:cell(index)="data">
                        {{ data.index + 1 }}
                    </template>
                    <template v-slot:cell(room)="{ value }">
                        Phòng {{ value.name }}
                    </template>
                    <template v-slot:cell(patrons)="{ value }">
                        {{ value.length }} khách
                    </template>
                    <template v-slot:cell(checkIn)="{ item }">
                        {{ checkIn(item) }}
                    </template>
                    <template v-slot:cell(checkOut)="{ item }">
                        {{ checkOut(item) }}
                    </template>
                    <template v-slot:cell(total)="{ value }">
                        {{ toMoney(value) }}
                    </template>
                </b-table>
                <div class="my-1 font-weight-medium text-right">
                    Tổng cộng:
                    {{ toMoney(bill.totalPrice) }}
                </div>
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { checkIn, checkOut } from './popup-bill-detail.helper';
import { GetBillQuery, GetBill } from '~/graphql/types';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { getBill } from '~/graphql/documents';
import { toDate, toMoney } from '~/utils';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-booking-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({
        toDate,
        toMoney,
        getBill,
        checkIn,
        checkOut,
    }),
) {
    variables!: GetBill.Variables;
    bill!: GetBill.Bill;
    currentEvent: MouseEvent | null = null;

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    async onResult({ data }: ApolloQueryResult<GetBillQuery>) {
        this.bill = data.bill;
    }

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');

        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }
}
</script>
