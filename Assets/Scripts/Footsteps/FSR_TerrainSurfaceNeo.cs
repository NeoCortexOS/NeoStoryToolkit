using System;
using UnityEngine;


namespace FSR
{
    public class FSR_TerrainSurfaceNeo : MonoBehaviour
    {

        private IndexTerrainNeo indexTerrain = new IndexTerrainNeo();
        [SerializeField] private FSR_DataNeo data;



        public String GetSurface(Vector3 playerPosition)
        {
            
                    String terrain = transform.gameObject.GetComponent<Terrain>().ToString();

                    String[] surfaceName = indexTerrain.GetMainTextureName(playerPosition).Split('_');

                    bool mismatch = true;

                    foreach (FSR_DataNeo.SurfaceType surface in data.surfaces)
                    {

                        if (surface.name.Equals(surfaceName[1]))
                        {
                            mismatch = false;
                        }
                    }


                    if (!mismatch)
                    {
                        return surfaceName[1];
                    }
                    else
                    {
                        throw new UnityException("looks like you have mismatching surfaces names, make sure all the surfaces components have the same name specified in the FSR data");
                    }


            

        }
    }
}