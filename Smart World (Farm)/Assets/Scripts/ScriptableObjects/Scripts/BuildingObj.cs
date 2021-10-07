using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// В данном случае я выделил что-то общее у всех объектов, дале у других типов строений будут свои особенности.
/// </summary>
namespace SO
{
    public class BuildingObj : ScriptableObject
    {
        public GameObject gameObject;
        public int price;
    }
}

