<template>
    <div>
        <b-checkbox
            v-model="allSelected"
            :indeterminate="indeterminate"
            class="inline-checkbox text-bold"
            @input="toggleAll($event)"
        >
            {{ title }}
        </b-checkbox>
        <b-checkbox-group
            v-model="selected"
            :options="options"
            class="h-auto m-4"
            stacked
        />
    </div>
</template>
<script lang="ts">
import { Component, Prop, Watch, mixins } from 'nuxt-property-decorator';
import { CheckboxProps } from '~/components/mixins';

function isEquals(a: string[], b: string[]): boolean {
    if (a.length !== b.length) return false;
    const filter = a.filter(e => b.indexOf(e) === -1);
    return filter.length === 0;
}

@Component({
    name: 'b-checkbox-group-',
})
export default class extends mixins<CheckboxProps>(CheckboxProps) {
    @Prop({ required: true })
    title!: string;

    selected: string[] = [];
    allSelected: boolean = false;
    indeterminate: boolean = false;

    @Watch('selected')
    onSelectedChange(array: string[]) {
        if (array.length === 0) {
            this.indeterminate = false;
            this.allSelected = false;
        } else if (array.length === this.optionsList.length) {
            this.indeterminate = false;
            this.allSelected = true;
        } else {
            this.indeterminate = true;
            this.allSelected = false;
        }
        const arrayFiltered = this.value.filter(
            e => this.optionsList.indexOf(e) === -1,
        );
        const newValue = arrayFiltered.concat(array);

        if (!isEquals(this.value, newValue)) this.$emit('input', newValue);
    }

    @Watch('value')
    onValueChange() {
        this.updateSelectedFromValue();
    }

    mounted() {
        this.updateSelectedFromValue();
    }

    get optionsList(): string[] {
        return this.options.map(o => o.value);
    }

    updateSelectedFromValue() {
        const arr = this.value.filter(e => this.optionsList.indexOf(e) !== -1);
        if (!isEquals(this.selected, arr)) this.selected = arr;
    }

    toggleAll(checked: boolean) {
        if (this.indeterminate && !checked) return;
        this.selected = checked ? this.optionsList : [];
    }
}
</script>
