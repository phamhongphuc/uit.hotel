import { FetchResult } from 'apollo-link';
import { DocumentNode } from 'graphql';
import { Component, Prop, Vue } from 'nuxt-property-decorator';
import { apolloClientNotify } from '~/modules/apollo';
import { notify } from '~/plugins/notify';

@Component
export class MutableMixin extends Vue {
    @Prop({ required: true })
    protected mutation!: DocumentNode;

    @Prop({ default: '' })
    protected variables!: object;

    @Prop({ default: undefined })
    protected success: string | undefined;

    protected get mutationName(): string | undefined {
        const operation = this.mutation.definitions[0];
        if (
            operation !== undefined &&
            'name' in operation &&
            operation.name !== undefined
        ) {
            return operation.name.value;
        }
        return undefined;
    }

    protected async mutate(): Promise<
        FetchResult<{}, Record<string, any>, Record<string, any>> | undefined
    > {
        const result = await apolloClientNotify({ app: this }).mutate({
            mutation: this.mutation,
            variables: this.variables,
        });
        const mutationName = this.mutationName;
        if (mutationName !== undefined) {
            const data = result.data;
            if (data == null) return undefined;
            if (mutationName in data) {
                const text = data[mutationName];
                if (typeof text === 'string') {
                    notify.success({
                        title: 'Thông báo',
                        text,
                    });
                } else if (this.success !== undefined) {
                    notify.success({
                        title: 'Thông báo',
                        text: this.success,
                    });
                }
            }
        }
        return result;
    }
}
