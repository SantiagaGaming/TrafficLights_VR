using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewDriver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out RotatableScrew screw))
            screw.PlayAnimation();
    }
}
