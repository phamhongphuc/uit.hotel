<template>
    <span class="icon">{{ icon }}</span>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import selection from './selection.json';

@Component
export default class extends Vue {
    icon: string = '123';

    mounted() {
        const a = selection.icons.reduce((obj, current) => {
            obj[current.properties.name] = String.fromCharCode(
                current.properties.code,
            );
            return obj;
        }, {});
        // eslint-disable-next-line no-console
        console.log(a);
    }
}
</script>
