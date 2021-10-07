using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Currency : MonoBehaviour
{
    [SerializeField] private int _tree = 0;
    [SerializeField] private int _maxTree = 0;
    public int Tree { get => _tree; set => _tree = value; }
    public int MaxTree { get => _maxTree; set => _maxTree = value; }

    
}
