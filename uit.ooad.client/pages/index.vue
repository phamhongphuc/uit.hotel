<template>
    <div>dashboard</div>
</template>
<script lang="ts">
import { Vue, Component, namespace } from 'nuxt-property-decorator';

@Component
export default class extends Vue {
    @namespace('style').State
    breakpoint;

    @namespace('user').Action
    checkLogin;

    async mounted() {
        if (!(await this.checkLogin())) {
            this.$router.push('/login');
        }
    }
}
</script>
