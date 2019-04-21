<template>
    <b-nav
        v-show="show"
        v-on-clickaway="close"
        :style="style"
        class="context-menu"
        tabindex="-1"
        @click="onClick"
        @contextmenu.capture.prevent
    >
        <slot v-if="data" :data="data" :refs="refs" />
    </b-nav>
</template>

<script lang="ts">
import { Vue, Component, Prop, Watch } from 'nuxt-property-decorator';
import { mixin as clickaway } from 'vue-clickaway';

@Component({
    mixins: [clickaway],
    name: 'context-',
})
export default class extends Vue {
    @Prop({ default: true, type: Boolean })
    closeOnClick!: boolean;

    @Prop({ default: true, type: Boolean })
    closeOnScroll!: boolean;

    @Prop({ default: undefined })
    refs: any;

    top: number = 0;
    left: number = 0;
    show: boolean = false;
    data: any = null;

    get style() {
        return this.show
            ? { top: `${this.top}px`, left: `${this.left}px` }
            : null;
    }

    @Watch('closeOnScroll')
    closeOnScrollChanged(value, oldValue) {
        if (value === oldValue) {
            return;
        }
        if (value) {
            this.addScrollEventListener();
        } else {
            this.removeScrollEventListener();
        }
    }

    close(emit: boolean | Event = true) {
        if (!this.show) {
            return;
        }
        this.top = 0;
        this.left = 0;
        this.data = null;
        this.show = false;
        if (emit) {
            this.$emit('close');
        }
    }

    addScrollEventListener() {
        window.addEventListener('scroll', this.close);
    }

    removeScrollEventListener() {
        window.removeEventListener('scroll', this.close);
    }

    mounted() {
        if (this.closeOnScroll) {
            this.addScrollEventListener();
        }
    }

    beforeDestroy() {
        if (this.closeOnScroll) {
            this.removeScrollEventListener();
        }
    }

    onClick() {
        if (this.closeOnClick) {
            this.close(false);
        }
    }

    positionMenu(top, left) {
        const largestHeight =
            window.innerHeight - (this.$el as HTMLElement).offsetHeight - 25;
        const largestWidth =
            window.innerWidth - (this.$el as HTMLElement).offsetWidth - 25;
        if (top > largestHeight) {
            top = largestHeight;
        }
        if (left > largestWidth) {
            left = largestWidth;
        }
        this.top = top;
        this.left = left;
    }

    open(event: MouseEvent, data: any) {
        this.data = data;
        this.show = true;
        this.$nextTick(() => {
            this.positionMenu(event.clientY, event.clientX);
            this.$emit('open', event, this.data, this.top, this.left);
        });
    }
}
</script>
<style lang="scss">
.context-menu {
    background: $white;
    box-shadow: $box-shadow-context;
    border-radius: $border-radius;
    display: block;
    position: fixed;
    padding: #{0.25 * $context-size} 0;
    z-index: 1;
    .nav-item-icon {
        &:hover {
            background: rgba($black, 0.05);
        }
        > .nav-link {
            display: flex;
            line-height: $context-size;
            padding: 0.25rem 1rem 0.25rem 0.5rem;
            > .icon {
                display: block;
                text-align: center;
                font-size: 0.5 * $context-size;
                margin-right: 0.125 * $context-size;
                padding: 0;
                width: $context-size;
                min-width: $context-size;
                min-height: $context-size;
                line-height: $context-size;
            }
        }
    }
    .context-hr {
        width: calc(100% - 2rem);
        margin: auto;
        height: 1.5px;
        background: $border-color;
    }
}
</style>
