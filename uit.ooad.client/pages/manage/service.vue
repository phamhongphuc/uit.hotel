<template>
    <div @contextmenu.prevent="tableContext">
        <div class="row">
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.service_add.open()"
            >
                <span class="icon"></span>
                <span>Thêm dịch vụ mới</span>
            </b-button>
            <b-button
                class="m-2 ml-auto"
                variant="white"
                @click="showInactive = !showInactive"
            >
                <span class="icon mr-1">{{ showInactive ? '' : '' }}</span>
                <span>
                    {{
                        `Đang ${
                            showInactive ? 'hiện' : 'ẩn'
                        } dịch vụ đã bị vô hiệu hóa`
                    }}
                </span>
            </b-button>
        </div>
        <query-
            :query="getServices"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { services } }"
                class="table-style"
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
                    {{
                        unitRate.toLocaleString('vi', {
                            style: 'currency',
                            currency: 'VND',
                        })
                    }}
                    / {{ unit }}
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
import { Vue, Component } from 'nuxt-property-decorator';
import { getServices } from '~/graphql/documents/service';
import { mixinData } from '~/components/mixins/mutable';
import { GetServices } from '~/graphql/types';

@Component({
    name: 'service-',
    mixins: [mixinData({ getServices })],
})
export default class extends Vue {
    head() {
        return {
            title: 'Sơ đồ khách sạn',
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
