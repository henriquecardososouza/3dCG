﻿using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

using Framework.Core;

namespace Examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NativeWindowSettings settings = new NativeWindowSettings()
            {
                Title = "Hello Index",
                ClientSize = new Vector2i(800, 800),
                WindowBorder = WindowBorder.Fixed,
                WindowState = WindowState.Normal,
                APIVersion = new Version(3, 3),
                Vsync = VSyncMode.On
            };

            var window = new HelloIndexOOP_PositionNonInterleaved(GameWindowSettings.Default, settings);

            Shader.SetRootPath("Resources/Shader/");

            window.Run();
        }
    }
}