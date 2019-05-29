<template>
    <table class="timeline table-hover">
        <div class="now-fill" :style="nowStyle" />
        <div class="now-line" :style="nowStyle" />
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
                <td class="room">Phòng {{ room.name }}</td>
                <td class="bookings">
                    <b-button
                        v-for="booking in mapBookings(room)"
                        :key="booking.id"
                        :style="booking.style"
                        :variant="booking.variant"
                        class="booking shadow-sm"
                    >
                        {{ booking.id }}
                    </b-button>
                </td>
                <td v-for="(day, dayIndex) in days" :key="dayIndex" />
            </tr>
        </template>
    </table>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';
import { GetTimeline } from '~/graphql/types';
import moment from 'moment';

enum StatusEnum {
    Booked,
    CheckedIn,
    RequestedCheckOut,
    CheckedOut,
}

type StatusEnumMap = { [key in StatusEnum]: string };

const statusEnumMap: StatusEnumMap = {
    [StatusEnum.Booked]: 'light-blue',
    [StatusEnum.CheckedIn]: 'orange',
    [StatusEnum.RequestedCheckOut]: 'light-red',
    [StatusEnum.CheckedOut]: 'gray',
};

@Component({
    name: 'booking-timeline-',
})
export default class extends Vue {
    @Prop({ required: true })
    floors!: GetTimeline.Floors[];

    seconds = moment.duration(1, 'day').asSeconds();
    ratio = 5;

    get filteredFloors() {
        return this.floors
            .filter(f => f.isActive)
            .sort((f1, f2) => (f1.name > f2.name ? 1 : -1));
    }

    get timeBound() {
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
                        max: Math.max(max, outTime),
                        min: Math.min(min, inTime),
                    };
                },
                { min: Infinity, max: -Infinity },
            );
        return {
            min: moment
                .unix(min)
                .startOf('day')
                .set({ hour: 12 })
                .unix(),
            max: moment
                .unix(max)
                .add(1, 'day')
                .startOf('day')
                .set({ hour: 12 })
                .unix(),
        };
    }

    now = moment().unix();

    get nowValue() {
        const {
            timeBound: { max },
            ratio,
            now,
        } = this;
        return ((max - now) / this.seconds) * ratio + 'rem';
    }
    get nowStyle() {
        return {
            right: this.nowValue,
        };
    }

    get bookingsColStyle() {
        const {
            timeBound: { min, max },
            ratio,
        } = this;
        return {
            minWidth: ((max - min) / this.seconds) * ratio + 'rem',
        };
    }

    get days() {
        const {
            timeBound: { min, max },
        } = this;
        const length = (max - min) / this.seconds;
        const startDay = moment.unix(min);
        return Array.from({ length }, (v, index) =>
            startDay.clone().add(index, 'days'),
        ).map(day => ({
            dayOfWeek: day.format('dd'),
            day: day.format('DD'),
        }));
    }

    mapBookings(room: GetTimeline.Rooms) {
        const {
            timeBound: { min },
            ratio,
        } = this;
        return room.bookings.map(booking => {
            const inTime = moment(booking.bookCheckInTime).unix();
            const outTime = moment(booking.bookCheckOutTime).unix();

            const left = ((inTime - min) * ratio) / this.seconds;
            const right = ((outTime - min) * ratio) / this.seconds;
            const width = right - left;

            return {
                ...booking,
                style: {
                    left: left + 'rem',
                    width: width + 'rem',
                },
                variant: statusEnumMap[booking.status],
            };
        });
    }
}
</script>
<style lang="scss">
$border: $border-width solid $border-color;

table.timeline {
    position: relative;
    flex: 1;
    > div[class^='now-'] {
        position: absolute;
        top: 0;
        bottom: $border-width;
        &.now-fill {
            left: 0;
            z-index: 2;
            background-color: rgba($blue, 0.125);
        }
        &.now-line {
            z-index: 5;
            width: 1px;
            background: $blue;
            box-shadow: -2px 0 0.25rem rgba($blue, 0.8);
        }
    }

    > tr > td {
        padding: 1rem;
        white-space: nowrap;
        border: $border;
        &.floor {
            position: relative;
            z-index: 2;
            background-color: $white;
        }
        &.room {
            position: sticky;
            left: -2px;
            z-index: 4 !important;
            min-width: 10rem;
            background-color: $white;
            border-right: none;
            box-shadow: 1px 0 0 0 $border-color;
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
                margin: 0.5rem;
                box-shadow: none;
            }
        }
        &.day {
            padding: 0.5rem;
            text-align: center;
        }
    }

    > tr.header-row {
        > td {
            position: sticky;
            top: -2px;
            z-index: 3;
            background-color: $white;
            box-shadow: 0 1px 0 0 $border-color, 1px 0 0 0 $border-color;
            &.room {
                z-index: 5 !important;
            }
        }
    }

    &::-webkit-scrollbar {
        background-color: $white;
        border-radius: $border-radius;
    }
}
</style>