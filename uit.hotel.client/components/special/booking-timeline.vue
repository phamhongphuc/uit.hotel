<template>
    <table
        class="timeline table-hover"
        @mouseenter="tooltip('show')"
        @mouseleave="tooltip('hide')"
    >
        <div class="now-fill" :style="nowStyle" />
        <div id="timeline-now" class="now-line" :style="nowStyle">
            <b-tooltip
                target="timeline-now"
                triggers="manual"
                placement="top"
                boundary="window"
            >
                {{ formattedNow }}
            </b-tooltip>
        </div>
        <tr class="header-row">
            <td />
            <td class="room">Phòng</td>
            <td class="bookings" />
            <td
                v-for="(day, dayIndex) in days"
                :key="dayIndex"
                :style="{ minWidth: ratio + 'rem' }"
                class="day"
            >
                <div>
                    {{ day.day }}
                </div>
                <div>
                    {{ day.dayOfWeek }}
                </div>
            </td>
        </tr>
        <template v-for="floor in filteredFloors">
            <tr v-for="(room, roomIndex) in floor.rooms" :key="room.id">
                <td
                    v-if="roomIndex === 0"
                    class="floor"
                    :rowspan="floor.rooms.length"
                >
                    Tầng {{ floor.name }}
                </td>
                <td
                    v-b-tooltip.hover.right
                    class="room"
                    title="Phòng chưa được dọn"
                    :disabled="room.isClean"
                    @contextmenu.prevent="
                        refs.context_receptionist_room.open($event, { room })
                    "
                >
                    Phòng {{ room.name }}
                    <icon- v-if="!room.isClean" i="broom" class="text-orange" />
                </td>
                <td class="bookings">
                    <b-button
                        v-for="booking in mapBookings(room)"
                        :id="`booking-${booking.id}`"
                        :key="booking.id"
                        :style="booking.style"
                        :variant="booking.variant"
                        class="booking shadow-sm"
                        @dblclick="refs.booking_detail.open({ id: booking.id })"
                        @contextmenu.prevent="
                            refs.context_booking.open($event, { booking })
                        "
                    >
                        <b-tooltip
                            :target="`booking-${booking.id}`"
                            placement="left"
                            boundary="window"
                            triggers="hover"
                        >
                            Từ: {{ booking.inTime }}
                            <br />
                            Đến: {{ booking.outTime }}
                            <br />
                            Trạng thái: {{ booking.statusTitle }}
                        </b-tooltip>
                    </b-button>
                </td>
                <td v-for="(day, dayIndex) in days" :key="dayIndex" />
            </tr>
        </template>
    </table>
</template>
<script lang="ts">
import { Component, Prop, mixins } from 'nuxt-property-decorator';
import moment from 'moment';
import { InjectRefs } from '~/components/mixins';
import { GetTimeline, BookingStatusEnum } from '~/graphql/types';
import { toDateTime } from '~/utils';
import { bookingStatusMap, bookingStatusColorMap } from '~/modules/model';

type BookingStatusEnumMap = { [key in BookingStatusEnum]: string };

const seconds = moment.duration(1, 'day').asSeconds();

@Component({
    name: 'booking-timeline-',
})
export default class extends mixins<InjectRefs>(InjectRefs) {
    @Prop({ required: true })
    floors!: GetTimeline.Floors[];

    ratio = 6;

    now = moment().unix();
    formattedNow = moment().format('HH:mm:ss');

    interval?: NodeJS.Timeout;

    calcValue() {
        this.now = moment().unix();
        this.formattedNow = moment().format('HH:mm:ss');
    }

    mounted() {
        this.calcValue();
        this.interval = setInterval(this.calcValue, 1000);
    }

    beforeDestroy() {
        if (this.interval !== undefined) {
            clearInterval(this.interval);
        }
    }

    get filteredFloors() {
        return this.floors
            .filter(f => f.isActive)
            .sort((f1, f2) => (f1.name > f2.name ? 1 : -1));
    }

