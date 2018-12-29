<template>
    <b-button @click="mutate"><slot /></b-button>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import mutable from '~/components/mixins/mutable';

@Component({
    mixins: [mutable],
})
export default class extends Vue {}
</script>
