Shader "Unlit/Shader3"{
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _WaveAmp ("Wave Amplitude", Range(0,0.5)) = 0.1
    }
    SubShader{
        Tags {
            "RenderType"="Opaque"
        }

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #define TAU 6.28318530718

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _WaveAmp;
            
            struct MeshData {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float2 uv0 : TEXCOORD0;
            };
            float GetWave( float2 uv ) {
                //centraliza os UVs para o meio da mesh
                float2 uvsCentered = uv * 2 - 1;

                //Calcula a distância do meio da mesh para as pontas dela
                float radialDistance = length( uvsCentered );

                //retornamos o degradê saindo do meio da mesh para o fim dela.
                //return float4( radialDistance.xxx, 1 );
                float wave = cos( (radialDistance - _Time.y * 0.1) * TAU * 5 ) * 0.5 + 0.5;
                wave *= 1-radialDistance;
                return wave;
            }

            struct Interpolators {
                float2 uv : TEXCOORD1;
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
            };


            Interpolators vert (MeshData v) {
                Interpolators o;

                v.vertex.y = GetWave( v.uv0 ) * _WaveAmp;
                
                o.vertex = UnityObjectToClipPos( v.vertex );
                o.normal = UnityObjectToWorldNormal( v.normals );
                o.uv = v.uv0;
                return o;
            }
            

            float4 frag (Interpolators i) : SV_Target {
                float wave = GetWave(i.uv);
                
                return wave;
            }
            ENDCG
        }
    }
}
