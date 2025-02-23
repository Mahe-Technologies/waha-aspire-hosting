using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting;

/// <summary>
/// Provides extension methods for building and configuring Waha resources in a distributed application.
/// </summary>
public static class WahaResourceBuilderExtensions
{
    private const string WAHA_VOLUME_NAME = "waha-volume";
    private const string WAHA_VOLUME_MOUNT_PATH = "/tmp";
    private const string WAHA_DASHBOARD_PATH = "/dashboard";

    /// <summary>
    /// Adds a Waha resource to the distributed application builder.
    /// </summary>
    /// <param name="builder">The distributed application builder.</param>
    /// <param name="name">The name of the Waha resource.</param>
    /// <param name="port">The optional port for the HTTP endpoint.</param>
    /// <returns>An <see cref="IResourceBuilder{WahaResource}"/> for further configuration.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="builder"/> or <paramref name="name"/> is null.</exception>
    public static IResourceBuilder<WahaResource> AddWaha(
        this IDistributedApplicationBuilder builder,
        [ResourceName] string name,
        int? port = null)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ArgumentNullException.ThrowIfNull(name, nameof(name));

        var resource = new WahaResource(name);

        return builder
            .AddResource(resource)
            .WithAnnotation(new ContainerImageAnnotation { Image = WahaContainerImageTags.Image, Tag = WahaContainerImageTags.Tag, Registry = WahaContainerImageTags.Registry })
            .WithHttpEndpoint(port: port, targetPort: 3000, name: WahaResource.WahaEndpointName)
            .WithOtlpExporter()
            .WithHttpHealthCheck("/")
            .ExcludeFromManifest();
    }

    internal static class WahaContainerImageTags
    {
        internal const string Registry = "docker.io";
        internal const string Image = "devlikeapro/waha";
        internal const string Tag = "latest";
    }
}