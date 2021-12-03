using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaphneGALibrary
{
    public enum BinaryCrossoverOpeartor
    {
        OnePointCut, TwoPointCut, NPointCut
    }

    public class BinaryGA : GenericGASolver<byte>
    {
        // extra properties
        int[] poss; //this part of memory is defined within BinaryGA

        [Category("Binary Encoded GA"), Description("The crossover operator of a binary-encoded GA solver. ")]
        public BinaryCrossoverOpeartor crossoverOperatorType { set; get; } = BinaryCrossoverOpeartor.OnePointCut;
        /// <summary>
        /// Create a Binary GA Solver
        /// </summary>
        /// <param name="numberOfVariables"></param>
        /// <param name="optimizationType"></param>
        /// <param name="objectiveFunction"> the delegate to the objective function </param>
        public BinaryGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<byte> objectiveFunction,
            Panel hostPanelForGAMonitor) :
            base(numberOfVariables, optimizationType, objectiveFunction, hostPanelForGAMonitor)
        {
            int b = soFarTheBestSolution[0] * 8;
            poss = new int[numberOfVariables];
        }

        public override void InitializePopultaion()
        {
            for (int r = 0; r < populationSize; r++)
            {
                for (int c = 0; c < numberOfGenes; c++)
                    chromosomes[r][c] = (byte)randomizer.Next(2);
                objectives[r] = objectiveFunction(chromosomes[r]);
            }

        }
        /// <summary>
        /// define crossover operator type
        /// </summary>
        /// <param name="father"></param>
        /// <param name="mother"></param>
        /// <param name="child1"></param>
        /// <param name="child2"></param>
        public override void CrossoverAPairParent(int father, int mother, int child1, int child2)
        {
            switch (crossoverOperatorType) 
            {
                case BinaryCrossoverOpeartor.OnePointCut:
                    int cutPos = randomizer.Next(numberOfGenes);  // random generate a  cut position
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (i < cutPos)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[mother][i];
                            chromosomes[child2][i] = chromosomes[father][i];
                        }
                    }
                    break;

                case BinaryCrossoverOpeartor.TwoPointCut:
                    int cutPos1 = randomizer.Next(numberOfGenes);   // cut position 1
                    int cutPos2 = randomizer.Next(numberOfGenes);  // cut position 2
                    /*for(int i = 0; i < numberOfGenes; i++)
                    {
                        if(cutPos1 < cutPos2)
                        {
                            if (i< cutPos1 || i > cutPos2)
                            {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                            }
                            else if(i > cutPos1 && i < cutPos2)
                            {
                                chromosomes[child1][i] = chromosomes[mother][i];
                                chromosomes[child2][i] = chromosomes[father][i];
                            }
                        }
                        else if(cutPos2 < cutPos1)
                        {
                            if (i < cutPos2 || i > cutPos1)
                            {
                                chromosomes[child1][i] = chromosomes[father][i];
                                chromosomes[child2][i] = chromosomes[mother][i];
                            }
                            else if (i > cutPos2 && i < cutPos1)
                            {
                                chromosomes[child1][i] = chromosomes[mother][i];
                                chromosomes[child2][i] = chromosomes[father][i];
                            }
                        }
                    }*/
                    Boolean cutChange = false;
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if(i == cutPos1 || i == cutPos2)
                            cutChange = !cutChange;
                        if(cutChange == true)
                        {
                            chromosomes[child1][i] = chromosomes[father][i];
                            chromosomes[child2][i] = chromosomes[mother][i];
                        }
                        else
                        {
                            chromosomes[child1][i] = chromosomes[mother][i];
                            chromosomes[child2][i] = chromosomes[father][i];
                        }
                    }
                    break;

                case BinaryCrossoverOpeartor.NPointCut:
                    int n = 1 + randomizer.Next(numberOfGenes / 2);
                    // int[] cutPos = new int[n]; // don't do the new
                    for(int i = 0; i < n; i++)
                    {
                        poss[i] = randomizer.Next(numberOfGenes);
                    }
                    Array.Sort(poss, 0, n); //to n-1
                    // do the gene assignments

                    break;
            }
        }

        public override void MutateAParent(int parentId, int childId, bool[] mutatedFlag)
        {
            for(int i = 0; i < numberOfGenes; i++)
            {
                if (mutatedFlag[i])
                {
                    if (chromosomes[parentId][i] == 1) chromosomes[childId][i] = 0;
                    else chromosomes[childId][i] = 1;
                }
                else
                    chromosomes[childId][i] = chromosomes[parentId][i];
            }
        }
    }
}
