import { assert } from 'chai';
import { filename, itname } from './utils/utils';

describe(filename(__filename), function() {
    it(itname('.tên_hàm()', 'Làm gì đó'), async function() {
        assert.isTrue(true, 'Phải trả về true ở đây');
    });
});
