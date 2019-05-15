import { mixin } from 'vue-clickaway';
import { Component, Vue } from 'nuxt-property-decorator';

@Component({
    mixins: [mixin],
})
export class ClickawayMixin extends Vue {}
