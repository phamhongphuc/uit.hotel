<template>
    <popup- ref="popup" title="Thêm tầng" no-data="true">
        <form-mutate-
            slot-scope="{ data, close }"
            success="Thêm tầng mới thành công"
            :mutation="createFloor"
            :variables="{
                input: {
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
import { required, minLength } from 'vuelidate/lib/validators';

@Component({
    mixins: [PopupMixin, mixinData({ createFloor })],
    name: 'popup-add-floor-',
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
        this.floorName = '';
    }
}
</script>
