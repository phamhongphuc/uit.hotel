<template>
    <div
        id="initialize"
        class="bg-white shadow-lg p-5 d-flex flex-column overflow-auto"
    >
        <img
            :style="{ width: '120px' }"
            src="/favicon.png"
            class="d-block img-fluid mb-2 mt-5 mx-auto"
        />
        <h4 class="font-pacifico text-center mb-5">Quản lý khách sạn</h4>
        <form-mutate-
            class="flex-fill d-flex flex-column my-5"
            :mutation="initializeAdminAccount"
            :variables="{ email, password }"
            success="Khởi tạo tài khoản quản trị thành công"
        >
            <b-input-
                v-model="email"
                name="email"
                type="text"
                placeholder="Địa chỉ thư điện tử"
                icon="mail"
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
                Khởi tạo tài khoản quản trị
            </b-button>
        </form-mutate->
    </div>
</template>
<script lang="ts">
import { Component, namespace, mixins } from 'nuxt-property-decorator';
import { DataMixin } from '~/components/mixins';
import { initializeAdminAccount } from '~/graphql/documents';

@Component({
    name: 'initialize-',
    validations: {
        input: {},
    },
})
export default class extends mixins(DataMixin({ initializeAdminAccount })) {
    email = '';
    password = '';

    layout() {
        return 'side';
    }

    head() {
        return {
            title: 'Khởi tạo tài khoản quản trị',
        };
    }

    @(namespace('user').Action)
    checkIsInitializedDatabase;

    async beforeRouteEnter(to, from, next) {
        next(vm => vm.checkIsInitializedDatabase());
    }
}
</script>
