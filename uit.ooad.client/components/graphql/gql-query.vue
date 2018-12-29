<template>
    <apollo-query :query="query" :variables="variables" :poll-interval="500">
        <template slot-scope="{ result: { loading, error, data } }">
            <div v-if="loading" class="loading">Đang tải...</div>
            <div v-else-if="error" class="error">Đã có lỗi xảy ra!</div>
            <div v-else-if="data"><slot :data="data" /></div>
            <div v-else class="no-result">Không có kết quả trả về :(</div>
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
