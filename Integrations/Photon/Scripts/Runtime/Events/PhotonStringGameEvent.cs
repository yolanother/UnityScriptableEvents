using System;
#if PUN_2_OR_NEWER
using Photon.Pun;
using Photon.Realtime;
#endif
using UnityEngine;

namespace DoubTech.ScriptableEvents.Integrations.Photon.Events.BuiltinTypes
{
#if PUN_2_OR_NEWER
    [CreateAssetMenu(fileName = "PhotonStringGameEvent",
        menuName = "DoubTech/Game Events/Photon/Built In Types/Photon String Event")]
#endif
    [Serializable]
    public class PhotonStringGameEvent : GameEvent<int, string>
    {
        [SerializeField] public bool invokeLocallyIfNotMaster;
        [SerializeField] public bool onlyPostIfMaster;
        [SerializeField] public bool onlyTriggerIfMine;
        [SerializeField] public bool onlyTriggerIfNotMine;

        #if PUN_2_0_OR_NEWER
        private bool IsMine(int actorNumber)
        {
            return (!PhotonNetwork.IsConnected ||
                    actorNumber == PhotonNetwork.LocalPlayer.ActorNumber);
        }

        public override void Invoke(int actorNumber, string message)
        {
            if (onlyTriggerIfMine)
            {
                if (IsMine(actorNumber)) base.Invoke(actorNumber, message);
            }
            else if (onlyTriggerIfNotMine)
            {
                if (!IsMine(actorNumber)) base.Invoke(actorNumber, message);
            }
            else
            {
                base.Invoke(actorNumber, message);
            }
        }
        #endif

        public void Invoke(string text)
        {
#if PUN_2_OR_NEWER
            if (invokeLocallyIfNotMaster)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    NetworkSyncedEventsSingleton.PostEvent(this,
                        PhotonNetwork.LocalPlayer.ActorNumber, text);
                }
                else
                {
                    OnInvoke(PhotonNetwork.LocalPlayer.ActorNumber, text);
                }
            }
            else if (PhotonNetwork.IsMasterClient || !onlyPostIfMaster)
            {
                NetworkSyncedEventsSingleton.PostEvent(this, PhotonNetwork.LocalPlayer.ActorNumber,
                    text);
            }
#else
            base.Invoke(-1, text);
#endif
        }

#if PUN_2_OR_NEWER
        public void InvokeAs(Player player, string message)
        {
            if (invokeLocallyIfNotMaster)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    NetworkSyncedEventsSingleton.PostEvent(this,
                        player.ActorNumber, message);
                }
                else
                {
                    OnInvoke(player.ActorNumber);
                }
            }
            else if (PhotonNetwork.IsMasterClient || !onlyPostIfMaster)
            {
                NetworkSyncedEventsSingleton.PostEvent(this, player.ActorNumber, message);
            }
        }
#endif

        protected override void OnInvoke(object a)
        {
#if PUN_2_OR_NEWER
            base.Invoke(PhotonNetwork.LocalPlayer.ActorNumber, a);
#else
            base.Invoke(-1, a);
#endif
        }
    }
}
