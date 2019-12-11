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
                :items="patrons"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'name',
                        label: 'Tên khách hàng',
                        tdClass: 'w-100',
                    },
                    {
                        key: 'identification',
                        label: 'Chứng minh nhân dân',
                        tdClass: 'w-100',
                    },
                    {
                        key: 'phoneNumbers',
                        label: 'Số điện thoại',
                        tdClass: 'text-nowrap',
                    },
                    {
                        key: 'birthdate',
                        label: 'Năm sinh',
                        tdClass: 'text-nowrap',
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
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template v-slot:cell(phoneNumbers)="{ value }">
                    <a :href="`tel:${value}`" class="d-block" @click.stop>
                        {{ value }}
                    </a>
                </template>
                <template v-slot:cell(birthdate)="{ value }">
                    {{ toYear(value) }}
                </template>
            </b-table>
            <div v-if="patrons.length === 0" class="table-after">
                Không tìm thấy khách hàng nào
            </div>
        </query->
        <context-manage-patron- ref="context_patron" />
        <popup-patron-add- ref="patron_add" />
        <popup-patron-update- ref="patron_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getPatrons } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { toYear } from '~/utils';

@Component({
    name: 'patron-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getPatrons, toYear }),
) {
    head() {
        return {
            title: 'Quản lý khách hàng',
        };
    }
}
</script>
