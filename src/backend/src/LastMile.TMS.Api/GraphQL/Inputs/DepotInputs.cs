using HotChocolate.Types.Relay;
using LastMile.TMS.Application.Depots.DTOs;

namespace LastMile.TMS.Api.GraphQL.Inputs;

public class AddressInput : InputObjectType<AddressDto>
{
    protected override void Configure(IInputObjectTypeDescriptor<AddressDto> descriptor)
    {
        descriptor.Name("AddressInput");

        descriptor.Field(a => a.Street1).Name("street1").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.Street2).Name("street2").Type<StringType>();
        descriptor.Field(a => a.City).Name("city").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.State).Name("state").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.PostalCode).Name("postalCode").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.CountryCode).Name("countryCode").Type<NonNullType<StringType>>();
        descriptor.Field(a => a.IsResidential).Name("isResidential").Type<BooleanType>().DefaultValue(false);
        descriptor.Field(a => a.ContactName).Name("contactName").Type<StringType>();
        descriptor.Field(a => a.CompanyName).Name("companyName").Type<StringType>();
        descriptor.Field(a => a.Phone).Name("phone").Type<StringType>();
        descriptor.Field(a => a.Email).Name("email").Type<StringType>();
    }
}

public class OperatingHoursInput : InputObjectType<OperatingHoursDto>
{
    protected override void Configure(IInputObjectTypeDescriptor<OperatingHoursDto> descriptor)
    {
        descriptor.Name("OperatingHoursInput");

        descriptor.Field(h => h.DayOfWeek).Name("dayOfWeek").Type<NonNullType<EnumType<DayOfWeek>>>();
        descriptor.Field(h => h.OpenTime).Name("openTime").Type<StringType>();
        descriptor.Field(h => h.ClosedTime).Name("closedTime").Type<StringType>();
        descriptor.Field(h => h.IsClosed).Name("isClosed").Type<NonNullType<BooleanType>>().DefaultValue(false);
    }
}

public class CreateDepotInput : InputObjectType
{
    protected override void Configure(IInputObjectTypeDescriptor descriptor)
    {
        descriptor.Name("CreateDepotInput");

        descriptor.Field("name").Type<NonNullType<StringType>>();
        descriptor.Field("address").Type<NonNullType<AddressInput>>();
        descriptor.Field("operatingHours").Type<ListType<OperatingHoursInput>>();
        descriptor.Field("isActive").Type<BooleanType>().DefaultValue(true);
    }
}

public class UpdateDepotInput : InputObjectType
{
    protected override void Configure(IInputObjectTypeDescriptor descriptor)
    {
        descriptor.Name("UpdateDepotInput");

        descriptor.Field("name").Type<NonNullType<StringType>>();
        descriptor.Field("address").Type<AddressInput>();
        descriptor.Field("operatingHours").Type<ListType<OperatingHoursInput>>();
        descriptor.Field("isActive").Type<NonNullType<BooleanType>>();
    }
}
