using System;
using ConsoleMediaPlayer.Constants;
using ConsoleMediaPlayer.Enums;

namespace ConsoleMediaPlayer.Services;

public static class FileReader
{
    public static List<string> GetDirctories()
    {
        var directories = Directory.GetDirectories(AppConstants.DEFAULT_FOLDER);
        return directories.ToList();
    }

    public static List<string> GetFiles()
    {
        var files = Directory.GetFiles(AppConstants.DEFAULT_FOLDER);
        return files.ToList();
    }
    public static Dictionary<string, FileTypeEnum> GetContents()
    {
        var directories = GetDirctories();
        var files = GetFiles();

        var contents = new Dictionary<string, FileTypeEnum>();
        foreach (var dir in directories)
        {
            contents.Add(dir, FileTypeEnum.Directory);
        }
        foreach (var f in files)
        {
            contents.Add(f, FileTypeEnum.File);
        }
        return contents;
    }
}

