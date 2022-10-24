using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FingerDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    //陀螺上的旋转组件
    private SpinnerRotate spinnerRotate;
    public Text timeText;
    //当前能滑动的时间
    public float dragTime;
    //总共剩余滑动时间
    public float totalTime = 3;
    //是否开始旋转
    public bool isBeginRotate = false;
    //是否向右旋转
    private bool isRight;
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        
        if (!isBeginRotate)//当没有开始旋转时，手指移动让陀螺跟随手指旋转
        {
            spinnerRotate.Rotate(eventData.delta.x);
        }else//开始旋转
        {
            if(dragTime>0)//如果拖拽时间大于零
            {
                if (isRight == eventData.delta.x > 0)//如果旋转方向和拖拽的方向相同时，给陀螺加速
                    spinnerRotate.AddSpeed(eventData.delta.x);
            }
            
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (isBeginRotate) return;//陀螺在旋转时不执行后面代码
        isRight = eventData.delta.x > 0;//标记陀螺旋转的方向
        spinnerRotate.AddSpeed(eventData.delta.x*5);//第一次拖拽时让陀螺加速
        isBeginRotate = true;//标记陀螺正在旋转
        dragTime = totalTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        spinnerRotate = GetComponentInChildren<SpinnerRotate>();
        dragTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(dragTime>0)//如果拖拽时间大于零时
        {
            if(isBeginRotate)//如果陀螺正在旋转
            {
                dragTime -= Time.deltaTime;//拖拽时间减少
                if (dragTime < 0)//拖拽时间小于零
                {
                    dragTime = 0;//将拖拽时间设为零
                }
            }
            
        }
        if (spinnerRotate.Speed != 0)//如果速度不为0则让陀螺减速
        {
            spinnerRotate.Decelerate();
        }
        else
        {
            dragTime = 0;
            if (isBeginRotate) isBeginRotate = false;//如果陀螺速度为零让开始移动变为fasle
        }
        timeText.gameObject.SetActive(dragTime>0);
        timeText.text = Mathf.Ceil(dragTime).ToString();
    }
}
