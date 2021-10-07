using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeList : MonoBehaviour
{
    public List<Tree> trees = new List<Tree>();
    private Tree[] _treesArray;
    private void Awake()
    {
        _treesArray = GetComponentsInChildren<Tree>();
        foreach (var item in _treesArray)
        {
            trees.Add(item);
        }
    }


}
