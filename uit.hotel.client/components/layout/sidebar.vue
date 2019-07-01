<template>
    <b-collapse id="sidebar-collapse" visible :style="sidebarStyle">
        <b-navbar-nav id="sidebar-nav">
            <b-nav-item-icon-
                v-b-toggle.collapse_receptionist
                icon="chevron-down"
                text="Nghiệp vụ lễ tân"
                class="header-item"
                :permission="[
                    'GetMap',
                    'ManagePatron',
                    'ManagePatronKind',
                    'ManageRentingRoom',
                ]"
            />
            <b-collapse-
                id="collapse_receptionist"
                v-model="showReceptionist"
                auto-permission
            >
                <b-nav-item-icon-
                    to="/receptionist/timeline"
                    icon="clock"
                    text="Dòng thời gian"
                    exact
                    :permission="['ManageRentingRoom']"
                />
                <b-nav-item-icon-
                    to="/receptionist/map"
                    icon="grid"
                    text="Sơ đồ khách sạn"
                    exact
                    :permission="['GetMap']"
                />
                <b-nav-item-icon-
                    to="/receptionist/patron"
                    icon="users"
                    text="Quản lý khách hàng"
                    exact
                    :permission="['ManagePatron', 'ManagePatronKind']"
                />
                <!-- <b-nav-item-icon-
                    to="/receptionist/booking"
                    icon="box"
                    text="Quản lý đặt phòng"
                    exact
                    :permission="['ManageRentingRoom']"
                /> -->
            </b-collapse->
            <b-nav-item-icon-
                v-b-toggle.collapse_business
                icon="chevron-down"
                text="Quản lý kinh doanh"
                class="header-item"
                :permission="[
                    'GetAccountingVoucher',
                    'ManageService',
                    'ManageRate',
                ]"
            />
            <b-collapse-
                id="collapse_business"
                v-model="showBusiness"
                auto-permission
            >
                <b-nav-item-icon-
                    to="/business/bill"
                    icon="dollar-sign"
                    text="Quản lý hóa đơn"
                    exact
                    :permission="['GetAccountingVoucher']"
                />
                <b-nav-item-icon-
                    to="/business/receipt"
                    icon="dollar-sign"
                    text="Quản lý phiếu thu"
                    exact
                    :permission="['GetAccountingVoucher']"
                />
                <b-nav-item-icon-
                    to="/business/service"
                    icon="shopping-cart"
                    text="Quản lý dịch vụ"
                    exact
                    :permission="['ManageService']"
                />
                <b-nav-item-icon-
                    to="/business/rate"
                    icon="shopping-cart"
                    text="Quản lý giá"
                    exact
                    :permission="['ManageRate']"
                />
            </b-collapse->
            <b-nav-item-icon-
                v-b-toggle.collapse_personnel
                icon="chevron-down"
                text="Quản lý nhân sự"
                class="header-item"
                :permission="['ManagePosition', 'ManageEmployee']"
            />
            <b-collapse-
                id="collapse_personnel"
                v-model="showPersonnel"
                auto-permission
            >
                <b-nav-item-icon-
                    to="/personnel/position"
                    icon="lock"
                    text="Quản lý phân quyền"
                    exact
                    :permission="['ManagePosition']"
                />
                <b-nav-item-icon-
                    to="/personnel/employee"
                    icon="users"
                    text="Quản lý nhân viên"
                    exact
                    :permission="['ManageEmployee']"
                />
            </b-collapse->
            <b-nav-item-icon-
                v-b-toggle.collapse_manage
                icon="chevron-down"
                text="Cài đặt khách sạn"
                class="header-item"
                :permission="['ManageMap', 'ManagePatronKind']"
            />
            <b-collapse-
                id="collapse_manage"
                v-model="showManage"
                auto-permission
            >
                <b-nav-item-icon-
                    to="/manage/floor-room"
                    icon="archive"
                    text="Quản lý tầng phòng"
                    exact
                    :permission="['ManageMap']"
                />
                <b-nav-item-icon-
                    to="/manage/room-kind"
                    icon="box"
                    text="Quản lý loại phòng"
                    exact
                    :permission="['ManageMap']"
                />
                <b-nav-item-icon-
                    to="/manage/patron-kind"
                    icon="users"
                    text="Quản lý loại khách hàng"
                    exact
                    :permission="['ManagePatronKind']"
                />
            </b-collapse->
        </b-navbar-nav>
    </b-collapse>
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

    sidebarStyle = {
        width: 'auto',
    };

    async mounted() {
        await Vue.nextTick();
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
        const sidebarCollapse = document.getElementById('sidebar-collapse');
        if (sidebarCollapse === null) throw new Error();
        this.sidebarStyle.width =
            sidebarCollapse.getBoundingClientRect().width + 'px';
    }
}
</script>
<style lang="scss">
#sidebar-collapse {
    display: block !important;
    flex-direction: column;
    justify-content: flex-start;
    max-width: 100%;
    height: 100% !important;
    overflow-y: auto;
    background-color: $white;
    box-shadow: $box-shadow-sm-right;
    transition: width 0.2s;
    &:not(.show) {
        width: 0 !important;
    }
    > #sidebar-nav {
        padding: 1rem;
        > .header-item {
            height: 2rem;
            min-height: 2rem;
            color: $light;
            font-weight: bold;
            font-size: 0.8rem;
            line-height: 2rem;
            text-transform: uppercase;
            border-radius: 0 0.25rem 0.25rem 0;
            > .nav-link {
                flex-direction: row-reverse;
                > .icon {
                    height: 2rem;
                    min-height: 2rem;
                    margin-left: auto;
                    line-height: 2rem;
                    transform-style: preserve-3d;
                    transition: transform 0.2s;
                }
            }
            &.collapsed > .nav-link > .icon {
                transform: rotateX(180deg);
            }
        }
        > :not(.header-item) {
            margin-right: 0.75rem;
            margin-left: 0;
            &.collapse:not(.show) {
                display: block !important;
                height: 0;
                overflow: hidden;
            }
            .nav-item-icon {
                height: $navbar-size;
                overflow: hidden;
                transition: all 0.2s;
                > .nav-link {
                    display: flex;
                    font-weight: 600;
                    white-space: nowrap;
                    transition: all 0.25s;
                    &:hover,
                    &.active {
                        color: $main;
                    }
                    > div {
                        overflow: hidden;
                        text-overflow: ellipsis;
                    }
                    > .icon {
                        font-size: 1.25rem;
                    }
                }
            }
        }
    }
}
</style>
