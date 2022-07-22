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
//|				  strucctures  					  |
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
	float4 depthUV : TEXCOORD7;
	float4 normalUVs : TEXCOORD8;
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
sampler2D _LukaBackPass, _LukaFrontPass;
uniform float4 _LukaBackPass_ST, _LukaFrontPass_ST;

//falloff
float _FalloffRange, _ZoomRangeIncrease, _ToggleRenderLookAtMe, _RenderMeTolerance, _AllowSmartFalloff, _SmartFalloffMin, _SmartFalloffMax;

//chromatic abberation
float _ToggleRGB, _RedXValue, _RedYValue, _GreenXValue, _GreenYValue, _BlueXValue, _BlueYValue, _CAMode, _ToggleCleanRGB, _CASamples, _CATrans, _CAStyle, _CARotate, _CARotateSpeed, _CAOffsetX, _CAOffsetY;
float _ToggleAutoanimate, _RGBAutoanimateSpeed;
float _ToggleGreenMove, _RotationStrength, _RotationSpeedRed, _RotationSpeedBlue, _RotationSpeedGreen, _DirectionRed, _DirectionBlue, _DirectionGreen, _ToggleScreenFollow;

//color split
float4 _ColorSplitRGBone, _ColorSplitRGBtwo, _ColorSplitRGBthree;
float _ToggleColorSplit, _ColorSplitAmount, _ToggleAutoanimateColorSplit, _ColorSplitSpeed, _ToggleColorSplitStaySides, _ColSpONEopacity, _ColSpTWOopacity, _ColSpTHREEopacity, _CSLX, _CSLY, _CSMX, _CSMY, _CSRX, _CSRY,
_CSL, _CSRotate, _ColSplRotateSpeed, _CSOffsetX, _CSOffsetY, _CSTrans;

//glitch random rgb
float _ToggleGlitchChromatic, _GlitchRGB, _GlitchRGBSpeed, _GlitchRGBStrength, _ToggleGlitch;

//glitch rgb
float _ToggleRGBGlitch, _RedNoisePower, _RedNoiseSpeed, _RedBlocks, _GreenNoisePower, _GreenNoiseSpeed, _GreenBlocks, _BlueNoisePower, _BlueNoiseSpeed,
	_BlueBlocks, _RedBlockCount, _GreenBlockCount, _BlueBlockCount, _RedBlockSpeed, _GreenBlockSpeed, _BlueBlockSpeed, _RGBGlitchTrans, _RGBBlockMethod;
sampler2D _RedNoiseMap, _GreenNoiseMap, _BlueNoiseMap;

//block glitch rgb
sampler2D _BlockGlitchMap, _BGOverlayMap;
float4 _BlockGlitchMap_ST, _BGOverlayColor;
float _ToggleBlockyRGB, _BlockyRGBPush, _ToggleBlockyGlitch, _AllowBGColors, _BGOverlayIntensity, _BGBrokenColorIntensity, _BGOverlayToggle,
	_BlockyGlitchStrength, _BlockyGlitchSpeed, _BlockyRGBSpeed, _BGBrokenRandom, _BDepthX, _BDepthY;

//visualizer
float _ToggleVisualizer, _VisBarLeft, _VisBarRight, _VisBarWidth, _VisBaseWidth, _VisMode,
_ToggleHSVRainbowVis, _ToggleHSVRainbowXVis, _ToggleHSVRainbowYVis, _HSVRainbowHueVis, _HSVRainbowSatVis, _HSVRainbowLightVis, _HSVRainbowTimeVis,
_VisBarThree, _VisBarFour, _VisBarFive, _VisBarSix, _VisBarSeven, _VisBarEight, _VisBarNine, _VisBarTen, _VisCircleSize, _VisClassicBase, _VisClassicShape, _VisBarRainbow, _VisClassicMaxSize;
float4 _VisBarColor, _VisBaseColor, _VisStopperColor;

//reel
float _ToggleReel, _ReelSpeed, _ReelBars, _ReelWidth, _ReelBarHeigth, _ReelBarAmounts, _ReelJitter, _ReelMode, _ReelRainbow, _ReelRainbowX, _ReelRainbowY, _FilmPower;
float4 _ReelColor;

//make zoom work
float _ToggleZoom;

//rgb hide
float _HideRedTrans, _HideGreenTrans, _HideBlueTrans;

//depth
sampler2D_float _CameraDepthTexture;
float _AllowDepthTest, _DepthValue, _ReverseDepth;

//new depth stuff
float _KeepPlayerInFocus, _DepthPlayerTolerance, _DepthPlayerPower;

//overall opacity
float _OverallOpacity;

//warp zoom
float _ToggleWarpZoom, _WarpZoomAmount, _WarpZoomTolerance;

//zoom range
float _ToggleZoomRange, _ZoomRange, _ZoomFStart, _ZoomFEnd;

//inception
float _ToggleInception, _InceptionItterations, _InceptionSize, _InceptionShiftX, _InceptionShiftY;

//multiple screens
float _ScreensXRow, _ToggleScreens;

//overlay
float _ToggleOverlay, _UseSepOverlay, _OverlayTransparency, _OverlayXAdjust, _OverlayYAdjust, _OverlayTiling, _OverlayXShift, _OverlayYShift, _OvScOne, _OvScOneY, _OvScOneT;
sampler2D _OverlayTexture, _VROverlayTexture;
float4 _OverlayTexture_ST, _VROverlayTexture_ST;

//overlay two
float _ToggleOverlayTwo, _OverlayTransparencyTwo,  _OverlayXAdjustTwo, _OverlayYAdjustTwo, _OverlayTilingTwo, _OverlayXShiftTwo, _OverlayYShiftTwo, _OvScTwo, _OvScTwoY, _OvScTwoT;
sampler2D _OverlayTextureTwo;
float4 _OverlayTextureTwo_ST;

//overlay three
float _ToggleOverlayThree, _OverlayTransparencyThree, _OverlayXAdjustThree, _OverlayYAdjustThree, _OverlayTilingThree, _OverlayXShiftThree, _OverlayYShiftThree, _OvScThree, _OvScThreeY, _OvScThreeT;
float _OverlayTrans, _OverlayTransX, _OverlayTransY, _OverlayTransTwo, _OverlayTransXTwo, _OverlayTransYTwo, _OverlayTransThree, _OverlayTransXThree, _OverlayTransYThree;
sampler2D _OverlayTextureThree;
float4 _OverlayTextureThree_ST;

//gif overlay
float _ToggleGifOverlay, _OSSRows, _OSSColumns, _OSSSpeed, _OSTotalTiles, _GifTransparency, _GifXAdjust, _GifYAdjust, _GifTiling, _GifXShift, _GifYShift;
sampler2D _OverlaySpritesheet;
float4 _OverlaySpritesheet_ST, fixGifForVr_ST, _GifColorToCut;

//overlay transparencies
float _ToggleTransparentImage, _ToggleTransparentImageTwo, _ToggleTransparentImageThree, _ToggleACTUALTransparentGif;

//blink
float _BlinkStrength, _BlinkMode, _ForceBlink, _BlinkImageX, _BlinkImageY, _BlinkImagePower,
_BlinkBorderSize, _BlinkRainbow, _BlinkRainbowX, _BlinkRainbowY, _BlinkRainbowHue, _BlinkRainbowSat, _BlinkRainbowLight, _BlinkRainbowTime, _BlinkRainbowMode;
float4 _BlinkColor;
sampler2D _BlinkImage;
float4 _BlinkImage_ST, _BlinkBorder;

//transistion
float _TransX, _TransY, _ToggleTransistion, _ToggleDiagTrans, _TransDL, _TransDR;

//vr
float _VRAdjust, _VRPreview, _VRLeft, _VRRight;
float4 _VRLeftColor, _VRRightColor;



//|===============================================|
//|				  functions   					  |
//|===============================================|
float rgbRand(float2 co) {
	//RGB Block Random Function from ShaderToy (will put author here)
	return frac(sin(dot(co.xy, float2(12.9898, 78.233))) * 43758.5453) * 2.0 - 1.0;
}

float rand(float n) {
	return frac(sin(n) * 43758.5453123);
}

float noise(float p) {
	float fl = floor(p);
	float fc = frac(p);
	return lerp(rand(fl), rand(fl + 1.0), fc);
}

