<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.patron_add.open()"
            >
                <icon- class="mr-1" i="plus" />
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
                class="table-style"
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
                    <a
                        v-for="phoneNumber in value"
                        :key="phoneNumber"
                        :href="`tel:${phoneNumber}`"
                        class="d-block"
                        @click.stop
                    >
                        {{ phoneNumber }}
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
        <context-manage-patron- ref="context_patron" :refs="$refs" />
        <popup-patron-add- ref="patron_add" />
        <popup-patron-update- ref="patron_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getPatrons } from '~/graphql/documents';
import { DataMixin } from '~/components/mixins';
import { toYear } from '~/utils';

@Component({
    name: 'patron-',
})
export default class extends mixins(DataMixin({ getPatrons, toYear })) {
    head() {
        return {
            title: 'Quản lý khách hàng',
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
}
</script>
