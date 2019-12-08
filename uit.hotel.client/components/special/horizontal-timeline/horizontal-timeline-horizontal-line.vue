<template>
    <div class="horizontal-timeline-horizontal-line" :style="style" />
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';

@Component({
    name: 'horizontal-timeline-horizontal-line-',
})
export default class extends Vue {
    @Prop({ required: true, type: Number })
    line!: number;

    get style() {
        return {
            top: `calc(var(--day-title-height) + (var(--line-size) + var(--main-height)) * ${this.line})`,
        };
    }
}
</script>
<style lang="scss">
$line-color: lighten($light, 30%);
$line-size: 0.125rem;

.horizontal-timeline-horizontal-line {
    position: absolute;
    bottom: 0;
    z-index: 2;
    width: 100%;
    height: $line-size;
    background-color: $line-color;
}
</style>
