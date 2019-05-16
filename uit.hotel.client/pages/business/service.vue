<template>
    <div @contextmenu.prevent="tableContext">
        <block-flex->
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.service_add.open()"
            >
                <icon- class="mr-1" i="plus" />
                <span>Thêm dịch vụ mới</span>
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
                        } dịch vụ đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </block-flex->
        <query-
            :query="getServices"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { services } }"
                :items="servicesFilter(services)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                        sortable: true,
                    },
                    {
                        key: 'name',
                        label: 'Tên dịch vụ',
                        tdClass: (value, key, row) => {
                            if (!row.isActive)
                                return 'table-cell-disable w-100';
                            return 'w-100';
                        },
                        sortable: true,
                    },
                    {
                        key: 'unitRate',
                        label: 'Đơn giá',
                        tdClass: 'text-nowrap text-center',
                        sortable: true,
                    },
                    {
                        key: 'servicesDetails',
                        label: 'Đã sử dụng',
                        tdClass: 'text-nowrap text-center',
                        sortable: true,
                    },
                ]"
                class="table-style"
                @row-clicked="
                    (service, $index, $event) => {
                        $event.stopPropagation();
                        $refs.context_service.open(currentEvent || $event, {
                            service,
                            services,
                        });
                        currentEvent = null;
                    }
                "
            >
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <template
                    slot="unitRate"
                    slot-scope="{ item: { unitRate, unit } }"
                >
                    {{ toMoney(unitRate) }} / {{ unit }}
                </template>
                <template
                    slot="servicesDetails"
                    slot-scope="{ value, item: { unit } }"
                >
                    {{ value.length }} {{ unit }}
                </template>
            </b-table>
        </query->
        <context-manage-service- ref="context_service" :refs="$refs" />
        <popup-service-add- ref="service_add" />
        <popup-service-update- ref="service_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getServices } from '~/graphql/documents';
import { DataMixin } from '~/components/mixins';
import { GetServices } from '~/graphql/types';
import { toMoney } from '~/utils';

@Component({
    name: 'service-',
})
export default class extends mixins(DataMixin({ getServices, toMoney })) {
    head() {
        return {
            title: 'Quản lý dịch vụ',
        };
    }

    servicesFilter(services: GetServices.Services[]): GetServices.Services[] {
        if (this.showInactive) return services;
        return services.filter(rk => rk.isActive);
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
