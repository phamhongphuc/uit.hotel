<template>
    <apollo-query
        :query="query"
        :variables="variables"
        :poll-interval="500"
        class="gql-query"
    >
        <template slot-scope="{ result: { loading, error, data } }">
            <div v-if="loading" class="loading">Đang tải...</div>
            <div v-else-if="error" class="error">Đã có lỗi xảy ra!</div>
            <div v-else-if="data"><slot :data="data" /></div>
            <div v-else class="no-result">
                <span class="icon"></span>
                Đang tải dữ liệu...
            </div>
        </template>
    </apollo-query>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';
@Component
export default class extends Vue {
    @Prop({ required: true })
    query: string;

    @Prop({ default: () => ({}) })
    variables: object;
}
</script>
<style lang="scss">
.gql-query {
    min-height: 100%;
    // justify-content: center;
    // align-items: center;
}
</style>
