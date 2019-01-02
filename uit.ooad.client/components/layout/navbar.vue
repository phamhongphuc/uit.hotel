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
            <b-nav-item-icon- class="d-md-none mx-1" image="/favicon.png" />
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
                <b-dropdown
                    class="navar-dropdown d-none d-md-block"
                    variant="link"
                    size="md"
                    no-caret
                    right
                    toggle-class="p-0 border-0 nav-item-icon d-flex"
                    menu-class="border-0 shadow rounded mt-3"
                >
                    <template slot="button-content">
                        <div class="icon">
                            <image-
                                class="m-1 rounded-circle"
                                source="/black.png"
                                height="32"
                                width="32"
                            />
                        </div>
                    </template>
                    <b-dropdown-item
                        to="/profile"
                        class="d-flex dropdown-profile"
                    >
                        <image-
                            class="rounded-circle m-1"
                            source="/black.png"
                            height="40"
                            width="40"
                        />
                        <div class="dropdown-profile-detail">
                            <div class="dropdown-profile-detail-name">
                                {{ employee.name }}
                            </div>
                            <div class="dropdown-profile-detail-position">
                                {{ employee.position.name }}
                            </div>
                        </div>
                    </b-dropdown-item>
                    <div class="hr line" />
                    <b-dropdown-item-icon-
                        text="Đăng xuất"
                        icon=""
                        @click="logout"
                    />
                </b-dropdown>
            </b-navbar-nav>
        </b-collapse>
    </b-navbar>
</template>
<script lang="ts">
import { Vue, namespace, Component } from 'nuxt-property-decorator';
import { UserState } from 'store/user';
import { UserLogin } from 'graphql/types';

@Component({
    name: 'navbar-',
})
export default class extends Vue {
    isInputFocus = false;

    @namespace('style').State
    breakpoint;

    @namespace('user').Action
    logout;

    @namespace('user').State(
        (state: UserState) => state.employee || { position: {} },
    )
    employee: UserLogin.Employee;
}
</script>
<style lang="scss">
.dropdown-profile {
    padding: 1rem;
    margin-top: -0.5rem;
    > .dropdown-profile-detail {
        height: 3rem;
        margin-left: 0.75rem;
        margin-right: 2.5rem;
        > .dropdown-profile-detail-name {
            margin-top: 0.25rem;
            line-height: 1.5rem;
            font-weight: bold;
            font-size: 1rem;
        }
        > .dropdown-profile-detail-position {
            line-height: 1.25rem;
            font-size: 0.8rem;
        }
    }
}
</style>
