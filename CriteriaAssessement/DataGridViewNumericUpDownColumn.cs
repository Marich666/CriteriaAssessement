using System;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;

namespace DataGridViewNumericUpDownElements
{
    /// <summary>
    /// Custom column type dedicated to the DataGridViewNumericUpDownCell cell type.
    /// </summary>
    public class DataGridViewNumericUpDownColumn : DataGridViewColumn
    {
        /// <summary>
        /// Constructor for the DataGridViewNumericUpDownColumn class.
        /// </summary>
        public DataGridViewNumericUpDownColumn() : base(new DataGridViewNumericUpDownCell())
        {
        }

        /// <summary>
        /// Represents the implicit cell that gets cloned when adding rows to the grid.
        /// </summary>
        [
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                DataGridViewNumericUpDownCell dataGridViewNumericUpDownCell = value as DataGridViewNumericUpDownCell;
                if (value != null && dataGridViewNumericUpDownCell == null)
                {
                    throw new InvalidCastException("Value provided for CellTemplate must be of type DataGridViewNumericUpDownElements.DataGridViewNumericUpDownCell or derive from it.");
                }
                base.CellTemplate = value;
            }
        }

        /// <summary>
        /// Свойство DecimalPlaces позволяет получить или задать количество знаков после запятой
        /// </summary>
        public int DecimalPlaces
        {
            get
            {
                // Проверка на наличие шаблона ячейки типа NumericUpDown
                if (this.NumericUpDownCellTemplate == null)
                    // Генерация исключения из-за недопустимого для текущего состояния объекта
                    throw new InvalidOperationException("Действие не может быть выполнено");
                // Возврат  значения свойства DecimalPlaces
                return this.NumericUpDownCellTemplate.DecimalPlaces;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                    throw new InvalidOperationException("Действие не может быть выполнено");
                // Обновление ячейки шаблона, чтобы последующие клонированные ячейки
                // использовали новое значение
                this.NumericUpDownCellTemplate.DecimalPlaces = value;
                if (this.DataGridView != null)
                {
                    // Обновление всех существующих ячеек DataGridViewNumericUpDownCell в столбце
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        DataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index]
                            as DataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                            // Вызов внутреннего метода SetDecimalPlaces вместо свойства, 
                            // чтобы избежать аннулирования ячеек
                            dataGridViewCell.SetDecimalPlaces(rowIndex, value);
                    }
                    // Выов метода, который делает недействительным указанный столбец объекта DataGridView,
                    // принудительно вызывая его повторную перерисовку
                    this.DataGridView.InvalidateColumn(this.Index);
                }
            }
        }

        /// <summary>
        /// Replicates the Increment property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            Description("Indicates the amount to increment or decrement on each button click.")
        ]
        public Decimal Increment
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.Increment;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.NumericUpDownCellTemplate.Increment = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        DataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.SetIncrement(rowIndex, value);
                        }
                    }
                }
            }
        }

        /// Indicates whether the Increment property should be persisted.
        private bool ShouldSerializeIncrement()
        {
            return !this.Increment.Equals(DataGridViewNumericUpDownCell.DATAGRIDVIEWNUMERICUPDOWNCELL_defaultIncrement);
        }

        /// <summary>
        /// Replicates the Maximum property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            Description("Indicates the maximum value for the numeric up-down cells."),
            RefreshProperties(RefreshProperties.All)
        ]
        public Decimal Maximum
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.Maximum;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.NumericUpDownCellTemplate.Maximum = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        DataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.SetMaximum(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: This column and/or grid rows may need to be autosized depending on their
                    //       autosize settings. Call the autosizing methods to autosize the column, rows, 
                    //       column headers / row headers as needed.
                }
            }
        }

        /// Indicates whether the Maximum property should be persisted.
        private bool ShouldSerializeMaximum()
        {
            return !this.Maximum.Equals(DataGridViewNumericUpDownCell.DATAGRIDVIEWNUMERICUPDOWNCELL_defaultMaximum);
        }

        /// <summary>
        /// Replicates the Minimum property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            Description("Indicates the minimum value for the numeric up-down cells."),
            RefreshProperties(RefreshProperties.All)
        ]
        public Decimal Minimum
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.Minimum;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.NumericUpDownCellTemplate.Minimum = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        DataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.SetMinimum(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: This column and/or grid rows may need to be autosized depending on their
                    //       autosize settings. Call the autosizing methods to autosize the column, rows, 
                    //       column headers / row headers as needed.
                }
            }
        }

        /// Indicates whether the Maximum property should be persisted.
        private bool ShouldSerializeMinimum()
        {
            return !this.Minimum.Equals(DataGridViewNumericUpDownCell.DATAGRIDVIEWNUMERICUPDOWNCELL_defaultMinimum);
        }

        /// <summary>
        /// Replicates the ThousandsSeparator property of the DataGridViewNumericUpDownCell cell type.
        /// </summary>
        [
            Category("Data"),
            DefaultValue(DataGridViewNumericUpDownCell.DATAGRIDVIEWNUMERICUPDOWNCELL_defaultThousandsSeparator),
            Description("Indicates whether the thousands separator will be inserted between every three decimal digits.")
        ]
        public bool ThousandsSeparator
        {
            get
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.NumericUpDownCellTemplate.ThousandsSeparator;
            }
            set
            {
                if (this.NumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.NumericUpDownCellTemplate.ThousandsSeparator = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        DataGridViewNumericUpDownCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewNumericUpDownCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.SetThousandsSeparator(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);
                    // TODO: This column and/or grid rows may need to be autosized depending on their
                    //       autosize settings. Call the autosizing methods to autosize the column, rows, 
                    //       column headers / row headers as needed.
                }
            }
        }

        /// <summary>
        /// Small utility function that returns the template cell as a DataGridViewNumericUpDownCell
        /// </summary>
        private DataGridViewNumericUpDownCell NumericUpDownCellTemplate
        {
            get
            {
                return (DataGridViewNumericUpDownCell)this.CellTemplate;
            }
        }

        /// <summary>
        /// Returns a standard compact string representation of the column.
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(100);
            sb.Append("DataGridViewNumericUpDownColumn { Name=");
            sb.Append(this.Name);
            sb.Append(", Index=");
            sb.Append(this.Index.ToString(CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
