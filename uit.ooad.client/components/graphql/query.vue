<template>
    <no-ssr>
        <apollo-query
            :query="query"
            :variables="variables"
            :poll-interval="500"
            fetch-policy="no-cache"
            class="query"
        >
            <template slot-scope="{ result: { loading, error, data } }">
                <div :class="childClass">
                    <slot v-if="data" :data="data" />
                    <div v-else class="query-text">
                        <span v-if="loading">
                            <span class="icon mr-1"></span>
                            Đang tải dữ liệu...
                        </span>
                        <span v-else-if="error" class="text-red">
                            <span class="icon mr-1"></span>
                            Đã có lỗi xảy ra!
                        </span>
                        <span v-else>
                            <span class="icon mr-1"></span>
                            Đang yêu cầu dữ liệu...
                        </span>
                    </div>
                </div>
            </template>
        </apollo-query>
    </no-ssr>
</template>
<script lang="ts">
import { Vue, Component, Prop } from 'nuxt-property-decorator';
@Component({
    name: 'query-',
})
export default class extends Vue {
    @Prop({ required: true })
    query!: string;

    @Prop({ default: '' })
    childClass!: string;

    @Prop({ default: () => ({}) })
    variables!: object;
}
</script>
<style lang="scss">
.query {
    > div > .query-text {
        display: flex;
        height: 100%;
        padding: 2rem;
        justify-content: center;
        align-items: center;
    }
}
</style>
