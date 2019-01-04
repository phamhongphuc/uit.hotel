<template>
    <popup- ref="popup" title="Thêm vị trí" no-data="true">
        <form-mutate-
            slot-scope="{ close }"
            success="Thêm vị trí mới thành công"
            :mutation="createPosition"
            :variables="{
                input: input,
            }"
        >
            <div class="d-flex">
                <div>
                    <div class="input-label">Tên vị trí</div>
                    <b-input-
                        ref="autoFocus"
                        v-model="positionName"
                        :state="!$v.positionName.$invalid"
                        class="m-3 rounded"
                        icon=""
                    />
                    <div class="input-label">
                        Nhóm quyền của nhân viên kinh doanh
                    </div>
                    <b-form-checkbox-group
                        v-model="selected"
                        class="h-auto m-3"
                        stacked
                        size="sm"
                        button-variant="white"
                        :options="positionOptionsBusiness"
                    />
                    <div class="input-label">
                        Nhóm quyền của nhân viên hành chính
                    </div>
                    <b-form-checkbox-group
                        v-model="selected"
                        class="h-auto m-3"
                        stacked
                        size="sm"
                        button-variant="white"
                        :options="positionOptionsAdministrative"
                    />
                </div>
                <div>
                    <div class="input-label">
                        Nhóm quyền của nhân viên lễ tân
                    </div>
                    <b-form-checkbox-group
                        v-model="selected"
                        class="h-auto m-3"
                        stacked
                        size="sm"
                        button-variant="white"
                        :options="positionOptionsReceptionist"
                    />
                    <div class="input-label">
                        Nhóm quyền của nhân viên dọn dẹp
                    </div>
                    <b-form-checkbox-group
                        v-model="selected"
                        class="h-auto m-3"
                        stacked
                        size="sm"
                        button-variant="white"
                        :options="positionOptionsHouseKeeping"
                    />
                </div>
            </div>
            <div class="m-3">
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
import { PopupMixin } from '~/components/mixins/popup';
import {
    createPosition,
    positionOptionsAdministrative,
    positionOptionsBusiness,
    positionOptionsReceptionist,
    positionOptionsHouseKeeping,
} from '~/graphql/documents/position';
import { mixinData } from '~/components/mixins/mutable';
import { required } from 'vuelidate/lib/validators';
import { CheckboxOption } from '~/utils/components';

@Component({
    mixins: [PopupMixin, mixinData({ createPosition })],
    name: 'popup-position-add-',
    validations: {
        positionName: {
            required,
        },
    },
})
export default class extends PopupMixin {
    positionName: string = '';

    selected: string[] = [];

    positionOptionsAdministrative: CheckboxOption[] = [];
    positionOptionsBusiness: CheckboxOption[] = [];
    positionOptionsReceptionist: CheckboxOption[] = [];
    positionOptionsHouseKeeping: CheckboxOption[] = [];

    get input() {
        return {
            name: this.positionName,
            ...this.positionOptions,
        };
    }

    mounted() {
        this.positionOptionsAdministrative = positionOptionsAdministrative;
        this.positionOptionsBusiness = positionOptionsBusiness;
        this.positionOptionsReceptionist = positionOptionsReceptionist;
        this.positionOptionsHouseKeeping = positionOptionsHouseKeeping;
    }

    get positionOptions() {
        const options = {};

        const eachOption = option => {
            options[option.value] = this.selected.indexOf(option.value) !== -1;
        };
        this.positionOptionsAdministrative.forEach(eachOption);
        this.positionOptionsBusiness.forEach(eachOption);
        this.positionOptionsReceptionist.forEach(eachOption);
        this.positionOptionsHouseKeeping.forEach(eachOption);

        return options;
    }

    onOpen() {
        this.positionName = '';
        this.selected = [];
    }
}
</script>
