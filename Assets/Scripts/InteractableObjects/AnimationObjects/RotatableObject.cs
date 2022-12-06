using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableObject : AnimationObject
{
    private bool _closed = true;
    public override void PlayAnimation()
    {
        StartCoroutine(PlayScriptableAnimation());
    }
    private IEnumerator PlayScriptableAnimation()
    {
        Collider.enabled = false;
        if (_closed)
        {
            int x = -90;
            while (x >= -180)
            {
                transform.localRotation = Quaternion.Euler(0, x, 0);
                x--;
                yield return new WaitForSeconds(0.01f);
            }
            _closed= false;
        }
        else
        {
            int x = -180;
            while (x <= -90)
            {
                transform.localRotation = Quaternion.Euler(0, x, 0);
                x++;
                yield return new WaitForSeconds(0.01f);
            }
            _closed = true;
        }
        Collider.enabled = true;
    }
}
