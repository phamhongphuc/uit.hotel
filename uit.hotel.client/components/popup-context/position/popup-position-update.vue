<template>
    <popup- ref="popup" v-slot="{ close }" title="Cập nhật vị trí">
        <form-mutate-
            v-if="input"
            :mutation="updatePosition"
            :variables="{ input: getInput }"
            success="Cập nhật vị trí mới thành công"
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
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { GetPositions } from '~/graphql/types';
import { updatePosition } from '~/graphql/documents';
import {
    positionOptionsAdministrative,
    positionOptionsBusiness,
    positionOptionsReceptionist,
    positionOptionsHouseKeeping,
    permission,
} from '~/modules/model';
import { CheckboxOption } from '~/utils';
import { positionName } from '~/modules/validator';

type PopupMixinType = PopupMixin<{ position: GetPositions.Positions }, any>;

@Component({
    name: 'popup-position-update-',
    validations: {
        input: {
            name: positionName,
        },
    },
})
export default class extends mixins<
    PopupMixinType,
    {
        positionOptionsAdministrative: CheckboxOption[];
        positionOptionsBusiness: CheckboxOption[];
        positionOptionsReceptionist: CheckboxOption[];
        positionOptionsHouseKeeping: CheckboxOption[];
    }
>(
    PopupMixin,
    DataMixin({
        updatePosition,
        positionOptionsAdministrative,
        positionOptionsBusiness,
        positionOptionsReceptionist,
        positionOptionsHouseKeeping,
    }),
) {
    selected: string[] = [];

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
        this.selected = [];
        permission.forEach(p => this.data.position[p] && this.selected.push(p));

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
