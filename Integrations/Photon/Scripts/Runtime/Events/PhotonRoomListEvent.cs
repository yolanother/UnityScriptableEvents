using System;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

namespace DoubTech.ScriptableEvents.Integrations.Photon.Events.BuiltinTypes
{
#if PUN_2_OR_NEWER
    [CreateAssetMenu(fileName = "PhotonRoomListGameEvent",
        menuName = "DoubTech/Game Events/Photon/Built In Types/Photon Room List Event")]
    [Serializable]
    public class PhotonRoomListEvent : GameEvent<List<RoomInfo>>
    {

    }
#endif
}