using System;
#if PUN_2_OR_NEWER
using Photon.Pun;
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
        public void Invoke(string text)
        {
#if PUN_2_OR_NEWER
            base.Invoke(PhotonNetwork.LocalPlayer, text);
            #else
            base.Invoke(-1, text);
#endif
        }

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
