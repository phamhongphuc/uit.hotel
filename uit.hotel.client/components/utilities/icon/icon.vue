<template>
    <span class="icon">{{ icon }}</span>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';
import selection from './selection.json';

const map = selection.icons.reduce((obj, current) => {
    obj[current.properties.name] = String.fromCharCode(current.properties.code);
    return obj;
}, {});

@Component({
    name: 'icon-',
})
export default class extends Vue {
    @Prop({ required: true, type: String })
    i?: string;

    get icon(): string {
        if (!this.i) return '';
        if (this.i.length === 1 && this.i.charCodeAt(0) > 50000) {
            // eslint-disable-next-line no-console
            console.log(`%c [${this.i}]`, `color: #`);
            return this.i;
        }
        const character = map[this.i];
        if (character === undefined) {
            // eslint-disable-next-line no-console
            console.error(`Không tìm thấy icon name [${this.i}] trong map`);
            return '';
        }
        return character;
    }
}
</script>
