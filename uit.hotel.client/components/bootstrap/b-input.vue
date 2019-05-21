<template>
    <div :class="{ 'has-icon': icon !== null }" class="b-input">
        <icon- v-if="icon" :i="icon" />
        <b-input
            ref="input"
            :value="value"
            :type="type"
            :aria-invalid="ariaInvalid"
            :readonly="readonly"
            :plaintext="plaintext"
            :autocomplete="autocomplete"
            :placeholder="placeholder"
            :formatter="formatter"
            :lazy-formatter="lazyFormatter"
            :state="state"
            :disabled="disabled"
            @input="$emit('input', $event)"
            @focus="$emit('update:focus', true)"
            @blur="$emit('update:focus', false)"
        />
    </div>
</template>
<script lang="ts">
import { Component, Prop, mixins } from 'nuxt-property-decorator';
import { InputProps, IconProps, StateProps } from '~/components/mixins';

@Component({
    name: 'b-input-',
})
export default class extends mixins<IconProps, InputProps, StateProps>(
    IconProps,
    InputProps,
    StateProps,
) {
    @Prop({ default: null })
    title!: string;
}
</script>
<style lang="scss">
$input-icon-margin-left: 0.25rem;

.b-input {
    position: relative;
    display: flex;
    transition: border 0.2s;
    > .icon {
        position: absolute;
        display: block;
        width: $input-height;
        min-width: $input-height;
        min-height: $input-height;
        font-size: 1rem;
        line-height: $input-height;
        text-align: center;
    }

    > input {
        flex-grow: 1;
        min-width: 0;
        padding-left: calc(
            #{$input-height-inner} + #{$input-height-border} - 0.125rem
        );
        border: none;
        outline: none;
        &:focus {
            outline: none;
        }
    }
    &.circle {
        &,
        input {
            border-radius: calc(0.5 * #{$input-height});
        }
        > .icon {
            margin-left: $input-icon-margin-left;
        }
        &.has-icon {
            > input {
                padding-left: calc(
                    #{$input-height-inner} + #{$input-height-border} + #{$input-icon-margin-left}
                );
            }
        }
    }
}
</style>
