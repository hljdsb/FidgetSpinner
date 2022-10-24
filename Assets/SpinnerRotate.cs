using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerRotate : MonoBehaviour
{
    public float _speed = 0;//旋转速度
    public float Speed
    {
        get { return _speed; }
    }
    private float deceleration;//减速度
    private void Update()
    {
        if(_speed!=0)
        {
            this.transform.Rotate(Vector3.forward, _speed * Time.deltaTime);
        }
        
    }
    /// <summary>
    /// 加速
    /// </summary>
    /// <param name="speed"></param>
    public void AddSpeed(float speed)
    {
        _speed += speed;
    }
    /// <summary>
    /// 减速
    /// </summary>
    public void Decelerate()
    {
        deceleration = _speed * 0.01f;
        _speed -= deceleration;
        if(Mathf.Abs(_speed)<=50)
        {
            _speed = 0;
        }
    }

    public void Rotate(float speed)
    {
        this.transform.Rotate(Vector3.forward,  10*speed* Time.deltaTime);
    }
}
