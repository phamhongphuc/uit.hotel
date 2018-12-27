using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

public class HouseKeepingQuery : QueryType<HouseKeeping>
{
    public HouseKeepingQuery()
    {
        Field<ListGraphType<HouseKeepingType>>(
            _List,
            "Trả về một danh sách các công việc dọn dẹp",
            resolve: _CheckPermission_List(
                p => p.PermissionGetHouseKeepings,
                context => HouseKeepingBusiness.Get()
            )
        );
        Field<HouseKeepingType>(
            _Item,
            "Trả về thông tin một công việc dọn dẹp",
            _IdArgument(),
            context => HouseKeepingBusiness.Get(_GetId<int>(context))
        );
    }
}
