<template>
    <b-nav-item-icon-
        :image="image"
        :image-width="imageWidth"
        :image-height="imageHeight"
        :image-class="imageClass"
        :circle="circle"
        :text-class="textClass"
        :icon="icon"
        :text="isClicked ? textConfirm : text"
        :class="isClicked ? 'text-red' : ''"
        @click="onClick"
    />
</template>
<script lang="ts">
import { Component, mixins, Prop } from 'nuxt-property-decorator';
import {
    MutableMixin,
    IconProps,
    TextProps,
    ImageProps,
} from '~/components/mixins';

@Component({
    name: 'b-nav-item-icon-mutate-',
})
export default class extends mixins<
    MutableMixin,
    IconProps,
    TextProps,
    ImageProps
>(MutableMixin, IconProps, TextProps, ImageProps) {
    isClicked = false;

    @Prop({ default: 'Ấn lần nữa để xác nhận' })
    textConfirm!: string;

    @Prop({ default: false, type: Boolean })
    confirm!: boolean;

    onClick(event: MouseEvent) {
        if (!this.confirm || this.isClicked) this.mutate();
        else {
            event.stopPropagation();
            this.isClicked = true;
        }
    }
}
</script>
