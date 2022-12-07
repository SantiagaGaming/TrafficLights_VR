using AosSdk.Core.PlayerModule;
using AosSdk.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangableGrabbableLamp : GrabbableObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out LampPosition pos))
        {
            OnUnGrabbed(pos.NewLampPosition());
            Player.Instance.DropObject(0);
        }
    }
}
