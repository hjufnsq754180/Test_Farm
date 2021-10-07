using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��� ��� �� ��� ��������, �� � ���� ����� ����� �������� ��� ����������� �����, ������� ��������� �� Building
/// � ��������� ����� ���������.
/// </summary>
namespace SO 
{
    [CreateAssetMenu(fileName = "House")]
    public class House : BuildingObj
    {
        public int personCount;
    }
}
