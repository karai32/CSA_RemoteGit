namespace KlientServ.Storage
{
    public enum StorageEnum
    {
        Undefined,
        MemCache,
        FileStorage
    }

    public static class StorageEnumExtensions
    {
        public static StorageEnum ToStorageEnum(this string value)
        {
            switch (value)
            {
                case var s when s.ToLowerInvariant() == "MemCache"
                                || s.ToLowerInvariant() == "Phone"
                                || s.ToLowerInvariant() == "PhoneList":
                    return StorageEnum.MemCache;
                case var s when s.ToLowerInvariant() == "filestorage"
                                || s.ToLowerInvariant() == "file"
                                || s.ToLowerInvariant() == "storage":
                    return StorageEnum.FileStorage;
                default:
                    return StorageEnum.Undefined;
            }
        }
    }
}