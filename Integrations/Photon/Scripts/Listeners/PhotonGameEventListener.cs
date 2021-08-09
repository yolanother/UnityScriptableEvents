using System;
using DoubTech.ScriptableEvents.Integrations.Photon.Events.BuiltinTypes;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Integrations.Photon.Listeners.BuiltinTypes
{
    [Serializable]
    public class
        PhotonGameEventListener : GameEventListener<int, PhotonGameEvent, PhotonUnityGameEvent>
    {
        [SerializeField] private PhotonGameEvent gameEvent;

        [Header("Filters")]
        [SerializeField] public bool checkActorNumber;
        [SerializeField] public int actorNumberFilter = 0;
        [SerializeField] public bool isMine;

        [SerializeField] public PhotonView owner;

        [SerializeField] private PhotonUnityGameEvent onEvent = new PhotonUnityGameEvent();

        public override PhotonGameEvent GameEvent => gameEvent;
        public override PhotonUnityGameEvent OnEvent => onEvent;

        public override void OnEventRaised(int actor)
        {
#if PUN_2_OR_NEWER
            if (owner)
            {
                if (owner.OwnerActorNr == actor)
                {
                    base.OnEventRaised(actor);
                }
            }
            else if (isMine)
            {
                if (actor == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    base.OnEventRaised(actor);
                }
            }
            else if (!checkActorNumber || actor == actorNumberFilter)
            {
#endif
                base.OnEventRaised(actor);
#if PUN_2_OR_NEWER
            }
#endif
        }

        public override void Invoke(int actor)
        {
#if PUN_2_OR_NEWER
            if (owner)
            {
                if (owner.OwnerActorNr == actor)
                {
                    base.Invoke(actor);
                }
            }
            else if (isMine)
            {
                if (actor == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    base.Invoke(actor);
                }
            }
            else if (!checkActorNumber || actor == actorNumberFilter)
            {
#endif
                base.Invoke(actor);
#if PUN_2_OR_NEWER
            }
#endif
        }

        public void ClearActorFilter()
        {
            actorNumberFilter = -1;
        }

        public void SetActorFilter(int actor)
        {
            actorNumberFilter = actor;
        }
    }

    [Serializable]
    public class PhotonUnityGameEvent : UnityEvent<int>
    {
    }
}
