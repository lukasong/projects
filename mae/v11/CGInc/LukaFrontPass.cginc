//|===============================================|
//|				  license   					  |
//|===============================================|
//shader author: luka (lukasong on github, luka#8375 on discord, luka! in vrchat)
//license: this shader is to not be redistrubted or resold in any format and is limited to the buyer exclusively
//version 11.0 (July 30,  2019)



//|===============================================|
//|				 includes   					  |
//|===============================================|
#include "UnityCG.cginc"



//|===============================================|
//|				 structures 					  |
//|===============================================|
struct v2f
{
	float4 grabPos : TEXCOORD0;
	float4 pos : SV_POSITION;
	float2 uv0 : TEXCOORD1;
	float4 overlayCoordinates : TEXCOORD3;
	float4 tex : TEXCOORD4;
	float3 cameraPos : TEXCOORD5;
	float3 raycast : TEXCOORD6;
	float4 depthUV: TEXCOORD7;
	float4 center: TEXCOORD8;
	float4 vzoomUV : TEXCOORD9;
	float4 fadeProjUV : TEXCOORD12;
};
struct appdata {
	float4 vertex : POSITION;
	float2 uv : TEXCOORD1;
	float4 depthUV : TEXCOORD3;
};
struct VertexInput {
	float4 vertex : POSITION;
	float2 texcoord0 : TEXCOORD1;
	float4 worldPos : TEXCOORD2;
};
struct VertexOutput {
	float4 pos : SV_POSITION;
	float4 projPos : TEXCOORD0;
};



//|===============================================|
//|				  initialize  					  |
//|===============================================|
//declaring values
uniform sampler2D _LukaFrontPass;
uniform float4 __LukaFrontPass_ST;
sampler2D _emptyTex;
float4 _emptyTex_ST;

//falloff
float _FalloffRange, _ZoomRangeIncrease, _ToggleRenderLookAtMe, _RenderMeTolerance, _AllowSmartFalloff, _SmartFalloffMin, _SmartFalloffMax;

//screenspace
float _InvertStrength, _SepiaStrength, _InvertG, _InvertB, _InvertR, _InvertMode;
float4 _SepiaColor;

//color
float _ColorHue, _ColorSaturation, _ColorValue;
float4 _ColorRGB;

//static
float _ToggleNoise, _StaticIntensity, _ToggleAnimatedNoise, _StaticSpeed, _StaticBlack, _ToggleStaticMap, _StaticOverlay, _StaticSize;
float4 _StaticColor, _StaticMap_ST;
sampler2D _StaticMap;

//darken
float _DarknessStrength;

//pixelate
float _TogglePixelate, _PixelateStrength, _PixelateStrengthY;

//glitchy pixelate
float _GTogglePixelate, _GPixelStrength, _GPixelStrengthY, _GPixelFreq;
sampler2D _GPixelGlitchMap;

//deepfry 
float _ToggleDeepfry, _DeepfryValue, _DeepfryBrightness, _DeepfryEmbossPower;

//ramp
float _ToggleRampEffect, _RampColorChannel, _RampOneLighting, _ToggleRampOneAnimate, _RampOneStrength, _RampOneSpeed, _RampOneDepth;
sampler2D _RampMap;
float4 _RampMap_ST;

//zoom
float _ToggleZoom, _ToggleFlipZoom, _ZoomInValue, _ZoomOutValue, _SmoothZoom, _SmoothZoomTolerance;

//screen zoom
float _ToggleScreenZoom, _ScreenZoomInValue, _ScreenZoomOutValue;

//glitch
float _ToggleGlitch, _GlitchRedDistort, _RedYGlitch, _RedXGlitch, _RedTileGlitch, _ToggleRandomGlitch, _GlitchRandomize, _XGAnimate, _YGAnimate, _GlitchSideFactor, _TileGAnimate, _ToggleRandomSideGlitch;
sampler2D _GlitchRedMap, _GlitchNoiseMap;
float4 _GlitchRedMap_ST, _GlitchBlueMap_ST, _GlitchNoiseMap_ST;

//outline 
float _ToggleOutline, _OutlineSepiaAmount, _OutlineOffset, _OutlineModOne, _OutlineModTwo, _OutlineModThree, _OutlineModFour, _OutlineActualOffset;

//radial blur 
float _ToggleRadialBlur, _RadialBlurDistance, _RadialBlurHorizontalCenter, _RadialBlurVerticalCenter,
_RBToggleED, _RBEDTolerance, _RBEDTrans, _RBEDWidth, _RBEDBW, _RBEDToggleRainbow, _RBEDToggleHSVRainbowX, _RBEDToggleHSVRainbowY, _RBEDHSVRainbowHue,
_RBEDHSVRainbowSat, _RBEDHSVRainbowLight, _RBEDHSVRainbowTime, _RBEDBackPower, _RBDither, _RBDitherSpeed, _RBToggleRainbow, _RBToggleHSVRainbowX,
_RBToggleHSVRainbowY, _RBHSVRainbowHue, _RBHSVRainbowSat, _RBHSVRainbowLight, _RBHSVRainbowTime, _RBRotate, _RBRotateSpeed, _RBCAOffset, _RBCATrans, _RBEmpower, _RBMode, _RBItterations, _RBEDOnly, _RBEDBalance,
_RBGrainPower, _RBGrainSpeed, _RBGrainBlack;
float4 _RBEDBackColor, _RBEDColor, _RBGrainColor;

//recolor 
float _ToggleRecolor, _RecolorBright, _RecolorSat, _RecolorHue, _RecolorSpeed, _ToggleRecolorAnimate;

//droplet
float4 _DropletColOne, _DropletColTwo, _TwoDropletColOne, _TwoDropletColTwo, _ThreeDropletColOne, _ThreeDropletColTwo, _FourDropletColOne, _FourDropletColTwo;
float _DropletTolerance, _DropletIntensity, _ToggleDroplet, _ToggleDropletSepia, _ToggleDropletTwo, _TwoDropletTolerance, _TwoDropletIntensity, _ToggleDropletThree, _ThreeDropletTolerance, _ThreeDropletIntensity,
_ToggleDropletFourth, _FourDropletTolerance, _FourDropletIntensity;

//filter
float _ToggleFilter, _ToggleAdvancedFilter, _ToggleHSVFilter, _ToggleColoredFilter, _FilterTolerance, _FilterMinR, _FilterMaxR, _FilterMinG, _FilterMaxG, _FilterMinB, _FilterMaxB, _FilterIntensity, _BackgroundFilterIntensity;
float4 _FilterColor, _BackgroundFilterColor;

//bloom 
float _BloomGlow;

//bloom
float _RBloomQuality, _RBloomStrength, _RBloomBright, _RBloomOpacity, _RBloomDepth, _RBloomToggle;
float4 _RBloomColor;

//smear 
float _ToggleSmear, _CSDirection, _CSAutoRotate, _CSRotateSpeed, _CSRed, _CSGreen, _CSBlue, _CSCopies, _CSUseAdvanced, _CSRotateSpeedSinXR, _CSRotateSpeedCosXR, _CSRotateSpeedSinYR;

//vhs 
float _VHSXDisplacement, _VHSYDisplacement, _ToggleVHS, _shadowStrength, _darkness, _waveyness, _ToggleSmoothWave;

//posterize 
float _PosterizeValue;

//linocut
float _LinocutPower, _LinocutOpacity;
float4 _LinocutColor;

//edge detect
float _ToggleED, _EDTolerance, _EDGlow, _EDTrans, _EDXOffset, _EDYOffset, _EDBW, 
_EDToggleRainbow, _EDToggleHSVRainbowX, _EDToggleHSVRainbowY, _EDHSVRainbowHue, _EDHSVRainbowSat, _EDHSVRainbowLight, _EDHSVRainbowTime;
float4 _EDColor;

//edge width stuff
float _EDWidth, _EPWidth, _ROWidth, _EDRampScroll;

//edge dither stuff
float _EDDither, _EDDitherSpeed;

//scanline
float _ToggleScanline, _ScanlinePush, _ScanlineSize, _ScanlineSpeed, _ScanlineDir;

//blocky glitch
float _ToggleBlockyGlitch, _AllowBGX, _AllowBGY, _BDepthX, _BDepthY, _BlockyGlitchStrength, _BGRandomnessInc, _BlockyGlitchSpeed;
sampler2D _BlockGlitchMap;
float4 _BlockGlitchMap_ST;

//fade projection
float _ToggleFadeProjection, _FPFade, _FPZoom, _FadeLayer;
float4 _FPColor;

//duotone
float _ToggleDuotone, _DuotoneHardness, _DuotoneThreshold;
float4 _DuotoneColOne, _DuotoneColTwo;

//saturation
float _SaturationValue;

//sepia
float _SepiaRStrength, _SepiaRWarmth, _SepiaRTone;

//contrast
float _ContrastValue;

//gamma
float _GammaRed, _GammaGreen, _GammaBlue;

//vignette
float _ToggleVignette, _VigX, _VigColPow, _VigMode, _VigReverse, _VigSharpness;
float4 _VigCol;

//rgb zoom
float _ToggleRGBZoom, _RedZoom, _GreenZoom, _BlueZoom, _RGBZoomTrans, _RGBZoomTransG, _RGBZoomTransB;

//rainbow
float _ToggleHSVRainbow, _ToggleHSVRainbowX, _ToggleHSVRainbowY, _HSVRainbowHue, _HSVRainbowSat, _HSVRainbowLight, _HSVRainbowTime;

//ripple
float _ToggleRipple, _ShockCenterX, _ShockCenterY, _ShockDis, _ShockMag, _ShockSpread;

//depth
sampler2D_float _CameraDepthTexture;
float _AllowDepthTest, _DepthValue, _ReverseDepth;

//thermal
float _ThermalHeat, _ThermalSensitivity, _ThermalTransparency;
float4 _ThermalColor;

//ascii
float _ToggleAscii, _ASCIIVariation, _ASCIIPower, _ASCIIShapeOne, _ASCIIShapeTwo, _ASCIIShapeThree, _ASCIIShapeFour,
_ASCIIShapeFive, _ASCIIShapeSix, _ASCIIShapeSeven, _ASCIIShapeEight, _ASCIISpeed;

//girlscam
float _ToggleGirlscam, _GirlscamStrength, _GirlscamTime, _GirlscamDir;

//corner wheel
float _ToggleCC, _CCRotate, _CCApply, _CCSpeed;
float4 _CCOne, _CCTwo, _CCThree, _CCFour;

//color corner
float _CornerOneTrans, _CornerTwoTrans, _CornerThreeTrans, _CornerFourTrans;
float4  _CornerOneColor, _CornerTwoColor, _CornerThreeColor, _CornerFourColor;

//color gradient
float _GradTrans, _GradMode, _GradApply;
float4 _GradOne, _GradTwo;

//film
float _FilmPower, _FilmAllowLines, _FilmAllowSpots, _FilmAllowStripes, _FilmItterations, _FilmBrightness, _FilmJitterAmount, _FilmSpotStrength, _FilmLinesOften, _FilmSpotsOften, _FilmStripesOften;

//fog
float _ToggleFog, _FogDensity, _FogRainbow, _FogRainbowSpeed, _FogLayer, _FogSafe, _FogSafeTol;
float4 _FogColor;

//new blur
float _ToggleNBlur, _NBlurShape, _NBlurItterations, _NBlurPower, _NBlurSpeed, _NBlurRotate, _NBlurRotateSpeed, _NBlurX, _NBlurY, _NBlurOpacity, _NBlurGlow;
float4 _NBlurColor;

//big zoom
float _ToggleBigZoom, _BigZoomAmount, _BigZoomOutAmount, _BigZoomTolerance;

//shake
float _ShakeSpeed, _ShakeSpeed2, _ShakeStrength, _ShakeStrength2, _ToggleShake, _ToggleXYShake, _ShakeModel;

//distortion
float _ToggleDistortion, _DistortionX, _DistortionY, _DistortionXSpeed, _DistortionYSpeed, _DistortionRotate, _DistortionRotateSpeed, _DistortionTransparency;
sampler2D _DistortionMap;
float4 _DistortionMap_ST;

//screenpull
float _ToggleScreenpull, _ScreenpullStrength, _ScreenpullMode, _ScreenpullStrengthTwo;
sampler2D _ScreenpullMap;
float4 _ScreenpullMap_ST;

//pull
float _ApartMode, _Apart;
float4 _ApartColor;

//dizzy  
float _ToggleDizzyEffect, _DizzyMode, _DizzyAmountValue, _DizzyRotationSpeed;

//earthquake
float _SSAllowVerticalShake, _SSAllowHorizontalShake, _SSAllowVerticalBlur, _SSAllowHorizontalBlur, _SSValue, _SSSpeed, _SSValueVert, _SSSpeedVert, _SSTransparency;

//bulge
float _ToggleBulge, _BulgeIndent, _OwOStrength;

//edge distort
float _ToggleEdgeDistort, _EdgeDisX, _EdgeDisY, _ToggleEdgeDisRotate, _EdgeDisRotStr, _EdgeDisRotSpeed;

//swirl
float _ToggleSwirl, _SwirlPower, _SwirlCenterX, _SwirlCenterY, _SwirlRadius;

//splice
float _ToggleSplice, _SpliceTop, _SpliceBot, _SpliceXLimit, _SpliceLeft, _SpliceRight, _SpliceYLimit;

//screenspace
float _ToggleUpsideDown, _ToggleScreenFlip;

//mirror
float _ToggleMirror, _MirrorHU, _MirrorHO, _MirrorVU, _MirrorVO;

//warp
float _WarpHorizontal, _WarpVertical;

//rotater 
float _ToggleRotater, _ToggleRotaterAnimate, _RotaterValue, _RotaterSpin;

//screan tear fix
float _AllowTearFix, _TearToRepeat, _TearToMirror;
float4 _ScreenTearColor;

//silhouette
float _ToggleSilhouette, _SilhouetteDepth, _SilhouetteRainLayer, _SilhouetteRainbow, _SilhouetteRainbowSpeed, _SilhouetteLighting, _SilhouetteLightingMode;
float4 _SilhouetteFront, _SilhouetteBack;

//new depth stuff
float _KeepPlayerInFocus, _DepthPlayerTolerance, _DepthPlayerPower;

//zoom range
float _ToggleZoomRange, _ZoomRange, _ZoomFStart, _ZoomFEnd;

//solid color
float _SolidTrans;
float4 _SolidCol;

//overall transparency
float _OverallOpacity;

//edge background
float _EDBackPower;
float4 _EDBackColor;

//edge ramp map
sampler2D _EDRampMap;
float4 _EDRampMap_ST;
float _EDRampX, _EDRampY, _EDRampSX, _EDRampSY, _EDRampAllow;

//vibrance
float _VibrancePower;

//extra color stuff
float _ColorRGBtoHSV, _ColorHSVtoRGB;

//particle system
float _ParticleSystem;

//vr
float _VRAdjust, _VRPreview;

//noise mask
float _ToggleNoiseMask, _NoiseMaskSpeedOne, _NoiseMaskSpeedTwo, _NoiseMaskScale, _NoiseMaskGlow;
float3 _NoiseMaskColor;
sampler2D _NoiseMask;
float4 _NoiseMask_ST;

//wavey
float _ToggleWavey, _WavesX, _WavesXPower, _WavesXSpeed, _WavesY, _WavesYPower, _WavesYSpeed;

//scrol
float _ScrollX, _ScrollY;



//|===============================================|
//|				  functions   					  |
//|===============================================|
float grabEdgeLuma(float2 sceneUVs, float xCoord, float yCoord, float outlineWidth, float outlineTolerance, sampler2D _LukaFirstPass)
{

	//setting up uvs / screen texture
	float2 outlineUV = (sceneUVs.xy + float2(xCoord * outlineWidth, yCoord * outlineWidth)) / _ScreenParams.xy;
	float4 outlineScrnCol = tex2D(_LukaFirstPass, outlineUV.xy);

	//getting luma w/ applied tolerance
	float rTolerance = 0.2126 * outlineTolerance;
	float gTolerance = 0.7152 * outlineTolerance;
	float bTolerance = 0.0722 * outlineTolerance;
	return rTolerance * outlineScrnCol.r + gTolerance * outlineScrnCol.g + bTolerance * outlineScrnCol.b;

}

