//|===============================================|
//|				  license   					  |
//|===============================================|
//shader author: luka (lukasong on github, luka#8375 on discord, luka! in vrchat)
//license: this shader is to not be redistrubted or resold in any format and is limited to the buyer exclusively
//version 11.0 (July 30,  2019)



//|===============================================|
//|				  functions   					  |
//|===============================================|
float3 rgb2hsv(float3 c) {
	float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
	float4 p = lerp(float4(c.bg, K.wz), float4(c.gb, K.xy), step(c.b, c.g));
	float4 q = lerp(float4(p.xyw, c.r), float4(c.r, p.yzx), step(p.x, c.r));

	float d = q.x - min(q.w, q.y);
	float e = 1.0e-10;
	return float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
}

float3 hsv2rgb(float3 c) {
	float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
	float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
	return c.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

float3 smoothHSV2RGB(float3 c)
{
	//generic hsv to rgb except smoothed with cubic smoothing
	//original source: https://github.com/yuichiroharai/glsl-y-hsv (theres another source in this one I believe)
	float3 rgb = clamp(abs(fmod(c.x*6.0 + float3(0.0, 4.0, 2.0), 6.0) - 3.0) - 1.0, 0.0, 1.0);
	rgb = rgb * rgb*(3.0 - 2.0*rgb); // cubic smoothing	
	return c.z * lerp(float3(1.0, 1.0, 1.0), rgb, c.y);
}
