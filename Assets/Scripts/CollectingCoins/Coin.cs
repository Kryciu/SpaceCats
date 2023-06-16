using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool isSpawn = false;
    public AnimationCurve AnimationCurve;
    public float speed = 80;
    public Rigidbody _rb;

    IEnumerator unSpawn()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(1f, 2f)
            .SetRelative(true)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(AnimationCurve);
        transform.DORotate(new Vector3(0, 360, 0), 2.5f, RotateMode.LocalAxisAdd).SetLoops(-1);
        if (isSpawn == true)
        {
            StartCoroutine(unSpawn());
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        _rb.velocity = new Vector3(0, 0, speed * -1);
    }
}
