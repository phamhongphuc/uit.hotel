<template>
    <div class="m-3 d-flex">
        <b-input-
            ref="date"
            v-model="date"
            :state="state"
            type="date"
            class="rounded"
            icon="calendar"
        />
        <b-input-
            ref="time"
            v-model="time"
            :state="state"
            type="time"
            class="rounded ml-3"
            icon="calendar"
        />
    </div>
</template>
<script lang="ts">
import { Vue, Component, Watch, mixins } from 'nuxt-property-decorator';
import moment from 'moment';
import { InputProps, StateProps } from '~/components/mixins';

@Component({
    name: 'b-input-date-time-',
})
export default class extends mixins<InputProps, StateProps>(
    InputProps,
    StateProps,
) {
    date: string = '';
    time: string = '';

    @Watch('date')
    onDateChange() {
        this.emitDateTime();
    }

    @Watch('time')
    onTimeChange() {
        this.emitDateTime();
    }

    emitDateTime() {
        const dateTime = moment(
            `${this.date} ${this.time}`,
            'YYYY-MM-DD HH:mm',
        ).format();
        this.$emit('input', dateTime);
    }

    async mounted() {
        await Vue.nextTick();
        this.time = moment(this.value).format('HH:mm');
        this.date = moment(this.value).format('YYYY-MM-DD');
        (this.$refs.time as Vue).$emit('input', this.time);
        (this.$refs.date as Vue).$emit('input', this.date);
    }
}
</script>
