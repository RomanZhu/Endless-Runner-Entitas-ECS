Shader "FX/Distortion" {
Properties {
  _Color("Color", Color) = (1,1,1,1)
	_MainTex ("Normalmap", 2D) = "bump" {}
  _Magnitude("Magnitude", Range(0,1)) = 0.05
}

Category {

	Tags { "Queue"="Transparent" }

	SubShader {

		GrabPass { "_BackgroundTex" }

		Pass {
			Name "BASE"
			
      CGPROGRAM
      #pragma vertex vert
      #pragma fragment frag 
      #include "UnityCG.cginc"

      struct vertexInput {
	      float4 vertex : POSITION;
	      float2 texcoord: TEXCOORD0;
      };

      struct vertexOutput {
	      float4 vertex : SV_POSITION;
	      float4 uvgrab : TEXCOORD0;
	      float2 uvmain : TEXCOORD2;
	      UNITY_FOG_COORDS(3)
      };

      fixed4 _Color;
      sampler2D _MainTex;
      float4 _MainTex_ST;
      float _BumpAmt;
      float4 _BumpMap_ST;
      float  _Magnitude;

      vertexOutput vert (vertexInput v)
      {
	      vertexOutput o;
	      o.vertex = UnityObjectToClipPos(v.vertex);
	      #if UNITY_UV_STARTS_AT_TOP
	      float scale = -1.0;
	      #else
	      float scale = 1.0;
	      #endif
	      o.uvgrab.xy = (float2(o.vertex.x, o.vertex.y*scale) + o.vertex.w) * 0.5;
	      o.uvgrab.zw = o.vertex.zw;
	      o.uvmain = TRANSFORM_TEX( v.texcoord, _MainTex );
	      UNITY_TRANSFER_FOG(o,o.vertex);
	      return o;
      }

      sampler2D _BackgroundTex;
      float4 _GrabTexture_TexelSize;
      sampler2D _BumpMap;

      half4 frag (vertexOutput i) : SV_Target
      {
        half4 bump = tex2D(_MainTex, i.uvmain);

        half2 distortion = UnpackNormal(bump).rg;
        i.uvgrab.xy += distortion * _Magnitude;
	
	      half4 col = tex2Dproj(_BackgroundTex, UNITY_PROJ_COORD(i.uvgrab));

	      col *= _Color;

	      return col;
      }
      ENDCG
		}
	}
}

}