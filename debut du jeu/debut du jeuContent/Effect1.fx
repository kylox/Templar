sampler2D m_texture;

float4 MyShader(float2 Tex : TEXCOORD0) : COLOR0
{
    float4 Color;

	Color = tex2D( m_texture, Tex)

    return Color;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 Myshader();
    }
}
