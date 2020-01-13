<template>
    <b-table-lite
        class="table-style bg-lighten rounded"
        small
        :items="calculatedData"
        :fields="[
            {
                key: 'key',
                class: 'font-weight-medium',
                ...keyField,
            },
            {
                key: 'value',
                ...valueField,
            },
        ]"
    />
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';

@Component({
    name: 'key-value-',
})
export default class extends Vue {
    @Prop({ type: Object })
    data!: object;

    @Prop({ type: Object, default: () => ({}) })
    valueField!: object;

    @Prop({ type: Object, default: () => ({}) })
    keyField!: object;

    get calculatedData() {
        return Object.entries(this.data).map(([key, value]) => ({
            key,
            value,
        }));
    }
}
</script>
