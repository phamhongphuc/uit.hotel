<template>
    <popup- ref="popup" title="Cập nhật vị trí">
        <form-mutate-
            slot-scope="{ data: { employee }, close }"
            success="Cập nhật vị trí mới thành công"
            :mutation="updateEmployee"
            :variables="{
                input,
            }"
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
                        icon=""
                        disabled
                    />
                    <div class="input-label">Tên nhân viên</div>
                    <b-input-
                        v-model="input.name"
                        :state="!$v.input.name.$invalid"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon=""
                    />
                    <div class="input-label">Vị trí</div>
                    <query-
                        :query="getPositions"
                        class="m-3"
                        :poll-interval="0"
                    >
                        <div slot-scope="{ data: { positions } }">
                            <b-form-select
                                v-model="input.position.id"
                                value-field="id"
                                text-field="name"
                                :state="!$v.input.position.id.$invalid"
                                :options="positions"
                                class="rounded"
                            />
                        </div>
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
                                icon=""
                            />
                            <div class="input-label">Giới tính</div>
                            <div class="m-3">
                                <b-form-select
                                    v-model="input.gender"
                                    value-field="value"
                                    text-field="name"
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
                                    class="rounded"
                                />
                            </div>
                            <div class="input-label">Ngày sinh</div>
                            <b-input-
                                v-model="input.birthdate"
                                :state="!$v.input.birthdate.$invalid"
                                type="date"
                                class="m-3 rounded"
                                icon=""
                            />
                        </div>
                        <div>
                            <div class="input-label">Số điện thoại</div>
                            <b-input-
                                v-model="input.phoneNumber"
                                :state="!$v.input.phoneNumber.$invalid"
                                class="m-3 rounded"
                                icon=""
                            />
                            <div class="input-label">Thư điện tử</div>
                            <b-input-
                                v-model="input.email"
                                :state="!$v.input.email.$invalid"
                                class="m-3 rounded"
                                icon=""
                            />
                            <div class="input-label">Ngày bắt đầu</div>
                            <b-input-
                                v-model="input.startingDate"
                                :state="!$v.input.startingDate.$invalid"
                                type="date"
                                class="m-3 rounded"
                                icon=""
                            />
                        </div>
                    </div>
                    <div class="input-label">Địa chỉ</div>
                    <b-input-
                        v-model="input.address"
                        :state="!$v.input.address.$invalid"
                        class="m-3 rounded"
                        icon=""
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
import { updateEmployee } from '~/graphql/documents/employee';
import { getPositions } from '~/graphql/documents/position';
import { mixinData } from '~/components/mixins/mutable';
import { required, email, alphaNum } from 'vuelidate/lib/validators';
import { EmployeeUpdateInput, GetEmployees } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ updateEmployee, getPositions })],
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
export default class extends PopupMixin<
    { employee: GetEmployees.Employees },
    EmployeeUpdateInput
> {
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
