using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronAnimation: AnimationObject
{
    private Vector3 _openPosition = new Vector3(0, -0.023f, 0.0477f);
    private bool _closed = true;
    public override void PlayAnimation()
    {
        StartCoroutine(PlayScriptableAnimation());
    }
    private IEnumerator PlayScriptableAnimation()
    {
        GetComponent<Collider>().enabled = false;
        if(_closed)
        {
            int z = 0;
            while (z>=-20)
            {
                transform.localRotation = Quaternion.Euler(0, 0, z);
                yield return new WaitForSeconds(0.01f);
                z--;
            }
            transform.localRotation = Quaternion.Euler(60, 0, z);
            transform.localPosition += _openPosition;
            _closed = false;
        }
        else if(!_closed)
        {
            int z = -20;
            transform.localRotation = Quaternion.Euler(0, 0, z);
            transform.localPosition -= _openPosition;
            while (z <= 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, z);
                yield return new WaitForSeconds(0.01f);
                z++;
            }
            _closed = true;
        }
        GetComponent<Collider>().enabled = true;

    }
}
