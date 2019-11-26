using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public delegate void OnClickItemEventHandler(GButton obj);
public class FGUITest07_Window : Window
{
    public event OnClickItemEventHandler onClickItem;
    public FGUITest07_Window(){

    }

    protected override void OnInit(){
        this.contentPane = UIPackage.CreateObject("Package07","BagDialog").asCom;

        int cnt = 20;
        GList list = this.contentPane.GetChild("list").asList;
        list.itemRenderer = OnItemRender;
        list.numItems = cnt;

    }


    private void OnItemRender(int idx,GObject obj){
        GButton item = obj.asButton;
        int id = (idx%10);
        item.icon = UIPackage.GetItemURL("Package07","i"+id);
        item.title = "Item "+id;
        item.onClick.Add(()=>{
            onClickItem(item);
        });
    }



}
