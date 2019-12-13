<template>
    <b-button
        v-on-clickaway="clickaway"
        :block="block"
        :disabled="disabled"
        :size="size"
        :variant="isClicked && clickedVariant !== '' ? clickedVariant : variant"
        :type="type"
        :pressed="pressed"
        :class="{ [clickedClass]: isClicked }"
        @click="onClick"
    >
        <span v-if="isClicked">{{ textConfirm }}</span>
        <slot v-else />
    </b-button>
</template>
<script lang="ts">
import { Component, mixins, Prop } from 'nuxt-property-decorator';
import { directive as onClickaway } from 'vue-clickaway';
import { MutableMixin, ButtonProps } from '~/components/mixins';

@Component({
    name: 'b-button-mutate-',
    directives: { onClickaway },
})
export default class extends mixins<MutableMixin, ButtonProps>(
    MutableMixin,
    ButtonProps,
) {
    isClicked = false;

    @Prop({ required: false, type: String, default: 'text-red' })
    clickedClass!: string;

    @Prop({ required: false, type: String, default: '' })
    clickedVariant!: string;

    clickaway() {
        if (this.confirm) this.isClicked = false;
    }

    @Prop({ default: 'Ấn lần nữa để xác nhận' })
    textConfirm!: string;

    @Prop({ default: false, type: Boolean })
    confirm!: boolean;

    async onClick() {
        if (!this.confirm || this.isClicked) {
            try {
                await this.mutate();
                this.$emit('click');
                this.isClicked = false;
            } catch (e) {
                this.isClicked = false;
            }
        } else {
            this.isClicked = true;
        }
    }
}
</script>
