<template>
    <div>{{ breakpoint }}</div>
</template>
<script lang="ts">
import { Vue, Component, namespace } from 'nuxt-property-decorator';

@Component
export default class extends Vue {
    @namespace('style').State breakpoint;
}
</script>
