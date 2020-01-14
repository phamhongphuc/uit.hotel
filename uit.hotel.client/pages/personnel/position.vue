<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.position_add.open()"
            >
                <icon- class="mr-1" i="plus" />
                <span>Thêm vị trí mới</span>
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
                        } vị trí đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </block-flex->
        <query-
            v-slot="{ data: { positions } }"
            :query="getPositions"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                show-empty
                :items="positionsFilter(positions)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                    },
                    {
                        key: 'name',
                        label: 'Tên vị trí',
                        tdClass: (value, key, row) =>
                            !row.isActive && 'table-cell-disable',
                        sortable: true,
                    },
                    {
                        key: 'employeesActive',
                        label: 'Còn hoạt động',
                        class: 'text-right',
                        sortable: true,
                        formatter: (value, key, item) =>
                            toPeople(
                                item.employees.filter(e => e.isActive).length,
                            ),
                    },
                    {
                        key: 'employees',
                        label: 'Tổng cộng',
                        class: 'text-right',
                        sortable: true,
                        formatter: value => toPeople(value.length),
                    },
                ]"
                class="table-style table-header-line"
                @row-clicked="
                    (position, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_position.open(currentEvent || $event, {
                            position,
                            positions,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template v-slot:empty>
                    Không tìm thấy vị trí nào
                </template>
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
            </b-table>
        </query->
        <context-manage-position- ref="context_position" />
        <context-manage-employee- ref="context_employee" />
        <popup-position-add- ref="position_add" />
        <popup-position-detail- ref="position_detail" />
        <popup-position-update- ref="position_update" />
        <popup-employee-detail- ref="employee_detail" />
        <popup-employee-update- ref="employee_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getPositions } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { GetPositions } from '~/graphql/types';
import { toPeople } from '~/utils';

@Component({
    name: 'position-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getPositions, toPeople }),
) {
    head() {
        return {
            title: 'Quản lý vị trí',
        };
    }

    positionsFilter(
        positions: GetPositions.Positions[],
    ): GetPositions.Positions[] {
        if (this.showInactive) return positions;

        return positions.filter(rk => rk.isActive);
    }

    showInactive = false;
}
</script>
