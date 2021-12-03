using System.Drawing;

namespace CatalogPdf
{
    public static class UserSettings
    {

        public static Color catalogDocItem_ActiveColor { get; set; }
                                = Color.FromArgb(240, 246, 255);
        public static Color catalogDocItem_PassiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color catalogTomeItem_ActiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color catalogTomeItem_PassiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color BookmarkCatalogItem_ActiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color BookmarkCatalogItem_PassiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color ExplanetionCatalogItem_ActiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color ExplanetionCatalogItem_PassiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color BookmarkViewItem_ActiveColor { get; set; }
                          = Color.FromArgb(0, 0, 0);
        public static Color BookmarkViewItem_PassiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color ExplanetionViewItem_ActiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color ExplanetionViewItem_PassiveColor { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color BackForm { get; set; }
                                = Color.FromArgb(0, 0, 0);
        public static Color BackPanelsForm { get; set; }
                                = Color.FromArgb(0, 0, 0);
    }
}
