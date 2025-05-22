//using System;
//using System.Collections.Generic;
//using Microsoft.Data.SqlClient;
//using System.Data;

//namespace ElectronicGadgetsLibrary
//{
//    public class CustomerService : ICustomers
//    {
//        public void AddCustomer(Customers cust)
//        {
//            try
//            {
//                using SqlConnection cn = DBPropertyUtil.AppConnection();
//                SqlCommand cmd = new SqlCommand("InsertCustomerData_TechShop", cn)
//                {
//                    CommandType = CommandType.StoredProcedure
//                };

//                cmd.Parameters.AddWithValue("@CustomerID", cust.CustomerID);
//                cmd.Parameters.AddWithValue("@FirstName", cust.FirstName);
//                cmd.Parameters.AddWithValue("@LastName", cust.LastName);
//                cmd.Parameters.AddWithValue("@Email", cust.Email);
//                cmd.Parameters.AddWithValue("@Phone", cust.Phone);
//                cmd.Parameters.AddWithValue("@Address", cust.Address);

//                cn.Open();
//                cmd.ExecuteNonQuery();
//            }
//            catch(SqlException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }

//        public void UpdateCustomer(Customers cust)
//        {
//            try { 
//            using SqlConnection cn = DBPropertyUtil.AppConnection();
//            SqlCommand cmd = new SqlCommand("UpdateCustomerData_TechShop", cn) 
//            {
//                CommandType = CommandType.StoredProcedure
//            };

//            cmd.Parameters.AddWithValue("@CustomerID", cust.CustomerID);
//            cmd.Parameters.AddWithValue("@FirstName", cust.FirstName);
//            cmd.Parameters.AddWithValue("@LastName", cust.LastName);
//            cmd.Parameters.AddWithValue("@Email", cust.Email);
//            cmd.Parameters.AddWithValue("@Phone", cust.Phone);
//            cmd.Parameters.AddWithValue("@Address", cust.Address);

//            cn.Open();
//            cmd.ExecuteNonQuery();
//            }
//            catch(SqlException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//}

//        public void DeleteCustomer(int id)
//        {
//            try { 
//            using SqlConnection cn = DBPropertyUtil.AppConnection();
//            SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE customerID = @id", cn);
//            cmd.Parameters.AddWithValue("@id", id);
//            cn.Open();
//            cmd.ExecuteNonQuery();
//            }
//            catch(SqlException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//}

//        public Customers GetCustomerByID(int id)
//        {
//            try {
//            Customers cust = null;
//            using SqlConnection cn = DBPropertyUtil.AppConnection();
//            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE customerID = @id", cn);
//            cmd.Parameters.AddWithValue("@id", id);
//            cn.Open();
//            using SqlDataReader reader = cmd.ExecuteReader();
//            if (reader.Read())
//            {
//                cust = new Customers
//                {
//                    CustomerID = Convert.ToInt32(reader["customerID"]),
//                    FirstName = reader["firstName"].ToString(),
//                    LastName = reader["lastName"].ToString(),
//                    Email = reader["email"].ToString(),
//                    Phone = reader["phone"].ToString(),
//                    Address = reader["customerAddress"].ToString()
//                };
//            }
//            return cust ?? throw new Exception("Customer not found");
//            }
//            catch(SqlException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//}

//        public Customers GetCustomerByName(string name)
//        {
//            try { 
//            Customers cust = null;
//            using SqlConnection cn = DBPropertyUtil.AppConnection();
//            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE firstName = @name", cn);
//            cmd.Parameters.AddWithValue("@name", name);
//            cn.Open();
//            using SqlDataReader reader = cmd.ExecuteReader();
//            if (reader.Read())
//            {
//                cust = new Customers
//                {
//                    CustomerID = Convert.ToInt32(reader["customerID"]),
//                    FirstName = reader["firstName"].ToString(),
//                    LastName = reader["lastName"].ToString(),
//                    Email = reader["email"].ToString(),
//                    Phone = reader["phone"].ToString(),
//                    Address = reader["customerAddress"].ToString()
//                };
//            }
//            return cust ?? throw new Exception("Customer not found");
//            }
//            catch(SqlException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//}

