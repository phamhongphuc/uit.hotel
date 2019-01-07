<template>
    <div @contextmenu.prevent="tableContext">
        <div class="row">
            <b-button
                class="m-2"
                variant="white"
                @click="$refs.patron_add.open()"
            >
                <span class="icon mr-1"></span>
                <span>Thêm khách hàng mới</span>
            </b-button>
        </div>
        <query-
            :query="getPatrons"
            class="row"
            child-class="col m-2 p-0 bg-white rounded shadow-sm overflow-auto"
        >
            <b-table
                slot-scope="{ data: { patrons } }"
                class="table-style"
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
                <template slot="index" slot-scope="data">
                    {{ data.index + 1 }}
                </template>
                <template slot="phoneNumbers" slot-scope="{ value }">
                    <a
                        v-for="phoneNumber in value"
                        :key="phoneNumber"
                        class="d-block"
                        :href="`tel:${phoneNumber}`"
                        @click.stop
                    >
                        {{ phoneNumber }}
                    </a>
                </template>
                <template slot="birthdate" slot-scope="{ value }">
                    {{ toYear(value) }}
                </template>
            </b-table>
        </query->
        <context-manage-patron- ref="context_patron" :refs="$refs" />
        <popup-patron-add- ref="patron_add" />
        <popup-patron-update- ref="patron_update" />
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getPatrons } from '~/graphql/documents/patron';
import { mixinData } from '~/components/mixins/mutable';
import moment from 'moment';

@Component({
    name: 'patron-',
    mixins: [mixinData({ getPatrons })],
})
export default class extends Vue {
    head() {
        return {
            title: 'Sơ đồ khách sạn',
        };
    }

    tableContext(event: MouseEvent) {
        const tr = (event.target as HTMLElement).closest('tr');
        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }

    toYear(date: string) {
        return moment(date).year();
    }

    currentEvent: MouseEvent | null = null;

    showInactive: boolean = false;

    console = console;
}
</script>
