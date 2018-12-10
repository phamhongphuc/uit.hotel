using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._VolatilityRate
{
    [TestClass]
    public class _VolatilityRate
    {
        public _VolatilityRate()
        {
            RoomKindBusiness.Add(new RoomKind
            {
                Id = 1,
                Name = "Tên loại phòng",
                AmountOfPeople = 1,
                NumberOfBeds = 1,
                PriceByDate = 1
            });
            VolatilityRateBusiness.Add(new VolatilityRate
            {
                Id = 1,
                DayRate = 1,
                NightRate = 1,
                WeekRate = 1,
                MonthRate = 1,
                LateCheckOutFee = 1,
                EarlyCheckInFee = 1,
                EffectiveStartDate = DateTime.Now,
                EffectiveEndDate = DateTime.Now,
                EffectiveOnMonday = true,
                EffectiveOnTuesday = true,
                EffectiveOnWednesday = true,
                EffectiveOnThursday = true,
                CreateDate = DateTime.Now,
                RoomKind = RoomKindBusiness.Get(1)
            });
        }

        [TestMethod]
        public void VolatilityRates()
        {
            SchemaHelper.Execute(
                @"/GraphQL/VolatilityRate/query.volatilityrates.gql",
                @"/GraphQL/VolatilityRate/query.volatilityrates.schema.json"
            );
        }
    }
}
