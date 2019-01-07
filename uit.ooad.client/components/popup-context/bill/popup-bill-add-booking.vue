<template>
    <popup- ref="popup" title="Sửa hóa đơn">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { bill }, close }"
            success="Thêm phòng cho hóa đơn có sẵn"
            :mutation="addBookingToBill"
            :variables="{ input }"
        >
            <div class="input-label">Tên hóa đơn</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon=""
            />
            <div class="d-flex m-3">
                <b-button
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    :disabled="$v.$invalid"
                    @click="close"
                >
                    <span class="icon"></span>
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { addBookingToBill } from '~/graphql/documents/bill';
// eslint-disable-next-line typescript/no-unused-vars
import { required, minLength, minValue } from 'vuelidate/lib/validators';
import { GetBills, AddBookingToBill } from 'graphql/types';

@Component({
    mixins: [PopupMixin, mixinData({ addBookingToBill })],
    name: 'popup-bill-update-',
    validations: {
        input: {},
    },
})
export default class extends PopupMixin<
    { bill: GetBills.Bills },
    AddBookingToBill.Variables
> {
    onOpen() {
        this.input = {
            bill: {
                id: 1,
            },
            booking: {
                bookCheckInTime: new Date(),
                bookCheckOutTime: new Date(),
                room: { id: 1 },
                listOfPatrons: [],
            },
        };
    }
}
</script>
