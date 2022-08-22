using System.Text;
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

        public async Task<string> httpPost(string url, string param)
        {
            //todo 字符串转json 
            var request = new UnityWebRequest(_httpHost + url, "POST");

            byte[] bodyRaw = Encoding.UTF8.GetBytes(param);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); //添加数据
            request.downloadHandler = new DownloadHandlerBuffer(); // 数据Buffer
            request.SetRequestHeader("Content-Type", "application/json"); // 请求头设置
            await request.SendWebRequest();
            Debug.Log("Status Code: " + request.result);
            // UnityWebRequest.Result result = await request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("error" + request.error);
                return request.error;
            }
            else
            {
                 Debug.Log("加载成功" + request.downloadHandler.text);
            }

            return request.downloadHandler.text;
        }
    }
}