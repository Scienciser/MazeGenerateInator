using System.Windows.Forms;

namespace Maze.UI;

partial class MazeForm
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
        MazePanel = new MazePanel();
        UIContainer = new SplitContainer();
        ControlsLayoutPanel = new TableLayoutPanel();
        ControlsLabel = new Label();
        NewMazeButton = new Button();
        NavigateMazeButton = new Button();
        SolveButton = new Button();
        ((System.ComponentModel.ISupportInitialize)UIContainer).BeginInit();
        UIContainer.Panel1.SuspendLayout();
        UIContainer.Panel2.SuspendLayout();
        UIContainer.SuspendLayout();
        ControlsLayoutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // MazePanel
        // 
        MazePanel.Dock = DockStyle.Fill;
        MazePanel.Location = new Point(0, 0);
        MazePanel.Name = "MazePanel";
        MazePanel.Size = new Size(982, 350);
        MazePanel.TabIndex = 0;
        // 
        // UIContainer
        // 
        UIContainer.Dock = DockStyle.Fill;
        UIContainer.Location = new Point(0, 0);
        UIContainer.Name = "UIContainer";
        UIContainer.Orientation = Orientation.Horizontal;
        // 
        // UIContainer.Panel1
        // 
        UIContainer.Panel1.Controls.Add(MazePanel);
        // 
        // UIContainer.Panel2
        // 
        UIContainer.Panel2.Controls.Add(ControlsLayoutPanel);
        UIContainer.Size = new Size(982, 453);
        UIContainer.SplitterDistance = 350;
        UIContainer.TabIndex = 1;
        // 
        // ControlsLayoutPanel
        // 
        ControlsLayoutPanel.ColumnCount = 4;
        ControlsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ControlsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ControlsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ControlsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        ControlsLayoutPanel.Controls.Add(ControlsLabel, 0, 0);
        ControlsLayoutPanel.Controls.Add(NewMazeButton, 1, 0);
        ControlsLayoutPanel.Controls.Add(NavigateMazeButton, 2, 0);
        ControlsLayoutPanel.Controls.Add(SolveButton, 3, 0);
        ControlsLayoutPanel.Dock = DockStyle.Fill;
        ControlsLayoutPanel.Location = new Point(0, 0);
        ControlsLayoutPanel.Name = "ControlsLayoutPanel";
        ControlsLayoutPanel.RowCount = 1;
        ControlsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        ControlsLayoutPanel.Size = new Size(982, 99);
        ControlsLayoutPanel.TabIndex = 0;
        // 
        // ControlsLabel
        // 
        ControlsLabel.AutoSize = true;
        ControlsLabel.Dock = DockStyle.Fill;
        ControlsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ControlsLabel.Location = new Point(3, 0);
        ControlsLabel.Name = "ControlsLabel";
        ControlsLabel.Size = new Size(239, 99);
        ControlsLabel.TabIndex = 0;
        ControlsLabel.Text = "Controls:";
        ControlsLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // NewMazeButton
        // 
        NewMazeButton.Dock = DockStyle.Fill;
        NewMazeButton.Location = new Point(248, 3);
        NewMazeButton.Name = "NewMazeButton";
        NewMazeButton.Size = new Size(239, 93);
        NewMazeButton.TabIndex = 1;
        NewMazeButton.Text = "New Maze";
        NewMazeButton.UseVisualStyleBackColor = true;
        NewMazeButton.Click += NewMazeButton_Click;
        // 
        // NavigateMazeButton
        // 
        NavigateMazeButton.Dock = DockStyle.Fill;
        NavigateMazeButton.Location = new Point(493, 3);
        NavigateMazeButton.Name = "NavigateMazeButton";
        NavigateMazeButton.Size = new Size(239, 93);
        NavigateMazeButton.TabIndex = 2;
        NavigateMazeButton.Text = "Navigate with Arrow Keys";
        NavigateMazeButton.UseVisualStyleBackColor = true;
        NavigateMazeButton.Click += NavigateMazeButton_Click;
        // 
        // SolveButton
        // 
        SolveButton.Dock = DockStyle.Fill;
        SolveButton.Location = new Point(738, 3);
        SolveButton.Name = "SolveButton";
        SolveButton.Size = new Size(241, 93);
        SolveButton.TabIndex = 3;
        SolveButton.Text = "Solve";
        SolveButton.UseVisualStyleBackColor = true;
        SolveButton.Click += SolveButton_Click;
        // 
        // MazeForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(982, 453);
        Controls.Add(UIContainer);
        Name = "MazeForm";
        Text = "Maze Generate-inator";
        WindowState = FormWindowState.Maximized;
        UIContainer.Panel1.ResumeLayout(false);
        UIContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)UIContainer).EndInit();
        UIContainer.ResumeLayout(false);
        ControlsLayoutPanel.ResumeLayout(false);
        ControlsLayoutPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private MazePanel MazePanel;
    private Label ControlsLabel;
    private SplitContainer UIContainer;
    private TableLayoutPanel ControlsLayoutPanel;
    private Button NewMazeButton;
    private Button NavigateMazeButton;
    private Button SolveButton;
}
