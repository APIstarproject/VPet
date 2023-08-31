﻿using VPet_Simulator.Core;

namespace VPet_Simulator.Windows
{
    /// <summary>
    /// 窗体控制器实现
    /// </summary>
    public class MWController : IController
    {
        readonly MainWindow mw;
        public MWController(MainWindow mw)
        {
            this.mw = mw;
        }

        public double GetWindowsDistanceDown()
        {
            return mw.Dispatcher.Invoke(() => System.Windows.SystemParameters.PrimaryScreenHeight - mw.Top - mw.Height);
        }

        public double GetWindowsDistanceLeft()
        {
            return mw.Dispatcher.Invoke(() => mw.Left);
        }

        public double GetWindowsDistanceRight()
        {
            return mw.Dispatcher.Invoke(() => System.Windows.SystemParameters.PrimaryScreenWidth - mw.Left - mw.Width);
        }

        public double GetWindowsDistanceUp()
        {
            return mw.Dispatcher.Invoke(() => mw.Top);
        }

        public void MoveWindows(double X, double Y)
        {
            mw.Dispatcher.Invoke(() =>
            {
                mw.Left += X * ZoomRatio;
                mw.Top += Y * ZoomRatio;
            });
        }

        public void ShowSetting()
        {
            mw.Topmost = false;
            mw.ShowSetting();
        }

        public void ShowPanel()
        {
            var panelWindow = new winCharacterPanel();
            panelWindow.ShowDialog();
        }

        public double ZoomRatio => mw.Set.ZoomLevel;

        public int PressLength => mw.Set.PressLength;

        public bool EnableFunction => mw.Set.EnableFunction;

        public int InteractionCycle => mw.Set.InteractionCycle;

    }
}
