<template>
    <div class="col">
        <div class="row">
            <b-button class="m-2 shadow" size="md" variant="white">
                <span class="icon mr-1"></span>
                <span>Đặt phòng</span>
            </b-button>
            <b-button class="m-2 shadow" size="md" variant="white">
                <span class="icon mr-1"></span>
                <span>Nhận phòng đã đặt</span>
            </b-button>
            <b-button class="m-2 shadow" size="md" variant="white">
                <span class="icon mr-1"></span>
                <span>Nhận phòng ngay</span>
            </b-button>
        </div>
        <div class="row flex-fill">
            <div class="m-2 col-12 hotel-map">
                <query- :query="getFloors">
                    <template slot-scope="{ data }">
                        <div
                            v-for="floor in data.floors"
                            :key="floor.id"
                            class="row my-2"
                        >
                            <b-button class="shadow" variant="main">
                                {{ floor.name }}
                            </b-button>
                            <b-button
                                v-for="room in floor.rooms"
                                :key="room.id"
                                class="shadow"
                                variant="white"
                            >
                                {{ room.name }}
                            </b-button>
                        </div>
                    </template>
                </query->
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
import { getFloors } from '~/graphql/documents/floor-room';

@Component({
    name: 'index-',
})
export default class extends Vue {
    head() {
        return {
            title: 'Sơ đồ khách sạn',
        };
    }

    getFloors = getFloors;
}
</script>
