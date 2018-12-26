<template>
    <div id="login" class="bg-white shadow-lg p-5 d-flex flex-column">
        <img
            src="/favicon.png"
            class="d-block img-fluid mb-2 mt-5 mx-auto"
            :style="{ width: '120px' }"
        />
        <h4 class="font-pacifico text-center mb-5">Quản lý khách sạn</h4>
        <div class="flex-fill d-flex flex-column my-5">
            <b-input- type="text" placeholder="Tên đăng nhập" icon="" />
            <b-input-
                type="password"
                placeholder="Mật khẩu"
                icon=""
                class="my-2"
            />
            <b-button variant="main" class="border-circle d-block w-100">
                Đăng nhập
            </b-button>
        </div>
        <div class="text-center">
            <nuxt-link to="/help">Chưa có tài khoản</nuxt-link>
            <br />
            hoặc
            <br />
            <nuxt-link to="/help">Quên mật khẩu?</nuxt-link>
        </div>
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
@Component
export default class extends Vue {
    layout() {
        return 'side';
    }
}
</script>
