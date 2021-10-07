using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private Currency _currency;
    [SerializeField] private TextMeshProUGUI _treeCount;

    private void Start()
    {
        _currency = GetComponent<Currency>();
        SetTreeText();
    }

    public void SetTreeText()
    {
        _treeCount.text = _currency.Tree.ToString() + " / " + _currency.MaxTree;
    }
}
