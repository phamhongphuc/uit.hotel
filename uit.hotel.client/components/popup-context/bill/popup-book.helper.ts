import { GetPatronsAndRooms } from '~/graphql/types';

export type TableDataType = {
    room: GetPatronsAndRooms.Rooms;
    patrons: (GetPatronsAndRooms.Patrons & { isOwner: boolean })[];
};
