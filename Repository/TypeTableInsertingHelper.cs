using System.ComponentModel;
using System.Data;

namespace ShoppingCartProject.Repository
{
    public class TypeTableInsertingHelper
    {
        public DataTable typeTableCreate<T1, T2>(T1 typeTable, T2 typeData, string typeTableName) where T1 : class where T2 : class
        {
            DataTable dataTable = new(typeTableName);
            foreach (var messageDetailColumnFieled in typeTable.GetType().GetProperties())
            {
                dataTable.Columns.Add(messageDetailColumnFieled.Name);
            }



            DataRow myDataRow = dataTable.NewRow();
            foreach (var messageHeaderTableRowValue in typeData.GetType().GetProperties())
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.ColumnName == messageHeaderTableRowValue.Name)
                    {
                        myDataRow[column.ColumnName] = messageHeaderTableRowValue.GetValue(typeData);
                    }
                }
            }
            dataTable.Rows.Add(myDataRow);
            return dataTable;
        }

        public DataTable typeTableCreateList<T1, T2>(T1 typeTable, List<T2> typeDataes, string typeTableName) where T1 : class where T2 : class
        {
            DataTable dataTable = new(typeTableName);
            foreach (var messageDetailColumnFieled in typeTable.GetType().GetProperties())
            {
                dataTable.Columns.Add(messageDetailColumnFieled.Name);
            }

            foreach (var typeData in typeDataes)
            {
                DataRow myDataRow = dataTable.NewRow();
                foreach (var messageHeaderTableRowValue in typeData.GetType().GetProperties())
                {
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        Console.WriteLine(typeData.GetType().GetProperties());
                        if (column.ColumnName == messageHeaderTableRowValue.Name)
                        {
                            myDataRow[column.ColumnName] = messageHeaderTableRowValue.GetValue(typeData);
                        }
                    }
                }
                dataTable.Rows.Add(myDataRow);
            }
            return dataTable;
        }
        public DataTable ConvertToDataTable<T>(T item, string typeTableName) where T : class
        {
            return ConvertToDataTable(new List<T> { item }, typeTableName);
        }
        public DataTable ConvertToDataTable<T>(List<T> items, string typeTableName) where T : class
        {


            var dt = new DataTable(typeTableName);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));



            foreach (PropertyDescriptor prop in properties)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            if (items == null || items.Count == 0)
                return dt;

            foreach (T item in items)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}
