
namespace DaphneGALibrary
{
    partial class GAMonitor<S>
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tbProblem = new System.Windows.Forms.TabPage();
            this.lbMax = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.NumericMax = new System.Windows.Forms.NumericUpDown();
            this.NumericMin = new System.Windows.Forms.NumericUpDown();
            this.btnGenerateDataToDGV = new System.Windows.Forms.Button();
            this.dgvProblem = new System.Windows.Forms.DataGridView();
            this.cbNumOfJobs = new System.Windows.Forms.ComboBox();
            this.labNumOfJobs = new System.Windows.Forms.Label();
            this.tpGASetting = new System.Windows.Forms.TabPage();
            this.btnRunToEnd = new System.Windows.Forms.Button();
            this.btnRunOneIteration = new System.Windows.Forms.Button();
            this.ppgGA = new System.Windows.Forms.PropertyGrid();
            this.btnReset = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.rtbTheBestSolution = new System.Windows.Forms.RichTextBox();
            this.labSoFarTheBestObjective = new System.Windows.Forms.Label();
            this.chtGA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.tbProblem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblem)).BeginInit();
            this.tpGASetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtGA)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Linen;
            this.splitContainer1.Panel1.Controls.Add(this.tabPage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1189, 628);
            this.splitContainer1.SplitterDistance = 476;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.tbProblem);
            this.tabPage.Controls.Add(this.tpGASetting);
            this.tabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage.Location = new System.Drawing.Point(0, 0);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(476, 628);
            this.tabPage.TabIndex = 0;
            // 
            // tbProblem
            // 
            this.tbProblem.Controls.Add(this.lbMax);
            this.tbProblem.Controls.Add(this.lbMin);
            this.tbProblem.Controls.Add(this.NumericMax);
            this.tbProblem.Controls.Add(this.NumericMin);
            this.tbProblem.Controls.Add(this.btnGenerateDataToDGV);
            this.tbProblem.Controls.Add(this.dgvProblem);
            this.tbProblem.Controls.Add(this.cbNumOfJobs);
            this.tbProblem.Controls.Add(this.labNumOfJobs);
            this.tbProblem.Location = new System.Drawing.Point(4, 32);
            this.tbProblem.Name = "tbProblem";
            this.tbProblem.Padding = new System.Windows.Forms.Padding(3);
            this.tbProblem.Size = new System.Drawing.Size(468, 592);
            this.tbProblem.TabIndex = 0;
            this.tbProblem.Text = "Problem";
            this.tbProblem.UseVisualStyleBackColor = true;
            // 
            // lbMax
            // 
            this.lbMax.AutoSize = true;
            this.lbMax.Location = new System.Drawing.Point(23, 139);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(96, 23);
            this.lbMax.TabIndex = 11;
            this.lbMax.Text = "Maximum";
            // 
            // lbMin
            // 
            this.lbMin.AutoSize = true;
            this.lbMin.Location = new System.Drawing.Point(23, 85);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(93, 23);
            this.lbMin.TabIndex = 10;
            this.lbMin.Text = "Minimum";
            // 
            // NumericMax
            // 
            this.NumericMax.Location = new System.Drawing.Point(137, 131);
            this.NumericMax.Name = "NumericMax";
            this.NumericMax.Size = new System.Drawing.Size(120, 31);
            this.NumericMax.TabIndex = 9;
            this.NumericMax.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
            // 
            // NumericMin
            // 
            this.NumericMin.Location = new System.Drawing.Point(137, 83);
            this.NumericMin.Name = "NumericMin";
            this.NumericMin.Size = new System.Drawing.Size(120, 31);
            this.NumericMin.TabIndex = 8;
            // 
            // btnGenerateDataToDGV
            // 
            this.btnGenerateDataToDGV.Location = new System.Drawing.Point(6, 240);
            this.btnGenerateDataToDGV.Name = "btnGenerateDataToDGV";
            this.btnGenerateDataToDGV.Size = new System.Drawing.Size(131, 42);
            this.btnGenerateDataToDGV.TabIndex = 7;
            this.btnGenerateDataToDGV.Text = "Generate";
            this.btnGenerateDataToDGV.UseVisualStyleBackColor = true;
            this.btnGenerateDataToDGV.Click += new System.EventHandler(this.btnGenerateDataToDGV_Click);
            // 
            // dgvProblem
            // 
            this.dgvProblem.AllowUserToAddRows = false;
            this.dgvProblem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProblem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProblem.Location = new System.Drawing.Point(6, 292);
            this.dgvProblem.Name = "dgvProblem";
            this.dgvProblem.RowHeadersWidth = 62;
            this.dgvProblem.RowTemplate.Height = 31;
            this.dgvProblem.Size = new System.Drawing.Size(442, 298);
            this.dgvProblem.TabIndex = 6;
            // 
            // cbNumOfJobs
            // 
            this.cbNumOfJobs.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbNumOfJobs.FormattingEnabled = true;
            this.cbNumOfJobs.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbNumOfJobs.Location = new System.Drawing.Point(272, 26);
            this.cbNumOfJobs.Name = "cbNumOfJobs";
            this.cbNumOfJobs.Size = new System.Drawing.Size(121, 31);
            this.cbNumOfJobs.TabIndex = 5;
            this.cbNumOfJobs.Text = "3";
            // 
            // labNumOfJobs
            // 
            this.labNumOfJobs.AutoSize = true;
            this.labNumOfJobs.Location = new System.Drawing.Point(23, 29);
            this.labNumOfJobs.Name = "labNumOfJobs";
            this.labNumOfJobs.Size = new System.Drawing.Size(234, 23);
            this.labNumOfJobs.TabIndex = 3;
            this.labNumOfJobs.Text = "Number of Jobs/Machines";
            // 
            // tpGASetting
            // 
            this.tpGASetting.Controls.Add(this.btnRunToEnd);
            this.tpGASetting.Controls.Add(this.btnRunOneIteration);
            this.tpGASetting.Controls.Add(this.ppgGA);
            this.tpGASetting.Controls.Add(this.btnReset);
            this.tpGASetting.Location = new System.Drawing.Point(4, 32);
            this.tpGASetting.Name = "tpGASetting";
            this.tpGASetting.Padding = new System.Windows.Forms.Padding(3);
            this.tpGASetting.Size = new System.Drawing.Size(468, 592);
            this.tpGASetting.TabIndex = 1;
            this.tpGASetting.Text = "GA Settings";
            this.tpGASetting.UseVisualStyleBackColor = true;
            // 
            // btnRunToEnd
            // 
            this.btnRunToEnd.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRunToEnd.Location = new System.Drawing.Point(36, 104);
            this.btnRunToEnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunToEnd.Name = "btnRunToEnd";
            this.btnRunToEnd.Size = new System.Drawing.Size(189, 33);
            this.btnRunToEnd.TabIndex = 2;
            this.btnRunToEnd.Text = "Run To End";
            this.btnRunToEnd.UseVisualStyleBackColor = true;
            this.btnRunToEnd.Click += new System.EventHandler(this.btnRunToEnd_Click);
            // 
            // btnRunOneIteration
            // 
            this.btnRunOneIteration.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRunOneIteration.Location = new System.Drawing.Point(36, 61);
            this.btnRunOneIteration.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunOneIteration.Name = "btnRunOneIteration";
            this.btnRunOneIteration.Size = new System.Drawing.Size(189, 35);
            this.btnRunOneIteration.TabIndex = 1;
            this.btnRunOneIteration.Text = "Run One Iteration";
            this.btnRunOneIteration.UseVisualStyleBackColor = true;
            this.btnRunOneIteration.Click += new System.EventHandler(this.btnRunOneIteration_Click);
            // 
            // ppgGA
            // 
            this.ppgGA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ppgGA.Location = new System.Drawing.Point(6, 201);
            this.ppgGA.Margin = new System.Windows.Forms.Padding(4);
            this.ppgGA.Name = "ppgGA";
            this.ppgGA.Size = new System.Drawing.Size(458, 384);
            this.ppgGA.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReset.Location = new System.Drawing.Point(36, 20);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(189, 33);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.rtbTheBestSolution);
            this.splitContainer3.Panel1.Controls.Add(this.labSoFarTheBestObjective);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chtGA);
            this.splitContainer3.Size = new System.Drawing.Size(708, 628);
            this.splitContainer3.SplitterDistance = 194;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 1;
            // 
            // rtbTheBestSolution
            // 
            this.rtbTheBestSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTheBestSolution.Location = new System.Drawing.Point(0, 23);
            this.rtbTheBestSolution.Margin = new System.Windows.Forms.Padding(4);
            this.rtbTheBestSolution.Name = "rtbTheBestSolution";
            this.rtbTheBestSolution.Size = new System.Drawing.Size(708, 171);
            this.rtbTheBestSolution.TabIndex = 1;
            this.rtbTheBestSolution.Text = "";
            // 
            // labSoFarTheBestObjective
            // 
            this.labSoFarTheBestObjective.Dock = System.Windows.Forms.DockStyle.Top;
            this.labSoFarTheBestObjective.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labSoFarTheBestObjective.Location = new System.Drawing.Point(0, 0);
            this.labSoFarTheBestObjective.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSoFarTheBestObjective.Name = "labSoFarTheBestObjective";
            this.labSoFarTheBestObjective.Size = new System.Drawing.Size(708, 23);
            this.labSoFarTheBestObjective.TabIndex = 0;
            this.labSoFarTheBestObjective.Text = "The Best Objective:";
            this.labSoFarTheBestObjective.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chtGA
            // 
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.Title = "x";
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.Title = "y";
            chartArea2.Name = "ChartArea1";
            this.chtGA.ChartAreas.Add(chartArea2);
            this.chtGA.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chtGA.Legends.Add(legend2);
            this.chtGA.Location = new System.Drawing.Point(0, 0);
            this.chtGA.Margin = new System.Windows.Forms.Padding(4);
            this.chtGA.Name = "chtGA";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.SeaGreen;
            series4.Legend = "Legend1";
            series4.LegendText = "Iteration Average";
            series4.Name = "Series1";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.DodgerBlue;
            series5.Legend = "Legend1";
            series5.LegendText = "Iteration Best";
            series5.Name = "Series2";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.OrangeRed;
            series6.Legend = "Legend1";
            series6.LegendText = "So Far The Best";
            series6.Name = "Series3";
            this.chtGA.Series.Add(series4);
            this.chtGA.Series.Add(series5);
            this.chtGA.Series.Add(series6);
            this.chtGA.Size = new System.Drawing.Size(708, 429);
            this.chtGA.TabIndex = 0;
            this.chtGA.Text = "chart1";
            // 
            // GAMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GAMonitor";
            this.Size = new System.Drawing.Size(1189, 628);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tbProblem.ResumeLayout(false);
            this.tbProblem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProblem)).EndInit();
            this.tpGASetting.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtGA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chtGA;
        public System.Windows.Forms.PropertyGrid ppgGA;
        public System.Windows.Forms.Button btnRunOneIteration;
        public System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.Button btnRunToEnd;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.RichTextBox rtbTheBestSolution;
        public System.Windows.Forms.Label labSoFarTheBestObjective;
        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tbProblem;
        private System.Windows.Forms.TabPage tpGASetting;
        private System.Windows.Forms.Label labNumOfJobs;
        public System.Windows.Forms.DataGridView dgvProblem;
        public System.Windows.Forms.ComboBox cbNumOfJobs;
        private System.Windows.Forms.Button btnGenerateDataToDGV;
        private System.Windows.Forms.Label lbMax;
        private System.Windows.Forms.Label lbMin;
        public System.Windows.Forms.NumericUpDown NumericMax;
        public System.Windows.Forms.NumericUpDown NumericMin;
    }
}
