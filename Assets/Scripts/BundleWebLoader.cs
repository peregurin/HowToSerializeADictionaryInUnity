using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class BundleWebLoader : MonoBehaviour
{
    public string bundleUrl = "https://drive.google.com/uc?export=download&id=12VjWlIRiSpT4bakK3X-oh-iuEMzb_1vL";
    public string assetName = "BundledObject";

    IEnumerator Start()
    {
        using (UnityWebRequest web = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl))
        {
            yield return web.SendWebRequest();
            if (web.isNetworkError || web.isHttpError)
            {
                Debug.Log(web.error);
            }
            else
            {
                AssetBundle remoteAssetBundle = DownloadHandlerAssetBundle.GetContent(web);
                if (remoteAssetBundle == null)
                {
                    Debug.LogError("Failed to download AssetBundle!");
                    yield break;
                }
                Instantiate(remoteAssetBundle.LoadAsset(assetName));
                remoteAssetBundle.Unload(false);
            }          
        }
    }
}
