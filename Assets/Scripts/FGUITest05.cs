using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
public class FGUITest05 : MonoBehaviour
{
    private GComponent mainUI;
    private GProgressBar progressBar;
    private GComboBox comboBox;

    // Start is called before the first frame update
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        progressBar = mainUI.GetChild("n0").asProgress;
        comboBox = mainUI.GetChild("n1").asComboBox;
        progressBar.value = 0;
        comboBox.onChanged.Add(SetComboBoxChange);
    }

    private void SetComboBoxChange(){

        progressBar.value = 0;
        progressBar.TweenValue(100,Convert.ToInt32(comboBox.value));
    }

}
