using UnityEngine;


namespace FSR
{
    [RequireComponent(typeof(AudioSource))]
    public class FSR_PlayerNeo: MonoBehaviour
    {
        private AudioSource m_AudioSource;
        public Transform footStepSensor;
        public float raycastSize = 10;
        [SerializeField] private FSR_DataNeo data;

        private int steppedFootOld = 0;

        public void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();
            if (footStepSensor == null)
            {
                Debug.Log("unassigned foot ");
            }
        }


        public void Step(int steppedFoot)
        {
            RaycastHit hit;
            if (steppedFoot == steppedFootOld) return;
            if (Physics.Raycast(footStepSensor.position, -footStepSensor.up, out hit, raycastSize))
            {
                steppedFootOld = steppedFoot;
                try {

                   FSR_SimpleSurfaceNeo surface =  hit.transform.GetComponent<FSR_SimpleSurfaceNeo>();
                    foreach (FSR_DataNeo.SurfaceType surfaceData in data.surfaces)
                    {
                        if (surfaceData.name.Equals(surface.GetSurface()))
                        {
                            playSound(surfaceData);
                        }
                    }
                }
                catch
                {
                    try
                    {
                        FSR_TaggedSurfaceNeo surface = hit.transform.GetComponent<FSR_TaggedSurfaceNeo>();
                        foreach (FSR_DataNeo.SurfaceType surfaceData in data.surfaces)
                        {
                            if (surfaceData.name.Equals(surface.GetSurface()))
                            {
                                playSound(surfaceData);
                            }
                        }
                    }
                    catch
                    {
                        try
                        {
                            FSR_TerrainSurfaceNeo surface = hit.transform.GetComponent<FSR_TerrainSurfaceNeo>();
                            foreach (FSR_DataNeo.SurfaceType surfaceData in data.surfaces)
                            {
                                if (surfaceData.name.Equals(surface.GetSurface(transform.position)))
                                {
                                    playSound(surfaceData);
                                }
                            }

                        }
                        catch {

                            foreach (FSR_DataNeo.SurfaceType surfaceData in data.surfaces)
                            {
                                if (surfaceData.name.Equals("GENERIC"))
                                {
                                    playSound(surfaceData);
                                }
                            }

                        }
                    }


                }

            }
        }



        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        private void playSound(FSR_DataNeo.SurfaceType surfaceType)
        {
            // if (m_AudioSource.isPlaying) return;
            AudioClip[] soundEffects= surfaceType.soundEffects;

            int n = Random.Range(1, soundEffects.Length);
            m_AudioSource.clip = soundEffects[n];
            m_AudioSource.PlayOneShot(m_AudioSource.clip);
            // move picked sound to index 0 so it's not picked next time
            soundEffects[n] = soundEffects[0];
            soundEffects[0] = m_AudioSource.clip;
        }



    }
}
