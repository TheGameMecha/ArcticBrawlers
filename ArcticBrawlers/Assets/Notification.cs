using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Prototype.NetworkLobby
{


    public class Notification : NetworkBehaviour
    {

        RectTransform content;

        [SyncVar]
        public string msg;
        // Use this for initialization
        void Awake()
        {
            content = GameObject.Find("Content").GetComponent<RectTransform>();
        }
        private void Start()
        {
            this.gameObject.transform.SetAsFirstSibling();
           
        }

       public void message(string msg)
        {
            GetComponentInChildren<Text>().text = msg;
        }

    }
}
