<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { employee }, refs }">
            <b-nav-item-icon-
                v-if="employee.isActive"
                icon="edit-2"
                text="Sửa thông tin nhân viên"
                @click="refs.employee_update.open({ employee })"
            />
            <b-nav-item-icon-mutate-
                :mutation="setIsActiveAccount"
                :variables="{ id: employee.id, isActive: !employee.isActive }"
                :icon="employee.isActive ? '' : ''"
                :text="
                    employee.isActive
                        ? 'Vô hiệu hóa nhân viên'
                        : 'Kích hoạt lại nhân viên'
                "
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import { setIsActiveAccount } from '~/graphql/documents/employee';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    name: 'context-manage-employee-',
    mixins: [ContextMixin, mixinData({ setIsActiveAccount })],
})
export default class extends ContextMixin {}
</script>
