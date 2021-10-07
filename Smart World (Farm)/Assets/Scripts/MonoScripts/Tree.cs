using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ������ ����� � ���� 50 ������ ���������.
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
                gameObject.SetActive(false); // Destroy ����� ��������� ��������, ��� ������� ���������� �������
            }
            return personChopPower;
        }
        else
        {
            return 0;
        }
    }
}
