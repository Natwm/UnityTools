Shader "Custom/MultiplyColorWithGradientAlpha"
{
    Properties
    {
        _Color("Tint Color", Color) = (1, 1, 1, 1)
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

            uniform float4 _Color;
            sampler2D _MainTex;

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
                texColor.rgb *= _Color.rgb; // Applique la multiplication (Blend Mode "Multiply") avec la couleur
                texColor.a *= i.texcoord.y; // Applique le dégradé sur l'alpha en fonction de la coordonnée Y de l'UV
                return texColor;
            }
            ENDCG
        }
    }
}
