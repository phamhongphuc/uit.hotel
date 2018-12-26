<template>
    <div class="b-input">
        <div class="icon">{{ icon }}</div>
        <input
            class="pl-0 pr-3"
            :type="type"
            :placeholder="placeholder"
            :value="value"
            @input="$emit('input', $event.target.value)"
            @focus="$emit('update:focus', true)"
            @blur="$emit('update:focus', false)"
        />
    </div>
</template>
<script lang="ts">
import { Vue, Prop, Component } from 'nuxt-property-decorator';

@Component
export default class extends Vue {
    @Prop({ default: '' })
    value: string;

    @Prop({ default: 'text' })
    type: string;

    @Prop({ default: '' })
    placeholder: string;

    @Prop({ default: '', validator: icon => icon.length === 1 })
    icon: string;
}
</script>
<style lang="scss">
.b-input {
    background: rgba(black, 0.1);
    transition: border 0.2s;
    border-radius: 0.5 * $input-size;
    display: flex;
    > .icon {
        display: block;
        text-align: center;
        font-size: 1rem;
        margin-left: $input-size / 10;
        padding: 0;
        width: $input-size;
        min-width: $input-size;
        min-height: $input-size;
        line-height: $input-size;
    }
    > input {
        background: transparent;
        outline: none;
        height: $input-size;
        border: none;
        padding-top: 0;
        padding-bottom: 0;
        min-width: 0;
        flex-grow: 1;
    }
}
</style>
