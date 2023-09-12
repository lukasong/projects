Shader "luka/randoms/Fire/Real"
{
    Properties
    {
        [Space(5)]
        [Header(General Settings)]
        [Space(10)]
        _MaskTex ("Mask", 2D) = "" {}
        _Brightness ("Brightness", Range(0, 10)) = 2
        _MaxEmission ("Max Brightness", Range(0, 10)) = 1.5
        _AlphaMultiplier ("Alpha Multiplier", Range(0, 10)) = 2
        _MaxAlpha ("Max Alpha", Range(0, 10)) = 1.5
        [HDR] _ColorTop ("Top Color", Color) = (1, 0.4, 0.2, 1)
        [HDR] _Color ("Bottom Color", Color) = (1, 0.05, 0, 1)
        [Space(20)]
        [Header(Distortion Settings)]
        [Space(10)]
        _DistortionTex ("Distortion Texture", 2D) = "" {}
        _DistortionScale ("Distortion Scale", Range(0, 2)) = 0.5
        _DistortionSpeed ("Distortion Speed", Range(0, 1)) = 0.5
        _DistortionPower  ("Distortion Power", Range(0, 0.25)) = 0.05
        [Space(20)]
        [Header(Dissolve Settings)]
        [Space(10)]
        _DissolveTex ("Dissolve Texture", 2D) = "" {}
        _DissolveScale ("Dissolve Scale", Range(0, 2)) = 0.5
        _DissolveSpeed ("Dissolve Speed", Range(0, 1)) = 0.5
        _DissolvePower  ("Dissolve Power", Range(0, 0.25)) = 0.05
        _DissolveMoreAtTop ("Dissolve More At Top", Range(0, 1)) = 1
    }
    SubShader
    {

        // rendering settings
        Tags { "RenderType" = "Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex physics
            #pragma fragment pixel
            #include "UnityCG.cginc"

            // structures
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 gradient : TEXCOORD1;
            };

            // vertex properties
            sampler2D _MaskTex;
            float4 _MaskTex_ST;
            float4 _Color, _ColorTop;

            // vertex program
            v2f physics(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MaskTex);
                o.gradient = lerp(_Color, _ColorTop, v.uv.y);
                return o;
            }

            // pixel functions
            float approx_pow(float a, float b)
            {
                return a / ((1. - b) * a + b);
            }

            // pixel properties
            float _Brightness, _MaxEmission;
            float _AlphaMultiplier, _MaxAlpha;
            sampler2D _DistortionTex;
            float _DistortionScale, _DistortionSpeed, _DistortionPower;
            sampler2D _DissolveTex;
            float _DissolveScale, _DissolveSpeed, _DissolvePower;
            float _DissolveMoreAtTop;

            // pixel program
            float4 pixel (v2f i) : SV_Target
            {
                // sample + apply distortion
                float2 distortion_uv = frac(frac(i.uv * _DistortionScale) - float2(0, _Time.y * _DistortionSpeed));
                float distortion_offset = tex2D(_DistortionTex, distortion_uv).r;
                i.uv = lerp(i.uv, float2(distortion_offset, distortion_offset), _DistortionPower);
                i.uv = lerp(i.uv, i.uv + float2(0.5, 0), _DistortionPower); // re-center
                // sample initial texture + mask
                fixed4 final_col = float4(1, 1, 1, 1);
                final_col.a = tex2D(_MaskTex, i.uv).r;
                final_col.rgb *= i.gradient.rgb;
                // sample + apply dissolve
                float2 dissolve_uv = frac(frac(i.uv * _DissolveScale) - float2(0, _Time.y * _DissolveSpeed));
                float dissolve_power = tex2D(_DissolveTex, dissolve_uv).r;
                dissolve_power = pow(dissolve_power, _DissolvePower);
                dissolve_power *= distortion_offset;
                dissolve_power = lerp(dissolve_power, dissolve_power * (1.0 - i.uv.y), _DissolveMoreAtTop);
                final_col.a *= dissolve_power;
                // apply brightness
                final_col.rgb *= _Brightness;
                final_col.rgb = clamp(final_col.rgb, 0, _MaxEmission);
                // apply alpha
                final_col.a *= _AlphaMultiplier;
                final_col.a = clamp(final_col.a, 0, _MaxAlpha);
                return final_col;
            }

            ENDCG
        }
    }
    FallBack "Standard"
    CustomEditor "Luka.FireUI"
}
