using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Каждое дерево имеет в себе 50 единиц древесины.
/// </summary>
public class Tree : MonoBehaviour
{
    public int treeHaving = 50;

    public int Chop(int personChopPower)
    {
        if (treeHaving >= personChopPower)
        {
            treeHaving -= personChopPower;
            if (treeHaving == 0)
            {
                gameObject.SetActive(false); // Destroy более затратная операция, чем обычное выключение объекта
            }
            return personChopPower;
        }
        else
        {
            return 0;
        }
    }
}
