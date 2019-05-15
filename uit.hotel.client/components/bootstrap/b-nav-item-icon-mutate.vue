<template>
    <b-nav-item-icon-
        :image="image"
        :image-width="imageWidth"
        :image-height="imageHeight"
        :image-class="imageClass"
        :circle="circle"
        :text-class="textClass"
        :icon="icon"
        :text="text"
        @click="mutate"
    />
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
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
>(MutableMixin, IconProps, TextProps, ImageProps) {}
</script>
