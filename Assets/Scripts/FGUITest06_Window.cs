using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class FGUITest06_Window : Window
{
    private GameObject npc;
    public FGUITest06_Window(GameObject obj)
    {
        npc = obj;
    }

    protected override void OnInit()
    {
        this.contentPane = UIPackage.CreateObject("Package06", "PlayerDialog").asCom;
        RenderTexture rt = Resources.Load<RenderTexture>("FGUI/Test06/NpcRT");
        Material mat = Resources.Load<Material>("FGUI/Test06/NpcMat");
        NTexture texture = new NTexture(rt);
        GGraph graph = this.contentPane.GetChild("n1").asGraph;

        Image img = new Image();
        img.texture = texture;
        img.material = mat;
        graph.SetNativeObject(img);
        this.contentPane.GetChild("n1").y = 80;
        this.contentPane.GetChild("n2").onClick.Add(RotateRight);
        this.contentPane.GetChild("n3").onClick.Add(RotateLeft);

    }

    private void RotateLeft()
    {
        npc.transform.Rotate(Vector3.up * 30, Space.World);
    }

    private void RotateRight()
    {
        npc.transform.Rotate(Vector3.up * -30, Space.World);
    }




}
