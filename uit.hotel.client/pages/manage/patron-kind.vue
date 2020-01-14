<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.patron_kind_add.open()"
            >
                <icon- class="mr-1" i="plus" />
                <span>Thêm loại khách hàng mới</span>
            </b-button>
        </block-flex->
        <query-
            v-slot="{ data: { patronKinds } }"
            :query="getPatronKinds"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                show-empty=""
                :items="patronKinds"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                    },
                    {
                        key: 'name',
                        label: 'Tên loại khách hàng',
                        sortable: true,
                    },
                    {
                        key: 'description',
                        label: 'Mô tả',
                    },
                    {
                        key: 'patrons',
                        label: 'Số lượng',
                        tdClass: 'text-nowrap text-right',
                        sortable: true,
                    },
                ]"
                class="table-style table-header-line"
                @row-clicked="
                    (patronKind, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_patron_kind.open(currentEvent || $event, {
                            patronKind,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template v-slot:empty>
                    Không tìm thấy loại khách hàng nào
                </template>
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(patrons)="{ value }">
                    {{ value.length }} khách hàng
                </template>
            </b-table>
        </query->
        <context-manage-patron-kind- ref="context_patron_kind" />
        <popup-patron-detail- ref="patron_detail" />
        <popup-patron-kind-add- ref="patron_kind_add" />
        <popup-patron-kind-update- ref="patron_kind_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getPatronKinds } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';

@Component({
    name: 'patronKind-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getPatronKinds }),
) {
    head() {
        return {
            title: 'Quản lý loại khách hàng',
        };
    }
}
</script>
