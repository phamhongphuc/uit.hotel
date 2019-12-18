<template>
    <div class="horizontal-timeline" :style="style">
        <div class="d-flex m-child-1 flex-wrap">
            <div class="py-1 px-1 font-weight-medium">
                <icon-
                    i="circle-fill"
                    class="mr-1"
                    :class="`text-${statusColor}`"
                />
                {{ status }}
            </div>
            <div class="py-1 px-1 font-weight-medium">
                <icon- i="clock" class="mr-1" />
                {{ remain }}
            </div>
            <b-button class="ml-auto p-1" variant="lighten" @click="zoomOut">
                <icon- i="zoom-out" class="ml-0" />
            </b-button>
            <b-button class="p-1" variant="lighten" @click="zoomIn">
                <icon- i="zoom-in" class="ml-0" />
            </b-button>
        </div>
        <div class="overflow-auto mt-2">
            <div
                class="line-container rounded bg-lighten"
                :style="lineContainerStyle()"
            >
                <div
                    v-for="(day, index) in days"
                    ref="vertical-line"
                    :key="`vertical-line-${index}`"
                    :class="{
                        last: index == days.length - 1,
                        first: index == 0,
                    }"
                    class="vertical-line"
                >
                    <span v-if="index != days.length - 1">{{ day }}</span>
                </div>

                <horizontal-timeline-horizontal-line- :line="0" />
                <horizontal-timeline-horizontal-line- :line="1" />

                <horizontal-timeline-range-
                    class="text-white bg-blue"
                    :line="0"
                    :range="[left, right]"
                >
                    <div class="title">
                        Phòng {{ booking.room.name }} -
                        {{ booking.room.roomKind.name }}
                    </div>
                    <div class="text">
                        {{ toDateTime(left) }} —
                        {{ toDateTime(right) }}
                    </div>
                </horizontal-timeline-range->

                <horizontal-timeline-range-
                    v-if="booking.earlyCheckInFee !== 0"
                    id="early-check-in-fee-price"
                    class="text-white bg-light-red bg-stripes"
                    price
                    space-right
                    :line="1"
                    :range="[left, booking.baseNightCheckInTime]"
                >
                    <b-tooltip
                        target="early-check-in-fee-price"
                        boundary="window"
                    >
                        Nhận phòng sớm:
                        <br />
                        {{ earlyCheckInHour }} giờ ✕
                        {{ toMoney(booking.price.earlyCheckInFee) }} =
                        {{ toMoney(booking.earlyCheckInFee) }}
                    </b-tooltip>
                </horizontal-timeline-range->

                <horizontal-timeline-range-
                    v-if="booking.lateCheckOutFee !== 0"
                    id="late-check-out-fee-price"
                    class="text-white bg-light-red bg-stripes"
                    price
                    space-left
                    :line="1"
                    :range="[booking.baseDayCheckOutTime, right]"
                >
                    <b-tooltip
                        target="late-check-out-fee-price"
                        boundary="window"
                    >
                        Trả phòng trễ:
                        <br />
                        {{ lateCheckOutHour }} giờ ✕
                        {{ toMoney(booking.price.lateCheckOutFee) }} =
                        {{ toMoney(booking.lateCheckOutFee) }}
                    </b-tooltip>
                </horizontal-timeline-range->

                <horizontal-timeline-range-
                    v-for="(price, index) in prices"
                    :key="`price-${index}`"
                    v-b-tooltip.window="price.text"
                    class="text-white bg-blue bg-stripes"
                    price
                    :line="price.line"
                    :range="[price.left, price.right]"
                >
                    <div>{{ toMoney(price.value) }}</div>
                </horizontal-timeline-range->

                <horizontal-timeline-range-
                    v-for="(priceVolatility, index) in priceVolatilities"
                    :id="`priceVolatility-${index}`"
                    :key="`priceVolatility-${index}`"
                    class="text-white bg-green bg-stripes"
                    price
                    :line="priceVolatility.line"
                    :range="[priceVolatility.left, priceVolatility.right]"
                >
                    <b-tooltip
                        :target="`priceVolatility-${index}`"
                        boundary="window"
                    >
                        {{ priceVolatility.name }}:
                        <br />
                        {{ priceVolatility.text }}
                    </b-tooltip>
                </horizontal-timeline-range->
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, Prop, mixins, Provide } from 'nuxt-property-decorator';
import { duration } from 'moment';
import _ from 'lodash';
import { getBounding } from './horizontal-timeline.helper';
import { toDateTime, toMoney } from '~/utils';
import { GetBooking } from '~/graphql/types';
import { DataMixin } from '~/components/mixins';
import {
    bookingStatusMap,
    bookingStatusColorMap,
    BookingObject,
    PriceItemRender,
} from '~/modules/model';

