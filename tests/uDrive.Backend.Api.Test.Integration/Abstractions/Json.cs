#define _AUTO_VERIFY

namespace uDrive.Backend.Api.Test.Integration.Abstractions;

using Argon;

internal static class Json
{
    public static JsonSerializer Serializer { get; } =
        JsonSerializer.CreateDefault(
            new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = true }
                }
            }
        );
}
