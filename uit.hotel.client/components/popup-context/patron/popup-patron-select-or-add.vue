<template>
    <popup-
        ref="popup"
        v-slot="{ close }"
        title="Thêm hoặc chọn khách hàng"
        no-data
    >
        <form-mutate-
            v-if="input"
            v-slot="{ mutate }"
            :mutation="createPatron"
            :variables="{ input }"
            success="Thêm khách hàng mới thành công"
            @success="close"
        >
            <div class="d-flex">
                <div>
                    <div class="input-label">Chứng minh nhân dân</div>
                    <b-input-
                        v-model="input.identification"
                        :state="!$v.input.identification.$invalid"
                        :formatter="identificationFormatter"
                        class="m-3 rounded"
                        icon="package"
                    />
                    <div class="input-label">Tên khách hàng</div>
                    <b-input-
                        v-model="input.name"
                        :state="!$v.input.name.$invalid"
                        :disabled="disabled"
                        autocomplete="new-password"
                        class="m-3 rounded"
                        icon="type"
                    />
                    <div class="input-label">Giới tính</div>
                    <div class="m-3">
                        <b-form-select
                            v-model="input.gender"
                            :state="!$v.input.gender.$invalid"
                            :disabled="disabled"
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
                    >
                        <b-form-select
                            ref="patronKind"
                            v-model="input.patronKind.id"
                            :disabled="disabled"
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
                        :disabled="disabled"
                        :state="!$v.input.birthdate.$invalid"
                        type="date"
                        class="m-3 rounded"
                        icon="calendar"
                    />
                    <div class="input-label">Số điện thoại</div>
                    <b-input-
                        v-model="phoneNumbers"
                        :disabled="disabled"
                        :state="!$v.input.phoneNumbers.$invalid"
                        class="m-3 rounded"
                        icon="phone"
                    />
                    <div class="input-label">Thư điện tử</div>
                    <b-input-
                        v-model="input.email"
                        :disabled="disabled"
                        :state="optional($v.input.email)"
                        class="m-3 rounded"
                        icon="mail"
                    />
                    <div class="input-label">Công ty</div>
                    <b-input-
                        v-model="input.company"
                        :disabled="disabled"
                        :state="optional($v.input.company)"
                        class="m-3 rounded"
                        icon="briefcase"
                    />
                </div>
                <div>
                    <div class="input-label">Quốc tịch</div>
                    <b-input-
                        v-model="input.nationality"
                        :disabled="disabled"
                        :state="optional($v.input.nationality)"
                        class="m-3 rounded"
                        icon="map-pin"
                    />
                    <div class="input-label">Nguyên quán</div>
                    <b-input-
                        v-model="input.domicile"
                        :disabled="disabled"
                        :state="optional($v.input.domicile)"
                        class="m-3 rounded"
                        icon="calendar"
                    />
                    <div class="input-label">Địa chỉ thường trú</div>
                    <b-input-
                        v-model="input.residence"
                        :disabled="disabled"
                        :state="optional($v.input.residence)"
                        class="m-3 rounded"
                        icon="map-pin"
                    />
                    <div class="input-label">Ghi chú</div>
                    <b-input-
                        v-model="input.note"
                        :disabled="disabled"
                        :state="optional($v.input.note)"
                        class="m-3 rounded"
                        icon="calendar"
                    />
                </div>
            </div>
            <div class="m-3 d-flex">
                <b-button
                    v-if="currentPatron"
                    class="ml-auto"
                    variant="main"
                    @click="addAndSelectFromDatabase(close, currentPatron)"
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm khách hàng có sẵn trong hệ thống</span>
                </b-button>
                <b-button
                    v-if="!currentPatron"
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    @click="addAndSelect(close, mutate)"
                >
                    <icon- class="mr-1" i="plus" />
                    <span>Thêm</span>
                </b-button>
            </div>
            <query-
                v-slot
                :query="getPatrons"
                :poll-interval="500"
                class="d-none"
                @result="onResult"
            />
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component, mixins } from 'nuxt-property-decorator';
import { ApolloQueryResult } from 'apollo-client';
import { PopupMixin, DataMixin } from '~/components/mixins';
import {
    CreatePatron,
    PatronCreateInput,
    GetPatrons,
    GetPatronsQuery,
} from '~/graphql/types';
import { getPatronKinds, createPatron, getPatrons } from '~/graphql/documents';
import {
    gender,
    identification,
    included,
    phoneNumbers,
    name,
    optional,
    optionalBirthdate,
    optionalEmail,
} from '~/modules/validator';

@Component({
    name: 'popup-patron-select-or-add-',
    validations: {
        input: {
            name,
            identification,
            gender,
            patronKind: included('patronKind'),
            birthdate: optionalBirthdate,
            phoneNumbers,
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
    PopupMixin<{ callback(id: number, isNew: boolean) }, PatronCreateInput>
>(
    PopupMixin,
    DataMixin({ createPatron, getPatronKinds, getPatrons, optional }),
) {
    patrons: GetPatrons.Patrons[] = [];

    get disabled() {
        return (
            (this.$v.input.identification &&
                this.$v.input.identification.$invalid) ||
            this.currentPatron !== undefined
        );
    }

    identificationFormatter(value: string) {
        if (value.length > 9) value = value.slice(0, 9);
        return value;
    }

    onOpen() {
        this.input = {
            identification: '',
            name: '',
            gender: true,
            patronKind: {
                id: -1,
            },
            birthdate: null,
            phoneNumbers: '',
            email: '',
            company: '',
            nationality: '',
            domicile: '',
            residence: '',
            note: '',
        };
    }

    async onResult({ data }: ApolloQueryResult<GetPatronsQuery>) {
        this.patrons = data.patrons;
    }

    get currentPatron(): GetPatrons.Patrons | undefined {
        if (this.input == null) return undefined;

        const { identification } = this.input;
        const patron = this.patrons.find(
            p => p.identification === identification,
        );
        if (patron !== undefined) {
            this.input.name = patron.name;
            this.input.name = patron.name;
            this.input.gender = patron.gender;
            this.input.patronKind = patron.patronKind;
            this.input.birthdate = patron.birthdate;
            this.input.phoneNumbers = patron.phoneNumbers;
            this.input.email = patron.email;
            this.input.company = patron.company;
            this.input.nationality = patron.nationality;
            this.input.domicile = patron.domicile;
            this.input.residence = patron.residence;
            this.input.note = patron.note;
        }
        return patron;
    }

    async addAndSelect(
        close: Function,
        mutate: () => Promise<{ data: CreatePatron.Mutation }>,
    ) {
        const { data } = await mutate();
        this.data.callback(data.createPatron.id, true);
        close();
    }

    async addAndSelectFromDatabase(
        close: Function,
        patron: GetPatrons.Patrons,
    ) {
        this.data.callback(patron.id, false);
        close();
    }
}
</script>
