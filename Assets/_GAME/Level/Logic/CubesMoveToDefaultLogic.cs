using UnityEngine;
using DG.Tweening;
using _GAME.Level;

namespace _GAME.Player
{
    public class CubesMoveToDefaultLogic : MonoBehaviour
    {
        private void Awake()
        {
            Features.Level.OnLevelToDefault += CubesToDefaultPosition;

            SetDefaultPositionToCubes();
        }

        private void SetDefaultPositionToCubes()
        {
            for (int i = 0; i < Features.Level.Cubes.Length; i++) 
            {
                Features.Level.Cubes[i].StartPosition = Features.Level.Cubes[i].transform.position;
            }
        }

        private void CubesToDefaultPosition()
        {
            int CubeNumber = 0;
            foreach(CubeRefs cube in Features.Level.Cubes)
            {
                cube.RigidBody.isKinematic = true;
                cube.Collider.enabled = false;

                cube.transform.DOLocalRotate(Vector3.zero, 0.2f).SetDelay(0.03f * CubeNumber);
                cube.transform.DOJump(cube.StartPosition, cube.transform.position.y + 1f, 1, 0.3f).SetDelay(0.03f * CubeNumber)
                .OnComplete(() => 
                {
                    cube.RigidBody.velocity = Vector3.zero;
                    cube.RigidBody.angularVelocity = Vector3.zero;

                    cube.RigidBody.isKinematic = false;
                    cube.Collider.enabled = true;
                }); 

                CubeNumber++;
            }
        }
    }
}
