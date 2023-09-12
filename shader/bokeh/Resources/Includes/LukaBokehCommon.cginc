// copyright notice will go here.

#ifndef LUKA_BOKEH_COMMON
#define LUKA_BOKEH_COMMON

// CULLING FUNCTIONS
bool isMirror() {
	return unity_CameraProjection[2][0] != 0.f || unity_CameraProjection[2][1] != 0.f;
}

float3 getCamera() {
	#if UNITY_SINGLE_PASS_STEREO
		return (unity_StereoWorldSpaceCameraPos[0] + unity_StereoWorldSpaceCameraPos[1]) * 0.5;
	#else // UNITY_SINGLE_PASS_STEREO
		return _WorldSpaceCameraPos;
	#endif // UNITY_SINGLE_PASS_STEREO
}

float getDistance() {
	return float(distance(getCamera(), mul(unity_ObjectToWorld, float4(0, 0, 0, 1))));
}

bool isVR() {
	// checks if shader is being rendered in vr
	#if UNITY_SINGLE_PASS_STEREO
		return true;
	#else
		return false;
	#endif
}

bool isVRHandCamera() {
	// checks if shader is being rendered in a hand camera 
	// attribution: ScruffyRules#0879
	return !isVR() && abs(UNITY_MATRIX_V[0].y) > 0.0000005;
}

bool isVRHandCameraPreview() {
	// check if shader is being rendered in camera preview
	// attribution: ScruffyRules#0879
	return isVRHandCamera() && _ScreenParams.y == 720;
}

bool isVRHandCameraPicture() {
	// check if shader is being rendered in a camera picture
	// attribution: ScruffyRules#0879
	return isVRHandCamera() && _ScreenParams.y == 1080;
}

bool isPanorama() {
	return unity_CameraProjection[1][1] == 1 && _ScreenParams.x == 1075 && _ScreenParams.y == 1025;
}

// DEPTH FUNCTIONS
float4 getFrustumCorrection()
{
	// attribution: lukis101
	float x1 = -UNITY_MATRIX_P._31 / (UNITY_MATRIX_P._11 * UNITY_MATRIX_P._34);
	float x2 = -UNITY_MATRIX_P._32 / (UNITY_MATRIX_P._22 * UNITY_MATRIX_P._34);
	return float4(x1, x2, 0, UNITY_MATRIX_P._33 / UNITY_MATRIX_P._34 + x1 * UNITY_MATRIX_P._13 + x2 * UNITY_MATRIX_P._23);
}

float ManualLinear01Depth(float z)
{
	return 1.0 / (_ZBufferParams.z * z + _ZBufferParams.w);
}

float GetLinearZFromZDepthWorksWithMirrors(float zDepthFromMap, float2 screenUV)
{
	// attribution: shadertrixx method
	#if defined(UNITY_REVERSED_Z)
		zDepthFromMap = 1 - zDepthFromMap;
		if (zDepthFromMap >= 1.0) return _ProjectionParams.z;
	#endif // UNITY_REVERSED_Z
	float4 clipPos = float4(screenUV.xy, zDepthFromMap, 1.0);
	clipPos.xyz = 2.0f * clipPos.xyz - 1.0f;
	float4 camPos = mul(unity_CameraInvProjection, clipPos);
	return -camPos.z / camPos.w;
}

float getVRCLinearDepth(float4 inputVertexPosition,
float3 inputScreenPosition, float4 inputWorldDirection,
float3 inputWorldPosition, sampler2D inputCameraDepth)
{
	// attribution: shadertrix method, lukis method, my own frankeinstein
	float3 fullVectorFromEyeToGeometry = inputWorldPosition - _WorldSpaceCameraPos;
	// fix perspective stuffs
	float perspectiveDivide = 1.0f / inputVertexPosition.w;
	float2 screenPos = inputScreenPosition.xy * perspectiveDivide;
	// get working depth (works in unity and vrchat mirrors!)
	float perspectiveFactor = length(fullVectorFromEyeToGeometry * perspectiveDivide);
	float eyeDepthWorld = GetLinearZFromZDepthWorksWithMirrors(SAMPLE_DEPTH_TEXTURE(inputCameraDepth, screenPos), screenPos);
	eyeDepthWorld *= perspectiveFactor;
	// correct by size of vertex
	float3 vertexSize = inputWorldDirection.xyz * perspectiveDivide;
	float vertexSizeWorld = length(vertexSize);
	float correctedDepth = eyeDepthWorld / vertexSizeWorld;
	return correctedDepth;
}

float getVRCLinearDepth01(float4 inputVertexPosition,
float3 inputScreenPosition, float4 inputWorldDirection,
float3 inputWorldPosition, sampler2D inputCameraDepth)
{
	// attribution: shadertrix method, lukis method, my own frankeinstein
	float3 fullVectorFromEyeToGeometry = inputWorldPosition - _WorldSpaceCameraPos;
	// fix perspective stuffs
	float perspectiveDivide = 1.0f / inputVertexPosition.w;
	float2 screenPos = inputScreenPosition.xy * perspectiveDivide;
	// get working depth (works in unity and vrchat mirrors!)
	float perspectiveFactor = length(fullVectorFromEyeToGeometry * perspectiveDivide);
	float eyeDepthWorld = GetLinearZFromZDepthWorksWithMirrors(tex2D(inputCameraDepth, screenPos), screenPos);
	eyeDepthWorld *= perspectiveFactor;
	eyeDepthWorld = ManualLinear01Depth(eyeDepthWorld);
	// correct by size of vertex
	float3 vertexSize = inputWorldDirection.xyz * perspectiveDivide;
	float vertexSizeWorld = length(vertexSize);
	float correctedDepth = eyeDepthWorld / vertexSizeWorld;
	return correctedDepth;
}

