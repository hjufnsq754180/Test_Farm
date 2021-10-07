using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ѕо большей части этот скрипт нужен, если у нас есть разные тиры зданий, 
/// например хранилище на 100 и на 150 (разные Scriptable Object).
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

    //ѕри запуске сцены мы будем искать и добавл€ть строени€ в общий список. ѕри сохранении построек на сцене это будет полезно.
    //P.S. —транные два одинаковых метода, € пыталс€ как-то унифицировать их, перегрузкой или просто передавать тип, но не получилось.
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

    // ћусор из if-ов
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
