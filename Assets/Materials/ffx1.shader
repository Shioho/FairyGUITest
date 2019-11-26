Shader "Shioho/ffx1"
{
    Properties
    {
        _Color ("Diffuse Color", Color) = (1,1,1,1)
        _AmbientColor ("Ambient Color", Color) = (1,1,1,1)
        _SpecularColor ("Specular Color", Color) = (1,1,1,1)
        _Shininess("Shininess",Range(0,8)) = 4
        _EmissionColor("EmissionColor",Color) = (1,1,1,1)

        _MainTex("MainTex",2D) = "white"{}
        _SecondTex("SecondTex",2D) = "white"{}

        _ConstantColor("ConstantColor",Color) = (1,1,1,0.3)
    }
    SubShader
    {
        pass{
            Tags{ "Queue"="Transparent"  }
            ZTest off
            Blend SrcAlpha OneMinusSrcAlpha

            //漫反射要开启光照
            lighting on
            //高光需要开启镜面反射
            separateSpecular on
            // color[_Color]
            material{
                diffuse[_Color]
                ambient[_AmbientColor]
                specular[_SpecularColor]
                shininess[_Shininess]
                emission[_EmissionColor]
            }

            SetTexture[_MainTex]{

                Combine texture * primary double
            }
            SetTexture[_SecondTex]{

                ConstantColor[_ConstantColor]
                Combine texture * previous double,constant
            }


        }

    }
}
