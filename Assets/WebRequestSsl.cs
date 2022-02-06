using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestSsl : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WebRequest());
    }

    private IEnumerator WebRequest()
    {
        var unityWebRequest = new UnityWebRequest(
            $"https://coms.azurewebsites.net/SystemAdministration/Login",
            UnityWebRequest.kHttpVerbGET);
        unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
        // Uncomment this line to test with a custom certificate handler
        // unityWebRequest.certificateHandler = new AcceptAllCertificateHanlder();

        yield return unityWebRequest.SendWebRequest();

        var error = unityWebRequest.error;
        // Catch a breakpoint on the line below to inspect the error on device
        // Regardless of whether the certificate handler is uncommented or not, it will say 'SSL CA certificate error'
        var response = unityWebRequest;
    }
}

public class AcceptAllCertificateHanlder : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}