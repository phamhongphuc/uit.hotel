<template>
    <b-navbar
        id="navbar"
        toggleable="md"
        type="light"
        class="pb-0 py-md-0 px-md-2 shadow-sm"
        sticky
    >
        <b-navbar-nav class="flex-row flex-grow-1 flex-md-grow-0 mb-2 mb-md-0">
            <b-navbar-toggle target="navbar-collapse" class="mx-1">
                <icon- i="menu" />
            </b-navbar-toggle>
            <b-nav-item
                class="font-pacifico font-size-5 ml-md-2 mx-auto"
                to="/"
            >
                Quản lý khách sạn
            </b-nav-item>
            <b-nav-item-icon- class="d-md-none mx-1" image="/favicon.png" />
        </b-navbar-nav>

        <b-collapse
            id="navbar-collapse"
            :class="{ 'navbar-input-focused': isInputFocus }"
            class="justify-content-end mx-n2 mx-md-0 px-2 px-md-0"
            is-nav
        >
            <b-navbar-hr- class="d-md-none" />
            <b-navbar-nav class="py-2 flex-fill justify-content-end">
                <b-dropdown
                    class="d-none d-md-block"
                    variant="link"
                    size="md"
                    no-caret
                    right
                    toggle-class="p-0 border-0 nav-item-icon d-flex"
                    menu-class="border-0 shadow rounded mt-3"
                >
                    <template slot="button-content">
                        <div class="d-flex navbar-profile-button">
                            <div class="navbar-profile-button-text">
                                <div class="navbar-profile-button-text-name">
                                    {{ employee.name }}
                                </div>
                                <div
                                    class="navbar-profile-button-text-position"
                                >
                                    {{ employee.position.name }}
                                </div>
                            </div>
                            <div class="icon ml-2">
                                <image-
                                    class="m-1 rounded-circle"
                                    source="/black.png"
                                    height="32"
                                    width="32"
                                />
                            </div>
                        </div>
                    </template>
                    <b-dropdown-item-icon-
                        to="/profile"
                        text="Tài khoản"
                        icon="user"
                        @click="logout"
                    />
                    <b-dropdown-item-icon-
                        to="/settings"
                        text="Cài đặt"
                        icon="settings"
                        @click="logout"
                    />
                    <div class="hr line my-2" />
                    <b-dropdown-item-icon-
                        text="Đăng xuất"
                        icon="power"
                        @click="logout"
                    />
                </b-dropdown>
            </b-navbar-nav>
        </b-collapse>
    </b-navbar>
</template>
<script lang="ts">
import { Vue, namespace, Component } from 'nuxt-property-decorator';
import { UserState } from '~/store/user';
import { UserLogin } from '~/graphql/types';

@Component({
    name: 'navbar-',
})
export default class extends Vue {
    isInputFocus = false;

    @(namespace('style').State)
    breakpoint;

    @(namespace('user').Action)
    logout;

    @(namespace('user').State(
        (state: UserState) => state.employee || { position: {} },
    ))
    employee!: UserLogin.Employee;
}
</script>
<style lang="scss">
.navbar-toggler-sidebar {
    > .icon {
        transition: transform 0.2s;
    }
    &[aria-expanded='false'] {
        > .icon {
            transform: rotate(180deg);
        }
    }
}

.navbar-profile-button {
    > .navbar-profile-button-text {
        padding: 0.375rem 0 0.125rem;
        text-align: right;
        > .navbar-profile-button-text-name {
            font-weight: bold;
            font-size: 1rem;
            line-height: 1rem;
        }
        > .navbar-profile-button-text-position {
            font-size: 0.75rem;
            line-height: 0.75rem;
        }
    }
}
</style>
