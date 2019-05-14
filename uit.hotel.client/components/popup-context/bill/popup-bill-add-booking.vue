<template>
    <popup- ref="popup" title="Sửa hóa đơn">
        <form-mutate-
            v-if="input"
            slot-scope="{ data: { bill }, close }"
            :mutation="addBookingToBill"
            :variables="{ input }"
            success="Thêm phòng cho hóa đơn có sẵn"
        >
            <div class="input-label">Tên hóa đơn</div>
            <b-input-
                ref="autoFocus"
                v-model="input.name"
                :state="!$v.input.name.$invalid"
                class="m-3 rounded"
                icon="type"
            />
            <div class="d-flex m-3">
                <b-button
                    :disabled="$v.$invalid"
                    class="ml-auto"
                    variant="main"
                    type="submit"
                    @click="close"
                >
                    <icon- class="mr-1" i="edit-2" />
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </form-mutate->
    </popup->
</template>
<script lang="ts">
import { GetBills, AddBookingToBill } from 'graphql/types';
import { Component } from 'nuxt-property-decorator';
import { mixinData } from '~/components/mixins/mutable';
import { PopupMixin } from '~/components/mixins/popup';
import { addBookingToBill } from '~/graphql/documents/bill';
// import { required, minLength, minValue } from 'vuelidate/lib/validators';

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
