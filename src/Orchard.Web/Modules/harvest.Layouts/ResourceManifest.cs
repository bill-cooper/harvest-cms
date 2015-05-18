using Orchard.UI.Resources;

namespace harvest.Layouts {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();

            //manifest.DefineScript("harvest.Layouts.LayoutEditor").SetUrl(@"Models\Placeholder.js").SetDependencies("Layouts.LayoutEditor");
        }
    }
}
