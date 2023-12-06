Shader "Custom/MultiplyWithCustomGradientFromImage"
{
    Properties
    {
        _Color1("Color 1", Color) = (1, 1, 1, 1)
        _Color2("Color 2", Color) = (0, 0, 0, 1)
        _GradientDirection("Gradient Direction (0=Vertical, 1=Horizontal)", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };

            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float _GradientDirection;
            sampler2D _MainTex; // Texture source de l'objet Image UI

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 texColor = tex2D(_MainTex, i.texcoord);
                float gradientValue = (_GradientDirection == 0.0) ? i.texcoord.y : i.texcoord.x;
                fixed4 gradientColor = lerp(_Color1, _Color2, gradientValue);
                texColor.rgb *= gradientColor.rgb; // Multiplication de la couleur
                texColor.a *= gradientColor.a; // Modification de l'alpha en fonction du dégradé
                return texColor;
            }
            ENDCG
        }
    }
}
