<template>
    <b-form @submit.prevent="mutate"><slot :mutate="mutate" /></b-form>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import mutable from '~/components/mixins/mutable';

@Component({
    mixins: [mutable],
    name: 'form-mutate-',
})
export default class extends Vue {}
</script>
