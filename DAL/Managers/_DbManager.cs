﻿using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using static DAL.Enum;

namespace DAL.Managers
{
    public class _DbManager<T>
    {
        private readonly string _connectionString;

        public _DbManager()
        {
            _connectionString = "Server = (localdb)\\MSSQLLocalDB; Database = INCUBE_PROJECT; Trusted_Connection = True; MultipleActiveResultSets = true";
        }

        public EnumResult ExecuteMethod(string query)
        {
          using (IDbConnection dbConnection = new SqlConnection(_connectionString))
          {
                try
                {
                    dbConnection.Open();
                    int rowsAffected = dbConnection.Execute(query);                    

                    return rowsAffected > 0 ? EnumResult.Success : EnumResult.Fail;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error occurred:- " + ex.Message);
                    return EnumResult.Fail;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occered:- " + ex.Message);
                    return EnumResult.Other;
                }
                finally 
                { 
                    dbConnection.Close(); 
                }            
          }
        }

        public int ExecuteTransaction(string query)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                    try
                    {
                        dbConnection.Open();
                        return Convert.ToInt32(dbConnection.ExecuteScalar(query));
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error occurred:- " + ex.Message);
                        return -1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error occurred:- " + ex.Message);
                        return -1;
                    }
                    finally
                    {
                        dbConnection.Close();
                    }
            }
        }

        public IEnumerable<T> GetAll(string query)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<T>(query).ToList();
            }
        }

        public T GetSingle<T>(string query)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.QuerySingle<T>(query);

            }
        }
    }
}