Shader "Study/ColorImageEffectTest"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
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
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float4 _MainTex_TexelSize;


			fixed togray(fixed3 col)
			{
				return col * fixed3(0.299,0.587,0.114);
			}

			fixed4 frag (v2f i) : SV_Target
			{

				//-1, 0, 1
				//-2 ,0, 2
				//-1, 0, 1
				fixed3 gx = tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(-1,-1)) * -1;
				//gx += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(0,-1)) * 0;
				gx += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(1,-1)) * 1; 

				gx += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(-1,0)) * -2;
				//gx += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(0,0)) * 0; 
				gx += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(1,0)) * 2;

				gx += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(-1,1)) * -1;
				//gx += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(0,1)) * 0; 
				gx += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(1,1)) * 1; 


				fixed t = togray(abs(gx));
				fixed3 col = fixed3(t,t,t);

				//-1 -2 -1
				//0 0 0
				//1 2 1
				fixed3 gy = tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(-1,-1)) * -1;
				gy += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(0,-1)) * -2;
				gy += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(1,-1)) * -1; 

				//gy += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(-1,0)) * -2;
				//gy += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(0,0)) * 0; 
				//gy += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(1,0)) * 2;

				gy += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(-1,1)) * 1;
				gy += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(0,1)) * 2; 
				gy += tex2D(_MainTex, i.uv +_MainTex_TexelSize.xy* half2(1,1)) * 1; 


				t = togray(abs(gy)) ;
				col += fixed3(t,t,t);

				col *=0.5f;
				return fixed4(col,1);
			}
			ENDCG
		}
	}

	FallBack off
}
