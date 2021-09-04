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
        public virtual void OnEnable() {}
        public virtual void OnDisable() {}
#endif

#if PUN_2_OR_NEWER
        [PunRPC]
#endif
        public void OnPostEvent(string eventType)
        {
            gameEventSet[eventType].Invoke();
        }

#if PUN_2_OR_NEWER
        [PunRPC]
#endif
        public void OnPostEventT(string eventType, byte[] data)
        {
            gameEventSet[eventType].Invoke(Deserialize(data));
        }

#if PUN_2_OR_NEWER
        [PunRPC]
#endif
        public void OnPostEventT1T2(string eventType, byte[] data, byte[] data2)
        {
            gameEventSet[eventType].Invoke(Deserialize(data), Deserialize(data2));
        }

        public void PostEvent<T>(GameEvent<T> e, T data)
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
            else
            {
                OnPostEventT(e.name, Serialize(data));
            }
#else
            OnPostEventT(e.name, Serialize(data));
#endif
        }

        public void PostEvent<T1, T2>(GameEvent<T1, T2> e, T1 data, T2 data2)
        {
#if PUN_2_OR_NEWER
            if (PhotonNetwork.IsConnected)
            {
                PhotonView.Get(this).RPC(
                    "OnPostEventT1T2",
                    RpcTarget.All,
                    e.name,
                    Serialize(data),
                    Serialize(data2));
            }
            else
            {
                OnPostEventT1T2(e.name, Serialize(data), Serialize(data2));
            }
#else
            OnPostEventT1T2(e.name, Serialize(data));
#endif
        }

        public void PostEvent(GameEvent e)
        {
#if PUN_2_OR_NEWER
            if (PhotonNetwork.IsConnected)
            {
                PhotonView.Get(this).RPC("OnPostEvent", RpcTarget.All, e.name);
            }
            else
            {
                OnPostEvent(e.name);
            }
#else
            OnPostEvent(e.name);
#endif
        }

        public void PostEvent(string e)
        {
#if PUN_2_OR_NEWER
            if (PhotonNetwork.IsConnected)
            {
                PhotonView.Get(this).RPC("OnPostEvent", RpcTarget.All, e);
            }
            else
            {
                OnPostEvent(e);
            }
#else
            OnPostEvent(e);
#endif
        }

        public void PostEvent(string e, object data)
        {
#if PUN_2_OR_NEWER
            if (PhotonNetwork.IsConnected)
            {
                PhotonView.Get(this).RPC(
                    "OnPostEventT",
                    RpcTarget.All,
                    e,
                    Serialize(data));
            }
            else
            {
                OnPostEventT(e, Serialize(data));
            }
#else
            OnPostEvent(e);
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
