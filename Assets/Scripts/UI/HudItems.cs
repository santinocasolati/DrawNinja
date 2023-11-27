using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudItems : MonoBehaviour
{
    public static HudItems instance;

    public TMP_Text health;
    public TMP_Text score;

    private void Awake()
    {
        instance = this;
    }
}
