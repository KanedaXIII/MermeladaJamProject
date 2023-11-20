using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoolConfetti : MonoBehaviour
{
    public bool show=false;
    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            StartCoroutine(Unpool());
            show=false;
        }
    }

    IEnumerator Unpool()
    {
        yield return new WaitForSeconds(2f);
        SimplePool.Despawn(this.gameObject);
    }
}
