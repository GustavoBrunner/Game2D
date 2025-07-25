Shader "Unlit/Shader2"{
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        
        _WaveAmpl ("Wave amplitude", Range(0,0.5)) = 0.1
        
        _Color("Water Color", Color) = (1,1,1,1)
    }
    SubShader{
        Tags {
            "RenderType"="Opaque"
        }

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define TAU 6.28318530718

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float _WaveAmpl;

            float4 _Color;

            
            struct MeshData {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float2 uv0 : TEXCOORD0;
            };

            struct Interpolators {
                float2 uv : TEXCOORD1;
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
            };

            Interpolators vert (MeshData v){
                Interpolators o;
                
                float wave_y = cos( (v.uv0.y - _Time.y * 0.1) * TAU * 3 );
                float wave_x = cos( (v.uv0.x - _Time.y * 0.1) * TAU * 7 );

                v.vertex.y = wave_y * wave_x * _WaveAmpl;

                
                o.vertex = UnityObjectToClipPos( v.vertex );
                o.normal = UnityObjectToWorldNormal( v.normals ); 
                o.uv = v.uv0;
                return o;
            }

            fixed4 frag (Interpolators i) : SV_Target {
                float xOffSet = cos( i.uv.x * TAU * 8 ) * 0.01;
                
                float t = cos( (i.uv.y + xOffSet - _Time.y * 0.1) * TAU * 5 ) * 0.5 + 0.5;

                t *= 1-i.uv.y;
                
                return t * _Color;
            }
            ENDCG
        }
    }
}
