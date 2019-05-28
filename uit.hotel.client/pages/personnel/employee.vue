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
            :query="getEmployees"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { employees } }"
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
                class="table-style"
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
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <template slot="phoneNumber" slot-scope="{ value }">
                    <a :href="`tel:${value}`" @click.stop>{{ value }}</a>
                </template>
                <template slot="position" slot-scope="{ value }">
                    {{ value.name }}
                </template>
            </b-table>
        </query->
        <context-manage-employee- ref="context_employee" :refs="$refs" />
        <popup-employee-add- ref="employee_add" />
        <popup-employee-update- ref="employee_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getEmployees } from '~/graphql/documents';
import { DataMixin } from '~/components/mixins';
import { GetEmployees } from '~/graphql/types';

@Component({
    name: 'employee-',
})
export default class extends mixins(DataMixin({ getEmployees })) {
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

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');
        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }

    currentEvent: MouseEvent | null = null;

    showInactive: boolean = false;
}
</script>
