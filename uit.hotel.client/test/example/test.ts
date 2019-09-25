import { assert } from 'chai';
import { filename, itname } from '../utils/utils';

describe(filename(__filename), () => {
    it(itname('.tên_hàm()', 'Làm gì đó'), async () => {
        assert.isTrue(true, 'Phải trả về true ở đây');
    });
});
