using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace felixro
{   
    public class Weight : IComparable<Weight>
    {
        private int weight;
        private Cube cube;

        public Weight(int weight, Cube cube)
        {
            this.weight = weight;
            this.cube = cube;
        }
            
        public int GetWeight()
        {
            return weight;
        }

        public Cube GetCube()
        {
            return cube;
        }

        public void SetWeight(int weight)
        {
            this.weight = weight;
        }

        public int CompareTo(Weight obj) 
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            };

            int otherWeight = ((Weight)obj).GetWeight();

            if (weight == otherWeight)
            {
                return 0;
            }

            if (weight > otherWeight)
            {
                return 1;
            }

            return -1;
        }
    }
}
