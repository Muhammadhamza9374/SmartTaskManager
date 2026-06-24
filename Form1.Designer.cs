namespace SmartTaskManager
{
partial class Form1
{
private System.ComponentModel.IContainer components = null;
private System.Windows.Forms.Button btnAdd;

```
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.btnAdd = new System.Windows.Forms.Button();

        this.btnAdd.Location = new System.Drawing.Point(50, 50);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(100, 30);
        this.btnAdd.Text = "Add Task";
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        this.Controls.Add(this.btnAdd);

        this.Text = "Smart Task Manager";
        this.ResumeLayout(false);
    }
}
```

}
