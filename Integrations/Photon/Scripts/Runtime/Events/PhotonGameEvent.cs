using System;
#if PUN_2_OR_NEWER
using Photon.Pun;
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
        public void Invoke()
        {
#if PUN_2_OR_NEWER
            base.Invoke(PhotonNetwork.LocalPlayer.ActorNumber);
#else
            base.Invoke(-1);
#endif
        }
    }
}
