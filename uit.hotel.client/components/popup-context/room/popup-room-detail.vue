<template>
    <popup-
        ref="popup"
        v-slot
        title="Chi tiết phòng"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getRoom"
            :variables="variables"
            @result="onResult"
        >
            <div class="p-3">
                <div class="d-flex m-child-1 flex-wrap">
                    <div class="font-weight-medium p-1">
                        Trạng thái:
                        <span>
                            <icon-
                                i="circle-fill"
                                class="m-1"
                                :class="`text-${roomColorMap(room.isActive)}`"
                            />
                            {{ roomTitleMap(room.isActive) }}
                        </span>
                    </div>
                    <div class="font-weight-medium py-1 pr-1 mr-auto">
                        <icon-
                            i="circle-fill"
                            class="mx-1"
                            :class="room.isClean ? 'text-blue' : 'text-yellow'"
                        />
                        {{ room.isClean ? 'Phòng đã dọn' : 'Phòng chưa dọn' }}
                    </div>
                    <b-button-mutate-
                        class="px-2 py-1 ml-2"
                        variant="lighten"
                        :mutation="setIsCleanRoom"
                        :variables="{
                            id: room.id,
                            isClean: !room.isClean,
                        }"
                    >
                        <icon- i="broom" class="ml-n1 mr-1" />
                        {{
                            room.isClean
                                ? 'Đánh dấu là chưa dọn'
                                : 'Đánh dấu là đã dọn'
                        }}
                    </b-button-mutate->
                </div>
                <div class="font-weight-medium my-1 pl-1">
                    Loại phòng:
                    <b-link
                        class="text-main"
                        href="#"
                        @click="
                            refs.room_kind_detail.open({ id: room.roomKind.id })
                        "
                    >
                        {{ room.roomKind.name }}
                    </b-link>
                </div>
                <div class="font-weight-medium my-1 pl-1">
                    Các lần thuê phòng:
                </div>
                <div class="mb-1 overflow-auto">
                    <b-table
                        class="table-style table-sm bg-lighten rounded overflow-hidden"
                        show-empty
                        :items="room.bookings"
                        :fields="[
                            {
                                key: 'index',
                                label: '#',
                                class: 'table-cell-id text-center',
                                sortable: true,
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
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import {
    checkOutFormatter,
    checkInFormatter,
} from '~/components/popup-context/bill/popup-bill-detail.helper';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetRoom, GetRoomQuery } from '~/graphql/types';
import { getRoom, setIsCleanRoom } from '~/graphql/documents';
import { toMoney } from '~/utils';
import {
    roomTitleMap,
    roomColorMap,
    bookingStatusMap,
    bookingStatusColorMap,
} from '~/modules/model';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-room-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType, {}>(
    PopupMixin,
    DataMixin({
        bookingStatusColorMap,
        bookingStatusMap,
        checkInFormatter,
        checkOutFormatter,
        getRoom,
        roomColorMap,
        roomTitleMap,
        setIsCleanRoom,
        toMoney,
    }),
) {
    variables!: GetRoom.Variables;
    room!: GetRoom.Room;

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    onResult({ data }: ApolloQueryResult<GetRoomQuery>) {
        this.room = data.room;
    }
}
</script>
