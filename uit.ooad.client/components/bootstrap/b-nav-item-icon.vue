<template>
    <b-nav-item :to="to" class="nav-item-icon">
        <div v-if="icon !== ''" class="icon">{{ icon }}</div>
        <div v-else-if="image !== ''" class="icon">
            <image-
                class="m-2"
                :class="[{ 'rounded-circle': circle }, imageClass]"
                :source="image"
                height="24"
                width="24"
            />
        </div>
        <div v-if="text !== ''" :class="textClass">{{ text }}</div>
    </b-nav-item>
</template>
<script lang="ts">
import { Vue, Prop, Component } from 'nuxt-property-decorator';

@Component
export default class extends Vue {
    @Prop({ default: '' })
    to: string;

    @Prop({ default: '' })
    image: string;

    @Prop({ default: 0 })
    imageWidth: number;

    @Prop({ default: 0 })
    imageHeight: number;

    @Prop({ default: '' })
    imageClass: string;

    @Prop({ default: false })
    circle: boolean;

    @Prop({ default: '' })
    textClass: string;

    @Prop({ default: '' })
    icon: string;

    @Prop({ default: '' })
    text: string;
}
</script>
