<template>
    <div
        id="login"
        class="bg-white shadow-lg p-5 d-flex flex-column overflow-auto"
    >
        <img
            src="/favicon.png"
            class="d-block img-fluid mb-2 mt-5 mx-auto"
            :style="{ width: '120px' }"
        />
        <h4 class="font-pacifico text-center mb-5">Quản lý khách sạn</h4>
        <b-form
            class="flex-fill d-flex flex-column my-5"
            @submit.prevent="login({ id, password })"
        >
            <b-input-
                v-model="id"
                name="username"
                type="text"
                placeholder="Tên đăng nhập"
                icon="user"
                class="circle"
            />
            <b-input-
                v-model="password"
                name="password"
                type="password"
                placeholder="Mật khẩu"
                icon="lock"
                class="my-2 circle"
            />
            <b-button variant="main" type="submit" class="border-circle w-100">
                Đăng nhập
            </b-button>
        </b-form>
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
import { Vue, Component, namespace } from 'nuxt-property-decorator';

@Component({
    name: 'login-',
})
export default class extends Vue {
    id = '';
    password = '';

    layout() {
        return 'side';
    }

    head() {
        return {
            title: 'Đăng nhập',
        };
    }

    @(namespace('user').Action)
    login;
}
</script>
