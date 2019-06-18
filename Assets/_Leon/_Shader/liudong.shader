// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.35 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:4013,x:34054,y:32313,varname:node_4013,prsc:2|diff-937-OUT,emission-6581-OUT,clip-4022-OUT;n:type:ShaderForge.SFN_Tex2d,id:3471,x:32932,y:32742,ptovrint:False,ptlb:node_3471,ptin:_node_3471,varname:node_3471,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fe29dd2776b09444ba47230c9b770f56,ntxv:0,isnm:False|UVIN-1814-OUT;n:type:ShaderForge.SFN_Multiply,id:8699,x:33155,y:32710,varname:node_8699,prsc:2|A-7380-OUT,B-3471-RGB;n:type:ShaderForge.SFN_TexCoord,id:5193,x:32148,y:32683,varname:node_5193,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:332,x:32380,y:32683,varname:node_332,prsc:2,spu:0,spv:0.04|UVIN-5193-UVOUT;n:type:ShaderForge.SFN_Slider,id:4195,x:32100,y:32952,ptovrint:False,ptlb:node_4195,ptin:_node_4195,varname:node_4195,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:6,max:10;n:type:ShaderForge.SFN_Multiply,id:1814,x:32602,y:32759,varname:node_1814,prsc:2|A-332-UVOUT,B-4195-OUT;n:type:ShaderForge.SFN_Multiply,id:6581,x:33364,y:32732,varname:node_6581,prsc:2|A-3692-RGB,B-8699-OUT;n:type:ShaderForge.SFN_Color,id:3692,x:33090,y:32510,ptovrint:False,ptlb:node_3692,ptin:_node_3692,varname:node_3692,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9333334,c2:0.2117647,c3:0,c4:1;n:type:ShaderForge.SFN_Fresnel,id:9514,x:33010,y:32220,varname:node_9514,prsc:2|NRM-2208-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7380,x:32685,y:32518,ptovrint:False,ptlb:node_7380,ptin:_node_7380,varname:node_7380,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_OneMinus,id:4022,x:33235,y:32220,varname:node_4022,prsc:2|IN-9514-OUT;n:type:ShaderForge.SFN_NormalVector,id:2208,x:32799,y:32220,prsc:2,pt:False;n:type:ShaderForge.SFN_Power,id:7341,x:33537,y:32219,varname:node_7341,prsc:2|VAL-4022-OUT,EXP-2394-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2394,x:33298,y:32460,ptovrint:False,ptlb:node_2394,ptin:_node_2394,varname:node_2394,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Color,id:1317,x:33485,y:32039,ptovrint:False,ptlb:node_1317,ptin:_node_1317,varname:node_1317,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9176471,c2:0.8588236,c3:0.03921569,c4:1;n:type:ShaderForge.SFN_Multiply,id:937,x:33746,y:32175,varname:node_937,prsc:2|A-1317-RGB,B-7341-OUT;proporder:3471-4195-3692-7380-2394-1317;pass:END;sub:END;*/

Shader "Shader Forge/liudong" {
    Properties {
        _node_3471 ("node_3471", 2D) = "white" {}
        _node_4195 ("node_4195", Range(0, 10)) = 6
        _node_3692 ("node_3692", Color) = (0.9333334,0.2117647,0,1)
        _node_7380 ("node_7380", Float ) = 1
        _node_2394 ("node_2394", Float ) = 5
        _node_1317 ("node_1317", Color) = (0.9176471,0.8588236,0.03921569,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _node_3471; uniform float4 _node_3471_ST;
            uniform float _node_4195;
            uniform float4 _node_3692;
            uniform float _node_7380;
            uniform float _node_2394;
            uniform float4 _node_1317;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_4022 = (1.0 - (1.0-max(0,dot(i.normalDir, viewDirection))));
                clip(node_4022 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = (_node_1317.rgb*pow(node_4022,_node_2394));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float4 node_8128 = _Time + _TimeEditor;
                float2 node_1814 = ((i.uv0+node_8128.g*float2(0,0.04))*_node_4195);
                float4 _node_3471_var = tex2D(_node_3471,TRANSFORM_TEX(node_1814, _node_3471));
                float3 emissive = (_node_3692.rgb*(_node_7380*_node_3471_var.rgb));
/// Final Color:
                float3 finalColor = diffuse + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _node_3471; uniform float4 _node_3471_ST;
            uniform float _node_4195;
            uniform float4 _node_3692;
            uniform float _node_7380;
            uniform float _node_2394;
            uniform float4 _node_1317;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_4022 = (1.0 - (1.0-max(0,dot(i.normalDir, viewDirection))));
                clip(node_4022 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = (_node_1317.rgb*pow(node_4022,_node_2394));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
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
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float node_4022 = (1.0 - (1.0-max(0,dot(i.normalDir, viewDirection))));
                clip(node_4022 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
