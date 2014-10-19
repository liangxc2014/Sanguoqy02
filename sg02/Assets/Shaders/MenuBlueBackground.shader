Shader "Custom/MenuBlueBackground" {
	Properties {
		_Color ("Tint", Color) = (1, 1, 1, 1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Region ("Tint", Color) = (0.05, 0.95, 0.05, 0.95)
	}
	SubShader 
	{
		LOD 100

		Tags 
		{ 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
        }

        Cull Off 
        Lighting Off 
        ZWrite Off 
        Fog { Mode Off }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass 
		{
        	CGPROGRAM
        	#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata_t
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};
	
			struct v2f
			{
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
				fixed4 color : COLOR;
			};

			fixed4 _Color;
			sampler2D _MainTex;	
			fixed4 _Region;

			v2f vert (appdata_t v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.texcoord = v.texcoord;
				o.color = v.color;
				return o;
			}

            fixed4 frag (v2f i) : COLOR
            {
				float4 c = tex2D (_MainTex, i.texcoord.xy) * i.color * _Color;

				if (i.texcoord.x >= _Region.x && i.texcoord.x <= _Region.y && i.texcoord.y >= _Region.z && i.texcoord.y <= _Region.w)	 
				{
					if (c.a <= 0.7)
						return float4 (0,0.06,0.35,0.6);
				}

				return c;
			}
			ENDCG
        }
    }

	SubShader
	{
		LOD 100

		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		
		Pass
		{
			Cull Off
			Lighting Off
			ZWrite Off
			Fog { Mode Off }
			Offset -1, -1
			ColorMask RGB
			AlphaTest Greater .01
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMaterial AmbientAndDiffuse
			
			SetTexture [_MainTex]
			{
				Combine Texture * Primary
			}
		}
	}
}
