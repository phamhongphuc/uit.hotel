<template>
    <popup- ref="popup" v-slot="{ close }" title="Cập nhật thông tin nhân viên">
        <query-
            v-slot
            :query="getEmployee"
            :variables="{ id: data.id }"
            :poll-interval="0"
            @result="onResult"
        >
            <form-mutate-
                v-if="input"
                :mutation="updateEmployee"
                :variables="{ input }"
                success="Cập nhật thông tin nhân viên mới thành công"
                @success="close"
            >
                <div class="d-flex">
                    <div>
                        <div class="input-label">Tên đăng nhập</div>
                        <b-input-
                            ref="autoFocus"
                            v-model="input.id"
                            :state="!$v.input.id.$invalid"
                            autocomplete="new-password"
                            class="m-3 rounded"
                            icon="at-sign"
                            disabled
                        />
                        <div class="input-label">Tên nhân viên</div>
                        <b-input-
                            v-model="input.name"
                            :state="!$v.input.name.$invalid"
                            autocomplete="new-password"
                            class="m-3 rounded"
                            icon="type"
                        />
                        <div class="input-label">Vị trí</div>
                        <query-
                            v-slot="{ data: { positions } }"
                            :query="getPositions"
                            :poll-interval="0"
                            class="m-3"
                            @result="refresh(input.position)"
                        >
                            <b-form-select
                                ref="position"
                                v-model="input.position.id"
                                :state="!$v.input.position.id.$invalid"
                                :options="positions"
                                value-field="id"
                                text-field="name"
                                class="rounded"
                            />
                        </query->
                    </div>
                    <div>
                        <div class="d-flex">
                            <div>
                                <div class="input-label">
                                    Chứng minh nhân dân
                                </div>
                                <b-input-
                                    v-model="input.identityCard"
                                    :state="!$v.input.identityCard.$invalid"
                                    class="m-3 rounded"
                                    icon="package"
                                />
                                <div class="input-label">Giới tính</div>
                                <div class="m-3">
                                    <b-form-select
                                        v-model="input.gender"
                                        :state="!$v.input.gender.$invalid"
                                        :options="[
                                            {
                                                name: 'Nam',
                                                value: true,
                                            },
                                            {
                                                name: 'Nữ',
                                                value: false,
                                            },
                                        ]"
                                        value-field="value"
                                        text-field="name"
                                        class="rounded"
                                    />
                                </div>
                                <div class="input-label">Ngày sinh</div>
                                <b-input-
                                    v-model="input.birthdate"
                                    :state="!$v.input.birthdate.$invalid"
                                    type="date"
                                    class="m-3 rounded"
                                    icon="calendar"
                                />
                            </div>
                            <div>
                                <div class="input-label">Số điện thoại</div>
                                <b-input-
                                    v-model="input.phoneNumber"
                                    :state="!$v.input.phoneNumber.$invalid"
                                    class="m-3 rounded"
                                    icon="phone"
                                />
                                <div class="input-label">Thư điện tử</div>
                                <b-input-
                                    v-model="input.email"
                                    :state="!$v.input.email.$invalid"
                                    class="m-3 rounded"
                                    icon="mail"
                                />
                                <div class="input-label">Ngày bắt đầu</div>
                                <b-input-
                                    v-model="input.startingDate"
                                    :state="!$v.input.startingDate.$invalid"
                                    type="date"
                                    class="m-3 rounded"
                                    icon="calendar"
                                />
                            </div>
                        </div>
                        <div class="input-label">Địa chỉ</div>
                        <b-input-
                            v-model="input.address"
                            :state="!$v.input.address.$invalid"
                            class="m-3 rounded"
                            icon="map-pin"
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
        </query->
    </popup->
</template>
<script lang="ts">
import { Component, mixins, Vue } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { required } from 'vuelidate/lib/validators';
import {
    EmployeeUpdateInput,
    GetEmployeeQuery,
    GetEmployee,
} from '~/graphql/types';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { updateEmployee, getPositions, getEmployee } from '~/graphql/documents';
import { toInputDate } from '~/utils';
import {
    address,
    birthdate,
    gender,
    id,
    identityCard,
    included,
    name,
    phoneNumber,
    requiredEmail,
    startingDate,
    refresh,
} from '~/modules/validator';

type PopupMixinType = PopupMixin<{ id: number }, EmployeeUpdateInput>;

@Component({
    name: 'popup-employee-update-',
    validations: {
        input: {
            id,
            name,
            identityCard,
            startingDate,
            gender,
            phoneNumber: { phoneNumber, required },
            address,
            email: requiredEmail,
            birthdate,
            position: included('position'),
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ updateEmployee, getPositions, getEmployee, refresh }),
) {
    employee!: GetEmployee.Employee;

    async onResult({
        data: { employee },
    }: ApolloQueryResult<GetEmployeeQuery>) {
        await Vue.nextTick();
        this.employee = employee;
        const {
            id,
            name,
            identityCard,
            phoneNumber,
            address,
            email,
            birthdate,
            gender,
            startingDate,
            position,
        } = employee;
        this.input = {
            id,
            name,
            identityCard,
            phoneNumber,
            address,
            email,
            birthdate: toInputDate(birthdate),
            gender,
            startingDate: toInputDate(startingDate),
            position: { id: position.id },
        };
        this.$v.$touch();
    }
}
</script>
