using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace KitchenDALLibrary
{
    public class FoodItemsDAL
    {
        public string kitchenStr;
        public SqlConnection con;

        public FoodItemsDAL()
        {
            kitchenStr = ConfigurationManager.ConnectionStrings["KitchenStoryDB"].ConnectionString;
            con = new SqlConnection(kitchenStr);
        }

        public List<FoodItems> GetAllFoodItem()
        {
            List<FoodItems> foodItemList = new List<FoodItems>();
            SqlCommand cmd = new SqlCommand("Select * from FoodItems", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                FoodItems item = new FoodItems();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.Name = reader["FoodName"].ToString();
                item.Price = Convert.ToSingle(reader["price"]);
                foodItemList.Add(item);
            }
            con.Close();
            con.Dispose();
            return foodItemList;
        }

        public FoodItems GetFoodItemById(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * from FoodItems where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            FoodItems item = null;

            if (reader.HasRows)
            {
                reader.Read();

                item = new FoodItems
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["FoodName"].ToString(),
                    Price = Convert.ToSingle(reader["price"])
                };
            }

            con.Close();
            con.Dispose();
            return item;
        }


        public bool AddFoodItem(FoodItems foodItems)
        {
            SqlCommand cmd = new SqlCommand("dbo.sp_InsertFoodItem", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_Name", foodItems.Name);
            cmd.Parameters.AddWithValue("@p_Price", foodItems.Price);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return true;
        }

        public bool UpdateFoodItem(FoodItems foodItems)
        {
            SqlCommand cmd = new SqlCommand("dbo.sp_UpdateFoodItem", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_Id", foodItems.Id);
            cmd.Parameters.AddWithValue("@p_Name", foodItems.Name);
            cmd.Parameters.AddWithValue("@p_Price", foodItems.Price);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return true;

        }
        public bool DeleteFoodItem(int id)
        {
            SqlCommand cmd = new SqlCommand("Delete * from FoodItems where Id=" + id, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
            return true;
        }
    }
}
