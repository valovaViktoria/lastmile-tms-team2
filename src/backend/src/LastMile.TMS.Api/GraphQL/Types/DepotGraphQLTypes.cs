using HotChocolate.Types.Relay;
using LastMile.TMS.Application.Depots.DTOs;

namespace LastMile.TMS.Api.GraphQL.Types;

public class AddressType : ObjectType<AddressDto>
{
    protected override void Configure(IObjectTypeDescriptor<AddressDto> descriptor)
    {
        descriptor.Name("Address");

        descriptor.Field(a => a.Street1).Name("street1").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.Street2).Name("street2").Type<StringType>();
        descriptor.Field(a => a.City).Name("city").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.State).Name("state").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.PostalCode).Name("postalCode").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.CountryCode).Name("countryCode").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.IsResidential).Name("isResidential").Type<BooleanType>();
        descriptor.Field(a => a.ContactName).Name("contactName").Type<StringType>();
        descriptor.Field(a => a.CompanyName).Name("companyName").Type<StringType>();
        descriptor.Field(a => a.Phone).Name("phone").Type<StringType>();
        descriptor.Field(a => a.Email).Name("email").Type<StringType>();
    }
}

public class OperatingHoursType : ObjectType<OperatingHoursDto>
{
    protected override void Configure(IObjectTypeDescriptor<OperatingHoursDto> descriptor)
    {
        descriptor.Name("OperatingHours");

        descriptor.Field(h => h.DayOfWeek).Name("dayOfWeek").Type<NonNullType<EnumType<DayOfWeek>>>();
        descriptor.Field(h => h.OpenTime).Name("openTime").Type<StringType>();
        descriptor.Field(h => h.ClosedTime).Name("closedTime").Type<StringType>();
        descriptor.Field(h => h.IsClosed).Name("isClosed").Type<NonNullType<BooleanType>>();
    }
}

public class DepotType : ObjectType<DepotDto>
{
    protected override void Configure(IObjectTypeDescriptor<DepotDto> descriptor)
    {
        descriptor.Name("Depot");

        descriptor.Field(d => d.Id).Name("id").Type<NonNullType<IdType>>();
        descriptor.Field(d => d.Name).Name("name").Type<NonNullType<StringType>>();
        descriptor.Field(d => d.Address).Name("address").Type<AddressType>();
        descriptor.Field(d => d.OperatingHours).Name("operatingHours").Type<ListType<OperatingHoursType>>();
        descriptor.Field(d => d.IsActive).Name("isActive").Type<NonNullType<BooleanType>>();
        descriptor.Field(d => d.CreatedAt).Name("createdAt").Type<NonNullType<DateTimeType>>();
        descriptor.Field(d => d.UpdatedAt).Name("updatedAt").Type<DateTimeType>();
    }
}
