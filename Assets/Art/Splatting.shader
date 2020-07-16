// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Michal/TextureSplat" {

	Properties {
		//_Tint ("Tint", Color) = (1, 1, 1, 1)
		_Splat("Splat Map", 2D) = "white" {}
		[NoScaleOffset] _MainTex ("Main", 2D) = "white" {}
		[NoScaleOffset] _DetailTex ("Subtexture", 2D) = "white" {}
				
		_RotationSpeed ("Rotation Speed", Float) = 15

	}

	SubShader {

		Pass {
			Tags {"LightMode" = "ForwardBase"}
			CGPROGRAM

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram
			#pragma target 3.0
			#include "UnityCG.cginc"
			

			#pragma multi_compile_fwdbase
			#include "AutoLight.cginc"

			//float4 _Tint;
			sampler2D _MainTex, _DetailTex, _Splat;
			float4 _MainTex_ST, _DetailTex_ST, _Splat_ST;

			struct VertexData {
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct Interpolators {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
				float2 uvDetail : TEXCOORD1;
				float2 uvSplat : TEXCOORD2;
			};

			float _RotationSpeed;
			#define ANGLE (_Time.z * _RotationSpeed)

			Interpolators MyVertexProgram (VertexData v) {
				Interpolators i;
				i.position = UnityObjectToClipPos(v.position);
				i.uv = TRANSFORM_TEX(v.uv, _MainTex);
				i.uvDetail = TRANSFORM_TEX(v.uv, _DetailTex);
				i.uvSplat = TRANSFORM_TEX(v.uv,_Splat);
				return i;
			}

			float4 MyFragmentProgram (Interpolators i) : SV_TARGET {

				float4 splat = tex2D(_Splat, i.uvSplat);
				
				fixed2 center = fixed2(0.5, 0.5);
				float s = sin ( _RotationSpeed * _Time );
                float c = cos ( _RotationSpeed * _Time );
                float2x2 rotate = float2x2( c, -s, s, c);

				fixed2 uv_OverTex = mul(rotate, i.uvDetail - center) + center;

				float4 color = tex2D(_MainTex, i.uv) * splat.r + tex2D(_DetailTex, uv_OverTex) * (1 - splat.r);
				//color *= tex2D(_DetailTex, uv_OverTex) * 2;
				
				return color;
			}

			ENDCG
		}
	}
	Fallback "VertexLit"
}