using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace Prototype.NetworkLobby
{


    public class PlayerNameInput : NetworkBehaviour
    {
        public InputField nameField;

        [SyncVar]
        public string pName;

        private void Awake()
        {
            pName = PlayerPrefs.GetString("name");
            nameField.text = pName;
        }
        public void changeName()
        {
            pName = nameField.text;
            PlayerPrefs.SetString("name", pName);
            PlayerPrefs.Save();
        }

    }
}
