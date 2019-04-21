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
import { Vue, Component, Prop } from 'nuxt-property-decorator';
import { InputProps, IconProps, StateProps } from '~/components/mixins/props';

@Component({
    name: 'b-input-',
    mixins: [IconProps, InputProps, StateProps],
})
export default class extends Vue {
    @Prop({ default: null })
    title!: string;
}
</script>
<style lang="scss">
$input-icon-margin-left: 0.25rem;

.b-input {
    transition: border 0.2s;
    display: flex;
    position: relative;
    > .icon {
        position: absolute;
        display: block;
        text-align: center;
        font-size: 1rem;
        width: $input-height;
        min-width: $input-height;
        min-height: $input-height;
        line-height: $input-height;
    }

    > input {
        outline: none;
        border: none;
        min-width: 0;
        flex-grow: 1;
        padding-left: calc(
            #{$input-height-inner} + #{$input-height-border} - 0.125rem
        );
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
