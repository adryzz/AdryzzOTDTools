using System;
using System.Diagnostics;
using System.Threading.Tasks;
using OpenTabletDriver.Plugin;

public static class ShellHelper
{
    public static string Bash(string cmd)
    {
        string output = "";
        var escapedArgs = cmd.Replace("\"", "\\\"");
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "/usr/bin/env bash",
                Arguments = $"-c \"{escapedArgs}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            },
            EnableRaisingEvents = true
        };
        process.Exited += (sender, args) =>
        {
            output = process.StandardOutput.ReadToEnd();
            process.Dispose();
        };

        try
        {
            process.Start();
            process.WaitForExit();
        }
        catch (Exception e)
        {
            Log.Exception(e);
        }

        return output;
    }
}