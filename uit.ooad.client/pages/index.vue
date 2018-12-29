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
                <gql-query- :query="getFloors">
                    <template slot-scope="{ data }">
                        <div
                            v-for="floor in data.floors"
                            :key="floor.id"
                            class="row hotel-map-floor my-2"
                        >
                            <b-button
                                class="hotel-map-floor-name shadow"
                                variant="main"
                            >
                                {{ floor.name }}
                            </b-button>
                            <b-button
                                v-for="room in floor.rooms"
                                :key="room.id"
                                class="hotel-map-floor-room shadow"
                                variant="white"
                            >
                                {{ room.name }}
                            </b-button>
                        </div>
                    </template>
                </gql-query->
            </div>
        </div>
    </div>
</template>
<script lang="ts">
import { Vue, Component, namespace } from 'nuxt-property-decorator';
import gql from 'graphql-tag';

@Component({
    name: 'index-',
})
export default class extends Vue {
    head() {
        return {
            title: 'Sơ đồ khách sạn',
        };
    }

    @namespace('style').State
    breakpoint;

    getFloors = gql`
        query getFloors {
            floors {
                id
                name
                isActive
                rooms {
                    id
                    name
                    roomKind {
                        name
                    }
                }
            }
        }
    `;
}
</script>
<style lang="scss">
.hotel-map {
    .hotel-map-floor {
        > button {
            padding: 0.75rem;
        }
        > .hotel-map-floor-name {
            width: 100px;
            margin-right: 0.5rem;
        }
    }
}
</style>
