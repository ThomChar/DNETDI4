using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacchus
{
    class SQLITE
    {
        private SQLiteConnection con;
        private SQLiteCommand cmd;
        private SQLiteDataAdapter adapter;

        public SQLITE(string databasename){
            con = new SQLiteConnection(string.Format("Data Source={0};Compress=True;", databasename));
        }

        public int Execute(string sql_statement){
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = sql_statement;
            int row_updated;
            try
            {
                row_updated = cmd.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
                return 0;
            }
            con.Close();
            return row_updated;
        }

        public DataTable GetDataTable(string tablename){
            DataTable DT = new DataTable();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM {0}", tablename);
            adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(DT);
            con.Close();
            DT.TableName = tablename;
            return DT;
        }

        public void SaveDataTable(DataTable DT){
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM {0}", DT.TableName);
                adapter = new SQLiteDataAdapter(cmd);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
                adapter.Update(DT);
                con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}

