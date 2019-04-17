<template>
    <popup- ref="popup" title="Cập nhật khách hàng">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { patron }, close }"
            success="Cập nhật khách hàng thành công"
            :mutation="updatePatron"
            :variables="{ input }"
        >
            <div class="d-flex">
                <div>
                    <div class="input-label">Tên khách hàng</div>
                    <b-input-
                        v-model="input.name"
                        :state="!$v.input.name.$invalid"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon=""
                    />
                    <div class="input-label">Chứng minh nhân dân</div>
                    <b-input-
                        v-model="input.identification"
                        :state="!$v.input.identification.$invalid"
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
                    <div class="input-label">Loại khách hàng</div>
                    <query-
                        :query="getPatronKinds"
                        class="m-3"
                        :poll-interval="0"
                    >
                        <b-form-select
                            v-model="input.patronKind.id"
                            slot-scope="{ data: { patronKinds } }"
                            value-field="id"
                            text-field="name"
                            :state="!$v.input.patronKind.id.$invalid"
                            :options="patronKinds"
                            class="rounded"
                        />
                    </query->
                </div>
                <div>
                    <div class="input-label">Ngày sinh</div>
                    <b-input-
                        v-model="input.birthdate"
                        :state="!$v.input.birthdate.$invalid"
                        type="date"
                        class="m-3 rounded"
                        icon=""
                    />
                    <div class="input-label">Số điện thoại</div>
                    <b-input-
                        v-model="phoneNumbers"
                        :state="!$v.input.listOfPhoneNumbers.$invalid"
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
                    <div class="input-label">Công ty</div>
                    <b-input-
                        v-model="input.company"
                        :state="!$v.input.company.$invalid"
                        class="m-3 rounded"
                        icon=""
                    />
                </div>
                <div>
                    <div class="input-label">Quốc tịch</div>
                    <b-input-
                        v-model="input.nationality"
                        :state="!$v.input.nationality.$invalid"
                        class="m-3 rounded"
                        icon=""
                    />
                    <div class="input-label">Nguyên quán</div>
                    <b-input-
                        v-model="input.domicile"
                        :state="!$v.input.domicile.$invalid"
                        class="m-3 rounded"
                        icon=""
                    />
                    <div class="input-label">Địa chỉ thường trú</div>
                    <b-input-
                        v-model="input.residence"
                        :state="!$v.input.residence.$invalid"
                        class="m-3 rounded"
                        icon=""
                    />
                    <div class="input-label">Ghi chú</div>
                    <b-input-
                        v-model="input.note"
                        :state="!$v.input.note.$invalid"
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
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { PopupMixin } from '~/components/mixins/popup';
import { updatePatron } from '~/graphql/documents/patron';
import { getPatronKinds } from '~/graphql/documents/patronKind';
import { mixinData } from '~/components/mixins/mutable';
import { required, alphaNum, minLength } from 'vuelidate/lib/validators';
import { PatronUpdateInput, GetPatrons } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ updatePatron, getPatronKinds })],
    name: 'popup-patron-update-',
    validations: {
        input: {
            name: { required },
            identification: { required, alphaNum },
            gender: { required },
            patronKind: {
                id: { required },
            },

            birthdate: {},
            listOfPhoneNumbers: {
                minLength: minLength(0),
                $each: {
                    required,
                    alphaNum,
                },
            },
            email: {},
            company: {},

            nationality: {},
            domicile: {},
            residence: {},
            note: {},
        },
    },
})
export default class extends PopupMixin<
    { patron: GetPatrons.Patrons },
    PatronUpdateInput
> {
    phoneNumbers: string = '';

    onOpen() {
        const {
            id,
            identification,
            name,
            email,
            gender,
            nationality,
            birthdate,
            domicile,
            residence,
            company,
            note,
            phoneNumbers,
            patronKind,
        } = this.data.patron;
        const self = this;

        this.phoneNumbers = phoneNumbers.join(' ');
        this.input = {
            id,
            identification,
            name,
            email,
            gender,
            nationality,
            birthdate,
            domicile,
            residence,
            company,
            note,
            get listOfPhoneNumbers() {
                return self.phoneNumbers === ''
                    ? []
                    : self.phoneNumbers.split(/\s*,\s*/);
            },
            patronKind: {
                id: patronKind.id,
            },
        };
    }
}
</script>