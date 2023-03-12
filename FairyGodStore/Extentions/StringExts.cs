namespace FairyGodStore
{
    public static class StringExts
    {
        public static bool IsEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }
    }
}
