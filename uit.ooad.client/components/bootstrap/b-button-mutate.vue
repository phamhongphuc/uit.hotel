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
import { Vue, Component } from 'nuxt-property-decorator';
import mutable from '~/components/mixins/mutable';
import { ButtonProps } from '../mixins/button';

@Component({
    mixins: [mutable, ButtonProps],
})
export default class extends Vue {}
</script>