float3 createEdge(float2 sceneUVs, float outlineWidth, float outlineTolerance, float xOffset, float yOffset, float4 outlineColor, sampler2D _LukaFirstPass) {

	//creating uvs
	float2 adjustedUVs = float2(sceneUVs.x + xOffset, sceneUVs.y + yOffset) * _ScreenParams;

	//bluring to luma with edge detection, x
	float xTotal = 0.0;
	xTotal += -1.0 * grabEdgeLuma(adjustedUVs, -1.0, -1.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	xTotal += -2.0 * grabEdgeLuma(adjustedUVs, -1.0, 0.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	xTotal += -1.0 * grabEdgeLuma(adjustedUVs, -1.0, 1.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	xTotal += 1.0 * grabEdgeLuma(adjustedUVs, 1.0, -1.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	xTotal += 2.0 * grabEdgeLuma(adjustedUVs, 1.0, 0.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	xTotal += 1.0 * grabEdgeLuma(adjustedUVs, 1.0, 1.0, outlineWidth, outlineTolerance, _LukaFirstPass);

	//bluring to luma with edge detection, y
	float yTotal = 0.0;
	yTotal += -1.0 * grabEdgeLuma(adjustedUVs, -1.0, -1.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	yTotal += -2.0 * grabEdgeLuma(adjustedUVs, 0.0, -1.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	yTotal += -1.0 * grabEdgeLuma(adjustedUVs, 1.0, -1.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	yTotal += 1.0 * grabEdgeLuma(adjustedUVs, -1.0, 1.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	yTotal += 2.0 * grabEdgeLuma(adjustedUVs, 0.0, 1.0, outlineWidth, outlineTolerance, _LukaFirstPass);
	yTotal += 1.0 * grabEdgeLuma(adjustedUVs, 1.0, 1.0, outlineWidth, outlineTolerance, _LukaFirstPass);

	//applying and returning color
	float applied = xTotal * xTotal + yTotal * yTotal;
	float3 outlineReturn = outlineColor.rgb * applied;
	return outlineReturn;

}

float bitmapCharacter(float n, float2 p) 
{
	p = floor(p*float2(4.0, -4.0) + 2.5);
	if (clamp(p.x, 0.0, 4.0) == p.x && clamp(p.y, 0.0, 4.0) == p.y)
	{
		float a = float(n / exp2(p.x + 5.0*p.y));
		float b = float(2.0);
		float p = a - (b * floor(a / b));
		if (int(p) == 1) return 1.0;
	}
	return 0.0;
}

float rand(float n) {
	return frac(sin(n) * 43758.5453123);
}

float2 drawCircle(float Start, float Points, float Point)
{
	float Rad = (3.141592 * 2.0 * (1.0 / Points)) * (Point + Start);
	return float2(sin(Rad), cos(Rad));
}

float fracFunc(float x)
{
	//Girlscam Functions (See Girlscam)
	return x - floor(x);
}

float nrand(float x, float y)
{
	return fracFunc(sin(dot(float2(x, y), float2(12.9898, 78.233))) * 43758.5453);
}

float lerpFunc(float a, float b, float w) {
	return a + w * (b - a);
}

float randomLine(float seed, float2 uv)
{
	//Film Functions (See Film Grain)
	float b = 0.01 * rand(seed);
	float a = rand(seed + 1.0);
	float c = rand(seed + 2.0) - 0.5;
	float mu = rand(seed + 3.0);

	float l = 1.0;

	if (mu > 0.2)
		l = pow(abs(a * uv.x + b * uv.y + c), 1.0 / 8.0);
	else
		l = 2.0 - pow(abs(a * uv.x + b * uv.y + c), 1.0 / 8.0);

	return lerp(0.5, 1.0, l);
}

float randomBlotch(float seed, float2 uv, float spotSize)
{
	float x = rand(seed);
	float y = rand(seed + 1.0);
	float s = 0.01 * rand(seed + 2.0);

	float2 p = float2(x, y) - uv;
	p.x *= _ScreenParams.x / _ScreenParams.y;
	float a = atan2(p.y, p.x);
	float v = 1.0;
	float ss = s * s * (sin(6.2831*a*x)*0.1 + 1.0) * spotSize;

	if (dot(p, p) < ss) v = 0.2;
	else
		v = pow(dot(p, p) - ss, 1.0 / 16.0);

	return lerp(0.3 + 0.2 * (1.0 - (s / 0.02)), 1.0, v);
}

float2 ComputeWindowUV(float2 screenUV)
{
	#if UNITY_SINGLE_PASS_STEREO
		float4 scaleOffset = unity_StereoScaleOffset[unity_StereoEyeIndex];
		screenUV = (screenUV - scaleOffset.zw) / scaleOffset.xy;
	#else
		return screenUV;
	#endif
}

float ditherNoise(float2 sceneUVs) {
	//Dither Function (See Blur)
	float2 seed = float2(sin(sceneUVs.x), cos(sceneUVs.y));
	return frac(sin(dot(seed, float2(12.9898, 78.233))) * 43758.5453);
}

float noise(float p) {
	float fl = floor(p);
	float fc = frac(p);
	return lerp(rand(fl), rand(fl + 1.0), fc);
}

float glitchNoiseGenerator(float2 uv, float threshold, float scale, float seed, sampler2D _BlockGlitchMap)
{
	//Glitch Function (See Blocky Glitch)
	float scroll = floor(_Time.y + sin(11.0 *  _Time.y) + sin(_Time.y)) * 0.77;
	float2 noiseUV = uv.yy / scale + scroll;
	float noise2 = tex2D(_BlockGlitchMap, noiseUV).r;
	float id = floor(noise2 * 20.0);
	id = noise(id + seed) - 0.5;
	if (abs(id) > threshold)
		id = 0.0;
	return id;
}

float randomNegativeChance(float chance, float numberToNegate) {
	//Needs Optimised/Rewrote
	float randomNegativeChance = sin(_Time.w*chance);
	if (randomNegativeChance >= 0 && randomNegativeChance <= 0.5) {
		numberToNegate = numberToNegate * -1;
	}
	return numberToNegate;
}

float valueRemap(float value, float low1, float high1, float low2, float high2) {
	return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
}

float getviewDirection()
{
	//Wrote by Uncomfy, given to me by DocMe
	#if UNITY_SINGLE_PASS_STEREO
		float3 wnorm = normalize(unity_StereoWorldSpaceCameraPos[1] - unity_StereoWorldSpaceCameraPos[0]);
		float3 vdir = mul(unity_CameraToWorld, float4(0, 0, 1, 1)).xyz - _WorldSpaceCameraPos;
		vdir = vdir - dot(wnorm, vdir)*wnorm;
		float3 cPos = (unity_StereoWorldSpaceCameraPos[0] + unity_StereoWorldSpaceCameraPos[1]) / 2;
		float3 odir = mul(unity_ObjectToWorld, float4(0, 0, 0, 1)).xyz - cPos;
	#else
		float3 vdir = mul(unity_CameraToWorld, float4(0, 0, 1, 1)).xyz - _WorldSpaceCameraPos;
		float3 odir = mul(unity_ObjectToWorld, float4(0, 0, 0, 1)).xyz - _WorldSpaceCameraPos;
	#endif
	float dotresult = dot(normalize(vdir), normalize(odir));
	float saturateDot = saturate(dotresult);
	return saturateDot;
}

float mod(float x, float y)
{
	return x - y * floor(x / y);
}



//|===============================================|
//|				  vertex    					  |
//|===============================================|
v2f vert(appdata_base v, appdata p, VertexInput vi, float4 pos : POSITION) {

	v2f o;
	o.uv0 = vi.texcoord0;
	o.overlayCoordinates = mul(unity_ObjectToWorld, v.vertex);
	float3 viewPos = v.vertex;
	o.grabPos = ComputeGrabScreenPos(UnityViewToClipPos(viewPos));

	//Establishing a range
	float4 objToWorld = mul(unity_ObjectToWorld, float4(0, 0, 0, 1));
	float getDistanceAway = distance(_WorldSpaceCameraPos, objToWorld);

	//Creating falloff for rotation
	float returnOpacity = 1;
	if (_AllowSmartFalloff || _VRAdjust < 1) {
		float clampingDistanceRanges = clamp(getDistanceAway, _SmartFalloffMin, _SmartFalloffMax);
		returnOpacity = (1.0 - (clampingDistanceRanges - _SmartFalloffMin) / (_SmartFalloffMin));
		returnOpacity = clamp(returnOpacity, 0, 1);
		returnOpacity = returnOpacity * _OverallOpacity;
		#if UNITY_SINGLE_PASS_STEREO
			returnOpacity *= _VRAdjust;
		#endif
			if (_VRPreview) returnOpacity *= _VRAdjust;
	}

	UNITY_BRANCH
	if (_ToggleRenderLookAtMe) {
			float angledFalloff =
				((getviewDirection() > _RenderMeTolerance) ? ((getviewDirection() - _RenderMeTolerance) / (1.0 - _RenderMeTolerance)) : 0.0);
			returnOpacity *= angledFalloff;
	}

	if (getDistanceAway < _FalloffRange) {
		//Effect: Rotation
		UNITY_BRANCH
		if (_ToggleRotater) {
			//Applying only render looking at me strength
			_RotaterValue *= returnOpacity;
			float rSin, rCos;
			if (_ToggleRotaterAnimate) _RotaterValue = sin(_Time.y * _RotaterSpin) * _RotaterValue;
			sincos(radians(_RotaterValue), rSin, rCos);
			viewPos.xy = mul(float2x2(rCos, -rSin, rSin, rCos), viewPos.xy);
		}
		o.pos = UnityViewToClipPos(viewPos);
	}
	else {
		o.pos = float4(0, 0, 0, 1);
	}

	o.depthUV = ComputeScreenPos(o.pos);
	o.center = mul(UNITY_MATRIX_M, float4(0, 0, 0, 1));
	o.raycast = UnityObjectToViewPos(v.vertex).xyz - o.center* float3(-1, -1, 1);
	o.raycast = lerp(o.raycast, p.depthUV, p.depthUV.z != 0);

	//Adjusting camera posistion for VR users
	#if UNITY_SINGLE_PASS_STEREO
		o.cameraPos = (unity_StereoWorldSpaceCameraPos[0] + unity_StereoWorldSpaceCameraPos[1])*0.5;
	#else
		o.cameraPos = _WorldSpaceCameraPos;
	#endif

	//Creating a zoomed in UV to be used later in interpolation
	o.vzoomUV = ComputeGrabScreenPos(o.pos);
	o.vzoomUV.xy = lerp(o.grabPos.xy, TransformStereoScreenSpaceTex(0.5, 1.0) * o.vzoomUV.w, 1);

	//Establishing a range for zoom (since it can be swapped between zoom range and global range)
	float testZoomFalloff = 0;
	if (_ToggleZoomRange || _AllowSmartFalloff) testZoomFalloff = 1;
	if (!_ToggleZoomRange) {
		_ZoomFStart = _SmartFalloffMin;
		_ZoomFEnd = _SmartFalloffMax;
	}

	if ((_ToggleZoomRange && (getDistanceAway <= _ZoomRange)) || (!_ToggleZoomRange && (getDistanceAway <= _FalloffRange))) {
		//Creating falloff for zooms
		if (testZoomFalloff) {
			float clampingDistanceRanges = clamp(getDistanceAway, _ZoomFStart, _ZoomFEnd);
			float returnOpacity = (1.0 - (clampingDistanceRanges - _ZoomFStart) / (_ZoomFStart));
			returnOpacity = clamp(returnOpacity, 0, 1);
			returnOpacity *= _OverallOpacity;
			_BigZoomAmount = 0 + (returnOpacity - 0) * (_BigZoomAmount - 0) / (1 - 0);
			_ScreenZoomInValue = 0 + (returnOpacity - 0) * (_ScreenZoomInValue - 0) / (1 - 0);
			_ZoomInValue = 1 + (returnOpacity - 0) * (_ZoomInValue - 0) / (1 - 0);
			_ScreenZoomOutValue = 0 + (returnOpacity - 0) * (_ScreenZoomOutValue - 0) / (1 - 0);
		}

		//Effect: Focus Zoom
		UNITY_BRANCH
		if (_ToggleZoom) {
			o.pos = v.vertex;
			o.pos.xy *= 2;

			UNITY_BRANCH
			if (_SmoothZoom) {
				float angledFalloff =
					((getviewDirection() > _SmoothZoomTolerance) ? ((getviewDirection() - _SmoothZoomTolerance) / (1.0 - _SmoothZoomTolerance)) : 0.0);
				_ZoomInValue *= angledFalloff;
				_ZoomInValue = clamp(_ZoomInValue, 1, 15);
			}

			float4 zoomUv = ComputeGrabScreenPos(UnityObjectToClipPos(v.vertex));
			float4 zoomValue = ComputeGrabScreenPos(o.pos) - zoomUv;
			float4 zoomAddValue;

			//Flipping zoom if desired
			UNITY_BRANCH
			if (_ToggleFlipZoom == 1) {
				//Flipped zoom
				if (_ZoomOutValue > 0 && _ZoomInValue <= 1) {
					zoomAddValue = zoomValue * (-1 * (_ZoomOutValue + 1)); //zoom out
				}
				else {
					zoomAddValue = zoomValue / (-1 * (_ZoomInValue)); //zoom in
				}
			}
			else {
				//Normal zoom
				if (_ZoomOutValue > 0 && _ZoomInValue <= 1) {
					zoomAddValue = (zoomValue * (_ZoomOutValue + 1)); //zoom out, a bit broken if too far away
				}
				else {
					zoomAddValue = zoomValue / (_ZoomInValue); //zoom in
				}
			}

			//Applying the focused zoom
			o.grabPos = zoomUv + zoomAddValue;
			vi.worldPos = mul(unity_ObjectToWorld, v.vertex);
		}

		//Effect: Middle Zoom
		UNITY_BRANCH
		if (_ToggleBigZoom) {
			//Huge thanks to DocMe and Uncomfy (indirectly) for the help with the getting view direction portion!
			float4 zoomUv = ComputeGrabScreenPos(UnityObjectToClipPos(v.vertex));
			float4 zoomValue = ComputeGrabScreenPos(o.pos) - zoomUv;
			_BigZoomAmount -= _BigZoomOutAmount;
			float angledZoom =
				(_BigZoomAmount * ((getviewDirection() > _BigZoomTolerance)
				? ((getviewDirection() - _BigZoomTolerance)
				/ (1.0 - _BigZoomTolerance)) : 0));
			o.grabPos.xy = lerp(o.grabPos.xy, TransformStereoScreenSpaceTex(0.5, 1.0) * o.grabPos.w, angledZoom);
		}

		//Effect: Screen Zoom
		UNITY_BRANCH
		if (_ToggleScreenZoom) {
			o.grabPos.xy = lerp(o.grabPos.xy, TransformStereoScreenSpaceTex(0.5, 1.0) * o.grabPos.w, (_ScreenZoomInValue - _ScreenZoomOutValue));
		}

	}

	return o;
}



//|===============================================|
//|				  pixel     					  |
//|===============================================|
half4 frag(v2f i, VertexOutput vo, float facing : VFACE) : SV_Target: COLOR
{


	//== Start Frag Here! ==


	//Building the scene
	float2 sceneUVs = (vo.projPos.xy / vo.projPos.w);
	float2 cleanUVs = sceneUVs;
	float4 bgcolor = tex2D(_LukaFrontPass, sceneUVs);

	//Establishing a range
	float4 objToWorld = mul(unity_ObjectToWorld,float4(0,0,0,1));
	float getDistanceAway = distance(_WorldSpaceCameraPos, objToWorld);

	//Determing if the user is in shader range or out of it
	if (getDistanceAway >= _FalloffRange) return bgcolor;
	else
	{

		//Creating falloff
		float clampingDistanceRanges = clamp(getDistanceAway, _SmartFalloffMin, _SmartFalloffMax);
		float returnOpacity = (clampingDistanceRanges - _SmartFalloffMin) / (_SmartFalloffMax - _SmartFalloffMin);
		returnOpacity = smoothstep(1, 0, returnOpacity);
		returnOpacity = lerp(1, returnOpacity, _AllowSmartFalloff);
		returnOpacity = returnOpacity * _OverallOpacity;

		//Applying only render looking at me strength
		UNITY_BRANCH
		if (_ToggleRenderLookAtMe) {
			if ((getviewDirection() < _RenderMeTolerance)) {
				return bgcolor;
			}
			else if (_ToggleRenderLookAtMe) {
				float angledFalloff =
					(1 * ((getviewDirection() > _RenderMeTolerance) ? ((getviewDirection() - _RenderMeTolerance) / (1.0 - _RenderMeTolerance)) : 0.0));
				returnOpacity *= angledFalloff;
			}
		}

		//Applying seperated strength for VR users
		#if UNITY_SINGLE_PASS_STEREO
			returnOpacity *= _VRAdjust;
		#endif
		if (_VRPreview) returnOpacity *= _VRAdjust;


		//== Start UV Effects Here! ==


		//Effect: Pixelation
		UNITY_BRANCH
		if (_TogglePixelate) {
			float2 pixelateEquation = ceil(abs(float2(_PixelateStrength, _PixelateStrengthY)));
			float2 pixelatedUVs = (floor((pixelateEquation*sceneUVs.rg)) / pixelateEquation);
			sceneUVs.rg = pixelatedUVs;
		}

		//Effect: Glitchy Pixelate
		UNITY_BRANCH
		if (_GTogglePixelate) {
			float pixelateThresh = glitchNoiseGenerator(sceneUVs + float2(sceneUVs.y, 0.0), _GPixelFreq, (_GPixelStrength + _GPixelStrengthY) / 2, 70, _GPixelGlitchMap);
			float2 pixCalc = float2(ceil(abs(_GPixelStrength)), ceil(abs(_GPixelStrengthY)));
			float2 pixelatedUVs = (floor((pixCalc*sceneUVs.rg)) / pixCalc);
			float pixelateNoise = noise(sceneUVs.x / (noise(_Time.y))) / 5;
			pixelateNoise *= noise(sceneUVs.y / (noise(_Time.y))) / 4;
			pixelateNoise *= noise(sceneUVs.xy / noise(_Time.y)) / 3;
			if (pixelateNoise > pixelateThresh) {
				sceneUVs = pixelatedUVs;
			}
		}

		//Effect: Scanline
		UNITY_BRANCH
		if (_ToggleScanline) {
			float speedTime = _Time.y * _ScanlineSpeed;
			float scanlineMod = mod(speedTime, 2);
			float scanlineOffset = (sin(1.0 - tan(speedTime * 0.24))) * 0.05;
			float scanlineMinus = (scanlineMod - _ScanlineSize);
			float scanlinePlus = (scanlineMod + _ScanlineSize);
			float2 sceneDir = sceneUVs;
			UNITY_BRANCH
			if (_ScanlineDir == 1) {
				sceneDir = float2(sceneUVs.y, sceneUVs.x);
			}
			float x = smoothstep(scanlineMinus, scanlineMod, sceneDir.y) * _ScanlinePush;
			x -= smoothstep(scanlineMod, scanlinePlus, sceneDir.y) * _ScanlinePush;
			UNITY_BRANCH
			if (_ScanlineDir == 0) {
				sceneUVs.x += x;
			}
			else {
				sceneUVs.y += x;
			}
		}

		//Effect: Blocky Glitch
		UNITY_BRANCH
		if (_ToggleBlockyGlitch) {
			//setting up variables
			float displaceIntesnsity = _BlockyGlitchStrength * pow(sin(_Time.y * _BlockyGlitchSpeed), 5.0);
			float brokencolorIntensity = 0.1;

			//displacing UVs
			float displace =
				glitchNoiseGenerator(sceneUVs + float2(sceneUVs.y, 0.0), displaceIntesnsity, _BDepthX /* block density */, 66.6, _BlockGlitchMap) *
				glitchNoiseGenerator(sceneUVs.yx + float2(0.0, sceneUVs.x), displaceIntesnsity, _BDepthY /* block density */, 13.7, _BlockGlitchMap);

			//applying x offset
			float blockXGateOne = step(_AllowBGX, 1.0);
			float blockXGateTwo = step(1.0, _AllowBGX);
			float2 blockXUVs = float2(sceneUVs.x + displace, sceneUVs.y);
			sceneUVs.rg = float3(lerp((blockXGateOne*sceneUVs) + (blockXGateTwo*sceneUVs), (blockXUVs), blockXGateOne*blockXGateTwo), 0.0).rg;

			//applying y offset
			float blockYGateOne = step(_AllowBGY, 1.0);
			float blockYGateTwo = step(1.0, _AllowBGY);
			float2 blockYUVs = float2(sceneUVs.x, sceneUVs.y + displace);
			sceneUVs.rg = float3(lerp((blockYGateOne*sceneUVs) + (blockYGateTwo*sceneUVs), (blockYUVs), blockYGateOne*blockYGateTwo), 0.0).rg;
		}

		//Effect: Manual Glitch (Deprecated)
		UNITY_BRANCH
		if (_ToggleGlitch) {
			float4 storeTime = _Time;
			float2 cutRed;
			float cutRedTile;
			float applyRedGlitch;
			float2 applyRedGlitchTwo;
			float4 _RedMapVar;

			UNITY_BRANCH
			if (_ToggleRandomGlitch == 1) {
				//random direction 	
				UNITY_BRANCH
				if (_ToggleRandomSideGlitch == 1) {
					//random 
					float randomDirectionChance = sin(_Time.w*_GlitchSideFactor);
					//appearing horizontally
					if (randomDirectionChance >= 0 && randomDirectionChance <= 0.5) {
						//randomizing direction 
						_GlitchRedDistort = _GlitchRedDistort * -1;
					}
				}

				//autoaniamting
				_RedYGlitch = sin(_Time * 0.5) * _YGAnimate;
				_RedXGlitch = sin(_Time * 0.5) * _XGAnimate;
				_RedTileGlitch = sin(_Time.w) * _TileGAnimate;

				//cutting up the uvs
				cutRed = float2(1.0, 1.0) / float2(_RedYGlitch, _RedXGlitch);
				cutRedTile = floor(_RedTileGlitch * cutRed.x);
				applyRedGlitch = _RedTileGlitch - _RedYGlitch * cutRedTile;
				applyRedGlitchTwo = (sceneUVs.rg + float2(applyRedGlitch, cutRedTile)) * cutRed;
				_RedMapVar = tex2D(_GlitchRedMap, TRANSFORM_TEX(applyRedGlitchTwo, _GlitchRedMap));


			}
			else {
				cutRed = float2(1.0, 1.0) / float2(_RedYGlitch, _RedXGlitch);
				cutRedTile = floor(_RedTileGlitch * cutRed.x);
				applyRedGlitch = _RedTileGlitch - _RedYGlitch * cutRedTile;
				applyRedGlitchTwo = (sceneUVs.rg + float2(applyRedGlitch, cutRedTile)) * cutRed;
				_RedMapVar = tex2D(_GlitchRedMap, TRANSFORM_TEX(applyRedGlitchTwo, _GlitchRedMap));
			}

			sceneUVs.rg += (_RedMapVar.rgb.rg.r*_GlitchRedDistort);
		}

		//Effect: Ripple
		UNITY_BRANCH
		if (_ToggleRipple) {
			//Made this in ShaderForge, excuse the messy and poor code
			float2 appendResult41 = (float2(_ShockCenterX, _ShockCenterY));
			float2 appendResult44 = (float2(_ScreenParams.x, _ScreenParams.y));
			float2 temp_output_45_0 = (appendResult41 / appendResult44);
			float2 ase_screenPosNorm = sceneUVs;
			float2 appendResult49 = (float2(ase_screenPosNorm.x, ase_screenPosNorm.y));
			float temp_output_46_0 = distance(temp_output_45_0, appendResult49);
			float temp_output_54_0 = ((((_ShockSpread * _ScreenParams.x) / _ScreenParams.y) - _ShockMag) / (1.0 - _ShockMag));
			float ifLocalVar62 = 0;
			if (temp_output_46_0 <= (temp_output_54_0 + _ShockMag))
				ifLocalVar62 = 1.0;
			else
				ifLocalVar62 = 0.0;
			float ifLocalVar66 = 0;
			if (temp_output_46_0 > (temp_output_54_0 - _ShockMag))
				ifLocalVar66 = 1.0;
			else if (temp_output_46_0 < (temp_output_54_0 - _ShockMag))
				ifLocalVar66 = 0.0;
			float2 normalizeResult79 = normalize((appendResult49 - temp_output_45_0));
			float temp_output_71_0 = (temp_output_46_0 - temp_output_54_0);
			float2 ifLocalVar70 = 0;
			if ((ifLocalVar62 * ifLocalVar66) <= 0.0)
				ifLocalVar70 = appendResult49;
			else
				ifLocalVar70 = ((normalizeResult79 * ((1.0 - pow(abs((temp_output_71_0 * _ShockDis)), 0.8)) * temp_output_71_0)) + appendResult49);
			sceneUVs = ifLocalVar70;
		}

		//Effect: VHS
		UNITY_BRANCH
		if (_ToggleVHS) {
			//Props to ShaderToy member who came up with some VHS distortion math that I based mine off of (can't find original author, the shader was found on ShaderMan's github)
			sceneUVs -= fixed2(0.5, 0.5);
			sceneUVs = sceneUVs * 1.2 * (1 / 1.2 + 2 * sceneUVs.x * sceneUVs.x * sceneUVs.y * sceneUVs.y) + fixed2(0.5, 0.5);
			//sceneUVs += fixed2(.5,.5);
			fixed window = 1 / (1 + 20 * (sceneUVs.y - fmod(_Time.y / 4, 1)) * (sceneUVs.y - fmod(_Time.y / 4, 1))) + _waveyness;

			//Smooth wave option
			UNITY_BRANCH
			if (_ToggleSmoothWave == 0) {
				sceneUVs.x = sceneUVs.x + sin(sceneUVs.y * 10 + _Time.y) / 50 * _VHSXDisplacement*(1 + cos(_Time.y * 80))*window;
			}
			else {
				sceneUVs.x = sceneUVs.x + sin(sceneUVs.y + _Time.y) * _VHSXDisplacement * (cos(_Time.y)) * window;
			}

			fixed vShift = 0.4 * _VHSYDisplacement *(sin(_Time.y) + (sin(_Time.y) * cos(_Time.y)));
			sceneUVs.y = fmod(sceneUVs.y + vShift, 1);
		}

		//Effect: ASCII
		float asciiMulti = 1;
		UNITY_BRANCH
		if (_ToggleAscii) {
			//Props to the original creator of the screen color to bitmap character method that I adapted into my shader! (will put author here when I find)
			//Cutting and sampling scene
			_ASCIIPower = 0.5 * _ASCIIPower + 8.0;
			float2 vertexNawNaw = (sceneUVs * _ScreenParams.xy);
			sceneUVs = (floor(vertexNawNaw / _ASCIIPower) * _ASCIIPower / _ScreenParams.xy);
			float4 texSample = tex2D(_LukaFrontPass, sceneUVs);
			float colorSample = (texSample.r + texSample.g + texSample.b) / _ASCIIVariation;

			//Animated ASCII option
			UNITY_BRANCH
			if (_ASCIISpeed > 0) {
				colorSample = noise(colorSample * _Time.y * _ASCIISpeed);
			}

			//Deciding character
			float n = _ASCIIShapeOne;
			if (colorSample > 0.2) {
				n = _ASCIIShapeTwo;
			}
			if (colorSample > 0.3) {
				n = _ASCIIShapeThree;
			}
			if (colorSample > 0.4) {
				n = _ASCIIShapeFour;
			}
			if (colorSample > 0.5) {
				n = _ASCIIShapeFive;
			}
			if (colorSample > 0.6) {
				n = _ASCIIShapeSix;
			}
			if (colorSample > 0.7) {
				n = _ASCIIShapeSeven;
			}
			if (colorSample > 0.8) {
				n = _ASCIIShapeEight;
			}

			//Generating a character based on color
			float2 a = float2(vertexNawNaw / (_ASCIIPower / 2.0));
			float2 b = float2(2.0, 2.0);
			float2 p = a - (b * floor(a / b)) - float2(1.0, 1.0);
			asciiMulti = bitmapCharacter(n, p);
		}

		//Girlscam
		UNITY_BRANCH
		if (_ToggleGirlscam) {
			//Props to the original author of Girlscam that everbody uses code from but never credits, liuhaidong, who originally wrote it for WebGL
			//Setting up strength
			_GirlscamStrength *= _ToggleGirlscam;
			_GirlscamTime *= _ToggleGirlscam;
			float gcTimeMod = _Time.y * _GirlscamTime;
			float gcStrengthMod = _GirlscamStrength + gcTimeMod;

			//Setting up uvs
			float jitterValue = abs(sin(gcStrengthMod));
			float sliceThresh = clamp(1.0 - jitterValue, 0, 1);
			float sliceDisplace = pow(jitterValue, 3.0) * 0.05;
			float2 slicedUV = float2(sliceDisplace, sliceThresh);

			//Color drift
			float2 colorDrift = float2(0, 0);

			//Applying new uvs with direction option
			UNITY_BRANCH
			if (_GirlscamDir == 0) 
			{
				float finalJitter = (nrand(sceneUVs.y, jitterValue)) * 2.0 - 1.0;
				finalJitter *= step(slicedUV.y, abs(finalJitter)) * slicedUV.x;
				float finalDrift = sin(colorDrift.y) * colorDrift.x;
				sceneUVs = float2(fracFunc(sceneUVs.x + finalJitter + finalDrift), sceneUVs.y);
			}
			else
			{
				float finalJitter = (nrand(sceneUVs.x, jitterValue)) * 2.0 - 1.0;
				finalJitter *= step(slicedUV.y, abs(finalJitter)) * slicedUV.x;
				float finalDrift = sin(colorDrift.y) * colorDrift.x;
				sceneUVs = float2(sceneUVs.x, fracFunc(sceneUVs.y + finalJitter + finalDrift));
			}
		}

		//Effects: Flip and Upside Down
		sceneUVs.x = lerp(sceneUVs.x, (1.0 - sceneUVs.x), _ToggleScreenFlip);
		sceneUVs.y = lerp(sceneUVs.y, (1.0 - sceneUVs.y), _ToggleUpsideDown);

		//Effect: Apart
		UNITY_BRANCH
		if (_Apart > 0) {
			float testDirection = fmod(_ApartMode, 2); //1 = y 0 = x
			float testColor = (_ApartMode - 1); //2 or above = color
			UNITY_BRANCH
			if (testDirection) {
				if (sceneUVs.y > 0.5) {
					sceneUVs.y -= _Apart;
					if (sceneUVs.y < 0.5) {
						if (testColor >= 5) {
							return _ApartColor;
						}
						else {
							sceneUVs.y = 0;
						}
					}
				}
				else
				{
					sceneUVs.y += _Apart;
					if (sceneUVs.y > 0.5) {
						if (testColor >= 5) {
							return _ApartColor;
						}
						else {
							sceneUVs.y = 0;
						}
					}
				}
			}
			else
			{
				if (sceneUVs.x > 0.5) {
					sceneUVs.x -= _Apart;
					if (sceneUVs.x < 0.5) {
						if (testColor >= 5) {
							return _ApartColor;
						}
						else {
							sceneUVs.x = 0;
						}
					}
				}
				else
				{
					sceneUVs.x += _Apart;
					if (sceneUVs.x > 0.5) {
						if (testColor >= 5) {
							return _ApartColor;
						}
						else {
							sceneUVs.x = 0;
						}
					}
				}
			}
		}

		//Effect: Bulge
		UNITY_BRANCH
		if (_ToggleBulge + _BulgeIndent > 0) {
			float2 centerScreen = float2(0.5, 0.5);
			#if UNITY_SINGLE_PASS_STEREO
				if (sceneUVs.x < 0.5) {
					centerScreen = half2(0.25, 0.5);
				}
				else {
					centerScreen = half2(0.75, 0.5);
				}
			#endif
			if (_BulgeIndent > 0) {
				_OwOStrength = clamp(13.5 - (_OwOStrength - (_BulgeIndent * 5)), 0.65, 13.5);
			}
			float2 bulgeUVs = sceneUVs;
			bulgeUVs -= centerScreen;
			bulgeUVs /= _OwOStrength * (1.0 - distance(bulgeUVs, float2(0, 0)));
			bulgeUVs += centerScreen;
			sceneUVs = lerp(sceneUVs, bulgeUVs, _ToggleBulge - _BulgeIndent);
		}

		//Effect: Shake
		UNITY_BRANCH
		if (_ToggleShake) {
			float2 shakeOffset = float2(0, 0);

			//smooth
			UNITY_BRANCH
			if (_ShakeModel == 0) {
				if (_ToggleXYShake) {
					shakeOffset = float2(_ShakeStrength * sin(_Time.w * _ShakeSpeed), _ShakeStrength2 * sin(_Time.w * _ShakeSpeed2));
				}
				else
				{
					shakeOffset = float2(_ShakeStrength * sin(_Time.w * _ShakeSpeed), _ShakeStrength * sin(_Time.w * _ShakeSpeed));
				}
			}
			//rough
			else if (_ShakeModel == 1)
			{
				_ShakeStrength /= 25;
				_ShakeStrength2 /= 25;
				_ShakeSpeed *= 5;
				_ShakeSpeed2 *= 5;
				float ShakeMeDaddyOne = _ShakeStrength * sin(_Time.w * _ShakeSpeed);
				float ShakeMeDaddyTwo = _ShakeStrength2 * sin(_Time.w * _ShakeSpeed2);
				ShakeMeDaddyOne *= rand(ShakeMeDaddyOne);
				ShakeMeDaddyTwo *= rand(ShakeMeDaddyTwo);
				shakeOffset = float2(ShakeMeDaddyOne, ShakeMeDaddyTwo);
			}
			//noise
			else if (_ShakeModel == 2)
			{
				_ShakeStrength /= 25;
				_ShakeStrength2 /= 25;
				_ShakeSpeed *= 5;
				_ShakeSpeed2 *= 5;
				float2 noiseOffset = float2(sin(_Time.y * _ShakeSpeed), sin(_Time.y * _ShakeSpeed2));
				noiseOffset *= tex2D(_emptyTex, noiseOffset).xy;
				noiseOffset *= float2(_ShakeStrength * randomNegativeChance(noiseOffset.x*0.3, 1), _ShakeStrength2 * randomNegativeChance(noiseOffset.y*0.3, 1));
				shakeOffset = noiseOffset;
			}
			//circular
			else if (_ShakeModel == 3)
			{
				_ShakeStrength = valueRemap(_ShakeStrength, 0, 0.5, 500, 10);
				float RotSpeed = _ShakeSpeed * _Time.y;
				float sinXR = sin(RotSpeed);
				float cosXR = cos(RotSpeed);
				float sinYR = sin(RotSpeed);
				float2x2 circleShakeRM = float2x2(cosXR, -sinXR, sinYR, cosXR);
				float2 circleShakeDirection = mul(normalize(float2(1, 1)), circleShakeRM);
				shakeOffset = float2(circleShakeDirection.xy / _ShakeStrength);
			}
			//earthquake
			else if (_ShakeModel == 4)
			{
				float shakeMeDaddy = (_SSValue / 5) * sin(_Time.w * (_SSSpeed * 3.8));
				float shakeMeDaddy2 = (_SSValueVert / 5) * sin(_Time.w * (_SSSpeedVert * 3.8));
				if (_SSAllowHorizontalShake) shakeOffset.x = shakeMeDaddy;
				if (_SSAllowVerticalShake) shakeOffset.y = shakeMeDaddy2;

			}
			//map
			else if (_ShakeModel == 5)
			{
				float4 shakeMapUV = tex2D(_emptyTex, TRANSFORM_TEX(sceneUVs, _emptyTex));
				float2 shakeUVOffset = float2(_ShakeStrength * sin(_Time.w * _ShakeSpeed), _ShakeStrength2 * sin(_Time.w * _ShakeSpeed2));
				float2 shakeUV = (shakeMapUV.rgb*shakeUVOffset);
				shakeOffset = shakeUV;
			}

			//applying
			sceneUVs.xy += shakeOffset;
		}

		//Effect: Distortion
		float2 distortionStore = sceneUVs; //storing later for transparency
		UNITY_BRANCH
		if (_ToggleDistortion) {
			float2 transformDistortion = float2(_DistortionX, _DistortionY);
			float2 distortionUVs = sceneUVs;
			float2 rotateValue = float2(1, 1);

			//Distortion rotation option
			UNITY_BRANCH
			if (_DistortionRotate > 0) {
				sincos(_DistortionRotate + (_DistortionRotateSpeed * _Time.y) * UNITY_HALF_PI, rotateValue.y, rotateValue.x);
			}

			//Distortion speed option
			UNITY_BRANCH
			if (_DistortionXSpeed > 0 || _DistortionYSpeed > 0) {
				float2 distortionSpeed = (float2(_Time.y * _DistortionXSpeed, _Time.y * _DistortionYSpeed));
				distortionUVs = (distortionSpeed * transformDistortion + sceneUVs);
			}

			float4 transformMap = tex2D(_DistortionMap, TRANSFORM_TEX(distortionUVs.xy, _DistortionMap));

			//Distortion transparency option
			UNITY_BRANCH
			if (_DistortionTransparency == 1) {
				sceneUVs.xy += (((transformMap.rgb*transformDistortion))) * rotateValue;
			}
			else {
				distortionStore = sceneUVs.xy + (((transformMap.rgb*transformDistortion))) * rotateValue;
			}
		}

		//Effect: Edge Distortion
		UNITY_BRANCH
		if (_ToggleEdgeDistort) {

			//Grabbing extra copy of screen
			float4 edgeDistortGrab = tex2D(_LukaFrontPass, sceneUVs);

			//Rotation option
			UNITY_BRANCH
			if (_ToggleEdgeDisRotate) {
				//Establishing rotation matrix
				_EdgeDisRotSpeed *= _Time.y;
				float sinXR = sin(_EdgeDisRotSpeed);
				float cosXR = cos(_EdgeDisRotSpeed);
				float sinYR = sin(_EdgeDisRotSpeed);
				float2x2 edgeRM = float2x2(cosXR, -sinXR, sinYR, cosXR);
				float2 edgeRotateDirection = mul(normalize(float2(1, 1)), edgeRM);

				//Distorting UVs
				sceneUVs += float2(
					edgeDistortGrab.r * _EdgeDisX,
					edgeDistortGrab.g * _EdgeDisY)
					* (edgeRotateDirection.xy / _EdgeDisRotStr);
			}
			else {
				//Distorting UVs
				sceneUVs += float2(
					edgeDistortGrab.r * _EdgeDisX,
					edgeDistortGrab.g * _EdgeDisY);
			}
		}

		//Effect: Screenpull (Push)
		UNITY_BRANCH
		if (_ToggleScreenpull) {
			float4 _ScreenpullStore = tex2D(_ScreenpullMap, TRANSFORM_TEX(i.grabPos, _ScreenpullMap));
			float2 pushUV = (_ScreenpullStore.rgb.rg*_ScreenpullStrength);

			//Push mode option
			UNITY_BRANCH
			if (_ScreenpullMode == 1) {
				sceneUVs.r += _ScreenpullStrength;
				sceneUVs.g += _ScreenpullStrengthTwo;
			}
			else if (_ScreenpullMode == 2) {
				sceneUVs.rg += _ScreenpullStrength;
			}
			else if (_ScreenpullMode == 3) {
				sceneUVs.x = pow(sceneUVs.x, _WarpHorizontal);
				sceneUVs.y = pow(sceneUVs.y, _WarpVertical);
			}
			else if (_ScreenpullMode == 4) {
				pushUV = (_ScreenpullStore.rgb.rg*_ScreenpullStrength);
				sceneUVs.rg += pushUV;
			}
		}

		//Effect: Splice
		UNITY_BRANCH
		if (_ToggleSplice) {

			//Setting up initial cuts
			float uvYCut = 0;
			float uvXCut = 0;

			//Determing y cut
			if (sceneUVs.y > _SpliceXLimit) {
				uvYCut = _SpliceTop;
			}
			else {
				uvYCut = _SpliceBot;
			}

			//Determing x cut
			if (sceneUVs.x > _SpliceYLimit) {
				uvXCut = _SpliceLeft;
			}
			else {
				uvXCut = _SpliceRight;
			}

			//Applying cuts
			sceneUVs.x += uvYCut;
			sceneUVs.y += uvXCut;
		}

		//Effect: Film Jitter
		UNITY_BRANCH
		if (_FilmPower > 0 && _FilmJitterAmount > 0) {
			float jitterTimeFactor = float(int(_Time.y * _FilmItterations));
			float2 jitterUVs = (_FilmJitterAmount * float2(rand(jitterTimeFactor + 3), rand(jitterTimeFactor - 2)));
			sceneUVs = lerp(sceneUVs, sceneUVs + jitterUVs, _FilmPower);
		}

		//Effect: Swirl (Spiral)
		UNITY_BRANCH
		if (_ToggleSwirl) {

			//Changing center of screen based on eye in VR
			#if UNITY_SINGLE_PASS_STEREO
				if (sceneUVs.x < 0.5) {
					_SwirlCenterX /= 2;
				}
				else {
					float addAmount = _SwirlCenterX / 2;
					_SwirlCenterX += addAmount;
				}
			#endif

			float2 swirlCenter = float2(_SwirlCenterX, _SwirlCenterY);
			float calcSwirlDistance = distance(swirlCenter, sceneUVs);

			//Applying swirl if in radius
			if (calcSwirlDistance < _SwirlRadius)
			{
				//Excuse my older ShaderForge stuff..
				sceneUVs -= swirlCenter;
				float node_3420 = ((_SwirlRadius - calcSwirlDistance) / _SwirlRadius); // percent final
				float node_9968 = (node_3420*node_3420*_SwirlPower); // theta
				float node_6368 = cos(node_9968);
				float node_9833 = sin(node_9968);
				sceneUVs = float2(dot(sceneUVs, float2(node_6368, (node_9833*(-1.0)))), dot(sceneUVs, float2(node_9833, node_6368)));
				sceneUVs += swirlCenter;
			}
		}

		//Effect: Wavey (Waves)
		UNITY_BRANCH
		if (_ToggleWavey) {
			float xWaves = (sceneUVs.y + _Time.y * _WavesXSpeed) * _WavesXPower;
			float yWaves = (sceneUVs.x + _Time.y * _WavesYSpeed) * _WavesYPower;
			_WavesX = xWaves * _WavesX / 5;
			_WavesY = yWaves * _WavesY / 5;
			sceneUVs.x += (sin(xWaves) + sin(_WavesX)) * (_WavesXPower / 100) * sin(sceneUVs.y * 3.14);
			sceneUVs.y += (sin(yWaves) + sin(_WavesY)) * (_WavesYPower / 100) * sin(sceneUVs.x * 3.14);
		}

		//Effect: Dizzy
		UNITY_BRANCH
		if (_ToggleDizzyEffect) {

			float2x2 rotationMatrix = float2x2(0, 0, 0, 0);
			fixed2 uv = sceneUVs;
			fixed amount = 0;

			//Dizzy mode option
			UNITY_BRANCH
			if (_DizzyMode == 1) {
				float sinXR = sin(_DizzyRotationSpeed * _Time);
				float cosXR = cos(_DizzyRotationSpeed * _Time);
				float sinYR = sin(_DizzyRotationSpeed * _Time);
				rotationMatrix = float2x2(cosXR, -sinXR, sinYR, cosXR);
				amount = sin(_Time * _DizzyAmountValue); //What makes the camera follow the rotate
			}
			else if (_DizzyMode == 3) {
				float sinXR = sin(_DizzyRotationSpeed * _Time);
				float cosXR = cos(_DizzyRotationSpeed * _Time);
				float sinYR = sin(_DizzyRotationSpeed * _Time);
				rotationMatrix = float2x2(cosXR, -sinXR, sinYR, cosXR);
				amount = sin(_Time * _DizzyAmountValue); //What makes the camera follow the rotate
			}
			else if (_DizzyMode == 4) {
				float tanXR = tan(_DizzyRotationSpeed * _Time);
				float cosXR = cos(_DizzyRotationSpeed * _Time);
				float tanYR = tan(_DizzyRotationSpeed * _Time);
				rotationMatrix = float2x2(cosXR, -tanXR, tanYR, cosXR);
				amount = tan(_Time * _DizzyAmountValue); //What makes the camera follow the rotate
			}


			sceneUVs.x = sceneUVs.x + amount;
			float2 spinDirection = mul(normalize(float2(0, -1.0)), rotationMatrix);
			sceneUVs.xy = sceneUVs.xy + amount * spinDirection;
		}

		//Effect: Scroll
		UNITY_BRANCH
		if (abs(_ScrollX + _ScrollY) > 0) {
			sceneUVs.xy = float2(frac(sceneUVs.x + (_ScrollX * _Time.y)), (frac(sceneUVs.y + (_ScrollY * _Time.y))));
		}

		//Effect: Fix Screen Tear (Three Methods) 
		UNITY_BRANCH
		if (_TearToMirror) { //1.1 -> 0.9 sooo sceneUVs.x - 1.0 = 0.1 1.0 - 	// -0.1 -> 1.0 - (-0.1 - 1.0)
			if (sceneUVs.y > 1) {
				sceneUVs.y = (1.0 - ((sceneUVs.y) - 1.0));
			}
			else if (sceneUVs.y < 0) {
				sceneUVs.y *= -1.0;
			}
			if (sceneUVs.x > 1) {
				sceneUVs.x = (1.0 - ((sceneUVs.x) - 1.0));
			}
			else if (sceneUVs.x < 0) {//
				sceneUVs.x *= -1;
			}
		}
		else if (_TearToRepeat) {
			sceneUVs -= floor(sceneUVs);
		}
		else if (_AllowTearFix) {
			if (sceneUVs.y > 1 || sceneUVs.y < 0 || sceneUVs.x > 1 || sceneUVs.x < 0) return _ScreenTearColor;
		}

		//Applying falloff
		sceneUVs = lerp(cleanUVs, sceneUVs, returnOpacity);

		//Effect: Mirror (Could be optimized in the future?)
		UNITY_BRANCH
		if (_ToggleMirror) {
			if ((sceneUVs.x > 0.5) && (_MirrorHO)) {
				sceneUVs.x = (1.0 - sceneUVs.x);
			}

			if ((sceneUVs.x < 0.5) && (_MirrorHU)) {
				sceneUVs.x = (1.0 - sceneUVs.x);
			}


			if ((sceneUVs.y > 0.5) && (_MirrorVO)) {
				sceneUVs.y = (1.0 - sceneUVs.y);
			}


			if ((sceneUVs.y < 0.5) && (_MirrorVU)) {
				sceneUVs.y = (1.0 - sceneUVs.y);
			}
		}


		//== Setting up the scene == 
		float4 grabToChange = tex2D(_LukaFrontPass, sceneUVs);
		float4 cleanGrabToChange = tex2D(_LukaFrontPass, sceneUVs);


		//Setting up blur global values
		float3 blurColor = grabToChange;
		float balanceAmount = 1;

		//Effect: Blur
		UNITY_BRANCH
		if (_ToggleNBlur) {

			//Speed option
			UNITY_BRANCH
			if (_NBlurSpeed > 0 && !(_NBlurShape == 5)) {
				_NBlurPower *= sin(_Time.y * _NBlurSpeed);
			}

			//Rotate option
			float2 rotateValue = float2(1, 1);
			UNITY_BRANCH
			if (_NBlurRotate > 0) {
				sincos(_NBlurRotate + (_NBlurRotateSpeed * _Time.y), rotateValue.y, rotateValue.x);
			}

			//Setting up offset
			float2 blurOffset = float2(_NBlurX, _NBlurY);

			//Determing blur shape 
			//Normal blur shape
			UNITY_BRANCH
			if (_NBlurShape == 0) {
				UNITY_BRANCH
				if (_NBlurItterations > 1) {
					[unroll(32)]for (float i = 0; i < _NBlurItterations; i++) {
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, (i / (_NBlurItterations - 1)) * _NBlurPower) * rotateValue + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, (i / (_NBlurItterations - 1) - 1) * _NBlurPower)  * rotateValue + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1)) * _NBlurPower, 0)  * rotateValue + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1) - 1) * _NBlurPower, 0)  * rotateValue + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1) - 1) * _NBlurPower, (i / (_NBlurItterations - 1) - 1) * _NBlurPower)  * rotateValue + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1)) * _NBlurPower, (i / (_NBlurItterations - 1)) * _NBlurPower) * rotateValue + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1)) * _NBlurPower * -1, (i / (_NBlurItterations - 1)) * _NBlurPower)  * rotateValue + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1)) * _NBlurPower, (i / (_NBlurItterations - 1)) * _NBlurPower * -1)  * rotateValue + blurOffset);
					}
					//divide the sum of values by the amount of samples
					blurColor = blurColor / (_NBlurItterations * 8);
				}
				else {
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(_NBlurPower, 0) * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, _NBlurPower) * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(-_NBlurPower, 0) * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, -_NBlurPower) * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + _NBlurPower * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + -_NBlurPower * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(_NBlurPower, -_NBlurPower) * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(-_NBlurPower, _NBlurPower) * rotateValue + blurOffset);
					blurColor /= 8;
				}
			//Circle
			}
			else if (_NBlurShape == 1) {
				float Start = 2.0 / 14.0;
				_NBlurPower /= 5;
				blurColor += tex2D(_LukaFrontPass, sceneUVs);
				[unroll(32)]for (float i = 0; i < _NBlurItterations; i++) {
					for (float j = 0; j < 14; j++) {
						float magicNumber = (i / (_NBlurItterations * (7))) * (_NBlurPower * 2 * _NBlurItterations);
						float2 circleUVs = (sceneUVs + blurOffset) + ((drawCircle(Start, 14.0, j) * (_NBlurPower + magicNumber))) * rotateValue;
						blurColor += tex2D(_LukaFrontPass, circleUVs);
					}
				}
				blurColor /= (_NBlurItterations * 14);
			//Plus
			}
			else if (_NBlurShape == 2) {
				UNITY_BRANCH
				if (_NBlurItterations > 1) {
					[unroll(32)]for (float i = 0; i < _NBlurItterations; i++) {
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, (i / (_NBlurItterations - 1)) * _NBlurPower * rotateValue.y) + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, (i / (_NBlurItterations - 1) - 1) * _NBlurPower * rotateValue.y) + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1)) * _NBlurPower * rotateValue.x, 0) + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1) - 1) * _NBlurPower * rotateValue.x, 0) + blurOffset);
					}
					//divide the sum of values by the amount of samples
					blurColor = blurColor / (_NBlurItterations * 4);
				}
				else {
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(_NBlurPower, 0) * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, _NBlurPower) * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(-_NBlurPower, 0) * rotateValue + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, -_NBlurPower) * rotateValue + blurOffset);
					blurColor /= 4;
				}
			//Direction
			}
			else if (_NBlurShape == 3) {
				UNITY_BRANCH
				if (_NBlurItterations > 1) {
					[unroll(32)]for (float i = 0; i < _NBlurItterations; i++) {
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1) * rotateValue.x * _NBlurPower), (i / (_NBlurItterations - 1) * rotateValue.y * _NBlurPower)) + blurOffset);
					}
					//divide the sum of values by the amount of samples
					blurColor = blurColor / (_NBlurItterations);
				}
				else {
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(_NBlurPower * rotateValue.x, _NBlurPower * rotateValue.y) + blurOffset);
					blurColor /= 2;
				}
			//Dual
			}
			else if (_NBlurShape == 4) {
				UNITY_BRANCH
				if (_NBlurItterations > 1) {
					[unroll(32)]for (float i = 0; i < _NBlurItterations; i++) {
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2((i / (_NBlurItterations - 1) * rotateValue.x * _NBlurPower), (i / (_NBlurItterations - 1) * rotateValue.y * _NBlurPower)) + blurOffset);
						blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(-(i / (_NBlurItterations - 1) * rotateValue.x * _NBlurPower), -(i / (_NBlurItterations - 1) * rotateValue.y * _NBlurPower)) + blurOffset);
					}
					//divide the sum of values by the amount of samples
					blurColor = blurColor / (_NBlurItterations * 2);
				}
				else {
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(_NBlurPower * rotateValue.x, _NBlurPower * rotateValue.y) + blurOffset);
					blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(-_NBlurPower * rotateValue.x, -_NBlurPower * rotateValue.y) + blurOffset);
					blurColor /= 3;
				}
			//Simple Blur
			}
			else if (_NBlurShape == 6) {
				_NBlurPower *= 0.03;
				blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(_NBlurPower, 0));
				blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, _NBlurPower));
				blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(-_NBlurPower, 0));
				blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(0, -_NBlurPower));
				blurColor += tex2D(_LukaFrontPass, sceneUVs + _NBlurPower);
				blurColor += tex2D(_LukaFrontPass, sceneUVs - _NBlurPower);
				blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(_NBlurPower, -_NBlurPower));
				blurColor += tex2D(_LukaFrontPass, sceneUVs + float2(-_NBlurPower, _NBlurPower));
				blurColor /= 9;
			//Dither
			}
			else if (_NBlurShape == 5) {
				//ramp up blur strength since normally is really low
				_NBlurPower *= 30;
				_NBlurSpeed /= 30;
				float ditherSizzle = _Time.y * _NBlurSpeed;
				float2 fragCoord = sceneUVs.xy * _ScreenParams.xy;
				float ditherRadius = abs(_NBlurPower);
				float2 ditherOffset = -ditherRadius + float2(ditherNoise(fragCoord.xy + ditherSizzle), ditherNoise(fragCoord.yx + ditherSizzle)) * ditherRadius * 2.0;
				float2 ditherUVs = (fragCoord + ditherOffset) / _ScreenParams.xy;
				float3 ditheredBlur = tex2D(_LukaFrontPass, ditherUVs).rgb;
				blurColor = lerp(blurColor, ditheredBlur, _NBlurOpacity);
			}
		}

		//Effect: Split Shake (Earfquake) Blur
		UNITY_BRANCH
		if (_ShakeModel == 4 && _ToggleShake) {

			//Adjusting the lighting with copies of the screen 
			balanceAmount += lerp(0, 5, _SSTransparency);

			//Setting up split shake animation
			float horizontalOffset = ((_SSValue * 1) * sin(_Time.w * (_SSSpeed))) * _SSAllowHorizontalBlur;
			float verticalOffset = ((_SSValueVert * 1) * sin(_Time.w * (_SSSpeedVert))) * _SSAllowVerticalBlur;

			//Ones that use offset are the x and y axis
			float3 blurTexOne = tex2D(_LukaFrontPass, float2((sceneUVs.x + horizontalOffset), sceneUVs.g)).rgb;
			float3 blurTexTwo = tex2D(_LukaFrontPass, float2(sceneUVs.x, (sceneUVs.g + verticalOffset))).rgb;
			float3 blurTexThree = tex2D(_LukaFrontPass, sceneUVs.rg).rgb;
			float3 blurTexFour = tex2D(_LukaFrontPass, float2((sceneUVs.x - horizontalOffset), sceneUVs.g)).rgb;
			float3 blurTexFive = tex2D(_LukaFrontPass, float2(sceneUVs.x, (sceneUVs.g - verticalOffset))).rgb;
			float3 splitShakeRGB = (blurTexOne + blurTexTwo + blurTexThree + blurTexFour + blurTexFive);
			blurColor.rgb = lerp(blurColor.rgb, blurColor.rgb + splitShakeRGB, _SSTransparency);
		}

		//Balancing the lighting in blur color
		blurColor = blurColor / balanceAmount;

		//Setting the blur to be the main grab of the screen and applying color/glow/opacity
		grabToChange = lerp(grabToChange, lerp(grabToChange, float4(blurColor, 1), _NBlurColor * _NBlurGlow), _NBlurOpacity);

		//Effect: Radial Blur
		UNITY_BRANCH
		if (_ToggleRadialBlur)
		{
			//Setting up stuff
			float ditherSizzle = _Time.y * _RBDitherSpeed;
			float hueMod = _Time.y*_RBEDHSVRainbowTime; //set up time
			hueMod += (sceneUVs.y*_RBEDToggleHSVRainbowX); //vertical multiplier
			hueMod += (sceneUVs.x*_RBEDToggleHSVRainbowY); //horizontal multiplier
			hueMod *= _RBEDHSVRainbowHue;
			float3 hsvColor = smoothHSV2RGB(float3(hueMod, _RBEDHSVRainbowSat, _RBEDHSVRainbowLight));
			_RBEDColor.rgb = lerp(_RBEDColor.rgb, hsvColor, _RBEDToggleRainbow);
			float x, y;
			float2 radialUVs = sceneUVs;
			//VR Support
			#if UNITY_SINGLE_PASS_STEREO
				half2 dir;
				if (sceneUVs.x < 0.5) {
					dir = half2(0.25, 0.5) - sceneUVs.xy;
				}
				else {
					dir = half2(0.75, 0.5) - sceneUVs.xy;
				}
			#else
				half2 dir = half2(0.5, 0.5) - sceneUVs.xy;
			#endif

			//distance to center
			half dist = sqrt(dir.x * dir.x + dir.y * dir.y);
			float newDistance = smoothstep(.5, 1., 1. - dist);
			UNITY_BRANCH
			if (_RBMode == 0) {
				_RadialBlurDistance /= 15;
			}
			UNITY_BRANCH
			if (_RBMode == 0 || _RBMode == 3) {
				_RadialBlurDistance = lerp(_RadialBlurDistance, 0, newDistance);
			}

			float2 thisUV = i.vzoomUV.xy / i.vzoomUV.w;
			float redGrab;
			float greenGrab;
			float blueGrab;

			[unroll(32)]for (int copyLoop = 0; copyLoop < _RBItterations; copyLoop++) {


				//Radial mode option
				UNITY_BRANCH
				if (_RBMode == 2) {
					float rotateCopyLoop = 1;
					if (copyLoop == (_RBItterations / 2)) {
						rotateCopyLoop = 0;
					}
					else if (copyLoop < (_RBItterations / 2)) {
						rotateCopyLoop = copyLoop * -1;
					}
					else if (copyLoop > (_RBItterations / 2)) {
						rotateCopyLoop = copyLoop - (_RBItterations / 2);
					}
					x = cos(radians((10 * rotateCopyLoop / 5) * (_RadialBlurDistance * 5)));
					y = sin(radians((10 * rotateCopyLoop / 5) * (_RadialBlurDistance * 5)));
					radialUVs = mul(float2((sceneUVs.x - 0.5)* (_ScreenParams.x / _ScreenParams.y), sceneUVs.y - 0.5), float2x2(x, -y, y, x));
					radialUVs.x *= (_ScreenParams.y / _ScreenParams.x);
					radialUVs += 0.5;
				}
				else if (_RBMode == 0) {
					radialUVs += float2(dir * copyLoop / _RBItterations * _RadialBlurDistance);
				}
				else if (_RBMode == 1 || _RBMode == 3) {
					float calculatedStrength = copyLoop * 0.07;
					radialUVs = lerp(sceneUVs, thisUV, calculatedStrength * _RadialBlurDistance);
				}

				//Rotation option
				UNITY_BRANCH
				if (_RBRotate > 0) {
					float sampleTest = 0.01;
					UNITY_BRANCH
					if (_RBEmpower > 0) {
						sampleTest = _RBEmpower;
					}
					float2 sc = float2(1, 1);
					sincos(_RBRotate * (copyLoop * sampleTest) + (_Time.y * _RBRotateSpeed)*1.5, sc.y, sc.x);
					radialUVs += sc * 0.07;
				}

				//Dither option
				UNITY_BRANCH
				if (_RBDither > 0) {
					UNITY_BRANCH
					if (_RBEmpower > 0) {
						_RBDither += (copyLoop * _RBEmpower);
					}
					float2 fragCoord = radialUVs.xy * _ScreenParams.xy;
					float ditherRadius = abs(_RBDither);
					float2 ditherOffset = -ditherRadius + float2(ditherNoise(fragCoord.xy + ditherSizzle), ditherNoise(fragCoord.yx + ditherSizzle)) * ditherRadius * 2.0;
					radialUVs = (fragCoord + ditherOffset) / _ScreenParams.xy;
					//end dither
				}

				//Color
				float4 sampledTexture = tex2D(_LukaFrontPass, radialUVs);

				//Chromatic abberation option
				UNITY_BRANCH
				if (_RBCAOffset > 0) {
					_RBCAOffset += (copyLoop * (_RBEmpower / 100));
					redGrab = tex2D(_LukaFrontPass, radialUVs + float2(_RBCAOffset, 0)).r;
					float testModulos = fmod(copyLoop, 2);
					greenGrab = tex2D(_LukaFrontPass, radialUVs + float2((lerp(_RBCAOffset, -_RBCAOffset, testModulos) / 2), 0)).g;
					//greenGrab = tex2D(_LukaFrontPass, radialUVs + float2(0, 0)).g;
					blueGrab = tex2D(_LukaFrontPass, radialUVs + float2(-_RBCAOffset, 0)).b;
					sampledTexture.rgb = lerp(sampledTexture.rgb, float3(redGrab, greenGrab, blueGrab), _RBCATrans);
				}

				float4 storedTexture = sampledTexture;

				//Outline option
				UNITY_BRANCH
				if (_RBToggleED) {
					float4 blackAndWhiteGrab = dot(sampledTexture, float3(0.3*_SepiaColor.r, 0.59*_SepiaColor.g, 0.11*_SepiaColor.b));
					float3 edgeColor = createEdge(radialUVs, _RBEDWidth, _RBEDTolerance, 0, 0, _RBEDColor, _LukaFrontPass);
					float3 appliedEdge = lerp(sampledTexture.rgb, blackAndWhiteGrab.rgb, _RBEDBW) + edgeColor;
					if (_RBEDBackPower > 0) appliedEdge = lerp((sampledTexture.rgb + edgeColor), (_RBEDBackColor.rgb + edgeColor), _RBEDBackPower);
					appliedEdge = lerp(sampledTexture, appliedEdge, _RBEDTrans);
					UNITY_BRANCH
					if (_RBEDOnly == 1) {
						sampledTexture.rgb = edgeColor;
					}
					else {
						sampledTexture.rgb = appliedEdge;
					}
				}

				//Rainbow Option
				UNITY_BRANCH
				if (_RBToggleRainbow > 0) {
					UNITY_BRANCH
					if (_RBEmpower > 0) {
						_RBHSVRainbowHue += (copyLoop * _RBEmpower);
					}
					float hueMod = _Time.y*_RBHSVRainbowTime; //set up time
					hueMod += (sceneUVs.y*_RBToggleHSVRainbowX); //vertical multiplier
					hueMod += (sceneUVs.x*_RBToggleHSVRainbowY); //horizontal multiplier
					hueMod *= _RBHSVRainbowHue;
					float3 hsvColor = smoothHSV2RGB(float3(hueMod, _RBHSVRainbowSat, _RBHSVRainbowLight));
					sampledTexture.rgb = lerp(sampledTexture.rgb, sampledTexture.rgb*hsvColor, _RBToggleRainbow);
				}

				//Static Option
				UNITY_BRANCH
				if (_RBGrainPower > 0) {
					_RBGrainPower += (copyLoop * (_RBEmpower * 20) * (lerp(_RadialBlurDistance, 0, newDistance) * 5));
					float2 skew = radialUVs + 0.2127 + radialUVs.x*0.3713*radialUVs.y;
					float2 random = 4.789*sin(489.123*(skew));
					skew = radialUVs + 0.2127 * 0.3713 * (_RBGrainSpeed * _Time);
					float staticValue = frac(random.x*random.y*(1 + skew.x));
					float3 normalStatic = saturate(1 - (1.0 - (sampledTexture.rgb)) * (1 - (_RBGrainPower*staticValue) * _RBGrainColor.rgb));
					_RBGrainColor = (0, 0, 0, 1);
					float3 blackStatic = sampledTexture.rgb + (lerp(float3(1, 1, 1), saturate(3.0*abs(1.0 - 2.0*frac(float3(0.0, -1.0 / 3.0, 1.0 / 3.0))) - 1), 0) * 0);
					blackStatic = saturate(1 - (1.0 - (blackStatic.rgb))) * (1 - (_RBGrainColor*staticValue) * _RBGrainColor.rgb);
					sampledTexture.rgb = lerp(normalStatic, blackStatic, _RBGrainBlack);
				}

				//extra if for branching
				UNITY_BRANCH
				if (_RBToggleED == 0 || _RBEDOnly == 0) {
					if (copyLoop == 1) {
						grabToChange = sampledTexture;
					}
					else {
						grabToChange += sampledTexture;
					}
				}
				else {
					if (copyLoop == 1) {
						float4 blackAndWhiteGrab = dot(sampledTexture, float3(0.3*_SepiaColor.r, 0.59*_SepiaColor.g, 0.11*_SepiaColor.b));
						grabToChange.rgb = lerp(storedTexture.rgb, blackAndWhiteGrab.rgb, _RBEDBW) + sampledTexture.rgb;
					}
					else {
						grabToChange += sampledTexture;
					}
				}
			}

			//Applying
			grabToChange = grabToChange / _RBItterations;
			grabToChange *= lerp(1, _RBEDBalance, _RBEDOnly * _RBToggleED);
		}

		//Effect: Bloom 
		UNITY_BRANCH
		if (_RBloomToggle) {
			float Start = 2.0 / 14.0;
			_RBloomStrength /= 5;
			float4 cleanBloom = grabToChange;
			float4 test2 = tex2D(_LukaFrontPass, sceneUVs);
			[unroll(32)]for (float blurItter = 0; blurItter < _RBloomQuality; blurItter++) {
				for (float j = 0; j < 14; j++) {
					float magicNumber = (blurItter / (_RBloomQuality * (7))) * (_RBloomStrength * 2 * _RBloomQuality);
					float2 circleUVs = sceneUVs + ((drawCircle(Start, 14.0, j) * (_RBloomStrength + magicNumber)));
					grabToChange += tex2D(_LukaFrontPass, circleUVs);
				}
			}
			grabToChange /= (_RBloomQuality * 14);
			grabToChange *= _RBloomBright;
			float rawDepth = DecodeFloatRG(tex2Dproj(_CameraDepthTexture, vo.projPos));
			float linearDepth = Linear01Depth(rawDepth);
			i.raycast *= (_ProjectionParams.z / i.raycast.z);
			float4 vpos = float4(i.raycast * linearDepth, 1);
			float3 wpos = mul(unity_CameraToWorld, vpos).xyz;
			float ds = distance(wpos, _WorldSpaceCameraPos);
			grabToChange = lerp(cleanBloom, lerp(cleanBloom, grabToChange, _RBloomColor), _RBloomOpacity);
			if ((ds < _RBloomDepth)) {
				grabToChange = lerp(cleanBloom, grabToChange, (ds / _RBloomDepth));

			}
		}

		//== Start Screen Colour Effects Here ==


		//Effect: ASCII Color
		grabToChange.rgb = grabToChange.rgb * asciiMulti;

		//Effect: Fade Projection
		UNITY_BRANCH
		if (_ToggleFadeProjection > 0) {
			//normalizing
			float2 fadeUV = i.vzoomUV.xy / i.vzoomUV.w;
			fadeUV = lerp(sceneUVs, fadeUV, _FPZoom);

			//declaring
			float4 newMap = tex2D(_LukaFrontPass, fadeUV);

			//applying
			UNITY_BRANCH
			if (_FadeLayer == 0) {
				grabToChange = lerp(grabToChange, lerp(grabToChange, (grabToChange + (newMap*_FPColor)) / 2, _FPFade), _ToggleFadeProjection);
			}
			else {
				float rawDepth = DecodeFloatRG(tex2Dproj(_CameraDepthTexture, vo.projPos));
				float linearDepth = Linear01Depth(rawDepth);
				i.raycast *= (_ProjectionParams.z / i.raycast.z);
				float4 vpos = float4(i.raycast * linearDepth, 1);
				float3 wpos = mul(unity_CameraToWorld, vpos).xyz;
				float ds = distance(wpos, _WorldSpaceCameraPos);
				float4 noProj = grabToChange;
				grabToChange = lerp(grabToChange, lerp(grabToChange, (grabToChange + (newMap*_FPColor)) / 2, _FPFade), _ToggleFadeProjection);
				if (ds < 30) {
					grabToChange = lerp(noProj, grabToChange, (ds / 30));
				}
			}		
		}

		//Effect: RGB Projection
		UNITY_BRANCH
		if (_ToggleRGBZoom > 0) {
			//Normalizing
			float2 redUV = i.vzoomUV.xy / i.vzoomUV.w;
			float2 greenUV = i.vzoomUV.xy / i.vzoomUV.w;
			float2 blueUV = i.vzoomUV.xy / i.vzoomUV.w;
			redUV = lerp(sceneUVs, redUV, _RedZoom);
			greenUV = lerp(sceneUVs, greenUV, _GreenZoom);
			blueUV = lerp(sceneUVs, blueUV, _BlueZoom);

			//Declaring
			float4 rgbZoomPass = tex2D(_LukaFrontPass, sceneUVs);
			rgbZoomPass.r = tex2D(_LukaFrontPass, redUV);
			rgbZoomPass.g = tex2D(_LukaFrontPass, greenUV);
			rgbZoomPass.b = tex2D(_LukaFrontPass, blueUV);

			//Applying
			float3 rgbProj = grabToChange.rgb;
			rgbProj.r = lerp(grabToChange.r, rgbZoomPass.r, _RGBZoomTrans);
			rgbProj.g = lerp(grabToChange.g, rgbZoomPass.g, _RGBZoomTransG);
			rgbProj.b = lerp(grabToChange.b, rgbZoomPass.b, _RGBZoomTransB);
			grabToChange.rgb = lerp(grabToChange.rgb, rgbProj, _ToggleRGBZoom);
		}

		//Effect: Distortion Transparency
		UNITY_BRANCH
		if (_DistortionTransparency < 1 && _ToggleDistortion)
		{
			float4 distortionPass = tex2D(_LukaFrontPass, distortionStore);
			grabToChange = lerp(grabToChange, ((grabToChange + distortionPass) / 2), _DistortionTransparency);
		}

		//Effect: Fog
		UNITY_BRANCH
		if (_ToggleFog > 0 && _FogLayer == 1) {
			UNITY_BRANCH
			if (_FogSafe > 0) {
				if ((getviewDirection() > _FogSafeTol)) {
					_FogDensity += (_FogDensity * getviewDirection() * _FogSafe);
				}
			}
			float rawDepth = DecodeFloatRG(tex2Dproj(_CameraDepthTexture, vo.projPos));
			float linearDepth = Linear01Depth(rawDepth);
			i.raycast *= (_ProjectionParams.z / i.raycast.z);
			float4 vpos = float4(i.raycast * linearDepth, 1);
			float3 wpos = mul(unity_CameraToWorld, vpos).xyz;
			float ds = distance(wpos, _WorldSpaceCameraPos);
			float fogRainbowMod = _Time.y*_FogRainbowSpeed; //set up time
			float3 fogRainbow = smoothHSV2RGB(float3(fogRainbowMod, 1, 1));
			_FogColor.rgb = lerp(_FogColor.rgb, fogRainbow, _FogRainbow);
			float4 noFog = grabToChange;
			grabToChange = lerp(grabToChange, _FogColor, _ToggleFog);
			if ((ds < _FogDensity)) {
				//cleanGrabToChange = lerp(bgcolor, cleanGrabToChange, (ds / _FogDensity));
				grabToChange = lerp(noFog, grabToChange, (ds / _FogDensity));
			}
		}

		//Effect: Silhouette
		UNITY_BRANCH
		if (_ToggleSilhouette) {
			float rawDepth = DecodeFloatRG(tex2Dproj(_CameraDepthTexture, vo.projPos));
			float linearDepth = Linear01Depth(rawDepth);
			i.raycast *= (_ProjectionParams.z / i.raycast.z);
			float4 vpos = float4(i.raycast * linearDepth, 1);
			float3 wpos = mul(unity_CameraToWorld, vpos).xyz;
			float ds = distance(wpos, _WorldSpaceCameraPos);
			float silRainbowMod = _Time.y*_SilhouetteRainbowSpeed; //set up time
			float3 silRainbow = smoothHSV2RGB(float3(silRainbowMod, 1, 1));

			UNITY_BRANCH
			if (_SilhouetteRainLayer == 0) {
				_SilhouetteBack.rgb = lerp(_SilhouetteBack.rgb, silRainbow, _SilhouetteRainbow);
			}
			else {
				_SilhouetteFront.rgb = lerp(_SilhouetteFront.rgb, silRainbow, _SilhouetteRainbow);
			}

			float4 noFog = grabToChange;
			float3 silOverlay = lerp(noFog.rgb, _SilhouetteFront.rgb, _SilhouetteLighting);
			float3 silMult = lerp(noFog.rgb, noFog.rgb*_SilhouetteFront.rgb, _SilhouetteLighting);
			noFog.rgb = lerp(silMult, silOverlay, _SilhouetteLightingMode);
			grabToChange = lerp(grabToChange, _SilhouetteBack, _ToggleSilhouette);
			if ((ds < _SilhouetteDepth)) {
				//cleanGrabToChange = lerp(bgcolor, cleanGrabToChange, (ds / _FogDensity));
				grabToChange = lerp(noFog, grabToChange, (ds / _SilhouetteDepth));
			}
		}

		//Effect: Smear (Code needs cleaned!)
		UNITY_BRANCH
		if (_ToggleSmear) {
			//Props to donald on ShaderToy for some of the original WebGL formulas
			//variables to be used in equations 
			float piTT = 3.1415926*2. / 3.;
			float m = -1e10;//very negitive start value for maximisation algorithm.
			fixed4 mv = fixed4(0., 0, 0, 0); //lank starting value of max so far
			fixed2 xy = sceneUVs;
			float smearDistance = 10; //stores smear distance

			[unroll(32)]for (int i = 0; i < _CSCopies; i++) { //kms for loops 

				UNITY_BRANCH
				if (_CSAutoRotate) {
					//if for rotaitng smear

					//advanced mode or nah 
					float matrixMULTISXR;
					float matrixMULTICXR;
					float matrixMULTISYR;
					if (_CSUseAdvanced) {
						matrixMULTISXR = _CSRotateSpeedSinXR;
						matrixMULTICXR = _CSRotateSpeedCosXR;
						matrixMULTISYR = _CSRotateSpeedSinYR;
					}
					else {
						matrixMULTISXR = _CSRotateSpeed;
						matrixMULTICXR = _CSRotateSpeed;
						matrixMULTISYR = _CSRotateSpeed;
					}

					//rotation matrix
					float sinXR = sin(matrixMULTISXR * _Time);
					float cosXR = cos(matrixMULTICXR * _Time);
					float sinYR = sin(matrixMULTISYR * _Time);
					float2x2 rotMatrix = float2x2(cosXR, -sinXR, sinYR, cosXR);
					float2 rotmatDirection = mul(normalize(float2(0, _CSDirection)), rotMatrix);

					//color
					fixed2 np = fixed2(xy.x + float(i) / _ScreenParams.x*(rotmatDirection.x), (xy.y + float(i) / _ScreenParams.y*(rotmatDirection.y)));
					fixed4 uvGP = tex2D(_LukaFrontPass, np);

					//keeping some of the original math concepts with the new rotation matrix
					float t =
					uvGP.r*(_CSRed)+
					uvGP.g*(_CSGreen + piTT) +
					uvGP.b*(_CSBlue + 2.*piTT) - .01*float(i);

					//fixing values in case 	
					if (t > m) {
						m = t;
						mv = uvGP;
						smearDistance = i;
					}
				}
				else {
					//if for manual smear 

					//rotation matrix
					float sinXR = sin(_CSDirection);
					float cosXR = cos(_CSDirection);
					float sinYR = sin(_CSDirection);
					float2x2 rotMatrix = float2x2(cosXR, -sinXR, sinYR, cosXR);
					float2 rotmatDirection = mul(normalize(float2(_CSDirection, 1)), rotMatrix);

					//color
					fixed2 np = fixed2(xy.x + float(i) / _ScreenParams.x*(rotmatDirection.x), (xy.y + float(i) / _ScreenParams.y*(rotmatDirection.y)));
					fixed4 uvGP = tex2D(_LukaFrontPass, np);

					//keeping some of the original math concepts with the new rotation matrix
					float t =
					uvGP.r*(_CSRed)+
					uvGP.g*(_CSGreen + piTT) +
					uvGP.b*(_CSBlue + 2.*piTT) - .01*float(i);

					//fixing values in case 	
					if (t > m) {
						m = t;
						mv = uvGP;
						smearDistance = i;
					}


				}
			}

			//fixing colors by dividing by copies 
			float colorFix = float(smearDistance) / _CSCopies;
			mv = colorFix * grabToChange + (1. - colorFix) * mv;
			grabToChange = float4(mv.r, mv.g, mv.b, 1.0);
		}

		//Effect: Edge Detection (Colored Outline)
		UNITY_BRANCH
		if (_ToggleED) {

			//applying rainbow
			float hueMod = _Time.y*_EDHSVRainbowTime; //set up time
			hueMod += (sceneUVs.y*_EDToggleHSVRainbowX); //vertical multiplier
			hueMod += (sceneUVs.x*_EDToggleHSVRainbowY); //horizontal multiplier
			hueMod *= _EDHSVRainbowHue;
			float3 hsvColor = smoothHSV2RGB(float3(hueMod, _EDHSVRainbowSat, _EDHSVRainbowLight));
			_EDColor.rgb = lerp(_EDColor.rgb, hsvColor, _EDToggleRainbow);

			//applying ramp
			float2 rampUVs = sceneUVs;
			rampUVs *= float2(_EDRampX, _EDRampY);
			float timeFactor = 1;
			if (_EDRampScroll) timeFactor = _Time.y;
			rampUVs += float2((timeFactor * _EDRampSX), (timeFactor * _EDRampSY));
			float4 rampColor = tex2D(_EDRampMap, rampUVs);
			_EDColor = lerp(_EDColor, rampColor, _EDRampAllow);

			//applying
			_EDColor *= _EDGlow;

			//applying dither
			_EDDither *= 30;
			_EDDitherSpeed /= 30;
			float2 outlineUVs = sceneUVs;
			float ditherSizzle = _Time.y * _EDDitherSpeed;
			float2 fragCoord = outlineUVs.xy * _ScreenParams.xy;
			float ditherRadius = abs(_EDDither);
			float2 ditherOffset = -ditherRadius + float2(ditherNoise(fragCoord.xy + ditherSizzle), ditherNoise(fragCoord.yx + ditherSizzle)) * ditherRadius * 2.0;
			outlineUVs = (fragCoord + ditherOffset) / _ScreenParams.xy;
			//end dither

			//start black and white screen
			float4 blackAndWhiteGrab = dot(grabToChange, float3(0.3*_SepiaColor.r, 0.59*_SepiaColor.g, 0.11*_SepiaColor.b));
			//end black and white screen

			//applying
			float3 edgeColor = createEdge(outlineUVs, _EDWidth, _EDTolerance, _EDXOffset, _EDYOffset, _EDColor, _LukaFrontPass);
			float3 appliedEdge = lerp(grabToChange.rgb, blackAndWhiteGrab.rgb, _EDBW) + edgeColor;
			if (_EDBackPower > 0) appliedEdge = lerp((grabToChange.rgb + edgeColor), (_EDBackColor.rgb + edgeColor), _EDBackPower);
			grabToChange.rgb = lerp(grabToChange, appliedEdge, _EDTrans);
		}


		//Effect: Invert
		float4 normalInv = grabToChange;
		normalInv.rgb =
		abs(_InvertStrength - normalInv.rgb);
		normalInv.rgb =
		abs(float3(
		_InvertR - normalInv.r,
		_InvertG - normalInv.g,
		_InvertB - normalInv.b
		));
		float4 fuckyWucky = grabToChange;
		fuckyWucky.rgb =
		_InvertStrength - fuckyWucky.rgb;
		fuckyWucky.rgb =
		float3(
		_InvertR - fuckyWucky.r,
		_InvertG - fuckyWucky.g,
		_InvertB - fuckyWucky.b
		);
		grabToChange.rgb = lerp(normalInv, fuckyWucky, _InvertMode);

		//Effect: Saturation
		UNITY_BRANCH
		if (!(_SaturationValue == 1)) {
			float3 hsvGrab = rgb2hsv(grabToChange.rgb);
			hsvGrab.g *= _SaturationValue;
			grabToChange.rgb = hsv2rgb(hsvGrab);

		}

		//Effect: Gamma
		grabToChange.rgb = pow(grabToChange.rgb, float3(
		(1.0 / (1.0 - _GammaRed)),
		(1.0 / (1.0 - _GammaGreen)),
		(1.0 / (1.0 - _GammaBlue))
		));

		//Effect: Colors
		grabToChange.rgba = grabToChange.rgba*_ColorRGB.rgba;
		grabToChange.rgb = grabToChange.rgb + (lerp(float3(1, 1, 1), saturate(3.0*abs(1.0 - 2.0*frac(_ColorHue + float3(0.0, -1.0 / 3.0, 1.0 / 3.0))) - 1), _ColorSaturation)*_ColorValue);
		grabToChange.rgb = lerp(grabToChange.rgb, _SolidCol.rgb, _SolidTrans);

		//Effect: Darken
		grabToChange.rgb = grabToChange.rgb*(1.0 - _DarknessStrength);

		//Effect: Vibrance
		UNITY_BRANCH
		if (!(_VibrancePower == 0)) {
			float3 hsvGrabVib = rgb2hsv(grabToChange.rgb);
			float maxDelta = sqrt(hsvGrabVib.y) - hsvGrabVib.y;
			hsvGrabVib.y = (maxDelta * _VibrancePower) + hsvGrabVib.y;
			grabToChange.rgb = hsv2rgb(hsvGrabVib.rgb);
		}

		//Effect: Recolor (Hue Shift) (needs rewrote)
		UNITY_BRANCH
		if (_ToggleRecolor) {
			//Excuse the poor and messy ShaderForge code
			float4 node_8388_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
			float4 node_8388_p = lerp(float4(float4(grabToChange.rgb, 0.0).zy, node_8388_k.wz), float4(float4(grabToChange.rgb, 0.0).yz, node_8388_k.xy), step(float4(grabToChange.rgb, 0.0).z, float4(grabToChange.rgb, 0.0).y));
			float4 node_8388_q = lerp(float4(node_8388_p.xyw, float4(grabToChange.rgb, 0.0).x), float4(float4(grabToChange.rgb, 0.0).x, node_8388_p.yzx), step(node_8388_p.x, float4(grabToChange.rgb, 0.0).x));
			float node_8388_d = node_8388_q.x - min(node_8388_q.w, node_8388_q.y);
			float node_8388_e = 1.0e-10;
			float3 node_8388 = float3(abs(node_8388_q.z + (node_8388_q.w - node_8388_q.y) / (6.0 * node_8388_d + node_8388_e)), node_8388_d / (node_8388_q.x + node_8388_e), node_8388_q.x);;
			float3 staticHue = (lerp(float3(1, 1, 1), saturate(3.0*abs(1.0 - 2.0*frac((node_8388.r*_RecolorHue) + float3(0.0, -1.0 / 3.0, 1.0 / 3.0))) - 1), (_RecolorSat*node_8388.g))*(_RecolorBright*node_8388.b));
			float3 animatedHue = (lerp(float3(1, 1, 1), saturate(3.0*abs(1.0 - 2.0*frac(((((_RecolorSpeed)*_SinTime.x)*node_8388.r)*_RecolorHue) + float3(0.0, -1.0 / 3.0, 1.0 / 3.0))) - 1), (_RecolorSat*node_8388.g))*(_RecolorBright*node_8388.b));
			grabToChange.rgb = lerp(staticHue, animatedHue, _ToggleRecolorAnimate);
		}

		//Effect: Exposure
		grabToChange *= _BloomGlow;

		//Effect: Posterize
		UNITY_BRANCH
		if (_PosterizeValue > -100) {
			grabToChange.rgb = floor(grabToChange.rgb * _PosterizeValue) / (_PosterizeValue - 1);
		}

		//Effect: Contrast
		grabToChange.rgb = saturate(lerp(half3(0.5, 0.5, 0.5), grabToChange.rgb, _ContrastValue));

		//Effect: Sepia
		float4 sepiaToneDarken = (grabToChange*(1.0 - 0.5));
		float sepiaDot = dot(fixed3(0.299, 0.587, 0.114), sepiaToneDarken.rgb);
		float4 sepiaChange = sepiaToneDarken + (float4(0.191, -0.054, -0.221, 0.0)*_SepiaRWarmth) + sepiaDot * _SepiaRTone;
		grabToChange = lerp(grabToChange, sepiaChange, _SepiaRStrength);

		//Effect: Extra Color Methods
		UNITY_BRANCH
		if (_ColorRGBtoHSV > 0) {
			grabToChange.rgb = lerp(grabToChange, rgb2hsv(grabToChange.rgb), _ColorRGBtoHSV);
		}
		UNITY_BRANCH
		if (_ColorHSVtoRGB > 0) {
			grabToChange.rgb = lerp(grabToChange, hsv2rgb(grabToChange.rgb), _ColorHSVtoRGB);
		}

		//Effect: Corners
		UNITY_BRANCH
		if (_CornerOneTrans + _CornerTwoTrans + _CornerThreeTrans + _CornerFourTrans > 0) {
			float bottomLeft = abs(sceneUVs.x - 1) * abs(sceneUVs.y - 1);
			grabToChange = lerp(grabToChange, lerp(grabToChange, _CornerOneColor, bottomLeft), _CornerOneTrans);
			float topLeft = abs(sceneUVs.x - 1) * abs(sceneUVs.y - 0);
			grabToChange = lerp(grabToChange, lerp(grabToChange, _CornerTwoColor, topLeft), _CornerTwoTrans);
			float bottomRight = abs(sceneUVs.x - 0) * abs(sceneUVs.y - 1);
			grabToChange = lerp(grabToChange, lerp(grabToChange, _CornerThreeColor, bottomRight), _CornerThreeTrans);
			float topRight = abs(sceneUVs.x - 0) * abs(sceneUVs.y - 0);
			grabToChange = lerp(grabToChange, lerp(grabToChange, _CornerFourColor, topRight), _CornerFourTrans);
		}

		//Effect: Gradient
		float4 gradLerp = lerp(_GradOne, _GradTwo, lerp(sceneUVs.x, sceneUVs.y, _GradMode));
		gradLerp = lerp(gradLerp, grabToChange*gradLerp, _GradApply);
		grabToChange = lerp(grabToChange, gradLerp, _GradTrans);

		//Effect: Black and White
		grabToChange.rgb = lerp(grabToChange.rgb, dot(grabToChange, float3(0.3*_SepiaColor.r, 0.59*_SepiaColor.g, 0.11*_SepiaColor.b)), _SepiaStrength);

		//Effect: Deepfry
		UNITY_BRANCH
		if (_ToggleDeepfry) {

			UNITY_BRANCH
			if (_DeepfryEmbossPower > 0) {
				float lum = dot(grabToChange, float4(0.7, 0.2, -0.7, 1.0));
				float f = fwidth(lum*_DeepfryEmbossPower);
				grabToChange.rgb *= (1.0 - 8.0*f);
			}

			UNITY_BRANCH
			if (_DeepfryValue == 0) {
				grabToChange.rgb = (1.0 - grabToChange) * (1.0 - _Time.w) + grabToChange * _Time.w * _DeepfryBrightness;
			}
			else if (_DeepfryValue == 1) {
				grabToChange.rgb = cos(sin(1.0 - grabToChange) * (1.0 - _Time.w) + grabToChange + grabToChange * _Time.w * _DeepfryBrightness);
			}
			else if (_DeepfryValue == 2) {
				grabToChange.rgb = cos(cos(cos(1.0 - grabToChange) * (1.0 - _Time.w) + grabToChange + grabToChange * _Time.w * _DeepfryBrightness));
			}
			else if (_DeepfryValue == 3) {
				grabToChange.r = cos(sin(1.0 - grabToChange) * (1.0 - _Time.w) + grabToChange + grabToChange * _Time.w * _DeepfryBrightness);
				grabToChange.g = cos(sin(1.0 - grabToChange) * (1.0 - _Time.w) + grabToChange + grabToChange * _Time.w * _DeepfryBrightness);
				grabToChange.b = cos(sin(1.0 - grabToChange) * (1.0 - _Time.w) + grabToChange + grabToChange * _Time.w * _DeepfryBrightness);
			}

		}

		//Effect: Grain
		UNITY_BRANCH
		if (_ToggleNoise) {

			//variables
			float2 skew = (1, 1);
			float2 random = (1, 1);
			float2 staticPixelate = ceil(abs(_StaticSize));
			float2 staticUVs = (floor((staticPixelate*sceneUVs.rg)) / staticPixelate);

			//creating noise
			UNITY_BRANCH
			if (!_ToggleStaticMap) {
				skew = staticUVs + 0.2127 + staticUVs.x*0.3713*staticUVs.y;
				random = 4.789*sin(489.123*(skew));
				skew = lerp(skew, staticUVs + 0.2127 * 0.3713 * (_StaticSpeed * _Time), _ToggleAnimatedNoise);
			}
			else
			{
				//using map
				float4 staticPush = tex2D(_StaticMap, TRANSFORM_TEX(sceneUVs.rg, _StaticMap));
				float2 node_5031 = lerp(staticPush.rgb.rg, (staticPush.rgb.rg + sin((_StaticSpeed*_Time.y))*float2(1, 1)), _ToggleAnimatedNoise);
				skew = node_5031 + 0.2127 + node_5031.x*0.3713*node_5031.y;
				random = 4.789*sin(489.123*(skew));
			}

			//applying
			float staticValue = frac(random.x*random.y*(1 + skew.x));
			float3 normalStatic = saturate(1 - (1.0 - (grabToChange.rgb)) * (1 - (_StaticIntensity*staticValue) * _StaticColor.rgb));
			_StaticColor = (0, 0, 0, 1);
			float3 blackStatic = grabToChange.rgb + (lerp(float3(1, 1, 1), saturate(3.0*abs(1.0 - 2.0*frac(float3(0.0, -1.0 / 3.0, 1.0 / 3.0))) - 1), 0)*_StaticOverlay);
			blackStatic = saturate(1 - (1.0 - (blackStatic.rgb))) * (1 - (_StaticIntensity*staticValue) * _StaticColor.rgb);
			grabToChange.rgb = lerp(normalStatic, blackStatic, _StaticBlack);

		}

		//Effect: VHS (needs rewrote)
		UNITY_BRANCH
		if (_ToggleVHS) {

			//final return 
			fixed2 uv = sceneUVs;

			//distorting the screen to get that curved tv look
			uv -= fixed2(0.5, 0.5);
			uv = uv * 1.2 * (1 / 1.2 + 2 * uv.x * uv.x * uv.y * uv.y) + fixed2(0.5, 0.5);
			//uv += fixed2(.5,.5);

			//getting video 
			fixed window = 1 / (1 + 20 * (uv.y - fmod(_Time.y / 4, 1)) * (uv.y - fmod(_Time.y / 4, 1))) + _waveyness;

			//smooth wave
			UNITY_BRANCH
			if (_ToggleSmoothWave == 0) {
				uv.x = uv.x + sin(uv.y * 10 + _Time.y) / 50 * _VHSXDisplacement*(1 + cos(_Time.y * 80))*window;
			}
			else {
				uv.x = uv.x + sin(uv.y + _Time.y) * _VHSXDisplacement * (cos(_Time.y)) * window;
			}

			fixed vShift = 0.4 * _VHSYDisplacement *(sin(_Time.y) + (sin(_Time.y) * cos(_Time.y)));
			uv.y = fmod(uv.y + vShift, 1);
			//fixed3 video = fixed3(tex2D(_LukaFrontPass, uv).xyz);

			//stripes 
			fixed noi = noise(uv * fixed2(0.5, 1) + fixed2(1, 3));
			float3 stripesUV = (fmod(uv.y* (_Time.y * 4) + sin(_Time.y), 1), 0.5, 0.6) * noi;

			//ramping the stripes 
			fixed inside = step(stripesUV.y, stripesUV.z) - step(stripesUV.x, stripesUV.z);

			//fixing float division by zero warning 
			float firstUVSet = (stripesUV.z - stripesUV.y);
			float secUVSet = (stripesUV.x - stripesUV.y);
			secUVSet += 1;
			float fact = firstUVSet / secUVSet * inside;
			float3 stripeRampUV = (1 - fact) * inside;

			//noise 
			float multiNoise = uv * 2 / 2;
			fixed sample = float4(0, 0, 0, 1) * fixed2(1, cos(_Time.y)*_Time.y * 8 + multiNoise * 1).x;
			sample = mul(sample, sample);

			//applying effects
			grabToChange = (grabToChange + float4(stripeRampUV, 1)) + sample;

			//calculating vignette
			float vignette =
			(1 - _shadowStrength * (uv.y - 0.5) * (uv.y - 0.5))*
			(1 - _shadowStrength * (uv.x - 0.5) * (uv.x - 0.5));

			//applying vignette
			grabToChange = mul(grabToChange, vignette);

			//apply stripes and returning
			grabToChange = mul(grabToChange, (_darkness + fmod(uv.y * 30 + _Time.y, 1)) / (_darkness + 1));

		}

		//Effect: Neon (Outline)
		UNITY_BRANCH
		if (_ToggleOutline > 0)
		{
			float neonOffset = (-1 * _OutlineActualOffset);
			float neonOffsettwo = _OutlineActualOffset;
			float4 neonGrab = float4((((grabToChange.rgb + ((_OutlineOffset)-tex2D(_LukaFrontPass, float2((sceneUVs.x - neonOffset), sceneUVs.g)).rgb)) + (grabToChange.rgb + (_OutlineOffset - tex2D(_LukaFrontPass, float2((sceneUVs.x - neonOffsettwo), sceneUVs.g)).rgb))) / _OutlineModOne * float3(_OutlineModTwo, _OutlineModThree, _OutlineModFour)), 1);
			float4 greyscaleGrab = dot(neonGrab, float3(0.3, 0.59, 0.11));
			neonGrab = lerp(neonGrab, greyscaleGrab, _OutlineSepiaAmount);
			grabToChange = lerp(grabToChange, neonGrab, _ToggleOutline);
		}

		//Effect: Ramp
		UNITY_BRANCH
		if (_ToggleRampEffect > 0) {
			grabToChange *= _RampOneDepth;
			float rampSpeed = lerp(_RampOneStrength, _Time.x * _RampOneSpeed * _RampOneStrength, _ToggleRampOneAnimate);
			float useColorChannel = lerp(grabToChange.r, grabToChange.g, clamp(_RampColorChannel, 0, 1));
			useColorChannel = lerp(useColorChannel, grabToChange.b, valueRemap(_RampColorChannel, 0, 2, 0, 1));
			float4 rampGrab = tex2D(_RampMap, (useColorChannel + rampSpeed)) / _RampOneLighting;
			grabToChange = lerp(grabToChange, rampGrab, _ToggleRampEffect);
		}

		//Effect: Droplet (Color Droplet)
		UNITY_BRANCH
		if (_ToggleDroplet) {
			//checking colors 
			if (
			(bgcolor.r >= _DropletColOne.r - _DropletTolerance && bgcolor.r <= _DropletColOne.r + _DropletTolerance) &&  //red 
			(bgcolor.g >= _DropletColOne.g - _DropletTolerance && bgcolor.g <= _DropletColOne.g + _DropletTolerance) &&  //green 
			(bgcolor.b >= _DropletColOne.b - _DropletTolerance && bgcolor.b <= _DropletColOne.b + _DropletTolerance)) {  //blue
				return lerp(grabToChange, _DropletColTwo, _DropletIntensity);
			}

			if (_ToggleDropletTwo) {
				if (
					(bgcolor.r >= _TwoDropletColOne.r - _TwoDropletTolerance && bgcolor.r <= _TwoDropletColOne.r + _TwoDropletTolerance) &&  //red 
					(bgcolor.g >= _TwoDropletColOne.g - _TwoDropletTolerance && bgcolor.g <= _TwoDropletColOne.g + _TwoDropletTolerance) &&  //green 
					(bgcolor.b >= _TwoDropletColOne.b - _TwoDropletTolerance && bgcolor.b <= _TwoDropletColOne.b + _TwoDropletTolerance)) { //blue
					return lerp(grabToChange, _TwoDropletColTwo, _TwoDropletIntensity);
				}
			}

			if (_ToggleDropletThree) {
				if (
					(bgcolor.r >= _ThreeDropletColOne.r - _ThreeDropletTolerance && bgcolor.r <= _ThreeDropletColOne.r + _ThreeDropletTolerance) &&  //red 
					(bgcolor.g >= _ThreeDropletColOne.g - _ThreeDropletTolerance && bgcolor.g <= _ThreeDropletColOne.g + _ThreeDropletTolerance) &&  //green 
					(bgcolor.b >= _ThreeDropletColOne.b - _ThreeDropletTolerance && bgcolor.b <= _ThreeDropletColOne.b + _ThreeDropletTolerance)) { //blue
					return lerp(grabToChange, _ThreeDropletColTwo, _ThreeDropletIntensity);
				}
			}

			if (_ToggleDropletFourth) {
				if (
					(bgcolor.r >= _FourDropletColOne.r - _FourDropletTolerance && bgcolor.r <= _FourDropletColOne.r + _FourDropletTolerance) &&  //red 
					(bgcolor.g >= _FourDropletColOne.g - _FourDropletTolerance && bgcolor.g <= _FourDropletColOne.g + _FourDropletTolerance) &&  //green 
					(bgcolor.b >= _FourDropletColOne.b - _FourDropletTolerance && bgcolor.b <= _FourDropletColOne.b + _FourDropletTolerance)) { //blue
					return lerp(grabToChange, _FourDropletColTwo, _FourDropletIntensity);
				}
			}

			//sepia
			float4 grabDropletSepia = dot(grabToChange.rgb, float3(0.3, 0.59, 0.11));
			grabToChange = lerp(grabToChange, grabDropletSepia, _ToggleDropletSepia);
		}

		//Effect: Filter
		UNITY_BRANCH
		if (_ToggleFilter) {

			//saving code using less variables later 
			float filterMinR = lerp(_FilterTolerance, _FilterMinR, _ToggleAdvancedFilter);
			float filterMaxR = lerp(_FilterTolerance, _FilterMaxR, _ToggleAdvancedFilter);
			float filterMinG = lerp(_FilterTolerance, _FilterMinG, _ToggleAdvancedFilter);
			float filterMaxG = lerp(_FilterTolerance, _FilterMaxG, _ToggleAdvancedFilter);
			float filterMinB = lerp(_FilterMinB, _FilterTolerance, _ToggleAdvancedFilter);
			float filterMaxB = lerp(_FilterTolerance, _FilterMaxB, _ToggleAdvancedFilter);

			//applying
			grabToChange.rgb = dot(grabToChange.rgb, float3(0.3, 0.59, 0.11));
			grabToChange.rgb = lerp(grabToChange.rgb, lerp(grabToChange, _BackgroundFilterColor, _BackgroundFilterIntensity), _ToggleColoredFilter);

			if (
			(bgcolor.r >= _FilterColor.r - filterMinR && bgcolor.r <= _FilterColor.r + filterMaxR) &&  //red 
			(bgcolor.g >= _FilterColor.g - filterMinG && bgcolor.g <= _FilterColor.g + filterMaxG) &&  //green 
			(bgcolor.b >= _FilterColor.b - filterMinB && bgcolor.b <= _FilterColor.b + filterMaxB)) {  //blue
				grabToChange = lerp(grabToChange, bgcolor, _FilterIntensity);
			}

		}

		//Effect: Linocut
		UNITY_BRANCH
		if (_LinocutOpacity > 0) {
			//Props to spite on ShaderToy, math based on it
			float2 center = (vo.projPos.x / 2, vo.projPos.y / 2);
			float2 uvMinusCenter = sceneUVs - center;
			float aTanCenter = atan2(uvMinusCenter.x, uvMinusCenter.y) + 1 * (0.5 - (length(uvMinusCenter) / 1000)) / 0.5;
			float2 centerTransformed = center + 0.5 * float2(cos(aTanCenter), sin(aTanCenter)) * _LinocutPower;
			float colLino = (0.75 + 0.25 * sin(centerTransformed.x * 1000));
			float toBWScale = dot(grabToChange.rgb, float3(0.299, 0.587, 0.114));
			float rgb = smoothstep(0, 0.5, float(smoothstep(0.5 * colLino, colLino, toBWScale)));
			float4 finalLinocut = float4(rgb, rgb, rgb, 0) * _LinocutColor;
			grabToChange = lerp(grabToChange, finalLinocut, _LinocutOpacity);
		}

		//Effect: Duotone
		UNITY_BRANCH
		if (_ToggleDuotone > 0) {
			//Props to Zoidberg on ISF who I based my math off of!
			float4 LuminCoeff = float4(0.299, 0.587, 0.114, 0.0);
			float4 averageAmount = float4(2.0, 2.0, 2.0, 2.0);
			float Lux = dot(grabToChange, LuminCoeff);
			float4 averagedColor = (_DuotoneColOne + _DuotoneColTwo) / averageAmount;
			float4 softDuo = grabToChange;
			if (Lux >= _DuotoneThreshold)
				grabToChange = lerp(grabToChange, lerp(averagedColor, _DuotoneColOne, smoothstep(_DuotoneThreshold, _DuotoneThreshold + ((1.0 - _DuotoneThreshold)*_DuotoneHardness), Lux)), _ToggleDuotone);
			else
				grabToChange = lerp(grabToChange, lerp(_DuotoneColTwo, averagedColor, smoothstep(_DuotoneThreshold - ((1.0 - _DuotoneThreshold)*_DuotoneHardness), _DuotoneThreshold, Lux)), _ToggleDuotone);
		}

		//Effect: Vignette
		UNITY_BRANCH
		if (_ToggleVignette > 0) {
			//setting up vignette
			float2 vignetteUv = sceneUVs * (1.0 - sceneUVs.yx);
			float vignette = vignetteUv.x * vignetteUv.y * _VigSharpness;
			vignette = pow(vignette, _VigX);

			//applying
			float4 darkVigCol = lerp(_VigCol * float4(0, 0, 0, 1), _VigCol*_VigColPow, vignette);
			_VigCol = lerp(darkVigCol, _VigCol * _VigColPow, _VigMode);
			float4 hardVig = lerp(_VigCol, grabToChange, vignette);
			float4 revHardVig = lerp(grabToChange, _VigCol, vignette);
			float4 vigGrab = lerp(hardVig, revHardVig, _VigReverse);
			if (_ToggleVignette > 0) grabToChange = lerp(grabToChange, vigGrab, _ToggleVignette);
		}

		//Effect: Rainbow
		UNITY_BRANCH
		if (_ToggleHSVRainbow > 0) {
			float hueMod = _Time.y*_HSVRainbowTime; //set up time
			hueMod += (sceneUVs.y*_ToggleHSVRainbowY); //vertical multiplier
			hueMod += (sceneUVs.x*_ToggleHSVRainbowX); //horizontal multiplier
			hueMod *= _HSVRainbowHue;
			float3 hsvColor = smoothHSV2RGB(float3(hueMod, _HSVRainbowSat, _HSVRainbowLight));
			grabToChange.rgb = lerp(grabToChange.rgb, grabToChange.rgb *= hsvColor, _ToggleHSVRainbow);
		}

		//Effect: Thermal (needs cleaned)
		UNITY_BRANCH
		if (_ThermalTransparency > 0) {

			//properties
			float _ThermRange = _ThermalHeat;
			float _ThermOrangeThresh = 7;
			float _ThermYellowThresh = 6;
			float _ThermLimeThresh = 5;
			float _ThermGreenThresh = 4;
			float _ThermTealThresh = 3;
			float _ThermBlueThresh = 2;
			float _ThermPurpleThresh = 1;

			//"normalizing" thermal range
			_ThermRange = 1 / _ThermRange; // calculating range by dividing by one

			//applying color-specific ranges to the normal range
			_ThermOrangeThresh *= _ThermRange;
			_ThermYellowThresh *= _ThermRange;
			_ThermLimeThresh *= _ThermRange;
			_ThermGreenThresh *= _ThermRange;
			_ThermTealThresh *= _ThermRange;
			_ThermBlueThresh *= _ThermRange;
			_ThermPurpleThresh *= _ThermRange;

			//colors
			float3 thermColBlack = float3(0.0, 0.0, 0.0);
			float3 thermColPurple = float3(0.2, 0.0, 0.45);
			float3 thermColBlue = float3(0.0, 0.0, 1.0);
			float3 thermColTeal = float3(0.0, 1.0, 1.0);
			float3 thermColGreen = float3(0.0, 1.0, 0.0);
			float3 thermColYellow = float3(1.0, 1.0, 0.0);
			float3 thermColOrange = float3(1.0, 0.5, 0.0);
			float3 thermColRed = float3(1.0, 0.0, 0.0);

			//converting to greyscale for luminance
			float luxanna = dot(grabToChange.rgb, float3(0.3, 0.59, 0.11));
			luxanna = pow(luxanna, _ThermalSensitivity);

			//storing new values
			float3 lowRGB = float3(0, 0, 0);
			float3 highRGB = float3(1, 1, 1);
			float normalizerValue = 0;

			//comparing luminance & applying hot --> cool colors
			if (luxanna > _ThermOrangeThresh) { /* orange */
				lowRGB = thermColOrange;
				highRGB = thermColRed;
				normalizerValue = 7;
			}
			else if (luxanna > _ThermYellowThresh) { /* yellow */
				lowRGB = thermColYellow;
				highRGB = thermColOrange;
				normalizerValue = 6;
			}
			else if (luxanna > _ThermLimeThresh) { /* lime */
				lowRGB = thermColGreen;
				highRGB = thermColYellow;
				normalizerValue = 5;
			}
			else if (luxanna > _ThermGreenThresh) { /* green */
				lowRGB = thermColGreen;
				highRGB = thermColGreen;
				normalizerValue = 4;
			}
			else if (luxanna > _ThermTealThresh) { /* teal */
				lowRGB = thermColTeal;
				highRGB = thermColGreen;
				normalizerValue = 3;
			}
			else if (luxanna > _ThermBlueThresh) { /* blue */
				lowRGB = thermColBlue;
				highRGB = thermColTeal;
				normalizerValue = 2;
			}
			else if (luxanna > _ThermPurpleThresh) { /* purple */
				lowRGB = thermColPurple;
				highRGB = thermColBlue;
				normalizerValue = 1;
			}
			else { /* to cool for school :sunglasses: */
				lowRGB = thermColBlack;
				highRGB = thermColPurple;
			}

			//lerping low and high color
			float thermalEquation = (luxanna - normalizerValue * _ThermRange) / _ThermRange; //unsure of source or if ported but not my original equation
			float4 finalThermal = lerp(
			fixed4(lowRGB, 1),
			fixed4(highRGB, 1),
			thermalEquation
			);

			//applying
			grabToChange = lerp(grabToChange, finalThermal*_ThermalColor, _ThermalTransparency);

		}

		//Effect: Color Spin
		UNITY_BRANCH
		if (_ToggleCC > 0) {
			//converted from vidvox's original shader
			//speed
			_CCSpeed = _CCSpeed * _Time.y;
			_CCRotate += _CCSpeed;

			//calculating
			float2 uvsRotate = sceneUVs;
			float4	dist = float4(0, 0, 0, 0);
			float pi = 3.1415926535897932384626433832795;
			float centerDistance = distance(float2(0.50, 0.50), uvsRotate);
			float aTanUVs = atan2((uvsRotate.y - 0.5), (uvsRotate.x - 0.5));

			//rotating the colors uvs
			uvsRotate.x = centerDistance * cos(aTanUVs + 2.0 * pi * _CCRotate - pi) + 0.5;
			uvsRotate.y = centerDistance * sin(aTanUVs + 2.0 * pi * _CCRotate - pi) + 0.5;

			//getting area for each color
			dist.r = max(1.0 - distance(float2(0.0, 0.0), uvsRotate), 0.0);
			dist.g = max(1.0 - distance(float2(1.0, 0.0), uvsRotate), 0.0);
			dist.b = max(1.0 - distance(float2(0.0, 1.0), uvsRotate), 0.0);
			dist.a = max(1.0 - distance(float2(1.0, 1.0), uvsRotate), 0.0);

			//blending colors really well, gj vidvox or whoever originally wrote this blend
			float	luma1 = (grabToChange.r + grabToChange.g + grabToChange.b) / 3.0;
			float4	resultPixel = (_CCOne * dist.r + _CCTwo * dist.g + _CCThree * dist.b + _CCFour * dist.a) / (dist.r + dist.g + dist.b + dist.a);
			float	luma2 = (resultPixel.r + resultPixel.g + resultPixel.b) / 3.0;
			resultPixel.rgb *= luma1 / luma2;
			resultPixel.a *= grabToChange.a;

			//applying
			float4 applyMulti = grabToChange * resultPixel;
			float4 applyEqual = resultPixel;

			UNITY_BRANCH
			if (_CCApply == 0)
			{
				grabToChange = lerp(grabToChange, applyEqual, _ToggleCC);
			}
			else if (_CCApply == 1)
			{
				grabToChange = lerp(grabToChange, applyMulti, _ToggleCC);
			}
			else if (_CCApply == 2)
			{
				grabToChange = lerp(grabToChange, (_CCOne * dist.r + _CCTwo * dist.g + _CCThree * dist.b + _CCFour * dist.a) / (dist.r + dist.g + dist.b + dist.a), _ToggleCC);
			}
		}

		//Effect: Film Grain
		UNITY_BRANCH
		if (_FilmPower > 0) {
			//Rewrote a WebGL shader from Github that was reposted, way more simple and optimized :)

			//variables to be used
			float2 oneMinusUV = 1 - sceneUVs;
			float stripeDirection = sceneUVs.x;
			float timeFactor = float(int(_Time.y * _FilmItterations));
			float4 filmGrab = grabToChange;


			//applying some creative time based brightness
			float vI =
				lerp(1, (sceneUVs.x * oneMinusUV.x * sceneUVs.y * oneMinusUV.y) + 1.0 + 0.4 * rand(timeFactor + 8.), _FilmBrightness);

			//generate large lines? if so, pass threshold (frequency)?
			if (_FilmAllowLines) {
				float lineCheck = rand(timeFactor) * 2;
				if (lineCheck > _FilmLinesOften) vI *= randomLine(timeFactor + 6.0 + 17.* lineCheck, sceneUVs);

			}

			//generate spots? if so, pass threshold (frequency)?
			if (_FilmAllowSpots) {
				float spotCheck = max(rand(timeFactor + 18.0) - 2.0, 0.0);
				if (spotCheck < _FilmSpotsOften) vI *= randomBlotch(
					(timeFactor + 6.0) + (19 * spotCheck), sceneUVs, _FilmSpotStrength);
			}

			//applying effects
			filmGrab.rgb *= vI;

			if (_FilmAllowStripes) {
				stripeDirection *= _FilmStripesOften;
				filmGrab.rgb *= (1.0 + (rand(stripeDirection + timeFactor * .01) - .2)*.15);
			}

			grabToChange.rgb = lerp(grabToChange.rgb, filmGrab.rgb, _FilmPower);
		}

		//Effect: Noise Mask
		UNITY_BRANCH
		if (_ToggleNoiseMask > 0) {
			float2 ratioUVs = sceneUVs.xy * _ScreenParams.xy;
			float2 maskUVs = ratioUVs / _ScreenParams.x;
			maskUVs *= _NoiseMaskScale;
			float maskApply = tex2D(_NoiseMask, maskUVs + (_Time*_NoiseMaskSpeedOne)).r;
			maskApply *= tex2D(_NoiseMask, maskUVs + (_Time*_NoiseMaskSpeedTwo)).g;
			float3 finalReturn = (maskApply, maskApply, maskApply) * (_NoiseMaskColor*_NoiseMaskGlow);
			finalReturn = pow(122, finalReturn);
			grabToChange.rgb = lerp(grabToChange.rgb, grabToChange.rgb*finalReturn, _ToggleNoiseMask);
		}

		//Effect: Fog
		UNITY_BRANCH
		if (_ToggleFog > 0 && _FogLayer == 0) { 
			UNITY_BRANCH
			if (_FogSafe > 0) {
				if ((getviewDirection() > _FogSafeTol)) {
					_FogDensity += (_FogDensity * getviewDirection() * _FogSafe);
				}
			}
			float rawDepth = DecodeFloatRG(tex2Dproj(_CameraDepthTexture, vo.projPos));
			float linearDepth = Linear01Depth(rawDepth);
			i.raycast *= (_ProjectionParams.z / i.raycast.z);
			float4 vpos = float4(i.raycast * linearDepth, 1);
			float3 wpos = mul(unity_CameraToWorld, vpos).xyz;
			float ds = distance(wpos, _WorldSpaceCameraPos);
			float fogRainbowMod = _Time.y*_FogRainbowSpeed; //set up time
			float3 fogRainbow = smoothHSV2RGB(float3(fogRainbowMod, 1, 1));
			_FogColor.rgb = lerp(_FogColor.rgb, fogRainbow, _FogRainbow);
			float4 noFog = grabToChange;
			grabToChange = lerp(grabToChange, _FogColor, _ToggleFog);
			if ((ds < _FogDensity)) {
				//cleanGrabToChange = lerp(bgcolor, cleanGrabToChange, (ds / _FogDensity));
				grabToChange = lerp(noFog, grabToChange, (ds / _FogDensity));
			}
		}

		//Effect: Depth of Field (needs optimized)
		UNITY_BRANCH
		if (_AllowDepthTest) {

			//focus on player?
			UNITY_BRANCH
			if (_KeepPlayerInFocus){
				if ((getviewDirection() > _DepthPlayerTolerance)) {
					_DepthValue += (_DepthValue * getviewDirection() * _DepthPlayerPower);
				}
			}

			float rawDepth = DecodeFloatRG(tex2Dproj(_CameraDepthTexture, vo.projPos));
			float linearDepth = Linear01Depth(rawDepth);
			i.raycast *= (_ProjectionParams.z / i.raycast.z);
			float4 vpos = float4(i.raycast * linearDepth, 1);
			float3 wpos = mul(unity_CameraToWorld, vpos).xyz;
			float ds = distance(wpos, _WorldSpaceCameraPos);


			if ((ds < _DepthValue) && !_ReverseDepth) {
				cleanGrabToChange = lerp(bgcolor, cleanGrabToChange, (ds / _DepthValue));
				grabToChange = lerp(bgcolor, grabToChange, (ds / _DepthValue));

			}
			else if ((ds > _DepthValue) && _ReverseDepth) {
				cleanGrabToChange = lerp(cleanGrabToChange, bgcolor, saturate(ds / _DepthValue));
				grabToChange = lerp(grabToChange, bgcolor, saturate(_DepthValue / _DepthValue));
			}
		}


		//Returning with falloff
		return lerp(cleanGrabToChange, grabToChange, returnOpacity);

	}
	//End of shader range
}
