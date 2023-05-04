using Damien.ProjectileSystem.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Damien.ProjectileSystem
{
    public class ProjectileAgent : MonoBehaviour
    {
        [SerializeField] internal ProjectileAgentBehaviour AgentBehaviour;
        public Transform ProjectileSpawnPoint;

        private int currentHandlerIndex = 0;

        private void Start()
        {
            StartCoroutine(ShootLoop());
        }

        private void Update()
        {
        }

        private IEnumerator ShootLoop()
        {
            Fire();
            yield return new WaitForSeconds(AgentBehaviour.AttackSpeed);
            StartCoroutine(ShootLoop());
        }

        public void Fire()
        {
            ProjectileHandlerBehaviour handler = null;
            if (AgentBehaviour.HandlerUseWeights)
                handler = GetHandlerByWeights();
            else if (AgentBehaviour.HandlerUseOrder)
                handler = GetHandlerByOrder();
            else
                throw new System.Exception("Weights or Order must be enabled.");

            if (handler==null)
                throw new System.Exception($"No projectile handlers are configured for the projectile agent {AgentBehaviour.Name}.");
        

            var obj = new GameObject();
            obj.transform.parent = ProjectileSpawnPoint;
            obj.transform.localPosition = new Vector3(0, 0, 0);
            obj.transform.localEulerAngles = new Vector3(0, 0, 0);
            obj.AddComponent<ProjectileHandler>();
            obj.GetComponent<ProjectileHandler>().Behaviour = handler;
            obj.transform.parent = null;
        }

        private ProjectileHandlerBehaviour GetHandlerByOrder()
        {
            var result =  AgentBehaviour.Handlers[currentHandlerIndex].Handler;
            currentHandlerIndex++;
            if (currentHandlerIndex >= AgentBehaviour.Handlers.Length)
                currentHandlerIndex = 0;
            return result;
        }

        private ProjectileHandlerBehaviour GetHandlerByWeights()
        {
            ProjectileHandlerBehaviour handler = null;
            var current = 0;
            var weights = AgentBehaviour.Handlers.ToDictionary(x => x.Handler, x => new KeyValuePair<int, int>(current, current += x.Weight));
            var random = Random.Range(0, AgentBehaviour.Handlers.Sum(x => x.Weight));

            foreach (var weight in weights)
            {
                if (weight.Value.Key <= random && weight.Value.Value > random)
                {
                    handler = weight.Key;
                }
            }
            return handler;
        }
    }
}
