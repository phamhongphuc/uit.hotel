<template>
    <div>{{ breakpoint }}</div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { namespace } from 'vuex-class';

@Component({
    components: {},
})
export default class extends Vue {
    @namespace('style').State breakpoint;
}
</script>
