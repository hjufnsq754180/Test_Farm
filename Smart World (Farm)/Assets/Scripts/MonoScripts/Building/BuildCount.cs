using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ������� ����� ���� ������ �����, ���� � ��� ���� ������ ���� ������, 
/// �������� ��������� �� 100 � �� 150 (������ Scriptable Object).
/// </summary>
public class BuildCount : MonoBehaviour
{
    [SerializeField] private List<SO.House> _houses;
    [SerializeField] private List<SO.Storage> _storages;
    [SerializeField] private Building[] _buildings;

    private void Awake()
    {
        _buildings = FindObjectsOfType<Building>();

        FindHouses();
        FindStorages();

    }

    private void SetMaxTree()
    {
        Currency currency = FindObjectOfType<Currency>();
        int sumMaxTree = 0;
        if (currency != null)
        {
            foreach (var item in _storages)
            {
                sumMaxTree += item.woodCount;
            }
            currency.MaxTree = sumMaxTree;
        }
    }

    //��� ������� ����� �� ����� ������ � ��������� �������� � ����� ������. ��� ���������� �������� �� ����� ��� ����� �������.
    //P.S. �������� ��� ���������� ������, � ������� ���-�� ������������� ��, ����������� ��� ������ ���������� ���, �� �� ����������.
    public void FindHouses()
    {
        foreach (var house in _buildings)
        {
            if (house.GetComponent<Building>().buildingObj is SO.House)
            {
                _houses.Add(house.buildingObj as SO.House);
            }
        }
        SetMaxTree();
    }

    public void FindStorages()
    {
        foreach (var storage in _buildings)
        {
            if (storage.GetComponent<Building>().buildingObj is SO.Storage)
            {
                _storages.Add(storage.buildingObj as SO.Storage);
            }
        }
        SetMaxTree();
    }

    // ����� �� if-��
    public void AddBuilding(Building build)
    {
        if (build.GetComponent<Building>().buildingObj is SO.Storage)
        {
            _storages.Add(build.buildingObj as SO.Storage);
        }
        else if (build.GetComponent<Building>().buildingObj is SO.House)
        {
            _houses.Add(build.buildingObj as SO.House);
        }

        SetMaxTree();
    }
}
