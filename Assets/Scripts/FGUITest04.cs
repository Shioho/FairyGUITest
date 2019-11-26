using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class FGUITest04 : MonoBehaviour
{
    private GComponent mainUI;
    private GList list;
    // Start is called before the first frame update
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        list = mainUI.GetChild("n0").asList;
        list.SetVirtualAndLoop();
        list.itemRenderer = OnRenderItem;
        list.numItems = 5;
        list.scrollPane.onScroll.Add(DoScrollEffect);
        DoScrollEffect();
    }

    private void OnRenderItem(int index, GObject item){
        GButton btn = item.asButton;
        btn.icon = UIPackage.GetItemURL("Package04","n"+(index+1));
    }

    private void DoScrollEffect(){
        float centerX = list.scrollPane.posX + list.viewWidth/2;
        for(int i=0;i<list.numChildren;i++){
            GObject item = list.GetChildAt(i);
            float halfW =  item.width/2;
            float itemX = item.x + halfW;
            float dis = Mathf.Abs(centerX - itemX);
            if(dis<halfW){
                float scale = 1+(1-(dis/halfW))*0.3f;
                item.SetScale(scale,scale);
            }else{
                item.SetScale(1,1);
            }

        }

    }


}
