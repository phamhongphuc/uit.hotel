<template>
    <b-navbar-nav id="sidebar">
        <b-nav-item-icon-
            v-b-toggle.collapse_dashboard
            icon=""
            text="Nghiệp vụ lễ tân"
            class="header-item"
        />
        <b-collapse id="collapse_dashboard" v-model="showDashboard">
            <b-nav-item-icon- to="/" icon="" text="Sơ đồ khách sạn" exact />
            <b-nav-item-icon-
                to="/manage/patron"
                icon=""
                text="Quản lý khách hàng"
                exact
            />
        </b-collapse>
        <b-nav-item-icon-
            v-b-toggle.collapse_business
            icon=""
            text="Quản lý kinh doanh"
            class="header-item"
        />
        <b-collapse id="collapse_business" v-model="showBusiness">
            <b-nav-item-icon-
                to="/manage/bill"
                icon=""
                text="Quản lý hóa đơn"
                exact
            />
            <b-nav-item-icon-
                to="/manage/receipt"
                icon=""
                text="Quản lý phiếu thu"
                exact
            />
            <b-nav-item-icon-
                to="/manage/service"
                icon=""
                text="Quản lý dịch vụ"
                exact
            />
        </b-collapse>
        <b-nav-item-icon-
            v-b-toggle.collapse_employee
            icon=""
            text="Quản lý nhân sự"
            class="header-item"
        />
        <b-collapse id="collapse_employee" v-model="showEmployee">
            <b-nav-item-icon-
                to="/manage/position"
                icon=""
                text="Quản lý phân quyền"
                exact
            />
            <b-nav-item-icon-
                to="/manage/employee"
                icon=""
                text="Quản lý nhân viên"
                exact
            />
        </b-collapse>
        <b-nav-item-icon-
            v-b-toggle.collapse_manage
            icon=""
            text="Cài đặt khách sạn"
            class="header-item"
        />
        <b-collapse id="collapse_manage" v-model="showManage">
            <b-nav-item-icon-
                to="/manage/floor-room"
                icon=""
                text="Quản lý tầng phòng"
                exact
            />
            <b-nav-item-icon-
                to="/manage/room-kind"
                icon=""
                text="Quản lý loại phòng"
                exact
            />
            <b-nav-item-icon-
                to="/manage/patron-kind"
                icon=""
                text="Quản lý loại khách hàng"
                exact
            />
        </b-collapse>
    </b-navbar-nav>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';

@Component({
    name: 'sidebar-',
})
export default class extends Vue {
    showDashboard: boolean = false;
    showSystem: boolean = false;
    showEmployee: boolean = false;
    showBusiness: boolean = false;
    showManage: boolean = false;

    mounted() {
        if (this.$route !== undefined) {
            if (this.$route.path.indexOf('/manage') === 0) {
                this.showManage = true;
            }
        }
    }
}
</script>
<style lang="scss">
#sidebar {
    flex-direction: column;
    justify-content: flex-start;
    padding: 1rem;
    background-color: $white;
    box-shadow: $box-shadow-sm-right;

    > .header-item {
        border-radius: 0 0.25rem 0.25rem 0;
        text-transform: uppercase;
        color: $light;
        font-weight: bold;
        font-size: 0.8rem;
        line-height: 2rem;
        height: 2rem;
        > .nav-link {
            flex-direction: row-reverse;
            > .icon {
                line-height: 2rem;
                min-height: 2rem;
                height: 2rem;
                margin-left: auto;
            }
        }
    }
    > :not(.header-item) {
        margin-right: 0.75rem;
        margin-left: 0;
        &.collapse:not(.show) {
            display: block !important;
            overflow: hidden;
            height: 0;
        }
        .nav-item-icon {
            transition: all 0.2s;
            overflow: hidden;
            height: $navbar-size;
            > .nav-link {
                display: flex;
                font-weight: 600;
                transition: all 0.25s;
                &:hover {
                    color: $main;
                }
                &.active {
                    color: $main;
                }
                > .icon {
                    font-size: 1.25rem;
                }
            }
        }
    }
}
</style>
