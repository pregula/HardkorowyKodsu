namespace HardkorowyKodsu.Client
{
    partial class MainForm
    {
        private void InitializeComponent()
        {
            this.treeViewDatabase = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            
            this.treeViewDatabase.Location = new System.Drawing.Point(12, 12);
            this.treeViewDatabase.Name = "treeViewDatabase";
            this.treeViewDatabase.Size = new System.Drawing.Size(500, 400);
            this.treeViewDatabase.TabIndex = 0;
            this.treeViewDatabase.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDatabase_NodeMouseDoubleClick);
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.treeViewDatabase);
            this.Name = "MainForm";
            this.Text = "Hardkorowy Kodsu";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TreeView treeViewDatabase;
    }

}