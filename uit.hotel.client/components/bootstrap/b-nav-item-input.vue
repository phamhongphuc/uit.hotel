<template>
    <b-nav-item class="nav-item-input">
        <icon- :i="icon" />
        <input
            :class="`pl-0 pr-3 pl-${reverseWhen}-3 pr-${reverseWhen}-0`"
            :placeholder="placeholder"
            :value="value"
            type="text"
            @input="$emit('input', $event.target.value)"
            @focus="$emit('update:focus', true)"
            @blur="$emit('update:focus', false)"
        />
    </b-nav-item>
</template>
<script lang="ts">
import { Prop, Component, mixins } from 'nuxt-property-decorator';
import { IconProps, InputProps } from '~/components/mixins';

@Component({
    name: 'b-nav-item-input-',
})
export default class extends mixins<IconProps, InputProps>(
    IconProps,
    InputProps,
) {
    @Prop({ default: '' })
    reverseWhen!: string;
}
</script>
<style lang="scss">
.nav-item-input {
    background: rgba(black, 0.05);
    border-radius: 0.5 * $navbar-size;
    transition: border 0.2s;
    input {
        flex-grow: 1;
        min-width: 0;
        height: $navbar-size;
        padding-top: 0;
        padding-bottom: 0;
        background: transparent;
        border: none;
        outline: none;
    }
}
</style>
