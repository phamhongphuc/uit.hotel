<template>
    <popup- ref="popup" title="Cập nhật vị trí">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { position }, close }"
            :mutation="updatePosition"
            :variables="{ input: getInput }"
            success="Cập nhật vị trí mới thành công"
        >
            <div class="d-flex">
                <div>
                    <div class="input-label">Tên vị trí</div>
                    <b-input-
                        ref="autoFocus"
                        v-model="input.name"
                        :state="!$v.input.name.$invalid"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <b-checkbox-group-
                        v-model="selected"
                        :options="positionOptionsBusiness"
                        title="Nhóm quyền của nhân viên kinh doanh"
                    />
                    <b-checkbox-group-
                        v-model="selected"
                        :options="positionOptionsAdministrative"
                        title="Nhóm quyền của nhân viên hành chính"
                    />
                </div>
                <div>
                    <b-checkbox-group-
                        v-model="selected"
                        :options="positionOptionsReceptionist"
                        title="Nhóm quyền của nhân viên lễ tân"
                    />
                    <b-checkbox-group-
                        v-model="selected"
                        :options="positionOptionsHouseKeeping"
                        title="Nhóm quyền của nhân viên dọn dẹp"
                    />
                </div>
            </div>
            <div class="m-3">
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    @click="close"
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { GetPositions } from 'graphql/types';
import { Component, mixins } from 'nuxt-property-decorator';
import { PopupMixin, DataMixin } from '~/components/mixins';
import {
    updatePosition,
    positionOptionsAdministrative,
    positionOptionsBusiness,
    positionOptionsReceptionist,
    positionOptionsHouseKeeping,
} from '~/graphql/documents';
import { required } from 'vuelidate/lib/validators';
import { CheckboxOption } from '~/utils/components';

type PopupMixinType = PopupMixin<{ position: GetPositions.Positions }, any>;

@Component({
    name: 'popup-position-update-',
    validations: {
        input: {
            name: { required },
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ updatePosition }),
) {
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

    get getInput() {
        return {
            id: this.data.position.id,
            name: this.input.name,
            ...this.positionOptions,
        };
    }

    onOpen() {
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
            name: this.data.position.name,
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
