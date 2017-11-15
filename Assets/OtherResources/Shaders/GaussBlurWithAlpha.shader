Shader "Custom/GaussBlurWithAlpha"
{
	Properties
	{
		_ColorWithAlpha("ColorWithAlpha", Color) = (0.9, 0.1, 0.1, 0.5)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		samplerPerlinPerm2D("samplerPerlinPerm2D", 2D) = "white" {}
		samplerPerlinGrad2D("samplerPerlinGrad2D", 2D) = "white" {}
		_TextureSize("_TextureSize",Float) = 256
		_BlurRadius("_BlurRadius",Range(1,10)) = 1
		_Center("_Center", Vector) = (0, 0, 0, 0)
		_Rad("_Rad", Range(1, 10000)) = 15
		_NoiseRad("_NoiseRad", Range(1, 1000)) = 10
		_Hardness("_Hardness", Range(1, 10)) = 1
		_Seed("_Seed", Range(1, 256)) = 1
		_TotalTime("_TotalTime", Range(0.1, 10)) = 2
	}

	SubShader
	{
		Tags{ "Queue" = "Transparent" }

		Pass
		{
			ZWrite Off

			//Blend  SrcAlpha SrcAlpha
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex vert 
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform float4 _ColorWithAlpha;
			sampler2D _MainTex;
			sampler2D _BgTex;
			int _BlurRadius;
			float _TextureSize;
			float2 _Center;
			float _Rad;
			uniform float rad;
			float _NoiseRad;
			float _Hardness;
			float _Seed;

			uniform int _StartSpread;
			float _TotalTime;
			uniform float _StartTime;

			sampler2D samplerPerlinPerm2D;
			sampler2D samplerPerlinGrad2D;

			struct v2f {
				float2 uv : TEXCOORD0;
				half2 taps[4] : TEXCOORD1;
			};


            v2f vert (
                float4 vertex : POSITION, // vertex position input
                float2 uv : TEXCOORD0, // texture coordinate input
                out float4 outpos : SV_POSITION // clip space position output
                )
            {
                v2f o;
				UNITY_INITIALIZE_OUTPUT(v2f, o);
                o.uv = uv;
                outpos = UnityObjectToClipPos(vertex);
                return o;
            }

			float perlinNoise(float2 p, float seed)
			{
				// Calculate 2D integer coordinates i and fraction p.
				float2 i = floor(p);
				float2 f = p - i;

				// Get weights from the coordinate fraction
				float2 w = f * f * f * (f * (f * 6 - 15) + 10);
				float4 w4 = float4(1, w.x, w.y, w.x * w.y);

				// Get the four randomly permutated indices from the noise lattice nearest to
				// p and offset these numbers with the seed number.
				float4 perm = tex2D(samplerPerlinPerm2D, i / 256) + seed;

				// Permutate the four offseted indices again and get the 2D gradient for each
				// of the four permutated coordinates-seed pairs.
				float4 g1 = tex2D(samplerPerlinGrad2D, perm.xy) * 2 - 1;
				float4 g2 = tex2D(samplerPerlinGrad2D, perm.zw) * 2 - 1;

				// Evaluate the four lattice gradients at p
				float a = dot(g1.xy, f);
				float b = dot(g2.xy, f + float2(-1, 0));
				float c = dot(g1.zw, f + float2(0, -1));
				float d = dot(g2.zw, f + float2(-1, -1));

				// Bi-linearly blend between the gradients, using w4 as blend factors.
				float4 grads = float4(a, b - a, c - a, a - b - c + d);
				float n = dot(grads, w4);

				// Return the noise value, roughly normalized in the range [-1, 1]
				return n * 1.5;
			}

			float GetGaussianDistribution(float x, float y, float rho) {
				//float g = 1.0f / sqrt(2.0f * 3.141592654f * rho * rho);
				//float g = 1.0f / (2.0f * 3.141592654f * rho * rho);
				float g = 1;
				return g * exp(-(x * x + y * y) / (2 * rho * rho));
			}

			fixed4 GetSzyBlurColor(float2 uv, float4 pos)
			{
				//rad = _Rad;
				if (_StartSpread == 1) {
					rad = _Rad;
					if (_Time.y - _StartTime < _TotalTime) {
						rad = lerp(0.01, _Rad, saturate((_Time.y - _StartTime) / _TotalTime));
					}
					else {
						_StartSpread = 0;
					}
				}

				//rad = lerp(0.1, _Rad, fmod(_Time.y, _TotalTime) / _TotalTime); // 循环播放
#if SHADER_API_D3D11
				_Center.y = _ScreenParams.y - _Center.y;
#endif
				float4 mainColor = float4(0, 0, 0, 0);
				float distSqr = (pos.x - _Center.x) * (pos.x - _Center.x) + (pos.y - _Center.y) * (pos.y - _Center.y);
				float space = 1.0 / _TextureSize;
				float rho = (float)rad * space / 3.0;
				float4 c = mainColor;
				float t = saturate(GetGaussianDistribution((pos.x - _Center.x) * space, (pos.y - _Center.y) * space, rho) * _Hardness);
				if (distSqr > _NoiseRad * _NoiseRad && distSqr < rad * rad)
				{
					//t += perlinNoise(pos.xy, _Seed);
				}
				//float dist = distance(pos, _Center);
				//c.a = lerp(1, 0, 1 - dist / rad); // 线性羽化，备用
				c.a = lerp(1.5, 0, t);
				return c;
			}

			fixed4 frag (v2f i, UNITY_VPOS_TYPE screenPos : VPOS) : SV_Target
			{
				return GetSzyBlurColor(i.uv, float4(screenPos.xy, 0, 0));
			}
			ENDCG
		}
	}
}
