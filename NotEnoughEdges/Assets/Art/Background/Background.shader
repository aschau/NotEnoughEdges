// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/Background"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_MainTex1 ("Texture", 2D) = "white" {}
		_ColorTex("Texture", 2D) = "white" {}
		[PerRendererData] _PlayerPos("PlayerPosition", Vector) = (0, 0, 0, 0)
	
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			Blend One Zero

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : POSITION;
				float2 uvMain : TEXCOORD0;
				float2 uvColor : TEXCOORD1;
			};

			sampler2D _MainTex1;
			sampler2D _ColorTex;
			float2 _PlayerPos;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				float2 worldPos = mul(unity_ObjectToWorld, v.vertex).xy;

				o.uvMain = v.uv;
				o.uvColor.x = v.uv.x;

				//center is at (worldPos - _PlayerPos)
				o.uvColor.x = (((worldPos.x - _PlayerPos.x) / 3) + 1) / 2;
				o.uvColor.y = (((worldPos.y - _PlayerPos.y)/ 3) + 1) / 2;

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex1, i.uvMain);
				col.rgb *= col.a;
				col.rgb *= tex2D(_ColorTex, i.uvColor).rgb;
				return col;
			}
			ENDCG
		}
	}
}
