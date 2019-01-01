<template>
    <popup- ref="popup" title="Thêm tầng" no-data="true">
        <form-mutate-
            slot-scope="{ data, close }"
            success="Thêm tầng mới thành công"
            :mutation="createFloor"
            :variables="{
                input: {
                    name: floorName,
                    isActive: true,
                },
            }"
        >
            <div class="mt-2 mx-3 p-1 nmb-3">Tên tầng</div>
            <b-input-
                ref="autoFocus"
                v-model="floorName"
                class="m-3 rounded"
                icon=""
            />
            <div class="d-flex m-3">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    @click="close"
                >
                    <span class="icon"></span>
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { createFloor } from '~/graphql/documents/floor-room';

@Component({
    mixins: [PopupMixin, mixinData({ createFloor })],
    name: 'popup-add-floor-',
})
export default class extends PopupMixin {
    floorName: string = '';

    onOpen() {
        this.floorName = '';
    }
}
</script>
