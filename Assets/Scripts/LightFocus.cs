using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFocus : MonoBehaviour
{
    public float maxRange = 10;
    public float retime = 2;
    float timeStart = 0;
    public float angleVel = 10;
    public Gradient colors;
    float retimeRand = 0;
    Light2D light;
    float startAngle = 0;
    Quaternion oldRot = Quaternion.identity;
    Quaternion rotation=Quaternion.identity;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        light = GetComponent<Light2D>();
        startAngle=transform.rotation.eulerAngles.z;
        oldRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart + retimeRand < Time.time)
        {

            timeStart = Time.time;
            Color color = colors.Evaluate(Random.Range(0, 1.1f));
            light.color = new Color(color.r, color.g, color.b,1);
            color.a = 0.2f;
            spriteRenderer.color= color;
            //light.color = color;
            retimeRand = Random.Range(0, retime);
            oldRot=transform.rotation;
            rotation = Quaternion.Euler(0, 0, startAngle + Random.Range(-maxRange, maxRange));
        }
        RotateTowardsPosition(angleVel);
    }
    protected void RotateTowardsPosition(float angleVelocity)
    {

        
        transform.rotation = Quaternion.Slerp(oldRot, rotation, (Time.time-timeStart)* angleVelocity); ;
        //Debug.Log("rotate: "+rotation);

    }
}
