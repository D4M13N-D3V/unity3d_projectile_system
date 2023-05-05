using Damien.ProjectileSystem.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Damien.ProjectileSystem
{
    [AddComponentMenu("Damien/Projectile System/Agent")]
    public class ProjectileAgent : MonoBehaviour
    {
        [SerializeField] internal ProjectileAgentBehaviour AgentBehaviour;

        public Transform ProjectileSpawnPoint;

        private int currentHandlerIndex = 0;

        private void Start()
        {
        }

        private void Update()
        {
        }


        public void CreateProjectile()
        {
            ProjectileHandlerBehaviour handler = null;
            if (AgentBehaviour.HandlerUseWeights)
                handler = AgentBehaviour.GetNextHandlerByWeights();
            else if (AgentBehaviour.HandlerUseOrder)
                handler = AgentBehaviour.GetNextHandlerByOrder(ref currentHandlerIndex);
            else
                throw new System.Exception("Weights or Order must be enabled.");

            if (handler==null)
                throw new System.Exception($"No projectile handlers are configured for the projectile agent {AgentBehaviour.Name}.");
        

            var obj = new GameObject("Projectile");
            obj.transform.parent = ProjectileSpawnPoint;
            obj.transform.localPosition = new Vector3(0, 0, 0);
            obj.transform.localEulerAngles = new Vector3(0, 0, 0);
            obj.AddComponent<ProjectileHandler>();
            obj.GetComponent<ProjectileHandler>().Behaviour = handler;
            obj.transform.parent = null;
        }
    }
}