    get timeBound() {
        const { now } = this;
        const { min, max } = this.filteredFloors
            .flatMap(floor =>
                floor.rooms
                    .filter(room => room.isActive)
                    .sort((r1, r2) => (r1.name > r2.name ? 1 : -1)),
            )
            .flatMap(room => room.bookings)
            .map(({ bookCheckInTime, bookCheckOutTime }) => ({
                inTime: moment(bookCheckInTime).unix(),
                outTime: moment(bookCheckOutTime).unix(),
            }))
            .reduce(
                ({ min, max }, { inTime, outTime }) => {
                    return {
                        max: Math.max(now, max, outTime),
                        min: Math.min(now, min, inTime),
                    };
                },
                { min: Infinity, max: -Infinity },
            );

        return {
            min: moment
                .unix(min)
                .add(-3, 'day')
                .startOf('day')
                .set({ hour: 12 })
                .unix(),
            max: moment
                .unix(max)
                .add(3, 'day')
                .startOf('day')
                .set({ hour: 12 })
                .unix(),
        };
    }

    get nowStyle() {
        const {
            timeBound: { max },
            ratio,
            now,
        } = this;
        const value = ((max - now) / seconds) * ratio;

        return {
            right: `${value}rem`,
        };
    }

    get days() {
        const {
            timeBound: { min, max },
        } = this;
        const length = (max - min) / seconds;
        const startDay = moment.unix(min);

        return Array.from({ length }, (v, index) =>
            startDay.clone().add(index, 'days'),
        ).map(day => ({
            dayOfWeek: day.format('dddd'),
            day: day.format('DD'),
        }));
    }

    mapBookings(room: GetTimeline.Rooms) {
        const {
            timeBound: { min },
            ratio,
        } = this;

        return room.bookings.map(booking => {
            const inTime = moment(
                booking.status === BookingStatusEnum.Booked
                    ? booking.bookCheckInTime
                    : (booking.realCheckInTime as string),
            ).unix();

            const outTime = moment(
                booking.status === BookingStatusEnum.CheckedOut
                    ? (booking.realCheckOutTime as string)
                    : booking.bookCheckOutTime,
            ).unix();

            const left = ((inTime - min) * ratio) / seconds;
            const right = ((outTime - min) * ratio) / seconds;
            const width = right - left;

            return {
                ...booking,
                outTime: toDateTime(outTime),
                inTime: toDateTime(inTime),
                style: {
                    left: `${left}rem`,
                    width: `${width}rem`,
                },
                variant: bookingStatusColorMap[booking.status],
                statusTitle: bookingStatusMap[booking.status],
            };
        });
    }

    tooltip(action: 'show' | 'hide') {
        this.$root.$emit(`bv::${action}::tooltip`, 'timeline-now');
    }
}
</script>
<style lang="scss">
$border: $border-width solid $border-color;

table.timeline {
    position: relative;
    flex: 1;
    > [class^='now-'] {
        position: absolute;
        top: 0;
        bottom: 0;
        &.now-fill {
            left: 0;
            z-index: 2;
            background-color: rgba($blue, 0.125);
        }
        &.now-line {
            z-index: 5;
            width: 1px;
            background: $blue;
            box-shadow: -1px 0 0.25rem rgba($blue, 0.8);
        }
    }

    > tr > td {
        padding: 1rem;
        white-space: nowrap;
        background-color: rgba($body-bg, 0.5);
        border: $border;
        transition: all 0.2s;
        &.floor {
            position: relative;
            z-index: 2;
            background-color: $white;
        }
        &.room {
            position: sticky;
            left: -1px;
            z-index: 5 !important;
            min-width: 10rem;
            background-color: $white;
            border-right: none;
            box-shadow: 1px 0 0 0 $border-color;
            > span {
                float: right;
            }
        }
        &.bookings {
            position: relative;
            z-index: 2;
            box-sizing: content-box;
            width: 0;
            padding: 0;
            border: none;
            > .booking {
                position: absolute;
                top: 0;
                bottom: 0;
                margin: 0.5rem 0;
                box-shadow: none;
            }
        }
        &.day {
            padding: 0.5rem;
            text-align: center;
            text-transform: capitalize;
        }
    }

    > tr.header-row {
        > td {
            position: sticky;
            top: -1px;
            z-index: 3;
            background-color: $white;
            box-shadow: 0 1px 0 0 $border-color, 1px 0 0 0 $border-color;
            &.room {
                z-index: 6 !important;
            }
        }
    }

    &::-webkit-scrollbar {
        background-color: $white;
        border-radius: $border-radius;
    }
}
</style>
