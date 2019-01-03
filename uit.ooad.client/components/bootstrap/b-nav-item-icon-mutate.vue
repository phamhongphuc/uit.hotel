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
import { Vue, Component } from 'nuxt-property-decorator';
import mutable from '~/components/mixins/mutable';
import { IconProps, TextProps, ImageProps } from '~/components/mixins/props';

@Component({
    name: 'b-nav-item-icon-mutate-',
    mixins: [mutable, IconProps, TextProps, ImageProps],
})
export default class extends Vue {}
</script>
