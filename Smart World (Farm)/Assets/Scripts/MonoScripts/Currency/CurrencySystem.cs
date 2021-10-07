using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    [SerializeField] private Currency _currency;
    [SerializeField] private CurrencyUI _currencyUi;

    private void Awake()
    {
        _currency = GetComponent<Currency>();
        _currencyUi = FindObjectOfType<CurrencyUI>();
    }
    //������
    public void AddTree(int treeCount)
    {
        _currency.Tree += treeCount;
        _currencyUi.SetTreeText();


    }
    //�������
    public void RemoveTree(int price)
    {
        if (_currency.Tree >= price)
        {
            _currency.Tree -= price;
            _currencyUi.SetTreeText();
        }
    }
}
