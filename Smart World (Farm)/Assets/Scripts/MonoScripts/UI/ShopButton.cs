using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    private bool isShow = false;
    public void ShowBuildingPanel(GameObject bPanel)
    {
        if (isShow)
        {
            bPanel.SetActive(false);
            isShow = false;
        }
        else
        {
            bPanel.SetActive(true);
            isShow = true;
        }
    }
}
