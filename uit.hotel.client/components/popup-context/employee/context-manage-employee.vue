<template>
    <context- ref="context" v-slot="{ data: { employee } }">
        <b-nav-item-icon-
            icon="info"
            text="Chi tiết nhân viên"
            @click="refs.employee_detail.open({ id: employee.id })"
        />
        <b-nav-item-icon-
            v-if="employee.isActive"
            icon="edit-2"
            text="Sửa thông tin nhân viên"
            @click="refs.employee_update.open({ id: employee.id })"
        />
        <b-nav-item-icon-mutate-
            :mutation="setIsActiveAccount"
            :variables="{ id: employee.id, isActive: !employee.isActive }"
            :icon="employee.isActive ? 'x' : 'chevrons-up'"
            :text="
                employee.isActive
                    ? 'Vô hiệu hóa nhân viên'
                    : 'Kích hoạt lại nhân viên'
            "
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { setIsActiveAccount } from '~/graphql/documents';

@Component({
    name: 'context-manage-employee-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ setIsActiveAccount }),
) {}
</script>
