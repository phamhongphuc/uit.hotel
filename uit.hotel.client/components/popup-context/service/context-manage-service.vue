<template>
    <context- ref="context" :refs="refs">
        <template slot-scope="{ data: { service, services }, refs }">
            <b-nav-item-icon-
                v-if="service.isActive"
                icon=""
                text="Sửa thông tin dịch vụ"
                @click="refs.service_update.open({ service })"
            />
            <b-nav-item-icon-mutate-
                :mutation="setIsActiveService"
                :variables="{ id: service.id, isActive: !service.isActive }"
                :icon="service.isActive ? '' : ''"
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
                icon=""
                text="Xóa dịch vụ"
            />
        </template>
    </context->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { ContextMixin } from '~/components/mixins/context';
import { setIsActiveService, deleteService } from '~/graphql/documents/service';
import { mixinData } from '~/components/mixins/mutable';

@Component({
    name: 'context-manage-service-',
    mixins: [ContextMixin, mixinData({ setIsActiveService, deleteService })],
})
export default class extends ContextMixin {}
</script>
