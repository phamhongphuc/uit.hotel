<template>
    <b-navbar-nav id="sidebar">
        <b-nav-item-icon-
            v-b-toggle.collapse_receptionist
            icon=""
            text="Nghiệp vụ lễ tân"
            class="header-item"
        />
        <b-collapse id="collapse_receptionist" v-model="showReceptionist">
            <b-nav-item-icon-
                to="/receptionist/map"
                icon=""
                text="Sơ đồ khách sạn"
                exact
            />
            <b-nav-item-icon-
                to="/receptionist/patron"
                icon=""
                text="Quản lý khách hàng"
                exact
            />
            <b-nav-item-icon-
                to="/receptionist/booking"
                icon=""
                text="Quản lý đặt phòng"
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
                to="/business/bill"
                icon=""
                text="Quản lý hóa đơn"
                exact
            />
            <b-nav-item-icon-
                to="/business/receipt"
                icon=""
                text="Quản lý phiếu thu"
                exact
            />
            <b-nav-item-icon-
                to="/business/service"
                icon=""
                text="Quản lý dịch vụ"
                exact
            />
            <b-nav-item-icon-
                to="/business/rate"
                icon=""
                text="Quản lý giá"
                exact
            />
        </b-collapse>
        <b-nav-item-icon-
            v-b-toggle.collapse_personnel
            icon=""
            text="Quản lý nhân sự"
            class="header-item"
        />
        <b-collapse id="collapse_personnel" v-model="showPersonnel">
            <b-nav-item-icon-
                to="/personnel/position"
                icon=""
                text="Quản lý phân quyền"
                exact
            />
            <b-nav-item-icon-
                to="/personnel/employee"
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
    showReceptionist: boolean = false;
    showBusiness: boolean = false;
    showPersonnel: boolean = false;
    showManage: boolean = false;

    mounted() {
        if (this.$route !== undefined) {
            if (this.$route.path.indexOf('/receptionist') === 0) {
                this.showReceptionist = true;
            } else if (this.$route.path.indexOf('/business') === 0) {
                this.showBusiness = true;
            } else if (this.$route.path.indexOf('/manage') === 0) {
                this.showManage = true;
            } else if (this.$route.path.indexOf('/personnel') === 0) {
                this.showPersonnel = true;
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
    overflow-y: auto;
    > .header-item {
        border-radius: 0 0.25rem 0.25rem 0;
        text-transform: uppercase;
        color: $light;
        font-weight: bold;
        font-size: 0.8rem;
        line-height: 2rem;
        height: 2rem;
        min-height: 2rem;
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
