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
    </b-dropdown-item>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import {
    LinkProps,
    IconProps,
    TextProps,
    ImageProps,
} from '~/components/mixins/props';

@Component({
    name: 'b-dropdown-item-icon-',
    mixins: [LinkProps, IconProps, TextProps, ImageProps],
})
export default class extends Vue {}
</script>
