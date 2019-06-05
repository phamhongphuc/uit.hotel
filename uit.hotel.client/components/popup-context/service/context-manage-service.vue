<template>
    <context- ref="context" v-slot="{ data: { service, services } }">
        <b-nav-item-icon-
            v-if="service.isActive"
            icon="edit-2"
            text="Sửa thông tin dịch vụ"
            @click="refs.service_update.open({ service })"
        />
        <b-nav-item-icon-mutate-
            :mutation="setIsActiveService"
            :variables="{ id: service.id, isActive: !service.isActive }"
            :icon="service.isActive ? 'x' : 'chevrons-up'"
            :text="
                service.isActive
                    ? 'Vô hiệu hóa dịch vụ'
                    : 'Kích hoạt lại dịch vụ'
            "
        />
        <b-nav-item-icon-mutate-
            v-if="service.isActive"
            :mutation="deleteService"
            :variables="{ id: service.id }"
            icon="trash-2"
            text="Xóa dịch vụ"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { setIsActiveService, deleteService } from '~/graphql/documents';

@Component({
    name: 'context-manage-service-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ setIsActiveService, deleteService }),
) {}
</script>
