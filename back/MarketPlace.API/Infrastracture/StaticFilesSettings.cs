namespace MarketPlace.API.Infrastracture
{
    public static class StaticFilesSettings
    {
        public static string StoragePath => "Media/Images"; //головна папка для фото
        public static string ItemPath => "Items";
        public static string WebItemPath => "/images/items";

        public static string CategoryPath => "Categories"; //папка у Image
        public static string WebCategoryPath => "/images/categories";

        public static string VideosStoragePath => "Media/Videos"; //окрема папка для Video
        public static string WebVideosPath => "/videos";
    }
}
