<template>
    <context- ref="context" v-slot="{ data: { servicesDetail } }">
        <!-- <b-nav-item-icon-
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
        /> -->
        <b-nav-item-icon-mutate-
            :mutation="deleteServicesDetail"
            :variables="{ id: servicesDetail.id }"
            confirm
            icon="trash-2"
            text="Xóa chi tiết dịch vụ"
        />
    </context->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ContextMixin, DataMixin } from '~/components/mixins';
import { setIsActiveService, deleteServicesDetail } from '~/graphql/documents';

@Component({
    name: 'context-receptionist-service-detail-',
})
export default class extends mixins<ContextMixin>(
    ContextMixin,
    DataMixin({ setIsActiveService, deleteServicesDetail }),
) {}
</script>
