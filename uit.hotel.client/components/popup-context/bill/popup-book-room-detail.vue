<template>
    <div class="room-booking-details" :class="{ hide: !isShow }">
        <div class="room-title" @click.stop="isShow = !isShow">
            <icon- i="chevron-down" />
            <span class="mr-auto">Phòng {{ row.room.name }}</span>
            <span>{{ row.patrons.length }} người</span>
            <icon-
                i="plus"
                class="ml-2"
                @click.native.stop="$emit('add-patron')"
            />
            <icon-
                i="trash-2"
                @click.native.stop="$emit('remove-room', row.room.id)"
            />
        </div>
        <table class="patrons-table table">
            <tr v-for="(patron, index) in row.patrons" :key="patron.id">
                <td>{{ index + 1 }}</td>
                <td>{{ patron.name }}</td>
                <td>{{ patron.identification }}</td>
                <td>{{ patron.gender ? 'Nam' : 'Nữ' }}</td>
                <td>{{ moment(patron.birthdate).format('YYYY') }}</td>
                <td>
                    <div class="d-flex">
                        <icon-
                            i="star"
                            :class="{
                                'is-owner': patron.isOwner,
                            }"
                            @click.native.stop="
                                $emit('select-patron', patron.id)
                            "
                        />
                        <icon-
                            i="trash-2"
                            @click.native.stop="
                                $emit('remove-patron', patron.id)
                            "
                        />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</template>
<script lang="ts">
import moment from 'moment';
import { Component, Prop, mixins } from 'nuxt-property-decorator';
import { TableDataType } from './popup-book.helper';
import { DataMixin } from '~/components/mixins';

@Component({
    name: 'popup-book-room-detail-',
})
export default class extends mixins<{ moment: typeof moment }>(
    DataMixin({ moment }),
) {
    isShow = true;

    @Prop({ required: true })
    row!: TableDataType;
}
</script>
<style lang="scss">
.room-booking-details {
    $border-color: $gray-500;
    $row-size: 1.75rem;
    $space-size: 0.375rem;

    &:not(:last-child) {
        border-bottom: 1px solid $border-color;
    }
    .icon {
        width: $row-size;
        height: $row-size;
        line-height: $row-size;
        text-align: center;
        border-radius: $border-radius;
        cursor: pointer;
        transition: background-color 0.1s;
        &:hover {
            background-color: rgba($black, 0.1);
        }
        &:active {
            background-color: rgba($black, 0.2);
        }
        &.is-owner {
            background-color: rgba($main, 0.5);
        }
    }

    > .room-title {
        display: flex;
        box-sizing: content-box;
        height: $row-size;
        padding: $space-size;
        line-height: $row-size;
        border-bottom: 1px solid $border-color;
        cursor: pointer;
        &:hover {
            background-color: rgba($black, 0.1);
        }
        > .icon {
            width: $row-size;
            text-align: center;
            transition: transform 0.2s;
            &:first-child {
                margin-right: $space-size;
            }
        }
    }
    > .patrons-table {
        > tr {
            &:hover {
                background-color: rgba($black, 0.1);
            }
            > td {
                vertical-align: middle;
                &:not(:first-child) {
                    padding: $space-size 0.75rem;
                    border-left: 1px solid $border-color;
                }
                &:first-child {
                    box-sizing: content-box;
                    min-width: $row-size;
                    padding: $space-size;
                    text-align: center;
                }
                &:last-child {
                    padding: $space-size;
                }
                &:nth-child(2) {
                    width: 100%;
                }
            }
            &:not(:last-child) {
                > td {
                    border-bottom: 1px solid $border-color;
                }
            }
        }
    }

    &.hide {
        > .room-title {
            border-bottom: none;
            > span:first-child {
                transform: rotateX(180deg);
            }
        }
        > .patrons-table {
            display: none;
        }
    }
}
</style>
