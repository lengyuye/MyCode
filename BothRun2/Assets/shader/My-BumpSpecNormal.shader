﻿Shader "Custom/My-BumpSpecNormal" {
	Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
	_MainTex ("Base (RGB) TransGloss (A)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	_specTex_Gloss("Specular(RGB)Gloss(A)", 2D) = "black" {}
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	LOD 400
	
CGPROGRAM
#pragma surface surf BlinnPhong alpha

sampler2D _MainTex;
sampler2D _BumpMap;
fixed4 _Color;
half _Shininess;
sampler2D _specTex_Gloss;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
	float2 uv_specTex_Gloss;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	o.Albedo = tex.rgb * _Color.rgb;
	o.Gloss = tex.a;
	o.Alpha = tex.a * _Color.a;
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	
	
	float4 Tex2D0=tex2D(_specTex_Gloss,(IN.uv_specTex_Gloss.xyxy).xy);
	float4 Add0=_Shininess.xxxx + Tex2D0.aaaa;
	//float4 Add1=Tex2D0 + _specColor;
	o.Specular = Add0;
	
}
ENDCG
}

FallBack "Transparent/VertexLit"
}
