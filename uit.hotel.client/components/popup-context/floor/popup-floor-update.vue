<template>
    <popup- ref="popup" title="Sửa tầng">
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            :mutation="updateFloor"
            :variables="{ input }"
            success="Cập nhật thông tin tầng thành công"
            @success="close"
        >
            <div class="input-label">Tên tầng</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon="type"
            />
            <div class="d-flex m-3">
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    type="submit"
                >
                    <icon- class="mr-1" i="edit-2" />
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { FloorUpdateInput, GetFloors } from 'graphql/types';
import { Component, mixins } from 'nuxt-property-decorator';
import { DataMixin, PopupMixin } from '~/components/mixins';
import { updateFloor } from '~/graphql/documents';
import { required, minLength } from 'vuelidate/lib/validators';

type PopupMixinType = PopupMixin<{ floor: GetFloors.Floors }, FloorUpdateInput>;

@Component({
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
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ updateFloor }),
) {
    onOpen() {
        this.input = {
            id: this.data.floor.id,
            name: this.data.floor.name,
        };
    }
}
</script>
