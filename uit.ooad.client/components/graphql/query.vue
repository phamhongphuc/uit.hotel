<template>
    <apollo-query
        :query="query"
        :variables="variables"
        :poll-interval="500"
        class="query"
    >
        <template slot-scope="{ result: { loading, error, data } }">
            <div v-if="loading" class="query-text loading">
                <span class="icon"></span>
                Đang tải dữ liệu...
            </div>
            <div v-else-if="error" class="query-text text-red">
                <span class="icon"></span>
                Đã có lỗi xảy ra!
            </div>
            <div v-else-if="data"><slot :data="data" /></div>
            <div v-else class="query-text no-result">
                <span class="icon"></span>
                Đang yêu cầu dữ liệu...
            </div>
        </template>
    </apollo-query>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';
@Component({
    name: 'query-',
})
export default class extends Vue {
    @Prop({ required: true })
    query: string;

    @Prop({ default: () => ({}) })
    variables: object;
}
</script>
<style lang="scss">
.query {
    min-height: 100%;
    > .query-text {
        width: 100%;
        text-align: center;
        align-self: center;
    }
}
</style>
