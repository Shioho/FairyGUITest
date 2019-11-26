using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class FGUITest06 : MonoBehaviour
{
    private GComponent mainUI;

    public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        mainUI = GetComponent<UIPanel>().ui;
        FGUITest06_Window window = new FGUITest06_Window(npc);
        mainUI.GetChild("n0").onClick.Add(()=>{
            window.Show();
            window.SetPosition(167,114,window.z);

        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
