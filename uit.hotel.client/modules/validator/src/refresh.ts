import { Vue } from 'nuxt-property-decorator';

export async function refresh(objectHasId: { id: number }) {
    await Vue.nextTick();

    const { id } = objectHasId;
    objectHasId.id = -1;
    objectHasId.id = id;
}
