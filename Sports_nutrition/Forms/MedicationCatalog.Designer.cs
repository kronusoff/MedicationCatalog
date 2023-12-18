using System.Drawing;
using System.Windows.Forms;

namespace Medication
{
    partial class MedicationCatalog
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
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.FixButton = new System.Windows.Forms.Button();
            this.sortComboBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.IdHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CategoryHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CostHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.LightSlateGray;
            this.AddButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.ForeColor = System.Drawing.Color.SeaShell;
            this.AddButton.Location = new System.Drawing.Point(255, 557);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(167, 81);
            this.AddButton.TabIndex = 16;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.BackColor = System.Drawing.Color.SlateGray;
            this.RemoveButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RemoveButton.Location = new System.Drawing.Point(601, 557);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(167, 81);
            this.RemoveButton.TabIndex = 17;
            this.RemoveButton.Text = "Удалить";
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // FixButton
            // 
            this.FixButton.BackColor = System.Drawing.Color.SlateGray;
            this.FixButton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FixButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FixButton.Location = new System.Drawing.Point(428, 557);
            this.FixButton.Name = "FixButton";
            this.FixButton.Size = new System.Drawing.Size(167, 81);
            this.FixButton.TabIndex = 18;
            this.FixButton.Text = "Изменить";
            this.FixButton.UseVisualStyleBackColor = false;
            this.FixButton.Click += new System.EventHandler(this.FixButton_Click);
            // 
            // sortComboBox
            // 
            this.sortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortComboBox.FormattingEnabled = true;
            this.sortComboBox.Items.AddRange(new object[] {
            "По категории" ,
            "По имени",
            "По цене"});
            this.sortComboBox.Location = new System.Drawing.Point(647, 12);
            this.sortComboBox.Name = "sortComboBox";
            this.sortComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sortComboBox.Size = new System.Drawing.Size(121, 23);
            this.sortComboBox.TabIndex = 22;
            this.sortComboBox.SelectedIndexChanged += new System.EventHandler(this.SortComboBox_SelectedIndexChanged);
            // 
            // searchTextBox
            // 
            this.searchTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchTextBox.Location = new System.Drawing.Point(255, 14);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(195, 21);
            this.searchTextBox.TabIndex = 23;
            this.searchTextBox.Text = "Введите текст для поиска";
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            this.searchTextBox.Enter += new System.EventHandler(this.SearchTextBox_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.SearchTextBox_Leave);
         
            this.IdHeader.Width = 0;
        
            this.NameHeader.Text = "Наименование";
            this.NameHeader.Width = 170;

            // NameHeader
            this.CategoryHeader.Text = "Категория";
            this.CategoryHeader.Width = 168;


            this.CostHeader.Text = "Стоимость";
            this.CostHeader.Width = 171;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdHeader,
            this.CategoryHeader,
            this.NameHeader,
            this.CostHeader});
            this.listView1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(255, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(513, 510);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // MedicationCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1005, 650);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.sortComboBox);
            this.Controls.Add(this.FixButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MedicationCatalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medication Catalog";
            this.Resize += new System.EventHandler(this.MedicationCatalog_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button FixButton;
        private System.Windows.Forms.ComboBox sortComboBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private ColumnHeader IdHeader;
        private ColumnHeader CategoryHeader;
        private ColumnHeader NameHeader;
        private ColumnHeader CostHeader;
        private ListView listView1;
    }
}