float2 makeCenter(float2 inputUVs, 
	float inputX, float inputY) {
	float2 thisCenter;
	#if UNITY_SINGLE_PASS_STEREO
		if (inputUVs.x < 0.5) {
			thisCenter = float2(inputX / 2, inputY);
		}
	else {
		thisCenter = float2(inputX + (inputX / 2), inputY);
	}
	#else
		thisCenter = float2(inputX, inputY);
	#endif
	return thisCenter; 
}

float approxPow(float a,
	float b) {
	return a / ((1. - b) * a + b);
}

// NOISE FUNCTIONS
float unity_noise_random_value(float2 uv) {
    return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453);
}

float noise_range(float2 uv, float min_range, float max_range) {
	return lerp(min_range, max_range, unity_noise_random_value(uv));
}

float2 hash22(float2 p) {
	float3 p3 = frac(float3(p.xyx) * float3(0.1031, 0.1030, 0.0973));
    p3 += dot(p3, p3.yzx + 33.33);
    return frac((p3.xx + p3.yz) * p3.zy);
}

float hash_range(float2 uv, float min_range, float max_range) {
	return lerp(min_range, max_range, hash22(uv).x);
}

// OTHER FUNCTIONS
float get_luma(float3 color) {
	return dot(color, float3(0.2126, 0.7152, 0.0722));
}

float3 srgb_to_linear(float3 c) {
	 return c * c; 
}

float3 linear_to_srgb(float3 c) { 
	return sqrt(c); 
}

float3 rgb_to_hsv(float3 In)
{
	// attribution: unity technologies
    float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    float4 P = lerp(float4(In.bg, K.wz), float4(In.gb, K.xy), step(In.b, In.g));
    float4 Q = lerp(float4(P.xyw, In.r), float4(In.r, P.yzx), step(P.x, In.r));
    float D = Q.x - min(Q.w, Q.y);
    float  E = 1e-10;
    return float3(abs(Q.z + (Q.w - Q.y)/(6.0 * D + E)), D / (Q.x + E), Q.x);
}

float3 hsv_to_rgb(float3 In)
{
	// attribution: unity technologies
	float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
	float3 P = abs(frac(In.xxx + K.xyz) * 6.0 - K.www);
	return In.z * lerp(K.xxx, saturate(P - K.xxx), In.y);
}

float remap_value(float value, float old_min, float old_max, float new_min, float new_max) {
	return new_min + (value - old_min) * (new_max - new_min) / (old_max - old_min);
}

float3 aces_approximation(float3 inputColors) {
	float acesMap[5];
	acesMap[0] = 2.51;
	acesMap[1] = 0.03;
	acesMap[2] = 2.43;
	acesMap[3] = 0.59;
	acesMap[4] = 0.14;
    return saturate((inputColors * (acesMap[0] * inputColors + acesMap[1])) / (inputColors * (acesMap[2] * inputColors + acesMap[3])+ acesMap[4]));
}

float2 make_spritesheet(float inputColumns,
	float inputRows, float inputTotal,
	float inputSpeed, int inputCurrent,
	float2 inputUVs) {
	inputCurrent += frac(inputSpeed * _Time.y) * inputTotal;
	inputCurrent = clamp(inputCurrent, 0, inputTotal);
	inputCurrent = fmod(inputCurrent, inputColumns * inputRows);
	float2 inputCurrentCount = float2(1.0, 1.0) / float2(inputColumns, inputRows);
	float inputCurrentY = abs(inputRows - (floor(inputCurrent * inputCurrentCount.x) + 1));
	float inputCurrentX = abs(0 * inputColumns - ((inputCurrent - inputColumns * floor(inputCurrent * inputCurrentCount.x))));
	return float2((inputUVs + float2(inputCurrentX, inputCurrentY)) * inputCurrentCount);
}

float2 rotate_radians(float2 inputUv, float2 inputCenter, float inputRotation)
{
    inputUv -= inputCenter;
    float s = sin(inputRotation);
    float c = cos(inputRotation);
    float2x2 rMatrix = float2x2(c, -s, s, c);
    rMatrix *= 0.5;
    rMatrix += 0.5;
    rMatrix = rMatrix * 2 - 1;
    inputUv.xy = mul(inputUv.xy, rMatrix);
    inputUv += inputCenter;
    return inputUv;
}

float2 zoom_uvs(float2 inputUvs, float2 inputCenter, float inputZoom) {
	inputUvs -= inputCenter;
	inputUvs *= inputZoom;
	inputUvs += inputCenter;
	return inputUvs;
}

bool is_out(float2 uvs) {
	return any(abs(uvs - 0.5) >= 0.5);
}

// VERTEX PROPERTIES
float _CullDistance, _SmoothCull, _SmoothCullEnd;
float _VRChatPreview;

// VERTEX PROGRAM
v2f physics(appdata_base v) {
	v2f o;
	o.pos = UnityObjectToClipPos(v.vertex);
	o.grabPos = ComputeGrabScreenPos(o.pos);
	o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
	o.worldDir.xyz = mul(unity_ObjectToWorld, v.vertex).xyz - _WorldSpaceCameraPos;
	o.worldDir.w = dot(v.vertex, getFrustumCorrection());
	o.render = !isMirror();
	[branch] if (_CullDistance != 0) {
		o.render = o.render && getDistance() < _CullDistance;
	}
	#if defined(_BOKEH_VRCHAT)
		o.render = o.render && (isVRHandCamera() || isVRHandCameraPicture() || isPanorama());
		[branch] if (_VRChatPreview == 1.0) {
			o.render = o.render || isVRHandCameraPreview();
		}
	#endif // _BOKEH_VRCHAT
	return o;
}

#endif // LUKA_BOKEH_COMMON