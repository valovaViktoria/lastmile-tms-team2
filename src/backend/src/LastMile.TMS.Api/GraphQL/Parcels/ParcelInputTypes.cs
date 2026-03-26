using HotChocolate.Types.Descriptors;

namespace LastMile.TMS.Api.GraphQL.Parcels;

public class RegisterParcelInputType : InputObjectType<RegisterParcelInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<RegisterParcelInput> descriptor)
    {
        descriptor.BindFieldsImplicitly();
    }
}
