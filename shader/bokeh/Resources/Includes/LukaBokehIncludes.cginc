// copyright notice will go here.
#ifndef LUKA_BOKEH_INCLUDES
#define LUKA_BOKEH_INCLUDES

// STRUCTURES
struct v2f // vertex to fragment
{
    float4 grabPos : TEXCOORD0;
    float4 pos : SV_POSITION;
    float4 worldDir : TEXCOORD1;
    float3 worldPos : TEXCOORD2;
    bool render : TEXCOORD3;
};

// DECLARATIONS
#define BOKEH_LUKA_INITER_SCREENSPACE(tex) sampler2D tex
#define BOKEH_LUKA_SAMPLER_SCREENSPACE(tex, coords) tex2D(tex, coords)
#define BOKEH_LUKA_INITER_DEPTH(depth) UNITY_DECLARE_DEPTH_TEXTURE(depth)
#define BOKEH_LUKA_SAMPLER_DEPTH(depth, coords) SAMPLE_DEPTH_TEXTURE(depth, coords)

// BRANCH SPECIFIC DEFINES
#if defined(_BOKEH_HD)
    #define BOKEH_SQRT_SAMPLES 22 
    #define BOKEH_CLEANER 5
#else // _BOKEH_HD
    #define BOKEH_SQRT_SAMPLES 14
    #define BOKEH_CLEANER 5
#endif // _BOKEH_HD

// SHADER PROPERTIES
float _Power;
float _Dithering;

// INITS
#if defined(BOKEH_PASS_THREE)
    BOKEH_LUKA_INITER_SCREENSPACE(_BokehGrabThree);
    BOKEH_LUKA_INITER_SCREENSPACE(_BokehGrabTwo);
    float _ColorGrading, _Exposure, _ColorMode;
    float _HSVMode, _Hue, _Saturation, _Value, _HSVTapBased;
    float4 _Color;
    sampler2D _Guide;
    float4 _Guide_ST;
    #if defined(_BOKEH_RANDOMIZED)
        float _GuideRandomizeStyle, _GuideRandomizeVariation, _GuideRandomizeSpeed, _GuideRandomizeX, _GuideRandomizeY;
    #endif // _BOKEH_RANDOMIZED
    #if defined(_BOKEH_ANIMATION)
        float _AnimationVariation;
        float _AnimationRotation, _AnimationRotationSpeed;
        float _AnimationScale, _AnimationScaleSpeed, _AnimationScalePower, _AnimationScaleMinimum, _AnimationScaleMaximum;
    #endif // _BOKEH_ANIMATION
#elif defined(BOKEH_PASS_TWO)
    BOKEH_LUKA_INITER_SCREENSPACE(_BokehGrabTwo);
    #if defined(_BOKEH_CLEAN)
        float _BlendingRadius;
    #endif // _BOKEH_CLEAN
#else // BOKEH PASS ONE
    float _FocalMode, _ManualFocus, _FocalX, _FocalY;
    float _Aperature, _BokehPower, _FarPlane, _MaxDiameter;
    float _Accentuate;
    float _FactorDepth, _FactorDepthCutoff, _FactorDepthInfluence;
    float _FactorLuma, _FactorLumaInfluence, _FactorLumaMinimum;
    #if defined(_BOKEH_CLEAN)
        float _CocSpread;
    #endif // _BOKEH_CLEAN
    float4 _CameraDepthTexture_ST;
#endif // BOKEH PASS
BOKEH_LUKA_INITER_SCREENSPACE(_BokehGrabOne);
BOKEH_LUKA_INITER_DEPTH(_CameraDepthTexture);

// INCLUDED CG FILES
#include "Resources/Includes/LukaBokehCommon.cginc"
#include "Resources/Includes/LukaBokehSampler.cginc"

#endif // LUKA_BOKEH_INCLUDES