float glitchNoiseGenerator(float2 uv, float threshold, float scale, float seed, sampler2D _BlockGlitchMap)
{
	//Blocky glitch noise generator (see front pass for more info)
	float scroll = floor(_Time.y + sin(11.0 *  _Time.y) + sin(_Time.y)) * 0.77;
	float2 noiseUV = uv.yy / scale + scroll;
	float noise2 = tex2D(_BlockGlitchMap, noiseUV).r;
	float id = floor(noise2 * 20.0);
	id = noise(id + seed) - 0.5;
	if (abs(id) > threshold)
		id = 0.0;

	return id;
}

float3 randomizeColor(float3 overlayColor, float2 sceneUVs, float divFactor, float2 boundaries) {

	float lineDecider = frac(sceneUVs.y / divFactor);
	if (lineDecider > boundaries.x) { overlayColor = float3(1.0, 3.0, 0.0); }
	else if (lineDecider > boundaries.y) { overlayColor = float3(1.0, 0.0, 3.0); }
	return overlayColor;

}

float randomNegativeChance(float chance, float numberToNegate) {
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
	//written by uncomfy, permission from docme <3
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

float rgbWave(float blockCount, float timeCount, float sceneUVs) {
	float2 randomTest = rgbRand(float2(_Time.y, floor(sceneUVs * blockCount)));
	return float2(sin(_Time.y * sceneUVs * timeCount), randomTest.y);
}

float rgbOffset(float blockCount, float timeCount, float sceneUVs) {
	//Still expirementing... c:
	//return rand(float2(_Time.y, floor(sceneUvs.y * blocks)));
	return rgbRand(float2(_Time.y * timeCount, floor(sceneUVs * blockCount)));
	//float2 texNoise = tex2D(noiseMap, sceneUVswhole).xy;
	//float2 randomRGB = rgbRand(float2(_Time.y * timeCount * texNoise.x, floor(sceneUVs * blockCount)));
	//return float2(sin(_Time.y * timeCount), randomRGB.y);
}



//|===============================================|
//|				  vertex    					  |
//|===============================================|
v2f vert(appdata_base v, appdata p, VertexInput vi, float4 pos : POSITION) {
	v2f o;
	o.uv0 = vi.texcoord0;
	o.overlayCoordinates = mul(unity_ObjectToWorld, v.vertex);
	o.pos = UnityObjectToClipPos(v.vertex);
	o.grabPos = ComputeGrabScreenPos(o.pos);
	o.normalUVs = o.grabPos;
	o.depthUV = ComputeScreenPos(o.pos);
	o.raycast = UnityObjectToViewPos(v.vertex).xyz * float3(-1, -1, 1);
	o.raycast = lerp(o.raycast, p.depthUV, p.depthUV.z != 0);

	//Fix camera posistion in VR
	#if UNITY_SINGLE_PASS_STEREO
		o.cameraPos = (unity_StereoWorldSpaceCameraPos[0] + unity_StereoWorldSpaceCameraPos[1])*0.5;
	#else
		o.cameraPos = _WorldSpaceCameraPos;
	#endif

	//Establish a range
	float4 objToWorld = mul(unity_ObjectToWorld, float4(0, 0, 0, 1));
	float getDistanceAway = distance(_WorldSpaceCameraPos, objToWorld);

	//Start zoom range (tons of messy code I wrote at like 1 am, needs rewrote..)
	float testZoomFalloff = 0;
	//Manually fixing warp zoom
	_ZoomFEnd -= (_ZoomFEnd / 5);
	float fixedFallMin = _SmartFalloffMin - (_SmartFalloffMin / 5);
	if (_ToggleZoomRange || _AllowSmartFalloff) testZoomFalloff = 1;
	if (!_ToggleZoomRange) {
		_ZoomFStart = fixedFallMin;
		_ZoomFEnd = _SmartFalloffMax;
		_ZoomRange = _FalloffRange;
	}
	if (getDistanceAway <= _ZoomRange) {

		//Creating falloff for warped zoom
		UNITY_BRANCH
		if (testZoomFalloff || _VRAdjust < 1) {
			float clampingDistanceRanges = clamp(getDistanceAway, _ZoomFStart, _ZoomFEnd);
			float returnOpacity = (1.0 - (clampingDistanceRanges - _ZoomFStart) / (_ZoomFStart));
			returnOpacity = clamp(returnOpacity, 0, 1);
			returnOpacity *= _OverallOpacity;
			#if UNITY_SINGLE_PASS_STEREO
				returnOpacity *= _VRAdjust;
			#endif
			if (_VRPreview) returnOpacity *= _VRAdjust;
			_WarpZoomAmount = 0 + (returnOpacity - 0) * (_WarpZoomAmount - 0) / (1 - 0);
		}

		//Effect: Warp Zoom
		UNITY_BRANCH
		if (_ToggleWarpZoom) {
			float4 zoomUv = ComputeGrabScreenPos(UnityObjectToClipPos(v.vertex));
			float4 zoomValue = ComputeGrabScreenPos(o.pos) - zoomUv;
			float angledZoom =
				(_WarpZoomAmount * ((getviewDirection() > _WarpZoomTolerance) ? ((getviewDirection() - _WarpZoomTolerance) / (1.0 - _WarpZoomTolerance)) : 0.0));
			vi.worldPos = mul(unity_ObjectToWorld, v.vertex);
			float4 worldObjToPos = mul(unity_WorldToObject, float4(vi.worldPos.xyz, 1));
			float4 clipPosOne = UnityObjectToClipPos(worldObjToPos.xyz);
			float4 clipPosTwo = ComputeGrabScreenPos(clipPosOne);
			float4 clipPosThree = UnityObjectToClipPos(float4(0, 0, 0, 1).xyz);
			float4 clipPosFour = ComputeGrabScreenPos(clipPosThree);
			o.grabPos = (zoomUv)+(clipPosFour * (angledZoom));
		}
	}
	return o;
}



//|===============================================|
//|				  pixel     					  |
//|===============================================|
half4 frag(v2f i, VertexOutput vo, float facing : VFACE) : SV_Target: COLOR
{

	//Building the scene
	float2 sceneUVs = (vo.projPos.xy / vo.projPos.w);
	float2 cleanSceneUVs = (i.normalUVs.xy / i.normalUVs.w);
	float2 cleanUVs = sceneUVs;
	float4 bgcolor = tex2D(_LukaBackPass, sceneUVs);

	//Establishing a range
	float4 objToWorld = mul(unity_ObjectToWorld,float4(0,0,0,1));
	float getDistanceAway = distance(_WorldSpaceCameraPos, objToWorld);

	//Determing if the player is within range
	if (getDistanceAway >= _FalloffRange) {
		return bgcolor;
	}
	else {

		//Establishing Falloff (could maybe be optimized)
		float clampingDistanceRanges = clamp(getDistanceAway, _SmartFalloffMin, _SmartFalloffMax);
		float returnOpacity = (clampingDistanceRanges - _SmartFalloffMin) / (_SmartFalloffMax - _SmartFalloffMin);
		returnOpacity = smoothstep(1, 0, returnOpacity);
		returnOpacity = lerp(1, returnOpacity, _AllowSmartFalloff);
		returnOpacity = returnOpacity * _OverallOpacity;

		//Applying only render if looking at me
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

		//Applying VR adjustment strength
		#if UNITY_SINGLE_PASS_STEREO
			returnOpacity *= _VRAdjust;
		#endif
		if (_VRPreview) returnOpacity *= _VRAdjust;

		//Effect: VR Closed Eye
		#if UNITY_SINGLE_PASS_STEREO
			if (sceneUVs.x >= 0.5 && _VRLeft) {
				return _VRLeftColor;
			}
			else if (sceneUVs.x < 0.5 && _VRRight) {
				return _VRRightColor;
			}
		#endif

		//Effect: Screens
		UNITY_BRANCH
		if (_ToggleScreens > 0) {
			float3 shaderFAdjustOne = mul(UNITY_MATRIX_V, float4((i.overlayCoordinates.rgb - _WorldSpaceCameraPos), 0)).xyz;
			float2 shaderFAdjustTwo = (shaderFAdjustOne.rgb.rg / shaderFAdjustOne.rgb.b).rg;
			float vrAdjuster = 1;
			#ifdef UNITY_SINGLE_PASS_STEREO
				vrAdjuster *= 2;
			#endif
			float2 sfAdFinalColorScreen = float2(
				((_ScreenParams.b / _ScreenParams.a) //params 
					* shaderFAdjustTwo.r) //x axis 
				, (shaderFAdjustTwo.g)) //y axis 
				* (_ScreensXRow / (_ScreenParams.xy / 1000)) + 0.5;
			sfAdFinalColorScreen *= vrAdjuster;
			sfAdFinalColorScreen -= floor(sfAdFinalColorScreen);
			//float4 overScreen = tex2D(_LukaBackPass, sfAdFinalColorScreen);
			sceneUVs = lerp(sceneUVs, sfAdFinalColorScreen, _ToggleScreens);
		}

		//Applying falloff
		sceneUVs = lerp(cleanUVs, sceneUVs, returnOpacity);

		//Setting up the scene again
		float4 grabToChange = tex2D(_LukaBackPass, sceneUVs);
		float4 cleanGrabToChange = tex2D(_LukaBackPass, sceneUVs);

		//Effect: Chromatic Abberation (RGB Split)
		if (_ToggleRGB) {

			//normal rgb split 
			UNITY_BRANCH
			if (_CAStyle == 0) {

				//autoanimate
				_RedXValue = lerp(_RedXValue, (abs(sin(_Time.y * (_RGBAutoanimateSpeed))) * _RedXValue), _ToggleAutoanimate);
				_BlueXValue = lerp(_BlueXValue, (abs(sin(_Time.y * (_RGBAutoanimateSpeed))) * _BlueXValue), _ToggleAutoanimate);

				//setting up rgb textures for easier use
				float2 redUVs = float2(sceneUVs.x + _RedXValue, sceneUVs.y + _RedYValue);
				float2 greenUVs = float2(sceneUVs.x + _GreenXValue, sceneUVs.y + _GreenYValue);
				float2 blueUVs = float2(sceneUVs.x + _BlueXValue, sceneUVs.y + _BlueYValue);
				float redGrab = tex2D(_LukaBackPass, redUVs).r;
				float greenGrab = tex2D(_LukaBackPass, greenUVs).g;
				float blueGrab = tex2D(_LukaBackPass, blueUVs).b;
				float hueGrab = rgb2hsv(tex2D(_LukaBackPass, redUVs)).r;
				float satGrab = rgb2hsv(tex2D(_LukaBackPass, greenUVs)).g;
				float valueGrab = rgb2hsv(tex2D(_LukaBackPass, blueUVs)).b;
				float4 negativityGrabOne = 0 - tex2D(_LukaBackPass, redUVs);
				float4 negativityGrabTwo = tex2D(_LukaBackPass, greenUVs) * 2;
				float4 negativityGrabThree = 0 - tex2D(_LukaBackPass, blueUVs);

				//applying rgb hide settings
				redGrab = lerp(cleanGrabToChange, redGrab, _HideRedTrans);
				greenGrab = lerp(cleanGrabToChange, greenGrab, _HideGreenTrans);
				blueGrab = lerp(cleanGrabToChange, blueGrab, _HideBlueTrans);
				hueGrab = lerp(cleanGrabToChange, hueGrab, _HideRedTrans);
				satGrab = lerp(cleanGrabToChange, satGrab, _HideBlueTrans);
				valueGrab = lerp(cleanGrabToChange, valueGrab, _HideGreenTrans);

				//rgb or hsv?
				grabToChange.rgb = lerp(
					float3(redGrab, greenGrab, blueGrab),
					hsv2rgb(float3(hueGrab, satGrab, valueGrab)),
				clamp(_CAMode, 0, 1));

				//rgb/hsv or negativity?
				grabToChange.rgb = lerp(
					grabToChange.rgb,
					negativityGrabOne + negativityGrabTwo + negativityGrabThree,
				valueRemap(clamp(_CAMode, 1, 2), 1, 2, 0, 1));

				//clean rgb?
				UNITY_BRANCH
				if (_ToggleCleanRGB) {
					if (redUVs.x > 1 || redUVs.x < 0 || redUVs.y > 1 || redUVs.y < 0) {
						grabToChange.r = 0;
					}
					if (greenUVs.x > 1 || greenUVs.x < 0 || greenUVs.y > 1 || greenUVs.y < 0) {
						grabToChange.g = 0;
					}
					if (blueUVs.x > 1 || blueUVs.x < 0 || blueUVs.y > 1 || blueUVs.y < 0) {
						grabToChange.b = 0;
					}
				}
			}
			//rotating rgb split 
			else if (_CAStyle == 2)
			{
				//establishing rotation matrixes
				float sinXR = sin(_RotationSpeedRed * _Time);
				float cosXR = cos(_RotationSpeedRed * _Time);
				float sinYR = sin(_RotationSpeedRed * _Time);
				float2x2 rotationMatrixRed = float2x2(cosXR, -sinXR, sinYR, cosXR);

				float sinXB = sin(_RotationSpeedBlue * _Time);
				float cosXB = cos(_RotationSpeedBlue * _Time);
				float sinYB = sin(_RotationSpeedBlue * _Time);
				float2x2 rotationMatrixBlue = float2x2(cosXB, -sinXB, sinYB, cosXB);

				float sinXG = sin(_RotationSpeedGreen * _Time);
				float cosXG = cos(_RotationSpeedGreen * _Time);
				float sinYG = sin(_RotationSpeedGreen * _Time);
				float2x2 rotationMatrixGreen = float2x2(cosXG, -sinXG, sinYG, cosXG);

				//rotation matrix directions
				float2 rDirection = mul(normalize(float2(0, _DirectionRed)), rotationMatrixRed);
				float2 bDirection = mul(normalize(float2(0, _DirectionBlue)), rotationMatrixBlue);
				float2 gDirection = mul(normalize(float2(0, _DirectionGreen)), rotationMatrixGreen);

				//force screen follow
				UNITY_BRANCH
				if (_ToggleScreenFollow == 1) {
					_RotationStrength = sin(_Time.y * (_RotationStrength));
				}

				//setting up rgb textures for easier use
				fixed2 rotRedUV = sceneUVs + _RotationStrength * rDirection;
				fixed2 rotBlueUV = sceneUVs + _RotationStrength * bDirection;

				//rgb or hsv? & creating color splits
				float redGrab = tex2D(_LukaBackPass, rotRedUV).r;
				float blueGrab = tex2D(_LukaBackPass, rotBlueUV).b;
				float hueGrab = rgb2hsv(tex2D(_LukaBackPass, rotRedUV)).r;
				float valueGrab = rgb2hsv(tex2D(_LukaBackPass, rotBlueUV)).b;
				redGrab = lerp(redGrab, hueGrab, _CAMode);
				blueGrab = lerp(blueGrab, valueGrab, _CAMode);

				//setting up rotation split
				grabToChange.r = lerp(cleanGrabToChange.r, redGrab, _HideRedTrans);
				grabToChange.b = lerp(cleanGrabToChange.b, blueGrab, _HideBlueTrans);

				//green movement optional
				float2 rotGreenUV;
				UNITY_BRANCH
				if (_ToggleGreenMove) {
					rotGreenUV = sceneUVs + _RotationStrength * gDirection;
					float greenGrab = tex2D(_LukaBackPass, rotGreenUV).g;
					float satGrab = rgb2hsv(tex2D(_LukaBackPass, rotGreenUV)).g;
					greenGrab = lerp(greenGrab, satGrab, _CAMode);
					grabToChange.g = lerp(cleanGrabToChange, greenGrab, _HideGreenTrans);
				}

				//clean rgb?
				UNITY_BRANCH
				if (_ToggleCleanRGB) {
					if (rotRedUV.x > 1 || rotRedUV.x < 0 || rotRedUV.y > 1 || rotRedUV.y < 0) {
						grabToChange.r = 0;
					}
					if (rotGreenUV.x > 1 || rotGreenUV.x < 0 || rotGreenUV.y > 1 || rotGreenUV.y < 0) {
						grabToChange.g = 0;
					}
					if (rotBlueUV.x > 1 || rotBlueUV.x < 0 || rotBlueUV.y > 1 || rotBlueUV.y < 0) {
						grabToChange.b = 0;
					}
				}
			}
			//sampled rgb split
			else if (_CAStyle == 1) {

				//autoanimate?
				_RedXValue = lerp(_RedXValue, (abs(sin(_Time.y * (_RGBAutoanimateSpeed))) * _RedXValue), _ToggleAutoanimate);
				_BlueXValue = lerp(_BlueXValue, (abs(sin(_Time.y * (_RGBAutoanimateSpeed))) * _BlueXValue), _ToggleAutoanimate);

				//ramping up values for sampled
				_RedXValue *= 3;
				_GreenXValue *= 3;
				_BlueXValue *= 3;

				//setting up rotate
				float2 rotateValue = float2(1, 1); sincos(_CARotate + (_CARotateSpeed * _Time.y), rotateValue.y, rotateValue.x);

				//setting up offset
				float2 caOffset = float2(_CAOffsetX, _CAOffsetY);

				float redGrabStart = tex2D(_LukaBackPass, sceneUVs + float2((1.1 / (_CASamples - 1) * rotateValue.x * _RedXValue), (1.1 / (_CASamples - 1) * rotateValue.y * _RedXValue)) + caOffset).r;
				float greenGrabStart = tex2D(_LukaBackPass, sceneUVs).g;
				float blueGrabStart = tex2D(_LukaBackPass, sceneUVs + float2(-(1.1 / (_CASamples - 1) * rotateValue.x * _BlueXValue), -(1.1 / (_CASamples - 1) * rotateValue.y * _BlueXValue)) + caOffset).b;
				grabToChange = float4(redGrabStart, greenGrabStart, blueGrabStart, 1);

				[unroll(32)]for (float i = 0; i < _CASamples; i++) {
					float2 redAdd = float2((i / (_CASamples - 1) * rotateValue.x * _RedXValue), (i / (_CASamples - 1) * rotateValue.y * _RedXValue)) + caOffset;
					float2 blueAdd = float2(-(i / (_CASamples - 1) * rotateValue.x * _BlueXValue), -(i / (_CASamples - 1) * rotateValue.y * _BlueXValue)) + caOffset;
					float redGrab = tex2D(_LukaBackPass, sceneUVs + redAdd).r;
					float greenGrab = tex2D(_LukaBackPass, sceneUVs).g;
					float testModulos = fmod(i, 2);
					float2 greenOffset = float2((i / (_CASamples - 1) * rotateValue.x * (_RedXValue * _GreenXValue)), (i / (_CASamples - 1) * rotateValue.y * (_RedXValue * _GreenXValue)));
					greenOffset = lerp(greenOffset, -greenOffset, testModulos);
					greenGrab = tex2D(_LukaBackPass, sceneUVs + greenOffset + caOffset).g;
					float blueGrab = tex2D(_LukaBackPass, sceneUVs + blueAdd).b;
					grabToChange += float4(lerp(0, redGrab, _HideRedTrans), lerp(0, greenGrab, _HideGreenTrans), lerp(0, blueGrab, _HideBlueTrans), 1);
				}

				grabToChange = grabToChange / (_CASamples);

			}
     		//applying rgb split visibility
			grabToChange = lerp(bgcolor, grabToChange, _CATrans);
		}

		//Effect: Color Split
		UNITY_BRANCH
		if (_ToggleColorSplit)
		{
			float4 previousGrab = grabToChange;
			float2 rotateValue = float2(1, 1); sincos(_CSRotate + (_ColSplRotateSpeed * _Time.y), rotateValue.y, rotateValue.x);
			UNITY_BRANCH
			if (_CSRotate > 0) {
				_CSLY += 0.1;
				_CSMY += 0.1;
				_CSRY += 0.1;
			}
			UNITY_BRANCH
			if (_CSL > 1) {
				float2 leftOffset = float2(_CSLX, _CSLY);
				float2 middleOffset = float2(_CSMX, _CSMY);
				float2 rightOffset = float2(_CSRX, _CSRY);
				if (_ToggleAutoanimateColorSplit) {
					leftOffset *= sin(_Time.y * _ColorSplitSpeed);
					middleOffset *= sin(_Time.y * _ColorSplitSpeed);
					rightOffset *= sin(_Time.y * _ColorSplitSpeed);
				}
				float2 csOffset = float2(_CSOffsetX, _CSOffsetY);
				[unroll(32)]for (float i = 0; i < _CSL; i++) {
					grabToChange += (tex2D(_LukaBackPass, sceneUVs + float2((i / (_CSL - 1) * rotateValue.x * leftOffset.x), (i / (_CSL - 1) * rotateValue.y * leftOffset.y)) + csOffset) * (_ColorSplitRGBone * _ColSpONEopacity));
					if (i < (_CSL / 2)) {
						grabToChange += (tex2D(_LukaBackPass, sceneUVs + float2((i / (_CSL - 1) * rotateValue.x * (leftOffset.x * middleOffset.x)), (i / (_CSL - 1) * rotateValue.y * (leftOffset.y * middleOffset.y))) + csOffset) *  (_ColorSplitRGBtwo * _ColSpTWOopacity));
					}
					else {
						grabToChange += (tex2D(_LukaBackPass, sceneUVs + float2(-(i / (_CSL - 1) * rotateValue.x * (rightOffset.x * middleOffset.x)), -(i / (_CSL - 1) * rotateValue.y * (rightOffset.y * middleOffset.y))) + csOffset) *  (_ColorSplitRGBtwo * _ColSpTWOopacity));
					}
					grabToChange += (tex2D(_LukaBackPass, sceneUVs + float2(-(i / (_CSL - 1) * rotateValue.x * rightOffset.x), -(i / (_CSL - 1) * rotateValue.y * rightOffset.y)) + csOffset) * (_ColorSplitRGBthree * _ColSpTHREEopacity));
				}
				//divide the sum of values by the amount of samples
				grabToChange = grabToChange / ((_CSL) * 2);
				grabToChange = lerp(previousGrab, grabToChange, _CSTrans);
				if (_ToggleRGB) grabToChange = (previousGrab + grabToChange) / 2;
			}
			else {
				float2 csOffset = float2(_CSOffsetX, _CSOffsetY);
				float2 leftOffset = float2(_CSLX * rotateValue.x, _CSLY * rotateValue.y) + csOffset;
				float2 middleOffset = float2(_CSMX * rotateValue.x, _CSMY * rotateValue.y) + csOffset;
				float2 rightOffset = float2(_CSRX * rotateValue.x, _CSRY * rotateValue.y) + csOffset;
				if (_ToggleAutoanimateColorSplit) {
					leftOffset *= sin(_Time.y * _ColorSplitSpeed);
					middleOffset *= sin(_Time.y * _ColorSplitSpeed);
					rightOffset *= sin(_Time.y * _ColorSplitSpeed);
				}
				float4 leftSplit = tex2D(_LukaBackPass, sceneUVs + leftOffset);
				float4 middleSplit = tex2D(_LukaBackPass, sceneUVs + middleOffset);
				float4 rightSplit = tex2D(_LukaBackPass, sceneUVs - rightOffset);
				leftSplit *= (_ColorSplitRGBone * _ColSpONEopacity);
				middleSplit *= (_ColorSplitRGBtwo * _ColSpTWOopacity);
				rightSplit *= (_ColorSplitRGBthree * _ColSpTHREEopacity);
				grabToChange = leftSplit + middleSplit + rightSplit;
				grabToChange /= 3;
				grabToChange = lerp(previousGrab, grabToChange, _CSTrans);
				if (_ToggleRGB) grabToChange = (previousGrab + grabToChange) / 2;
			}
		}

		//Effect: Chromatic Abberation (RGB) Glitch
		UNITY_BRANCH
		if (_ToggleRGBGlitch) {

			//storing for transparency
			float4 previousGrab = grabToChange;

			//applying chromatic shake
			float2 redOffset = float2(_RedNoisePower * sin(_RedNoiseSpeed * _Time.y), _RedNoisePower * sin(_RedNoiseSpeed * _Time.y));
			redOffset *= tex2D(_RedNoiseMap, redOffset).xy;
			redOffset *= float2(randomNegativeChance(redOffset.x*0.1, 1),randomNegativeChance(redOffset.y*0.1, 1));
			float2 greenOffset = float2(sin(_GreenNoiseSpeed * _Time.y), sin(_GreenNoiseSpeed * _Time.y));
			greenOffset *= tex2D(_GreenNoiseMap, greenOffset).xy;
			greenOffset *= float2(_GreenNoisePower * randomNegativeChance(greenOffset.x*0.2, 1), _GreenNoisePower * randomNegativeChance(greenOffset.y*0.2, 1));
			float2 blueOffset = float2(sin(_BlueNoiseSpeed * _Time.y), sin(_BlueNoiseSpeed * _Time.y));
			blueOffset *= tex2D(_BlueNoiseMap, blueOffset).xy;
			blueOffset *= float2(_BlueNoisePower * randomNegativeChance(blueOffset.x*0.3, 1), _BlueNoisePower * randomNegativeChance(blueOffset.y*0.3, 1));

			//applying chromatic blocks
			UNITY_BRANCH
			if (_RGBBlockMethod == 0) {
				redOffset += float2(rgbOffset(_RedBlockCount, _RedBlockSpeed, sceneUVs.y) * _RedBlocks, 0);
				greenOffset += float2(rgbOffset(_GreenBlockCount, _GreenBlockSpeed, sceneUVs.y) * _GreenBlocks, 0.0);
				blueOffset += float2(rgbOffset(_BlueBlockCount, _BlueBlockSpeed, sceneUVs.y) * _BlueBlocks, 0.0);
			}
			else if (_RGBBlockMethod == 1) {
				redOffset += float2(0, rgbOffset(_RedBlockCount, _RedBlockSpeed, sceneUVs.x) * _RedBlocks);
				greenOffset += float2(0, rgbOffset(_GreenBlockCount, _GreenBlockSpeed, sceneUVs.x) * _GreenBlocks);
				blueOffset += float2(0, rgbOffset(_BlueBlockCount, _BlueBlockSpeed, sceneUVs.x) * _BlueBlocks);
			}
			else if (_RGBBlockMethod == 2) {
				redOffset += float2(rgbOffset(_RedBlockCount, _RedBlockSpeed, sceneUVs.y) * _RedBlocks, rgbOffset(_RedBlockCount, _RedBlockSpeed, sceneUVs.x) * _RedBlocks);
				greenOffset += float2(rgbOffset(_GreenBlockCount, _GreenBlockSpeed, sceneUVs.y) * _GreenBlocks, rgbOffset(_GreenBlockCount, _GreenBlockSpeed, sceneUVs.x) * _GreenBlocks);
				blueOffset += float2(rgbOffset(_BlueBlockCount, _BlueBlockSpeed, sceneUVs.y) * _BlueBlocks, rgbOffset(_BlueBlockCount, _BlueBlockSpeed, sceneUVs.x) * _BlueBlocks);
			}

			//applying
			grabToChange.r = tex2D(_LukaBackPass, sceneUVs + redOffset).r;
			grabToChange.g = tex2D(_LukaBackPass, sceneUVs + greenOffset).g;
			grabToChange.b = tex2D(_LukaBackPass, sceneUVs + blueOffset).b;
			grabToChange = lerp(previousGrab, grabToChange, _RGBGlitchTrans);
			if (_ToggleRGB || _ToggleColorSplit) grabToChange = (previousGrab + grabToChange) / 2;


		}

		//Effect: Blocky RGB Glitch
		UNITY_BRANCH
		if (_ToggleBlockyGlitch && _ToggleBlockyRGB) {
			//Props to the original blocky glitch ShaderToy author that I based a lot of my math on/rewrote their effect! <3			//Props to the original blocky glitch ShaderToy author that I based a lot of my math on/rewrote their effect! <3
			//grab to change block rgb
			float4 grabToChangeBlockRGB = tex2D(_LukaBackPass, sceneUVs);

			//calculating displacement
			float displaceIntesnsity = _BlockyGlitchStrength * pow(sin(_Time.y * _BlockyGlitchSpeed), 5.0);

			//displacing UVs
			float displace =
			glitchNoiseGenerator(sceneUVs + float2(sceneUVs.y, 0.0), displaceIntesnsity, _BDepthX, 66.6, _BlockGlitchMap) *
			glitchNoiseGenerator(sceneUVs.yx + float2(0.0, sceneUVs.x), displaceIntesnsity, _BDepthY, 13.7, _BlockGlitchMap);

			//displacing rgb
			float rgbIntesnsity = _BlockyRGBPush * sin(_Time.y * _BlockyRGBSpeed);
			float2 rgbOffset = 0.1 * float2(glitchNoiseGenerator(sceneUVs.xy + float2(sceneUVs.y, 0.0), rgbIntesnsity, 65.0, 341.0, _BlockGlitchMap), 0.0);
			grabToChangeBlockRGB.r = tex2D(_LukaBackPass, sceneUVs - (rgbOffset + float2((_BlockyRGBPush / 300) * (sin(_Time.y * 2 * _BlockyGlitchSpeed)), 0))).r;
			grabToChangeBlockRGB.g = tex2D(_LukaBackPass, sceneUVs).g;
			grabToChangeBlockRGB.b = tex2D(_LukaBackPass, sceneUVs + (rgbOffset + float2((_BlockyRGBPush / 300) * (sin(_Time.y * 2 * _BlockyGlitchSpeed)), 0))).b;


			if (_ToggleRGB || _ToggleRGBGlitch || _ToggleColorSplit) {
				grabToChange = (grabToChange + grabToChangeBlockRGB) / 2;
			}
			else
			{
				grabToChange = grabToChangeBlockRGB;
			}

		}

		//Effect: Color Degrading Glitch
		UNITY_BRANCH
		if (_BGOverlayToggle > 0) {
			//Props to the original blocky glitch ShaderToy author that I based a lot of my math on/rewrote their effect! <3
			//displacing
			float displaceIntesnsity = _BGOverlayIntensity * pow(sin(_Time.y * _BGOverlayIntensity * 2), 5.0);
			float displace =
				glitchNoiseGenerator(sceneUVs + float2(sceneUVs.y, 0.0), displaceIntesnsity, _BDepthX, 66.6, _BGOverlayMap) *
				glitchNoiseGenerator(sceneUVs.yx + float2(0.0, sceneUVs.x), displaceIntesnsity, _BDepthY, 13.7, _BGOverlayMap);

			//overlay color
			float3 randomOverlayColor = (0, 0, 0);
			randomOverlayColor.r = smoothstep((glitchNoiseGenerator(sceneUVs, 1, 40.0, _Time.y * 3, _BGOverlayMap)), 0, 1);
			randomOverlayColor.g = smoothstep((glitchNoiseGenerator(sceneUVs, 2, 30.0, _Time.y * 2, _BGOverlayMap)), 0, 1);
			randomOverlayColor.b = smoothstep((glitchNoiseGenerator(sceneUVs, 3, 20.0, _Time.y * 1, _BGOverlayMap)), 0, 1);

			//applying random maybe idk up to u uwu
			_BGOverlayColor.rgb = lerp(_BGOverlayColor, randomOverlayColor, _BGBrokenRandom);
			float line2 = frac(sceneUVs.y / 3.0);
			float3 overlayColor = float3(_BGOverlayColor.rgb);
			randomizeColor(overlayColor, sceneUVs, 3, float2(0.333, 0.666));
			float rgbIntesnsity = _BGOverlayIntensity * sin(_Time.y * (_BGOverlayIntensity / 2));
			float2 rgbOffset = 0.1 * float2(glitchNoiseGenerator(sceneUVs.xy + float2(sceneUVs.y, 0.0), _BGOverlayIntensity, 65.0, 341.0, _BGOverlayMap), 0.0);
			float maskNoise = glitchNoiseGenerator(sceneUVs, _BGOverlayIntensity, 90.0, _Time.y, _BGOverlayMap) * max(displace, rgbOffset.x);
			maskNoise = 1.0 - maskNoise;
			if (maskNoise == 1.0) overlayColor = float3(1.0, 1.0, 1.0);
			float randomizeMask =
				glitchNoiseGenerator(sceneUVs, _BGBrokenColorIntensity, 11.0, _Time.y, _BGOverlayMap) *
				glitchNoiseGenerator(sceneUVs.yx, _BGBrokenColorIntensity, 90.0, _Time.y, _BGOverlayMap);
			overlayColor *= (1.0 - 5.0 * randomizeMask);
			grabToChange.rgb = lerp(grabToChange.rgb, grabToChange.rgb*overlayColor, _BGOverlayToggle);
		}

		//Effect: Inception
		UNITY_BRANCH
		if (_ToggleInception > 0) {
			float4 previousGrab = grabToChange;
			float3 shaderFAdjustOne = mul(UNITY_MATRIX_V, float4((i.overlayCoordinates.rgb - _WorldSpaceCameraPos), 0)).xyz;
			float2 shaderFAdjustTwo = (shaderFAdjustOne.rgb.rg / shaderFAdjustOne.rgb.b).rg;
			float vrAdjuster = 1;
			#ifdef UNITY_SINGLE_PASS_STEREO
				vrAdjuster = 2;
			#endif
			float2 sfAdFinalColorScreen = float2(
				((_ScreenParams.b / _ScreenParams.a) //params 
					* shaderFAdjustTwo.r) + _InceptionShiftX//x axis 
				, (shaderFAdjustTwo.g) + _InceptionShiftY) //y axis 
				* (_InceptionSize / (_ScreenParams.xy / 3000)) + 0.5;
			sfAdFinalColorScreen *= vrAdjuster;
			float4 overScreen = tex2D(_LukaBackPass, sfAdFinalColorScreen);
			//effects on front only
			UNITY_BRANCH
			if (_InceptionItterations == 1) {
				grabToChange = tex2D(_LukaFrontPass, sceneUVs);
			}
			//effects on screen only
			else if (_InceptionItterations == 2) {
				overScreen = tex2D(_LukaFrontPass, sfAdFinalColorScreen);
			}
			if (sfAdFinalColorScreen.x > 0 && sfAdFinalColorScreen.x < 1 && sfAdFinalColorScreen.y > 0 && sfAdFinalColorScreen.y < 1) {
				UNITY_BRANCH
				if (_ToggleRGB || _ToggleColorSplit || (_ToggleBlockyGlitch && _ToggleBlockyRGB) || _ToggleRGBGlitch) {
					grabToChange = lerp(grabToChange, overScreen, _ToggleInception);
					grabToChange = (grabToChange + previousGrab) / 2;
				}
				else {
					grabToChange = lerp(grabToChange, overScreen, _ToggleInception);
				}
			}
		}
	
		//Effect: Blink (could be optimized?)
		UNITY_BRANCH
		if (_BlinkStrength > 0) {
			_BlinkStrength *= returnOpacity;
			float3 blinkOverlayUVOne = mul(UNITY_MATRIX_V, float4((i.overlayCoordinates.rgb - _WorldSpaceCameraPos), 0)).xyz;
			float2 blinkOverlayUVTwo = (blinkOverlayUVOne.rgb.rg / blinkOverlayUVOne.rgb.b).rg;
			float2 blinkVRuvs = float2(
				((_ScreenParams.b / _ScreenParams.a) //params 
					* blinkOverlayUVTwo.r * _BlinkImageX) //x axis 
				, (blinkOverlayUVTwo.g * _BlinkImageY)) //y axis 
				+ 0.5;

			//creating the blink image for vr
			float4 blinkOverlayVR = tex2D(_BlinkImage, blinkVRuvs);
			if (blinkVRuvs.x > 1 || blinkVRuvs.x < 0 || blinkVRuvs.y > 1 || blinkVRuvs.y < 0) {
				blinkOverlayVR = float4(0, 0, 0, 0);
			}

			_BlinkColor = lerp(_BlinkColor, blinkOverlayVR, _BlinkImagePower);

			//rainbow?
			float hueMod = _Time.y*_BlinkRainbowTime;; //set up time
			hueMod += (sceneUVs.y*_BlinkRainbowY); //vertical multiplier
			hueMod += (sceneUVs.x*_BlinkRainbowX); //horizontal multiplier
			hueMod *= _BlinkRainbowHue;
			float3 hsvColor = smoothHSV2RGB(float3(hueMod, _BlinkRainbowSat, _BlinkRainbowLight));
			_BlinkColor.rgb = lerp(lerp(_BlinkColor.rgb, hsvColor, _BlinkRainbow), _BlinkColor.rgb, _BlinkRainbowMode);
			_BlinkBorder.rgb = lerp(_BlinkBorder.rgb, lerp(_BlinkBorder.rgb, hsvColor, _BlinkRainbow), _BlinkRainbowMode);

			//start blink
			float testY = abs(sceneUVs.y * 2 - 1);
			float testX = abs(sceneUVs.x * 2 - 1);
			_BlinkStrength = 1.0 - _BlinkStrength;
			if (testY >= _BlinkStrength > 0 && _BlinkMode == 1)
			{
				if (testY <= ((_BlinkStrength + 1) - _BlinkBorderSize))
				{
					_BlinkColor = _BlinkBorder;
				}
				if (_ForceBlink) return _BlinkColor; //color
				grabToChange = _BlinkColor;
			}
			else if (testX >= _BlinkStrength > 0 && _BlinkMode == 2)
			{
				if (testX <= ((_BlinkStrength + 1) - _BlinkBorderSize))
				{
					_BlinkColor = _BlinkBorder;
				}
				if (_ForceBlink) return _BlinkColor; //color
				grabToChange = _BlinkColor;
			}
			else if (_BlinkMode == 3) {
				float2 nos_pos = (vo.projPos.xy / vo.projPos.w) - 0.5;
				float2 abs_n_p = float2(abs(nos_pos));
				float sceneTest = sceneUVs.y;
				if (sceneUVs.y < 0.5) sceneTest = 1 - sceneTest;
				_BlinkStrength = 1.0 - _BlinkStrength;
				_BlinkStrength -= 0.5;
				_BlinkStrength *= -1;
				_BlinkBorderSize /= 6;
				_BlinkBorderSize = 1.1 - _BlinkBorderSize;
				_BlinkBorderSize -= 1;
				if (abs_n_p.y > 0.40 + _BlinkStrength)
				{
					if (abs_n_p.y > (0.42 + _BlinkBorderSize + _BlinkStrength) && abs_n_p.y < (0.42 + _BlinkBorderSize))
					{
						grabToChange.rgb =
							_BlinkBorder.rgb *
							step(mod(7.0 * (nos_pos.x*sceneTest), 1.0)*(1.0 - _BlinkColor), 0.8);
					}
					else {
						grabToChange = _BlinkColor;
					}

				}
			}
		}

		//Effect: Reel
		UNITY_BRANCH
		if (_FilmPower > 0 && _ToggleReel) {
			float3 insideColor = float3(0.7, 0.7, 0.7);
			float reelhueMod = _Time.y*0.8; //set up time
			reelhueMod += (cleanSceneUVs.y*_ReelRainbowY); //vertical multiplier
			reelhueMod += (cleanSceneUVs.x*_ReelRainbowX); //horizontal multiplier
			float3 reelhsvColor = smoothHSV2RGB(float3(reelhueMod, 1, 1));
			insideColor.rgb = lerp(insideColor.rgb, reelhsvColor, _ReelRainbow);
			float2 correctPos = (i.normalUVs.xy / i.normalUVs.w) - 0.5 - float2(min(frac(_Time.y) - _ReelJitter, 0), 0);
			float2 absPos = float2(abs(correctPos));
			float4 reelGrab = grabToChange;
			float testDirection = lerp(absPos.x, absPos.y, clamp(_ReelMode, 0, 1));
			if (_ReelMode == 3) {
				testDirection = lerp(testDirection, lerp(absPos.x, absPos.y, 2), 0.2);
				_ReelMode = 1;
			}
			else if (_ReelMode == 4) {
				testDirection = lerp(testDirection, lerp(absPos.x, absPos.y, 2), -0.4);
				_ReelMode = 1;
			}
			float correctDirection = lerp(correctPos.y, correctPos.x, clamp(_ReelMode, 0, 1));
			correctDirection = lerp(correctDirection, correctPos.y, valueRemap(clamp(_ReelMode, 0, 2), 0, 2, -1, 1));
			if (testDirection > 0.40 + _ReelWidth)
			{
				if (testDirection > (0.42 + _ReelBars + _ReelWidth) && testDirection < (0.48 - _ReelBars)) { //first down second up
					reelGrab.rgb =
						insideColor *
						step(mod(_ReelBarAmounts * (correctDirection + frac(_Time.y) * _ReelSpeed), 1.0)*(1.0 - _ReelColor), 0.8 - _ReelBarHeigth); //0.8 bar distance, 10 = bar amount
				}
				else {
					reelGrab = _ReelColor;
				}
			}

			grabToChange = lerp(grabToChange, lerp(grabToChange, reelGrab, _ToggleReel), _FilmPower);
		}

		//Effect: Visualizer (could be optimized?)
		UNITY_BRANCH
		if (_ToggleVisualizer) {

			float2 nos_pos = (i.normalUVs.xy / i.normalUVs.w) - 0.5;
			float2 abs_n_p = float2(abs(nos_pos));


			//visualizer: side bars
			if (_VisMode == 0 && (abs_n_p.x > 0.40 + _VisBaseWidth))
			{

				//rainbow?			
				if (_ToggleHSVRainbowVis) {
					float hueMod = _Time.y*_HSVRainbowTimeVis; //set up time
					hueMod += (cleanSceneUVs.y*_ToggleHSVRainbowYVis); //vertical multiplier
					hueMod += (cleanSceneUVs.x*_ToggleHSVRainbowXVis); //horizontal multiplier
					hueMod *= _HSVRainbowHueVis;
					float3 hsvColor = smoothHSV2RGB(float3(hueMod, _HSVRainbowSatVis, _HSVRainbowLightVis));
					_VisBarColor.rgb *= hsvColor;
				}

				float barLength = _VisBarRight;
				if (cleanSceneUVs.x > 0.5) barLength = _VisBarLeft;
				if (abs_n_p.x > (0.42 + _VisBarWidth + _VisBaseWidth) && abs_n_p.x < (0.48 - _VisBarWidth)) {
					grabToChange.rgb =
						_VisBarColor.rgb *
						step(mod(10.0 * (nos_pos.y - barLength), 0.0), 1.0);
				}
				else {
					grabToChange = _VisBaseColor;
				}




				//visualizer: horizontal bars
			}
			else if (_VisMode == 1) {

				//generating rainbow to be used
				float hueMod = _Time.y*_HSVRainbowTimeVis; //set up time
				hueMod += (cleanSceneUVs.y*_ToggleHSVRainbowYVis); //vertical multiplier
				hueMod += (cleanSceneUVs.x*_ToggleHSVRainbowXVis); //horizontal multiplier
				hueMod *= _HSVRainbowHueVis;
				float3 hsvColor = smoothHSV2RGB(float3(hueMod, _HSVRainbowSatVis, _HSVRainbowLightVis));

				float2 nos_pos = (vo.projPos.xy / vo.projPos.w) - 0.5;
				float2 cleanUVs = (vo.projPos.xy / vo.projPos.w);
				float2 abs_n_p = float2((nos_pos))*-1;
				if (abs_n_p.y > _VisClassicBase) {
					grabToChange = float4(0, 0, 0, 1);
				}
				else if (abs_n_p.y > _VisClassicBase - 0.015) {
					grabToChange.rgb = lerp(_VisStopperColor.rgb, hsvColor, _ToggleHSVRainbowVis);
				}

				// create pixel coordinates
				float2 fragCoord = cleanUVs.xy * _ScreenParams.xy;
				float2 uv = fragCoord / _ScreenParams.xy;

				// distort
				float bass = -0.02;

				// quantize coordinates
				float bands = _VisCircleSize;
				float segs = _VisCircleSize;
				float2 p = (floor(uv.x*bands) / bands, floor(uv.y*segs) / segs);

				float adjustMod = _VisCircleSize / _VisClassicMaxSize;
				float powerMod = 0;
				if (uv.x > 0.90) {
					powerMod = (_VisBarLeft + 1.1) / adjustMod;
				}
				else if (uv.x > 0.80) {
					powerMod = (_VisBarRight + 1.1) / adjustMod;
				}
				else if (uv.x > 0.70) {
					powerMod = (_VisBarThree + 1.1) / adjustMod;
				}
				else if (uv.x > 0.60) {
					powerMod = (_VisBarFour + 1.1) / adjustMod;
				}
				else if (uv.x > 0.50) {
					powerMod = (_VisBarFive + 1.1) / adjustMod;
				}
				else if (uv.x > 0.40) {
					powerMod = (_VisBarSix + 1.1) / adjustMod;
				}
				else if (uv.x > 0.30) {
					powerMod = (_VisBarSeven + 1.1) / adjustMod;
				}
				else if (uv.x > 0.20) {
					powerMod = (_VisBarEight + 1.1) / adjustMod;
				}
				else if (uv.x > 0.10) {
					powerMod = (_VisBarNine + 1.1) / adjustMod;
				}
				else {
					powerMod = (_VisBarTen + 1.1) / adjustMod;
				}


				float fft = bass + powerMod;


				float3 shapeColor = lerp(_VisBarColor.rgb, _VisBaseColor.rgb, sqrt(uv.y) + (powerMod*_VisClassicBase) / 2); //0.4, 0.0, 1.0, 1.0, 0.0, 0.4
				shapeColor = lerp(shapeColor, hsvColor, _VisBarRainbow);


				float mask = (p.y < fft) ? 1.0 : 0.0;

				// led shape
				float2 shapeDist = frac((uv - p)*float2(bands, segs)) - 0.5;
				float circleShape = 1.0 - smoothstep(0.85 - (0.85*0.01), 0.85 + (0.85*0.01), dot(shapeDist, shapeDist)*4.0);
				float squareShape = smoothstep(0.5, 0.3, abs(shapeDist.x)) * smoothstep(0.5, 0.3, abs(shapeDist.y));
				float desiredShape = lerp(circleShape, squareShape, _VisClassicShape);
				float3 coloredShape = desiredShape * shapeColor;
				if ((coloredShape.r + coloredShape.g + coloredShape.b) < 0.01) coloredShape = grabToChange.rgb;
				coloredShape = lerp(grabToChange.rgb, coloredShape, mask);
				//optional additional mask?



				grabToChange = float4(coloredShape, 1.0);

			}


		}

		//Effect: Screen Image Overlays
		UNITY_BRANCH
		if (_ToggleOverlay) {

			//creating a vr friendly uv
			float3 shaderFAdjustOne = mul(UNITY_MATRIX_V, float4((i.overlayCoordinates.rgb - _WorldSpaceCameraPos), 0)).xyz;
			float2 shaderFAdjustTwo = (shaderFAdjustOne.rgb.rg / shaderFAdjustOne.rgb.b).rg;
			float2 sfAdFinalColorOverlay = float2(
			((_ScreenParams.b / _ScreenParams.a) //params 
			* shaderFAdjustTwo.r * _OverlayXAdjust) + _OverlayYShift //x axis 
			, (shaderFAdjustTwo.g * _OverlayYAdjust) + _OverlayXShift) //y axis 
			* _OverlayTiling + 0.5;

			UNITY_BRANCH
			if (_OvScOneT) {
				float2 uvScroll = float2(_Time.y * _OvScOne, _Time.y * _OvScOneY);
				sfAdFinalColorOverlay = float2(frac(sfAdFinalColorOverlay.x + uvScroll.x), frac(sfAdFinalColorOverlay.y + uvScroll.y));
			}

			//different image for VR 
			UNITY_BRANCH
			if (_UseSepOverlay) {
				#if UNITY_SINGLE_PASS_STEREO
					_OverlayTexture = _VROverlayTexture;
				#endif
			}

			float4 overlayFixedUV = tex2D(_OverlayTexture, sfAdFinalColorOverlay);

			if (sfAdFinalColorOverlay.x > 1 || sfAdFinalColorOverlay.x < 0 || sfAdFinalColorOverlay.y > 1 || sfAdFinalColorOverlay.y < 0) {
				overlayFixedUV = float4(0, 0, 0, 0);
			}


			//transistion
			UNITY_BRANCH
			if (_OverlayTrans) {
				overlayFixedUV = lerp(
				grabToChange,
				overlayFixedUV,
				step(_OverlayTransY, sceneUVs.y));

				overlayFixedUV = lerp(
				grabToChange,
				overlayFixedUV,
				step(_OverlayTransX, sceneUVs.x));
			}

			//transparent or not
			float transparentFactor = lerp(2, overlayFixedUV.a * 2, _ToggleTransparentImage);

			//applying overlay transparency and blending
			float3 cleanGrab = grabToChange.rgb;
			grabToChange = max(grabToChange, overlayFixedUV);
			//grabToChange = grabToChange + (overlayFixedUV);			
			overlayFixedUV = (grabToChange + overlayFixedUV) / 2;
			float3 overlayApplied = lerp(grabToChange.rgb, overlayFixedUV.rgb, transparentFactor);
			grabToChange.rgb = lerp(cleanGrab.rgb, overlayApplied.rgb, _OverlayTransparency);




			//second overlay
			//start second overlay
			if (_ToggleOverlayTwo) {
			
				float2 sfAdFinalColorOverlayTwo = float2(
				((_ScreenParams.b / _ScreenParams.a) //params 
				* shaderFAdjustTwo.r * _OverlayXAdjustTwo) + _OverlayYShiftTwo //x axis 
				, (shaderFAdjustTwo.g * _OverlayYAdjustTwo) + _OverlayXShiftTwo) //y axis 
				* _OverlayTilingTwo + 0.5;

				UNITY_BRANCH
				if (_OvScTwoT) {
					float2 uvScrollTwo = float2(_Time.y * _OvScTwo, _Time.y * _OvScTwoY);
					sfAdFinalColorOverlayTwo = float2(frac(sfAdFinalColorOverlayTwo.x + uvScrollTwo.x), frac(sfAdFinalColorOverlayTwo.y + uvScrollTwo.y));
				}

				float4 overlayFixedUVTwo = tex2D(_OverlayTextureTwo, sfAdFinalColorOverlayTwo);

				if (sfAdFinalColorOverlayTwo.x > 1 || sfAdFinalColorOverlayTwo.x < 0 || sfAdFinalColorOverlayTwo.y > 1 || sfAdFinalColorOverlayTwo.y < 0) {
					overlayFixedUVTwo = float4(0, 0, 0, 0);
				}

				//transistion
				if (_OverlayTransTwo) {
					overlayFixedUVTwo = lerp(
					grabToChange,
					overlayFixedUVTwo,
					step(_OverlayTransYTwo, sceneUVs.y));

					overlayFixedUVTwo = lerp(
					grabToChange,
					overlayFixedUVTwo,
					step(_OverlayTransXTwo, sceneUVs.x));
				}


				//transparent or not
				float transparentFactor = lerp(2, overlayFixedUVTwo.a * 2, _ToggleTransparentImageTwo);

				//applying overlay transparency and blending
				float3 cleanGrab = grabToChange.rgb;
				grabToChange = max(grabToChange, overlayFixedUVTwo);
				//grabToChange = grabToChange + (overlayFixedUVTwo);
				overlayFixedUVTwo = (grabToChange + overlayFixedUVTwo) / 2; //was originally not overlayFixedUVTwo 
				float3 overlayApplied = lerp(grabToChange.rgb, overlayFixedUVTwo.rgb, transparentFactor);
				grabToChange.rgb = lerp(cleanGrab.rgb, overlayApplied.rgb, _OverlayTransparencyTwo);


			}
			//end second overlay 



			//start third overlay 
			if (_ToggleOverlayThree) {			

				float2 sfAdFinalColorOverlayThree = float2(
				((_ScreenParams.b / _ScreenParams.a) //params 
				* shaderFAdjustTwo.r * _OverlayXAdjustThree) + _OverlayYShiftThree //x axis 
				, (shaderFAdjustTwo.g * _OverlayYAdjustThree) + _OverlayXShiftThree) //y axis 
				* _OverlayTilingThree + 0.5;

				UNITY_BRANCH
				if (_OvScThreeT) {
					float2 uvScrollThree = float2(_Time.y * _OvScThree, _Time.y * _OvScThreeY);
					sfAdFinalColorOverlayThree = float2(frac(sfAdFinalColorOverlayThree.x + uvScrollThree.x), frac(sfAdFinalColorOverlayThree.y + uvScrollThree.y));
				}

				float4 overlayFixedUVThree = tex2D(_OverlayTextureThree, sfAdFinalColorOverlayThree);

				if (sfAdFinalColorOverlayThree.x > 1 || sfAdFinalColorOverlayThree.x < 0 || sfAdFinalColorOverlayThree.y > 1 || sfAdFinalColorOverlayThree.y < 0) {
					overlayFixedUVThree = float4(0, 0, 0, 0);
				}

				//transistion
				if (_OverlayTransThree) {
					overlayFixedUVThree = lerp(
					grabToChange,
					overlayFixedUVThree,
					step(_OverlayTransYThree, sceneUVs.y));

					overlayFixedUV = lerp(
					grabToChange,
					overlayFixedUVThree,
					step(_OverlayTransXThree, sceneUVs.x));
				}

				//transparent or not
				float transparentFactor = lerp(2, transparentFactor = overlayFixedUVThree.a * 2, _ToggleTransparentImageThree);

				//applying overlay transparency and blending
				float3 cleanGrab = grabToChange.rgb;
				grabToChange = max(grabToChange, overlayFixedUVThree);
				//grabToChange = grabToChange + (overlayFixedUVThree);
				overlayFixedUVThree = (grabToChange + overlayFixedUVThree) / 2; //was originally not overlayFixedUVThree
				float3 overlayApplied = lerp(grabToChange.rgb, overlayFixedUVThree.rgb, transparentFactor);
				grabToChange.rgb = lerp(cleanGrab.rgb, overlayApplied.rgb, _OverlayTransparencyThree);

			}



		}

		//Effect: Screen GIF Overlay
		UNITY_BRANCH
		if (_ToggleGifOverlay) {

			//creating a vr friendly uv
			float3 shaderFAdjustOne = mul(UNITY_MATRIX_V, float4((i.overlayCoordinates.rgb - _WorldSpaceCameraPos), 0)).xyz;
			float2 shaderFAdjustTwo = (shaderFAdjustOne.rgb.rg / shaderFAdjustOne.rgb.b).rg;
			float2 sfAdFinalColorGif = float2(
			((_ScreenParams.b / _ScreenParams.a) //params 
			* shaderFAdjustTwo.r * _GifXAdjust) + _GifYShift //x axis 
			, (shaderFAdjustTwo.g * _GifYAdjust) + _GifXShift) //y axis 
			* _GifTiling + 0.5;

			//rotating the uv for the gif
			float4 _storeTime = _Time; //for future testing maybe idk lol
			float2 divToDiv = float2(_OSSRows, _OSSColumns);
			float _oneUVMath = round(((_OSSRows*_OSSColumns)*frac((_OSSSpeed*_storeTime.g))));
			float2 _twoUVMath = (((sfAdFinalColorGif / divToDiv) + float2(_OSSRows, _OSSColumns)) + float2((fmod(_oneUVMath, _OSSRows) / _OSSRows), (1.0 - (floor((_oneUVMath / _OSSRows)) / _OSSColumns))));

			//applying the texture to the scenes uv and displaying it
			float4 _gifScreenUV = tex2D(_OverlaySpritesheet, TRANSFORM_TEX(_twoUVMath, _OverlaySpritesheet));

			if (sfAdFinalColorGif.x > 1 || sfAdFinalColorGif.x < 0 || sfAdFinalColorGif.y > 1 || sfAdFinalColorGif.y < 0) {
				_gifScreenUV = float4(0, 0, 0, 0);
			}

			//applying overlay transparency 
			float transparentFactor = lerp(2, _gifScreenUV.a * 2, _ToggleACTUALTransparentGif);

			//applying overlay transparency and blending
			float3 cleanGrab = grabToChange.rgb;
			grabToChange = max(grabToChange, _gifScreenUV);
			//grabToChange = grabToChange + (_gifScreenUV);
			_gifScreenUV = (grabToChange + _gifScreenUV) / 2;
			float3 overlayApplied = lerp(grabToChange.rgb, _gifScreenUV.rgb, transparentFactor);
			grabToChange.rgb = lerp(cleanGrab.rgb, overlayApplied.rgb, _GifTransparency);


		}

		//Effect: Depth of Field (could be optimized?)
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
				grabToChange = lerp(grabToChange, bgcolor, saturate(ds / _DepthValue));

			}

		}

		//Effect: Transistion (needs rewrote because i thought i was optimizing but found a better way and idk its a mess.. :c)
		UNITY_BRANCH
		if (_ToggleTransistion) {
			//applying transistion
			float4 cleanScene = tex2D(_LukaFrontPass, sceneUVs);

			//horizontal transistion
			grabToChange =
				lerp(
					//normal
					grabToChange,
					//interpolated transistion
					lerp(
						cleanScene,
						grabToChange,
						step(_TransX, sceneUVs.x)),
					//toggle
					_ToggleTransistion);

			//vertical transistion
			grabToChange =
				lerp(
					//normal
					grabToChange,
					//interpolated transistion
					lerp(
						cleanScene,
						grabToChange,
						step(_TransY, sceneUVs.y)),
					//toggle
					_ToggleTransistion);

			//diagonal one transistion
			grabToChange =
				lerp(
					//normal
					grabToChange,
					//interpolated transistion
					lerp(
						cleanScene,
						grabToChange,
						step(_TransDR - sceneUVs.y, sceneUVs.x)),
					//two step toggle
					_ToggleDiagTrans * _ToggleTransistion);

			//diagonal two transistion
			grabToChange =
				lerp(
					//normal
					grabToChange,
					//interpolated transistion
					lerp(
						cleanScene,
						grabToChange,
						step(sceneUVs.x + _TransDL, sceneUVs.y)),
					//two step toggle
					_ToggleDiagTrans * _ToggleTransistion);
		}

		//Returning
		return lerp(cleanGrabToChange, grabToChange, returnOpacity);
	}
}

