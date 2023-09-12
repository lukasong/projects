Shader "luka/randoms/bokeh studio"
{
    Properties
    {
        // guide settings
        // [Header(Guide Settings)]
        // [Space(5)]
        _Guide ("Guide Map", 2D) = "" {}
        [Enum(LOCATION, 0, TIME, 1, BOTH, 2)] _GuideRandomizeStyle ("Randomize Guide", Range(0, 2)) = 2
        _GuideRandomizeSpeed ("Randomize Speed", Range(0, 0.75)) = 0
        [PowerSlider(2.0)] _GuideRandomizeVariation ("Randomize Variation", Range(1, 20)) = 100
        _GuideRandomizeX ("Random X Rows", Float) = 2
        _GuideRandomizeY ("Random Y Rows", Float) = 2
        // focal controls
        // [Header(Focal Controls)]
        // [Space(5)]
        [Enum(MANUAL, 0, AUTOMATIC, 1, ALWAYS, 2)] _FocalMode ("Focal Mode", Range(0, 2)) = 2
        _ManualFocus ("Manual Focus", Range(0, 1)) = 0
        _FocalX ("Focal X", Range(0, 1)) = 0.5
        _FocalY ("Focal Y", Range(0, 1)) = 0.5
        // camera controls
        // [Header(Camera Controls)]
        // [Space(5)]
        _Power ("Shape Size", Range(0, 10)) = 0.01
        _BokehPower ("Bokeh Power",  Range(0, 1)) = 0.1
        _Aperature ("Aperature", Range(0.01, 5)) = 0.5
        // variables
        // [Header(Factor Controls)]
        // [Space(5)]
        [Enum(DISABLED, 0, ENABLED, 1)] _FactorDepth ("Factor in Depth", Range(0, 1)) = 1
        _FactorDepthCutoff ("Depth Close-Up End", Range(0, 1)) = 0.5
        _FactorDepthInfluence ("Depth Close-Up Influence", Range(0, 1)) = 0.65
        [Enum(DISABLED, 0, ENABLED, 1)] _FactorLuma ("Factor in Luma", Range(0, 1)) = 0
        _FactorLumaInfluence ("Luma Influence", Range(0, 1)) = 0.5
        _FactorLumaMinimum ("Luma Minimum", Range(0, 0.5)) = 0.15
        // animation
        // [Header(Animation Controls)]
        // [Space(5)]
        [PowerSlider(2.0)] _AnimationVariation ("Animation Variation", Range(1, 20)) = 4
        [Enum(DISABLED, 0, UNIVERSAL, 1, LOCAL, 2)] _AnimationRotation ("Rotate Bokehs", Range(0, 1)) = 0
        _AnimationRotationSpeed ("Rotation Speed", Range(0, 1)) = 0.5
        [Enum(DISABLED, 0, UNIVERSAL, 1, LOCAL, 2)] _AnimationScale ("Scale Bokehs", Range(0, 1)) = 0
        _AnimationScaleSpeed ("Scale Speed", Range(0, 10)) = 0.5
        _AnimationScalePower ("Scale Power", Range(0, 1)) = 0.5
        [PowerSlider(2.0)] _AnimationScaleMinimum ("Scale Minimum", Range(3, 1)) = 2
        [PowerSlider(2.0)] _AnimationScaleMaximum ("Scale Maximum", Range(1, 0.5)) = 1
        // clean edges
        // [Header(Clean Edges)]
        // [Space(5)]
        _BlendingRadius ("Blending Radius", Range(0, .1)) = 0.01
        _CocSpread ("CoC Spread", Float) = 0.05
        // [Header(Lighting Controls)]
        // [Space(5)]
        _Accentuate ("Accentuate Bokehs", Range(0, 1)) = 0
        [PowerSlider(0.5)] _Exposure ("Expose Bokehs", Range(1, 75)) = 1
        [PowerSlider(0.5)] _ColorGrading ("Tonemap Bokehs", Range(0, 30)) = 0
        [Enum(DISABLED, 0, TAP BASED, 1, SCREEN BASED, 2)] _ColorMode ("Color Mode", Range(0, 2)) = 0
        _Color ("Color", Color) = (1, 1, 1, 1)
        [Enum(DISABLED, 0, ADD, 1, MULTIPLY, 2)] _HSVMode ("HSV Mode", Range(0, 1)) = 0
        [Enum(DISABLED, 0, ENABLED, 1)] _HSVTapBased ("HSV Tap Based", Range(0, 1)) = 0
        _Hue ("Hue", Range(-2, 2)) = 1
        _Saturation ("Saturation", Range(0, 2)) = 1
        _Value ("Value", Range(0, 2)) = 1
        // technical controls
        // [Header(Technical Controls)]
        // [Space(5)]
        _CullDistance ("Cull Distance", Range(0.1, 100)) = 10
        [PowerSlider(2.0)] _Dithering ("Dithering", Range(0, 10)) = 0.2
        _MaxDiameter ("Max Diameter", Range(0, 1.5)) = 0.5
        _FarPlane ("Far Plane", Range(0, 5)) = 1
        [Enum(DISABLED, 0, ENABLED, 1)] _VRChatPreview ("VRChat Preview", Range(0, 1)) = 0
        // branching properties
        [Enum(DISABLED, 0, ENABLED, 1)] _Randomize ("Randomize", Range(0, 1)) = 0 
        [Enum(DISABLED, 0, ENABLED, 1)] _Animate ("Animate", Range(0, 1)) = 0
        [Enum(DISABLED, 0, ENABLED, 1)] _Clean ("Clean", Range(0, 1)) = 0 
        [Enum(DISABLED, 0, ENABLED, 1)] _VRChat ("VRChat", Range(0, 1)) = 0
        [Enum(DISABLED, 0, ENABLED, 1)] _HD ("HD", Range(0, 1)) = 0
        // editor settings
        [Enum(ENGLISH, 0, DEUTSCH, 1, JAPANESE, 2)] _Language ("Language", Range(0, 2)) = 0 // sorry for the romanization, shaderlab metadata limitations
    }
    SubShader
    {

        // render settings
		Tags 
		{
			"RenderType" = "Transparent"
			"Queue" = "Overlay+2000"
			"LightMode" = "Always"
			"DisableBatching"="True" 
			"ForceNoShadowCasting" = "True" 
			"VRCFallback" = "Hidden"
		}
        ZTest Always
        Cull Off

        // PASS ONE: TAP CENTER OF CONFUSION
        GrabPass {  Tags { "LightMode" = "ForwardBase" } "_BokehGrabOne" }
        Pass
        {

            // TAGS AND INCLUDES
            Tags {"LightMode" = "ForwardBase" }
            CGPROGRAM
            #pragma vertex physics
            #pragma fragment pixel
            #pragma skip_variants LIGHTMAP_SHADOW_MIXING LIGHTMAP_ON DYNAMICLIGHTMAP_ON SHADOWS_SCREEN SHADOWS_SHADOWMASK DIRLIGHTMAP_COMBINED
            #pragma shader_feature_local _BOKEH_CLEAN
            #pragma shader_feature_local _BOKEH_VRCHAT
            #include "UnityCG.cginc"
            #define BOKEH_PASS_ONE
            #include "Resources/Includes/LukaBokehIncludes.cginc"

            // PIXEL PROGRAM
            float4 pixel(v2f i) : SV_Target
            {
                float2 normalized = i.grabPos.xy / i.grabPos.w;
                float4 screenColor = tex2D(_BokehGrabOne, normalized);
                if (i.render == false) {
                    return screenColor;
                }
                screenColor = Pass_One(screenColor, normalized, i);
                return screenColor;
            }

            // DONE 
            ENDCG
        }

        // PASS TWO: BLUR CENTER OF CONFUSION
        GrabPass {  Tags { "LightMode" = "ForwardBase" } "_BokehGrabTwo" }
        Pass
        {

            // TAGS AND INCLUDES
            Tags {"LightMode" = "ForwardBase" }
            CGPROGRAM
            #pragma vertex physics
            #pragma fragment pixel
            #pragma shader_feature_local _BOKEH_CLEAN
            #pragma shader_feature_local _BOKEH_VRCHAT
            #include "UnityCG.cginc"
            #define BOKEH_PASS_TWO
            #include "Resources/Includes/LukaBokehIncludes.cginc"

            // PIXEL PROGRAM
            float4 pixel(v2f i) : SV_Target
            {
                float2 normalized = i.grabPos.xy / i.grabPos.w;
                float4 screenColor = tex2D(_BokehGrabTwo, normalized);
                if (i.render == false) {
                    return screenColor;
                }
                screenColor = Pass_Two(screenColor, normalized, i);
                return screenColor;
            }

            // DONE 
            ENDCG
        }

        // PASS THREE: BLUR THE SCREEN
        GrabPass {  Tags { "LightMode" = "ForwardBase" } "_BokehGrabThree" }
        Pass
        {

            // TAGS AND INCLUDES
            Tags {"LightMode" = "ForwardBase" }
            CGPROGRAM
            #pragma vertex physics
            #pragma fragment pixel
            #pragma shader_feature_local _BOKEH_HD 
            #pragma shader_feature_local _BOKEH_CLEAN
            #pragma shader_feature_local _BOKEH_RANDOMIZED
            #pragma shader_feature_local _BOKEH_ANIMATION
            #pragma shader_feature_local _BOKEH_VRCHAT
            #include "UnityCG.cginc"
            #define BOKEH_PASS_THREE
            #include "Resources/Includes/LukaBokehIncludes.cginc"

            // PIXEL PROGRAM
            float4 pixel(v2f i) : SV_Target
            {
                float2 normalized = i.grabPos.xy / i.grabPos.w;
                float4 screenColor = tex2D(_BokehGrabThree, normalized);
                if (i.render == false) {
                    return screenColor;
                }
                screenColor = Pass_Three(screenColor, normalized, i);
                return screenColor;
            }

            // DONE 
            ENDCG
        }

    }

    CustomEditor "Luka.BokehUI"
    Fallback "Diffuse"
}