using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class FGUITest07 : MonoBehaviour
{
    private GComponent mainUI;
    private GButton btnBag;
    private GButton btnItemShow;
    // Start is called before the first frame update
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        btnBag = mainUI.GetChild("btnBag").asButton;
        btnItemShow = mainUI.GetChild("btnItemShow").asButton;

        FGUITest07_Window window = new FGUITest07_Window();
        btnBag.onClick.Add(()=>{
            window.Show();
            window.SetXY(100,50);
        });
        window.onClickItem+=OnClickItem;
        btnItemShow.onClick.Add(UseItem);
    }

    private void OnClickItem(GButton btn){
        btnItemShow.title = btn.title;
        btnItemShow.icon = btn.icon;
    }

    private void UseItem(){
        btnItemShow.title = "";
        btnItemShow.icon = null;
    }


}
