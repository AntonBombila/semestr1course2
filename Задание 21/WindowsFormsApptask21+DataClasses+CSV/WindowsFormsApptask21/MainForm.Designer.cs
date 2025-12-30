namespace WindowsFormsApptask21
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.comboBoxQueries = new System.Windows.Forms.ComboBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.checkBoxRegular = new System.Windows.Forms.CheckBox();
            this.numericUpDownProductId = new System.Windows.Forms.NumericUpDown();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.buttonAddToCart = new System.Windows.Forms.Button();
            this.buttonRemoveFromCart = new System.Windows.Forms.Button();
            this.buttonClearCart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(24, 192);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 82;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1102, 577);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // comboBoxQueries
            // 
            this.comboBoxQueries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQueries.FormattingEnabled = true;
            this.comboBoxQueries.Location = new System.Drawing.Point(24, 23);
            this.comboBoxQueries.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxQueries.Name = "comboBoxQueries";
            this.comboBoxQueries.Size = new System.Drawing.Size(396, 33);
            this.comboBoxQueries.TabIndex = 1;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(441, 23);
            this.textBoxFilter.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(296, 31);
            this.textBoxFilter.TabIndex = 2;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(1160, 23);
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(18, 17, 18, 17);
            this.monthCalendar.MaxSelectionCount = 31;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 3;
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(24, 96);
            this.buttonExecute.Margin = new System.Windows.Forms.Padding(6);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(200, 58);
            this.buttonExecute.TabIndex = 4;
            this.buttonExecute.Text = "Выполнить";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // checkBoxRegular
            // 
            this.checkBoxRegular.AutoSize = true;
            this.checkBoxRegular.Location = new System.Drawing.Point(236, 110);
            this.checkBoxRegular.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxRegular.Name = "checkBoxRegular";
            this.checkBoxRegular.Size = new System.Drawing.Size(241, 29);
            this.checkBoxRegular.TabIndex = 5;
            this.checkBoxRegular.Text = "Постоянный клиент";
            this.checkBoxRegular.UseVisualStyleBackColor = true;
            // 
            // numericUpDownProductId
            // 
            this.numericUpDownProductId.Location = new System.Drawing.Point(992, 113);
            this.numericUpDownProductId.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownProductId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownProductId.Name = "numericUpDownProductId";
            this.numericUpDownProductId.Size = new System.Drawing.Size(120, 31);
            this.numericUpDownProductId.TabIndex = 6;
            this.numericUpDownProductId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotal.Location = new System.Drawing.Point(24, 788);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(108, 31);
            this.labelTotal.TabIndex = 7;
            this.labelTotal.Text = "Итого: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Фильтр";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(733, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "ID проданного товара : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1156, 352);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Период";
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.Location = new System.Drawing.Point(992, 67);
            this.numericUpDownQuantity.Margin = new System.Windows.Forms.Padding(6);
            this.numericUpDownQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 31);
            this.numericUpDownQuantity.TabIndex = 11;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.ValueChanged += new System.EventHandler(this.numericUpDownQuantity_ValueChanged);
            // 
            // buttonAddToCart
            // 
            this.buttonAddToCart.BackColor = System.Drawing.Color.LightGreen;
            this.buttonAddToCart.Location = new System.Drawing.Point(1170, 434);
            this.buttonAddToCart.Margin = new System.Windows.Forms.Padding(6);
            this.buttonAddToCart.Name = "buttonAddToCart";
            this.buttonAddToCart.Size = new System.Drawing.Size(220, 58);
            this.buttonAddToCart.TabIndex = 12;
            this.buttonAddToCart.Text = "Добавить в корзину";
            this.buttonAddToCart.UseVisualStyleBackColor = false;
            this.buttonAddToCart.Click += new System.EventHandler(this.ButtonAddToCart_Click);
            // 
            // buttonRemoveFromCart
            // 
            this.buttonRemoveFromCart.BackColor = System.Drawing.Color.LightCoral;
            this.buttonRemoveFromCart.Enabled = false;
            this.buttonRemoveFromCart.Location = new System.Drawing.Point(1170, 544);
            this.buttonRemoveFromCart.Margin = new System.Windows.Forms.Padding(6);
            this.buttonRemoveFromCart.Name = "buttonRemoveFromCart";
            this.buttonRemoveFromCart.Size = new System.Drawing.Size(220, 58);
            this.buttonRemoveFromCart.TabIndex = 13;
            this.buttonRemoveFromCart.Text = "Удалить из корзины";
            this.buttonRemoveFromCart.UseVisualStyleBackColor = false;
            this.buttonRemoveFromCart.Click += new System.EventHandler(this.ButtonRemoveFromCart_Click);
            // 
            // buttonClearCart
            // 
            this.buttonClearCart.BackColor = System.Drawing.Color.LightYellow;
            this.buttonClearCart.Location = new System.Drawing.Point(1170, 680);
            this.buttonClearCart.Margin = new System.Windows.Forms.Padding(6);
            this.buttonClearCart.Name = "buttonClearCart";
            this.buttonClearCart.Size = new System.Drawing.Size(220, 58);
            this.buttonClearCart.TabIndex = 14;
            this.buttonClearCart.Text = "Очистить корзину";
            this.buttonClearCart.UseVisualStyleBackColor = false;
            this.buttonClearCart.Click += new System.EventHandler(this.ButtonClearCart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(733, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Количество товара:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 887);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonClearCart);
            this.Controls.Add(this.buttonRemoveFromCart);
            this.Controls.Add(this.buttonAddToCart);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.numericUpDownProductId);
            this.Controls.Add(this.checkBoxRegular);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.comboBoxQueries);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "Магазин оргтехники - LINQ запросы";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownProductId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox comboBoxQueries;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.CheckBox checkBoxRegular;
        private System.Windows.Forms.NumericUpDown numericUpDownProductId;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button buttonAddToCart;
        private System.Windows.Forms.Button buttonRemoveFromCart;
        private System.Windows.Forms.Button buttonClearCart;
        private System.Windows.Forms.Label label4;
    }
}