using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableScrew : BaseObject,IAnimationObject
{
    private bool _closed = true;
    public void PlayAnimation()
    {
        Debug.Log("Yeah!");
        StartCoroutine(RoateScrew());
    }

    private IEnumerator RoateScrew()
    {
        GetComponent<Collider>().enabled = false;
        if (_closed)
        {
           
            int z = 0;
            while (z >= -120)
            {
                transform.localRotation = Quaternion.Euler(0, 0, z);
                transform.localPosition += new Vector3(0, 0, 0.0001f);
                z--;
                yield return new WaitForSeconds(0.005f);
            }
            _closed = false;

        }
        else if(!_closed)
        {
            int z = -120;
            while (z <= 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, z);
                transform.localPosition -= new Vector3(0, 0, 0.0001f);
                z++;
                yield return new WaitForSeconds(0.005f);
            }
            _closed = true;

        }
        GetComponent<Collider>().enabled = true;
    }
}
