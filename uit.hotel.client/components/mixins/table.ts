import { Component, Vue } from 'nuxt-property-decorator';

@Component
export class TableContext extends Vue {
    tableContext(event: MouseEvent) {
        event.stopPropagation();

        const tr = (event.target as HTMLElement).closest('tr');
        if (tr !== null) {
            this.currentEvent = event;
            tr.click();
        }
    }

    currentEvent: MouseEvent | null = null;
}
