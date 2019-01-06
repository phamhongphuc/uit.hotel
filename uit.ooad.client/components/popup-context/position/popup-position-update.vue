<template>
    <popup- ref="popup" title="Cập nhật vị trí">
        <form-mutate-
            slot-scope="{ data: { position }, close }"
            success="Cập nhật vị trí mới thành công"
            :mutation="updatePosition"
            :variables="{
                input,
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
                    <b-checkbox-group-
                        v-model="selected"
                        title="Nhóm quyền của nhân viên kinh doanh"
                        :options="positionOptionsBusiness"
                    />
                    <b-checkbox-group-
                        v-model="selected"
                        title="Nhóm quyền của nhân viên hành chính"
                        :options="positionOptionsAdministrative"
                    />
                </div>
                <div>
                    <b-checkbox-group-
                        v-model="selected"
                        title="Nhóm quyền của nhân viên lễ tân"
                        :options="positionOptionsReceptionist"
                    />
                    <b-checkbox-group-
                        v-model="selected"
                        title="Nhóm quyền của nhân viên dọn dẹp"
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
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { PopupMixin } from '~/components/mixins/popup';
import {
    updatePosition,
    positionOptionsAdministrative,
    positionOptionsBusiness,
    positionOptionsReceptionist,
    positionOptionsHouseKeeping,
} from '~/graphql/documents/position';
import { mixinData } from '~/components/mixins/mutable';
import { required } from 'vuelidate/lib/validators';
import { CheckboxOption } from '~/utils/components';
import { GetPositions } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ updatePosition })],
    name: 'popup-position-update-',
    validations: {
        positionName: {
            required,
        },
    },
})
export default class extends PopupMixin<
    { position: GetPositions.Positions },
    any
> {
    positionName: string = '';

    selected: string[] = [];

    positionOptionsAdministrative: CheckboxOption[] = [];
    positionOptionsBusiness: CheckboxOption[] = [];
    positionOptionsReceptionist: CheckboxOption[] = [];
    positionOptionsHouseKeeping: CheckboxOption[] = [];

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
        this.positionName = this.data.position.name;

        const permission = [
            ...positionOptionsAdministrative,
            ...positionOptionsBusiness,
            ...positionOptionsReceptionist,
            ...positionOptionsHouseKeeping,
        ].map(p => p.value);
        this.selected = [];
        permission.forEach(p => {
            if (this.data.position[p]) this.selected.push(p);
        });

        this.input = {
            id: this.data.position.id,
            name: this.positionName,
            ...this.positionOptions,
        };
    }

    toggleAll(checked: boolean, options: CheckboxOption[]) {
        function addUnique(array: string[], add: string[]) {
            const a = array.concat();
            add.forEach(e => {
                if (a.indexOf(e) === -1) a.push(e);
            });
            return a;
        }
        function removeUnique(array: string[], sub: string[]) {
            const a = array.concat();
            sub.forEach(e => {
                const index = a.indexOf(e);
                if (index !== -1) a.splice(index, 1);
            });
            return a;
        }

        const optionsList = options.map(option => option.value);

        if (checked) {
            this.selected = addUnique(this.selected, optionsList);
        } else {
            this.selected = removeUnique(this.selected, optionsList);
        }
    }
}
</script>
