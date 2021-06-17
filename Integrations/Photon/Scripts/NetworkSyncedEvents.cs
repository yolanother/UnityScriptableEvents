#if PUN_2_OR_NEWER
using Photon.Pun;
using UnityEditor;
#endif
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DoubTech.ScriptableEvents.Integrations.Photon
{
    public class NetworkSyncedEvents :
#if PUN_2_OR_NEWER
    MonoBehaviourPunCallbacks
#else
    MonoBehaviour
#endif
    {
        [SerializeField] public GameEventSet gameEventSet;

#if !PUN_2_OR_NEWER
        protected virtual void OnEnable() {}
        protected virtual void OnDisable() {}
#endif

        [PunRPC]
        public void OnPostEvent(string eventType)
        {
            gameEventSet[eventType].Invoke();
        }

        [PunRPC]
        public void OnPostEventT(string eventType, byte[] data)
        {
            gameEventSet[eventType].Invoke(Deserialize(data));
        }

        public void PostEvent<T>(GameEventT<T> e, T data)
        {
#if PUN_2_OR_NEWER
            if (PhotonNetwork.IsConnected)
            {
                PhotonView.Get(this).RPC(
                    "OnPostEventT",
                    RpcTarget.All,
                    e.name,
                    Serialize(data));
            }
#endif
        }

        public void PostEvent(GameEvent e)
        {
#if PUN_2_OR_NEWER
            if (PhotonNetwork.IsConnected)
            {
                PhotonView.Get(this).RPC("OnPostEvent", RpcTarget.All, e.name);
            }
#endif
        }

        public void PostEvent(string e)
        {
#if PUN_2_OR_NEWER
            if (PhotonNetwork.IsConnected)
            {
                PhotonView.Get(this).RPC("OnPostEvent", RpcTarget.All, e);
            }
#endif
        }

        public void PostEvent(string e, object data)
        {
#if PUN_2_OR_NEWER
            if (PhotonNetwork.IsConnected)
            {
                PhotonView.Get(this).RPC(
                    "OnPostEvent",
                    RpcTarget.All,
        e,
                    Serialize(data));
            }
#endif
        }

        public byte[] Serialize(object data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, data);
                return ms.ToArray();
            }
        }

        public static object Deserialize(byte[] bytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(bytes, 0, bytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                return binForm.Deserialize(memStream);
            }
        }
    }
}
