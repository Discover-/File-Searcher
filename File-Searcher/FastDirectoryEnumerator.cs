using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace File_Searcher
{
    [Serializable]
    public struct FileData
    {
        public readonly FileAttributes Attributes;
        public readonly DateTime CreationTimeUtc;
        public readonly DateTime LastAccessTimeUtc;
        public readonly DateTime LastWriteTimeUtc;
        public readonly string Name;
        public readonly string Path;
        public readonly long Size;

        internal FileData(string dir, Win32FindData findData)
        {
            Attributes = findData.dwFileAttributes;
            CreationTimeUtc = ConvertDateTime(findData.ftCreationTime_dwHighDateTime, findData.ftCreationTime_dwLowDateTime);
            LastAccessTimeUtc = ConvertDateTime(findData.ftLastAccessTime_dwHighDateTime, findData.ftLastAccessTime_dwLowDateTime);
            LastWriteTimeUtc = ConvertDateTime(findData.ftLastWriteTime_dwHighDateTime, findData.ftLastWriteTime_dwLowDateTime);
            Size = CombineHighLowInts(findData.nFileSizeHigh, findData.nFileSizeLow);
            Name = findData.cFileName;
            Path = System.IO.Path.Combine(dir, findData.cFileName);
        }

        public DateTime CreationTime
        {
            get { return CreationTimeUtc.ToLocalTime(); }
        }

        public DateTime LastAccessTime
        {
            get { return LastAccessTimeUtc.ToLocalTime(); }
        }

        public DateTime LastWriteTime
        {
            get { return LastWriteTimeUtc.ToLocalTime(); }
        }

        private static long CombineHighLowInts(uint high, uint low)
        {
            return (((long) high) << 0x20) | low;
        }

        private static DateTime ConvertDateTime(uint high, uint low)
        {
            long fileTime = CombineHighLowInts(high, low);
            return DateTime.FromFileTimeUtc(fileTime);
        }
    }

    [Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto), BestFitMapping(false)]
    internal struct Win32FindData
    {
        public FileAttributes dwFileAttributes;
        public uint ftCreationTime_dwLowDateTime;
        public uint ftCreationTime_dwHighDateTime;
        public uint ftLastAccessTime_dwLowDateTime;
        public uint ftLastAccessTime_dwHighDateTime;
        public uint ftLastWriteTime_dwLowDateTime;
        public uint ftLastWriteTime_dwHighDateTime;
        public uint nFileSizeHigh;
        public uint nFileSizeLow;
        public int dwReserved0;
        public int dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternateFileName;
    }

    public static class FastDirectoryEnumerator
    {
        static FastDirectoryEnumerator()
        {
            new FileIOPermission(PermissionState.None) { AllFiles = FileIOPermissionAccess.PathDiscovery }.Demand();
        }

        public static IEnumerable<string> GetDirectories(string path, string searchPattern)
        {
            Win32FindData winFindData;
            var findHandle = FindFirstFile(Path.Combine(path, searchPattern), out winFindData);

            if (findHandle == InvalidHandleValue)
                yield break;
            try
            {
                do
                {
                    if (winFindData.cFileName == "." || winFindData.cFileName == "..")
                        continue;
                    if ((winFindData.dwFileAttributes & FileAttributes.Directory) != 0)
                    {
                        yield return Path.Combine(path, winFindData.cFileName);
                    }
                } while (FindNextFile(findHandle, out winFindData));
            }
            finally
            {
                FindClose(findHandle);
            }
        }

        public static IEnumerable<string> GetAllDirectories(string path)
        {
            foreach (var dir in GetDirectories(path, "*"))
            {
                if (dir == ".." || dir == ".")
                    continue;
                yield return dir;
                foreach (var subDir in GetAllDirectories(Path.Combine(path, dir)))
                    yield return subDir;
            }
        }

        public static IEnumerable<FileData> GetFiles(string path, string searchPattern)
        {
            Win32FindData winFindData;
            var findHandle = FindFirstFile(Path.Combine(path, searchPattern), out winFindData);

            if (findHandle == InvalidHandleValue)
                yield break;
            try
            {
                do
                {
                    if (winFindData.cFileName == "." || winFindData.cFileName == "..")
                        continue;
                    if ((winFindData.dwFileAttributes & FileAttributes.Directory) == 0)
                    {
                        yield return new FileData(path, winFindData);
                    }
                } while (FindNextFile(findHandle, out winFindData));
            }
            finally
            {
                FindClose(findHandle);
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindFirstFile(string fileName, out Win32FindData data);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool FindNextFile(IntPtr hndFindFile, out Win32FindData lpFindFileData);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindClose(IntPtr hFindFile);
        private static readonly IntPtr InvalidHandleValue = new IntPtr(-1);
    }
}
