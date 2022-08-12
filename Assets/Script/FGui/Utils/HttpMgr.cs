using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Script.FGui.Utils
{
    public class HttpMgr : MonoBehaviour
    {
        private static string _httpHost = "https://ns-test-api.m3passport.io/";
        private static HttpMgr _instance = null;

        public static HttpMgr getInstance()
        {
            if (HttpMgr._instance == null)
            {
                return new HttpMgr();
            }
            return HttpMgr._instance;
        }
        //发送get请求 特制网络请求
        public async Task<string> httpGet(string url)
        {

            UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);
            // return "1312313";
            var request = UnityWebRequest.Get(_httpHost + url);
            await request.SendWebRequest();
            // UnityWebRequest.Result result = await request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
                return request.error;
            }
            else
            {
                Debug.Log("加载成功");
            }
            
            return request.downloadHandler.text;
        }
        
        
    }
}