import { BillStatusEnum } from '~/graphql/types';
import { fromNow } from '~/utils';

export const billStatusMap = (status: BillStatusEnum, time: string): string =>
    ({
        [BillStatusEnum.Pending]: 'Đang chờ',
        [BillStatusEnum.Cancel]: `Đã hủy ${fromNow(time)}`,
        [BillStatusEnum.Success]: `Đã thanh toán ${fromNow(time)}`,
    }[status]);

export const billStatusColorMap: {
    [key in BillStatusEnum]: string;
} = {
    [BillStatusEnum.Pending]: 'yellow',
    [BillStatusEnum.Cancel]: 'light',
    [BillStatusEnum.Success]: 'green',
};
