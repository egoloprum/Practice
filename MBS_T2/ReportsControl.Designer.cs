namespace MBS
{
    partial class ReportsControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bnOrder = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lOrders = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslReportOrder = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrintOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbExportHTMLOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbExportExcellOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lOrderSelect = new System.Windows.Forms.ToolStripLabel();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.bnBatch = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.lBatchs = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslReportBatch = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrintBatch = new System.Windows.Forms.ToolStripButton();
            this.tsbExportHTMLBatch = new System.Windows.Forms.ToolStripButton();
            this.tsbExportExcellBatch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.lBatchSelect = new System.Windows.Forms.ToolStripLabel();
            this.dgvBatch = new System.Windows.Forms.DataGridView();
            this.dgvDosing = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bnOrder)).BeginInit();
            this.bnOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnBatch)).BeginInit();
            this.bnBatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDosing)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnOrder
            // 
            this.bnOrder.AddNewItem = null;
            this.bnOrder.CountItem = this.toolStripLabel1;
            this.bnOrder.CountItemFormat = "из {0}";
            this.bnOrder.DeleteItem = null;
            this.bnOrder.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lOrders,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.tslReportOrder,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator3,
            this.tsbPrintOrder,
            this.tsbExportHTMLOrder,
            this.tsbExportExcellOrder,
            this.toolStripSeparator4,
            this.lOrderSelect});
            this.bnOrder.Location = new System.Drawing.Point(0, 0);
            this.bnOrder.MoveFirstItem = this.toolStripButton1;
            this.bnOrder.MoveLastItem = this.toolStripButton4;
            this.bnOrder.MoveNextItem = this.toolStripButton3;
            this.bnOrder.MovePreviousItem = this.toolStripButton2;
            this.bnOrder.Name = "bnOrder";
            this.bnOrder.PositionItem = this.toolStripTextBox1;
            this.bnOrder.Size = new System.Drawing.Size(1053, 27);
            this.bnOrder.TabIndex = 1;
            this.bnOrder.Text = "Навигация по заказам";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 24);
            this.toolStripLabel1.Text = "из {0}";
            this.toolStripLabel1.ToolTipText = "Общее число элементов";
            // 
            // lOrders
            // 
            this.lOrders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lOrders.Name = "lOrders";
            this.lOrders.Size = new System.Drawing.Size(56, 24);
            this.lOrders.Text = "ЗАКАЗЫ";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "Переместить в начало";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "Переместить назад";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tslReportOrder
            // 
            this.tslReportOrder.Name = "tslReportOrder";
            this.tslReportOrder.Size = new System.Drawing.Size(40, 24);
            this.tslReportOrder.Text = "Заказ ";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Положение";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Текущее положение";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "Переместить вперед";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "Переместить в конец";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(26, 25);
            // 
            // tsbPrintOrder
            // 
            this.tsbPrintOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintOrder.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintOrder.Image")));
            this.tsbPrintOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintOrder.Name = "tsbPrintOrder";
            this.tsbPrintOrder.Size = new System.Drawing.Size(24, 24);
            this.tsbPrintOrder.Text = "&Print";
            this.tsbPrintOrder.ToolTipText = "Печать выбранного заказа (все замесы)";
            this.tsbPrintOrder.Click += new System.EventHandler(this.tsbPrintOrder_Click);
            // 
            // tsbExportHTMLOrder
            // 
            this.tsbExportHTMLOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportHTMLOrder.Image = global::MBS.Properties.Resources.HTML_2__1_;
            this.tsbExportHTMLOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportHTMLOrder.Name = "tsbExportHTMLOrder";
            this.tsbExportHTMLOrder.Size = new System.Drawing.Size(24, 24);
            this.tsbExportHTMLOrder.ToolTipText = "Экспорт в HTML (браузер) выбранного заказа (все замесы)";
            this.tsbExportHTMLOrder.Click += new System.EventHandler(this.tsbExportHTMLOrder_Click);
            // 
            // tsbExportExcellOrder
            // 
            this.tsbExportExcellOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportExcellOrder.Image = global::MBS.Properties.Resources._1440864433_excel;
            this.tsbExportExcellOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportExcellOrder.Name = "tsbExportExcellOrder";
            this.tsbExportExcellOrder.Size = new System.Drawing.Size(24, 24);
            this.tsbExportExcellOrder.ToolTipText = "Экспорт в Excel выбранного заказа (все замесы)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(26, 25);
            // 
            // lOrderSelect
            // 
            this.lOrderSelect.Name = "lOrderSelect";
            this.lOrderSelect.Size = new System.Drawing.Size(0, 24);
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            this.dgvOrder.AllowUserToDeleteRows = false;
            this.dgvOrder.AllowUserToResizeColumns = false;
            this.dgvOrder.AllowUserToResizeRows = false;
            this.dgvOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrder.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrder.ColumnHeadersHeight = 34;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvOrder.EnableHeadersVisualStyles = false;
            this.dgvOrder.Location = new System.Drawing.Point(0, 27);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOrder.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.Size = new System.Drawing.Size(1053, 100);
            this.dgvOrder.TabIndex = 2;
            this.dgvOrder.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_RowEnter);
            this.dgvOrder.SelectionChanged += new System.EventHandler(this.dgvOrder_SelectionChanged);
            // 
            // bnBatch
            // 
            this.bnBatch.AddNewItem = null;
            this.bnBatch.CountItem = this.bindingNavigatorCountItem1;
            this.bnBatch.CountItemFormat = "из {0}";
            this.bnBatch.DeleteItem = null;
            this.bnBatch.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bnBatch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lBatchs,
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.tslReportBatch,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.tsbPrintBatch,
            this.tsbExportHTMLBatch,
            this.tsbExportExcellBatch,
            this.toolStripSeparator5,
            this.lBatchSelect});
            this.bnBatch.Location = new System.Drawing.Point(0, 127);
            this.bnBatch.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bnBatch.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bnBatch.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bnBatch.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bnBatch.Name = "bnBatch";
            this.bnBatch.PositionItem = this.bindingNavigatorPositionItem1;
            this.bnBatch.Size = new System.Drawing.Size(1053, 27);
            this.bnBatch.TabIndex = 3;
            this.bnBatch.Text = "Навигация по замесам";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(36, 24);
            this.bindingNavigatorCountItem1.Text = "из {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Общее число элементов";
            // 
            // lBatchs
            // 
            this.lBatchs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lBatchs.Name = "lBatchs";
            this.lBatchs.Size = new System.Drawing.Size(57, 24);
            this.lBatchs.Text = "ЗАМЕСЫ";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem1.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem1.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tslReportBatch
            // 
            this.tslReportBatch.Name = "tslReportBatch";
            this.tslReportBatch.Size = new System.Drawing.Size(41, 24);
            this.tslReportBatch.Text = "Замес";
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem1.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem1.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.AutoSize = false;
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(26, 25);
            // 
            // tsbPrintBatch
            // 
            this.tsbPrintBatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintBatch.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintBatch.Image")));
            this.tsbPrintBatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintBatch.Name = "tsbPrintBatch";
            this.tsbPrintBatch.Size = new System.Drawing.Size(24, 24);
            this.tsbPrintBatch.Text = "&Print";
            this.tsbPrintBatch.ToolTipText = "Печать выбранного замеса";
            this.tsbPrintBatch.Click += new System.EventHandler(this.tsbPrintBatch_Click);
            // 
            // tsbExportHTMLBatch
            // 
            this.tsbExportHTMLBatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportHTMLBatch.Image = global::MBS.Properties.Resources.HTML_2__1_;
            this.tsbExportHTMLBatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportHTMLBatch.Name = "tsbExportHTMLBatch";
            this.tsbExportHTMLBatch.Size = new System.Drawing.Size(24, 24);
            this.tsbExportHTMLBatch.ToolTipText = "Экспорт в HTML (браузер) выбранного замеса";
            this.tsbExportHTMLBatch.Click += new System.EventHandler(this.tsbExportHTMLBatch_Click);
            // 
            // tsbExportExcellBatch
            // 
            this.tsbExportExcellBatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExportExcellBatch.Image = global::MBS.Properties.Resources._1440864433_excel;
            this.tsbExportExcellBatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExportExcellBatch.Name = "tsbExportExcellBatch";
            this.tsbExportExcellBatch.Size = new System.Drawing.Size(24, 24);
            this.tsbExportExcellBatch.Text = "toolStripButton5";
            this.tsbExportExcellBatch.ToolTipText = "Экспорт в Excel выбранного замеса";
            this.tsbExportExcellBatch.Click += new System.EventHandler(this.tsbExportExcellBatch_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(26, 25);
            // 
            // lBatchSelect
            // 
            this.lBatchSelect.Name = "lBatchSelect";
            this.lBatchSelect.Size = new System.Drawing.Size(0, 24);
            // 
            // dgvBatch
            // 
            this.dgvBatch.AllowUserToAddRows = false;
            this.dgvBatch.AllowUserToDeleteRows = false;
            this.dgvBatch.AllowUserToResizeRows = false;
            this.dgvBatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBatch.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBatch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBatch.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBatch.EnableHeadersVisualStyles = false;
            this.dgvBatch.Location = new System.Drawing.Point(0, 154);
            this.dgvBatch.Name = "dgvBatch";
            this.dgvBatch.ReadOnly = true;
            this.dgvBatch.RowHeadersVisible = false;
            this.dgvBatch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBatch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBatch.Size = new System.Drawing.Size(1053, 100);
            this.dgvBatch.TabIndex = 4;
            this.dgvBatch.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBatch_RowEnter);
            this.dgvBatch.SelectionChanged += new System.EventHandler(this.dgvBatch_SelectionChanged);
            // 
            // dgvDosing
            // 
            this.dgvDosing.AllowUserToAddRows = false;
            this.dgvDosing.AllowUserToDeleteRows = false;
            this.dgvDosing.AllowUserToResizeRows = false;
            this.dgvDosing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDosing.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDosing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDosing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDosing.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDosing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDosing.EnableHeadersVisualStyles = false;
            this.dgvDosing.Location = new System.Drawing.Point(0, 3);
            this.dgvDosing.Name = "dgvDosing";
            this.dgvDosing.ReadOnly = true;
            this.dgvDosing.RowHeadersVisible = false;
            this.dgvDosing.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDosing.Size = new System.Drawing.Size(1053, 110);
            this.dgvDosing.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDosing);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 254);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel1.Size = new System.Drawing.Size(1053, 113);
            this.panel1.TabIndex = 6;
            // 
            // ReportsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvBatch);
            this.Controls.Add(this.bnBatch);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.bnOrder);
            this.Name = "ReportsControl";
            this.Size = new System.Drawing.Size(1053, 367);
            ((System.ComponentModel.ISupportInitialize)(this.bnOrder)).EndInit();
            this.bnOrder.ResumeLayout(false);
            this.bnOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnBatch)).EndInit();
            this.bnBatch.ResumeLayout(false);
            this.bnBatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDosing)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnOrder;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslReportOrder;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.BindingNavigator bnBatch;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripLabel tslReportBatch;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.DataGridView dgvBatch;
        private System.Windows.Forms.ToolStripLabel lOrderSelect;
        private System.Windows.Forms.ToolStripLabel lBatchSelect;
        private System.Windows.Forms.DataGridView dgvDosing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton tsbExportExcellOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbExportExcellBatch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbExportHTMLOrder;
        private System.Windows.Forms.ToolStripButton tsbExportHTMLBatch;
        private System.Windows.Forms.ToolStripButton tsbPrintOrder;
        private System.Windows.Forms.ToolStripButton tsbPrintBatch;
        private System.Windows.Forms.ToolStripLabel lOrders;
        private System.Windows.Forms.ToolStripLabel lBatchs;
    }
}
