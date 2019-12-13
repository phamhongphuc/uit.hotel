<template>
    <div :class="{ 'has-icon': icon !== null }" class="b-input">
        <icon- v-if="icon" :i="icon" />
        <input
            v-money="money"
            type="tel"
            class="v-money form-control"
            :class="
                state !== null && {
                    'is-valid': state,
                    'is-invalid': !state,
                }
            "
            :value="value"
            :aria-invalid="ariaInvalid"
            :readonly="readonly"
            :autocomplete="autocomplete"
            :placeholder="placeholder"
            :disabled="disabled"
            @change="onChange"
            @focus="$emit('update:focus', true)"
            @blur="$emit('update:focus', false)"
        />
    </div>
</template>
<script lang="ts">
import { Component, Prop, mixins } from 'nuxt-property-decorator';
import { VMoney } from 'v-money';
import { unformat } from './b-input-money.helper';
import {
    InputProps,
    IconProps,
    StateProps,
    DataMixin,
} from '~/components/mixins';

const money = {
    decimal: '.',
    thousands: ',',
    prefix: '',
    suffix: ' ₫',
    precision: 0,
    masked: true,
};

@Component({
    name: 'b-input-money-',
    directives: { money: VMoney },
})
export default class extends mixins<
    { money: typeof money },
    IconProps,
    InputProps,
    StateProps
>(DataMixin({ money }), IconProps, InputProps, StateProps) {
    @Prop({ default: null })
    title!: string;

    @Prop({
        type: [Number, String],
        default: 0,
    })
    value!: number | string;

    onChange(event: InputEvent) {
        if (event.target && 'value' in event.target) {
            const { value } = event.target as HTMLInputElement;
            this.$emit('input', unformat(value, this.money.precision));
        }
    }
}
</script>
<style lang="scss">
.v-money {
    text-align: right;
}
</style>
