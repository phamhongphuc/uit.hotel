<template>
    <popup- ref="popup" title="Cập nhật vị trí">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { employee }, close }"
            :mutation="updateEmployee"
            :variables="{ input }"
            success="Cập nhật vị trí mới thành công"
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
                        :query="getPositions"
                        :poll-interval="0"
                        class="m-3"
                    >
                        <b-form-select
                            v-model="input.position.id"
                            slot-scope="{ data: { positions } }"
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
                            <div class="input-label">Chứng minh nhân dân</div>
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
import { EmployeeUpdateInput, GetEmployees } from 'graphql/types';
import { Component, mixins } from 'nuxt-property-decorator';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { updateEmployee, getPositions } from '~/graphql/documents';
import { required, email, alphaNum } from 'vuelidate/lib/validators';

type PopupMixinType = PopupMixin<
    { employee: GetEmployees.Employees },
    EmployeeUpdateInput
>;

@Component({
    name: 'popup-employee-update-',
    validations: {
        input: {
            id: { required },
            name: { required },
            identityCard: { required, alphaNum },
            startingDate: { required },
            gender: { required },
            phoneNumber: { required, alphaNum },
            address: { required },
            email: { required, email },
            birthdate: { required },

            position: {
                id: { required },
            },
        },
    },
})
export default class extends mixins<PopupMixinType>(
    PopupMixin,
    DataMixin({ updateEmployee, getPositions }),
) {
    onOpen() {
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
        } = this.data.employee;

        this.input = {
            id,
            name,
            identityCard,
            phoneNumber,
            address,
            email,
            birthdate,
            gender,
            startingDate,
            position: {
                id: position.id,
            },
        };
    }
}
</script>
