import { filename, itname } from '../utils/utils';
import { assert } from 'chai';

describe(filename(__filename), function(): void {
    it(itname('.tên_hàm()', 'Làm gì đó'), async function(): Promise<void> {
        assert.isTrue(true, 'Phải trả về true ở đây');
    });
});
