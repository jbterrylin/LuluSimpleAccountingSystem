namespace Lulu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PackListView = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Component = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Person = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ComponentTB = new System.Windows.Forms.TextBox();
            this.PersonTB = new System.Windows.Forms.TextBox();
            this.QuanityTB = new System.Windows.Forms.NumericUpDown();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.DateTB = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ProcessBtn = new System.Windows.Forms.Button();
            this.LoadBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SaveLocationTB = new System.Windows.Forms.TextBox();
            this.PackTreeView = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.PriceBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuanityTB)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.PackListView, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(554, 444);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // PackListView
            // 
            this.PackListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.Component,
            this.Person,
            this.Quantity});
            this.PackListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PackListView.GridLines = true;
            this.PackListView.HideSelection = false;
            this.PackListView.Location = new System.Drawing.Point(3, 3);
            this.PackListView.Name = "PackListView";
            this.PackListView.Size = new System.Drawing.Size(548, 393);
            this.PackListView.TabIndex = 0;
            this.PackListView.UseCompatibleStateImageBehavior = false;
            this.PackListView.View = System.Windows.Forms.View.Details;
            this.PackListView.SelectedIndexChanged += new System.EventHandler(this.PackListView_SelectedIndexChanged);
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 150;
            // 
            // Component
            // 
            this.Component.Text = "Component";
            this.Component.Width = 150;
            // 
            // Person
            // 
            this.Person.Text = "Person";
            this.Person.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 100;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.ComponentTB, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.PersonTB, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.QuanityTB, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.SubmitBtn, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.DateTB, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 402);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(548, 39);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // ComponentTB
            // 
            this.ComponentTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ComponentTB.Location = new System.Drawing.Point(112, 8);
            this.ComponentTB.Name = "ComponentTB";
            this.ComponentTB.Size = new System.Drawing.Size(103, 22);
            this.ComponentTB.TabIndex = 0;
            this.ComponentTB.Text = "Part ";
            this.ComponentTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComponentTB_KeyDown);
            // 
            // PersonTB
            // 
            this.PersonTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PersonTB.Location = new System.Drawing.Point(221, 8);
            this.PersonTB.Name = "PersonTB";
            this.PersonTB.Size = new System.Drawing.Size(103, 22);
            this.PersonTB.TabIndex = 1;
            this.PersonTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PersonTB_KeyDown);
            // 
            // QuanityTB
            // 
            this.QuanityTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.QuanityTB.Location = new System.Drawing.Point(330, 8);
            this.QuanityTB.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.QuanityTB.Name = "QuanityTB";
            this.QuanityTB.Size = new System.Drawing.Size(103, 22);
            this.QuanityTB.TabIndex = 2;
            this.QuanityTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuanityTB_KeyDown);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitBtn.Location = new System.Drawing.Point(439, 8);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(106, 23);
            this.SubmitBtn.TabIndex = 3;
            this.SubmitBtn.Text = "submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // DateTB
            // 
            this.DateTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTB.Location = new System.Drawing.Point(3, 8);
            this.DateTB.Name = "DateTB";
            this.DateTB.Size = new System.Drawing.Size(103, 22);
            this.DateTB.TabIndex = 4;
            this.DateTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateTB_KeyDown);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.SaveLocationTB, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.PackTreeView, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(563, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(234, 444);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.ProcessBtn, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.LoadBtn, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.SaveBtn, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 47);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(228, 38);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // ProcessBtn
            // 
            this.ProcessBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessBtn.Location = new System.Drawing.Point(3, 3);
            this.ProcessBtn.Name = "ProcessBtn";
            this.ProcessBtn.Size = new System.Drawing.Size(70, 32);
            this.ProcessBtn.TabIndex = 0;
            this.ProcessBtn.Text = "Process";
            this.ProcessBtn.UseVisualStyleBackColor = true;
            this.ProcessBtn.Click += new System.EventHandler(this.ProcessBtn_Click);
            // 
            // LoadBtn
            // 
            this.LoadBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadBtn.Location = new System.Drawing.Point(155, 3);
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(70, 32);
            this.LoadBtn.TabIndex = 1;
            this.LoadBtn.Text = "Load";
            this.LoadBtn.UseVisualStyleBackColor = true;
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveBtn.Location = new System.Drawing.Point(79, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(70, 32);
            this.SaveBtn.TabIndex = 2;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SaveLocationTB
            // 
            this.SaveLocationTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveLocationTB.Location = new System.Drawing.Point(3, 11);
            this.SaveLocationTB.Name = "SaveLocationTB";
            this.SaveLocationTB.Size = new System.Drawing.Size(228, 22);
            this.SaveLocationTB.TabIndex = 5;
            this.SaveLocationTB.Text = "C:";
            // 
            // PackTreeView
            // 
            this.PackTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PackTreeView.Location = new System.Drawing.Point(3, 135);
            this.PackTreeView.Name = "PackTreeView";
            this.PackTreeView.Size = new System.Drawing.Size(228, 306);
            this.PackTreeView.TabIndex = 6;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.Controls.Add(this.PriceBtn, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 91);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(228, 38);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // PriceBtn
            // 
            this.PriceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PriceBtn.Location = new System.Drawing.Point(3, 3);
            this.PriceBtn.Name = "PriceBtn";
            this.PriceBtn.Size = new System.Drawing.Size(120, 32);
            this.PriceBtn.TabIndex = 9;
            this.PriceBtn.Text = "Price";
            this.PriceBtn.UseVisualStyleBackColor = true;
            this.PriceBtn.Click += new System.EventHandler(this.PriceBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuanityTB)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView PackListView;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Component;
        private System.Windows.Forms.ColumnHeader Person;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox ComponentTB;
        private System.Windows.Forms.TextBox PersonTB;
        private System.Windows.Forms.NumericUpDown QuanityTB;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.DateTimePicker DateTB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button ProcessBtn;
        private System.Windows.Forms.Button LoadBtn;
        private System.Windows.Forms.TextBox SaveLocationTB;
        private System.Windows.Forms.TreeView PackTreeView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button PriceBtn;
        private System.Windows.Forms.Button SaveBtn;
    }
}

