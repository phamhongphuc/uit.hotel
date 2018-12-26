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
                Hotel Management {{ breakpoint }}
            </b-nav-item>
            <b-nav-item-icon-
                class="d-md-none mx-1"
                to="/profile"
                image="/favicon.png"
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
                    placeholder="Search..."
                    icon=""
                    :focus.sync="isInputFocus"
                />
                <b-nav-item-icon-
                    to="/profile"
                    image="/favicon.png"
                    text="Tên người dùng"
                    text-class="d-md-none"
                    class="d-none d-md-block"
                    :class="isInputFocus ? 'w-0 h-0' : ''"
                />
            </b-navbar-nav>
        </b-collapse>
    </b-navbar>
</template>
<script lang="ts">
import { Vue, namespace, Component } from 'nuxt-property-decorator';

@Component
export default class extends Vue {
    isInputFocus = false;

    @namespace('style').State breakpoint;
}
</script>
