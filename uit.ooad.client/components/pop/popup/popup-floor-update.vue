<template>
    <popup- ref="popup" title="Sửa tầng">
        <form-mutate-
            slot-scope="{ data: { floor }, close }"
            success="Cập nhật thông tin tầng thành công"
            :mutation="updateFloor"
            :variables="{
                input: {
                    id: floor.id,
                    name: floorName,
                },
            }"
        >
            <div class="mt-2 mx-3 p-1 nmb-3">Tên tầng</div>
            <b-input-
                ref="autoFocus"
                v-model="floorName"
                :state="!$v.floorName.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="d-flex m-3">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
                    @click="close"
                >
                    <span class="icon"></span>
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { updateFloor } from '~/graphql/documents/floor';
import { required, minLength } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, mixinData({ updateFloor })],
    name: 'popup-floor-update-',
    validations: {
        floorName: {
            required,
            minLength: minLength(1),
        },
    },
})
export default class extends PopupMixin {
    floorName: string = '';

    onOpen() {
        this.floorName = this.data.floor.name;
    }
}
</script>
