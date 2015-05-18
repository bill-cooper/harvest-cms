using Orchard.Layouts.Elements;
using Orchard.Localization;

namespace harvest.Layouts.Elements {
    public class Placeholder : Container
    {
        public const int GridSize = 12;

        public override string Category {
            get { return "Layout"; }
        }

        public override LocalizedString DisplayText {
            get { return T("Placeholder"); }
        }

        public override bool IsSystemElement {
            get { return true; }
        }

        public override bool HasEditor {
            get { return false; }
        }
    }
}