using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableCap : AnimationObject
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
            int x = 0;
            while (x >= -90)
            {
                transform.localRotation = Quaternion.Euler(0, x, 0);
                x--;
                yield return new WaitForSeconds(0.01f);
            }
            _closed= false;
        }
        else
        {
            int x = -90;
            while (x <= 0)
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
