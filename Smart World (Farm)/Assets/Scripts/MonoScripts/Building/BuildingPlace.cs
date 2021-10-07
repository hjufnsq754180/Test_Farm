using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlace : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private Building _building;
    [SerializeField] private GameObject _mesh;

    private BuildCount _buildCount;
    private CurrencySystem _currencySystem;
    private Currency _currency;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _buildCount = GetComponent<BuildCount>();

        _currencySystem = FindObjectOfType<CurrencySystem>();
        _currency = FindObjectOfType<Currency>();
    }

    public void PlacingMesh(GameObject mesh)
    {
        if (_mesh != null)
        {
            Destroy(_mesh);
        }

        _mesh = Instantiate(mesh);
    }

    public void PlacingBuild(Building buildingPref)
    {
        _building = buildingPref;
    }

    public void CancelBuilding()
    {
        Destroy(_mesh);
        _building = null;
    }

    private void Update()
    {
        if (_mesh != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                _mesh.transform.position = worldPosition;
            }

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && _currency.Tree >= _building.buildingObj.price)
            {
                _currencySystem.RemoveTree(_building.buildingObj.price);
                Vector3 meshPos = new Vector3(_mesh.transform.position.x, _mesh.transform.position.y, _mesh.transform.position.z);
                Instantiate(_building, meshPos, Quaternion.identity);
                _buildCount.AddBuilding(_building);
                Destroy(_mesh);
            }
        }
    }
}
