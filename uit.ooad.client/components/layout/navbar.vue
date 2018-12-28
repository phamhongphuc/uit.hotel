<template>
    <b-navbar
        id="navbar"
        toggleable="md"
        type="light"
        class="pb-0 py-md-0 px-md-2 shadow-sm"
        sticky
    >
        <b-navbar-nav class="flex-row flex-grow-1 flex-md-grow-0 mb-2 mb-md-0">
            <b-navbar-toggle target="navbar-collapse" class="mx-1" />
            <b-nav-item
                class="font-pacifico font-size-bigger ml-md-2 mx-auto"
                to="/"
            >
                Quản lý khách sạn
            </b-nav-item>
            <b-nav-item-icon-
                class="d-md-none mx-1"
                image="/favicon.png"
                @click.native="toggle"
            />
        </b-navbar-nav>

        <b-collapse
            id="navbar-collapse"
            :class="{ 'navbar-input-focused': isInputFocus }"
            class="justify-content-end nmx-2 nmx-md-0 px-2 px-md-0"
            is-nav
        >
            <b-navbar-hr- class="d-md-none" />

            <b-navbar-nav class="py-2 flex-fill justify-content-end">
                <b-nav-item-input-
                    class="flex-fill"
                    reverse-when="md"
                    placeholder="Tìm kiếm..."
                    icon=""
                    :focus.sync="isInputFocus"
                />
                <b-nav-item-icon-
                    image="/favicon.png"
                    text="Tên người dùng"
                    text-class="d-md-none"
                    class="d-none d-md-block"
                    :class="isInputFocus ? 'w-0 h-0' : ''"
                />
                <b-dropdown
                    class="navar-dropdown"
                    variant="link"
                    size="md"
                    no-caret
                    right
                    toggle-class="p-0 border-0 nav-item-icon d-flex"
                    menu-class="border-0 shadow rounded mt-3 p-0"
                >
                    <template slot="button-content">
                        <div class="icon">
                            <image-
                                class="m-2 rounded-circle"
                                source="https://api.adorable.io/avatars/40/admin"
                                height="24"
                                width="24"
                            />
                        </div>
                    </template>
                    <b-dropdown-item href="#">Action</b-dropdown-item>
                    <b-dropdown-item @click="logout">Đăng xuất</b-dropdown-item>
                </b-dropdown>
            </b-navbar-nav>
        </b-collapse>
    </b-navbar>
</template>
<script lang="ts">
import { Vue, namespace, Component } from 'nuxt-property-decorator';

@Component({
    name: 'navbar-',
})
export default class extends Vue {
    isInputFocus = false;

    @namespace('style').State
    breakpoint;

    @namespace('user').Action
    logout;
}
</script>
<style lang="scss">
.navar-dropdown {
    .dropdown-item {
        display: flex;
    }
}
</style>
