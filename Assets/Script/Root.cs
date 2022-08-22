using FairyGUI;
using Login;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Script.FGui.Utils;

public class Root : MonoBehaviour
{
    public  Newtonsoft.Json.Linq.JObject DeserializeString(string jsonStr)
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
            my_view.m_des_tip.text = "hhhhhhhhhhhhh";
            EDItem_Monster monster = EDItem_Monster.GetById(1);
            // ItemManager man = Resources.Load<ItemManager>("DataAssets/Item");
            // Item myItem = man.getItemById(10001);
            Debug.Log(monster.attack + "---" + monster.name + "---" + monster.isBoss);

            //todo 发送请求，调取后端数据
            string account = "0x4398Dd2508F3ed87b0e36DbA343438523cf6BaAc";

            JObject ob = new JObject();
            ob["address"] = account;

            string sendData = JsonConvert.SerializeObject(ob);
            string res_login = await HttpMgr.getInstance().httpPost("api/auth/signIn", sendData);
            
            
            Debug.Log("jsonDict=" + res_login);
            var jsonDict = DeserializeString(res_login);
            string sign = jsonDict["data"].Value<string>("msg");
            string signInfo = jsonDict["data"].Value<string>("msg");
            Debug.Log("====>"+signInfo+"======>><<"+sign);

            
            // var message = res_login["data"].Values<string>("msg");
            // Debug.Log(message);
            // // Debug.Log(usr);
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


    // Update is called once per frame
    void Update()
    {
    }
}