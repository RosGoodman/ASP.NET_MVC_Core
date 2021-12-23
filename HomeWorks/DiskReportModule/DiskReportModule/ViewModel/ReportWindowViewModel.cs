

using System;
using System.IO;

namespace DiskReportModule.ViewModel;

public class ReportWindowViewModel
{
    public string DiskName { get; private set; }
    public string DiskType { get; private set; } = "Локальный диск";
    public string FileSystem { get; private set; }
    public string OccupedSpaceByte { get; private set; }
    public string OccupedSpaceGB { get; private set; }
    public string FreeSpaceByte { get; private set; }
    public string FreeSpaceGB { get; private set; }
    public string DiskFullSpaceByte { get; private set; }
    public string DiskFullSpaceGB { get; private set; }

    public ReportWindowViewModel(string diskName)
    {
        LoadDriveInfo(diskName);
    }

    /// <summary> Установить в св-вах информацю об указанном диске. </summary>
    /// <param name="diskName"> Имя диска. </param>
    private void LoadDriveInfo(string diskName)
    {
        DriveInfo[] di = DriveInfo.GetDrives();
        DriveInfo drive = null;
        foreach (DriveInfo d in di)
        {
            if (d.Name == diskName)
            {
                drive = d;
                break;
            }
        }

        if(drive != null)
        {
            long freeSpaceByte = drive.AvailableFreeSpace;
            decimal freeSpaceGB = Math.Round((decimal)drive.AvailableFreeSpace / 1024 / 1024 / 1024, 2);
            long diskFullSpaceByte = drive.TotalSize;
            decimal diskFullSpaceGB = Math.Round((decimal)drive.TotalSize / 1024 / 1024 / 1024, 2);

            DiskName = drive.Name;
            FileSystem = drive.DriveFormat;

            OccupedSpaceByte = $"{diskFullSpaceByte - freeSpaceByte} Byte";
            OccupedSpaceGB = $"{diskFullSpaceGB - freeSpaceGB} GB";

            FreeSpaceByte = $"{freeSpaceByte} Byte";
            FreeSpaceGB = $"{freeSpaceGB} GB";

            DiskFullSpaceByte = $"{diskFullSpaceByte} Byte";
            DiskFullSpaceGB = $"{diskFullSpaceGB} GB";
        }
        
    }
}
