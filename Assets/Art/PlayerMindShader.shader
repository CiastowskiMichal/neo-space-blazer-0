// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Michal/PlayerMindShader"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_RotationSpeed ("Rotation Speed", Float) = 15
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};
			fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			float _RotationSpeed;
			#define ANGLE (_Time.z * _RotationSpeed)
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed2 center = fixed2(0.5, 0.5);
				float s = sin ( _RotationSpeed * _Time );
                float c = cos ( _RotationSpeed * _Time );
                float2x2 rotate = float2x2( c, -s, s, c);
				//float2x2 rotate = float2x2(cos(_Time * _RotationSpeed), -sin(_Time * _RotationSpeed), sin(_Time * _RotationSpeed), cos(_Time * _RotationSpeed));
				fixed2 uv_OverTex = mul(rotate, i.uv - center) + center;
				// sample the texture
				fixed4 col = tex2D(_MainTex, uv_OverTex)* _Color * 1.5;
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
