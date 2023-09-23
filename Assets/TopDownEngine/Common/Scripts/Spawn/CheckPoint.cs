using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    public struct CheckPointEvent
    {
        public int Order;
        public CheckPointEvent(int order)
        {
            Order = order;
        }

        static CheckPointEvent e;
        public static void Trigger(int order)
        {
            e.Order = order;
            MMEventManager.TriggerEvent(e);
        }
    }

    [AddComponentMenu("TopDown Engine/Spawn/Checkpoint")]
    public class CheckPoint : TopDownMonoBehaviour 
    {
        public Character.FacingDirections FacingDirection = Character.FacingDirections.East;
        public bool ForceAssignation = false;
        public int CheckPointOrder;

        private const string CheckPointOrderKey = "CurrentCheckPointOrder";
        private List<Respawnable> _listeners;

        protected virtual void Awake () 
        {
            _listeners = new List<Respawnable>();
        }

        public virtual void SpawnPlayer(Character player)
        {
            player.RespawnAt(transform, FacingDirection);
            
            foreach(Respawnable listener in _listeners)
            {
                listener.OnPlayerRespawn(this,player);
            }
        }
        
        public virtual void AssignObjectToCheckPoint (Respawnable listener) 
        {
            _listeners.Add(listener);
        }

        protected virtual void OnTriggerEnter2D(Collider2D collider)
        {
            TriggerEnter(collider.gameObject);            
        }

        protected virtual void OnTriggerEnter(Collider collider)
        {
            TriggerEnter(collider.gameObject);
        }

        protected virtual void TriggerEnter(GameObject collider)
        {
            Character character = collider.GetComponent<Character>();

            if (character == null) { return; }
            if (character.CharacterType != Character.CharacterTypes.Player) { return; }
            if (!LevelManager.HasInstance) { return; }
            
            PlayerPrefs.SetInt(CheckPointOrderKey, CheckPointOrder);
            PlayerPrefs.Save();

            LevelManager.Instance.SetCurrentCheckpoint(this);
            CheckPointEvent.Trigger(CheckPointOrder);
        }

        protected virtual void OnDrawGizmos()
        {   
            #if UNITY_EDITOR

            if (!LevelManager.HasInstance)
            {
                return;
            }

            if (LevelManager.Instance.Checkpoints == null)
            {
                return;
            }

            if (LevelManager.Instance.Checkpoints.Count == 0)
            {
                return;
            }

            for (int i=0; i < LevelManager.Instance.Checkpoints.Count; i++)
            {
                if ((i+1) < LevelManager.Instance.Checkpoints.Count)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawLine(LevelManager.Instance.Checkpoints[i].transform.position,LevelManager.Instance.Checkpoints[i+1].transform.position);
                }
            }
            #endif
        }

        public static int GetCurrentCheckpointOrder()
        {
            return PlayerPrefs.GetInt(CheckPointOrderKey, 0);
        }
    }
}
