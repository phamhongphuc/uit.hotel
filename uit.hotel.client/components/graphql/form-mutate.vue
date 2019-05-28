<template>
    <b-form @submit.prevent="mutate"><slot :mutate="mutate" /></b-form>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { MutableMixin } from '~/components/mixins';

@Component({
    name: 'form-mutate-',
})
export default class extends mixins<MutableMixin>(MutableMixin) {}
</script>
