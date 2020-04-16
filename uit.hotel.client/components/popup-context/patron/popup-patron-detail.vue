<template>
    <popup-
        ref="popup"
        v-slot
        title="Chi tiết khách hàng"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getPatron"
            :variables="variables"
            @result="onResult"
        >
            <div class="p-3">
                <div class="d-flex m-child-1 flex-wrap">
                    <div class="p-1 font-weight-medium mr-auto">
                        Tên khách hàng:
                        <span class="text-main">
                            {{ patron.name }}
                        </span>
                    </div>
                    <b-button
                        class="ml-2"
                        size="sm"
                        variant="lighten"
                        @click="refs.patron_update.open({ id: patron.id })"
                    >
                        <icon- class="mr-1" i="edit-2" />
                        <span>Sửa thông tin khách hàng</span>
                    </b-button>
                </div>
                <div class="row mt-2">
                    <div class="col-6">
                        <div class="px-1">
                            <b-table-simple
                                small
                                borderless
                                class="table-key-value"
                            >
                                <b-tbody>
                                    <b-tr>
                                        <b-td>Chứng minh nhân dân</b-td>
                                        <b-td>{{ patron.identification }}</b-td>
                                    </b-tr>
                                    <b-tr>
                                        <b-td>Loại khách hàng</b-td>
                                        <b-td>
                                            <b-link
                                                class="text-main"
                                                href="#"
                                                @click="
                                                    refs.patronKind_detail.open(
                                                        {
                                                            id:
                                                                patron
                                                                    .patronKind
                                                                    .id,
                                                        },
                                                    )
                                                "
                                            >
                                                {{ patron.patronKind.name }}
                                            </b-link>
                                        </b-td>
                                    </b-tr>
                                    <b-tr>
                                        <b-td>Giới tính</b-td>
                                        <b-td>
                                            {{ patron.gender ? 'Nam' : 'Nữ' }}
                                        </b-td>
                                    </b-tr>
                                    <b-tr>
                                        <b-td>Số điện thoại</b-td>
                                        <b-td>
                                            <a
                                                v-if="
                                                    patron.phoneNumber !== '' &&
                                                        patron.phoneNumber !==
                                                            null
                                                "
                                                :href="
                                                    `tel:${patron.phoneNumber}`
                                                "
                                                @click.stop
                                            >
                                                {{ patron.phoneNumber }}
                                            </a>
                                            <span v-else>-</span>
                                        </b-td>
                                    </b-tr>
                                    <b-tr>
                                        <b-td>Thư điện tử</b-td>
                                        <b-td>
                                            <a
                                                v-if="
                                                    patron.email !== '' &&
                                                        patron.email !== null
                                                "
                                                :href="`mailto:${patron.email}`"
                                                @click.stop
                                            >
                                                {{ patron.email }}
                                            </a>
                                            <span v-else>-</span>
                                        </b-td>
                                    </b-tr>
                                </b-tbody>
                            </b-table-simple>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="px-1">
                            <b-table-simple
                                small
                                borderless
                                class="table-key-value"
                            >
                                <b-tbody>
                                    <b-tr>
                                        <b-td>Ngày sinh</b-td>
                                        <b-td>
                                            {{ toDate(patron.birthdate) }}
                                        </b-td>
                                    </b-tr>

                                    <b-tr>
                                        <b-td>Hộ khẩu</b-td>
                                        <b-td>
                                            {{ dash(patron.residence) }}
                                        </b-td>
                                    </b-tr>
                                    <b-tr>
                                        <b-td>Nguyên quán</b-td>
                                        <b-td>
                                            {{ dash(patron.domicile) }}
                                        </b-td>
                                    </b-tr>
                                    <b-tr>
                                        <b-td>Quốc tịch</b-td>
                                        <b-td>
                                            {{ dash(patron.nationality) }}
                                        </b-td>
                                    </b-tr>
                                    <b-tr>
                                        <b-td>Công ty</b-td>
                                        <b-td>
                                            {{ dash(patron.company) }}
                                        </b-td>
                                    </b-tr>
                                </b-tbody>
                            </b-table-simple>
                        </div>
                    </div>
                </div>
                <hr class="my-2" />
                <div class="px-1 pb-1 pt-0 font-weight-medium mr-auto">
                    Các phòng đã đặt:
                </div>
                <b-table
                    class="table-style table-sm bg-lighten rounded overflow-hidden"
                    :items="patron.bookings"
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
                            refs.context_booking.open(currentEvent || $event, {
                                booking,
                            });
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
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import {
    checkInFormatter,
    checkOutFormatter,
} from '../bill/popup-bill-detail.helper';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetPatron, GetPatronQuery } from '~/graphql/types';
import { getPatron, setIsActiveAccount } from '~/graphql/documents';
import { toDate, toMoney, dash } from '~/utils';
import { bookingStatusColorMap, bookingStatusMap } from '~/modules/model';

type PopupMixinType = PopupMixin<{ id: number | string }, null>;

@Component({
    name: 'popup-patron-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType, {}>(
    PopupMixin,
    DataMixin({
        bookingStatusColorMap,
        bookingStatusMap,
        checkInFormatter,
        checkOutFormatter,
        dash,
        getPatron,
        setIsActiveAccount,
        toDate,
        toMoney,
    }),
) {
    variables!: GetPatron.Variables;
    patron!: GetPatron.Patron;

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    onResult({ data: { patron } }: ApolloQueryResult<GetPatronQuery>) {
        this.patron = patron;
    }
}
</script>
