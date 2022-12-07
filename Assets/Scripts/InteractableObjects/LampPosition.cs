using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampPosition : MonoBehaviour
{
    [SerializeField] private Transform _newLampPosition;

    public Transform NewLampPosition() => _newLampPosition;
}
