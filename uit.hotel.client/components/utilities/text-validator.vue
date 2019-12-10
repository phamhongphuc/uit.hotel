<template>
    <div class="text-validator" :class="stateClass">
        <slot v-if="state" name="valid" />
        <slot v-else name="invalid" />
        <slot />
    </div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';

@Component({
    name: 'table-validation-',
})
export default class extends Vue {
    @Prop({ type: [Boolean] })
    state!: boolean;

    get stateClass() {
        if (this.state === null) return null;

        return this.state ? 'is-valid' : 'is-invalid';
    }
}
</script>
<style lang="scss">
@if $enable-validation-icons {
    @each $state, $data in $form-validation-states {
        $color: map-get($data, color);
        $icon: map-get($data, icon);

        .text-validator {
            .was-validated &:#{$state},
            &.is-#{$state} {
                padding-right: $input-height-inner !important;
                background-image: $icon;
                background-repeat: no-repeat;
                background-position: center right $input-height-inner-quarter;
                background-size: $input-height-inner-half
                    $input-height-inner-half;
            }
        }
    }
}
</style>
