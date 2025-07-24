Shader "Unlit/Shader1"
{
    Properties {
        //_MainTex ("Texture", 2D) = "white" {}
        _ColorA("Color A", Color) = (1,1,1,1)
        _ColorB("Color B", Color) = (1,1,1,1)
        _ColorStart("Color Start", Range(0,1)) = 0
        _ColorEnd("Color End", Range(0,1)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }
        //LOD 100

        Pass{
            //ZTest Always //Will always render the shader, doesnt matter if it is being overlapped by another gameobject
            //ZTest GEqual //Will only show the shader if it is behind another gameobject
            //ZTest LEqual //Will show only the parts of the shaders that ARE NOT being overlapped by an object
            //Cull Front - Will hide the front part of our mesh
            //Cull Back - default, will hide the back part of our mesh
            Cull Off // Will show both parts
            ZWrite Off
            Blend One One 
            
            
            CGPROGRAM
            #pragma vertex vert // runs on every vertex of a mesh
            #pragma fragment frag // runs on every pixel of a mesh

            #include "UnityCG.cginc"
            #define TAU 6.28318530718

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float4 _ColorA;
            float4 _ColorB;

            float _ColorStart;
            float _ColorEnd;

            
            
            
            struct MeshData{ //per-vertex mesh data 
                float4 vertex : POSITION; //
                float4 tangent : TANGENT; // 
                float3 normals : NORMAL;
                float4 color : COLOR; 
                float2 uv0 : TEXCOORD0; //uv0 diffuse/normal map textures
                // float2 uv1 : TEXCOORD1; //uv1 coordinates
            };

            struct Interpolators { //original name V2F, vertex to fragment, passes data from the vertices to the frag shader
                //float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
            };

            //data passed from the vertex shader to the fragment shader
            //this will interpolate/blend accross the triangle
            Interpolators vert ( MeshData v ){
                Interpolators o;
                
                // this makes the object which the shader is applied will be followed by the shader
                // if we change it, it may be stuck to the camera.
                // for example: o.vertex = v.vertex
                o.vertex = UnityObjectToClipPos( v.vertex );

                o.normal = UnityObjectToWorldNormal( v.normals );//mul( ( float3x3 )unity_ObjectToWorld, v.normals );//UnityObjectToWorldNormal( v.normals ); //v.normals; //passing data from the MashData to the interpolator

                o.uv = (v.uv0 + _ColorStart) * _ColorEnd; //this allow us to create transitions between colors
                
                return o;
            }

            float InverseLerp(float a, float b, float v){
                return (v-a)/(b-a);
            }

            

            //float: 32 bit float precision
            //half: 16 bit float precision
            //fixed : around 12 bit float precision
            //float4 -> half4 -> fixed4 -> This is equals to Vector4, theres equivalent of float2/3
            //float4x4 -> half4x4 -> fixed4x4 -> this is equivalent to a matrix
            float4 frag ( Interpolators i ) : SV_Target {

                //float t = saturate( InverseLerp( _ColorStart, _ColorEnd, i.uv.x ) );
                //return t;

                float xOffset = cos( i.uv.x * TAU * 8 ) * 0.01;
                
                float t = cos(( i.uv.y + xOffset - _Time.y * 0.1 ) * TAU * 5 ) * 0.5 + 0.5;

                t *= 1-i.uv.y;

                float bottomUpRemover = abs( i.normal.y ) < 0.999;
                float waves = t * bottomUpRemover;

                float4 gradient = lerp( _ColorA, _ColorB, i.uv.y );
                
                return gradient * waves;

                
                //blend between two colors based on the x uv coordinates
                // float4 outputColor = lerp(_ColorA, _ColorB, t);
                //
                // return outputColor;
            }
            ENDCG
        }
    }
}
