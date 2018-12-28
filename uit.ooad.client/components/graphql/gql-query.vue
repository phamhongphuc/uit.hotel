<template>
    <apollo-query :query="query" :variables="variables" :poll-interval="500">
        <template slot-scope="{ result: { loading, error, data } }">
            <div v-if="loading" class="loading apollo">Đang tải...</div>
            <div v-else-if="error" class="error apollo">Đã có lỗi xảy ra!</div>
            <div v-else-if="data" class="result apollo">
                <slot :data="data" />
            </div>
            <div v-else class="no-result apollo">
                Không có kết quả trả về :(
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
