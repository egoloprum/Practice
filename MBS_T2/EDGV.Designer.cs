namespace MBS
{
    partial class EDGV
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EDGV));
            this.BN = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsbExportHTML = new System.Windows.Forms.ToolStripButton();
            this.tsbExportExcell = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearFilterButton = new System.Windows.Forms.ToolStripButton();
            this.clearSortButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.lSetWeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.SetWeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.lDoneWeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.DoneWeight = new System.Windows.Forms.ToolStripStatusLabel();
            this.lDiff = new System.Windows.Forms.ToolStripStatusLabel();
            this.Diff_kg = new System.Windows.Forms.ToolStripStatusLabel();
            this.lDiff_kg = new System.Windows.Forms.ToolStripStatusLabel();
            this.Diff_prc = new System.Windows.Forms.ToolStripStatusLabel();
            this.lDiff_prc = new System.Windows.Forms.ToolStripStatusLabel();
            this.DGV = new ADGV.AdvancedDataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.BN)).BeginInit();
            this.BN.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BN
            // 
            this.BN.AddNewItem = null;
            this.BN.CountItem = this.bindingNavigatorCountItem;
            this.BN.CountItemFormat = "из {0}";
            this.BN.DeleteItem = null;
            this.BN.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.BN.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.printToolStripButton,
            this.tsbExportHTML,
            this.tsbExportExcell,
            this.toolStripSeparator,
            this.refreshToolStripButton,
            this.toolStripSeparator1,
            this.clearFilterButton,
            this.clearSortButton});
            this.BN.Location = new System.Drawing.Point(0, 0);
            this.BN.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN.Name = "BN";
            this.BN.PositionItem = this.bindingNavigatorPositionItem;
            this.BN.Size = new System.Drawing.Size(704, 27);
            this.BN.TabIndex = 0;
            this.BN.Text = "Навигация";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 24);
            this.bindingNavigatorCountItem.Text = "из {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.AutoSize = false;
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(26, 27);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.ToolTipText = "Печать";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // tsbExportHTML
            // 
            this.tsbExportHTML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportHTML.Image = global::MBS.Properties.Resources.HTML_2__1_;
            this.tsbExportHTML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportHTML.Name = "tsbExportHTML";
            this.tsbExportHTML.Size = new System.Drawing.Size(24, 24);
            this.tsbExportHTML.ToolTipText = "Экспорт в HTML (браузер)";
            this.tsbExportHTML.Click += new System.EventHandler(this.tsbExportHTML_Click);
            // 
            // tsbExportExcell
            // 
            this.tsbExportExcell.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportExcell.Image = global::MBS.Properties.Resources._1440864433_excel;
            this.tsbExportExcell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportExcell.Name = "tsbExportExcell";
            this.tsbExportExcell.Size = new System.Drawing.Size(24, 24);
            this.tsbExportExcell.Text = "&ExportExcell";
            this.tsbExportExcell.ToolTipText = "Экспорт в Excell";
            this.tsbExportExcell.Click += new System.EventHandler(this.tsbExportExcell_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.AutoSize = false;
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(26, 27);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::MBS.Properties.Resources._1439474354_gtk_refresh;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.refreshToolStripButton.Text = "toolStripButton1";
            this.refreshToolStripButton.ToolTipText = "Обновить";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(26, 27);
            // 
            // clearFilterButton
            // 
            this.clearFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearFilterButton.Image = global::MBS.Properties.Resources._139_1394711_leerer_filter_icon_filtro_de_excel_icono_4_;
            this.clearFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearFilterButton.Name = "clearFilterButton";
            this.clearFilterButton.Size = new System.Drawing.Size(24, 24);
            this.clearFilterButton.Text = "toolStripButton1";
            this.clearFilterButton.ToolTipText = "Сбросить фильтр";
            this.clearFilterButton.Click += new System.EventHandler(this.clearFilterButton_Click);
            // 
            // clearSortButton
            // 
            this.clearSortButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearSortButton.Image = global::MBS.Properties.Resources.png_clipart_sorting_algorithm_computer_icons_others_blue_angle_1__2_;
            this.clearSortButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearSortButton.Name = "clearSortButton";
            this.clearSortButton.Size = new System.Drawing.Size(24, 24);
            this.clearSortButton.Text = "toolStripButton2";
            this.clearSortButton.ToolTipText = "Сбросить сортировку";
            this.clearSortButton.Click += new System.EventHandler(this.clearSortButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lSum,
            this.lSetWeight,
            this.SetWeight,
            this.lDoneWeight,
            this.DoneWeight,
            this.lDiff,
            this.Diff_kg,
            this.lDiff_kg,
            this.Diff_prc,
            this.lDiff_prc});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 29);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lSum
            // 
            this.lSum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lSum.Name = "lSum";
            this.lSum.Size = new System.Drawing.Size(46, 17);
            this.lSum.Text = "ВСЕГО:";
            // 
            // lSetWeight
            // 
            this.lSetWeight.Name = "lSetWeight";
            this.lSetWeight.Size = new System.Drawing.Size(140, 17);
            this.lSetWeight.Text = "                  Заданный вес:";
            // 
            // SetWeight
            // 
            this.SetWeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SetWeight.Name = "SetWeight";
            this.SetWeight.Size = new System.Drawing.Size(14, 17);
            this.SetWeight.Text = "0";
            // 
            // lDoneWeight
            // 
            this.lDoneWeight.Name = "lDoneWeight";
            this.lDoneWeight.Size = new System.Drawing.Size(168, 17);
            this.lDoneWeight.Text = "кг                  Полученный вес:";
            // 
            // DoneWeight
            // 
            this.DoneWeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.DoneWeight.Name = "DoneWeight";
            this.DoneWeight.Size = new System.Drawing.Size(14, 17);
            this.DoneWeight.Text = "0";
            // 
            // lDiff
            // 
            this.lDiff.Name = "lDiff";
            this.lDiff.Size = new System.Drawing.Size(120, 17);
            this.lDiff.Text = "кг                  Разница:";
            // 
            // Diff_kg
            // 
            this.Diff_kg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Diff_kg.Name = "Diff_kg";
            this.Diff_kg.Size = new System.Drawing.Size(14, 17);
            this.Diff_kg.Text = "0";
            // 
            // lDiff_kg
            // 
            this.lDiff_kg.Name = "lDiff_kg";
            this.lDiff_kg.Size = new System.Drawing.Size(54, 17);
            this.lDiff_kg.Text = "кг            ";
            // 
            // Diff_prc
            // 
            this.Diff_prc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Diff_prc.Name = "Diff_prc";
            this.Diff_prc.Size = new System.Drawing.Size(14, 17);
            this.Diff_prc.Text = "0";
            // 
            // lDiff_prc
            // 
            this.lDiff_prc.Name = "lDiff_prc";
            this.lDiff_prc.Size = new System.Drawing.Size(17, 17);
            this.lDiff_prc.Text = "%";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AutoGenerateContextFilters = true;
            this.DGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.DateWithTime = false;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.Size = new System.Drawing.Size(704, 296);
            this.DGV.TabIndex = 1;
            this.DGV.TimeFilter = false;
            this.DGV.SortStringChanged += new System.EventHandler(this.SortStringChanged);
            this.DGV.FilterStringChanged += new System.EventHandler(this.FilterStringChanged);
            this.DGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellDoubleClick);
            this.DGV.SizeChanged += new System.EventHandler(this.DGV_SizeChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DGV);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(704, 326);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 4;
            // 
            // EDGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.BN);
            this.Name = "EDGV";
            this.Size = new System.Drawing.Size(704, 353);
            ((System.ComponentModel.ISupportInitialize)(this.BN)).EndInit();
            this.BN.ResumeLayout(false);
            this.BN.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator BN;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton tsbExportExcell;
        private System.Windows.Forms.ToolStripButton clearFilterButton;
        private System.Windows.Forms.ToolStripButton clearSortButton;
        private System.Windows.Forms.ToolStripButton tsbExportHTML;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lSum;
        private System.Windows.Forms.ToolStripStatusLabel lSetWeight;
        private System.Windows.Forms.ToolStripStatusLabel SetWeight;
        private System.Windows.Forms.ToolStripStatusLabel lDoneWeight;
        private System.Windows.Forms.ToolStripStatusLabel DoneWeight;
        private System.Windows.Forms.ToolStripStatusLabel lDiff;
        private System.Windows.Forms.ToolStripStatusLabel Diff_kg;
        private System.Windows.Forms.ToolStripStatusLabel lDiff_kg;
        private System.Windows.Forms.ToolStripStatusLabel Diff_prc;
        private System.Windows.Forms.ToolStripStatusLabel lDiff_prc;
        public ADGV.AdvancedDataGridView DGV;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
