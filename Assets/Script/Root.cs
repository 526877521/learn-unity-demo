using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using Login;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Script.FGui.Utils;
using UnityEngine;
using Object = System.Object;

public class Root : MonoBehaviour
{
    // Start is called before the first frame update
   async void Start()
    {
        fguiBindAndLoad();
        UI_Main my_view = UI_Main.CreateInstance();
        GRoot.inst.AddChild(my_view);
        my_view.m_login_btn.onClick.Add(async ()  =>
        {
            Debug.Log("点击登录按钮");
            my_view.m_des_tip.text = "玩家点击了登录按钮";
            //todo 发送请求，调取后端数据
           var usr= JsonConvert.SerializeObject("{name: 'zs', age: 18}");
           Debug.Log(usr);
            // Newtonsoft.Json.Linq.JObject.FromObject(new { Id = 1, Num = 99, Name = "gas" });
            // var result = await HttpMgr.getInstance().httpGet("api/parse/result");
            // Dictionary<string,Object > dic1= JsonUnity.DeserializeStringToDictionary<string,Object>(result);
            // // string str = JsonUnity.SerializeDictionaryToJsonString();
            // Dictionary<string,Object > dic2= JsonUnity.DeserializeStringToDictionary<string,Object>(str);
            //
            //  Debug.Log(dic1["buildingList"]);
        });
    }

    void fguiBindAndLoad()
    {
        LoginBinder.BindAll();
        UIPackage.AddPackage("UI/login");
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