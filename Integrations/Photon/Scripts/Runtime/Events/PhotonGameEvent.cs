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
            NetworkSyncedEventsSingleton.PostEvent(this, player.ActorNumber);
        }
#endif

        public void Invoke()
        {
#if PUN_2_OR_NEWER
            NetworkSyncedEventsSingleton.PostEvent(this, PhotonNetwork.LocalPlayer.ActorNumber);
#else
            base.Invoke(-1);
#endif
        }
    }
}
