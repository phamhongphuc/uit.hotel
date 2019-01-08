<template>
    <popup- ref="popup" title="Sửa tầng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { floor }, close }"
            success="Cập nhật thông tin tầng thành công"
            :mutation="updateFloor"
            :variables="{ input }"
        >
            <div class="input-label">Tên tầng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
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
                    <span class="icon mr-1"></span>
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
import { FloorUpdateInput, GetFloors } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ updateFloor })],
    name: 'popup-floor-update-',
    validations: {
        input: {
            name: {
                required,
                minLength: minLength(1),
            },
        },
    },
})
export default class extends PopupMixin<
    { floor: GetFloors.Floors },
    FloorUpdateInput
> {
    onOpen() {
        this.input = {
            id: this.data.floor.id,
            name: this.data.floor.name,
        };
    }
}
</script>
