Shader "Custom/InvisibleMan_ScreenUV"
{
    Properties
    {
        _MainTex("Background RT", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Back

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPos = o.vertex;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 screenUV = i.screenPos.xy / i.screenPos.w;
                screenUV = screenUV*0.5 + 0.5; // NDC[-0.5,0.5] Å® UV[0,1]
                screenUV.y = 1.0 - screenUV.y;   // Yé≤îΩì]

                // RenderTextureÇ©ÇÁÉXÉNÉäÅ[ÉìUVÇ≈éÊìæ
                fixed4 col = tex2D(_MainTex, screenUV);
                return col;
            }
            ENDCG
        }
    }
}