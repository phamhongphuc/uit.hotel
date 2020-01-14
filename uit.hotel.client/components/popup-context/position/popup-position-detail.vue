<template>
    <popup-
        ref="popup"
        v-slot
        class="popup-position-detail"
        :title="`Chi tiết quyền ${position ? position.name : ''}`"
        @contextmenu.prevent="tableContext"
    >
        <query-
            v-slot
            :query="getPosition"
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
                                    `text-${positionColorMap(
                                        position.isActive,
                                    )}`
                                "
                            />
                            {{ positionTitleMap(position.isActive) }}
                        </span>
                    </div>
                    <b-button-mutate-
                        class="px-2 py-1 ml-2"
                        variant="lighten"
                        :mutation="setIsActivePosition"
                        :variables="{
                            id: position.id,
                            isActive: !position.isActive,
                        }"
                    >
                        <icon-
                            :i="position.isActive ? 'x' : 'chevrons-up'"
                            class="ml-n1 mr-1"
                        />
                        {{
                            position.isActive
                                ? 'Vô hiệu hóa vị trí'
                                : 'Kích hoạt lại vị trí'
                        }}
                    </b-button-mutate->
                    <b-button
                        class="ml-2"
                        size="sm"
                        variant="lighten"
                        @click="refs.position_update.open({ position })"
                    >
                        <icon- class="mr-1" i="edit-2" />
                        <span>Sửa</span>
                    </b-button>
                </div>
                <div class="font-weight-medium my-1 pl-1">
                    Chi tiết quyền:
                </div>
                <div class="d-flex my-n3">
                    <div>
                        <b-checkbox-group-
                            v-model="selected"
                            :options="positionOptionsBusiness"
                            title="Nhóm quyền của nhân viên kinh doanh"
                            class="mx-n4 px-1"
                            disabled
                        />
                        <b-checkbox-group-
                            v-model="selected"
                            :options="positionOptionsAdministrative"
                            title="Nhóm quyền của nhân viên hành chính"
                            class="mx-n4 px-1"
                            disabled
                        />
                    </div>
                    <div class="pl-3">
                        <b-checkbox-group-
                            v-model="selected"
                            :options="positionOptionsReceptionist"
                            title="Nhóm quyền của nhân viên lễ tân"
                            class="mx-n4 px-1"
                            disabled
                        />
                        <b-checkbox-group-
                            v-model="selected"
                            :options="positionOptionsHouseKeeping"
                            title="Nhóm quyền của nhân viên dọn dẹp"
                            class="mx-n4 px-1"
                            disabled
                        />
                    </div>
                </div>
                <div class="font-weight-medium my-1 pl-1">
                    Danh sách nhân viên:
                </div>
                <div class="my-1 overflow-auto">
                    <b-table
                        show-empty
                        class="table-style table-sm bg-lighten rounded overflow-hidden"
                        :items="position.employees"
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
                        ]"
                        @row-clicked="
                            (employee, $index, $event) => {
                                $event.stopPropagation();
                                refs.context_employee.open(
                                    currentEvent || $event,
                                    { employee },
                                );
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
                                <icon-
                                    i="circle-fill"
                                    class="mr-1 text-green"
                                />
                                Đang hoạt động
                            </span>
                            <span v-else>
                                <icon-
                                    i="circle-fill"
                                    class="mr-1 text-light"
                                />
                                Ngưng hoạt động
                            </span>
                        </template>
                        <template v-slot:cell(phoneNumber)="{ value }">
                            <a :href="`tel:${value}`" @click.stop>
                                {{ value }}
                            </a>
                        </template>
                    </b-table>
                </div>
            </div>
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetPosition, GetPositionQuery } from '~/graphql/types';
import { getPosition, setIsActivePosition } from '~/graphql/documents';
import {
    positionTitleMap,
    positionColorMap,
    positionOptionsAdministrative,
    positionOptionsBusiness,
    positionOptionsReceptionist,
    positionOptionsHouseKeeping,
    permission,
} from '~/modules/model';
import { CheckboxOption, toNameFormatter, toYear, fromNow } from '~/utils';

type PopupMixinType = PopupMixin<{ id: number }, null>;

@Component({
    name: 'popup-position-detail-',
    validations: {},
})
export default class extends mixins<
    PopupMixinType,
    {
        positionOptionsAdministrative: CheckboxOption[];
        positionOptionsBusiness: CheckboxOption[];
        positionOptionsReceptionist: CheckboxOption[];
        positionOptionsHouseKeeping: CheckboxOption[];
    }
>(
    PopupMixin,
    DataMixin({
        fromNow,
        getPosition,
        positionColorMap,
        positionOptionsAdministrative,
        positionOptionsBusiness,
        positionOptionsHouseKeeping,
        positionOptionsReceptionist,
        positionTitleMap,
        setIsActivePosition,
        toNameFormatter,
        toYear,
    }),
) {
    variables!: GetPosition.Variables;
    position: GetPosition.Position | null = null;
    selected: string[] = [];

    get positionOptions() {
        const options = {};

        const eachOption = option => {
            options[option.value] = this.selected.indexOf(option.value) !== -1;
        };

        this.positionOptionsAdministrative.forEach(eachOption);
        this.positionOptionsBusiness.forEach(eachOption);
        this.positionOptionsReceptionist.forEach(eachOption);
        this.positionOptionsHouseKeeping.forEach(eachOption);

        return options;
    }

    onOpen() {
        this.variables = { id: this.data.id.toString() };
    }

    onResult({ data }: ApolloQueryResult<GetPositionQuery>) {
        this.position = data.position;
        this.selected = [];
        permission.forEach(p => data.position[p] && this.selected.push(p));
    }
}
</script>
<style lang="scss">
.popup-position-detail {
    .custom-control.custom-checkbox {
        &,
        & * {
            cursor: not-allowed;
        }
    }
}
</style>
