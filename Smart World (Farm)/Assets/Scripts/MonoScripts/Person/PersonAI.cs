using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PersonAI : MonoBehaviour
{
    public Tree currentTree;
    public float speedWalk = 3;
    public bool canChop = false;
    public bool isChopCor = false;
    public int personChopPower;

    private TreeList _treeList;
    private CurrencySystem _currencySystem;
    private Currency _currency;

    private void Start()
    {
        personChopPower = 5;
        _treeList = FindObjectOfType<TreeList>();
        //Разделять хранение валюты и операции над ней, чтоб потом получать ссылку и на то и на то, уверен что плохая это идея)
        _currencySystem = FindObjectOfType<CurrencySystem>();
        _currency = FindObjectOfType<Currency>();

        if (currentTree == null)
        {
            currentTree = _treeList.trees.OrderBy(x => Vector3.Distance(gameObject.transform.position, x.transform.position)).FirstOrDefault();
        }
    }

    private void FixedUpdate()
    {
        if (currentTree != null && _currency.Tree < _currency.MaxTree)
        {
            gameObject.transform.LookAt(new Vector3(currentTree.transform.position.x, transform.position.y, currentTree.transform.position.z));
            if (Vector3.Distance(gameObject.transform.position, currentTree.transform.position) >= 2)
            {
                transform.Translate(Vector3.forward * Time.fixedDeltaTime * speedWalk);
            }
            else
            {
                canChop = true;
                if (!isChopCor && canChop)
                {
                    StartCoroutine("ChopCoroutine");
                    isChopCor = true;
                }
            }
            if (currentTree.gameObject.activeSelf == false)
            {
                _treeList.trees.Remove(currentTree);
                canChop = false;
                isChopCor = false;
                StopCoroutine("ChopCoroutine");
                currentTree = _treeList.trees.OrderBy(x => Vector3.Distance(gameObject.transform.position, x.transform.position)).FirstOrDefault();
            }
        }
    }

    IEnumerator ChopCoroutine()
    {
        while (_currency.Tree < _currency.MaxTree)
        {
            yield return new WaitForSeconds(1f);
            _currencySystem.AddTree(currentTree.Chop(personChopPower));
        }
    }

    //Просто удобно отслеживать направление персонажа
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 dir = transform.TransformDirection(Vector3.forward) * 10f;
        Gizmos.DrawRay(gameObject.transform.position, dir);
    }
}
