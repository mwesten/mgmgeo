﻿namespace GMap.NET
{
   partial class TilePrefetcherEnh
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
         if(disposing && (components != null))
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
          this.label1 = new System.Windows.Forms.Label();
          this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
          this.progressBarDownload = new System.Windows.Forms.ProgressBar();
          this.label2 = new System.Windows.Forms.Label();
          this.tableLayoutPanel1.SuspendLayout();
          this.SuspendLayout();
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.label1.Location = new System.Drawing.Point(3, 0);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(394, 13);
          this.label1.TabIndex = 1;
          this.label1.Text = "label1";
          // 
          // tableLayoutPanel1
          // 
          this.tableLayoutPanel1.ColumnCount = 2;
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
          this.tableLayoutPanel1.Controls.Add(this.progressBarDownload, 0, 1);
          this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
          this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
          this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
          this.tableLayoutPanel1.Name = "tableLayoutPanel1";
          this.tableLayoutPanel1.RowCount = 2;
          this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
          this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tableLayoutPanel1.Size = new System.Drawing.Size(494, 50);
          this.tableLayoutPanel1.TabIndex = 2;
          // 
          // progressBarDownload
          // 
          this.progressBarDownload.Dock = System.Windows.Forms.DockStyle.Fill;
          this.progressBarDownload.Location = new System.Drawing.Point(3, 16);
          this.progressBarDownload.Name = "progressBarDownload";
          this.progressBarDownload.Size = new System.Drawing.Size(394, 31);
          this.progressBarDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
          this.progressBarDownload.TabIndex = 3;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label2.Location = new System.Drawing.Point(403, 13);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(88, 37);
          this.label2.TabIndex = 2;
          this.label2.Text = "please wait...";
          this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
          // 
          // TilePrefetcherEnh
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.AliceBlue;
          this.ClientSize = new System.Drawing.Size(502, 58);
          this.ControlBox = false;
          this.Controls.Add(this.tableLayoutPanel1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.KeyPreview = true;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "TilePrefetcherEnh";
          this.Padding = new System.Windows.Forms.Padding(4);
          this.ShowIcon = false;
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "GMap.NET - esc to cancel fetching";
          this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Prefetch_FormClosed);
          this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Prefetch_PreviewKeyDown);
          this.tableLayoutPanel1.ResumeLayout(false);
          this.tableLayoutPanel1.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.ProgressBar progressBarDownload;
      private System.Windows.Forms.Label label2;
   }
}