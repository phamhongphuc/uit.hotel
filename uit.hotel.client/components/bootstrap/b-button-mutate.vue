<template>
    <b-button
        :block="block"
        :disabled="disabled"
        :size="size"
        :variant="variant"
        :type="type"
        :pressed="pressed"
        @click="$emit('click') && mutate()"
    >
        <slot />
    </b-button>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { MutableMixin, ButtonProps } from '~/components/mixins';

@Component({
    name: 'b-button-mutate-',
})
export default class extends mixins<MutableMixin, ButtonProps>(
    MutableMixin,
    ButtonProps,
) {}
</script>
