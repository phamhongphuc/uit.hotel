<template>
    <popup-
        ref="popup"
        v-slot
        title="Chi tiết nhân viên"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getEmployee"
            :variables="variables"
            @result="onResult"
        >
            <div class="p-3">
                <div class="d-flex m-child-1 flex-wrap">
                    <div class="font-weight-medium p-1 mr-auto">
                        Trạng thái:
                        <span>
                            <icon-
                                i="circle-fill"
                                class="m-1"
                                :class="
                                    `text-${employeeColorMap(
                                        employee.isActive,
                                    )}`
                                "
                            />
                            {{ employeeTitleMap(employee.isActive) }}
                        </span>
                    </div>
                    <b-button-mutate-
                        class="px-2 py-1 ml-2"
                        variant="lighten"
                        :mutation="setIsActiveAccount"
                        :variables="{
                            id: employee.id,
                            isActive: !employee.isActive,
                        }"
                    >
                        <icon-
                            :i="employee.isActive ? 'x' : 'chevrons-up'"
                            class="ml-n1 mr-1"
                        />
                        {{
                            employee.isActive
                                ? 'Vô hiệu hóa nhân viên'
                                : 'Kích hoạt lại nhân viên'
                        }}
                    </b-button-mutate->
                    <b-button
                        class="ml-2"
                        size="sm"
                        variant="lighten"
                        @click="refs.employee_update.open({ id: employee.id })"
                    >
                        <icon- class="mr-1" i="edit-2" />
                        <span>Sửa</span>
                    </b-button>
                </div>
                <div class="px-1 mt-2">
                    <b-table-simple small borderless class="table-key-value">
                        <b-tbody>
                            <b-tr>
                                <b-td>Tên đăng nhập</b-td>
                                <b-td>{{ employee.id }}</b-td>
                            </b-tr>
                            <b-tr>
                                <b-td>Tên nhân viên</b-td>
                                <b-td>{{ employee.name }}</b-td>
                            </b-tr>
                            <b-tr>
                                <b-td>Vị trí</b-td>
                                <b-td>
                                    <b-link
                                        class="text-main"
                                        href="#"
                                        @click="
                                            refs.position_detail.open({
                                                id: employee.position.id,
                                            })
                                        "
                                    >
                                        {{ employee.position.name }}
                                    </b-link>
                                </b-td>
                            </b-tr>
                            <b-tr>
                                <b-td>Ngày bắt đầu</b-td>
                                <b-td>
                                    {{ toDate(employee.startingDate) }}
                                </b-td>
                            </b-tr>
                            <b-tr>
                                <b-td>Chứng minh nhân dân</b-td>
                                <b-td>{{ employee.identityCard }}</b-td>
                            </b-tr>
                            <b-tr>
                                <b-td>Giới tính</b-td>
                                <b-td>
                                    {{ employee.gender ? 'Nam' : 'Nữ' }}
                                </b-td>
                            </b-tr>
                            <b-tr>
                                <b-td>Ngày sinh</b-td>
                                <b-td>
                                    {{ toDate(employee.birthdate) }}
                                </b-td>
                            </b-tr>
                            <b-tr>
                                <b-td>Số điện thoại</b-td>

                                <b-td>
                                    <a
                                        v-if="
                                            employee.phoneNumber !== '' &&
                                                employee.phoneNumber !== null
                                        "
                                        :href="`tel:${employee.phoneNumber}`"
                                        @click.stop
                                    >
                                        {{ employee.phoneNumber }}
                                    </a>
                                    <span v-else>-</span>
                                </b-td>
                            </b-tr>
                            <b-tr>
                                <b-td>Thư điện tử</b-td>
                                <b-td>
                                    <a
                                        v-if="
                                            employee.email !== '' &&
                                                employee.email !== null
                                        "
                                        :href="`mailto:${employee.email}`"
                                        @click.stop
                                    >
                                        {{ employee.email }}
                                    </a>
                                    <span v-else>-</span>
                                </b-td>
                            </b-tr>
                            <b-tr>
                                <b-td>Địa chỉ</b-td>
                                <b-td>
                                    {{ dash(employee.address) }}
                                </b-td>
                            </b-tr>
                        </b-tbody>
                    </b-table-simple>
                </div>
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { dash, toDate } from '~/utils';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetEmployee, GetEmployeeQuery } from '~/graphql/types';
import { getEmployee, setIsActiveAccount } from '~/graphql/documents';
import { employeeTitleMap, employeeColorMap } from '~/modules/model';

type PopupMixinType = PopupMixin<{ id: number | string }, null>;

@Component({
    name: 'popup-employee-detail-',
    validations: {},
})
export default class extends mixins<PopupMixinType, {}>(
    PopupMixin,
    DataMixin({
        employeeColorMap,
        employeeTitleMap,
        getEmployee,
        setIsActiveAccount,
        toDate,
        dash,
    }),
) {
    variables!: GetEmployee.Variables;
    employee!: GetEmployee.Employee;

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    onResult({ data: { employee } }: ApolloQueryResult<GetEmployeeQuery>) {
        this.employee = employee;
    }
}
</script>
