using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    public Color naturalColor, dissolveColor;
    public Color tempCol;
    public float colorLerpSpeed, powerLerpSpeed, dissolveSpeed;
    public float colorLerpTime, powerLerpTime, dissolveLerpTime;

    public Material mat;
    public Shader shad;

    public bool startDissolve;
    public bool resetDissolve;
    public int loopZoop;

    // Start is called before the first frame update
    void Start()
    {
        mat.SetColor("_RimColor", naturalColor);
        //shad = GetComponent<Shader>();
        //mat = GetComponent<Material>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (startDissolve)
        {
            if(loopZoop == 0)
            {
                colorLerpTime = 0;
                powerLerpTime = 0;
                dissolveLerpTime = 0;
            }
            loopZoop = 1;
            colorLerpTime += Time.deltaTime * colorLerpSpeed;
            powerLerpTime += Time.deltaTime * powerLerpSpeed;
            dissolveLerpTime += Time.deltaTime * dissolveSpeed;
            tempCol = Color.Lerp(naturalColor, dissolveColor, colorLerpTime);
            mat.SetColor("_RimColor", tempCol);
            mat.SetFloat("_RimPower", -powerLerpTime + 8);
            mat.SetFloat("_Solution", dissolveLerpTime);

            //while(tempCol != dissolveColor)
            //{

            //}
            //DissolveObject();
        }
        if(resetDissolve)
        {
            loopZoop = 0;
            startDissolve = false;
            mat.SetColor("_RimColor", naturalColor);
            mat.SetFloat("_RimPower", 8);
            mat.SetFloat("_Solution", 0);
            resetDissolve = false;
        }
    }

    public void DissolveObject()
    {
        //mat.SetColor("_RimColor", Color.Lerp(dissolveColor, mat.color, (colorLerpSpeed * Time.deltaTime)));
        resetDissolve = false;
        startDissolve = true;
        loopZoop = 0;

    }
    public void ResetObject()
    {
        startDissolve = false;
        resetDissolve = true;
    }
}
