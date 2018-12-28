using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;
using uit.ooad.Queries.Base;

namespace uit.ooad.ObjectTypes
{
    public class PatronType : ObjectGraphType<Patron>
    {
        public PatronType()
        {
            Name = nameof(Patron);
            Description = "Thông tin  một khách hàng của khách sạn";

            Field(x => x.Id).Description("Id của khách hàng");
            Field(x => x.Identification)
               .Description("Số an sinh xã hội / Số chứng minh nhân dân / Số passport của khách hàng");
            Field(x => x.Name).Description("Tên của khách hàng");
            Field(x => x.Email).Description("Địa chỉ e-mail của khách hàng");
            Field(x => x.Gender).Description("Giới tính của khách hàng");
            Field(x => x.Birthdate).Description("Ngày sinh của khách hàng");
            Field(x => x.Nationality).Description("Quốc tịch của khách hàng");
            Field(x => x.Domicile).Description("Nguyên quán của khách hàng");
            Field(x => x.Residence).Description("Địa chỉ thường trú của khách hàng");
            Field(x => x.Company).Description("Công ty mà khách hàng đang làm việc");
            Field(x => x.Note).Description("Một số chú thích về khách hàng nếu cần thiết");

            Field<ListGraphType<StringGraphType>>(
                nameof(Patron.PhoneNumbers),
                resolve: context => context.Source.PhoneNumbers.ToList(),
                description: "Danh sách số điện thoại của khách hàng"
            );

            Field<NonNullGraphType<PatronKindType>>(
                nameof(Patron.PatronKind),
                resolve: context => context.Source.PatronKind,
                description: "Loại khách hàng"
            );

            Field<ListGraphType<BillType>>(
                nameof(Patron.Bills),
                resolve: context => context.Source.Bills.ToList(),
                description: "Danh sách các số hóa đơn của khách hàng"
            );
            Field<ListGraphType<BookingType>>(
                nameof(Patron.Bookings),
                resolve: context => context.Source.Bookings.ToList(),
                description: "Danh sách các đơn đặt trước của khách hàng"
            );
        }
    }

    public class PatronIdInput : InputType<Patron>
    {
        public PatronIdInput()
        {
            Name = _Id;
            Description = "Input cho thông tin một khách hàng";

            Field(x => x.Id).Description("Id của khách hàng");
        }
    }

    public class PatronCreateInput : InputType<Patron>
    {
        public PatronCreateInput()
        {
            Name = _Creation;

            Field(x => x.Identification)
               .Description("Số an sinh xã hội / Số chứng minh nhân dân / Số passport của khách hàng");
            Field(x => x.Name).Description("Tên của khách hàng");
            Field(x => x.Email).Description("Địa chỉ e-mail của khách hàng");
            Field(x => x.Gender).Description("Giới tính của khách hàng");
            Field(x => x.Birthdate).Description("Ngày sinh của khách hàng");
            Field(x => x.Nationality).Description("Quốc tịch của khách hàng");
            Field(x => x.Domicile).Description("Nguyên quán của khách hàng");
            Field(x => x.Residence).Description("Địa chỉ thường trú của khách hàng");
            Field(x => x.Company).Description("Công ty mà khách hàng đang làm việc");
            Field(x => x.Note).Description("Một số chú thích về khách hàng nếu cần thiết");

            Field<ListGraphType<StringGraphType>>(
                nameof(Patron.ListOfPhoneNumbers),
                "Danh sách số điện thoại của khách hàng"
            );
            Field<PatronKindIdInput>(
                nameof(Patron.PatronKind),
                "Loại khách hàng"
            );
        }
    }

    public class PatronUpdateInput : InputType<Patron>
    {
        public PatronUpdateInput()
        {
            Name = _Updation;

            Field(x => x.Id).Description("Id của khách hàng");
            Field(x => x.Identification)
               .Description("Số an sinh xã hội / Số chứng minh nhân dân / Số passport của khách hàng");
            Field(x => x.Name).Description("Tên của khách hàng");
            Field(x => x.Email).Description("Địa chỉ e-mail của khách hàng");
            Field(x => x.Gender).Description("Giới tính của khách hàng");
            Field(x => x.Birthdate).Description("Ngày sinh của khách hàng");
            Field(x => x.Nationality).Description("Quốc tịch của khách hàng");
            Field(x => x.Domicile).Description("Nguyên quán của khách hàng");
            Field(x => x.Residence).Description("Địa chỉ thường trú của khách hàng");
            Field(x => x.Company).Description("Công ty mà khách hàng đang làm việc");
            Field(x => x.Note).Description("Một số chú thích về khách hàng nếu cần thiết");

            Field<ListGraphType<StringGraphType>>(
                nameof(Patron.ListOfPhoneNumbers),
                "Danh sách số điện thoại của khách hàng"
            );
            Field<PatronKindIdInput>(
                nameof(Patron.PatronKind),
                "Loại khách hàng"
            );
        }
    }
}
