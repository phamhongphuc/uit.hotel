<template>
    <div>
        <div class="row-like flex-fill d-flex">
            <div class="bg-white m-2 flex-fill rounded main-app">
                Vui lòng sử dụng menu bên trái để chọn chức năng tương ứng!
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin, Page } from '~/components/mixins';

@Component({
    name: 'index-',
})
export default class extends mixins<Page, {}>(Page, DataMixin({})) {
    head() {
        return {
            title: 'Trang chủ',
        };
    }
}
</script>
<style lang="scss">
.main-app {
    display: flex;
    align-items: center;
    justify-content: center;
    overflow: auto;
    box-shadow: $box-shadow-sm;
}
</style>
