import { RoomCreateInput } from '~/graphql/types';
import { PopupMixin } from '~/components/mixins';

export type RoomSelectMixinType = PopupMixin<
    {
        currentRoomIds: number[];
        callback: (roomIds: number[]) => void;
        from: string;
        to: string;
    },
    RoomCreateInput
>;
