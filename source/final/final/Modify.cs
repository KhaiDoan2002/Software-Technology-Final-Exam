using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace final
{
    class Modify
    {
        SqlDataAdapter dataAdapter;     // xuất dữ liệu từ bảng
        SqlCommand sqlCommand;          // truy cập vào dữ liệu của bảng
        public Modify() { }


        public DataTable warehouse()
        {
            DataTable dataTable = new DataTable();
            String query = "select * from warehouse";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        // Import
        public DataTable Import()
        {
            DataTable dataTable = new DataTable();
            String query = "select * from Imports";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        // thêm dữ liệu vào bảng goods,imports
        public bool Imports(Import import)
        {
            if (import.Quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0");
                return false;
            }
            SqlConnection sqlConnection = Connection.getConnection();
            String query_updateWarehouse = "update warehouse set Quantity=@Quantity+Quantity where GoodsId=@goodsid and GoodsUnit = @goodsunit";
            String query_import = "insert into Imports values (@AccountantId,@GoodsId,@GoodsUnit,@Quantity,@TotalPrice,@ImportDate)";
            String query_insertWarehouse = "insert into warehouse values (@GoodsId,@GoodsUnit,@Quantity)";
            try
            {
                Decimal TotalPrice=0;
                String getGoodsPrice = "select GoodsPrice from Goods where GoodsId = @goodsid and GoodsUnit = @goodsunit";
                sqlConnection.Open();
                sqlCommand = new SqlCommand(getGoodsPrice, sqlConnection);
                sqlCommand.Parameters.Add("@goodsid", SqlDbType.VarChar).Value = import.GoodsId;
                sqlCommand.Parameters.Add("@goodsunit", SqlDbType.VarChar).Value = import.GoodsUnit;
                if(sqlCommand.ExecuteScalar()!=null)
                {
                    Decimal price = (Decimal)sqlCommand.ExecuteScalar();
                    TotalPrice = price * import.Quantity;
                }
                sqlConnection.Close();
                sqlConnection.Open();
                //same AccountantID, GoodsID, GoodsUnit, Date
                String getSame = "select * from Imports where AccountantId = @accountantid and GoodsId = @goodsid and GoodsUnit = @goodsunit and ImportDate = @date";
                sqlCommand = new SqlCommand(getSame, sqlConnection);
                sqlCommand.Parameters.Add("@goodsid", SqlDbType.VarChar).Value = import.GoodsId;
                sqlCommand.Parameters.Add("@goodsunit", SqlDbType.VarChar).Value = import.GoodsUnit;
                sqlCommand.Parameters.Add("@accountantid", SqlDbType.VarChar).Value = import.AccountantId;
                sqlCommand.Parameters.Add("@date", SqlDbType.Date).Value = import.ImportDate;

                if (sqlCommand.ExecuteReader().HasRows)
                {
                    sqlConnection.Close();
                    sqlConnection.Open();

                    //update table Imports
                    String query_updateImport = "update Imports set Quantity=@Quantity+Quantity,TotalPrice=@TotalPrice+TotalPrice where AccountantId = @accountantid and GoodsId=@goodsid and GoodsUnit = @goodsunit and ImportDate=@date";
                    sqlCommand = new SqlCommand(query_updateImport, sqlConnection);
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = import.Quantity;
                    sqlCommand.Parameters.Add("@TotalPrice", SqlDbType.Float).Value = TotalPrice;
                    sqlCommand.Parameters.Add("@goodsid", SqlDbType.VarChar).Value = import.GoodsId;
                    sqlCommand.Parameters.Add("@goodsunit", SqlDbType.VarChar).Value = import.GoodsUnit;
                    sqlCommand.Parameters.Add("@accountantid", SqlDbType.VarChar).Value = import.AccountantId;
                    sqlCommand.Parameters.Add("@date", SqlDbType.Date).Value = import.ImportDate;
                    sqlCommand.ExecuteReader();

                    // update table warehouse
                    sqlConnection.Close();
                    sqlConnection.Open();

                    sqlCommand = new SqlCommand(query_updateWarehouse, sqlConnection);
                    sqlCommand.Parameters.Add("@goodsid", SqlDbType.VarChar).Value = import.GoodsId;
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = import.Quantity;
                    sqlCommand.Parameters.Add("@goodsunit", SqlDbType.VarChar).Value = import.GoodsUnit;
                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                    return true;
                }
                sqlConnection.Close();
                sqlConnection.Open();

                //trường hợp trùng ID, trung Unit
                String getWarehouse = "select * from warehouse where GoodsId = @goodsid and GoodsUnit = @goodsunit";
                sqlCommand = new SqlCommand(getWarehouse, sqlConnection);
                sqlCommand.Parameters.Add("@goodsid", SqlDbType.VarChar).Value = import.GoodsId;
                sqlCommand.Parameters.Add("@goodsunit", SqlDbType.VarChar).Value = import.GoodsUnit;

                if (sqlCommand.ExecuteReader().HasRows)
                {
                    sqlConnection.Close();
                    sqlConnection.Open();

                    sqlCommand = new SqlCommand(query_import, sqlConnection);
                    sqlCommand.Parameters.Add("@AccountantId", SqlDbType.VarChar).Value = import.AccountantId;
                    sqlCommand.Parameters.Add("@GoodsId", SqlDbType.VarChar).Value = import.GoodsId;
                    sqlCommand.Parameters.Add("@GoodsUnit", SqlDbType.VarChar).Value = import.GoodsUnit;
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = import.Quantity;
                    sqlCommand.Parameters.Add("@TotalPrice", SqlDbType.Float).Value = TotalPrice;
                    sqlCommand.Parameters.Add("@ImportDate", SqlDbType.Date).Value = import.ImportDate;
                    sqlCommand.ExecuteNonQuery();

                    //update bảng warehouse
                    sqlConnection.Close();
                    sqlConnection.Open();

                    sqlCommand = new SqlCommand(query_updateWarehouse, sqlConnection);
                    sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = import.GoodsId;
                    sqlCommand.Parameters.Add("@goodsunit", SqlDbType.VarChar).Value = import.GoodsUnit;
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = import.Quantity;
                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                    return true;
                }

                sqlConnection.Close();
                sqlConnection.Open();

                // trường hợp ko trùng ID và ko trùng ngày
                // thêm các thuộc tính trong bảng Imports
                sqlCommand = new SqlCommand(query_import, sqlConnection);
                sqlCommand.Parameters.Add("@AccountantId", SqlDbType.VarChar).Value = import.AccountantId;
                sqlCommand.Parameters.Add("@GoodsId", SqlDbType.VarChar).Value = import.GoodsId;
                sqlCommand.Parameters.Add("@GoodsUnit", SqlDbType.VarChar).Value = import.GoodsUnit;
                sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = import.Quantity;
                sqlCommand.Parameters.Add("@TotalPrice", SqlDbType.Float).Value = TotalPrice;
                sqlCommand.Parameters.Add("@ImportDate", SqlDbType.Date).Value = import.ImportDate;
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
                sqlConnection.Open();

                // thêm thuộc tính vào bảng warehouse
                sqlCommand = new SqlCommand(query_insertWarehouse, sqlConnection);
                sqlCommand.Parameters.Add("@GoodsId", SqlDbType.VarChar).Value = import.GoodsId;
                sqlCommand.Parameters.Add("@GoodsUnit", SqlDbType.VarChar).Value = import.GoodsUnit;
                sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = import.Quantity;
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Add sucessfull to ware house");

                sqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //Order
        public DataTable Order()
        {
            DataTable dataTable = new DataTable();
            String query = "select * from Orders";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        // thêm dữ liệu vào bảng orders
        public bool insert_goods_orders(Order orders)
        {
            if (orders.Quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0");
                return false;
            }
            SqlConnection sqlConnection = Connection.getConnection();
            String get_Id_sameDay = "select * from Orders where GoodsId =@goodsId and GoodsUnit = @goodsUnit and OrderDate=@date and AgentId=@AgentId";
            String get_prices = "select GoodsPrice from Goods where Goodsid =@goodsId and GoodsUnit = @goodsUnit";
            String get_QuantityWareHouse = "select Quantity from warehouse where GoodsId=@goodsId and GoodsUnit = @goodsUnit"; 

            String query_updateWarehouse = "update warehouse set Quantity=Quantity-@Quantity where GoodsId=@goodsId and GoodsUnit = @goodsUnit";
            String query_updatePriceQuantity = "update Orders set Quantity=Quantity+@Quantity,TotalPrice=TotalPrice+@TotalPrice where GoodsId=@goodsId and GoodsUnit = @goodsUnit and OrderDate=@OrderDate and AgentId=@AgentId";

            String query_orders = "insert into Orders values (@AgentId,@GoodsId,@GoodsUnit,@Quantity,@TotalPrice,@OrderDate,@chargeState,@deliveryState)";

            Boolean check_sameIdsameDay = false;
            Boolean check_sameId = false;

            sqlConnection.Open();
            sqlCommand = new SqlCommand(get_QuantityWareHouse, sqlConnection);
            sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = orders.GoodsId;
            sqlCommand.Parameters.Add("@goodsUnit", SqlDbType.VarChar).Value = orders.GoodsUnit;

            int quantity =999999999; // so sánh trong kho  
            if(sqlCommand.ExecuteScalar() !=null)
            {
                quantity = (int)sqlCommand.ExecuteScalar();

            }
            if (quantity < orders.Quantity)
            {
                MessageBox.Show("There are only" + quantity+ " left. Please choose less quantity");
                return false;
            }
            
            sqlConnection.Close();

            // tính total price trong orders
            Decimal price = 0;
            sqlConnection.Open();
            sqlCommand = new SqlCommand(get_prices, sqlConnection);
            sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = orders.GoodsId;
            sqlCommand.Parameters.Add("@goodsUnit", SqlDbType.VarChar).Value = orders.GoodsUnit;
            if (sqlCommand.ExecuteScalar() != null)
            {
                price = (Decimal)sqlCommand.ExecuteScalar();
            }
            Decimal TotalPrice = price * orders.Quantity;
            sqlConnection.Close();
            try
            {
                // trường hợp trùng ID và trùng ngày
                sqlConnection.Open();
                sqlCommand = new SqlCommand(get_Id_sameDay, sqlConnection);
                sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = orders.GoodsId;
                sqlCommand.Parameters.Add("@goodsUnit", SqlDbType.VarChar).Value = orders.GoodsUnit;
                sqlCommand.Parameters.Add("@date", SqlDbType.Date).Value = orders.OrderDate;
                sqlCommand.Parameters.Add("@AgentId", SqlDbType.VarChar).Value = orders.AgentId;

                if (sqlCommand.ExecuteReader().HasRows)
                {
                    sqlConnection.Close();
                    sqlConnection.Open();

                    check_sameIdsameDay = true;
                    sqlCommand = new SqlCommand(query_updatePriceQuantity, sqlConnection);
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = orders.Quantity;
                    sqlCommand.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value = TotalPrice;
                    sqlCommand.Parameters.Add("@OrderDate", SqlDbType.Date).Value = orders.OrderDate;
                    sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = orders.GoodsId;
                    sqlCommand.Parameters.Add("@goodsUnit", SqlDbType.VarChar).Value = orders.GoodsUnit;
                    sqlCommand.Parameters.Add("@AgentId", SqlDbType.VarChar).Value = orders.AgentId;
                    sqlCommand.ExecuteReader();

                    // update bảng warehouse
                    sqlConnection.Close();
                    sqlConnection.Open();

                    sqlCommand = new SqlCommand(query_updateWarehouse, sqlConnection);
                    sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = orders.GoodsId;
                    sqlCommand.Parameters.Add("@goodsUnit", SqlDbType.VarChar).Value = orders.GoodsUnit;
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = orders.Quantity;
                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                    return true;
                }
                sqlConnection.Close();
                sqlConnection.Open();
 
                // trường hợp ko trùng ID và ko trùng ngày
                if (check_sameId == false && check_sameIdsameDay == false)
                 {

                    // thêm các thuộc tính trong bảng Orders
                    sqlCommand = new SqlCommand(query_orders, sqlConnection);
                    sqlCommand.Parameters.Add("@AgentId", SqlDbType.VarChar).Value = orders.AgentId;
                    sqlCommand.Parameters.Add("@GoodsId", SqlDbType.VarChar).Value = orders.GoodsId;
                    sqlCommand.Parameters.Add("@GoodsUnit", SqlDbType.VarChar).Value = orders.GoodsUnit;
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = orders.Quantity;
                    sqlCommand.Parameters.Add("@TotalPrice", SqlDbType.Decimal).Value =TotalPrice;
                    sqlCommand.Parameters.Add("@OrderDate", SqlDbType.Date).Value = orders.OrderDate;
                    sqlCommand.Parameters.Add("@chargeState", SqlDbType.VarChar).Value = orders.chargeState;
                    sqlCommand.Parameters.Add("@deliveryState", SqlDbType.VarChar).Value = orders.deliveryState;
                    sqlCommand.ExecuteNonQuery();

                    // update thuộc tính vào bảng warehouse
                    sqlCommand = new SqlCommand(query_updateWarehouse, sqlConnection);
                    sqlCommand.Parameters.Add("@goodsId", SqlDbType.VarChar).Value = orders.GoodsId;
                    sqlCommand.Parameters.Add("@goodsUnit", SqlDbType.VarChar).Value = orders.GoodsUnit;
                    sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = orders.Quantity;
                    sqlCommand.ExecuteNonQuery();

                    return true;
                 }
                 sqlConnection.Close();
            }
            catch
            {
                return false;

            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool update_goods_orders(Order orders)
        {
            if (orders.Quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0");
                return false;
            }
            SqlConnection sqlConnection = Connection.getConnection();
            String query_updateOrder = "update Orders set chargeState=@chargeState,deliveryState=@deliveryState where AgentId=@AgentId and GoodsId=@GoodsId and GoodsUnit = @GoodsUnit and OrderDate=@OrderDate";

            sqlCommand = new SqlCommand(query_updateOrder, sqlConnection);

            // tính total price trong orders
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@AgentId", SqlDbType.VarChar).Value = orders.AgentId;
            sqlCommand.Parameters.Add("@GoodsId", SqlDbType.VarChar).Value = orders.GoodsId;
            sqlCommand.Parameters.Add("@GoodsUnit", SqlDbType.VarChar).Value = orders.GoodsUnit;
            sqlCommand.Parameters.Add("@OrderDate", SqlDbType.Date).Value = orders.OrderDate;
            sqlCommand.Parameters.Add("@chargeState", SqlDbType.VarChar).Value = orders.chargeState;
            sqlCommand.Parameters.Add("@deliveryState", SqlDbType.VarChar).Value = orders.deliveryState;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        // Best Selling
        public DataTable BestSelling()
        {
            DataTable dataTable = new DataTable();
            String query = "select Goods.GoodsId,Goods.GoodsUnit,GoodsName,GoodsPrice,Best.[Best Selling] from Goods right join (select o.GoodsId,SUM(Quantity) as 'Best Selling' from Orders o group by o.GoodsId having SUM(Quantity)=(select max(count) from ( select sum(Quantity)as count,GoodsId from Orders group by GoodsId) as sta)) as Best on Goods.GoodsId=Best.GoodsId\r\n";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        // Monthly Income
        public DataTable MonthlyIncome()
        {
            DataTable dataTable = new DataTable();
            //String query1 = "select MONTH(OrderDate) as 'Month',sum(TotalPrice) as 'Monthly Income' from Orders group by MONTH(OrderDate)";
            String query = "select CONCAT(MONTH(OrderDate),'/',YEAR(OrderDate)) as 'Month/Year',sum(TotalPrice) as 'Monthly Income' from Orders group by MONTH(OrderDate), Year(OrderDate)";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        // Danh sách nhà phân phối
        public DataTable ManufacturerList()
        {
            DataTable dataTable = new DataTable();
            String query = "select * from Manufacturer";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }
        
        // Danh sách sản phẩm tốt
        public DataTable GoodsList()
        {
            DataTable dataTable = new DataTable();
            String query = "select * from Goods";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        // Thêm sản phẩm
        public bool insert_goods(Goods g)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            try
            {
                String query = "insert into Goods values (@id, @unit, @name, @price, @manuid)";
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = g.GoodsId;
                sqlCommand.Parameters.Add("@unit", SqlDbType.VarChar).Value = g.GoodsUnit;
                sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = g.GoodsName;
                sqlCommand.Parameters.Add("@price", SqlDbType.VarChar).Value = g.GoodsPrice;
                sqlCommand.Parameters.Add("@manuid", SqlDbType.VarChar).Value = g.ManuId;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;

            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        // Thêm nhà phân phối
        public bool insert_manufacturer(Manufacturer m)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            try
            {
                String query = "insert into Manufacturer values (@id, @name, @address)";
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = m.ManufacturerId;
                sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = m.ManufacturerName;
                sqlCommand.Parameters.Add("@address", SqlDbType.VarChar).Value = m.Address;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;

            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
    }
}