using System;
using System.Linq;
using System.Text;
using ConsoleMediaPlayer.Constants;
using ConsoleMediaPlayer.Enums;

namespace ConsoleMediaPlayer.Services;

public static class FigureService
{
    public static void DrawHorizontalLine(int width, string character)
    {
        for (int i = 0; i <= width; i++)
        {
            Console.Write(character);
        }
    }

    public static void DrawRectangle(int width, int height)
    {
        DrawHorizontalLine(width, AppConstants.HOTIZONTAL_LINE);
        Console.Write("\n");
        for (int i = 0; i <= height; i++)
        {
            Console.Write(AppConstants.VERTICAL_LINE);
            DrawHorizontalLine(width - 2, AppConstants.WHITESPACE);
            Console.Write(AppConstants.VERTICAL_LINE + "\n");
        }
        DrawHorizontalLine(width, AppConstants.HOTIZONTAL_LINE);
    }

    public static void DrawMediaPlayer()
    {
        // ToDo: print contents of the first directory too.
        var contents = FileReader.GetContents();
        var maxWidth = contents.MaxBy(c=> c.Key.Length);
        var width = maxWidth.Key.Length + 2;

        // Some songs have wierd characters in their names and this breaks the frame.
        // ToDo: Change this, right now it prints like ?.
        Console.OutputEncoding = Encoding.ASCII;
        DrawHorizontalLine(width, AppConstants.HOTIZONTAL_LINE);
        Console.Write("\n");
        foreach(var content in contents)
        {
            Console.Write(AppConstants.VERTICAL_LINE);
            // ToDo: allow to chose colours.
            Console.ForegroundColor = content.Value == FileTypeEnum.Directory ? ConsoleColor.DarkMagenta : ConsoleColor.Cyan;
            Console.Write(content.Key);
            int whitespaceCount = width - content.Key.Length - 2;
            Console.ForegroundColor = ConsoleColor.White;

            DrawHorizontalLine(whitespaceCount, AppConstants.WHITESPACE);
            Console.Write(AppConstants.VERTICAL_LINE + "\n");
        }
        DrawHorizontalLine(width, AppConstants.HOTIZONTAL_LINE);
    }
}

