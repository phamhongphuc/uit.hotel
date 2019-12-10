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
            v-slot="{ data: { services } }"
            :query="getServices"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
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
                        key: 'unitPrice',
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
                class="table-style table-header-line"
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
                <template v-slot:cell(index)="data">
                    {{ data.index + 1 }}
                </template>
                <template
                    v-slot:cell(unitPrice)="{ item: { unitPrice, unit } }"
                >
                    {{ toMoney(unitPrice) }} / {{ unit }}
                </template>
                <template
                    v-slot:cell(servicesDetails)="{ value, item: { unit } }"
                >
                    {{ servicesDetailsCount(value) }} {{ unit }}
                </template>
            </b-table>
            <div
                v-if="servicesFilter(services).length === 0"
                class="table-after"
            >
                Không tìm thấy dịch vụ nào
            </div>
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

    servicesDetailsCount(servicesDetails: GetServices.ServicesDetails[]) {
        return servicesDetails.reduce((output, current) => {
            return output + current.number;
        }, 0);
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
