using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHPBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;



    public void UpdateHPBar(float currentVal, float maxVal)
    {
        slider.value = (float) currentVal / (float) maxVal;
    }


    private void Update()
    {
        
    }


}
