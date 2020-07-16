Shader "Michal/SurfaceBlendTest" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Splat("Splat Map", 2D) = "white" {}
		[NoScaleOffset] _MainTex ("Main", 2D) = "white" {}
		[NoScaleOffset] _DetailTex ("Subtexture", 2D) = "white" {}
		_NormalMap ("Normal Map", 2D) = "bump" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		_RotationSpeed ("Rotation Speed", Float) = 15
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows
		

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex, _DetailTex, _Splat;
		sampler2D _NormalMap;

		struct Input {
			float2 uv_MainTex;
			float2 uv_DetailTex;
			float2 uv_Splat;
			float2 uv_NormalMap;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		float _RotationSpeed;
		#define ANGLE (_Time.z * _RotationSpeed)

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float4 splat = tex2D(_Splat, IN.uv_Splat);
			fixed2 center = fixed2(0.5, 0.5);
			float sinus = sin ( _RotationSpeed * _Time );
            float cosinus = cos ( _RotationSpeed * _Time );
            float2x2 rotate = float2x2( cosinus, -sinus, sinus, cosinus);
			
			fixed2 uv_OverTex = mul(rotate, IN.uv_DetailTex - center) + center;

			float4 color = tex2D(_MainTex, IN.uv_MainTex) * splat.r + tex2D(_DetailTex, uv_OverTex) * (1 - splat.r);

			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = color.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
