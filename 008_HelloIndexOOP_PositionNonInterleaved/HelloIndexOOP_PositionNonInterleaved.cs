﻿// <copyright file="HelloIndexOOP_PositionNonInterleaved.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Examples
{
    using Framework.Core;
    using Framework.Core.Buffer;
    using Framework.Core.Vertex;
    using Framework.Utils;
    using Framework.Utils.GUI;
    using OpenTK.Graphics.OpenGL4;
    using OpenTK.Windowing.Common;
    using OpenTK.Windowing.Desktop;

    /// <inheritdoc/>
    internal class HelloIndexOOP_PositionNonInterleaved : GameWindow
    {
        private FPSCounter fpsCounter;

        private VertexBufferObject vbo;
        private VertexBufferObject posVbo;
        private VertexArrayObject vao;
        private ElementBufferObject ebo;

        private Shader shader;

        private Texture texture;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelloIndexOOP_PositionNonInterleaved"/> class.
        /// </summary>
        /// <param name="gameWindowSettings"> PARAM TODO. </param>
        /// <param name="nativeWindowSettings"> PARAM2 TODO. </param>
        public HelloIndexOOP_PositionNonInterleaved(
            GameWindowSettings gameWindowSettings,
            NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        /// <inheritdoc/>
        protected override void OnLoad()
        {
            base.OnLoad();

            this.fpsCounter = new FPSCounter(this);

            float[] positionData =
            {
            // .Position
            // .X           Y           Z
                -0.125000f, 0.083333f,  -0.000050f, // Triangle
                -0.500000f, 0.833333f,  -0.000050f,
                -0.875000f, 0.083333f,  -0.000050f,

                0.125000f,  0.125000f,  -0.000050f, // Square
                0.875000f,  0.125000f,  -0.000050f,
                0.875000f,  0.875000f,  -0.000050f,
                0.125000f,  0.875000f,  -0.000050f,

                -0.125000f, -0.500000f, -0.000050f, // Hexagon
                -0.312500f, -0.175241f, -0.000050f,
                -0.687500f, -0.175241f, -0.000050f,
                -0.875000f, -0.500000f, -0.000050f,
                -0.687500f, -0.824760f, -0.000050f,
                -0.312500f, -0.824760f, -0.000050f,

                0.875000f,  -0.500000f, -0.000050f, // Circle
                0.868952f,  -0.432643f, -0.000050f,
                0.851518f,  -0.369226f, -0.000050f,
                0.823760f,  -0.310813f, -0.000050f,
                0.786743f,  -0.258469f, -0.000050f,
                0.741531f,  -0.213257f, -0.000050f,
                0.689187f,  -0.176240f, -0.000050f,
                0.630774f,  -0.148483f, -0.000050f,
                0.567357f,  -0.131048f, -0.000050f,
                0.500000f,  -0.125000f, -0.000050f,
                0.432643f,  -0.131048f, -0.000050f,
                0.369226f,  -0.148483f, -0.000050f,
                0.310813f,  -0.176240f, -0.000050f,
                0.258469f,  -0.213257f, -0.000050f,
                0.213257f,  -0.258469f, -0.000050f,
                0.176240f,  -0.310814f, -0.000050f,
                0.148483f,  -0.369226f, -0.000050f,
                0.131048f,  -0.432643f, -0.000050f,
                0.125000f,  -0.500000f, -0.000050f,
                0.131048f,  -0.567358f, -0.000050f,
                0.148482f,  -0.630774f, -0.000050f,
                0.176240f,  -0.689187f, -0.000050f,
                0.213257f,  -0.741531f, -0.000050f,
                0.258469f,  -0.786743f, -0.000050f,
                0.310813f,  -0.823760f, -0.000050f,
                0.369226f,  -0.851518f, -0.000050f,
                0.432643f,  -0.868952f, -0.000050f,
                0.500000f,  -0.875000f, -0.000050f,
                0.567358f,  -0.868952f, -0.000050f,
                0.630774f,  -0.851518f, -0.000050f,
                0.689187f,  -0.823760f, -0.000050f,
                0.741531f,  -0.786743f, -0.000050f,
                0.786743f,  -0.741531f, -0.000050f,
                0.823760f,  -0.689187f, -0.000050f,
                0.851517f,  -0.630774f, -0.000050f,
                0.868952f,  -0.567358f, -0.000050f,
            };

            float[] data =
            {
            // .Color                               Texture coordinates
            // .R           G           B           U           V
                0.000000f,  1.000000f,  0.000000f,  1.000000f,  -0.000000f, // Triangle
                0.000000f,  0.000000f,  1.000000f,  0.500000f,  -1.000000f,
                1.000000f,  0.000000f,  0.000000f,  0.000000f,  -0.000000f,

                1.000000f,  0.000000f,  0.000000f,  0.000000f,  -0.000000f, // Square
                0.000000f,  1.000000f,  0.000000f,  1.000000f,  -0.000000f,
                0.000000f,  0.000000f,  1.000000f,  1.000000f,  -1.000000f,
                0.000000f,  0.000000f,  1.000000f,  0.000000f,  -1.000000f,

                0.000000f,  1.000000f,  0.000000f,  1.000000f,  -0.500000f, // Hexagon
                1.000000f,  0.000000f,  0.000000f,  0.750000f,  -1.000000f,
                1.000000f,  0.000000f,  0.000000f,  0.250000f,  -1.000000f,
                0.000000f,  1.000000f,  0.000000f,  0.000000f,  -0.500000f,
                0.000000f,  0.000000f,  1.000000f,  0.250000f,  -0.000000f,
                0.000000f,  0.000000f,  1.000000f,  0.750000f,  -0.000000f,

                1.000000f,  0.000000f,  0.000000f,  1.000000f,  -0.500000f, // Circle
                0.944444f,  0.000000f,  0.000000f,  0.991936f,  -0.589810f,
                0.888888f,  0.000000f,  0.000000f,  0.968690f,  -0.674366f,
                0.833333f,  0.000000f,  0.000000f,  0.931680f,  -0.752249f,
                0.777777f,  0.000000f,  0.000000f,  0.882324f,  -0.822041f,
                0.722222f,  0.000000f,  0.000000f,  0.822041f,  -0.882324f,
                0.666666f,  0.000000f,  0.000000f,  0.752249f,  -0.931680f,
                0.611111f,  0.000000f,  0.000000f,  0.674366f,  -0.968690f,
                0.555555f,  0.000000f,  0.000000f,  0.589810f,  -0.991936f,
                0.500000f,  0.000000f,  0.000000f,  0.500000f,  -1.000000f,
                0.444444f,  0.000000f,  0.000000f,  0.410190f,  -0.991936f,
                0.388888f,  0.000000f,  0.000000f,  0.325634f,  -0.968690f,
                0.333333f,  0.000000f,  0.000000f,  0.247751f,  -0.931680f,
                0.277777f,  0.000000f,  0.000000f,  0.177959f,  -0.882324f,
                0.222222f,  0.000000f,  0.000000f,  0.117676f,  -0.822041f,
                0.166666f,  0.000000f,  0.000000f,  0.068320f,  -0.752249f,
                0.111111f,  0.000000f,  0.000000f,  0.031310f,  -0.674366f,
                0.055555f,  0.000000f,  0.000000f,  0.008064f,  -0.589810f,
                0.111111f,  0.000000f,  0.000000f,  0.000000f,  -0.500000f,
                0.166666f,  0.000000f,  0.000000f,  0.008064f,  -0.410190f,
                0.222222f,  0.000000f,  0.000000f,  0.031310f,  -0.325634f,
                0.277777f,  0.000000f,  0.000000f,  0.068320f,  -0.247751f,
                0.333333f,  0.000000f,  0.000000f,  0.117676f,  -0.177959f,
                0.388888f,  0.000000f,  0.000000f,  0.177959f,  -0.117676f,
                0.444444f,  0.000000f,  0.000000f,  0.247751f,  -0.068320f,
                0.500000f,  0.000000f,  0.000000f,  0.325634f,  -0.031310f,
                0.555555f,  0.000000f,  0.000000f,  0.410190f,  -0.008064f,
                0.611111f,  0.000000f,  0.000000f,  0.500000f,  -0.000000f,
                0.666666f,  0.000000f,  0.000000f,  0.589810f,  -0.008064f,
                0.722222f,  0.000000f,  0.000000f,  0.674366f,  -0.031310f,
                0.777777f,  0.000000f,  0.000000f,  0.752249f,  -0.068320f,
                0.833333f,  0.000000f,  0.000000f,  0.822041f,  -0.117676f,
                0.888888f,  0.000000f,  0.000000f,  0.882324f,  -0.177959f,
                0.944444f,  0.000000f,  0.000000f,  0.931680f,  -0.247751f,
                1.000000f,  0.000000f,  0.000000f,  0.968690f,  -0.325634f,
                1.000000f,  0.000000f,  0.000000f,  0.991936f,  -0.410190f,
            };

            int[] indices =
            {
                0, 1, 2, // Triangle
                3, 4, 5, 5, 6, 3, // Square
                10, 7, 8, 9, 8, 10, 11, 7, 10, 11, 12, 7, // Hexagon
                13, 14, 15, 13, 15, 16, 13, 16, 17, 13, 17, 18, 13, 18, 19, 13, 19, 20, 13, 20, 21, 13, 21, 22, // Circle
                13, 22, 23, 13, 23, 24, 13, 24, 25, 13, 25, 26, 13, 26, 27, 13, 27, 28, 13, 28, 29, 13, 29, 30,
                13, 30, 31, 13, 31, 32, 13, 32, 33, 13, 33, 34, 13, 34, 35, 13, 35, 36, 13, 36, 37, 13, 37, 38,
                13, 38, 39, 13, 39, 40, 13, 40, 41, 13, 41, 42, 13, 42, 43, 13, 43, 44, 13, 44, 45, 13, 45, 46,
                13, 46, 47, 13, 47, 48,
            };

            this.vbo = new VertexBufferObject(data);

            this.posVbo = new VertexBufferObject(positionData);

            VertexFormat vertexFormat = new VertexFormat();
            vertexFormat.AddAttribute(this.posVbo, VertexAttributeType.Position);
            vertexFormat.AddAttributesGroup(this.vbo, VertexAttributeType.Color, VertexAttributeType.TexCoord0);

            this.vao = new VertexArrayObject(vertexFormat);

            this.ebo = new ElementBufferObject(indices);

            this.shader = new Shader("HelloIndex");

            this.texture = Texture.LoadFromFile("Uv_checker_01.png", TextureUnit.Texture0);

            GL.ClearColor(0.1f, 0.1f, 0.2f, 1.0f);
        }

        /// <inheritdoc/>
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            this.texture.Use(TextureUnit.Texture0);

            this.shader.Use();

            Draw.Elements(this.vao, this.ebo.IndexCount);

            this.SwapBuffers();
        }

        /// <inheritdoc/>
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            this.fpsCounter.Update(args);
        }

        /// <inheritdoc/>
        protected override void OnUnload()
        {
            base.OnUnload();

            this.vao.Dispose();
            this.vbo.Dispose();
            this.posVbo.Dispose();
            this.ebo.Dispose();
            this.shader.Dispose();
            this.texture.Dispose();
        }
    }
}
