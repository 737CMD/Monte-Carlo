namespace Monte_Carlo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            Calculate = new Button();
            EqRes = new Label();
            expressionTB = new TextBox();
            Tip = new Label();
            lowerLim = new TextBox();
            upperLim = new TextBox();
            Limits_of_integration = new Label();
            bindingSource1 = new BindingSource(components);
            Residual = new Label();
            resTb = new TextBox();
            pointsBar = new TrackBar();
            Points_per_cycle = new Label();
            IterTicker = new Label();
            EvalModeBox = new CheckBox();
            Ichart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pointsBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Ichart).BeginInit();
            SuspendLayout();
            // 
            // Calculate
            // 
            Calculate.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Calculate.Location = new Point(737, 412);
            Calculate.Margin = new Padding(3, 4, 3, 4);
            Calculate.Name = "Calculate";
            Calculate.Size = new Size(134, 71);
            Calculate.TabIndex = 0;
            Calculate.Text = "Calculate ";
            Calculate.UseVisualStyleBackColor = true;
            Calculate.Click += Calculate_Click;
            // 
            // EqRes
            // 
            EqRes.AutoSize = true;
            EqRes.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EqRes.Location = new Point(877, 449);
            EqRes.Name = "EqRes";
            EqRes.Size = new Size(0, 24);
            EqRes.TabIndex = 1;
            // 
            // expressionTB
            // 
            expressionTB.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expressionTB.Location = new Point(737, 40);
            expressionTB.Margin = new Padding(3, 4, 3, 4);
            expressionTB.Name = "expressionTB";
            expressionTB.Size = new Size(349, 34);
            expressionTB.TabIndex = 2;
            // 
            // Tip
            // 
            Tip.AutoSize = true;
            Tip.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tip.Location = new Point(737, 12);
            Tip.Name = "Tip";
            Tip.Size = new Size(160, 24);
            Tip.TabIndex = 3;
            Tip.Text = "Your expression:";
            // 
            // lowerLim
            // 
            lowerLim.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lowerLim.Location = new Point(737, 146);
            lowerLim.Margin = new Padding(3, 4, 3, 4);
            lowerLim.Name = "lowerLim";
            lowerLim.Size = new Size(133, 34);
            lowerLim.TabIndex = 4;
            // 
            // upperLim
            // 
            upperLim.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            upperLim.Location = new Point(953, 146);
            upperLim.Margin = new Padding(3, 4, 3, 4);
            upperLim.Name = "upperLim";
            upperLim.Size = new Size(133, 34);
            upperLim.TabIndex = 5;
            // 
            // Limits_of_integration
            // 
            Limits_of_integration.AutoSize = true;
            Limits_of_integration.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Limits_of_integration.Location = new Point(737, 118);
            Limits_of_integration.Name = "Limits_of_integration";
            Limits_of_integration.Size = new Size(201, 24);
            Limits_of_integration.TabIndex = 6;
            Limits_of_integration.Text = "Limits of integration:";
            // 
            // Residual
            // 
            Residual.AutoSize = true;
            Residual.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Residual.Location = new Point(737, 220);
            Residual.Name = "Residual";
            Residual.Size = new Size(94, 24);
            Residual.TabIndex = 7;
            Residual.Text = "Residual:";
            // 
            // resTb
            // 
            resTb.Font = new Font("Georgia", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            resTb.Location = new Point(737, 248);
            resTb.Margin = new Padding(3, 4, 3, 4);
            resTb.Name = "resTb";
            resTb.Size = new Size(133, 34);
            resTb.TabIndex = 8;
            // 
            // pointsBar
            // 
            pointsBar.LargeChange = 1;
            pointsBar.Location = new Point(737, 332);
            pointsBar.Margin = new Padding(3, 4, 3, 4);
            pointsBar.Minimum = 1;
            pointsBar.Name = "pointsBar";
            pointsBar.Size = new Size(350, 56);
            pointsBar.TabIndex = 9;
            pointsBar.TabStop = false;
            pointsBar.Value = 1;
            pointsBar.Scroll += pointsBar_Scroll;
            // 
            // Points_per_cycle
            // 
            Points_per_cycle.AutoSize = true;
            Points_per_cycle.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Points_per_cycle.Location = new Point(737, 304);
            Points_per_cycle.Name = "Points_per_cycle";
            Points_per_cycle.Size = new Size(266, 24);
            Points_per_cycle.TabIndex = 10;
            Points_per_cycle.Text = "Points per cycle per 10: 1000";
            // 
            // IterTicker
            // 
            IterTicker.AutoSize = true;
            IterTicker.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IterTicker.Location = new Point(877, 412);
            IterTicker.Name = "IterTicker";
            IterTicker.Size = new Size(0, 24);
            IterTicker.TabIndex = 11;
            // 
            // EvalModeBox
            // 
            EvalModeBox.AutoSize = true;
            EvalModeBox.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EvalModeBox.Location = new Point(741, 87);
            EvalModeBox.Margin = new Padding(3, 4, 3, 4);
            EvalModeBox.Name = "EvalModeBox";
            EvalModeBox.Size = new Size(107, 24);
            EvalModeBox.TabIndex = 12;
            EvalModeBox.Text = "EvalMode";
            EvalModeBox.UseVisualStyleBackColor = true;
            EvalModeBox.CheckedChanged += EvalModeBox_CheckedChanged;
            // 
            // Ichart
            // 
            chartArea1.Name = "MainArea";
            Ichart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            Ichart.Legends.Add(legend1);
            Ichart.Location = new Point(12, 12);
            Ichart.Name = "Ichart";
            Ichart.Size = new Size(719, 514);
            Ichart.TabIndex = 13;
            Ichart.Text = "Ichart";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 538);
            Controls.Add(Ichart);
            Controls.Add(EvalModeBox);
            Controls.Add(IterTicker);
            Controls.Add(Points_per_cycle);
            Controls.Add(pointsBar);
            Controls.Add(resTb);
            Controls.Add(Residual);
            Controls.Add(Limits_of_integration);
            Controls.Add(upperLim);
            Controls.Add(lowerLim);
            Controls.Add(Tip);
            Controls.Add(expressionTB);
            Controls.Add(EqRes);
            Controls.Add(Calculate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Monte-Carlo";
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pointsBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)Ichart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Calculate;
        private Label EqRes;
        private TextBox expressionTB;
        private Label Tip;
        private TextBox lowerLim;
        private TextBox upperLim;
        private Label Limits_of_integration;
        private BindingSource bindingSource1;
        private Label Residual;
        private TextBox resTb;
        private TrackBar pointsBar;
        private Label Points_per_cycle;
        private Label IterTicker;
        private CheckBox EvalModeBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart Ichart;
    }
}
