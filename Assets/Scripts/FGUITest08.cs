using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class FGUITest08 : MonoBehaviour
{
    private GComponent mainUI;
    private GTextField degreeValue;
    private FGUITest08_Joystick joystick;
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        degreeValue = mainUI.GetChild("degreeValue").asTextField;
        joystick = new FGUITest08_Joystick(mainUI);
        joystick.onMove.Add(OnMove);
        joystick.onEnd.Add(OnEnd);
    }

    private void OnMove(EventContext context)
    {
        float degree = (float)context.data;
        degreeValue.text = degree.ToString();
    }

    private void OnEnd()
    {
        degreeValue.text = "";
    }



}
