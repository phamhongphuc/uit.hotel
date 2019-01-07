<template>
    <div v-show="show" class="popup" @click="close">
        <div ref="popup" class="popup-modal" @click.stop>
            <div class="popup-modal-title">
                <div class="text">{{ title }}</div>
                <b-button variant="white" class="icon close" @click="close">
                    
                </b-button>
            </div>
            <no-ssr>
                <div class="popup-modal-content">
                    <slot v-if="noData || data" :data="data" :close="close" />
                </div>
            </no-ssr>
        </div>
    </div>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';
import { mixin as clickaway } from 'vue-clickaway';

@Component({
    mixins: [clickaway],
    name: 'popup-',
})
export default class extends Vue {
    show: boolean = false;
    data: any = null;

    @Prop({ required: true, type: String })
    title: string;

    @Prop({ default: false, type: Boolean })
    noData: boolean;

    close() {
        this.data = null;
        this.show = false;
    }

    open(data: any) {
        this.data = data;
        this.show = true;
    }
}
</script>

<style lang="scss">
$popup-modal-title-size: $input-height;

.popup {
    position: absolute;
    background: rgba($black, 0.2);
    display: flex;
    justify-content: center;
    align-items: center;
    z-index: 5;
    width: 100%;
    height: 100%;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;

    > .popup-modal {
        min-width: 300px;
        background: $white;
        box-shadow: $box-shadow-context;
        border-radius: $border-radius;

        > .popup-modal-title {
            display: flex;
            border-bottom: 1.5px solid $border-color;
            opacity: 0.8;
            line-height: $input-height;
            > .text {
                flex: 1;
                padding: 0 0.75rem;
                font-weight: 500;
                font-size: calc(0.4 * #{$input-height});
            }
            > .icon {
                display: block;
                text-align: center;
                font-size: calc(0.5 * #{$input-height});
                padding: 0;
                width: $input-height;
                min-width: $input-height;
                min-height: $input-height;
            }
        }
    }
}
</style>
