<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.patron_add.open()"
            >
                <icon- class="mr-1" i="user-plus" />
                <span>Thêm khách hàng mới</span>
            </b-button>
        </block-flex->
        <query-
            v-slot="{ data: { patrons } }"
            :query="getPatrons"
            class="query-fill"
        >
            <b-table
                show-empty
                :items="patrons"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                    },
                    {
                        key: 'name',
                        label: 'Tên khách hàng',
                    },
                    {
                        key: 'gender',
                        label: 'Giới tính',
                        formatter: gender => (gender ? 'Nam' : 'Nữ'),
                    },
                    {
                        key: 'identification',
                        label: 'Chứng minh nhân dân',
                        tdClass: 'text-nowrap',
                    },
                    {
                        key: 'phoneNumber',
                        label: 'Số điện thoại',
                        tdClass: 'text-nowrap',
                    },
                    {
                        key: 'birthdate',
                        label: 'Năm sinh',
                        formatter: toYear,
                    },
                    {
                        key: 'patronKind',
                        label: 'Loại khách hàng',
                        formatter: toNameFormatter,
                    },
                ]"
                class="table-style table-header-line"
                @row-clicked="
                    (patron, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_patron.open(currentEvent || $event, {
                            patron,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template v-slot:empty>
                    Không tìm thấy khách hàng nào
                </template>
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(phoneNumber)="{ value }">
                    <a :href="`tel:${value}`" class="d-block" @click.stop>
                        {{ value }}
                    </a>
                </template>
            </b-table>
        </query->
        <context-manage-patron- ref="context_patron" />
        <popup-patron-detail- ref="patron_detail" />
        <popup-patron-add- ref="patron_add" />
        <popup-patron-update- ref="patron_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getPatrons } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { toYear, toNameFormatter } from '~/utils';

@Component({
    name: 'patron-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getPatrons, toYear, toNameFormatter }),
) {
    head() {
        return {
            title: 'Quản lý khách hàng',
        };
    }
}
</script>
