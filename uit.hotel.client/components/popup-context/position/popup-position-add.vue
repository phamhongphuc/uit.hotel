<template>
    <popup- ref="popup" v-slot="{ close }" title="Thêm vị trí" no-data>
        <form-mutate-
            v-if="input"
            :mutation="createPosition"
            :variables="{ input, getInput }"
            success="Thêm vị trí mới thành công"
            @success="close"
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
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { PopupMixin, DataMixin } from '~/components/mixins';
import {
    createPosition,
    positionOptionsAdministrative,
    positionOptionsBusiness,
    positionOptionsReceptionist,
    positionOptionsHouseKeeping,
} from '~/graphql/documents';
import { CheckboxOption } from '~/utils';
import { positionName } from '~/modules/validator';

@Component({
    name: 'popup-position-add-',
    validations: {
        input: {
            name: positionName,
        },
    },
})
export default class extends mixins<PopupMixin<void, any>>(
    PopupMixin,
    DataMixin({ createPosition }),
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
            name: this.input.name,
            ...this.positionOptions,
        };
    }

    onOpen() {
        this.selected = [];
        this.input = {
            name: '',
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
