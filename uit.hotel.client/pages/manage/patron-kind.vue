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
            :query="getPatronKinds"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { patronKinds } }"
                class="table-style"
                :items="patronKinds"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'name',
                        label: 'Tên loại khách hàng',
                        sortable: true,
                    },
                    {
                        key: 'description',
                        label: 'Mô tả',
                        tdClass: 'w-100',
                        sortable: true,
                    },
                    {
                        key: 'patrons',
                        label: 'Số lượng',
                        tdClass: 'text-nowrap text-right',
                        sortable: true,
                    },
                ]"
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
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <template slot="patrons" slot-scope="{ value }">
                    {{ value.length }} khách hàng
                </template>
            </b-table>
        </query->
        <context-manage-patron-kind- ref="context_patron_kind" :refs="$refs" />
        <popup-patron-kind-add- ref="patron_kind_add" />
        <popup-patron-kind-update- ref="patron_kind_update" />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getPatronKinds } from '~/graphql/documents/patronKind';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    name: 'patronKind-',
    mixins: [mixinData({ getPatronKinds })],
})
export default class extends Vue {
    head() {
        return {
            title: 'Quản lý loại khách hàng',
        };
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

    console = console;
}
</script>
