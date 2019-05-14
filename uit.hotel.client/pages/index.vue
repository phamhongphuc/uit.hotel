<template>
    <div>
        <div class="col m-2 bg-white rounded shadow-sm overflow-auto main-app">
            Vui lòng sử dụng menu bên trái để chọn chức năng tương ứng!
        </div>
    </div>
</template>
<script lang="ts">
import { GetFloors } from 'graphql/types';
import { Vue, Component } from 'nuxt-property-decorator';
import { getFloors } from '~/graphql/documents';
import { mixinData } from '~/components/mixins';

@Component({
    name: 'index-',
    mixins: [mixinData({ getFloors })],
})
export default class extends Vue {
    selected: GetFloors.Rooms[] = [];

    head() {
        return {
            title: 'Trang chủ',
        };
    }

    floorsFilter(floors: GetFloors.Floors[]): GetFloors.Floors[] {
        return floors
            .filter(f => f.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    roomsFilter(rooms: GetFloors.Rooms[]): GetFloors.Rooms[] {
        return rooms
            .filter(r => r.isActive)
            .sort((a, b) => (a.name > b.name ? 1 : -1));
    }

    toggle(room: GetFloors.Rooms): void {
        const index = this.selected.indexOf(room);

        if (index === -1) this.selected.push(room);
        else this.selected.splice(index, 1);
    }
}
</script>
<style lang="scss">
.main-app {
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>
