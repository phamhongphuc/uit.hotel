import { GetPatrons, GetRooms } from '~/graphql/types';

export type TableDataType = {
    room: GetRooms.Rooms;
    patrons: (GetPatrons.Patrons & { isOwner: boolean })[];
};
