using System;
using DoubTech.ScriptableEvents.Integrations.Photon.Events.BuiltinTypes;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Integrations.Photon.Listeners.BuiltinTypes
{
    [Serializable]
    public class
        PhotonStringGameEventListener : GameEventListener<int, string, PhotonStringGameEvent,
            PhotonStringWithActorUnityGameEvent>
    {
        [SerializeField] private PhotonStringGameEvent gameEvent;

        [Header("Filters")]
        [SerializeField] public bool checkActorNumber;
        [SerializeField] public int actorNumberFilter = 0;
        [SerializeField] public bool isMine = false;
        [SerializeField] public PhotonView owner;

        [SerializeField]
        private PhotonStringUnityGameEvent onEventWithoutActor = new PhotonStringUnityGameEvent();

        [SerializeField]
        private PhotonStringWithActorUnityGameEvent onEventWithActor = new
            PhotonStringWithActorUnityGameEvent();

        public override PhotonStringGameEvent GameEvent => gameEvent;
        public PhotonStringUnityGameEvent OnEventWithoutActor => onEventWithoutActor;
        public override PhotonStringWithActorUnityGameEvent OnEvent => onEventWithActor;

        public override void OnEventRaised(int actor, string text)
        {
#if PUN_2_OR_NEWER
            if (owner)
            {
                if (owner.OwnerActorNr == actor)
                {
                    base.OnEventRaised(actor, text);
                    onEventWithoutActor.Invoke(text);
                }
            }
            else if (isMine)
            {
                if (actor == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    base.OnEventRaised(actor, text);
                    onEventWithoutActor.Invoke(text);
                }
            }
            else if (!checkActorNumber || actor == actorNumberFilter)
            {
#endif
                base.OnEventRaised(actor, text);
                onEventWithoutActor.Invoke(text);
#if PUN_2_OR_NEWER
            }
#endif
        }

        public void Invoke(string text)
        {
            Invoke(PhotonNetwork.LocalPlayer.ActorNumber, text);
        }

        public override void Invoke(int actor, string text)
        {
#if PUN_2_OR_NEWER
            if (owner)
            {
                if (owner.OwnerActorNr == actor)
                {
                    base.Invoke(actor, text);
                }
            }
            else if (isMine)
            {
                if (actor == PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    base.Invoke(actor, text);
                }
            }
            else if (!checkActorNumber || actor == actorNumberFilter)
            {
#endif
                base.Invoke(actor, text);
#if PUN_2_OR_NEWER
            }
#endif
        }

        public void ClearActorFilter()
        {
            checkActorNumber = false;
        }

        public void SetActorFilter(int actor)
        {
            checkActorNumber = true;
            actorNumberFilter = actor;
        }
    }

    [Serializable]
    public class PhotonStringWithActorUnityGameEvent : UnityEvent<int, string>
    {
    }

    [Serializable]
    public class PhotonStringUnityGameEvent : UnityEvent<string>
    {
    }
}
