using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableBolt : AnimationObject
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
            int y = 0;
            while (y <= 75)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y++;
                yield return new WaitForSeconds(0.01f);
            }
            _closed = false;
        }
        else
        {
            int y = 75;
            while (y >= 0)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
            _closed = true;
        }
        Collider.enabled = true;
    }
}
