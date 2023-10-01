﻿using Microsoft.VisualBasic.CompilerServices;

namespace WinPaletter
{
    public class ExplorerPatcher
    {
        public static bool IsInstalled = false;
        public bool UseStart10 = false;
        public bool UseTaskbar10 = false;
        public bool TaskbarButton10 = false;
        public StartStyles StartStyle;

        public enum StartStyles
        {
            NotRounded,
            RoundedCornersFloatingMenu,
            RoundedCornersDockedMenu
        }

        public ExplorerPatcher()
        {

            try
            {
                if (My.MyProject.Computer.Registry.CurrentUser.OpenSubKey(@"Software\ExplorerPatcher") is not null)
                {
                    IsInstalled = true;
                }
                else
                {
                    IsInstalled = false;
                }
            }
            finally
            {
                My.MyProject.Computer.Registry.CurrentUser.Close();
            }

            if (!My.Env.Settings.ExplorerPatcher.Enabled_Force)
            {

                if (IsInstalled & My.Env.W11)
                {
                    UseStart10 = Conversions.ToBoolean(Reg_IO.GetReg(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_ShowClassicMode", false));
                    try
                    {
                        {
                            var temp = My.MyProject.Computer.Registry.CurrentUser.OpenSubKey(@"Software\ExplorerPatcher");
                            UseTaskbar10 = Conversions.ToBoolean(temp.GetValue("OldTaskbar"));
                            TaskbarButton10 = (int)temp.GetValue("OrbStyle") == 0;
                            StartStyle = (StartStyles)Conversions.ToInteger(temp.GetValue("StartUI_EnableRoundedCorners"));
                        }
                    }
                    finally
                    {
                        My.MyProject.Computer.Registry.CurrentUser.Close();
                    }
                }
                else
                {
                    UseStart10 = false;
                    UseTaskbar10 = false;
                    TaskbarButton10 = false;
                    StartStyle = StartStyles.NotRounded;
                }
            }

            else
            {
                UseStart10 = My.Env.Settings.ExplorerPatcher.UseStart10;
                UseTaskbar10 = My.Env.Settings.ExplorerPatcher.UseTaskbar10;
                TaskbarButton10 = My.Env.Settings.ExplorerPatcher.TaskbarButton10;
                StartStyle = My.Env.Settings.ExplorerPatcher.StartStyle;
            }


        }

        public static bool IsAllowed()
        {
            bool condition0 = My.Env.W11 && My.Env.Settings.ExplorerPatcher.Enabled && IsInstalled;
            bool condition1 = My.Env.Settings.ExplorerPatcher.Enabled_Force;

            return condition0 || condition1;
        }
    }
}