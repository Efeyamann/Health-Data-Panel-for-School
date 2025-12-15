namespace HealthDataPanel
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartAnne = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHIV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBebek = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBebek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTB)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            //this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1402, 627);
            this.splitContainer1.SplitterDistance = 748;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartAnne, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartHIV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartBebek, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartTB, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(650, 627);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chartAnne
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAnne.ChartAreas.Add(chartArea1);
            this.chartAnne.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartAnne.Legends.Add(legend1);
            this.chartAnne.Location = new System.Drawing.Point(3, 3);
            this.chartAnne.Name = "chartAnne";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartAnne.Series.Add(series1);
            this.chartAnne.Size = new System.Drawing.Size(319, 307);
            this.chartAnne.TabIndex = 0;
            this.chartAnne.Text = "chart1";
            // 
            // chartHIV
            // 
            chartArea2.Name = "ChartArea1";
            this.chartHIV.ChartAreas.Add(chartArea2);
            this.chartHIV.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartHIV.Legends.Add(legend2);
            this.chartHIV.Location = new System.Drawing.Point(3, 316);
            this.chartHIV.Name = "chartHIV";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartHIV.Series.Add(series2);
            this.chartHIV.Size = new System.Drawing.Size(319, 308);
            this.chartHIV.TabIndex = 1;
            this.chartHIV.Text = "chart2";
            // 
            // chartBebek
            // 
            chartArea3.Name = "ChartArea1";
            this.chartBebek.ChartAreas.Add(chartArea3);
            this.chartBebek.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartBebek.Legends.Add(legend3);
            this.chartBebek.Location = new System.Drawing.Point(328, 3);
            this.chartBebek.Name = "chartBebek";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartBebek.Series.Add(series3);
            this.chartBebek.Size = new System.Drawing.Size(319, 307);
            this.chartBebek.TabIndex = 2;
            this.chartBebek.Text = "chart3";
            // 
            // chartTB
            // 
            chartArea4.Name = "ChartArea1";
            this.chartTB.ChartAreas.Add(chartArea4);
            this.chartTB.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chartTB.Legends.Add(legend4);
            this.chartTB.Location = new System.Drawing.Point(328, 316);
            this.chartTB.Name = "chartTB";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartTB.Series.Add(series4);
            this.chartTB.Size = new System.Drawing.Size(319, 308);
            this.chartTB.TabIndex = 3;
            this.chartTB.Text = "chart4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 627);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAnne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBebek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnne;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHIV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBebek;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTB;
    }
}

