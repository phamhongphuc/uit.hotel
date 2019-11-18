<template>
    <b-nav-item
        v-if="isShow"
        :href="href"
        :rel="rel"
        :target="target"
        :active="active"
        :active-class="activeClass"
        :append="append"
        :disabled="disabled"
        :event="event"
        :exact="exact"
        :exact-active-class="exactActiveClass"
        :replace="replace"
        :router-tag="routerTag"
        :to="to"
        class="nav-item-icon"
        @click="$emit('click')"
    >
        <icon- v-if="icon" :i="icon" />
        <div v-else-if="image !== ''" class="icon">
            <image-
                :class="[{ 'rounded-circle': circle }, imageClass]"
                :source="image"
                class="m-2"
                height="24"
                width="24"
            />
        </div>
        <slot />
        <div v-if="text !== ''" :class="[textClass, 'mr-auto']">{{ text }}</div>
        <slot name="suffix" />
    </b-nav-item>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import {
    IconProps,
    ImageProps,
    LinkProps,
    TextProps,
    PermissionMixin,
} from '~/components/mixins';

@Component({
    name: 'b-nav-item-icon-',
})
export default class extends mixins<
    LinkProps,
    IconProps,
    TextProps,
    ImageProps,
    PermissionMixin
>(LinkProps, IconProps, TextProps, ImageProps, PermissionMixin) {}
</script>
<style lang="scss">
.nav-item-icon {
    .badge {
        align-self: center;
        height: 1.5rem;
        padding: 0 0.5rem;
        line-height: 1.5rem;
    }
}
</style>
