<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.employee_add.open()"
            >
                <icon- class="mr-1" i="plus" />
                <span>Thêm nhân viên mới</span>
            </b-button>
            <b-button
                class="m-2 ml-auto"
                variant="white"
                @click="showInactive = !showInactive"
            >
                <icon- :i="showInactive ? 'eye' : 'eye-off'" class="mx-1" />
                <span>
                    {{
                        `Đang ${
                            showInactive ? 'hiện' : 'ẩn'
                        } nhân viên đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </block-flex->
        <query-
            v-slot="{ data: { employees } }"
            :query="getEmployees"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                show-empty
                :items="employeesFilter(employees)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                    },
                    {
                        key: 'id',
                        label: 'Tên đăng nhập',
                        tdClass: (value, key, row) =>
                            !row.isActive && 'table-cell-disable',
                        sortable: true,
                    },
                    {
                        key: 'position',
                        label: 'Vị trí',
                        tdClass: 'text-center text-nowrap',
                        sortable: true,
                        formatter: toNameFormatter,
                    },
                    {
                        key: 'name',
                        label: 'Tên nhân viên',
                        tdClass: (value, key, row) =>
                            !row.isActive && 'table-cell-disable',
                        sortable: true,
                    },
                    {
                        key: 'isActive',
                        label: 'Trạng thái',
                    },

                    {
                        key: 'gender',
                        label: 'Giới tính',
                        formatter: gender => (gender ? 'Nam' : 'Nữ'),
                    },
                    {
                        key: 'phoneNumber',
                        label: 'Số điện thoại',
                        tdClass: 'text-center text-nowrap',
                    },
                    {
                        key: 'birthdate',
                        label: 'Năm sinh',
                        tdClass: 'text-nowrap',
                        formatter: toYear,
                    },
                    {
                        key: 'startingDate',
                        label: 'Đã vào làm',
                        formatter: v => `Từ năm ${toYear(v)} - ${fromNow(v)}`,
                    },
                ]"
                class="table-style table-header-line"
                @row-clicked="
                    (employee, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_employee.open(currentEvent || $event, {
                            employee,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template v-slot:empty>
                    Không tìm thấy nhân viên nào
                </template>
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(isActive)="{ value }">
                    <span v-if="value">
                        <icon- i="circle-fill" class="mr-1 text-green" />
                        Đang hoạt động
                    </span>
                    <span v-else>
                        <icon- i="circle-fill" class="mr-1 text-light" />
                        Ngưng hoạt động
                    </span>
                </template>
                <template v-slot:cell(phoneNumber)="{ value }">
                    <a :href="`tel:${value}`" @click.stop>{{ value }}</a>
                </template>
            </b-table>
        </query->
        <context-manage-employee- ref="context_employee" />
        <popup-employee-detail- ref="employee_detail" />
        <popup-employee-add- ref="employee_add" />
        <popup-employee-update- ref="employee_update" />
        <popup-position-detail- ref="position_detail" />
        <popup-position-update- ref="position_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getEmployees } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { GetEmployees } from '~/graphql/types';
import { toNameFormatter, toYear, fromNow } from '~/utils';

@Component({
    name: 'employee-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getEmployees, toNameFormatter, toYear, fromNow }),
) {
    head() {
        return {
            title: 'Quản lý nhân viên',
        };
    }

    employeesFilter(
        employees: GetEmployees.Employees[],
    ): GetEmployees.Employees[] {
        if (this.showInactive) return employees;

        if (employees === undefined) return [];

        return employees.filter(rk => rk.isActive);
    }

    showInactive = false;
}
</script>
