﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TelegramBotRemoteControlComputer.Control.Spotify.Service;

public static class ShowSpotifyWindow
{
    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string className, string windowTitle);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

    [DllImport("user32.dll")]
    private static extern int SetForegroundWindow(IntPtr hwnd);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetWindowPlacement(IntPtr hWnd, ref Windowplacement lpwndpl);

    private enum ShowWindowEnum
    {
        Hide = 0,
        ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
        Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
        Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
        Restore = 9, ShowDefault = 10, ForceMinimized = 11
    };

    private struct Windowplacement
    {
        public int length;
        public int flags;
        public int showCmd;
        public System.Drawing.Point ptMinPosition;
        public System.Drawing.Point ptMaxPosition;
        public System.Drawing.Rectangle rcNormalPosition;
    }

    public static void BringWindowToFront()
    {
        var processes = Process.GetProcessesByName("spotify");
        
        IntPtr wdwIntPtr = FindWindow(null, processes.FirstOrDefault().MainWindowTitle);

        //get the hWnd of the process
        Windowplacement placement = new Windowplacement();
        GetWindowPlacement(wdwIntPtr, ref placement);

        // Check if window is minimized
        if (placement.showCmd == 2)
        {
            //the window is hidden so we restore it
            ShowWindow(wdwIntPtr, ShowWindowEnum.Restore);
        }

        //set user focus to the window
        SetForegroundWindow(wdwIntPtr);
    }
}