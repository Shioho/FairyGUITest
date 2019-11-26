Shader "Shioho/cg"
{
    SubShader
    {
        pass{
            CGPROGRAM

            #pragma vertex vext
            #pragma fragment frag

            void vext(inout float4 pos:POSITION,out fixed4 col:COLOR){
                
                // pos = fixed4(objPos,0,1);

                if(pos.x>0&&pos.y>0){
                    col = fixed4(1,0,0,1);
                }else if(pos.x>0){
                    col = fixed4(0,1,0,1);
                }else if(pos.y>0){
                    col = fixed4(0,0,1,1);
                }else{
                    col = fixed4(1,0,1,1);

                }


                // col = pos;
                







            }

            void frag(inout fixed4 col:COLOR){

                // fixed arr[4] = {1,0.5,0.5,1};
                // col = fixed4(arr);
                // col = fixed4(arr[0],arr[1],arr[2],arr[3]);
                // col = fixed4(1,0,0,1);
                // int i =2;
                
                // switch(i){
                //     case 0:{
                //         col = fixed4(1,0,0,1);
                //         break;
                //     }
                //     case 1:{
                //         col = fixed4(0,1,0,1);
                //         break;
                //     }
                //     default:{
                //         col = fixed4(0,0,1,1);
                //         break;
                //     }


                // }



            }

            ENDCG



        }


    }
}
