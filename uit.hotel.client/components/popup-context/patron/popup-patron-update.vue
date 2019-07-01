<template>
    <popup- ref="popup" v-slot="{ close }" title="Cập nhật khách hàng">
        <form-mutate-
            v-if="input"
            :mutation="updatePatron"
            :variables="{ input }"
            success="Cập nhật khách hàng thành công"
            @success="close"
        >
            <div class="d-flex">
                <div>
                    <div class="input-label">Tên khách hàng</div>
                    <b-input-
                        v-model="input.name"
                        :state="!$v.input.name.$invalid"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Chứng minh nhân dân</div>
                    <b-input-
                        v-model="input.identification"
                        :state="!$v.input.identification.$invalid"
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
                    <div class="input-label">Loại khách hàng</div>
                    <query-
                        v-slot="{ data: { patronKinds } }"
                        :query="getPatronKinds"
                        :poll-interval="0"
                        class="m-3"
                        @result="onResult"
                    >
                        <b-form-select
                            ref="patronKind"
                            v-model="input.patronKind.id"
                            :state="!$v.input.patronKind.id.$invalid"
                            :options="patronKinds"
                            value-field="id"
                            text-field="name"
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
                        icon="calendar"
                    />
                    <div class="input-label">Số điện thoại</div>
                    <b-input-
                        v-model="phoneNumbers"
                        :state="!$v.input.listOfPhoneNumbers.$invalid"
                        class="m-3 rounded"
                        icon="phone"
                    />
                    <div class="input-label">Thư điện tử</div>
                    <b-input-
                        v-model="input.email"
                        :state="optional($v.input.email)"
                        class="m-3 rounded"
                        icon="mail"
                    />
                    <div class="input-label">Công ty</div>
                    <b-input-
                        v-model="input.company"
                        :state="optional($v.input.company)"
                        class="m-3 rounded"
                        icon="briefcase"
                    />
                </div>
                <div>
                    <div class="input-label">Quốc tịch</div>
                    <b-input-
                        v-model="input.nationality"
                        :state="optional($v.input.nationality)"
                        class="m-3 rounded"
                        icon="map-pin"
                    />
                    <div class="input-label">Nguyên quán</div>
                    <b-input-
                        v-model="input.domicile"
                        :state="optional($v.input.domicile)"
                        class="m-3 rounded"
                        icon="calendar"
                    />
                    <div class="input-label">Địa chỉ thường trú</div>
                    <b-input-
                        v-model="input.residence"
                        :state="optional($v.input.residence)"
                        class="m-3 rounded"
                        icon="map-pin"
                    />
                    <div class="input-label">Ghi chú</div>
                    <b-input-
                        v-model="input.note"
                        :state="optional($v.input.note)"
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
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins, Vue } from 'nuxt-property-decorator';
import { PopupMixin, DataMixin } from '~/components/mixins';
import { PatronUpdateInput, GetPatrons } from '~/graphql/types';
import { updatePatron, getPatronKinds } from '~/graphql/documents';
import {
    birthdate,
    gender,
    identification,
    included,
    listOfPhoneNumbers,
    name,
    optional,
    optionalEmail,
} from '~/modules/validator';

@Component({
    name: 'popup-patron-update-',
    validations: {
        input: {
            name,
            identification,
            gender,
            patronKind: included('patronKind'),
            birthdate,
            listOfPhoneNumbers,
            email: optionalEmail,
            company: {},
            nationality: {},
            domicile: {},
            residence: {},
            note: {},
        },
    },
})
export default class extends mixins<
    PopupMixin<{ patron: GetPatrons.Patrons }, PatronUpdateInput>
>(PopupMixin, DataMixin({ updatePatron, getPatronKinds, optional })) {
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
        } = this.data.patron;
        const self = this;

        this.phoneNumbers = phoneNumbers.join(',');
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
                id: -1,
            },
        };
    }

    async onResult() {
        if (this.input === null) return;
        await Vue.nextTick();
        this.input.patronKind.id = this.data.patron.patronKind.id;
        this.$v.$touch();
    }
}
</script>
