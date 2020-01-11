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
                show-empty
                :items="servicesFilter(services)"
                :fields="[
                    {
                        key: 'index',
                        label: '#',
                        class: 'table-cell-id text-center',
                    },
                    {
                        key: 'name',
                        label: 'Tên dịch vụ',
                        tdClass: (value, key, row) =>
                            !row.isActive && 'table-cell-disable',
                        sortable: true,
                    },
                    {
                        key: 'unitPrice',
                        label: 'Đơn giá',
                        tdClass: 'text-center',
                        sortable: true,
                    },
                    {
                        key: 'servicesDetails',
                        label: 'Đã sử dụng',
                        tdClass: 'text-center',
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
                <template v-slot:empty>
                    Không tìm thấy dịch vụ nào
                </template>
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
        </query->
        <context-manage-service- ref="context_service" />
        <popup-service-add- ref="service_add" />
        <popup-service-update- ref="service_update" />
    </div>
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { getServices } from '~/graphql/documents';
import { DataMixin, Page } from '~/components/mixins';
import { GetServices } from '~/graphql/types';
import { toMoney } from '~/utils';

@Component({
    name: 'service-',
})
export default class extends mixins<Page, {}>(
    Page,
    DataMixin({ getServices, toMoney }),
) {
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
        return servicesDetails.reduce((output, servicesDetail) => {
            return output + servicesDetail.number;
        }, 0);
    }

    showInactive = false;
}
</script>
