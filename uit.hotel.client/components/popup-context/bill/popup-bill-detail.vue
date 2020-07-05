<template>
    <popup-
        ref="popup"
        v-slot
        :title="`Chi tiết hóa đơn #${id}`"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getBill"
            :variables="variables"
            @result="onResult"
        >
            <div class="p-3">
                <div class="d-flex m-child-1 flex-wrap">
                    <div class="p-1 font-weight-medium mr-auto">
                        Trạng thái thanh toán:
                        <span>
                            <icon-
                                i="circle-fill"
                                class="m-1"
                                :class="`text-${
                                    billStatusColorMap[bill.status]
                                }`"
                            />
                            {{ billStatusMap(bill.status, bill.time) }}
                        </span>
                    </div>
                    <b-button
                        v-if="bill.status === BillStatusEnum.Pending"
                        size="sm"
                        variant="lighten"
                        @click="refs.bill_update_discount.open({ bill })"
                    >
                        <icon- class="mr-1" i="discount" />
                        <span>Giảm giá</span>
                    </b-button>
                    <b-button-mutate-
                        v-if="
                            bill.status === BillStatusEnum.Pending && rest === 0
                        "
                        size="sm"
                        variant="lighten"
                        :mutation="payTheBill"
                        :variables="{ id }"
                    >
                        <icon- class="mr-1" i="card" />
                        Chốt hóa đơn
                    </b-button-mutate->
                    <b-button
                        v-if="bill.status !== BillStatusEnum.Success"
                        size="sm"
                        variant="green"
                        @click="refs.receipt_add.open({ bill })"
                    >
                        <icon- class="mr-1" i="card-down" />
                        <span>Thanh toán</span>
                    </b-button>
                </div>
                <div class="p-1 font-weight-medium mr-auto">
                    Đứng tên hóa đơn:
                    <b-link href="#" class="text-blue">
                        {{ bill.patron.name }}
                    </b-link>
                </div>
                <div
                    v-if="bill.bookings.length !== 0"
                    class="font-weight-medium my-1 pl-1"
                >
                    Danh sách phòng:
                </div>
                <div
                    v-if="bill.bookings.length !== 0"
                    class="my-1 overflow-auto"
                >
                    <b-table
                        class="table-style table-sm bg-lighten rounded overflow-hidden"
                        :items="bill.bookings"
                        :fields="[
                            {
                                key: 'index',
                                label: '#',
                                class: 'table-cell-id text-center',
                            },
                            {
                                key: 'room',
                                label: 'Phòng',
                                formatter: room => `Phòng ${room.name}`,
                            },
                            {
                                key: 'patrons',
                                label: 'Khách',
                                formatter: patrons => `${patrons.length} khách`,
                            },
                            {
                                key: 'checkIn',
                                label: 'Nhận phòng',
                                formatter: checkInFormatter,
                            },
                            {
                                key: 'checkOut',
                                label: 'Trả phòng',
                                formatter: checkOutFormatter,
                            },
                            {
                                key: 'status',
                                label: 'Trạng thái',
                            },
                            {
                                key: 'total',
                                label: 'Chi phí',
                                formatter: toMoney,
                            },
                        ]"
                        @row-clicked="
                            (booking, $index, $event) => {
                                $event.stopPropagation();
                                refs.context_booking.open(
                                    currentEvent || $event,
                                    { booking },
                                );
                                currentEvent = null;
                            }
                        "
                    >
                        <template v-slot:cell(index)="data">
                            {{ data.index + 1 }}
                        </template>
                        <template v-slot:cell(status)="{ value }">
                            <icon-
                                class="mr-1"
                                i="circle-fill"
                                :class="`text-${bookingStatusColorMap[value]}`"
                            />
                            {{ bookingStatusMap[value] }}
                        </template>
                    </b-table>
                </div>
                <div
                    v-if="bill.bookings.length !== 0"
                    class="mt-1 mb-2 font-weight-medium text-right"
                >
                    Tổng cộng:
                    <span class="text-blue">
                        {{ toMoney(bill.totalPrice) }}
                    </span>
                </div>
                <div class="d-flex m-child-1 flex-wrap mb-1">
                    <div class="p-1 font-weight-medium mr-auto">
                        Danh sách phiếu thu:
                    </div>
                    <b-button
                        size="sm"
                        variant="lighten"
                        @click="receiptShow = !receiptShow"
                    >
                        <icon-
                            class="mr-1"
                            :class="receiptShow ? '' : 'text-green'"
                            :i="receiptShow ? 'circle' : 'circle-fill'"
                        />
                        <span>
                            {{
                                receiptShow
                                    ? 'Đang hiện tất cả'
                                    : 'Đang ẩn các giao dịch lỗi'
                            }}
                        </span>
                    </b-button>
                </div>
                <div class="my-1 overflow-auto">
                    <b-table
                        class="table-style table-sm table-cell-middle bg-lighten rounded overflow-hidden text-nowrap"
                        show-empty
                        :items="receipts"
                        :fields="[
                            {
                                key: 'orderId',
                                label: 'Mã giao dịch',
                                class: 'table-cell-id text-left',
                                tdClass: 'text-monospace',
                            },
                            {
                                key: 'time',
                                label: 'Thời gian',
                                class: 'text-center',
                                formatter: toDateTime,
                            },
                            {
                                key: 'kind',
                                label: 'Hình thức',
                                class: '',
                            },
                            {
                                key: 'status',
                                label: 'Trạng thái',
                                class: '',
                            },
                            {
                                key: 'money',
                                label: 'Số tiền',
                                class: 'text-right',
                                formatter: toMoney,
                            },
                        ]"
                    >
                        <template v-slot:empty>
                            Chưa có phiếu thu nào được tạo
                        </template>
                        <template v-slot:cell(index)="data">
                            {{ data.index + 1 }}
                        </template>
                        <template v-slot:cell(kind)="{ value }">
                            <icon-
                                class="mr-1"
                                :i="ReceiptKindIconMap[value]"
                                :class="`text-${ReceiptKindColorMap[value]}`"
                            />
                            {{ ReceiptKindTitleMap[value] }}
                        </template>
                        <template
                            v-slot:cell(status)="{
                                value,
                                item,
                                item: { kind, statusText },
                            }"
                        >
                            <div
                                class="d-flex m-child-1 align-items-center mr-n2"
                            >
                                <icon-
                                    class="mr-1"
                                    i="circle-fill"
                                    :class="`text-${ReceiptStatusColorMap[value]}`"
                                />
                                <span class="mr-2">
                                    {{ statusText }}
                                </span>
                                <b-button
                                    v-if="
                                        kind == ReceiptKindEnum.Momo &&
                                        value == ReceiptStatusEnum.Pending
                                    "
                                    size="sm"
                                    class="shadow-none ml-auto"
                                    variant="momo"
                                    @click="
                                        refs.receipt_pay_momo.open({
                                            receipt: item,
                                        })
                                    "
                                >
                                    <icon- i="card-down" class="mr-1" />
                                    Thanh toán
                                </b-button>
                            </div>
                        </template>
                    </b-table>
                </div>
                <div class="my-1 font-weight-medium text-right">
                    Đã thanh toán:
                    <span class="text-blue">
                        {{ toMoney(bill.totalReceipts) }}
                    </span>
                </div>
                <div class="my-1 font-weight-medium text-right">
                    Giảm giá:
                    <span class="text-yellow">
                        {{ toMoney(bill.discount) }}
                    </span>
                </div>
                <div class="mt-1 font-weight-medium text-right font-size-6">
                    Chưa thanh toán:
                    <span class="text-red">
                        {{ toMoney(rest, true) }}
                    </span>
                </div>
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins, Watch } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import {
    checkInFormatter,
    checkOutFormatter,
} from './popup-bill-detail.helper';
import {
    BillStatusEnum,
    BookingStatusEnum,
    GetBill,
    GetBillQuery,
    ReceiptKindEnum,
    ReceiptStatusEnum,
} from '~/graphql/types';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { getBill, payTheBill } from '~/graphql/documents';
import { toDateTime, toMoney, isMinDate, fromNow } from '~/utils';
import {
    billStatusColorMap,
    billStatusMap,
    bookingStatusColorMap,
    bookingStatusMap,
    ReceiptKindColorMap,
    ReceiptKindIconMap,
    ReceiptKindTitleMap,
    ReceiptStatusColorMap,
} from '~/modules/model';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-bill-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType, {}>(
    PopupMixin,
    DataMixin({
        billStatusColorMap,
        BillStatusEnum,
        billStatusMap,
        bookingStatusColorMap,
        BookingStatusEnum,
        bookingStatusMap,
        checkInFormatter,
        checkOutFormatter,
        fromNow,
        getBill,
        isMinDate,
        payTheBill,
        ReceiptKindColorMap,
        ReceiptKindEnum,
        ReceiptKindIconMap,
        ReceiptKindTitleMap,
        ReceiptStatusColorMap,
        ReceiptStatusEnum,
        toDateTime,
        toMoney,
    }),
) {
    variables!: GetBill.Variables;

    bill!: GetBill.Bill;
    receipts: GetBill.Receipts[] = [];
    id = -1;
    rest = 0;
    receiptShow = false;

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    async onResult({ data: { bill } }: ApolloQueryResult<GetBillQuery>) {
        this.bill = bill;
        this.id = bill.id;
        this.rest = bill.totalPrice - bill.totalReceipts - bill.discount;
        this.setReceipts();
    }

    @Watch('receiptShow')
    setReceipts() {
        this.receipts = this.receiptShow
            ? this.bill.receipts
            : this.bill.receipts.filter(
                  r =>
                      r.status === ReceiptStatusEnum.Pending ||
                      r.status === ReceiptStatusEnum.Success,
              );
    }
}
</script>
