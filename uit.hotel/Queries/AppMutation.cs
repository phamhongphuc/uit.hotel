﻿using uit.hotel.Queries.Base;
using uit.hotel.Queries.Mutation;

namespace uit.hotel.Queries
{
    public class AppMutation : AppType
    {
        public AppMutation()
        {
            AddFields(
                new AuthenticationMutation(),
                new BillMutation(),
                new EmployeeMutation(),
                new FloorMutation(),
                new HouseKeepingMutation(),
                new PatronKindMutation(),
                new PatronMutation(),
                new PositionMutation(),
                new RateMutation(),
                new ReceiptMutation(),
                new RoomKindMutation(),
                new RoomMutation(),
                new ServiceMutation(),
                new ServicesDetailMutation(),
                new BookingMutation(),
                new VolatilityRateMutation()
            );
        }
    }
}