﻿namespace Nine.Graphics
{
    using System;
    using System.Threading.Tasks;
    using Nine.Injection;
    using Xunit;

    [Trait("ci", "false")]
    public class SpriteRendererTest : GraphicsTest
    {
        public static readonly TheoryData<Type, Type, string> Dimensions = new TheoryData<Type, Type, string>
        {
            { typeof(OpenGL.GraphicsHost), typeof(OpenGL.SpriteRenderer), "Content/Logo.png" },
        };

        [Theory]
        [MemberData(nameof(Dimensions))]
        public async Task draw_an_image(Type hostType, Type rendererType, string texture)
        {
            await Container.Get<ITextureLoader>().Load(texture);

            using (Frame(hostType))
            {
                var renderer = Container.Get(rendererType) as IRenderer<Sprite>;
                renderer.Draw(new[] { new Sprite(texture) }, null);
            }
        }
    }
}
