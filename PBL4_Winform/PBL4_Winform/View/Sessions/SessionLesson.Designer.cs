﻿namespace PBL4_Winform.View.Sessions
{
    partial class SessionLesson
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnAddLesson = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dgvLesson = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLesson)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgvLesson, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.88889F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnAddLesson);
            this.panel6.Location = new System.Drawing.Point(3, 408);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(794, 39);
            this.panel6.TabIndex = 6;
            // 
            // btnAddLesson
            // 
            this.btnAddLesson.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddLesson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddLesson.Location = new System.Drawing.Point(0, 0);
            this.btnAddLesson.Name = "btnAddLesson";
            this.btnAddLesson.Size = new System.Drawing.Size(794, 39);
            this.btnAddLesson.TabIndex = 3;
            this.btnAddLesson.Text = "Chọn";
            this.btnAddLesson.UseVisualStyleBackColor = false;
            this.btnAddLesson.Click += new System.EventHandler(this.btnAddLesson_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(794, 61);
            this.panel5.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(794, 53);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "Danh sách bài học";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvLesson
            // 
            this.dgvLesson.AllowUserToAddRows = false;
            this.dgvLesson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLesson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLesson.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLesson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLesson.Location = new System.Drawing.Point(3, 70);
            this.dgvLesson.Name = "dgvLesson";
            this.dgvLesson.ReadOnly = true;
            this.dgvLesson.RowHeadersWidth = 51;
            this.dgvLesson.RowTemplate.Height = 24;
            this.dgvLesson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLesson.Size = new System.Drawing.Size(794, 332);
            this.dgvLesson.TabIndex = 0;
            // 
            // SessionLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "SessionLesson";
            this.Text = "Danh sách bài học";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLesson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnAddLesson;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dgvLesson;
    }
}