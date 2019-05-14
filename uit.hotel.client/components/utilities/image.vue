<script lang="ts">
import { Vue, Prop, Component } from 'nuxt-property-decorator';
import { VNode, CreateElement } from 'vue';

@Component({
    name: 'image-',
})
export default class extends Vue {
    isError = false;
    isLoad = false;

    @Prop()
    source!: string;

    @Prop({ default: '/img/circle.svg' })
    default!: string;

    onError() {
        this.isError = true;
    }

    render(createElement: CreateElement): VNode {
        return createElement('img', {
            attrs: {
                src: this.isError ? this.default : this.source,
            },
            class: {
                image: true,
                'd-none': !this.isLoad,
                'd-block': this.isLoad,
            },
            on: {
                error: this.onError,
                load: () => {
                    this.isLoad = true;
                },
            },
        });
    }
}
</script>
