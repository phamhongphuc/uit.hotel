import { Component, mixins } from 'nuxt-property-decorator';
import { ProvideRefs } from './refs';
import { TableContext } from './table';

@Component
export class Page extends mixins<ProvideRefs, TableContext>(
    ProvideRefs,
    TableContext,
) {}
