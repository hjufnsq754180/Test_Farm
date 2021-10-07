using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Дом это всё ещё строение, но у него будут такие атрибута как вместимость людей, поэтому наследуем от Building
/// и добавляем новых атрибутов.
/// </summary>
namespace SO 
{
    [CreateAssetMenu(fileName = "House")]
    public class House : BuildingObj
    {
        public int personCount;
    }
}
