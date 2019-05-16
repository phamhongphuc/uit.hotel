<template>
    <b-navbar-nav id="sidebar">
        <b-nav-item-icon-
            v-b-toggle.collapse_receptionist
            icon="chevron-down"
            text="Nghiệp vụ lễ tân"
            class="header-item"
            :permission="[
                'GetMap',
                'ManagePatron',
                'ManagePatronKind',
                'ManageHiringRoom',
            ]"
        />
        <b-collapse id="collapse_receptionist" v-model="showReceptionist">
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
            <b-nav-item-icon-
                to="/receptionist/booking"
                icon="box"
                text="Quản lý đặt phòng"
                exact
                :permission="['ManageHiringRoom']"
            />
        </b-collapse>
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
        <b-collapse id="collapse_business" v-model="showBusiness">
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
        </b-collapse>
        <b-nav-item-icon-
            v-b-toggle.collapse_personnel
            icon="chevron-down"
            text="Quản lý nhân sự"
            class="header-item"
            :permission="['ManagePosition', 'ManageEmployee']"
        />
        <b-collapse id="collapse_personnel" v-model="showPersonnel">
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
        </b-collapse>
        <b-nav-item-icon-
            v-b-toggle.collapse_manage
            icon="chevron-down"
            text="Cài đặt khách sạn"
            class="header-item"
            :permission="['ManageMap', 'ManagePatronKind']"
        />
        <b-collapse id="collapse_manage" v-model="showManage">
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
                transition: transform 0.2s;
                transform-style: preserve-3d;
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
