using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;
public class FGUITest02 : MonoBehaviour
{
    private GComponent btnClick;
    private GComponent attackValue;
    // Start is called before the first frame update

    private int startValue;
    private int endValue;

    void Start()
    {
        btnClick = GetComponent<UIPanel>().ui;
        attackValue = UIPackage.CreateObject("Package","AttackValue").asCom;
        attackValue.GetTransition("t1").SetHook("AddValue",DoAddValue);
        btnClick.GetChild("n0").onClick.Add(()=>{
            OnShowAttackValueEvent(attackValue);
        });

    }
    private void DoAddValue(){

        DOTween.To(()=>startValue,x=>{
            attackValue.GetChild("n2").text = x.ToString();
        },endValue,0.3f).SetEase(Ease.Linear).SetUpdate(true);
    }


    private void OnShowAttackValueEvent(GComponent target){
        GObject btn = btnClick.GetChild("n0");
        btn.visible = false;
        GRoot.inst.AddChild(target);
        startValue = Random.Range(0,10000);
        int addValue = Random.Range(0,3000);
        endValue = startValue+addValue;

        target.GetChild("n2").text = startValue.ToString();
        target.GetChild("n7").text = "+"+addValue;
        
        target.GetTransition("t1").Play(()=>{
            btn.visible = true;
            GRoot.inst.RemoveChild(target);
        });

    }

}
