using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using Login;
using UnityEngine;
using Newtonsoft.Json;
public class Root : MonoBehaviour
{
    
    public static Newtonsoft.Json.Linq.JObject DeserializeString(string jsonStr)
    {
      
        Newtonsoft.Json.Linq.JObject jsonDict = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(jsonStr);

        return jsonDict;

    }
    // Start is called before the first frame update
    void Start()
    {
        fguiBindAndLoad();
        UI_Main my_view = UI_Main.CreateInstance();
        GRoot.inst.AddChild(my_view);
        my_view.MakeFullScreen();
        my_view.Center();
        my_view.m_des_tip.text = "MMMMMMMMM";
        Debug.Log(my_view.m_des_tip.text);
        my_view.m_login_btn.onClick.Add(async () =>
        {
            Debug.Log("点击登录按钮" + Application.dataPath);
            my_view.m_des_tip.text = "Name";
            

            // ItemManager man = Resources.Load<ItemManager>("DataAssets/Item");
            // Item myItem = man.getItemById(10001);
            // Debug.Log(myItem.itemPrice + "---" + myItem.itemName + "---" + myItem.itemPrice);

            //todo 发送请求，调取后端数据
            // var usr= JsonConvert.SerializeObject("{name: 'zs', age: 18}");
            // Debug.Log(usr);
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
