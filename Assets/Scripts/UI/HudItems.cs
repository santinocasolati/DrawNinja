using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudItems : MonoBehaviour
{
    public static HudItems instance;

    public TMP_Text health;
    public TMP_Text score;
    public TMP_Text bullets;

    private void Start()
    {
        instance = this;

        BulletsManager.instance.bulletsModified += BulletsModifiedHandler;
    }

    private void BulletsModifiedHandler(int amount)
    {
        bullets.text = amount.ToString();
    }
}
