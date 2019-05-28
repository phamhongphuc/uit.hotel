<template>
    <b-dropdown-item
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
        class="dropdown-item-icon"
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
        <div v-if="text !== ''" :class="textClass">{{ text }}</div>
    </b-dropdown-item>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import {
    LinkProps,
    IconProps,
    TextProps,
    ImageProps,
} from '~/components/mixins';

@Component({
    name: 'b-dropdown-item-icon-',
})
export default class extends mixins<
    LinkProps,
    IconProps,
    TextProps,
    ImageProps
>(LinkProps, IconProps, TextProps, ImageProps) {}
</script>
