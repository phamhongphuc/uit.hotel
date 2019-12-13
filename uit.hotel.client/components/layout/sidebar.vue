<template>
    <b-navbar-nav class="sidebar-nav">
        <b-nav-item-icon- to="/" icon="trello" text="Bảng điều khiển" exact />
        <b-nav-item-icon-
            text="Nghiệp vụ lễ tân"
            class="sidebar-nav-item-header"
            :permission="[
                'GetMap',
                'ManagePatron',
                'ManagePatronKind',
                'ManageRentingRoom',
            ]"
        />
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
        <b-nav-item-icon-
            text="Quản lý kinh doanh"
            class="sidebar-nav-item-header"
            :permission="[
                'GetAccountingVoucher',
                'ManageService',
                'ManagePrice',
            ]"
        />
        <b-nav-item-icon-
            id="sidebar-business-bill"
            to="/business/bill"
            icon="bill-sign"
            text="Quản lý hóa đơn"
            exact
            :permission="['GetAccountingVoucher']"
        >
            <template v-slot:suffix>
                <b-badge pill variant="danger" class="ml-2">
                    12
                </b-badge>
            </template>
            <b-tooltip
                target="sidebar-business-bill"
                placement="right"
                boundary="window"
            >
                Chưa thanh toán: 12
                <br />
                Đang thuê: 5
            </b-tooltip>
        </b-nav-item-icon->
        <b-nav-item-icon-
            to="/business/price"
            icon="receipt"
            text="Quản lý giá"
            exact
            :permission="['ManagePrice']"
        />
        <b-nav-item-icon-
            to="/business/service"
            icon="shopping-bag"
            text="Quản lý dịch vụ"
            exact
            :permission="['ManageService']"
        />
        <b-nav-item-icon-
            text="Quản lý nhân sự"
            class="sidebar-nav-item-header"
            :permission="['ManagePosition', 'ManageEmployee']"
        />
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
        <b-nav-item-icon-
            text="Cài đặt khách sạn"
            class="sidebar-nav-item-header"
            :permission="['ManageMap', 'ManagePatronKind']"
        />
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
    </b-navbar-nav>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';

@Component({
    name: 'sidebar-',
})
export default class extends Vue {
    showReceptionist = false;
    showBusiness = false;
    showPersonnel = false;
    showManage = false;

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
    }
}
</script>
<style lang="scss">
.sidebar-nav {
    display: block !important;
    padding: 1rem;
    overflow-y: auto;
    background-color: $white;
    box-shadow: $box-shadow-sm-right;
    &-item-header {
        height: 2rem !important;
        min-height: 2rem;
        padding: 0 0.25rem;
        color: $light;
        font-weight: bold;
        font-size: 0.75rem;
        line-height: 2rem;
        text-transform: uppercase;
        border-radius: 0 0.25rem 0.25rem 0;
    }
    > :not(.sidebar-nav-item-header) {
        height: $navbar-size;
        padding-right: 0.25rem;
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
                margin-right: 0.25rem;
                font-size: $navbar-size * 0.5;
            }
        }
    }
}
</style>
