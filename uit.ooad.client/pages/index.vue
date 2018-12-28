<template>
    <div>dashboard</div>
</template>
<script lang="ts">
import { Vue, Component, namespace } from 'nuxt-property-decorator';

@Component({
    name: 'index-',
})
export default class extends Vue {
    @namespace('style').State
    breakpoint;
}
</script>
