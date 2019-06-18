// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.35 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|emission-2185-OUT;n:type:ShaderForge.SFN_Tex2d,id:6673,x:32001,y:32342,ptovrint:False,ptlb:node_6673,ptin:_node_6673,varname:node_6673,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:f11ee23620de3a746a7dd0704098fad6,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6421,x:32158,y:32737,ptovrint:False,ptlb:node_6421,ptin:_node_6421,varname:node_6421,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-9464-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2185,x:32365,y:32669,varname:node_2185,prsc:2|A-2780-OUT,B-6421-RGB,C-6231-RGB;n:type:ShaderForge.SFN_TexCoord,id:404,x:31712,y:32737,varname:node_404,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:9464,x:31921,y:32737,varname:node_9464,prsc:2,spu:0.2,spv:0|UVIN-404-UVOUT,DIST-6231-R;n:type:ShaderForge.SFN_TexCoord,id:884,x:31712,y:32960,varname:node_884,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:861,x:31921,y:32960,varname:node_861,prsc:2,spu:0,spv:0.1|UVIN-884-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:6231,x:32138,y:32960,ptovrint:False,ptlb:node_6231,ptin:_node_6231,varname:node_6231,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-861-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2780,x:31985,y:32535,varname:node_2780,prsc:2|A-6673-RGB,B-4094-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4094,x:31731,y:32430,ptovrint:False,ptlb:node_4094,ptin:_node_4094,varname:node_4094,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;proporder:6673-6421-6231-4094;pass:END;sub:END;*/

Shader "Shader Forge/yan" {
    Properties {
        _node_6673 ("node_6673", 2D) = "white" {}
        _node_6421 ("node_6421", 2D) = "white" {}
        _node_6231 ("node_6231", 2D) = "white" {}
        _node_4094 ("node_4094", Float ) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _node_6673; uniform float4 _node_6673_ST;
            uniform sampler2D _node_6421; uniform float4 _node_6421_ST;
            uniform sampler2D _node_6231; uniform float4 _node_6231_ST;
            uniform float _node_4094;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _node_6673_var = tex2D(_node_6673,TRANSFORM_TEX(i.uv0, _node_6673));
                float4 node_4750 = _Time + _TimeEditor;
                float2 node_861 = (i.uv0+node_4750.g*float2(0,0.1));
                float4 _node_6231_var = tex2D(_node_6231,TRANSFORM_TEX(node_861, _node_6231));
                float2 node_9464 = (i.uv0+_node_6231_var.r*float2(0.2,0));
                float4 _node_6421_var = tex2D(_node_6421,TRANSFORM_TEX(node_9464, _node_6421));
                float3 emissive = ((_node_6673_var.rgb*_node_4094)*_node_6421_var.rgb*_node_6231_var.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
