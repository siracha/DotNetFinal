using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JadeThomas_Final
{
    class DBInterface
    {
        private string _query = "SELECT * FROM Users";
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        private SqlCommandBuilder _cmdBuilder;
        //In the disconnected scenario, the data retrieved from the database is stored in a local buffer called DataSet
        private DataSet _dataSet;
        private DataTable _theTable;

        public DBInterface()
        {
            this._conn = new SqlConnection("Server=(local);Database=Final;User=ADMIN;Password=ADMIN");
            _adapter = new SqlDataAdapter(_query, _conn);
            _cmdBuilder = new SqlCommandBuilder(_adapter);

            FillDataSet();
        }
        public DBInterface(string conn_str)
        {
            this._conn = new SqlConnection(conn_str);
            _adapter = new SqlDataAdapter(_query, _conn);
            _cmdBuilder = new SqlCommandBuilder(_adapter);

            FillDataSet();
        }
        public DBInterface(string conn_str, string query)
        {
            this._conn = new SqlConnection(conn_str);
            _adapter = new SqlDataAdapter(query, _conn);
            _cmdBuilder = new SqlCommandBuilder(_adapter);

            FillDataSet();
        }

        private void FillDataSet()
        {
            //reset the dataset
            _dataSet = new DataSet();

            _adapter.Fill(_dataSet);
            _theTable = _dataSet.Tables[0];

            //define primary key
            DataColumn[] pk = new DataColumn[1];
            pk[0] = _theTable.Columns["userID"];
            _theTable.PrimaryKey = pk;
        }

        private void insertUser(Member player)
        {
            DataRow newRow = _theTable.NewRow();
            newRow["userID"] = 0;

            newRow["username"] = player._name;
            newRow["pass"] = player._password;
            newRow["score"] = player._score;
            newRow["spec_score"] = player._spec_score;
            newRow["regis_date"] = player._date;
            newRow["good_guess"] = player._good_guess;
            newRow["bad_guess"] = player._bad_guess;
            newRow["score"] = player._score;
            newRow["email"] = player._email;
            _theTable.Rows.Add(newRow);

            _adapter.InsertCommand = _cmdBuilder.GetInsertCommand();
            _adapter.Update(_theTable);
            FillDataSet();
        }

        private void updateUser(Member player)
        {
            DataRow row = _theTable.Rows.Find(player._userID);

            if (row != null)
            {
                row["username"] = player._name;
                row["pass"] = player._password;
                row["score"] = player._score;
                row["spec_score"] = player._spec_score;
                row["regis_date"] = player._date;
                row["good_guess"] = player._good_guess;
                row["bad_guess"] = player._bad_guess;
                row["score"] = player._score;
                row["email"] = player._email;

                _adapter.UpdateCommand = _cmdBuilder.GetUpdateCommand();
                _adapter.Update(_theTable);

                FillDataSet();
            }
            else
                Console.WriteLine("\nInvalid product id. please try again.");
        }

        private void deleteUser(Member player)
        {
            DataRow row = _theTable.Rows.Find(player._userID);

            if (row != null)
            {
                row.Delete();

                _adapter.DeleteCommand = _cmdBuilder.GetDeleteCommand();
                _adapter.Update(_theTable);

                FillDataSet();
            }
            else
                Console.WriteLine("\nInvalid product id. please try again.");
        }
    }
}
