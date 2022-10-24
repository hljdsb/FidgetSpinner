using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedShow : MonoBehaviour
{
    public Text speedText;
    private SpinnerRotate spinnerRotate;

    private void Awake()
    {
        spinnerRotate = GetComponentInChildren<SpinnerRotate>();
    }
    // Update is called once per frame
    void Update()
    {
        float fps = 1 / Time.deltaTime;//帧率
        if(spinnerRotate!=null)
        {
            float num = Mathf.Abs(Mathf.Floor(spinnerRotate.Speed * Time.deltaTime / 360 * fps * 60));
            speedText.text = num + "圈/分钟";
        }
        
    }
}
