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
                :items="employeesFilter(employees)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'name',
                        label: 'Tên nhân viên',
                        tdClass: (value, key, row) => {
                            if (!row.isActive)
                                return 'table-cell-disable w-100';
                            return 'w-100';
                        },
                        sortable: true,
                    },
                    {
                        key: 'phoneNumber',
                        label: 'Số điện thoại',
                        tdClass: 'text-center text-nowrap',
                        sortable: true,
                    },
                    {
                        key: 'position',
                        label: 'Vị trí',
                        tdClass: 'text-center text-nowrap',
                        sortable: true,
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
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(phoneNumber)="{ value }">
                    <a :href="`tel:${value}`" @click.stop>{{ value }}</a>
                </template>
                <template v-slot:cell(position)="{ value }">
                    {{ value.name }}
                </template>
            </b-table>
            <div
                v-if="employeesFilter(employees).length === 0"
                class="table-after"
            >
                Không tìm thấy nhân viên nào
            </div>
        </query->
        <context-manage-employee- ref="context_employee" />
        <popup-employee-add- ref="employee_add" />
        <popup-employee-update- ref="employee_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getEmployees } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { GetEmployees } from '~/graphql/types';

@Component({
    name: 'employee-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getEmployees }),
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
