<template>
    <b-table-lite
        small
        :thead-class="theadClass"
        :borderless="borderless"
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

    @Prop({ default: false })
    borderless!: boolean;

    @Prop({ default: undefined })
    theadClass!: string | string[] | object;

    get calculatedData() {
        return Object.entries(this.data).map(([key, value]) => ({
            key,
            value,
        }));
    }
}
</script>
<style lang="scss">
.table-key-value {
    tr > td {
        padding-top: 0;
        padding-bottom: 0;
        &:nth-child(1) {
            padding-left: 0;
            font-weight: 600;
        }
        &:nth-child(2) {
            padding-right: 0;
        }
    }
}
</style>
