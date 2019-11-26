using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class FGUITest01 : MonoBehaviour
{
    private GComponent btnCom;
    private GComponent alertCom;


    private void Start()
    {
        btnCom = GetComponent<UIPanel>().ui;
        alertCom = UIPackage.CreateObject("Package", "BossAlert").asCom;

        btnCom.GetChild("Btn").onClick.Add(()=>{
            OnClickBossBtnEvent(alertCom);
        });

    }

    private void OnClickBossBtnEvent(GComponent target)
    {
        GObject btnGroup =  btnCom.GetChild("BossBtnGroup");
        btnGroup.visible = false;
        GRoot.inst.AddChild(target);
        target.GetTransition("AlertAppear").Play(()=>{
            btnGroup.visible=true;
            GRoot.inst.RemoveChild(target);
        });
    }


}
