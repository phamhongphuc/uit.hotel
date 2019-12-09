<template>
    <b-button
        :block="block"
        :disabled="disabled"
        :size="size"
        :variant="variant"
        :type="type"
        :pressed="pressed"
        :class="isClicked ? 'text-red' : ''"
        @click="onClick"
    >
        <span v-if="isClicked">{{ textConfirm }}</span>
        <slot v-else />
    </b-button>
</template>
<script lang="ts">
import { Component, mixins, Prop } from 'nuxt-property-decorator';
import { MutableMixin, ButtonProps } from '~/components/mixins';

@Component({
    name: 'b-button-mutate-',
})
export default class extends mixins<MutableMixin, ButtonProps>(
    MutableMixin,
    ButtonProps,
) {
    isClicked = false;

    @Prop({ default: 'Ấn lần nữa để xác nhận' })
    textConfirm!: string;

    @Prop({ default: false, type: Boolean })
    confirm!: boolean;

    async onClick() {
        if (!this.confirm || this.isClicked) {
            try {
                await this.mutate();
                this.$emit('click');
            } catch (e) {
                this.isClicked = false;
            }
        } else {
            this.isClicked = true;
        }
    }
}
</script>
