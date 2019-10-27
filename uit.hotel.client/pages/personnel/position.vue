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
                :items="positionsFilter(positions)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'name',
                        label: 'Tên vị trí',
                        tdClass: (value, key, row) => {
                            if (!row.isActive)
                                return 'table-cell-disable w-100';
                            return 'w-100';
                        },
                        sortable: true,
                    },
                    {
                        key: 'employeesActive',
                        label: 'Hoạt động',
                        tdClass: 'text-center',
                        sortable: true,
                    },
                    {
                        key: 'employeesInactive',
                        label: 'Ngưng hoạt động',
                        tdClass: 'text-center',
                        sortable: true,
                    },
                    {
                        key: 'employees',
                        label: 'Tổng cộng',
                        tdClass: 'text-center',
                        sortable: true,
                    },
                ]"
                class="table-style"
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
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(employeesActive)="{ item }">
                    {{ item.employees.filter(e => e.isActive).length }}
                    người
                </template>
                <template v-slot:cell(employeesInactive)="{ item }">
                    {{ item.employees.filter(e => !e.isActive).length }}
                    người
                </template>
                <template v-slot:cell(employees)="{ value }">
                    {{ value.length }} người
                </template>
            </b-table>
            <div
                v-if="positionsFilter(positions).length === 0"
                class="table-after"
            >
                Không tìm thấy vị trí nào
            </div>
        </query->
        <context-manage-position- ref="context_position" :refs="$refs" />
        <popup-position-add- ref="position_add" />
        <popup-position-update- ref="position_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getPositions } from '~/graphql/documents';
import { DataMixin } from '~/components/mixins';
import { GetPositions } from '~/graphql/types';

@Component({
    name: 'position-',
})
export default class extends mixins(DataMixin({ getPositions })) {
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

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');
        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }

    currentEvent: MouseEvent | null = null;

    showInactive = false;
}
</script>
