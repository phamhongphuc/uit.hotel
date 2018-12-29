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
import { ButtonIconProps, ButtonImageProps } from '~/components/mixins/button';

@Component({
    name: 'b-nav-item-icon-mutate-',
    mixins: [mutable, ButtonIconProps, ButtonImageProps],
})
export default class extends Vue {}
</script>
