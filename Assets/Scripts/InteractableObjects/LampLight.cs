using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
    [SerializeField] private Material _onMaterial;
    [SerializeField] private Material _offMaterial;
    private Material _currentMaterial;
    private void Start()
    {
      _currentMaterial= GetComponent<Material>();
    }
    public void EnableLight(bool value)
    {
        if (_currentMaterial == null)
            return;
            if (value)
            _currentMaterial = _onMaterial;
            else _currentMaterial = _offMaterial;
    }
}
