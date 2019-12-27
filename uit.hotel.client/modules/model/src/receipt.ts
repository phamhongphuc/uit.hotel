import { ReceiptKindEnum, ReceiptStatusEnum } from '~/graphql/types';

export const ReceiptKindTitleMap: { [key in ReceiptKindEnum]: string } = {
    [ReceiptKindEnum.Cash]: 'Tiền mặt',
    [ReceiptKindEnum.Momo]: 'Ví Momo',
};

export const ReceiptKindIconMap: { [key in ReceiptKindEnum]: string } = {
    [ReceiptKindEnum.Cash]: 'receipt',
    [ReceiptKindEnum.Momo]: 'momo',
};

export const ReceiptKindColorMap: { [key in ReceiptKindEnum]: string } = {
    [ReceiptKindEnum.Cash]: 'green',
    [ReceiptKindEnum.Momo]: 'momo',
};

export const ReceiptStatusColorMap: { [key in ReceiptStatusEnum]: string } = {
    [ReceiptStatusEnum.Pending]: 'yellow',
    [ReceiptStatusEnum.Success]: 'green',
    [ReceiptStatusEnum.Error]: 'red',
    [ReceiptStatusEnum.SystemError]: 'light',
};
