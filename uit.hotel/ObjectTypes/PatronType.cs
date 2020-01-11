using System.Linq;
using GraphQL.Types;
using uit.hotel.Models;
using uit.hotel.Queries.Base;

namespace uit.hotel.ObjectTypes
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
            Field(x => x.PhoneNumber).Description("Danh sách số điện thoại của khách hàng");
            Field(x => x.Company).Description("Công ty mà khách hàng đang làm việc");
            Field(x => x.Note).Description("Một số chú thích về khách hàng nếu cần thiết");

            Field<NonNullGraphType<PatronKindType>>(
                nameof(Patron.PatronKind),
                "Loại khách hàng",
                resolve: context => context.Source.PatronKind
            );
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BillType>>>>(
                nameof(Patron.Bills),
                "Danh sách các số hóa đơn của khách hàng",
                resolve: context => context.Source.Bills.ToList()
            );
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BookingType>>>>(
                nameof(Patron.Bookings),
                "Danh sách các đơn đặt trước của khách hàng",
                resolve: context => context.Source.Bookings.ToList()
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
            Field(x => x.Birthdate, true).Description("Ngày sinh của khách hàng");
            Field(x => x.Nationality).Description("Quốc tịch của khách hàng");
            Field(x => x.Domicile).Description("Nguyên quán của khách hàng");
            Field(x => x.Residence).Description("Địa chỉ thường trú của khách hàng");
            Field(x => x.PhoneNumber).Description("Danh sách số điện thoại của khách hàng");
            Field(x => x.Company).Description("Công ty mà khách hàng đang làm việc");
            Field(x => x.Note).Description("Một số chú thích về khách hàng nếu cần thiết");

            Field<NonNullGraphType<PatronKindIdInput>>(
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
            Field(x => x.PhoneNumber).Description("Danh sách số điện thoại của khách hàng");
            Field(x => x.Company).Description("Công ty mà khách hàng đang làm việc");
            Field(x => x.Note).Description("Một số chú thích về khách hàng nếu cần thiết");

            Field<NonNullGraphType<PatronKindIdInput>>(
                nameof(Patron.PatronKind),
                "Loại khách hàng"
            );
        }
    }
}
