using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;

public class WsClient : MonoBehaviour
{
    WebSocket ws;
     public InputField mainInputField;

    private void Start()
    {
        ws = new WebSocket("ws://localhost:4000/api/stream?name=sdf&code=TftpZf");
        //ws = new WebSocket("http://localhost:4000/api/state");
        
        ws.Connect();
        ws.OnMessage += (sender, e) => {
            Debug.Log("Message Received from "+((WebSocket)sender).Url+", Data : "+e.Data);
        };
    }

    private void SubmitName(string arg0) {
         Debug.Log(arg0);
     }

    private void Update(){
        //if (Input.GetKeyUp(KeyCode.Return)) { TapYourSubmitFunction(); }

        if(ws == null) {
            return;
        }
 
        if (Input.GetKeyDown(KeyCode.Space)){
            ws.Send("Hello");
            Debug.Log("Yeah");
        }  
    }
}