@Component({
    name: 'horizontal-timeline-',
})
export default class extends mixins(DataMixin({ toDateTime, toMoney })) {
    @Prop({ required: true })
    booking!: GetBooking.Booking;

    dayWidth = 4;

    get bookingObject() {
        return new BookingObject(this.booking);
    }

    get status() {
        return bookingStatusMap[this.booking.status];
    }

    get statusColor() {
        return bookingStatusColorMap[this.booking.status];
    }

    get remain() {
        return this.bookingObject.remain;
    }

    currentWidth() {
        return (this.$refs['vertical-line'] as HTMLElement[])[1].offsetWidth;
    }

    zoomIn() {
        this.dayWidth = Math.floor(this.currentWidth() / 16) + 1;
    }

    zoomOut() {
        this.dayWidth = Math.floor(this.currentWidth() / 16) - 1;
    }

    get style() {
        return {
            '--day-width': `${this.dayWidth}rem`,
        };
    }

    lineContainerStyle() {
        const lines =
            1 +
            _.chain(this.priceVolatilities)
                .groupBy(item => item.line)
                .values()
                .value().length;
        return {
            height: `calc(var(--main-height) + var(--line-size) + var(--price-space) + (var(--price-space) + var(--price-child)) * ${lines})`,
        };
    }

    get earlyCheckInHour() {
        return this.bookingObject.earlyCheckInHour;
    }

    get lateCheckOutHour() {
        return this.bookingObject.lateCheckOutHour;
    }

    get left() {
        return this.bookingObject.left;
    }

    get right() {
        return this.bookingObject.right;
    }

    get prices(): PriceItemRender[] {
        return this.bookingObject.priceItemsRender;
    }

    get priceVolatilities(): PriceItemRender[] {
        return this.bookingObject.priceVolatilityItemsRender;
    }

    @Provide()
    get min() {
        return getBounding(this.booking.baseNightCheckInTime, true);
    }

    @Provide()
    get max() {
        return getBounding(this.booking.baseDayCheckOutTime, false);
    }

    get days() {
        const { min, max } = this;

        return Array.from(
            { length: duration(max.diff(min)).asDays() },
            (v, index) =>
                min
                    .clone()
                    .add(index + 1, 'day')
                    .format('DD/MM'),
        );
    }
}
</script>
<style lang="scss">
.horizontal-timeline {
    --day-title-height: #{$ht-day-title-height};
    --line-size: #{$ht-line-size};
    --main-height: #{$ht-main-height};
    --price-child: #{$ht-price-child};
    --price-space: #{$ht-price-space};

    .line-container {
        position: relative;
        display: flex;
        box-sizing: content-box;
        width: fit-content;
        min-width: 100%;
        padding-top: $ht-day-title-height + $ht-line-size;

        > .vertical-line {
            position: relative;
            flex: 1;
            min-width: var(--day-width);
            border-color: $ht-line-color;
            border-style: solid;
            border-width: 0 1px;
            transition: all 0.2s;
            > span {
                position: absolute;
                top: -$ht-day-title-height;
                right: 0;
                z-index: 1;
                font-weight: 500;
                line-height: $ht-day-title-height;
                text-align: center;
                transform: translateX(50%);
            }

            &.first {
                border-left-color: transparent;
            }
            &.last {
                border-right-color: transparent;
            }

            &.first,
            &.last {
                flex: 0.25;
                min-width: calc(var(--day-width) * 0.25);
            }
        }
    }
}
</style>
