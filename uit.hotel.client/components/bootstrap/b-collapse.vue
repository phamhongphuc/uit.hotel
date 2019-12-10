<template>
    <b-collapse
        v-if="isShow"
        :id="id"
        :visible="visible"
        @input="$emit('input', $event)"
    >
        <slot />
    </b-collapse>
</template>
<script lang="ts">
import { Component, Prop, mixins, Vue } from 'nuxt-property-decorator';
import { PermissionMixin, PermissionUnion } from '~/components/mixins';

function isPermissionMixin(instance: Vue): instance is PermissionMixin {
    return 'permission' in instance;
}

@Component({
    name: 'b-collapse-',
    model: {
        prop: 'visible',
        event: 'input',
    },
})
export default class extends mixins<PermissionMixin>(PermissionMixin) {
    @Prop({ default: false, type: Boolean })
    visible!: boolean;

    @Prop({ required: true, type: String, default: '' })
    id!: string;

    @Prop({ default: false, type: Boolean })
    autoPermission!: boolean;

    mounted() {
        if (this.autoPermission === false) return;

        const defaultSlot = this.$slots.default;

        if (defaultSlot === undefined) return;

        this.autoPermissionValue = defaultSlot.reduce<PermissionUnion[]>(
            (output, current) => {
                (() => {
                    const child = current.componentInstance;

                    if (child === undefined) return;

                    if (!isPermissionMixin(child)) return;

                    const { permission } = child;

                    if (typeof permission === 'boolean') return;

                    output = output.concat(permission);
                })();

                return output;
            },
            [],
        );
    }
}
</script>
