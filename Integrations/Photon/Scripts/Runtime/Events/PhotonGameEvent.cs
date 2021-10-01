using System;
#if PUN_2_OR_NEWER
using Photon.Pun;
using Photon.Realtime;
#endif
using UnityEngine;

namespace DoubTech.ScriptableEvents.Integrations.Photon.Events.BuiltinTypes
{
#if PUN_2_OR_NEWER
    [CreateAssetMenu(fileName = "PhotonGameEvent",
        menuName = "DoubTech/Game Events/Photon/Built In Types/Photon Event")]
#endif

    [Serializable]
    public class PhotonGameEvent : GameEvent<int>
    {
        [SerializeField] public bool invokeLocallyIfNotMaster;
        [SerializeField] public bool onlyPostIfMaster;

        public void InvokeAs(int actorNumber)
        {
#if PUN_2_OR_NEWER
            NetworkSyncedEventsSingleton.PostEvent(this, actorNumber);
#else
            base.Invoke(actorNumber);
#endif
        }

#if PUN_2_OR_NEWER
        public void InvokeAs(Player player)
        {
            if (invokeLocallyIfNotMaster)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    NetworkSyncedEventsSingleton.PostEvent(this,
                        player.ActorNumber);
                }
                else
                {
                    OnInvoke(player.ActorNumber);
                }
            }
            else if(PhotonNetwork.IsMasterClient || !onlyPostIfMaster)
            {
                NetworkSyncedEventsSingleton.PostEvent(this, player.ActorNumber);
            }
        }
#endif

        public void Invoke()
        {
#if PUN_2_OR_NEWER
            if (invokeLocallyIfNotMaster)
            {
                if (PhotonNetwork.IsMasterClient) {
                    NetworkSyncedEventsSingleton.PostEvent(this,
                        PhotonNetwork.LocalPlayer.ActorNumber);
                }
                else
                {
                    OnInvoke(PhotonNetwork.LocalPlayer.ActorNumber);
                }
            }
            else if (PhotonNetwork.IsMasterClient || !onlyPostIfMaster)
            {
                NetworkSyncedEventsSingleton.PostEvent(this, PhotonNetwork.LocalPlayer.ActorNumber);
            }
#else
            base.Invoke(-1);
#endif
        }
    }
}
