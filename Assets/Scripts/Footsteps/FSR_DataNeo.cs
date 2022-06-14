using UnityEngine;

namespace FSR
{
    [CreateAssetMenu]
    public class FSR_DataNeo : ScriptableObject
    {


        public SurfaceType[] surfaces;
         

        [System.Serializable]
        public class SurfaceType
        {
            public string name;
            public AudioClip[] soundEffects;
        }
    }
}
