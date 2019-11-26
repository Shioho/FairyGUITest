using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;
public class FGUITest08_Joystick : EventDispatcher
{
    public EventListener onMove { get; private set; }
    public EventListener onEnd { get; private set; }

    private GObject touchArea;
    private GObject center;
    private GObject thumb;


    private int touchID;
    private GTweener tweener;


    private Vector2 initPos;//初始位置
    private Vector2 startPos;//点击第一下的位置

    private float maxRadian = 150;

    public FGUITest08_Joystick(GComponent mainUI)
    {

        onMove = new EventListener(this, "onMove");
        onEnd = new EventListener(this, "onEnd");

        touchArea = mainUI.GetChild("touchArea");
        center = mainUI.GetChild("center");
        thumb = mainUI.GetChild("thumb");

        touchArea.onTouchBegin.Add(OnTouchBegin);
        touchArea.onTouchMove.Add(OnTouchMove);
        touchArea.onTouchEnd.Add(OnTouchEnd);

        touchID = -1;
        initPos = GetAddHalfWHPos(center.position, center);

    }

    private void OnTouchBegin(EventContext context)
    {
        if (touchID == -1)
        {
            InputEvent inputEvent = (InputEvent)context.data;
            touchID = inputEvent.touchId;
            if (tweener != null)
            {
                tweener.Kill();
                tweener = null;
            }
            Vector2 localPos = GRoot.inst.GlobalToLocal(inputEvent.position);

            startPos = localPos;

            SetCenterPosXY(center, localPos);
            center.visible = false;
            SetCenterPosXY(thumb, localPos);
            thumb.visible = true;

            Vector2 dir = new Vector2(startPos.x - initPos.x, startPos.y - initPos.y);
            float radian = Mathf.Atan2(dir.y, dir.x);
            float degree = radian * 180 / Mathf.PI;
            thumb.rotation = degree + 90;

            context.CaptureTouch();
            // Debug.Log("===============>TouchBegin"+degree);
        }
    }

    private void OnTouchMove(EventContext context)
    {
        InputEvent inputEvent = (InputEvent)context.data;
        if (touchID != -1 && inputEvent.touchId == touchID)
        {
            Vector2 localPos = GRoot.inst.GlobalToLocal(inputEvent.position);
            center.visible = true;
            Vector2 moveVec = localPos - startPos;

            float radian = Mathf.Atan2(moveVec.y, moveVec.x);
            float degree = radian * 180 / Mathf.PI;
            thumb.rotation = degree + 90;
            if (moveVec.magnitude > maxRadian)
            {
                moveVec.Normalize();
                moveVec *= maxRadian;
            }

            moveVec += startPos;
            SetCenterPosXY(thumb, moveVec);
            onMove.Call(degree);
            // Debug.Log("===============>TouchMove");
        }

    }

    private void OnTouchEnd(EventContext context)
    {
        InputEvent inputEvent = (InputEvent)context.data;
        if (touchID != -1 && inputEvent.touchId == touchID)
        {
            touchID = -1;
            center.visible = false;
            tweener = thumb.TweenMove(GetReduceHalfWHPos(initPos, thumb), 0.3f).OnComplete(() =>
            {
                SetCenterPosXY(center, initPos);
                center.visible = true;
                thumb.rotation = 0;
                thumb.visible = false;
            });
            // Debug.Log("===============>TouchEnd");
        }
        onEnd.Call();
    }


    private void SetCenterPosXY(GObject obj, Vector2 pos)
    {
        obj.SetXY(pos.x - obj.width / 2, pos.y - obj.height / 2);
    }

    private Vector2 GetAddHalfWHPos(Vector2 startPos, GObject obj)
    {
        return new Vector2(startPos.x + obj.width / 2, startPos.y + obj.height / 2);
    }
    private Vector2 GetReduceHalfWHPos(Vector2 startPos, GObject obj)
    {
        return new Vector2(startPos.x - obj.width / 2, startPos.y - obj.height / 2);
    }


}
