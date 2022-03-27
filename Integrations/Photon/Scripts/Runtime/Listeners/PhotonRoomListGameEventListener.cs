using System;
using System.Collections.Generic;
using DoubTech.ScriptableEvents.Integrations.Photon.Events.BuiltinTypes;
#if PUN_2_OR_NEWER
using Photon.Realtime;
#endif
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Integrations.Photon.Listeners.BuiltinTypes
{
#if PUN_2_OR_NEWER
    [Serializable]
    public class PhotonRoomListGameEventListener : GameEventListener<List<RoomInfo>, PhotonRoomListEvent, PhotonRoomListUnityEvent>
    {
        [SerializeField] private PhotonRoomListEvent gameEvent;
        [SerializeField] private PhotonRoomListUnityEvent onEvent = new PhotonRoomListUnityEvent();

        public override PhotonRoomListEvent GameEvent => gameEvent;
        public override PhotonRoomListUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class PhotonRoomListUnityEvent : UnityEvent<List<RoomInfo>>
    {
    }
#endif
}