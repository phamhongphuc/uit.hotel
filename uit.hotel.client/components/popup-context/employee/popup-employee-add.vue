<template>
    <popup- ref="popup" v-slot="{ close }" title="Thêm nhân viên" no-data>
        <form-mutate-
            v-if="input"
            :mutation="createEmployee"
            :variables="{ input }"
            success="Thêm nhân viên mới thành công"
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
                    />
                    <div class="input-label">Mật khẩu</div>
                    <b-input-
                        v-model="input.password"
                        :state="!$v.input.password.$invalid"
                        type="password"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon="unlock"
                    />
                    <div class="input-label">Nhập lại mật khẩu</div>
                    <b-input-
                        v-model="rePassword"
                        :state="!$v.rePassword.$invalid"
                        type="password"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon="lock"
                    />
                    <div class="input-label">Vị trí</div>
                    <query-
                        v-slot="{ data: { positions } }"
                        :query="getPositions"
                        :poll-interval="0"
                        class="m-3"
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
                    <div class="input-label">Tên nhân viên</div>
                    <b-input-
                        v-model="input.name"
                        :state="!$v.input.name.$invalid"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon="type"
                    />
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
                    <div class="input-label">Địa chỉ</div>
                    <b-input-
                        v-model="input.address"
                        :state="!$v.input.address.$invalid"
                        class="m-3 rounded"
                        icon="map-pin"
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
import moment from 'moment';
import { required } from 'vuelidate/lib/validators';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { EmployeeCreateInput } from '~/graphql/types';
import { getPositions, createEmployee } from '~/graphql/documents';
import {
    address,
    birthdate,
    gender,
    id,
    identityCard,
    included,
    name,
    password,
    phoneNumber,
    rePassword,
    requiredEmail,
    startingDate,
} from '~/modules/validator';

@Component({
    name: 'popup-employee-add-',
    validations: {
        input: {
            id,
            name,
            password,
            identityCard,
            startingDate,
            gender,
            phoneNumber: { phoneNumber, required },
            address,
            email: requiredEmail,
            birthdate,
            position: included('position'),
        },
        rePassword,
    },
})
export default class PopupEmployeeAdd extends mixins<
    PopupMixin<void, EmployeeCreateInput>
>(PopupMixin, DataMixin({ createEmployee, getPositions })) {
    rePassword = '';
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
            startingDate: moment()
                .set({ hour: 0, minute: 0, second: 0 })
                .format('YYYY-MM-DD'),
            position: {
                id: -1,
            },
        };
    }
}
</script>
