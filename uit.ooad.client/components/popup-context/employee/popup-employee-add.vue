<template>
    <popup- ref="popup" title="Thêm nhân viên" no-data>
        <form-mutate-
            v-if="input"
            slot-scope="{ close }"
            success="Thêm nhân viên mới thành công"
            :mutation="createEmployee"
            :variables="{ input }"
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
                    />
                    <div class="input-label">Mật khẩu</div>
                    <b-input-
                        v-model="input.password"
                        type="password"
                        :state="!$v.input.password.$invalid"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon=""
                    />
                    <div class="input-label">Nhập lại mật khẩu</div>
                    <b-input-
                        v-model="rePassword"
                        type="password"
                        :state="!$v.rePassword.$invalid"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon=""
                    />
                    <div class="input-label">Vị trí</div>
                    <query-
                        :query="getPositions"
                        class="m-3"
                        :poll-interval="0"
                    >
                        <b-form-select
                            v-model="input.position.id"
                            slot-scope="{ data: { positions } }"
                            value-field="id"
                            text-field="name"
                            :state="!$v.input.position.id.$invalid"
                            :options="positions"
                            class="rounded"
                        />
                    </query->
                </div>
                <div>
                    <div class="input-label">Tên nhân viên</div>
                    <b-input-
                        v-model="input.name"
                        :state="!$v.input.name.$invalid"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon=""
                    />
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
                    <div class="input-label">Địa chỉ</div>
                    <b-input-
                        v-model="input.address"
                        :state="!$v.input.address.$invalid"
                        class="m-3 rounded"
                        icon=""
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
            <div class="m-3">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
                    @click="close"
                >
                    <span class="icon mr-1"></span>
                    <span>Thêm</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { PopupMixin } from '~/components/mixins/popup';
import { getPositions } from '~/graphql/documents/position';
import { createEmployee } from '~/graphql/documents/employee';
import { mixinData } from '~/components/mixins/mutable';
import { required, email, alphaNum } from 'vuelidate/lib/validators';
import { EmployeeCreateInput } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ createEmployee, getPositions })],
    name: 'popup-employee-add-',
    validations: {
        input: {
            id: { required },
            name: { required },
            password: { required },
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
        rePassword: {
            required,
            equalPassword(value) {
                return value === this.input.password;
            },
        },
    },
})
export default class extends PopupMixin<void, EmployeeCreateInput> {
    input: EmployeeCreateInput | null = null;
    rePassword: string = '';

    onOpen() {
        this.input = {
            id: '',
            password: '',
            name: '',
            identityCard: '',
            phoneNumber: '',
            address: '',
            email: '',
            birthdate: '',
            gender: true,
            startingDate: '',
            position: {
                id: 1,
            },
        };
    }
}
</script>
