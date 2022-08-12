using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public async Task<string> getHttpGet(string url)
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        return "aaaa";
        // var ret= await httpGet(url);
        // return ret;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