//        public List<Customers> GetAllCustomers()
//        {
//            try { 
//            List<Customers> list = new();
//            using SqlConnection cn = DBPropertyUtil.AppConnection();
//            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", cn);
//            cn.Open();
//            using SqlDataReader reader = cmd.ExecuteReader();
//            while (reader.Read())
//            {
//                list.Add(new Customers
//                {
//                    CustomerID = Convert.ToInt32(reader["customerID"]),
//                    FirstName = reader["firstName"].ToString(),
//                    LastName = reader["lastName"].ToString(),
//                    Email = reader["email"].ToString(),
//                    Phone = reader["phone"].ToString(),
//                    Address = reader["customerAddress"].ToString()
//                });
//            }
//            return list;
//            }
//            catch(SqlException ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//}
//    }
//}

using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ElectronicGadgetsLibrary
{
    public class CustomerService : ICustomers
    {
        public void AddCustomer(Customers cust)
        {
            SqlConnection cn = null;
            try
            {
                cn = DBPropertyUtil.AppConnection();
                using SqlCommand cmd = new SqlCommand("InsertCustomerData_TechShop", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CustomerID", cust.CustomerID);
                cmd.Parameters.AddWithValue("@FirstName", cust.FirstName);
                cmd.Parameters.AddWithValue("@LastName", cust.LastName);
                cmd.Parameters.AddWithValue("@Email", cust.Email);
                cmd.Parameters.AddWithValue("@Phone", cust.Phone);
                cmd.Parameters.AddWithValue("@Address", cust.Address);

                cn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Customer added successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Failed to add customer. " + ex.Message);
            }
            finally
            {
                cn?.Close();
            }
        }

        public void UpdateCustomer(Customers cust)
        {
            SqlConnection cn = null;
            try
            {
                cn = DBPropertyUtil.AppConnection();
                using SqlCommand cmd = new SqlCommand("UpdateCustomerData_TechShop", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CustomerID", cust.CustomerID);
                cmd.Parameters.AddWithValue("@FirstName", cust.FirstName);
                cmd.Parameters.AddWithValue("@LastName", cust.LastName);
                cmd.Parameters.AddWithValue("@Email", cust.Email);
                cmd.Parameters.AddWithValue("@Phone", cust.Phone);
                cmd.Parameters.AddWithValue("@Address", cust.Address);

                cn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Customer updated successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Failed to update customer. " + ex.Message);
            }
            finally
            {
                cn?.Close();
            }
        }

        public void DeleteCustomer(int id)
        {
            SqlConnection cn = null;
            try
            {
                cn = DBPropertyUtil.AppConnection();
                using SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE customerID = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Customer deleted successfully." : "Customer not found.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Failed to delete customer. " + ex.Message);
            }
            finally
            {
                cn?.Close();
            }
        }

        public Customers GetCustomerByID(int id)
        {
            SqlConnection cn = null;
            try
            {
                Customers cust = null;
                cn = DBPropertyUtil.AppConnection();
                using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE customerID = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);

                cn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cust = new Customers
                    {
                        CustomerID = Convert.ToInt32(reader["customerID"]),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        Email = reader["email"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Address = reader["customerAddress"].ToString()
                    };
                    Console.WriteLine("Customer retrieved successfully.");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }

                return cust;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Failed to retrieve customer. " + ex.Message);
                return null;
            }
            finally
            {
                cn?.Close();
            }
        }

        public Customers GetCustomerByName(string name)
        {
            SqlConnection cn = null;
            try
            {
                Customers cust = null;
                cn = DBPropertyUtil.AppConnection();
                using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE firstName = @name", cn);
                cmd.Parameters.AddWithValue("@name", name);

                cn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cust = new Customers
                    {
                        CustomerID = Convert.ToInt32(reader["customerID"]),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        Email = reader["email"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Address = reader["customerAddress"].ToString()
                    };
                    Console.WriteLine("Customer retrieved successfully.");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }

                return cust;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Failed to retrieve customer. " + ex.Message);
                return null;
            }
            finally
            {
                cn?.Close();
            }
        }

        public List<Customers> GetAllCustomers()
        {
            SqlConnection cn = null;
            try
            {
                List<Customers> list = new();
                cn = DBPropertyUtil.AppConnection();
                using SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", cn);

                cn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Customers
                    {
                        CustomerID = Convert.ToInt32(reader["customerID"]),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        Email = reader["email"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Address = reader["customerAddress"].ToString()
                    });
                }

                Console.WriteLine("Customers retrieved successfully.");
                return list;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Failed to retrieve customers. " + ex.Message);
                return new List<Customers>();
            }
            finally
            {
                cn?.Close();
            }
        }
    }
}

