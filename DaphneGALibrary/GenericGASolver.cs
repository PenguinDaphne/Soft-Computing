using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DaphneGALibrary
{
    // template class
    public class GenericGASolver <T> // 在Method後面接上泛型類型 <型別參數T> 就可在宣告時，再指定型別
    {
        protected GAMonitor<T> theMonitor = null;
        protected Random randomizer = new Random( );

        [Browsable(false)]
        public T[ ][ ] Chromosomes { get => chromosomes; }
        [Browsable(false)]
        public double CurrentBestObjectiveValue { get => soFarTheBestObjectiveValue; }
        [Browsable(false)]
        public T[] CurrentBestSolution { get => soFarTheBestSolution; }
        [Browsable(false)]
        public Button RestButton
        {
            get
            {
                if (theMonitor == null) return null;
                else return theMonitor.btnReset;
            }
        }
        [Browsable(false)]
        public Button RunOneIterationButton
        {
            get
            {
                if (theMonitor == null) return null;
                else return theMonitor.btnRunOneIteration;
            }
        }
        [Browsable(false)]
        public Button RunToEndButton
        {
            get
            {
                if (theMonitor == null) return null;
                else return theMonitor.btnRunToEnd;
            }
        }

        public event EventHandler AfterInitialization;
        public event EventHandler OneIterationCompleted;
        public event EventHandler SoFarTheBestSolutionUpdated;

        /// <summary>
        /// Fire the AfterInitialization event;
        /// </summary>
        protected void OnAfterInitialization()
        {
            if (AfterInitialization != null) AfterInitialization(this, null);
        }

        protected void OnSoFarTheBestSolutionUpdated()
        {
            if (SoFarTheBestSolutionUpdated != null) SoFarTheBestSolutionUpdated(this, null);
        }

        // data fields
        /// <summary>
        /// chromosomes[ population size ][ number of variables ]  
        /// </summary>
        protected T[][] chromosomes;  // 2-D jagged array, type is byte
        /// <summary>
        /// objective value (may be negative due to problem defined)
        /// </summary>
        protected double[ ] objectives;
        /// <summary>
        /// convert objective value into fitness value, always be positive
        /// </summary>
        protected double[ ] fitnessValues;
        protected T[ ] soFarTheBestSolution;
        protected double soFarTheBestObjectiveValue;
        
        double iterationBestObjective;  //value
        double iterationAverageObjective;  // value

        protected int[ ] indices;
        bool[ ][ ] mutatedGenes;
        protected T[ ][ ] selectedChromosomes;
        protected double[ ] SelectedObjectives;

        protected int numberOfGenes;
        protected OptimizationType optimizationType = OptimizationType.Maximization;
        protected ObjectiveFunction<T> objectiveFunction = null;  // reference type
        protected double leastFitnessFraction = 0.1;

        protected int populationSize = 10;
        protected double crossoverRate = 0.8;
        protected double  mutationRate = 0.05; // Gene number-based; not population size-based
        
        MutationMode mutationType = MutationMode.GeneNumberBased;
        SelectionMode selectionType = SelectionMode.Deterministic;
        int iterationLimit = 200;

        int numberOfCrossoverChildren; // the number is determined by population size & crossover rate 
        int numberOfMutatedChildren;

        // run time data
        int iterationId=0;



        #region Properties

        /// <summary>
        /// User need to specify the number of chromosomes evolved by the GA.
        /// </summary>
        [Category("GA Parameters"), Description("Portion of the parent participating crossover operation. ")]
        public double CrossOverRate
        {
            get => crossoverRate; set
            {
                if (value >= 0 && value <= 1.0) crossoverRate = value;
            } 
        }
        [Category("GA Parameters"), Description("Number of chromosomes employed. ")]
        public int PopulationSize
        {
            get => populationSize;
            set
            {
                if (value > 1)  populationSize = value; 
            }
        }

        [Category("Problem Type"), Description("Optimization type of the problem. ")]
        public OptimizationType OptimizationType { get => optimizationType; set => optimizationType = value; }
        
        [Category("GA Parameters"), Description("Ratio of genes out of the total number of genes in the population to be mutated. ")]
        public double MutationRate { get => mutationRate; set => mutationRate = value; }

        [Category("Stopping condition"), Description("Iteration limit for GA evolution. ")]
        public int IterationLimit { get => iterationLimit; set => iterationLimit = value; }

        [Category("GA Parameters"), Description("Fraction of fitness range assigned for the worst chromosome. ")]
        public double LeastFitnessFraction { get => leastFitnessFraction; set => leastFitnessFraction = value; }

        [Category("Operation Mode"), Description("Gene number based mutation or population size based mutation mode. ")]
        public MutationMode MutationType { get => mutationType; set => mutationType = value; } // not sure
        
        [Category("Operation Mode"), Description("Genetic selection mode setting: deterministic selection selects the best population")]
        public SelectionMode SelectionType { get => selectionType; set => selectionType = value; }

        #endregion

        // constructor

        /// <summary>
        /// Generic GA Solver
        /// </summary>
        /// <param name="numberOfVariables"> number of Variables </param>
        /// <param name="optimizationType"> Max or Min </param>
        /// <param name="objectiveFunction"> zzz </param>
        public GenericGASolver( int numberOfVariables, OptimizationType optimizationType, 
            ObjectiveFunction<T> objectiveFunction, Panel hostPanelForMonitor = null )
        {
            numberOfGenes = numberOfVariables;
            this.optimizationType = optimizationType;
            this.objectiveFunction = objectiveFunction;

            if(hostPanelForMonitor != null)
            {
                // create monitor object and add it to the host panel
                theMonitor = new GAMonitor<T>(this);
                hostPanelForMonitor.Controls.Add(theMonitor);
                theMonitor.Dock = DockStyle.Fill;
                theMonitor.ppgGA.SelectedObject = this;
            }

            // soFarTheBestSolution[0] = soFarTheBestSolution[1] * 8;
            soFarTheBestSolution = new T[numberOfVariables];
        }
        
        public void dgvGenerateProblem()
        {
             int NumOfJobs;
             NumOfJobs = int.Parse(theMonitor. cbNumOfJobs.Text);  // get value from combo box

             Random random = new Random();
            double randomMin = decimal.ToDouble(theMonitor.NumericMin.Value);
            double randomMax = decimal.ToDouble(theMonitor.NumericMax.Value);


            theMonitor.dgvProblem.Rows.Clear();
            theMonitor.dgvProblem.Columns.Clear();


            // adding headers to DGV
            theMonitor.dgvProblem.TopLeftHeaderCell.Value = "Job/Machine";
            for (int i = 1; i<NumOfJobs+1; i++)
            {
                theMonitor.dgvProblem.Columns.Add($"M{i}", $"M{i}");
                theMonitor.dgvProblem.Rows.Add();
                theMonitor.dgvProblem.Rows[i - 1].HeaderCell.Value = $"J{i}";
            }

            // adding random data to DGV
            for (int col = 0; col< theMonitor.dgvProblem.Columns.Count; col++)
            {
                for (int row = 0; row< theMonitor.dgvProblem.Rows.Count; row++)
                {
                    if (col != row)
                    {
                        double randomValue = Math.Round(randomMin + (random.NextDouble() * (randomMax - randomMin)), 3);
                        theMonitor.dgvProblem[col, row].Value = randomValue;
                    }
                    else
                        theMonitor.dgvProblem[col, row].Value = 0;  // zero on diagonal
                }
            }
            theMonitor.dgvProblem.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }
        

        /// <summary>
        /// stochastic haven't done
        /// </summary>
        // Helping functions
        void setFitnessFromObjectives()
        {
            int total = populationSize + numberOfCrossoverChildren + numberOfMutatedChildren;
            for (int i = 0; i < total; i++)
            {
                fitnessValues[i] = objectives[i];  
            }

            double oMin, oMax, b;
            oMin = objectives.Min();
            oMax = objectives.Max();
            b = Math.Max(leastFitnessFraction*(oMax-oMin),Math.Pow(10,-5));

            // objective values to fitness
            switch (optimizationType)
            {
                case OptimizationType.Maximization:
                    for (int i = 0; i < total; i++)
                        fitnessValues[i] = b+ objectives[i]-oMin ;
                    break;
                case OptimizationType.Minimization:
                    for (int i = 0; i < total; i++)
                        fitnessValues[i] = b + oMin - objectives[i] ;
                    break;
            }

            // do the selection
            switch (selectionType)
            {
                case SelectionMode.Deterministic:

                    for (int i = 0; i < total; i++) indices[i] = i; 
                    // sort fitness value from large to small
                    Array.Sort(fitnessValues, indices, 0, total);   // 根據fitness value大小來找到對應index
                    Array.Reverse(indices, 0, total);  // sort完 index代表的fitness value是由小到大，所以要反向(變由大到小)
                    break;

                case SelectionMode.Stochastic:
                    for (int i = 0; i < total; i++) indices[i] = i;

                    double sumFit = 0;
                    double[] acccumulateSumFitness = new double[total];
                    // sum total fitness value & accumulate fitness value
                    for (int i = 0; i < total; i++)
                    {
                        sumFit += fitnessValues[i];
                        acccumulateSumFitness[i] += fitnessValues[i];
                    }
                    double a = randomizer.NextDouble() * sumFit;
                    // decide the selected chromosomes
                    //for (int i = 0; i < total-1; i++)
                    //{
                    //    if(a > acccumulateSumFitness[i] && a < acccumulateSumFitness[i + 1])
                    //    {
                    //       // selectedChromosomes[][] = chromosomes[i+1];
                    //    }
                    //}
                    //-----------------
                    for (int i = 1; i < total; i++)
                    {
                        fitnessValues[i] = fitnessValues[i] + fitnessValues[i - 1];
                    }
                    for(int j = 0; j < indices[populationSize]; j++)
                    {
                        double num = randomizer.NextDouble() * fitnessValues[indices[total]];
                        for(int r = 0; r < indices[total]; r++)
                        {
                            if(fitnessValues[r] > num)
                            {
                                indices[j] = indices[r];
                            }
                            return;
                        }
                    }
                    Array.Sort(fitnessValues, indices, 0, total);
                    Array.Reverse(fitnessValues, 0, total);
                    Array.Reverse(indices, 0, total);
                    break;
            }

            // Gene-wise copy genes from selected parents and children to temporary matrix
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    selectedChromosomes[i][j] = chromosomes[indices[i]][j];
                }
                SelectedObjectives[i] = objectives[indices[i]];
            }
            // Gene-wise copy genes back to our population
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    chromosomes[i][j] = selectedChromosomes[i][j];
                }
                objectives[i] = objectives[indices[i]];
            }
        }

        void ShuffleAnArray(int[ ] array, int limit)
        {     // error here
            for (int i = 0; i < limit; i++) array[i] = i;
            // shuffle indexes for 0 to limit - 1
            //for (int i = limit - 1; i < limit; i--)
            //{
            //    int pos = randomizer.Next(i + 1);
            //    int temp = array[pos];
            //    array[pos] = array[i];
            //    array[i] = temp;
            //}
            for (int i = 0; i < 100; i++)
            {
                int po1 = randomizer.Next(limit);
                int po2 = randomizer.Next(limit);
                // do swap operation
                int temp = array[po1];
                array[po1] = array[po2];
                array[po2] = temp;
            }

        }

        /// <summary>
        ///  Reallocated memory for the GA operations and do the chromosome initialization.
        /// </summary>
        public void Reset( )
        {
            // variable reset
            iterationId = 0;
            if (optimizationType == OptimizationType.Maximization) soFarTheBestObjectiveValue = double.MinValue;
            else soFarTheBestObjectiveValue = double.MaxValue;
            // memory reallocation
            int ThreeTimesSize = populationSize * 3;
            /* population size(parent)+number of crossover offspring+number of mutated children */
            chromosomes = new T[ThreeTimesSize][ ];

            for (int r = 0; r < ThreeTimesSize; r++)
                chromosomes[r] = new T[numberOfGenes];
            indices = new int[ThreeTimesSize];
            objectives = new double[ThreeTimesSize];
            fitnessValues = new double[ThreeTimesSize];
            SelectedObjectives = new double[populationSize];
            selectedChromosomes = new T[populationSize][ ];
            for (int r = 0; r < populationSize; r++)
                selectedChromosomes[r] = new T[numberOfGenes];
            //....
            mutatedGenes = new bool[populationSize][];
            for (int r = 0; r < populationSize; r++)   mutatedGenes[r] = new bool[numberOfGenes];

            // set initial solution
            InitializePopultaion();

            // Fire After Initialization Event

            // evaluate objectives of the population
            for (int i = 0; i < populationSize; i++)
                objectives[i] = objectiveFunction(chromosomes[ i ]);

            if(theMonitor != null)
            {
                // reset to initial condition
                theMonitor.btnRunToEnd.Enabled = theMonitor.btnRunToEnd.Enabled = true;
                foreach (Series s in theMonitor.chtGA.Series) s.Points.Clear();
                theMonitor.labSoFarTheBestObjective.Text = "The Best Objective:";
                theMonitor.rtbTheBestSolution.Clear();
            }
        }

        public virtual void InitializePopultaion()
        {
            throw new NotImplementedException();
        }

        public void RunOneIteration( )
        {
            PerformCrossoverOperation();
            PerformMutationOperation();
            UpdateSoFarTheBestSolutionAndObjective();
            PerformSlectionOperation();
           

            if(theMonitor != null)
            {
                theMonitor.chtGA.Series[0].Points.AddXY(iterationId,iterationAverageObjective); // iterationAverageObjective);
                theMonitor.chtGA.Series[1].Points.AddXY(iterationId, iterationBestObjective); // iterationBestObjective);
                theMonitor.chtGA.Series[2].Points.AddXY(iterationId, soFarTheBestObjectiveValue); // soFarTheBestObjectiveValue);
                iterationId++;
            }
        }

        double s = double.MinValue;
        private void UpdateSoFarTheBestSolutionAndObjective()
        {
            // loop through objectives array for parents and children chromosomes
            // find the iteration best solution id first
            // check whether its value is better than the current best objective
            // if it does, than update the best objective and do gene-wise copy the iteration best
            // chromosomes to so-far-the-best solution.
            // calculate iterationBestObjective and iterationAverageObjective
            // If so far the best is updated in this iteration, update objective label and the solution

            int total = populationSize + numberOfMutatedChildren + numberOfCrossoverChildren;
            T[] iterationBestObjectiveArray;
            iterationBestObjectiveArray = new T[numberOfGenes]; // define an array to store chromosomes
            
            switch (optimizationType)
            {
                case OptimizationType.Minimization:
                    iterationBestObjective = double.MaxValue;
                    iterationAverageObjective = 0;
                    /* check whether the iteration (current) value is better(smaller) than 
                        so far the best value (compare with history) */
                    for (int i = 0; i < total; i++)
                    {
                        if(objectives[i] < iterationBestObjective)
                        {
                            iterationBestObjective = objectives[i];  // find iteration best value
                            for (int j = 0; j < numberOfGenes; j++)
                                iterationBestObjectiveArray[j] = chromosomes[i][j];
                        }
                    }
                    // calculate average objective value
                    for(int i = 0; i < populationSize; i++)
                        iterationAverageObjective += SelectedObjectives[i];
                    iterationAverageObjective = iterationAverageObjective / populationSize;

                    // find so far the best value
                    if(iterationBestObjective < soFarTheBestObjectiveValue)  
                    {
                        // update best objective if better and do gene-wise copy
                        soFarTheBestObjectiveValue = iterationBestObjective;
                        for (int i = 0; i < numberOfGenes; i++)
                            soFarTheBestSolution[i] = iterationBestObjectiveArray[i];
                    }
                    break;

                case OptimizationType.Maximization:
                    s = double.MinValue;
                    iterationAverageObjective = 0;
                    for(int i = 0; i < total; i++)
                    {
                        if(objectives[i] > s)
                        {
                            s = objectives[i];
                            iterationBestObjective = objectives[i];
                            for (int j = 0; j < numberOfGenes; j++)    
                                iterationBestObjectiveArray[j] = chromosomes[i][j];
                        }
                    }

                    for (int i = 0; i < populationSize; i++)
                    {
                        iterationAverageObjective += SelectedObjectives[i];
                    }
                    iterationAverageObjective = iterationAverageObjective / populationSize;
                    /* check whether the iteration(current) value is better(larger) than 
                       so far the best value (compare with history) */
                    if (iterationBestObjective > soFarTheBestObjectiveValue)
                    {
                        soFarTheBestObjectiveValue = iterationBestObjective;
                        for (int i = 0; i < numberOfGenes; i++)
                            // update if better 
                            soFarTheBestSolution[i] = iterationBestObjectiveArray[i];  //crash here
                    }
                    break;
            }
                

            if (theMonitor != null && true) // sofarthebestisupdated
            {
                theMonitor.labSoFarTheBestObjective.Text = $"The Best Objective: {soFarTheBestObjectiveValue:0.0000}";
                
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                // theMonitor.rtbTheBestSolution.Text = "";  // memory consuming // heap 堆積
                foreach (T i in soFarTheBestSolution) sb.Append($"{i},  ");
                theMonitor.rtbTheBestSolution.Text = sb.ToString();   
            }
        }

        private void PerformCrossoverOperation()
        {
            numberOfCrossoverChildren =(int)( populationSize * crossoverRate);
            if (numberOfCrossoverChildren % 2 == 1) numberOfCrossoverChildren--;
            // shuffle index array
            ShuffleAnArray(indices, populationSize);
            int father, mother, child1 = populationSize, child2= populationSize + 1;
            for(int i = 0; i < numberOfCrossoverChildren; i+=2)  // pair by pair
            {
                father = indices[i];
                mother = indices[i + 1];
                CrossoverAPairParent(father, mother, child1, child2);

                objectives[child1] = objectiveFunction(chromosomes[child1]);
                objectives[child2] = objectiveFunction(chromosomes[child2]);                
                child1 += 2;
                child2 += 2;
            }
        }

        public virtual void CrossoverAPairParent(int father, int mother, int child1, int child2)
        {
            throw new NotImplementedException();
        }

        protected void PerformMutationOperation()
        {
            
            if(mutationType == MutationMode.GeneNumberBased)
            {
                int limit = populationSize * numberOfGenes;
                int numberOfMutateGenes = (int) (mutationRate * limit) ;

                for(int i = 0; i < populationSize; i++)
                {
                    indices[i] = 0;
                    for (int j = 0; j < numberOfGenes; j++)
                        mutatedGenes[i][j] = false;
                }
                for(int i = 0; i < numberOfGenes; i++)
                {
                   int serialPos =  randomizer.Next(limit);
                    int parentId, geneId;
                    parentId = serialPos / numberOfGenes;
                    geneId = serialPos % numberOfGenes;
                   // SelectedObjectives[parentId] = double.NaN;
                    indices[parentId] = int.MinValue;
                    mutatedGenes[parentId][geneId] = true;
                }
                numberOfMutatedChildren = 0;
                int childId = populationSize + numberOfCrossoverChildren;
                for(int i = 0;i < populationSize; i++)
                {
                    if(indices[i] == int.MinValue)
                    {
                        MutateAParent(i, childId,mutatedGenes[i]);
                        objectives[childId] = objectiveFunction(chromosomes[childId]);
                        childId++;
                        numberOfMutatedChildren++;
                    }
                }
            }  // gene number based
            else  // population size based
            {
                 numberOfMutatedChildren = (int) mutationRate * populationSize ;
                ShuffleAnArray(indices, populationSize);

                for(int i = 0; i < numberOfMutatedChildren; i++)
                {
                    indices[i] = 0;
                    for(int j=0; j < numberOfGenes; j++)
                    {
                        mutatedGenes[i][j] = false;
                    }
                }
                for(int i = 0; i < numberOfMutatedChildren; i++)
                {
                    int parentId = 0;
                    int geneId = randomizer.Next(numberOfGenes);
                    SelectedObjectives[parentId] = int.MinValue;
                    mutatedGenes[parentId][geneId] = true;
                }
                // count
                int childId = populationSize + numberOfCrossoverChildren;
                for(int i = 0; i < populationSize; i++)
                {
                    if(indices[i] == int.MinValue)
                    {
                        MutateAParent(i, childId, mutatedGenes[i]);
                        objectives[childId] = objectiveFunction(chromosomes[childId]);
                        childId++;
                        numberOfMutatedChildren++;
                    }
                }
            }
        }

        public virtual void MutateAParent(int parentId, int childId, bool[ ] mutatedFlag)
        {
            throw new NotImplementedException();
        }

        public void PerformSlectionOperation()
        {
            setFitnessFromObjectives();
        }

        public void RunToEnd( )
        {
            do RunOneIteration();
            while (iterationId < iterationLimit);
        }
     }

   
    public enum OptimizationType { Minimization, Maximization }
    /// <summary>
    /// The mutation operation mode.
    /// </summary>
    public enum MutationMode { 
        /// <summary>
        /// The mutation rate is based on the total number of genes.
        /// </summary>
        GeneNumberBased, 
        /// <summary>
        ///  The mutation rate is based on the size of population.
        /// </summary>
        PopulationSizeBased}

    public enum SelectionMode { Deterministic, Stochastic }

    
    public delegate double ObjectiveFunction<SS>(SS[] aSolution);  // the delegate can check the function you prepare
}
