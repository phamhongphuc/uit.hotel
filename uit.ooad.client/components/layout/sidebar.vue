<template>
    <b-navbar-nav id="sidebar">
        <b-nav-item-icon- to="/" icon="" text="Sơ đồ khách sạn" exact />
        <b-nav-item-icon-
            to="/manage/floor-room"
            icon=""
            text="Quản lý tầng phòng"
            exact
        />
        <b-nav-item-icon-
            to="/help"
            icon=""
            text="Thông tin"
            exact
            class="mt-auto"
        />
    </b-navbar-nav>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';

@Component({
    name: 'sidebar-',
})
export default class extends Vue {}
</script>
<style lang="scss">
#sidebar {
    flex-direction: column;
    justify-content: flex-start;
    padding: 1rem 1rem 1rem 0;
    background-color: $white;
    box-shadow: $box-shadow-sm-right;

    .nav-item-icon {
        > .nav-link {
            padding-right: 1.5rem;
            padding-left: 0.5rem;
            border-radius: 0 1.25rem 1.25rem 0;
            font-weight: 600;
            transition: all 0.25s;
            &:hover {
                color: $main;
            }
            &.active {
                background: $main;
                color: $white;
            }
        }
        .icon {
            font-size: 1.25rem;
        }
    }
}
</style>
